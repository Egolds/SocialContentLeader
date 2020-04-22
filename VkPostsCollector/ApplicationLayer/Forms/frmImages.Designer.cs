namespace VkPostsCollector.ApplicationLayer.Forms
{
    partial class frmImages
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpImages = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpImages
            // 
            this.flpImages.AutoScroll = true;
            this.flpImages.BackColor = System.Drawing.Color.White;
            this.flpImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpImages.Location = new System.Drawing.Point(0, 0);
            this.flpImages.Name = "flpImages";
            this.flpImages.Size = new System.Drawing.Size(800, 450);
            this.flpImages.TabIndex = 0;
            // 
            // frmImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flpImages);
            this.Name = "frmImages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Просмотр изображений";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpImages;
    }
}