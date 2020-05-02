namespace VkPostsCollector.ApplicationLayer.UserControls
{
    partial class GroupItem
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pMainContainer = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.pAvatar = new System.Windows.Forms.PictureBox();
            this.pMainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // pMainContainer
            // 
            this.pMainContainer.BackColor = System.Drawing.Color.White;
            this.pMainContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pMainContainer.Controls.Add(this.lblName);
            this.pMainContainer.Controls.Add(this.pAvatar);
            this.pMainContainer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMainContainer.Location = new System.Drawing.Point(0, 0);
            this.pMainContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pMainContainer.Name = "pMainContainer";
            this.pMainContainer.Size = new System.Drawing.Size(310, 40);
            this.pMainContainer.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(40, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(23, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "---";
            // 
            // pAvatar
            // 
            this.pAvatar.Location = new System.Drawing.Point(3, 3);
            this.pAvatar.Name = "pAvatar";
            this.pAvatar.Size = new System.Drawing.Size(32, 32);
            this.pAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pAvatar.TabIndex = 0;
            this.pAvatar.TabStop = false;
            // 
            // GroupItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pMainContainer);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.Name = "GroupItem";
            this.Size = new System.Drawing.Size(310, 40);
            this.pMainContainer.ResumeLayout(false);
            this.pMainContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMainContainer;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pAvatar;
    }
}
