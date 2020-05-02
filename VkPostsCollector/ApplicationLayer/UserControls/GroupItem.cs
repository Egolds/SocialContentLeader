using System.Windows.Forms;
using VkPostsCollector.BusinessLayer;

namespace VkPostsCollector.ApplicationLayer.UserControls
{
    public partial class GroupItem : UserControl
    {
        public string Title { get; set; }
        public string ImageLink { get; set; }
        public GroupDTO GroupDTO { get; set; }

        public bool IsHovered { get; private set; }
        
        public GroupItem(string title, string imageLink, GroupDTO groupDTO)
        {
            InitializeComponent();

            Title = title;
            ImageLink = imageLink;
            GroupDTO = groupDTO;

            Init();
            SignEvents(this);
        }

        private void Init()
        {
            pAvatar.ImageLocation = ImageLink;
            lblName.Text = Title;
        }

        private void SignEvents(Control ctrl)
        {
            ctrl.MouseEnter += Ctrl_MouseEnter;
            ctrl.MouseLeave += Ctrl_MouseLeave;

            if(ctrl.Controls != null && ctrl.Controls.Count > 0)
            {
                for (int i = 0; i < ctrl.Controls.Count; i++)
                {
                    SignEvents(ctrl.Controls[i]);
                }
            }
        }

        private void Ctrl_MouseLeave(object sender, System.EventArgs e)
        {
            IsHovered = false;
        }

        private void Ctrl_MouseEnter(object sender, System.EventArgs e)
        {
            IsHovered = true;
        }
    }
}
