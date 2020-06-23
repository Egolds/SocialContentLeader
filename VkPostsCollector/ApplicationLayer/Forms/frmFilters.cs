using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using VkPostsCollector.BusinessLayer;

namespace VkPostsCollector.ApplicationLayer.Forms
{
    public partial class frmFilters : Form
    {
        public frmFilters()
        {
            InitializeComponent();

            LoadParameters();
        }

        private void LoadParameters()
        {
            nudQuantityPostsFromGroup_ValueChanged(null, null);

            cbMaxQuantityAdLinks.Checked = Configs.PublicationFilters.MaxQuantityAdLinks > -1;
            nudMaxQuantityAdLinks.Value = Configs.PublicationFilters.MaxQuantityAdLinks > -1 ? Configs.PublicationFilters.MaxQuantityAdLinks : 0;

            cbMaxQuantityLikes.Checked = Configs.PublicationFilters.MaxQuantityLikes > -1;
            nudMaxQuantityLikes.Value = Configs.PublicationFilters.MaxQuantityLikes > -1 ? Configs.PublicationFilters.MaxQuantityLikes : 0;
            cbMinQuantityLikes.Checked = Configs.PublicationFilters.MinQuantityLikes > -1;
            nudMinQuantityLikes.Value = Configs.PublicationFilters.MinQuantityLikes > -1 ? Configs.PublicationFilters.MinQuantityLikes : 0;

            cbMaxQuantityComments.Checked = Configs.PublicationFilters.MaxQuantityComments > -1;
            nudMaxQuantityComments.Value = Configs.PublicationFilters.MaxQuantityComments > -1 ? Configs.PublicationFilters.MaxQuantityComments : 0;
            cbMinQuantityComments.Checked = Configs.PublicationFilters.MinQuantityComments > -1;
            nudMinQuantityComments.Value = Configs.PublicationFilters.MinQuantityComments > -1 ? Configs.PublicationFilters.MinQuantityComments : 0;

            cbMaxQuantityReposts.Checked = Configs.PublicationFilters.MaxQuantityReposts > -1;
            nudMaxQuantityReposts.Value = Configs.PublicationFilters.MaxQuantityReposts > -1 ? Configs.PublicationFilters.MaxQuantityReposts : 0;
            cbMinQuantityReposts.Checked = Configs.PublicationFilters.MinQuantityReposts > -1;
            nudMinQuantityReposts.Value = Configs.PublicationFilters.MinQuantityReposts > -1 ? Configs.PublicationFilters.MinQuantityReposts : 0;

            cbMaxQuantityChars.Checked = Configs.PublicationFilters.MaxQuantityChars > -1;
            nudMaxQuantityChars.Value = Configs.PublicationFilters.MaxQuantityChars > -1 ? Configs.PublicationFilters.MaxQuantityChars : 0;

            tbKeyWordsBlackList.Clear();
            foreach (string keyword in Configs.PublicationFilters.KeyWordsBlackList)
                tbKeyWordsBlackList.Text = keyword + ", ";
            tbKeyWordsBlackList.Text = tbKeyWordsBlackList.Text.TrimEnd(' ', ',');

            cbAllowReposts.Checked = Configs.PublicationFilters.AllowReposts;
            cbAllowPinned.Checked = Configs.PublicationFilters.AllowPinned;
            cbAllowMarkedAsAds.Checked = Configs.PublicationFilters.AllowMarkedAsAds;
            cbAllowWithSigner.Checked = Configs.PublicationFilters.AllowWithSigner;
            cbAllowPublicateWithoutImages.Checked = Configs.PublicationFilters.AllowPublicateWithoutImages;
            cbAllowPublicateWithSmiles.Checked = Configs.PublicationFilters.AllowPublicateWithSmiles;
            cbAllowPublicateWithHashtags.Checked = Configs.PublicationFilters.AllowPublicateWithHashtags;

            cmbPriority.SelectedIndex = (int)Configs.PublicationFilters.Priority;

            cbQuantityPostsFromGroup.Checked = Configs.PublicationFilters.QuantityPostsFromGroup > -1;
            nudQuantityPostsFromGroup.Value = Configs.PublicationFilters.QuantityPostsFromGroup > -1 ? Configs.PublicationFilters.QuantityPostsFromGroup : 0;

            cbMaxQuantityPostsDaily.Checked = Configs.PublicationFilters.MaxQuantityPostsDaily > -1;
            nudMaxQuantityPostsDaily.Value = Configs.PublicationFilters.MaxQuantityPostsDaily > -1 ? Configs.PublicationFilters.MaxQuantityPostsDaily : 0;

            cbMinQuantityPostsDaily.Checked = Configs.PublicationFilters.MinQuantityPostsDaily > -1;
            nudMinQuantityPostsDaily.Value = Configs.PublicationFilters.MinQuantityPostsDaily > -1 ? Configs.PublicationFilters.MinQuantityPostsDaily : 0;
            
            nudQuantityProcessLastPostsPerGroup.Value = Configs.PublicationFilters.QuantityProcessLastPostsPerGroup;

            dtpPublicateTimeFrom.Value = DateTime.Now.Date + Configs.PublicationFilters.PublicateTimeFrom;
            dtpPublicateTimeTo.Value = DateTime.Now.Date + Configs.PublicationFilters.PublicateTimeTo;
        }

        private void SaveParameters()
        {
            if (cbMaxQuantityAdLinks.Checked == false) Configs.PublicationFilters.MaxQuantityAdLinks = -1;
            else Configs.PublicationFilters.MaxQuantityAdLinks = nudMaxQuantityAdLinks.Value;

            if (cbMaxQuantityLikes.Checked == false) Configs.PublicationFilters.MaxQuantityLikes = -1;
            else Configs.PublicationFilters.MaxQuantityLikes = nudMaxQuantityLikes.Value;
            if (cbMinQuantityLikes.Checked == false) Configs.PublicationFilters.MinQuantityLikes = -1;
            else Configs.PublicationFilters.MinQuantityLikes = nudMinQuantityLikes.Value;
            
            if (cbMaxQuantityComments.Checked == false) Configs.PublicationFilters.MaxQuantityComments = -1;
            else Configs.PublicationFilters.MaxQuantityComments = nudMaxQuantityComments.Value;
            if (cbMinQuantityComments.Checked == false) Configs.PublicationFilters.MinQuantityComments = -1;
            else Configs.PublicationFilters.MinQuantityComments = nudMinQuantityComments.Value;

            if (cbMaxQuantityReposts.Checked == false) Configs.PublicationFilters.MaxQuantityReposts = -1;
            else Configs.PublicationFilters.MaxQuantityReposts = nudMaxQuantityReposts.Value;
            if (cbMinQuantityReposts.Checked == false) Configs.PublicationFilters.MinQuantityReposts = -1;
            else Configs.PublicationFilters.MinQuantityReposts = nudMinQuantityReposts.Value;

            if (cbMaxQuantityChars.Checked == false) Configs.PublicationFilters.MaxQuantityChars = -1;
            else Configs.PublicationFilters.MaxQuantityChars = nudMaxQuantityChars.Value;

            Configs.PublicationFilters.KeyWordsBlackList.Clear();
            foreach (string keyword in tbKeyWordsBlackList.Text.Split(','))
                Configs.PublicationFilters.KeyWordsBlackList.Add(keyword.Trim());

            Configs.PublicationFilters.AllowReposts = cbAllowReposts.Checked;
            Configs.PublicationFilters.AllowPinned = cbAllowPinned.Checked;
            Configs.PublicationFilters.AllowMarkedAsAds = cbAllowMarkedAsAds.Checked;
            Configs.PublicationFilters.AllowWithSigner = cbAllowWithSigner.Checked;
            Configs.PublicationFilters.AllowPublicateWithoutImages = cbAllowPublicateWithoutImages.Checked;
            Configs.PublicationFilters.AllowPublicateWithSmiles = cbAllowPublicateWithSmiles.Checked;
            Configs.PublicationFilters.AllowPublicateWithHashtags = cbAllowPublicateWithHashtags.Checked;

            Configs.PublicationFilters.Priority = (PublicationFilters.PriorityEnum)cmbPriority.SelectedIndex;

            if (cbQuantityPostsFromGroup.Checked == false) Configs.PublicationFilters.QuantityPostsFromGroup = -1;
            else Configs.PublicationFilters.QuantityPostsFromGroup = nudQuantityPostsFromGroup.Value;

            if (cbMaxQuantityPostsDaily.Checked == false) Configs.PublicationFilters.MaxQuantityPostsDaily = -1;
            else Configs.PublicationFilters.MaxQuantityPostsDaily = nudMaxQuantityPostsDaily.Value;

            if (cbMinQuantityPostsDaily.Checked == false) Configs.PublicationFilters.MinQuantityPostsDaily = -1;
            else Configs.PublicationFilters.MinQuantityPostsDaily = nudMinQuantityPostsDaily.Value;

            Configs.PublicationFilters.QuantityProcessLastPostsPerGroup = (int)nudQuantityProcessLastPostsPerGroup.Value;

            Configs.PublicationFilters.PublicateTimeFrom = dtpPublicateTimeFrom.Value.TimeOfDay;
            Configs.PublicationFilters.PublicateTimeTo = dtpPublicateTimeTo.Value.TimeOfDay;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveParameters();
            Configs.FiltersSave();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void YesNo_CheckedChanged(object sender, EventArgs e)
        {
            if (sender != null)
            {
                CheckBox checkBox = (CheckBox)sender;
                if (checkBox.Checked)
                    checkBox.Text = "Вкл";
                else
                    checkBox.Text = "Выкл";

                foreach(Control ctrl in checkBox.Parent.Controls)
                {
                    if (ctrl is NumericUpDown)
                    {
                        NumericUpDown nud = (NumericUpDown)ctrl;

                        if (ctrl.Name.Contains(checkBox.Name.Replace("cb", "")))
                        {
                            ctrl.Enabled = checkBox.Checked;
                            if (checkBox.Checked == false)
                                nud.Value = nud.Minimum;
                        }
                    }
                }
            }
        }

        private void nudQuantityPostsFromGroup_ValueChanged(object sender, EventArgs e)
        {
            if (cbQuantityPostsFromGroup.Checked)
                nudMinQuantityPostsDaily.Maximum = Configs.Groups.Count * nudQuantityPostsFromGroup.Value;
            else
                nudMinQuantityPostsDaily.Maximum = 1000;
        }

        private void nudQuantityPostsFromGroup_EnabledChanged(object sender, EventArgs e)
        {
            nudQuantityPostsFromGroup_ValueChanged(sender, e);
        }
    }
}
