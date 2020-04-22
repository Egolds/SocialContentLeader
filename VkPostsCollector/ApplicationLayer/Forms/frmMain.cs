using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkPostsCollector.ApplicationLayer.Common;
using VkPostsCollector.BusinessLayer;
using System.Diagnostics;
using VkPostsCollector.DataAccessLayer.API;
using VkPostsCollector.ApplicationLayer.Forms;

namespace ApplicationLayer.VkPostsCollector
{
    public partial class frmMain : Form
    {
        private string TestGroup = "top_ali_shmot";
        private const string AccessToken = "20e0e7e620e0e7e620e0e7e6e420901b4d220e020e0e7e67e72e2ea810c2598e177d57b";

        private BackgroundWorker worker;

        private DataGridViewRow lastSelectedRow;
        private bool NeedUnselectRow = false;

        #region -- Load --

        public frmMain()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;

            FillContextMenu();
            UpdatePostsCount();
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
            btnStart.Enabled = true;
            btnStop.Enabled = false;

            dgvPosts.SelectedRows[0].Selected = false;

            MessageBox.Show("Сбор постов завершен");
        }

        private void Collector_DoWork(object sender, DoWorkEventArgs e)
        {
            int RequestedQuantity = (int)nudQuantity.Value;
            int CollectedQuantity = 0;
            
            while(CollectedQuantity < RequestedQuantity)
            {
                int CurrentQuantity = RequestedQuantity - CollectedQuantity;
                if (CurrentQuantity > 100) CurrentQuantity = 100;

                List<PublicationDTO> publications = VkAPI.GetWallPosts(TestGroup, CurrentQuantity, CollectedQuantity, AccessToken);

                for (int i = 0; i < publications.Count; i++)
                    AddRow(publications[i]);

                CollectedQuantity += CurrentQuantity;
            }
        }

        private void AddRow(PublicationDTO publication)
        {
            dgvPosts.Invoke(new MethodInvoker(() =>
            {
                int NewRowIndex = dgvPosts.Rows.Add();
                DataGridViewRow pRow = dgvPosts.Rows[NewRowIndex];
                pRow.Tag = publication;

                pRow.Cells["colGroupName"].Value = publication.GroupName;
                pRow.Cells["colCreated"].Value = publication.Created;
                pRow.Cells["colType"].Value = publication.PostType + (publication.IsRepost ? " (Repost)" : string.Empty);
                pRow.Cells["colGroupLink"].Value = publication.GroupLink;
                pRow.Cells["colPublicationLink"].Value = publication.PostLink;
                pRow.Cells["colLikes"].Value = publication.Likes;
                pRow.Cells["colReposts"].Value = publication.Reposts;
                pRow.Cells["colComments"].Value = publication.Comments;
                pRow.Cells["colViews"].Value = publication.Views;
                pRow.Cells["colPinned"].Value = Converters.BoolToText(publication.IsPinned);
                pRow.Cells["colMarkedAsAds"].Value = Converters.BoolToText(publication.MarkedAsAds);
                pRow.Cells["colExistsAttachments"].Value = Converters.BoolToText(publication.ExistsAttachments);
                pRow.Cells["colExistsSigner"].Value = Converters.BoolToText(publication.ExistsSigner);
                pRow.Cells["colSignerLink"].Value = publication.SignerLink;
                pRow.Cells["colLinks"].Value = string.Join(" ", publication.Links);
                pRow.Cells["colExistsLinks"].Value = Converters.BoolToText(publication.ExistsLinks);
        }));
        }

        private void UpdatePostsCount()
        {
            lblCount.Text = "Всего записей: " + dgvPosts.RowCount;
        }

        #region -- UI Events --

        private void btnAddGroups_Click(object sender, EventArgs e)
        {

        }

        private void btnFiltres_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (dgvPosts.Rows.Count > 0 &&
                DialogResult.No == MessageBox.Show("Текущие записи будут очищены, продолжить?", "Очистка результатов", MessageBoxButtons.YesNo))
                return;

            dgvPosts.Rows.Clear();

            btnStart.Enabled = false;
            btnStop.Enabled = true;

            StartCollection();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            worker.CancelAsync();
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

        private void dgvPosts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdatePostsCount();
        }

        private void dgvPosts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdatePostsCount();
        }



        #endregion

        private void tsmiShowPostText_Click(object sender, EventArgs e)
        {
            PublicationDTO publication = (PublicationDTO)dgvPosts.SelectedRows[0].Tag;

            MessageBox.Show(publication.Text, "Содержимое записи");
        }

        private void tsmiShowImages_Click(object sender, EventArgs e)
        {
            PublicationDTO publication = (PublicationDTO)dgvPosts.SelectedRows[0].Tag;

            //MessageBox.Show(string.Join("\r\n", publication.ImageLinks), "Изображения");
            frmImages imagesPanel = new frmImages();
            imagesPanel.AddImageRange(publication.ImageLinks.ToArray());
            imagesPanel.Show();
        }


        #endregion

        private void btnTesting_Click(object sender, EventArgs e)
        {
            string link = AdmitadAPI.CreateUrl("https://alitems.com/g/1e8d114494bd0482fb1316525dc3e8/", "https://aliexpress.ru/item/32822822772.html");
        }
    }
}
