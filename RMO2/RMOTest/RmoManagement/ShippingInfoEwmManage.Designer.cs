namespace RMO.RmoManagement
{
    partial class ShippingInfoEwmManage
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
            this.BtnOk = new System.Windows.Forms.Button();
            this.公司编号 = new System.Windows.Forms.Label();
            this.角色编码 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtXh = new System.Windows.Forms.TextBox();
            this.txtUt = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.txtPo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ITM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scan_Ewm_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemUnit_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Po_Itm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Xm_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amt_No_Tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shipping_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty_Shipping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Available_Qty_Serial_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manufacturer_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AQID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurType_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty_Po = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Already_Shipping_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Carrier_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lading_Shipping_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarCode_Print_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPrpty_Id_Before = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSerial_Id_Before = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AQID_Before = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.V = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Planning_Shipping_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shipping_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Planning_Arrive_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(3, 3);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 25);
            this.BtnOk.TabIndex = 0;
            this.BtnOk.Text = "确认";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // 公司编号
            // 
            this.公司编号.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.公司编号.AutoSize = true;
            this.公司编号.Location = new System.Drawing.Point(34, 9);
            this.公司编号.Name = "公司编号";
            this.公司编号.Size = new System.Drawing.Size(41, 12);
            this.公司编号.TabIndex = 0;
            this.公司编号.Text = "客户PO";
            // 
            // 角色编码
            // 
            this.角色编码.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.角色编码.AutoSize = true;
            this.角色编码.Location = new System.Drawing.Point(320, 9);
            this.角色编码.Name = "角色编码";
            this.角色编码.Size = new System.Drawing.Size(29, 12);
            this.角色编码.TabIndex = 1;
            this.角色编码.Text = "型号";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "单位";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "数量";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 131);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(939, 67);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.04762F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.761905F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.04762F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.761905F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.04762F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.761905F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.Controls.Add(this.公司编号, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.角色编码, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtXh, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtUt, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtQty, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnInput, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPo, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(939, 67);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtXh
            // 
            this.txtXh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtXh.Location = new System.Drawing.Point(355, 3);
            this.txtXh.Name = "txtXh";
            this.txtXh.ReadOnly = true;
            this.txtXh.Size = new System.Drawing.Size(151, 21);
            this.txtXh.TabIndex = 17;
            // 
            // txtUt
            // 
            this.txtUt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUt.Location = new System.Drawing.Point(81, 34);
            this.txtUt.Name = "txtUt";
            this.txtUt.Size = new System.Drawing.Size(151, 21);
            this.txtUt.TabIndex = 18;
            // 
            // txtQty
            // 
            this.txtQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQty.Location = new System.Drawing.Point(355, 34);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(151, 21);
            this.txtQty.TabIndex = 19;
            // 
            // btnInput
            // 
            this.btnInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.btnInput, 2);
            this.btnInput.Location = new System.Drawing.Point(551, 4);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(108, 23);
            this.btnInput.TabIndex = 20;
            this.btnInput.Text = "模拟产生系列号";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // txtPo
            // 
            this.txtPo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPo.Location = new System.Drawing.Point(81, 3);
            this.txtPo.Name = "txtPo";
            this.txtPo.ReadOnly = true;
            this.txtPo.Size = new System.Drawing.Size(151, 21);
            this.txtPo.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(939, 64);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.BtnCancel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnOk, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(9, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(238, 32);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(122, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 25);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(939, 543);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 131);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(939, 412);
            this.panel3.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ITM,
            this.Scan_Ewm_Id,
            this.ItemUnit_Id,
            this.Qty,
            this.Po_Itm,
            this.Xm_Id,
            this.Item_Desc,
            this.Amt_No_Tax,
            this.Shipping_Address,
            this.Qty_Shipping,
            this.Available_Qty_Serial_Id,
            this.Manufacturer_Id,
            this.Serial_Id,
            this.AQID,
            this.PurType_Id,
            this.Qty_Po,
            this.Already_Shipping_Id,
            this.Carrier_Id,
            this.Lading_Shipping_Id,
            this.BarCode_Print_Qty,
            this.ItemPrpty_Id_Before,
            this.ItemSerial_Id_Before,
            this.AQID_Before,
            this.V,
            this.APO,
            this.Planning_Shipping_Date,
            this.Shipping_Date,
            this.Planning_Arrive_Date});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(939, 412);
            this.dataGridView1.TabIndex = 0;
            // 
            // ITM
            // 
            this.ITM.DataPropertyName = "ITM";
            this.ITM.HeaderText = "序号";
            this.ITM.Name = "ITM";
            this.ITM.Width = 51;
            // 
            // Scan_Ewm_Id
            // 
            this.Scan_Ewm_Id.DataPropertyName = "Scan_Ewm_Id";
            this.Scan_Ewm_Id.HeaderText = "二维码";
            this.Scan_Ewm_Id.Name = "Scan_Ewm_Id";
            // 
            // ItemUnit_Id
            // 
            this.ItemUnit_Id.DataPropertyName = "ItemUnit_Id";
            this.ItemUnit_Id.HeaderText = "单位";
            this.ItemUnit_Id.Name = "ItemUnit_Id";
            this.ItemUnit_Id.Width = 51;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            this.Qty.HeaderText = "数量";
            this.Qty.Name = "Qty";
            this.Qty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Qty.Width = 51;
            // 
            // Po_Itm
            // 
            this.Po_Itm.DataPropertyName = "Po_Itm";
            this.Po_Itm.HeaderText = "PO行号";
            this.Po_Itm.Name = "Po_Itm";
            this.Po_Itm.Width = 52;
            // 
            // Xm_Id
            // 
            this.Xm_Id.DataPropertyName = "Xm_Id";
            this.Xm_Id.HeaderText = "项目代码";
            this.Xm_Id.Name = "Xm_Id";
            this.Xm_Id.Width = 52;
            // 
            // Item_Desc
            // 
            this.Item_Desc.DataPropertyName = "Item_Desc";
            this.Item_Desc.HeaderText = "设备描述";
            this.Item_Desc.Name = "Item_Desc";
            this.Item_Desc.Width = 51;
            // 
            // Amt_No_Tax
            // 
            this.Amt_No_Tax.DataPropertyName = "Amt_No_Tax";
            this.Amt_No_Tax.HeaderText = "无税金额";
            this.Amt_No_Tax.Name = "Amt_No_Tax";
            this.Amt_No_Tax.Width = 51;
            // 
            // Shipping_Address
            // 
            this.Shipping_Address.DataPropertyName = "Shipping_Address";
            this.Shipping_Address.HeaderText = "送货地址";
            this.Shipping_Address.Name = "Shipping_Address";
            this.Shipping_Address.Width = 51;
            // 
            // Qty_Shipping
            // 
            this.Qty_Shipping.DataPropertyName = "Qty_Shipping";
            this.Qty_Shipping.HeaderText = "送货数量";
            this.Qty_Shipping.Name = "Qty_Shipping";
            this.Qty_Shipping.Width = 52;
            // 
            // Available_Qty_Serial_Id
            // 
            this.Available_Qty_Serial_Id.DataPropertyName = "Available_Qty_Serial_Id";
            this.Available_Qty_Serial_Id.HeaderText = "可用数量序号";
            this.Available_Qty_Serial_Id.Name = "Available_Qty_Serial_Id";
            this.Available_Qty_Serial_Id.Width = 51;
            // 
            // Manufacturer_Id
            // 
            this.Manufacturer_Id.DataPropertyName = "Manufacturer_Id";
            this.Manufacturer_Id.HeaderText = "制作商";
            this.Manufacturer_Id.Name = "Manufacturer_Id";
            this.Manufacturer_Id.Width = 51;
            // 
            // Serial_Id
            // 
            this.Serial_Id.DataPropertyName = "Serial_Id";
            this.Serial_Id.HeaderText = "设备序列号";
            this.Serial_Id.Name = "Serial_Id";
            this.Serial_Id.Width = 52;
            // 
            // AQID
            // 
            this.AQID.DataPropertyName = "AQID";
            this.AQID.HeaderText = "AQID";
            this.AQID.Name = "AQID";
            this.AQID.Width = 51;
            // 
            // PurType_Id
            // 
            this.PurType_Id.DataPropertyName = "PurType_Id";
            this.PurType_Id.HeaderText = "采购类型";
            this.PurType_Id.Name = "PurType_Id";
            // 
            // Qty_Po
            // 
            this.Qty_Po.DataPropertyName = "Qty_Po";
            this.Qty_Po.HeaderText = "PO数量";
            this.Qty_Po.Name = "Qty_Po";
            // 
            // Already_Shipping_Id
            // 
            this.Already_Shipping_Id.DataPropertyName = "Already_Shipping_Id";
            this.Already_Shipping_Id.HeaderText = "是否发货";
            this.Already_Shipping_Id.Name = "Already_Shipping_Id";
            // 
            // Carrier_Id
            // 
            this.Carrier_Id.DataPropertyName = "Carrier_Id";
            this.Carrier_Id.HeaderText = "承运人代码";
            this.Carrier_Id.Name = "Carrier_Id";
            // 
            // Lading_Shipping_Id
            // 
            this.Lading_Shipping_Id.DataPropertyName = "Lading_Shipping_Id";
            this.Lading_Shipping_Id.HeaderText = "提单/送货单编号";
            this.Lading_Shipping_Id.Name = "Lading_Shipping_Id";
            // 
            // BarCode_Print_Qty
            // 
            this.BarCode_Print_Qty.DataPropertyName = "BarCode_Print_Qty";
            this.BarCode_Print_Qty.HeaderText = "条码打印数量";
            this.BarCode_Print_Qty.Name = "BarCode_Print_Qty";
            this.BarCode_Print_Qty.Visible = false;
            // 
            // ItemPrpty_Id_Before
            // 
            this.ItemPrpty_Id_Before.DataPropertyName = "ItemPrpty_Id_Before";
            this.ItemPrpty_Id_Before.HeaderText = "设备型号(改机前一次)";
            this.ItemPrpty_Id_Before.Name = "ItemPrpty_Id_Before";
            this.ItemPrpty_Id_Before.Visible = false;
            // 
            // ItemSerial_Id_Before
            // 
            this.ItemSerial_Id_Before.DataPropertyName = "ItemSerial_Id_Before";
            this.ItemSerial_Id_Before.HeaderText = "设备序列号(改机前一次)";
            this.ItemSerial_Id_Before.Name = "ItemSerial_Id_Before";
            this.ItemSerial_Id_Before.Visible = false;
            // 
            // AQID_Before
            // 
            this.AQID_Before.DataPropertyName = "AQID_Before";
            this.AQID_Before.HeaderText = "AQID(改机前一次)";
            this.AQID_Before.Name = "AQID_Before";
            // 
            // V
            // 
            this.V.DataPropertyName = "V";
            this.V.HeaderText = "V";
            this.V.Name = "V";
            // 
            // APO
            // 
            this.APO.DataPropertyName = "APO";
            this.APO.HeaderText = "APO";
            this.APO.Name = "APO";
            // 
            // Planning_Shipping_Date
            // 
            this.Planning_Shipping_Date.DataPropertyName = "Planning_Shipping_Date";
            this.Planning_Shipping_Date.HeaderText = "预计发货时间";
            this.Planning_Shipping_Date.Name = "Planning_Shipping_Date";
            // 
            // Shipping_Date
            // 
            this.Shipping_Date.DataPropertyName = "Shipping_Date";
            this.Shipping_Date.HeaderText = "实际发货时间";
            this.Shipping_Date.Name = "Shipping_Date";
            // 
            // Planning_Arrive_Date
            // 
            this.Planning_Arrive_Date.DataPropertyName = "Planning_Arrive_Date";
            this.Planning_Arrive_Date.HeaderText = "预计到达时间";
            this.Planning_Arrive_Date.Name = "Planning_Arrive_Date";
            // 
            // ShippingInfoEwmManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 543);
            this.Controls.Add(this.panel4);
            this.Name = "ShippingInfoEwmManage";
            this.Text = "ShippingInfoEwmManage";
            this.Load += new System.EventHandler(this.ShippingInfoEwmManage_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Label 公司编号;
        private System.Windows.Forms.Label 角色编码;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtXh;
        private System.Windows.Forms.TextBox txtUt;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtPo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scan_Ewm_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemUnit_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Po_Itm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Xm_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amt_No_Tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shipping_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty_Shipping;
        private System.Windows.Forms.DataGridViewTextBoxColumn Available_Qty_Serial_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manufacturer_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn AQID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurType_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty_Po;
        private System.Windows.Forms.DataGridViewTextBoxColumn Already_Shipping_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Carrier_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lading_Shipping_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarCode_Print_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPrpty_Id_Before;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSerial_Id_Before;
        private System.Windows.Forms.DataGridViewTextBoxColumn AQID_Before;
        private System.Windows.Forms.DataGridViewTextBoxColumn V;
        private System.Windows.Forms.DataGridViewTextBoxColumn APO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Planning_Shipping_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shipping_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Planning_Arrive_Date;
    }
}