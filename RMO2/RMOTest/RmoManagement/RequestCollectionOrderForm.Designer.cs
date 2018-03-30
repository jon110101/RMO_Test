namespace RMO.RmoManagement
{
    partial class RequestCollectionOrderForm
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ITM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Collection_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReqType_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesType_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CsvPo_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Req_Csv_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usr__Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create__Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
            this.BtnUpd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lalel1 = new System.Windows.Forms.Label();
            this.lalel2 = new System.Windows.Forms.Label();
            this.textBoxContainButton1 = new RMO.TextBoxContainButton();
            this.textBoxContainButton2 = new RMO.TextBoxContainButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxContainButton7 = new RMO.TextBoxContainButton();
            this.textBoxContainButton8 = new RMO.TextBoxContainButton();
            this.textBoxContainButton6 = new RMO.TextBoxContainButton();
            this.textBoxContainButton5 = new RMO.TextBoxContainButton();
            this.textBoxContainButton3 = new RMO.TextBoxContainButton();
            this.textBoxContainButton4 = new RMO.TextBoxContainButton();
            this.cbxReqType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSs = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnQuery = new System.Windows.Forms.Button();
            this.btnCh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ITM,
            this.Company_Id,
            this.Collection_Id,
            this.ReqType_Id,
            this.SalesType_Id,
            this.CsvPo_Id,
            this.Req_Csv_Id,
            this.Status_Id,
            this.Usr__Id,
            this.Create__Date});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(864, 406);
            this.dataGridView1.TabIndex = 1;
            // 
            // ITM
            // 
            this.ITM.DataPropertyName = "ITM";
            this.ITM.HeaderText = "序号";
            this.ITM.Name = "ITM";
            this.ITM.Width = 80;
            // 
            // Company_Id
            // 
            this.Company_Id.DataPropertyName = "Company_Id";
            this.Company_Id.HeaderText = "公司编码";
            this.Company_Id.Name = "Company_Id";
            this.Company_Id.Width = 150;
            // 
            // Collection_Id
            // 
            this.Collection_Id.DataPropertyName = "Collection_Id";
            this.Collection_Id.HeaderText = "收集单号";
            this.Collection_Id.Name = "Collection_Id";
            // 
            // ReqType_Id
            // 
            this.ReqType_Id.DataPropertyName = "ReqType_Id";
            this.ReqType_Id.HeaderText = "需求类型";
            this.ReqType_Id.Name = "ReqType_Id";
            this.ReqType_Id.Width = 150;
            // 
            // SalesType_Id
            // 
            this.SalesType_Id.DataPropertyName = "SalesType_Id";
            this.SalesType_Id.HeaderText = "销售类型";
            this.SalesType_Id.Name = "SalesType_Id";
            // 
            // CsvPo_Id
            // 
            this.CsvPo_Id.DataPropertyName = "CsvPo_Id";
            this.CsvPo_Id.HeaderText = "客户PO";
            this.CsvPo_Id.Name = "CsvPo_Id";
            this.CsvPo_Id.Width = 150;
            // 
            // Req_Csv_Id
            // 
            this.Req_Csv_Id.DataPropertyName = "Req_Csv_Id";
            this.Req_Csv_Id.HeaderText = "需求客户";
            this.Req_Csv_Id.Name = "Req_Csv_Id";
            // 
            // Status_Id
            // 
            this.Status_Id.DataPropertyName = "Status_Id";
            this.Status_Id.HeaderText = "单据状态";
            this.Status_Id.Name = "Status_Id";
            // 
            // Usr__Id
            // 
            this.Usr__Id.DataPropertyName = "Usr__Id";
            this.Usr__Id.HeaderText = "录入用户";
            this.Usr__Id.Name = "Usr__Id";
            // 
            // Create__Date
            // 
            this.Create__Date.DataPropertyName = "Create__Date";
            this.Create__Date.HeaderText = "录入时间";
            this.Create__Date.Name = "Create__Date";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 154);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(864, 406);
            this.panel3.TabIndex = 7;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(369, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(60, 25);
            this.BtnClose.TabIndex = 4;
            this.BtnClose.Text = "关闭";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnDel
            // 
            this.BtnDel.Location = new System.Drawing.Point(186, 3);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(55, 25);
            this.BtnDel.TabIndex = 3;
            this.BtnDel.Text = "删除";
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // BtnUpd
            // 
            this.BtnUpd.Location = new System.Drawing.Point(125, 3);
            this.BtnUpd.Name = "BtnUpd";
            this.BtnUpd.Size = new System.Drawing.Size(55, 25);
            this.BtnUpd.TabIndex = 2;
            this.BtnUpd.Text = "修改";
            this.BtnUpd.UseVisualStyleBackColor = true;
            this.BtnUpd.Click += new System.EventHandler(this.BtnUpd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 154);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(864, 111);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Controls.Add(this.lalel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lalel2, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton7, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton8, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton6, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton5, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton4, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxReqType, 6, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(864, 111);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lalel1
            // 
            this.lalel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lalel1.AutoSize = true;
            this.lalel1.Location = new System.Drawing.Point(3, 7);
            this.lalel1.Margin = new System.Windows.Forms.Padding(3);
            this.lalel1.Name = "lalel1";
            this.lalel1.Size = new System.Drawing.Size(53, 12);
            this.lalel1.TabIndex = 0;
            this.lalel1.Text = "收集单号";
            // 
            // lalel2
            // 
            this.lalel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lalel2.AutoSize = true;
            this.lalel2.Location = new System.Drawing.Point(433, 7);
            this.lalel2.Margin = new System.Windows.Forms.Padding(3);
            this.lalel2.Name = "lalel2";
            this.lalel2.Size = new System.Drawing.Size(53, 12);
            this.lalel2.TabIndex = 1;
            this.lalel2.Text = "需求类型";
            // 
            // textBoxContainButton1
            // 
            this.textBoxContainButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton1.Desc = null;
            this.textBoxContainButton1.Format = null;
            this.textBoxContainButton1.ID = null;
            this.textBoxContainButton1.Location = new System.Drawing.Point(59, 0);
            this.textBoxContainButton1.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton1.Name = "textBoxContainButton1";
            this.textBoxContainButton1.ReadOnly = false;
            this.textBoxContainButton1.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton1.TabIndex = 3;
            // 
            // textBoxContainButton2
            // 
            this.textBoxContainButton2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton2.Desc = null;
            this.textBoxContainButton2.Format = null;
            this.textBoxContainButton2.ID = null;
            this.textBoxContainButton2.Location = new System.Drawing.Point(244, 0);
            this.textBoxContainButton2.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton2.Name = "textBoxContainButton2";
            this.textBoxContainButton2.ReadOnly = false;
            this.textBoxContainButton2.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "----";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "需求客户";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "----";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(427, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "仓库/库位";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(645, 34);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "----";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 61);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "存货编码";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(212, 61);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 23;
            this.label8.Text = "----";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(433, 61);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "单据状态";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(492, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(147, 20);
            this.comboBox1.TabIndex = 26;
            // 
            // textBoxContainButton7
            // 
            this.textBoxContainButton7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton7.Desc = null;
            this.textBoxContainButton7.Format = null;
            this.textBoxContainButton7.ID = null;
            this.textBoxContainButton7.Location = new System.Drawing.Point(59, 54);
            this.textBoxContainButton7.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton7.Name = "textBoxContainButton7";
            this.textBoxContainButton7.ReadOnly = false;
            this.textBoxContainButton7.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton7.TabIndex = 18;
            // 
            // textBoxContainButton8
            // 
            this.textBoxContainButton8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton8.Desc = null;
            this.textBoxContainButton8.Format = null;
            this.textBoxContainButton8.ID = null;
            this.textBoxContainButton8.Location = new System.Drawing.Point(244, 54);
            this.textBoxContainButton8.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton8.Name = "textBoxContainButton8";
            this.textBoxContainButton8.ReadOnly = false;
            this.textBoxContainButton8.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton8.TabIndex = 20;
            // 
            // textBoxContainButton6
            // 
            this.textBoxContainButton6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton6.Desc = null;
            this.textBoxContainButton6.Format = null;
            this.textBoxContainButton6.ID = null;
            this.textBoxContainButton6.Location = new System.Drawing.Point(677, 27);
            this.textBoxContainButton6.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton6.Name = "textBoxContainButton6";
            this.textBoxContainButton6.ReadOnly = false;
            this.textBoxContainButton6.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton6.TabIndex = 15;
            // 
            // textBoxContainButton5
            // 
            this.textBoxContainButton5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton5.Desc = null;
            this.textBoxContainButton5.Format = null;
            this.textBoxContainButton5.ID = null;
            this.textBoxContainButton5.Location = new System.Drawing.Point(489, 27);
            this.textBoxContainButton5.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton5.Name = "textBoxContainButton5";
            this.textBoxContainButton5.ReadOnly = false;
            this.textBoxContainButton5.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton5.TabIndex = 14;
            // 
            // textBoxContainButton3
            // 
            this.textBoxContainButton3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton3.Desc = null;
            this.textBoxContainButton3.Format = null;
            this.textBoxContainButton3.ID = null;
            this.textBoxContainButton3.Location = new System.Drawing.Point(59, 27);
            this.textBoxContainButton3.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton3.Name = "textBoxContainButton3";
            this.textBoxContainButton3.ReadOnly = false;
            this.textBoxContainButton3.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton3.TabIndex = 11;
            // 
            // textBoxContainButton4
            // 
            this.textBoxContainButton4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton4.Desc = null;
            this.textBoxContainButton4.Format = null;
            this.textBoxContainButton4.ID = null;
            this.textBoxContainButton4.Location = new System.Drawing.Point(244, 27);
            this.textBoxContainButton4.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton4.Name = "textBoxContainButton4";
            this.textBoxContainButton4.ReadOnly = false;
            this.textBoxContainButton4.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton4.TabIndex = 12;
            // 
            // cbxReqType
            // 
            this.cbxReqType.FormattingEnabled = true;
            this.cbxReqType.Location = new System.Drawing.Point(492, 3);
            this.cbxReqType.Name = "cbxReqType";
            this.cbxReqType.Size = new System.Drawing.Size(147, 20);
            this.cbxReqType.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(864, 64);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.Controls.Add(this.BtnDel, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnClose, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSs, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnUpd, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnAdd, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnQuery, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCh, 5, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(9, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(432, 32);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnSs
            // 
            this.btnSs.Location = new System.Drawing.Point(247, 3);
            this.btnSs.Name = "btnSs";
            this.btnSs.Size = new System.Drawing.Size(55, 23);
            this.btnSs.TabIndex = 5;
            this.btnSs.Text = "发送";
            this.btnSs.UseVisualStyleBackColor = true;
            this.btnSs.Click += new System.EventHandler(this.btnSs_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(64, 3);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(55, 25);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "新增";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnQuery
            // 
            this.BtnQuery.Location = new System.Drawing.Point(3, 3);
            this.BtnQuery.Name = "BtnQuery";
            this.BtnQuery.Size = new System.Drawing.Size(55, 25);
            this.BtnQuery.TabIndex = 0;
            this.BtnQuery.Text = "查询";
            this.BtnQuery.UseVisualStyleBackColor = true;
            this.BtnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // btnCh
            // 
            this.btnCh.Location = new System.Drawing.Point(308, 3);
            this.btnCh.Name = "btnCh";
            this.btnCh.Size = new System.Drawing.Size(55, 23);
            this.btnCh.TabIndex = 6;
            this.btnCh.Text = "撤回";
            this.btnCh.UseVisualStyleBackColor = true;
            this.btnCh.Click += new System.EventHandler(this.btnCh_Click);
            // 
            // RequestCollectionOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "RequestCollectionOrderForm";
            this.Size = new System.Drawing.Size(864, 560);
            this.Load += new System.EventHandler(this.RequestCollectionOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.Button BtnUpd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnQuery;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lalel1;
        private System.Windows.Forms.Label lalel2;
        private TextBoxContainButton textBoxContainButton1;
        private TextBoxContainButton textBoxContainButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private TextBoxContainButton textBoxContainButton3;
        private TextBoxContainButton textBoxContainButton4;
        private TextBoxContainButton textBoxContainButton5;
        private System.Windows.Forms.Label label4;
        private TextBoxContainButton textBoxContainButton6;
        private System.Windows.Forms.Label label5;
        private TextBoxContainButton textBoxContainButton7;
        private System.Windows.Forms.Label label6;
        private TextBoxContainButton textBoxContainButton8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cbxReqType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Collection_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReqType_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesType_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CsvPo_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Req_Csv_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usr__Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create__Date;
        private System.Windows.Forms.Button btnSs;
        private System.Windows.Forms.Button btnCh;
    }
}
