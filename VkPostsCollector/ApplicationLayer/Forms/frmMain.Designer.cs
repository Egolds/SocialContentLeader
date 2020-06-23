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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.btnFiltres = new System.Windows.Forms.Button();
            this.btnAddGroups = new System.Windows.Forms.Button();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.btnTesting = new System.Windows.Forms.Button();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tlpDataGrid = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPosts = new System.Windows.Forms.DataGridView();
            this.lblCount = new System.Windows.Forms.Label();
            this.cmsPostsColumns = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsPost = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowPostText = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowImages = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPublicate = new System.Windows.Forms.ToolStripMenuItem();
            this.lblQuantityCollectLastPosts = new System.Windows.Forms.Label();
            this.cbAutobotMode = new System.Windows.Forms.CheckBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.colGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colPublicationLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colLikes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReposts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViews = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLikesCTR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPinned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarkedAsAds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExistsAttachments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExistsSigner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSignerLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colExistsLinks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLinks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsPublicated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlpMain.SuspendLayout();
            this.tlpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.tlpBottom.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tlpDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosts)).BeginInit();
            this.cmsPost.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(248, 6);
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
            this.tlpMain.Size = new System.Drawing.Size(998, 702);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpHeader
            // 
            this.tlpHeader.ColumnCount = 5;
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tlpHeader.Controls.Add(this.btnFiltres, 1, 0);
            this.tlpHeader.Controls.Add(this.btnAddGroups, 0, 0);
            this.tlpHeader.Controls.Add(this.nudQuantity, 3, 0);
            this.tlpHeader.Controls.Add(this.lblQuantityCollectLastPosts, 2, 0);
            this.tlpHeader.Controls.Add(this.cbAutobotMode, 4, 0);
            this.tlpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeader.Location = new System.Drawing.Point(0, 0);
            this.tlpHeader.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHeader.Name = "tlpHeader";
            this.tlpHeader.RowCount = 1;
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader.Size = new System.Drawing.Size(998, 35);
            this.tlpHeader.TabIndex = 0;
            // 
            // btnFiltres
            // 
            this.btnFiltres.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFiltres.Location = new System.Drawing.Point(193, 5);
            this.btnFiltres.Name = "btnFiltres";
            this.btnFiltres.Size = new System.Drawing.Size(184, 25);
            this.btnFiltres.TabIndex = 1;
            this.btnFiltres.Text = "Настроить фильтры бота";
            this.btnFiltres.UseVisualStyleBackColor = true;
            this.btnFiltres.Click += new System.EventHandler(this.btnFiltres_Click);
            // 
            // btnAddGroups
            // 
            this.btnAddGroups.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddGroups.Location = new System.Drawing.Point(3, 5);
            this.btnAddGroups.Name = "btnAddGroups";
            this.btnAddGroups.Size = new System.Drawing.Size(184, 25);
            this.btnAddGroups.TabIndex = 0;
            this.btnAddGroups.Text = "Добавить группы";
            this.btnAddGroups.UseVisualStyleBackColor = true;
            this.btnAddGroups.Click += new System.EventHandler(this.btnAddGroups_Click);
            // 
            // nudQuantity
            // 
            this.nudQuantity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudQuantity.Location = new System.Drawing.Point(576, 6);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.nudQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 23);
            this.nudQuantity.TabIndex = 2;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.tlpBottom.Location = new System.Drawing.Point(0, 644);
            this.tlpBottom.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.RowCount = 1;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.Size = new System.Drawing.Size(998, 58);
            this.tlpBottom.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnStart.Location = new System.Drawing.Point(326, 11);
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
            this.btnStop.Location = new System.Drawing.Point(519, 11);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.78541F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.21459F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tlpDataGrid, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(992, 603);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tbLog);
            this.panel1.Controls.Add(this.checkBox11);
            this.panel1.Controls.Add(this.checkBox10);
            this.panel1.Controls.Add(this.checkBox9);
            this.panel1.Controls.Add(this.checkBox8);
            this.panel1.Controls.Add(this.checkBox7);
            this.panel1.Controls.Add(this.btnTesting);
            this.panel1.Controls.Add(this.checkBox6);
            this.panel1.Controls.Add(this.checkBox5);
            this.panel1.Controls.Add(this.checkBox4);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Location = new System.Drawing.Point(744, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 564);
            this.panel1.TabIndex = 1;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(13, 373);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(215, 34);
            this.checkBox11.TabIndex = 11;
            this.checkBox11.Text = "Вывод статистики (откуда меньше\r\nвсего публикаций)";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(13, 333);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(211, 34);
            this.checkBox10.TabIndex = 10;
            this.checkBox10.Text = "Установить минимальное кол-во\r\nлайков (Вывод мин/макс лайков)";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(13, 293);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(163, 34);
            this.checkBox9.TabIndex = 9;
            this.checkBox9.Text = "Учитывать соотношение\r\nлайков/просмотров";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(13, 268);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(157, 19);
            this.checkBox8.TabIndex = 8;
            this.checkBox8.Text = "Фильтр ссылок (домен)";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(13, 243);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(193, 19);
            this.checkBox7.TabIndex = 7;
            this.checkBox7.Text = "Макс. кол-во ссылок в записи";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // btnTesting
            // 
            this.btnTesting.Location = new System.Drawing.Point(164, 538);
            this.btnTesting.Name = "btnTesting";
            this.btnTesting.Size = new System.Drawing.Size(75, 23);
            this.btnTesting.TabIndex = 6;
            this.btnTesting.Text = "test";
            this.btnTesting.UseVisualStyleBackColor = true;
            this.btnTesting.Click += new System.EventHandler(this.btnTesting_Click);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(13, 188);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(180, 49);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Text = "Установить ограничение \r\nмакс/мин кол-во смоволов\r\nтекста в посте";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(13, 163);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(147, 19);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "Удалять хэштеги #xxx_";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(13, 123);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(166, 34);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "Не публиковать посты\r\nбез вложений (Картинки)";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(13, 83);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(161, 34);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Отправлять на проверку\r\nпосты со ссылками";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(13, 43);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(161, 34);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Отправлять на проверку\r\nпосты со смайликами";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 18);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(171, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Удалять смайлики &&#XXX;";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tlpDataGrid
            // 
            this.tlpDataGrid.ColumnCount = 1;
            this.tlpDataGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataGrid.Controls.Add(this.dgvPosts, 0, 0);
            this.tlpDataGrid.Controls.Add(this.lblCount, 0, 1);
            this.tlpDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDataGrid.Location = new System.Drawing.Point(3, 3);
            this.tlpDataGrid.Name = "tlpDataGrid";
            this.tlpDataGrid.RowCount = 2;
            this.tlpDataGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpDataGrid.Size = new System.Drawing.Size(735, 597);
            this.tlpDataGrid.TabIndex = 2;
            // 
            // dgvPosts
            // 
            this.dgvPosts.AllowUserToAddRows = false;
            this.dgvPosts.AllowUserToDeleteRows = false;
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
            this.colCreated,
            this.colType,
            this.colGroupLink,
            this.colPublicationLink,
            this.colLikes,
            this.colReposts,
            this.colComments,
            this.colViews,
            this.colLikesCTR,
            this.colPinned,
            this.colMarkedAsAds,
            this.colExistsAttachments,
            this.colExistsSigner,
            this.colSignerLink,
            this.colExistsLinks,
            this.colLinks,
            this.colIsPublicated});
            this.dgvPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPosts.GridColor = System.Drawing.Color.MediumTurquoise;
            this.dgvPosts.Location = new System.Drawing.Point(3, 3);
            this.dgvPosts.MultiSelect = false;
            this.dgvPosts.Name = "dgvPosts";
            this.dgvPosts.ReadOnly = true;
            this.dgvPosts.RowHeadersVisible = false;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Gray;
            this.dgvPosts.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPosts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPosts.Size = new System.Drawing.Size(729, 561);
            this.dgvPosts.TabIndex = 0;
            this.dgvPosts.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPosts_CellMouseDown);
            this.dgvPosts.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPosts_CellMouseUp);
            this.dgvPosts.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPosts_ColumnHeaderMouseClick);
            this.dgvPosts.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvPosts_RowsAdded);
            this.dgvPosts.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvPosts_RowsRemoved);
            this.dgvPosts.SelectionChanged += new System.EventHandler(this.dgvPosts_SelectionChanged);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCount.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblCount.Location = new System.Drawing.Point(3, 574);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(99, 15);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "Всего записей: 0";
            // 
            // cmsPostsColumns
            // 
            this.cmsPostsColumns.Name = "cmsPosts";
            this.cmsPostsColumns.ShowCheckMargin = true;
            this.cmsPostsColumns.ShowImageMargin = false;
            this.cmsPostsColumns.Size = new System.Drawing.Size(61, 4);
            this.cmsPostsColumns.Opening += new System.ComponentModel.CancelEventHandler(this.cmsPostsColumns_Opening);
            // 
            // cmsPost
            // 
            this.cmsPost.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowPostText,
            this.tsmiShowImages,
            toolStripSeparator1,
            this.tsmiPublicate});
            this.cmsPost.Name = "cmsPost";
            this.cmsPost.Size = new System.Drawing.Size(252, 76);
            // 
            // tsmiShowPostText
            // 
            this.tsmiShowPostText.Name = "tsmiShowPostText";
            this.tsmiShowPostText.Size = new System.Drawing.Size(251, 22);
            this.tsmiShowPostText.Text = "Просмотр содержимого записи";
            this.tsmiShowPostText.Click += new System.EventHandler(this.tsmiShowPostText_Click);
            // 
            // tsmiShowImages
            // 
            this.tsmiShowImages.Name = "tsmiShowImages";
            this.tsmiShowImages.Size = new System.Drawing.Size(251, 22);
            this.tsmiShowImages.Text = "Просмотр изображения";
            this.tsmiShowImages.Click += new System.EventHandler(this.tsmiShowImages_Click);
            // 
            // tsmiPublicate
            // 
            this.tsmiPublicate.Name = "tsmiPublicate";
            this.tsmiPublicate.Size = new System.Drawing.Size(251, 22);
            this.tsmiPublicate.Text = "Опубликовать";
            this.tsmiPublicate.Click += new System.EventHandler(this.tsmiPublicate_ClickAsync);
            // 
            // lblQuantityCollectLastPosts
            // 
            this.lblQuantityCollectLastPosts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuantityCollectLastPosts.AutoSize = true;
            this.lblQuantityCollectLastPosts.Location = new System.Drawing.Point(383, 10);
            this.lblQuantityCollectLastPosts.Name = "lblQuantityCollectLastPosts";
            this.lblQuantityCollectLastPosts.Size = new System.Drawing.Size(180, 15);
            this.lblQuantityCollectLastPosts.TabIndex = 3;
            this.lblQuantityCollectLastPosts.Text = "Кол-во постов с одной группы:";
            // 
            // cbAutobotMode
            // 
            this.cbAutobotMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbAutobotMode.AutoSize = true;
            this.cbAutobotMode.Location = new System.Drawing.Point(702, 8);
            this.cbAutobotMode.Name = "cbAutobotMode";
            this.cbAutobotMode.Size = new System.Drawing.Size(188, 19);
            this.cbAutobotMode.TabIndex = 4;
            this.cbAutobotMode.Text = "Автоматизированный режим";
            this.cbAutobotMode.UseVisualStyleBackColor = true;
            this.cbAutobotMode.CheckedChanged += new System.EventHandler(this.cbAutobotMode_CheckedChanged);
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(0, 0);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(245, 564);
            this.tbLog.TabIndex = 12;
            // 
            // colGroupName
            // 
            this.colGroupName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colGroupName.HeaderText = "Группа";
            this.colGroupName.MinimumWidth = 100;
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.ReadOnly = true;
            // 
            // colCreated
            // 
            this.colCreated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Format = "g";
            dataGridViewCellStyle1.NullValue = null;
            this.colCreated.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCreated.HeaderText = "Дата публикации";
            this.colCreated.MinimumWidth = 100;
            this.colCreated.Name = "colCreated";
            this.colCreated.ReadOnly = true;
            this.colCreated.Width = 116;
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colType.HeaderText = "Тип записи";
            this.colType.MinimumWidth = 100;
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            // 
            // colGroupLink
            // 
            this.colGroupLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colGroupLink.HeaderText = "Ссылка на группу";
            this.colGroupLink.LinkColor = System.Drawing.Color.Blue;
            this.colGroupLink.MinimumWidth = 100;
            this.colGroupLink.Name = "colGroupLink";
            this.colGroupLink.ReadOnly = true;
            this.colGroupLink.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colPublicationLink
            // 
            this.colPublicationLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPublicationLink.HeaderText = "Ссылка на публикацию";
            this.colPublicationLink.LinkColor = System.Drawing.Color.Blue;
            this.colPublicationLink.MinimumWidth = 100;
            this.colPublicationLink.Name = "colPublicationLink";
            this.colPublicationLink.ReadOnly = true;
            this.colPublicationLink.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colPublicationLink.Width = 149;
            // 
            // colLikes
            // 
            this.colLikes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.colLikes.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLikes.HeaderText = "Кол-во лайков";
            this.colLikes.MinimumWidth = 100;
            this.colLikes.Name = "colLikes";
            this.colLikes.ReadOnly = true;
            this.colLikes.Width = 104;
            // 
            // colReposts
            // 
            this.colReposts.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.colReposts.DefaultCellStyle = dataGridViewCellStyle3;
            this.colReposts.HeaderText = "Кол-во репостов";
            this.colReposts.MinimumWidth = 100;
            this.colReposts.Name = "colReposts";
            this.colReposts.ReadOnly = true;
            this.colReposts.Width = 114;
            // 
            // colComments
            // 
            this.colComments.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.colComments.DefaultCellStyle = dataGridViewCellStyle4;
            this.colComments.HeaderText = "Кол-во комментариев";
            this.colComments.MinimumWidth = 100;
            this.colComments.Name = "colComments";
            this.colComments.ReadOnly = true;
            this.colComments.Width = 141;
            // 
            // colViews
            // 
            this.colViews.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.colViews.DefaultCellStyle = dataGridViewCellStyle5;
            this.colViews.HeaderText = "Кол-во просмотров";
            this.colViews.MinimumWidth = 100;
            this.colViews.Name = "colViews";
            this.colViews.ReadOnly = true;
            this.colViews.Width = 130;
            // 
            // colLikesCTR
            // 
            this.colLikesCTR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.colLikesCTR.DefaultCellStyle = dataGridViewCellStyle6;
            this.colLikesCTR.HeaderText = "CTR для лайков";
            this.colLikesCTR.MinimumWidth = 100;
            this.colLikesCTR.Name = "colLikesCTR";
            this.colLikesCTR.ReadOnly = true;
            // 
            // colPinned
            // 
            this.colPinned.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPinned.HeaderText = "Запись закреплена";
            this.colPinned.MinimumWidth = 70;
            this.colPinned.Name = "colPinned";
            this.colPinned.ReadOnly = true;
            this.colPinned.Width = 125;
            // 
            // colMarkedAsAds
            // 
            this.colMarkedAsAds.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMarkedAsAds.HeaderText = "Рекламная запись";
            this.colMarkedAsAds.MinimumWidth = 70;
            this.colMarkedAsAds.Name = "colMarkedAsAds";
            this.colMarkedAsAds.ReadOnly = true;
            this.colMarkedAsAds.Width = 121;
            // 
            // colExistsAttachments
            // 
            this.colExistsAttachments.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colExistsAttachments.HeaderText = "Есть вложения";
            this.colExistsAttachments.MinimumWidth = 70;
            this.colExistsAttachments.Name = "colExistsAttachments";
            this.colExistsAttachments.ReadOnly = true;
            this.colExistsAttachments.Width = 104;
            // 
            // colExistsSigner
            // 
            this.colExistsSigner.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colExistsSigner.HeaderText = "Запись содержит подпись";
            this.colExistsSigner.MinimumWidth = 70;
            this.colExistsSigner.Name = "colExistsSigner";
            this.colExistsSigner.ReadOnly = true;
            this.colExistsSigner.Width = 119;
            // 
            // colSignerLink
            // 
            this.colSignerLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSignerLink.HeaderText = "Ссылка на профиль автора записи";
            this.colSignerLink.LinkColor = System.Drawing.Color.Blue;
            this.colSignerLink.MinimumWidth = 100;
            this.colSignerLink.Name = "colSignerLink";
            this.colSignerLink.ReadOnly = true;
            this.colSignerLink.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSignerLink.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSignerLink.Width = 114;
            // 
            // colExistsLinks
            // 
            this.colExistsLinks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colExistsLinks.HeaderText = "В записи есть ссылки";
            this.colExistsLinks.MinimumWidth = 80;
            this.colExistsLinks.Name = "colExistsLinks";
            this.colExistsLinks.ReadOnly = true;
            this.colExistsLinks.Width = 91;
            // 
            // colLinks
            // 
            this.colLinks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colLinks.HeaderText = "Ссылки в записи";
            this.colLinks.MinimumWidth = 80;
            this.colLinks.Name = "colLinks";
            this.colLinks.ReadOnly = true;
            this.colLinks.Width = 80;
            // 
            // colIsPublicated
            // 
            this.colIsPublicated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colIsPublicated.HeaderText = "Опубликован";
            this.colIsPublicated.MinimumWidth = 80;
            this.colIsPublicated.Name = "colIsPublicated";
            this.colIsPublicated.ReadOnly = true;
            this.colIsPublicated.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(998, 702);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сборщик публикаций из групп ВК";
            this.tlpMain.ResumeLayout(false);
            this.tlpHeader.ResumeLayout(false);
            this.tlpHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.tlpBottom.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tlpDataGrid.ResumeLayout(false);
            this.tlpDataGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosts)).EndInit();
            this.cmsPost.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip cmsPostsColumns;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TableLayoutPanel tlpDataGrid;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.ContextMenuStrip cmsPost;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPostText;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowImages;
        private System.Windows.Forms.Button btnTesting;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.ToolStripMenuItem tsmiPublicate;
        private System.Windows.Forms.Label lblQuantityCollectLastPosts;
        private System.Windows.Forms.CheckBox cbAutobotMode;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewLinkColumn colGroupLink;
        private System.Windows.Forms.DataGridViewLinkColumn colPublicationLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLikes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReposts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colViews;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLikesCTR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPinned;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarkedAsAds;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExistsAttachments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExistsSigner;
        private System.Windows.Forms.DataGridViewLinkColumn colSignerLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExistsLinks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLinks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsPublicated;
    }
}

