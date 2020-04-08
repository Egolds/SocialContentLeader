using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace ApplicationLayer.VkPostsCollector
{
    public partial class frmMain : Form
    {
        private string TestGroup = "https://vk.com/godnoten";
        private const string ApiPage = "https://api.vk.com/method/";
        private const string ServiceKey = "";

        public frmMain()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;
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
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        #endregion
    }
}
