namespace RMO.BasisManage
{
    partial class EmployeeForm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.部门编码 = new System.Windows.Forms.Label();
            this.lblcompany = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.textBoxContainButton1 = new RMO.TextBoxContainButton();
            this.textBoxContainButton2 = new RMO.TextBoxContainButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxContainButton3 = new RMO.TextBoxContainButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxContainButton4 = new RMO.TextBoxContainButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxContainButton6 = new RMO.TextBoxContainButton();
            this.textBoxContainButton5 = new RMO.TextBoxContainButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
            this.BtnUpd = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnQuery = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ITM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc_01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductArea_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usr__Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create__Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ITM,
            this.Company_Id,
            this.Employee_Id,
            this.Desc_01,
            this.Remark,
            this.ProductArea_Id,
            this.Usr__Id,
            this.Create__Date});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(864, 417);
            this.dataGridView1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 143);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(864, 417);
            this.panel3.TabIndex = 4;
            // 
            // 部门编码
            // 
            this.部门编码.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.部门编码.AutoSize = true;
            this.部门编码.Location = new System.Drawing.Point(3, 54);
            this.部门编码.Name = "部门编码";
            this.部门编码.Size = new System.Drawing.Size(53, 12);
            this.部门编码.TabIndex = 2;
            this.部门编码.Text = "部门编码";
            // 
            // lblcompany
            // 
            this.lblcompany.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblcompany.AutoSize = true;
            this.lblcompany.Location = new System.Drawing.Point(3, 14);
            this.lblcompany.Name = "lblcompany";
            this.lblcompany.Size = new System.Drawing.Size(53, 12);
            this.lblcompany.TabIndex = 0;
            this.lblcompany.Text = "员工编码";
            // 
            // lblname
            // 
            this.lblname.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(427, 14);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(53, 12);
            this.lblname.TabIndex = 1;
            this.lblname.Text = "员工姓名";
            // 
            // textBoxContainButton1
            // 
            this.textBoxContainButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton1.Location = new System.Drawing.Point(59, 6);
            this.textBoxContainButton1.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton1.Name = "textBoxContainButton1";
            this.textBoxContainButton1.ReadOnly = false;
            this.textBoxContainButton1.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton1.TabIndex = 3;
            // 
            // textBoxContainButton2
            // 
            this.textBoxContainButton2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton2.Location = new System.Drawing.Point(244, 6);
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
            this.label1.Location = new System.Drawing.Point(212, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "----";
            // 
            // textBoxContainButton3
            // 
            this.textBoxContainButton3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton3.Location = new System.Drawing.Point(59, 46);
            this.textBoxContainButton3.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton3.Name = "textBoxContainButton3";
            this.textBoxContainButton3.ReadOnly = false;
            this.textBoxContainButton3.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton3.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(636, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "----";
            // 
            // textBoxContainButton4
            // 
            this.textBoxContainButton4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton4.Location = new System.Drawing.Point(244, 46);
            this.textBoxContainButton4.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton4.Name = "textBoxContainButton4";
            this.textBoxContainButton4.ReadOnly = false;
            this.textBoxContainButton4.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton4.TabIndex = 8;
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtName, 3);
            this.txtName.Location = new System.Drawing.Point(486, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(332, 21);
            this.txtName.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(864, 82);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.部门编码, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton6, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton5, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblcompany, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblname, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton4, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(864, 82);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // textBoxContainButton6
            // 
            this.textBoxContainButton6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton6.Location = new System.Drawing.Point(668, 46);
            this.textBoxContainButton6.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton6.Name = "textBoxContainButton6";
            this.textBoxContainButton6.ReadOnly = false;
            this.textBoxContainButton6.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton6.TabIndex = 12;
            // 
            // textBoxContainButton5
            // 
            this.textBoxContainButton5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton5.Location = new System.Drawing.Point(483, 46);
            this.textBoxContainButton5.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton5.Name = "textBoxContainButton5";
            this.textBoxContainButton5.ReadOnly = false;
            this.textBoxContainButton5.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton5.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "----";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(427, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "登录用户";
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(335, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 25);
            this.BtnClose.TabIndex = 4;
            this.BtnClose.Text = "关闭";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnDel
            // 
            this.BtnDel.Location = new System.Drawing.Point(252, 3);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(75, 25);
            this.BtnDel.TabIndex = 3;
            this.BtnDel.Text = "删除";
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // BtnUpd
            // 
            this.BtnUpd.Location = new System.Drawing.Point(169, 3);
            this.BtnUpd.Name = "BtnUpd";
            this.BtnUpd.Size = new System.Drawing.Size(75, 25);
            this.BtnUpd.TabIndex = 2;
            this.BtnUpd.Text = "修改";
            this.BtnUpd.UseVisualStyleBackColor = true;
            this.BtnUpd.Click += new System.EventHandler(this.BtnUpd_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(86, 3);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 25);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "新增";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnQuery
            // 
            this.BtnQuery.Location = new System.Drawing.Point(3, 3);
            this.BtnQuery.Name = "BtnQuery";
            this.BtnQuery.Size = new System.Drawing.Size(75, 25);
            this.BtnQuery.TabIndex = 0;
            this.BtnQuery.Text = "查询";
            this.BtnQuery.UseVisualStyleBackColor = true;
            this.BtnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.BtnClose, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnDel, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnUpd, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnAdd, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnQuery, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(9, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(417, 32);
            this.tableLayoutPanel2.TabIndex = 0;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 143);
            this.panel1.TabIndex = 3;
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
            // Employee_Id
            // 
            this.Employee_Id.DataPropertyName = "Employee_Id";
            this.Employee_Id.HeaderText = "员工编码";
            this.Employee_Id.Name = "Employee_Id";
            // 
            // Desc_01
            // 
            this.Desc_01.DataPropertyName = "Desc_01";
            this.Desc_01.HeaderText = "名称";
            this.Desc_01.Name = "Desc_01";
            this.Desc_01.Width = 150;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.Width = 150;
            // 
            // ProductArea_Id
            // 
            this.ProductArea_Id.DataPropertyName = "ProductArea_Id";
            this.ProductArea_Id.HeaderText = "生产厂区";
            this.ProductArea_Id.Name = "ProductArea_Id";
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
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "EmployeeForm";
            this.Size = new System.Drawing.Size(864, 560);
            this.Load += new System.EventHandler(this.EmployeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label 部门编码;
        private System.Windows.Forms.Label lblcompany;
        private System.Windows.Forms.Label lblname;
        private TextBoxContainButton textBoxContainButton1;
        private TextBoxContainButton textBoxContainButton2;
        private System.Windows.Forms.Label label1;
        private TextBoxContainButton textBoxContainButton3;
        private System.Windows.Forms.Label label2;
        private TextBoxContainButton textBoxContainButton4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.Button BtnUpd;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnQuery;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private TextBoxContainButton textBoxContainButton5;
        private System.Windows.Forms.Label label3;
        private TextBoxContainButton textBoxContainButton6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc_01;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductArea_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usr__Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create__Date;
    }
}