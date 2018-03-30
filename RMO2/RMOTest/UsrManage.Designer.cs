namespace RMOTest
{
    partial class UsrManage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtUsrId = new System.Windows.Forms.TextBox();
            this.公司编号 = new System.Windows.Forms.Label();
            this.角色编码 = new System.Windows.Forms.Label();
            this.角色名称 = new System.Windows.Forms.Label();
            this.txtZt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtPwd1 = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLrUsr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCTime = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.可访问公司 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.可访问角色 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.用户 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Size = new System.Drawing.Size(794, 178);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(794, 64);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 117);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Controls.Add(this.txtUsrId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.公司编号, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.角色编码, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.角色名称, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtZt, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPwd, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPwd1, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtLrUsr, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCTime, 4, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(708, 114);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtUsrId
            // 
            this.txtUsrId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUsrId.Location = new System.Drawing.Point(62, 8);
            this.txtUsrId.Name = "txtUsrId";
            this.txtUsrId.Size = new System.Drawing.Size(147, 21);
            this.txtUsrId.TabIndex = 1;
            // 
            // 公司编号
            // 
            this.公司编号.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.公司编号.AutoSize = true;
            this.公司编号.Location = new System.Drawing.Point(3, 12);
            this.公司编号.Name = "公司编号";
            this.公司编号.Size = new System.Drawing.Size(53, 12);
            this.公司编号.TabIndex = 0;
            this.公司编号.Text = "用户编码";
            // 
            // 角色编码
            // 
            this.角色编码.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.角色编码.AutoSize = true;
            this.角色编码.Location = new System.Drawing.Point(235, 12);
            this.角色编码.Name = "角色编码";
            this.角色编码.Size = new System.Drawing.Size(53, 12);
            this.角色编码.TabIndex = 1;
            this.角色编码.Text = "用户姓名";
            // 
            // 角色名称
            // 
            this.角色名称.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.角色名称.AutoSize = true;
            this.角色名称.Location = new System.Drawing.Point(473, 12);
            this.角色名称.Name = "角色名称";
            this.角色名称.Size = new System.Drawing.Size(53, 12);
            this.角色名称.TabIndex = 2;
            this.角色名称.Text = "管理员否";
            // 
            // txtZt
            // 
            this.txtZt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtZt.Location = new System.Drawing.Point(532, 8);
            this.txtZt.Name = "txtZt";
            this.txtZt.ReadOnly = true;
            this.txtZt.Size = new System.Drawing.Size(147, 21);
            this.txtZt.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "密码";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "密码确认";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "Email地址";
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtName.Location = new System.Drawing.Point(294, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(147, 21);
            this.txtName.TabIndex = 17;
            // 
            // txtPwd
            // 
            this.txtPwd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPwd.Location = new System.Drawing.Point(62, 45);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(147, 21);
            this.txtPwd.TabIndex = 18;
            // 
            // txtPwd1
            // 
            this.txtPwd1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPwd1.Location = new System.Drawing.Point(294, 45);
            this.txtPwd1.Name = "txtPwd1";
            this.txtPwd1.Size = new System.Drawing.Size(147, 21);
            this.txtPwd1.TabIndex = 19;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtEmail.Location = new System.Drawing.Point(532, 45);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(147, 21);
            this.txtEmail.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "录入用户";
            // 
            // txtLrUsr
            // 
            this.txtLrUsr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtLrUsr.Location = new System.Drawing.Point(62, 82);
            this.txtLrUsr.Name = "txtLrUsr";
            this.txtLrUsr.ReadOnly = true;
            this.txtLrUsr.Size = new System.Drawing.Size(147, 21);
            this.txtLrUsr.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "录入日期";
            // 
            // txtCTime
            // 
            this.txtCTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCTime.Location = new System.Drawing.Point(294, 82);
            this.txtCTime.Name = "txtCTime";
            this.txtCTime.ReadOnly = true;
            this.txtCTime.Size = new System.Drawing.Size(147, 21);
            this.txtCTime.TabIndex = 24;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 178);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(794, 356);
            this.panel3.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.可访问公司,
            this.可访问角色,
            this.用户});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(794, 356);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataGridView1_CellParsing);
            // 
            // 序号
            // 
            this.序号.DataPropertyName = "ITM";
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            // 
            // 可访问公司
            // 
            this.可访问公司.DataPropertyName = "Company_Id";
            this.可访问公司.HeaderText = "可访问公司";
            this.可访问公司.Name = "可访问公司";
            this.可访问公司.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.可访问公司.Width = 200;
            // 
            // 可访问角色
            // 
            this.可访问角色.DataPropertyName = "Role_Id";
            this.可访问角色.HeaderText = "可访问角色";
            this.可访问角色.Name = "可访问角色";
            this.可访问角色.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.可访问角色.Width = 200;
            // 
            // 用户
            // 
            this.用户.DataPropertyName = "Usr_Id";
            this.用户.HeaderText = "用户";
            this.用户.Name = "用户";
            this.用户.Visible = false;
            // 
            // UsrManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 534);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "UsrManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户";
            this.Load += new System.EventHandler(this.UsrManage_Load);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtUsrId;
        private System.Windows.Forms.Label 公司编号;
        private System.Windows.Forms.Label 角色编码;
        private System.Windows.Forms.Label 角色名称;
        private System.Windows.Forms.TextBox txtZt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtPwd1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLrUsr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCTime;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 可访问公司;
        private System.Windows.Forms.DataGridViewTextBoxColumn 可访问角色;
        private System.Windows.Forms.DataGridViewTextBoxColumn 用户;
    }
}