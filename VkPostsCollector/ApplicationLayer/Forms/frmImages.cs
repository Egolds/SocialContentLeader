using System.Drawing;
using System.Windows.Forms;

namespace VkPostsCollector.ApplicationLayer.Forms
{
    public partial class frmImages : Form
    {
        public frmImages()
        {
            InitializeComponent();
        }
        
        private void addPictureBox(PictureBox pb)
        {
            pb.Size = new Size(250, 250);
            pb.SizeMode = PictureBoxSizeMode.Zoom;

            flpImages.Controls.Add(pb);
        }

        public void AddImage(Image IMG)
        {
            PictureBox pb = new PictureBox();
            pb.Image = IMG;
            addPictureBox(pb);
        }

        public void AddImage(string URL)
        {
            PictureBox pb = new PictureBox();
            pb.ImageLocation = URL;
            addPictureBox(pb);
        }

        public void AddImageRange(string[] URLs)
        {
            for (int i = 0; i < URLs.Length; i++)
            {
                AddImage(URLs[i]);
            }
        }
    }
}
