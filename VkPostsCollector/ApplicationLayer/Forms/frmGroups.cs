using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using VkPostsCollector.ApplicationLayer;
using VkPostsCollector.ApplicationLayer.UserControls;
using VkPostsCollector.BusinessLayer;
using VkPostsCollector.DataAccessLayer.API;

namespace ApplicationLayer.VkPostsCollector
{
    public partial class frmGroups : Form
    {
        public List<GroupDTO> Groups = new List<GroupDTO>();

        private string AccessToken { get; set; } = string.Empty;

        private GroupItem LastHoveredItem = null;

        public frmGroups(string AccessToken)
        {
            InitializeComponent();

            this.AccessToken = AccessToken;

            for (int i = 0; i < Configs.Groups.Count; i++)
            {
                AddGroup(Configs.Groups[i]);
            }
        }

        private void AddGroup(GroupDTO groupDTO)
        {
            GroupItem GI = new GroupItem(groupDTO.Name, groupDTO.PhotoUrl, groupDTO);
            flpGroups.Controls.Add(GI);
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            GroupDTO groupDTO = VkAPI.GetGroup(tbGroupLink.Text, AccessToken);
            AddGroup(groupDTO);
            tbGroupLink.Clear();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (LastHoveredItem != null) flpGroups.Controls.Remove(LastHoveredItem);
        }

        private void tsmiDeleteAll_Click(object sender, EventArgs e)
        {
            flpGroups.Controls.Clear();
        }

        private void cmsItems_Opening(object sender, CancelEventArgs e)
        {
            tsmiDelete.Visible = HasHovered();

            LastHoveredItem = GetHovered();
        }

        private bool HasHovered()
        {
            return flpGroups.Controls.OfType<GroupItem>().ToList().Exists(x => x.IsHovered);
        }

        private GroupItem GetHovered()
        {
            return flpGroups.Controls.OfType<GroupItem>().ToList().Find(x => x.IsHovered);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < flpGroups.Controls.Count; i++)
            {
                Groups.Add((flpGroups.Controls[i] as GroupItem).GroupDTO);
            }

            DialogResult = DialogResult.OK;
        }
    }
}
