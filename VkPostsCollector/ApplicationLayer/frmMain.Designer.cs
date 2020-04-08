namespace ApplicationLayer.VkPostsCollector
{
    partial class frmMain
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.btnFiltres = new System.Windows.Forms.Button();
            this.btnAddGroups = new System.Windows.Forms.Button();
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPosts = new System.Windows.Forms.DataGridView();
            this.colGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colPublicationLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colLikes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReposts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViews = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPinned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpMain.SuspendLayout();
            this.tlpHeader.SuspendLayout();
            this.tlpBottom.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosts)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpHeader, 0, 0);
            this.tlpMain.Controls.Add(this.tlpBottom, 0, 2);
            this.tlpMain.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tlpMain.Size = new System.Drawing.Size(938, 511);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpHeader
            // 
            this.tlpHeader.ColumnCount = 3;
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeader.Controls.Add(this.btnFiltres, 1, 0);
            this.tlpHeader.Controls.Add(this.btnAddGroups, 0, 0);
            this.tlpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeader.Location = new System.Drawing.Point(0, 0);
            this.tlpHeader.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHeader.Name = "tlpHeader";
            this.tlpHeader.RowCount = 1;
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader.Size = new System.Drawing.Size(938, 35);
            this.tlpHeader.TabIndex = 0;
            // 
            // btnFiltres
            // 
            this.btnFiltres.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFiltres.Enabled = false;
            this.btnFiltres.Location = new System.Drawing.Point(187, 5);
            this.btnFiltres.Name = "btnFiltres";
            this.btnFiltres.Size = new System.Drawing.Size(150, 25);
            this.btnFiltres.TabIndex = 1;
            this.btnFiltres.Text = "Настроить фильтры";
            this.btnFiltres.UseVisualStyleBackColor = true;
            this.btnFiltres.Click += new System.EventHandler(this.btnFiltres_Click);
            // 
            // btnAddGroups
            // 
            this.btnAddGroups.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddGroups.Enabled = false;
            this.btnAddGroups.Location = new System.Drawing.Point(12, 5);
            this.btnAddGroups.Name = "btnAddGroups";
            this.btnAddGroups.Size = new System.Drawing.Size(150, 25);
            this.btnAddGroups.TabIndex = 0;
            this.btnAddGroups.Text = "Добавить группы";
            this.btnAddGroups.UseVisualStyleBackColor = true;
            this.btnAddGroups.Click += new System.EventHandler(this.btnAddGroups_Click);
            // 
            // tlpBottom
            // 
            this.tlpBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlpBottom.ColumnCount = 3;
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBottom.Controls.Add(this.btnStart, 0, 0);
            this.tlpBottom.Controls.Add(this.btnStop, 2, 0);
            this.tlpBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBottom.Location = new System.Drawing.Point(0, 453);
            this.tlpBottom.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.RowCount = 1;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.Size = new System.Drawing.Size(938, 58);
            this.tlpBottom.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnStart.Location = new System.Drawing.Point(296, 11);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(152, 35);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Запустить сбор";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnStop.Location = new System.Drawing.Point(489, 11);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(152, 35);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Остановить сбор";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.39056F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.60944F));
            this.tableLayoutPanel1.Controls.Add(this.dgvPosts, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(932, 412);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dgvPosts
            // 
            this.dgvPosts.AllowUserToOrderColumns = true;
            this.dgvPosts.AllowUserToResizeRows = false;
            this.dgvPosts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPosts.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvPosts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvPosts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvPosts.ColumnHeadersHeight = 50;
            this.dgvPosts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPosts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGroupName,
            this.colGroupLink,
            this.colPublicationLink,
            this.colLikes,
            this.colReposts,
            this.colComments,
            this.colViews,
            this.colPinned});
            this.dgvPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPosts.GridColor = System.Drawing.Color.MediumTurquoise;
            this.dgvPosts.Location = new System.Drawing.Point(3, 3);
            this.dgvPosts.Name = "dgvPosts";
            this.dgvPosts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPosts.Size = new System.Drawing.Size(677, 406);
            this.dgvPosts.TabIndex = 0;
            // 
            // colGroupName
            // 
            this.colGroupName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGroupName.HeaderText = "Группа";
            this.colGroupName.MinimumWidth = 100;
            this.colGroupName.Name = "colGroupName";
            // 
            // colGroupLink
            // 
            this.colGroupLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGroupLink.HeaderText = "Ссылка на группу";
            this.colGroupLink.MinimumWidth = 100;
            this.colGroupLink.Name = "colGroupLink";
            this.colGroupLink.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colPublicationLink
            // 
            this.colPublicationLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPublicationLink.HeaderText = "Ссылка на публикацию";
            this.colPublicationLink.MinimumWidth = 100;
            this.colPublicationLink.Name = "colPublicationLink";
            this.colPublicationLink.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colLikes
            // 
            this.colLikes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.colLikes.DefaultCellStyle = dataGridViewCellStyle5;
            this.colLikes.HeaderText = "Кол-во лайков";
            this.colLikes.MinimumWidth = 100;
            this.colLikes.Name = "colLikes";
            // 
            // colReposts
            // 
            this.colReposts.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.colReposts.DefaultCellStyle = dataGridViewCellStyle6;
            this.colReposts.HeaderText = "Кол-во репостов";
            this.colReposts.MinimumWidth = 100;
            this.colReposts.Name = "colReposts";
            // 
            // colComments
            // 
            this.colComments.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.colComments.DefaultCellStyle = dataGridViewCellStyle7;
            this.colComments.HeaderText = "Кол-во комментариев";
            this.colComments.MinimumWidth = 100;
            this.colComments.Name = "colComments";
            // 
            // colViews
            // 
            this.colViews.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.colViews.DefaultCellStyle = dataGridViewCellStyle8;
            this.colViews.HeaderText = "Кол-во просмотров";
            this.colViews.MinimumWidth = 100;
            this.colViews.Name = "colViews";
            // 
            // colPinned
            // 
            this.colPinned.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPinned.HeaderText = "Запись закреплена";
            this.colPinned.MinimumWidth = 70;
            this.colPinned.Name = "colPinned";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(938, 511);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сборщик публикаций из групп ВК";
            this.tlpMain.ResumeLayout(false);
            this.tlpHeader.ResumeLayout(false);
            this.tlpBottom.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpHeader;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnFiltres;
        private System.Windows.Forms.Button btnAddGroups;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvPosts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupName;
        private System.Windows.Forms.DataGridViewLinkColumn colGroupLink;
        private System.Windows.Forms.DataGridViewLinkColumn colPublicationLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLikes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReposts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colViews;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPinned;
    }
}

