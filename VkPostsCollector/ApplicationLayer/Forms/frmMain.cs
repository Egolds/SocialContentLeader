using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VkPostsCollector.ApplicationLayer;
using VkPostsCollector.ApplicationLayer.Common;
using VkPostsCollector.ApplicationLayer.Forms;
using VkPostsCollector.BotLayer;
using VkPostsCollector.BusinessLayer;
using VkPostsCollector.DataAccessLayer.API;

namespace ApplicationLayer.VkPostsCollector
{
    public partial class frmMain : Form
    {
        private BackgroundWorker worker;
        private TelegramPosterBot bot;

        private DataGridViewRow lastSelectedRow;
        private bool NeedUnselectRow = false;

        #region -- Load --

        public frmMain()
        {
            InitializeComponent();
            Configs.GroupsLoad();
            Configs.FiltersLoad();
            InitForm();
        }

        private void InitForm()
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;

            FillContextMenu();
            UpdatePostsCount();

            cbAutobotMode_CheckedChanged(null, null);
        }

        private void FillContextMenu()
        {
            for (int i = 0; i < dgvPosts.ColumnCount; i++)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(dgvPosts.Columns[i].HeaderText);
                tsmi.Checked = dgvPosts.Columns[i].Visible;
                tsmi.Tag = dgvPosts.Columns[i];
                tsmi.Click += ContextMenuHideShowColumn;
                cmsPostsColumns.Items.Add(tsmi);
            }
        }

        #endregion

        private void StartCollection()
        {
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += Collector_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tlpHeader.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = false;

            if (dgvPosts.SelectedRows.Count > 0)
            {
                dgvPosts.SelectedRows[0].Selected = false;
            }

            MessageBox.Show("Сбор постов завершен");
        }

        private void Collector_DoWork(object sender, DoWorkEventArgs e)
        {
            int RequestedQuantity = (int)nudQuantity.Value;
            
            for (int g = 0; g < Configs.Groups.Count; g++)
            {
                int CollectedQuantity = 0;

                while (CollectedQuantity < RequestedQuantity)
                {
                    int CurrentQuantity = RequestedQuantity - CollectedQuantity;
                    if (CurrentQuantity > 100) CurrentQuantity = 100;

                    List<VkPublicationDTO> publications = VkAPI.GetWallPosts(Configs.Groups[g], CurrentQuantity, CollectedQuantity, Configs.AccessToken);

                    if (publications != null)
                    {
                        for (int i = 0; i < publications.Count; i++)
                            AddRow(publications[i]);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка во время сбора публикаций");
                    }

                    CollectedQuantity += CurrentQuantity;
                }
            }
        }

        private void AddRow(VkPublicationDTO publication, bool IsPublicated = false)
        {
            dgvPosts.Invoke(new MethodInvoker(() =>
            {
                int NewRowIndex = dgvPosts.Rows.Add();
                DataGridViewRow pRow = dgvPosts.Rows[NewRowIndex];
                pRow.Tag = publication;

                pRow.Cells["colGroupName"].Value = publication.Group.Name;
                pRow.Cells["colCreated"].Value = publication.Created;
                pRow.Cells["colType"].Value = publication.PostType + (publication.IsRepost ? " (Repost)" : string.Empty);
                pRow.Cells["colGroupLink"].Value = publication.Group.URL;
                pRow.Cells["colPublicationLink"].Value = publication.PostLink;
                pRow.Cells["colLikes"].Value = publication.Likes;
                pRow.Cells["colReposts"].Value = publication.Reposts;
                pRow.Cells["colComments"].Value = publication.Comments;
                pRow.Cells["colViews"].Value = publication.Views;
                pRow.Cells["colLikesCTR"].Value = Math.Round(publication.Likes / publication.Views, 4, MidpointRounding.ToEven) + "%";
                pRow.Cells["colPinned"].Value = Converters.BoolToText(publication.IsPinned);
                pRow.Cells["colMarkedAsAds"].Value = Converters.BoolToText(publication.MarkedAsAds);
                pRow.Cells["colExistsAttachments"].Value = Converters.BoolToText(publication.ExistsAttachments);
                pRow.Cells["colExistsSigner"].Value = Converters.BoolToText(publication.ExistsSigner);
                pRow.Cells["colSignerLink"].Value = publication.SignerLink;
                pRow.Cells["colLinks"].Value = string.Join(" ", publication.Links);
                pRow.Cells["colExistsLinks"].Value = Converters.BoolToText(publication.ExistsLinks);

                pRow.Cells["colIsPublicated"].Value = Converters.BoolToText(IsPublicated);
            }));
        }

        private void UpdatePostsCount()
        {
            lblCount.Text = "Всего записей: " + dgvPosts.RowCount;
        }

        #region -- UI Events --

        private void btnAddGroups_Click(object sender, EventArgs e)
        {
            using (frmGroups frmGroups = new frmGroups(Configs.AccessToken))
            {
                if (frmGroups.ShowDialog() == DialogResult.OK)
                {
                    Configs.Groups = frmGroups.Groups;
                    Configs.GroupsSave();
                }
            }
        }

        private void btnFiltres_Click(object sender, EventArgs e)
        {
            new frmFilters().ShowDialog();
        }

        private void cbAutobotMode_CheckedChanged(object sender, EventArgs e)
        {
            nudQuantity.Enabled = !cbAutobotMode.Checked;
            colIsPublicated.Visible = cbAutobotMode.Checked;

            if (cbAutobotMode.Checked)
            {
                btnStart.Text = "Запустить бота";
                btnStop.Text = "Остановть бота";
            }
            else
            {
                btnStart.Text = "Запустить сбор";
                btnStop.Text = "Остановть сбор";
            }

            for (int i = 0; i < cmsPostsColumns.Items.Count; i++)
            {
                DataGridViewColumn column = (DataGridViewColumn)cmsPostsColumns.Items[i].Tag;
                if (column.Name == "colIsPublicated")
                {
                    cmsPostsColumns.Items[i].Visible = cbAutobotMode.Checked;
                    (cmsPostsColumns.Items[i] as ToolStripMenuItem).Checked = cbAutobotMode.Checked;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (dgvPosts.Rows.Count > 0 &&
                DialogResult.No == MessageBox.Show("Текущие записи будут очищены, продолжить?", "Очистка результатов", MessageBoxButtons.YesNo))
                return;

            dgvPosts.Rows.Clear();

            tlpHeader.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            if (cbAutobotMode.Checked == false)
            {
                StartCollection();
            }
            else
            {
                bot = new TelegramPosterBot(Configs.PublicationFilters.PublicateTimeFrom, Configs.PublicationFilters.PublicateTimeTo);
                bot.OnPublicationSended += Bot_OnPublicationSended;
                bot.OnPublicationCanceled += Bot_OnPublicationCanceled;
                bot.OnLogWrite += Bot_OnLogWrite;

                bot.Start();
            }
        }
        
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (cbAutobotMode.Checked == false)
                worker.CancelAsync();
            else
            {
                bot.Stop();

                btnStart.Enabled = true;
                btnStop.Enabled = false;
                tlpHeader.Enabled = true;
            }
        }
        
        #region -- DataGrid --

        private void dgvPosts_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.RowIndex < 0) return;
            DataGridViewRow row = dgvPosts.Rows[e.RowIndex];
            if (row.Selected) NeedUnselectRow = true;
            else NeedUnselectRow = false;
        }
        
        private void dgvPosts_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvPosts.Rows[e.RowIndex];

            if (e.Button == MouseButtons.Left)
            {
                lastSelectedRow = row;

                if (dgvPosts.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewLinkColumn))
                {
                    if (row.Cells[e.ColumnIndex].Value != null)
                    {
                        string link = row.Cells[e.ColumnIndex].Value.ToString();
                        if (DialogResult.Yes == MessageBox.Show("Открыть ссылку?\r\n" + link, "", MessageBoxButtons.YesNo))
                            Process.Start(link);

                        return;
                    }
                }
                else
                {
                    if (NeedUnselectRow == false)
                    {

                    }
                }

                if (NeedUnselectRow) row.Selected = false;
            }
            else if (e.Button == MouseButtons.Right && row.Selected)
            {
                cmsPost.Show(Cursor.Position);
            }
        }

        private void dgvPosts_SelectionChanged(object sender, EventArgs e)
        {
            if (lastSelectedRow == null) return;
            foreach (DataGridViewCell cell in lastSelectedRow.Cells)
            {
                if (cell.GetType() == typeof(DataGridViewLinkCell))
                {
                    if (cell.Selected) (cell as DataGridViewLinkCell).LinkColor = Color.White;
                    else (cell as DataGridViewLinkCell).LinkColor = Color.Blue;
                }
                else
                {
                    if (cell.Selected) cell.Style.ForeColor = Color.White;
                    else cell.Style.ForeColor = Color.Black;
                }
            }
        }

        private void dgvPosts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                cmsPostsColumns.Show(Cursor.Position);
        }

        private void ContextMenuHideShowColumn(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;

            if (tsmi.Checked)
            {
                for (int i = 0; i < cmsPostsColumns.Items.Count; i++)
                {
                    if (cmsPostsColumns.Items.OfType<ToolStripMenuItem>().ToList().FindAll(x => x.Checked).Count == 1)
                        return;
                }
            }

            tsmi.Checked = !tsmi.Checked;
            ((DataGridViewColumn)tsmi.Tag).Visible = !((DataGridViewColumn)tsmi.Tag).Visible;
        }

        private void cmsPostsColumns_Opening(object sender, CancelEventArgs e)
        {
            
        }

        private void dgvPosts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdatePostsCount();
        }

        private void dgvPosts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdatePostsCount();
        }



        #endregion

        #region -- Context Menu --

        private void tsmiShowPostText_Click(object sender, EventArgs e)
        {
            VkPublicationDTO publication = (VkPublicationDTO)dgvPosts.SelectedRows[0].Tag;

            MessageBox.Show(publication.Text, "Содержимое записи");
        }

        private void tsmiShowImages_Click(object sender, EventArgs e)
        {
            VkPublicationDTO publication = (VkPublicationDTO)dgvPosts.SelectedRows[0].Tag;
            
            frmImages imagesPanel = new frmImages();
            imagesPanel.AddImageRange(publication.ImageLinks.ToArray());
            imagesPanel.Show(this);
        }

        private void tsmiPublicate_ClickAsync(object sender, EventArgs e)
        {
            VkPublicationDTO publication = (VkPublicationDTO)dgvPosts.SelectedRows[0].Tag;

            TelegramPublicationDTO telegramPost = PublicationCreator.CreateTelegramPublication(publication);
            
            if(telegramPost == null)
            {
                MessageBox.Show("Ошибка публикации.");
                return;
            }
            else if(telegramPost.Error.Length > 0)
            {
                MessageBox.Show(telegramPost.Error);
                return;
            }
            else if (telegramPost.CanPublicate == false)
            {
                MessageBox.Show("Публикация отклонена. Не соответствует фильтру.");
                return;
            }

            bool ExistsImage = false;
            if (telegramPost.PhotoUrl != null && telegramPost.PhotoUrl != string.Empty)
                ExistsImage = true;

            TelegramAPI.SendPublicationAsync(telegramPost, ExistsImage);
        }

        #endregion

        #endregion

        private void Bot_OnLogWrite(string LOG)
        {
            tbLog.Invoke(new MethodInvoker(() =>
            {
                tbLog.Text += $"[{bot.CurrentTime.ToString("hh\\:mm\\:ss")}]: " + LOG + "\r\n\r\n";
                tbLog.Select(tbLog.Text.Length, 0);
                tbLog.ScrollToCaret();
            }));
        }

        private void Bot_OnPublicationSended(TelegramPublicationDTO telegramPublicationDTO)
        {
            AddRow(telegramPublicationDTO.VkPublication, true);
        }

        private void Bot_OnPublicationCanceled(TelegramPublicationDTO telegramPublicationDTO)
        {
            AddRow(telegramPublicationDTO.VkPublication, false);
        }

        private void btnTesting_Click(object sender, EventArgs e)
        {
            TelegramPosterBot bot = new TelegramPosterBot(Configs.PublicationFilters.PublicateTimeFrom, Configs.PublicationFilters.PublicateTimeTo);
            bot.Start();
        }

        
    }
}
