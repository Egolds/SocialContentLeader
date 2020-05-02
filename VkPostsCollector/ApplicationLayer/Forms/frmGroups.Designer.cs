namespace ApplicationLayer.VkPostsCollector
{
    partial class frmGroups
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
            this.components = new System.ComponentModel.Container();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.flpGroups = new System.Windows.Forms.FlowLayoutPanel();
            this.cmsItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.pActions = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbGroupLink = new System.Windows.Forms.TextBox();
            this.lblGroupLink = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.cmsItems.SuspendLayout();
            this.pActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 235F));
            this.tlpMain.Controls.Add(this.flpGroups, 0, 0);
            this.tlpMain.Controls.Add(this.pActions, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.65517F));
            this.tlpMain.Size = new System.Drawing.Size(562, 379);
            this.tlpMain.TabIndex = 1;
            // 
            // flpGroups
            // 
            this.flpGroups.AutoScroll = true;
            this.flpGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpGroups.ContextMenuStrip = this.cmsItems;
            this.flpGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpGroups.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpGroups.Location = new System.Drawing.Point(0, 0);
            this.flpGroups.Margin = new System.Windows.Forms.Padding(0);
            this.flpGroups.Name = "flpGroups";
            this.flpGroups.Size = new System.Drawing.Size(327, 379);
            this.flpGroups.TabIndex = 0;
            this.flpGroups.WrapContents = false;
            // 
            // cmsItems
            // 
            this.cmsItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDelete,
            this.tsmiDeleteAll});
            this.cmsItems.Name = "cmsItems";
            this.cmsItems.Size = new System.Drawing.Size(140, 48);
            this.cmsItems.Opening += new System.ComponentModel.CancelEventHandler(this.cmsItems_Opening);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(139, 22);
            this.tsmiDelete.Text = "Удалить";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiDeleteAll
            // 
            this.tsmiDeleteAll.Name = "tsmiDeleteAll";
            this.tsmiDeleteAll.Size = new System.Drawing.Size(139, 22);
            this.tsmiDeleteAll.Text = "Удалить все";
            this.tsmiDeleteAll.Click += new System.EventHandler(this.tsmiDeleteAll_Click);
            // 
            // pActions
            // 
            this.pActions.Controls.Add(this.btnSave);
            this.pActions.Controls.Add(this.tbGroupLink);
            this.pActions.Controls.Add(this.lblGroupLink);
            this.pActions.Controls.Add(this.btnAdd);
            this.pActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pActions.Location = new System.Drawing.Point(327, 0);
            this.pActions.Margin = new System.Windows.Forms.Padding(0);
            this.pActions.Name = "pActions";
            this.pActions.Size = new System.Drawing.Size(235, 379);
            this.pActions.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(105, 332);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbGroupLink
            // 
            this.tbGroupLink.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tbGroupLink.Location = new System.Drawing.Point(16, 29);
            this.tbGroupLink.Name = "tbGroupLink";
            this.tbGroupLink.Size = new System.Drawing.Size(207, 25);
            this.tbGroupLink.TabIndex = 2;
            // 
            // lblGroupLink
            // 
            this.lblGroupLink.AutoSize = true;
            this.lblGroupLink.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGroupLink.Location = new System.Drawing.Point(13, 9);
            this.lblGroupLink.Name = "lblGroupLink";
            this.lblGroupLink.Size = new System.Drawing.Size(115, 17);
            this.lblGroupLink.TabIndex = 1;
            this.lblGroupLink.Text = "Ссылка на группу:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(128, 60);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 26);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(562, 379);
            this.Controls.Add(this.tlpMain);
            this.Name = "frmGroups";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Группы";
            this.tlpMain.ResumeLayout(false);
            this.cmsItems.ResumeLayout(false);
            this.pActions.ResumeLayout(false);
            this.pActions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.FlowLayoutPanel flpGroups;
        private System.Windows.Forms.Panel pActions;
        private System.Windows.Forms.TextBox tbGroupLink;
        private System.Windows.Forms.Label lblGroupLink;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteAll;
        private System.Windows.Forms.ContextMenuStrip cmsItems;
    }
}