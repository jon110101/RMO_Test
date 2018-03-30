namespace RMO.RmoManagement
{
    partial class InputByCollectionOrderForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ITM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Choose_Id = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Src_Company_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Src_Bil_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CsvPo_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Project_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Spec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.部门编号 = new System.Windows.Forms.Label();
            this.textBoxContainButton1 = new RMO.TextBoxContainButton();
            this.label1 = new System.Windows.Forms.Label();
            this.部门名称 = new System.Windows.Forms.Label();
            this.textBoxContainButton2 = new RMO.TextBoxContainButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxContainButton3 = new RMO.TextBoxContainButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxContainButton4 = new RMO.TextBoxContainButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnQuery = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.Choose_Id,
            this.Src_Company_Id,
            this.Src_Bil_Id,
            this.CsvPo_Id,
            this.Project_Id,
            this.Item_Id,
            this.Item_Spec,
            this.Qty});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 126);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(884, 435);
            this.dataGridView1.TabIndex = 1;
            // 
            // ITM
            // 
            this.ITM.DataPropertyName = "ITM";
            this.ITM.HeaderText = "序号";
            this.ITM.Name = "ITM";
            this.ITM.Width = 80;
            // 
            // Choose_Id
            // 
            this.Choose_Id.DataPropertyName = "Choose_Id";
            this.Choose_Id.FalseValue = "F";
            this.Choose_Id.HeaderText = "选择";
            this.Choose_Id.Name = "Choose_Id";
            this.Choose_Id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Choose_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Choose_Id.TrueValue = "T";
            // 
            // Src_Company_Id
            // 
            this.Src_Company_Id.DataPropertyName = "Src_Company_Id";
            this.Src_Company_Id.HeaderText = "来源公司";
            this.Src_Company_Id.Name = "Src_Company_Id";
            // 
            // Src_Bil_Id
            // 
            this.Src_Bil_Id.DataPropertyName = "Src_Bil_Id";
            this.Src_Bil_Id.HeaderText = "来源单号";
            this.Src_Bil_Id.Name = "Src_Bil_Id";
            this.Src_Bil_Id.Width = 150;
            // 
            // CsvPo_Id
            // 
            this.CsvPo_Id.DataPropertyName = "CsvPo_Id";
            this.CsvPo_Id.HeaderText = "客户PO";
            this.CsvPo_Id.Name = "CsvPo_Id";
            // 
            // Project_Id
            // 
            this.Project_Id.DataPropertyName = "Project_Id";
            this.Project_Id.HeaderText = "项目编号";
            this.Project_Id.Name = "Project_Id";
            this.Project_Id.Width = 150;
            // 
            // Item_Id
            // 
            this.Item_Id.DataPropertyName = "Item_Id";
            this.Item_Id.HeaderText = "存货编码";
            this.Item_Id.Name = "Item_Id";
            // 
            // Item_Spec
            // 
            this.Item_Spec.DataPropertyName = "Item_Spec";
            this.Item_Spec.HeaderText = "规格型号";
            this.Item_Spec.Name = "Item_Spec";
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            this.Qty.HeaderText = "数量";
            this.Qty.Name = "Qty";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 561);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(884, 126);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 211F));
            this.tableLayoutPanel1.Controls.Add(this.部门编号, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.部门名称, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton2, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton3, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton4, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 58);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 68);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // 部门编号
            // 
            this.部门编号.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.部门编号.AutoSize = true;
            this.部门编号.Location = new System.Drawing.Point(3, 9);
            this.部门编号.Name = "部门编号";
            this.部门编号.Size = new System.Drawing.Size(53, 12);
            this.部门编号.TabIndex = 0;
            this.部门编号.Text = "公司编码";
            // 
            // textBoxContainButton1
            // 
            this.textBoxContainButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton1.Desc = null;
            this.textBoxContainButton1.Format = null;
            this.textBoxContainButton1.ID = null;
            this.textBoxContainButton1.Location = new System.Drawing.Point(59, 2);
            this.textBoxContainButton1.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton1.Name = "textBoxContainButton1";
            this.textBoxContainButton1.ReadOnly = false;
            this.textBoxContainButton1.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 5;
            // 
            // 部门名称
            // 
            this.部门名称.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.部门名称.AutoSize = true;
            this.部门名称.Location = new System.Drawing.Point(232, 9);
            this.部门名称.Name = "部门名称";
            this.部门名称.Size = new System.Drawing.Size(53, 12);
            this.部门名称.TabIndex = 1;
            this.部门名称.Text = "来源单号";
            // 
            // textBoxContainButton2
            // 
            this.textBoxContainButton2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton2.Desc = null;
            this.textBoxContainButton2.Format = null;
            this.textBoxContainButton2.ID = null;
            this.textBoxContainButton2.Location = new System.Drawing.Point(288, 2);
            this.textBoxContainButton2.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton2.Name = "textBoxContainButton2";
            this.textBoxContainButton2.ReadOnly = false;
            this.textBoxContainButton2.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "仓库/库位";
            // 
            // textBoxContainButton3
            // 
            this.textBoxContainButton3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton3.Desc = null;
            this.textBoxContainButton3.Format = null;
            this.textBoxContainButton3.ID = null;
            this.textBoxContainButton3.Location = new System.Drawing.Point(523, 0);
            this.textBoxContainButton3.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton3.Name = "textBoxContainButton3";
            this.textBoxContainButton3.ReadOnly = false;
            this.textBoxContainButton3.Size = new System.Drawing.Size(150, 31);
            this.textBoxContainButton3.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "存货编码";
            // 
            // textBoxContainButton4
            // 
            this.textBoxContainButton4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton4.Desc = null;
            this.textBoxContainButton4.Format = null;
            this.textBoxContainButton4.ID = null;
            this.textBoxContainButton4.Location = new System.Drawing.Point(59, 31);
            this.textBoxContainButton4.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton4.Name = "textBoxContainButton4";
            this.textBoxContainButton4.ReadOnly = false;
            this.textBoxContainButton4.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton4.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(884, 58);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.BtnClose, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnQuery, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnOk, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(9, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(244, 32);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(165, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 25);
            this.BtnClose.TabIndex = 4;
            this.BtnClose.Text = "关闭";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnQuery
            // 
            this.BtnQuery.Location = new System.Drawing.Point(84, 3);
            this.BtnQuery.Name = "BtnQuery";
            this.BtnQuery.Size = new System.Drawing.Size(75, 25);
            this.BtnQuery.TabIndex = 0;
            this.BtnQuery.Text = "查询";
            this.BtnQuery.UseVisualStyleBackColor = true;
            this.BtnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(3, 3);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 25);
            this.BtnOk.TabIndex = 1;
            this.BtnOk.Text = "确定";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // InputByCollectionOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.panel1);
            this.Name = "InputByCollectionOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputByCollectionOrderForm";
            this.Load += new System.EventHandler(this.InputByCollectionOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label 部门编号;
        private System.Windows.Forms.Label 部门名称;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnQuery;
        private System.Windows.Forms.Button BtnOk;
        private TextBoxContainButton textBoxContainButton2;
        private System.Windows.Forms.Label label2;
        private TextBoxContainButton textBoxContainButton3;
        private System.Windows.Forms.Label label3;
        private TextBoxContainButton textBoxContainButton4;
        private TextBoxContainButton textBoxContainButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Choose_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Src_Company_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Src_Bil_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CsvPo_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Project_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Spec;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
    }
}