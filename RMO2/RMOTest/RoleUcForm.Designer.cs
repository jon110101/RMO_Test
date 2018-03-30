namespace RMOTest
{
    partial class RoleUcForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
            this.BtnUpd = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnQuery = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.角色名称 = new System.Windows.Forms.Label();
            this.公司编号 = new System.Windows.Forms.Label();
            this.角色编码 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxContainButton1 = new RMOTest.TextBoxContainButton();
            this.textBoxContainButton2 = new RMOTest.TextBoxContainButton();
            this.textBoxContainButton3 = new RMOTest.TextBoxContainButton();
            this.textBoxContainButton4 = new RMOTest.TextBoxContainButton();
            this.P_Itm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc_01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parent_Role_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usr__Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create__Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.panel1.TabIndex = 0;
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
            this.tableLayoutPanel1.Controls.Add(this.角色名称, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.公司编号, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.角色编码, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton3, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton4, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtRoleName, 1, 1);
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
            // 角色名称
            // 
            this.角色名称.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.角色名称.AutoSize = true;
            this.角色名称.Location = new System.Drawing.Point(3, 54);
            this.角色名称.Name = "角色名称";
            this.角色名称.Size = new System.Drawing.Size(53, 12);
            this.角色名称.TabIndex = 2;
            this.角色名称.Text = "角色名称";
            // 
            // 公司编号
            // 
            this.公司编号.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.公司编号.AutoSize = true;
            this.公司编号.Location = new System.Drawing.Point(3, 14);
            this.公司编号.Name = "公司编号";
            this.公司编号.Size = new System.Drawing.Size(53, 12);
            this.公司编号.TabIndex = 0;
            this.公司编号.Text = "公司编码";
            // 
            // 角色编码
            // 
            this.角色编码.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.角色编码.AutoSize = true;
            this.角色编码.Location = new System.Drawing.Point(430, 14);
            this.角色编码.Name = "角色编码";
            this.角色编码.Size = new System.Drawing.Size(53, 12);
            this.角色编码.TabIndex = 1;
            this.角色编码.Text = "角色编码";
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
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(639, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "----";
            // 
            // txtRoleName
            // 
            this.txtRoleName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtRoleName, 3);
            this.txtRoleName.Location = new System.Drawing.Point(62, 49);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(332, 21);
            this.txtRoleName.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 143);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(864, 417);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.P_Itm,
            this.Company_Id,
            this.Role_Id,
            this.Desc_01,
            this.Parent_Role_Id,
            this.Remark,
            this.Usr__Id,
            this.Create__Time});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(864, 417);
            this.dataGridView1.TabIndex = 1;
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
            // textBoxContainButton3
            // 
            this.textBoxContainButton3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton3.Location = new System.Drawing.Point(486, 6);
            this.textBoxContainButton3.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton3.Name = "textBoxContainButton3";
            this.textBoxContainButton3.ReadOnly = false;
            this.textBoxContainButton3.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton3.TabIndex = 6;
            // 
            // textBoxContainButton4
            // 
            this.textBoxContainButton4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton4.Location = new System.Drawing.Point(671, 6);
            this.textBoxContainButton4.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton4.Name = "textBoxContainButton4";
            this.textBoxContainButton4.ReadOnly = false;
            this.textBoxContainButton4.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton4.TabIndex = 8;
            // 
            // P_Itm
            // 
            this.P_Itm.DataPropertyName = "P_Itm";
            this.P_Itm.HeaderText = "序号";
            this.P_Itm.Name = "P_Itm";
            this.P_Itm.Width = 80;
            // 
            // Company_Id
            // 
            this.Company_Id.DataPropertyName = "Company_Id";
            this.Company_Id.HeaderText = "公司编码";
            this.Company_Id.Name = "Company_Id";
            this.Company_Id.Width = 150;
            // 
            // Role_Id
            // 
            this.Role_Id.DataPropertyName = "Role_Id";
            this.Role_Id.HeaderText = "角色编码";
            this.Role_Id.Name = "Role_Id";
            // 
            // Desc_01
            // 
            this.Desc_01.DataPropertyName = "Desc_01";
            this.Desc_01.HeaderText = "角色名称";
            this.Desc_01.Name = "Desc_01";
            this.Desc_01.Width = 150;
            // 
            // Parent_Role_Id
            // 
            this.Parent_Role_Id.DataPropertyName = "Parent_Role_Id";
            this.Parent_Role_Id.HeaderText = "上级角色";
            this.Parent_Role_Id.Name = "Parent_Role_Id";
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.Width = 150;
            // 
            // Usr__Id
            // 
            this.Usr__Id.DataPropertyName = "Usr__Id";
            this.Usr__Id.HeaderText = "录入用户";
            this.Usr__Id.Name = "Usr__Id";
            // 
            // Create__Time
            // 
            this.Create__Time.DataPropertyName = "Create__Time";
            this.Create__Time.HeaderText = "录入时间";
            this.Create__Time.Name = "Create__Time";
            // 
            // RoleUcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "RoleUcForm";
            this.Size = new System.Drawing.Size(864, 560);
            this.Load += new System.EventHandler(this.RoleUcForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.Button BtnUpd;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnQuery;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label 角色名称;
        private System.Windows.Forms.Label 公司编号;
        private System.Windows.Forms.Label 角色编码;
        private TextBoxContainButton textBoxContainButton1;
        private TextBoxContainButton textBoxContainButton2;
        private System.Windows.Forms.Label label1;
        private TextBoxContainButton textBoxContainButton3;
        private System.Windows.Forms.Label label2;
        private TextBoxContainButton textBoxContainButton4;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_Itm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc_01;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parent_Role_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usr__Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create__Time;
    }
}
