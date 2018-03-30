namespace RMOTest
{
    partial class RoleManage
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
            this.公司编号 = new System.Windows.Forms.Label();
            this.角色编码 = new System.Windows.Forms.Label();
            this.角色名称 = new System.Windows.Forms.Label();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLrUsr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCtTime = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtRoleID = new System.Windows.Forms.TextBox();
            this.textBoxContainButton1 = new RMOTest.TextBoxContainButton();
            this.textBoxContainButton3 = new RMOTest.TextBoxContainButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(794, 143);
            this.panel1.TabIndex = 1;
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
            this.panel2.Size = new System.Drawing.Size(835, 82);
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
            this.tableLayoutPanel1.Controls.Add(this.公司编号, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.角色编码, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.角色名称, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtRoleName, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLrUsr, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCtTime, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtRoleID, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(708, 79);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // 公司编号
            // 
            this.公司编号.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.公司编号.AutoSize = true;
            this.公司编号.Location = new System.Drawing.Point(3, 13);
            this.公司编号.Name = "公司编号";
            this.公司编号.Size = new System.Drawing.Size(53, 12);
            this.公司编号.TabIndex = 0;
            this.公司编号.Text = "公司编码";
            // 
            // 角色编码
            // 
            this.角色编码.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.角色编码.AutoSize = true;
            this.角色编码.Location = new System.Drawing.Point(232, 13);
            this.角色编码.Name = "角色编码";
            this.角色编码.Size = new System.Drawing.Size(53, 12);
            this.角色编码.TabIndex = 1;
            this.角色编码.Text = "角色编码";
            // 
            // 角色名称
            // 
            this.角色名称.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.角色名称.AutoSize = true;
            this.角色名称.Location = new System.Drawing.Point(464, 13);
            this.角色名称.Name = "角色名称";
            this.角色名称.Size = new System.Drawing.Size(53, 12);
            this.角色名称.TabIndex = 2;
            this.角色名称.Text = "角色名称";
            // 
            // txtRoleName
            // 
            this.txtRoleName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtRoleName.Location = new System.Drawing.Point(523, 8);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(147, 21);
            this.txtRoleName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "上级角色";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "录入用户";
            // 
            // txtLrUsr
            // 
            this.txtLrUsr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtLrUsr.Location = new System.Drawing.Point(291, 46);
            this.txtLrUsr.Name = "txtLrUsr";
            this.txtLrUsr.ReadOnly = true;
            this.txtLrUsr.Size = new System.Drawing.Size(147, 21);
            this.txtLrUsr.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(464, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "录入时间";
            // 
            // txtCtTime
            // 
            this.txtCtTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCtTime.Location = new System.Drawing.Point(523, 46);
            this.txtCtTime.Name = "txtCtTime";
            this.txtCtTime.ReadOnly = true;
            this.txtCtTime.Size = new System.Drawing.Size(147, 21);
            this.txtCtTime.TabIndex = 16;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(190, 391);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.treeView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(190, 391);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 143);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(794, 391);
            this.panel4.TabIndex = 3;
            // 
            // txtRoleID
            // 
            this.txtRoleID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtRoleID.Location = new System.Drawing.Point(291, 8);
            this.txtRoleID.Name = "txtRoleID";
            this.txtRoleID.Size = new System.Drawing.Size(147, 21);
            this.txtRoleID.TabIndex = 17;
            // 
            // textBoxContainButton1
            // 
            this.textBoxContainButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton1.Location = new System.Drawing.Point(59, 5);
            this.textBoxContainButton1.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton1.Name = "textBoxContainButton1";
            this.textBoxContainButton1.ReadOnly = false;
            this.textBoxContainButton1.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton1.TabIndex = 3;
            // 
            // textBoxContainButton3
            // 
            this.textBoxContainButton3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton3.Location = new System.Drawing.Point(59, 43);
            this.textBoxContainButton3.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton3.Name = "textBoxContainButton3";
            this.textBoxContainButton3.ReadOnly = false;
            this.textBoxContainButton3.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton3.TabIndex = 12;
            // 
            // RoleManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 534);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "RoleManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角色";
            this.Load += new System.EventHandler(this.RoleManage_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
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
        private System.Windows.Forms.Label 角色名称;
        private System.Windows.Forms.Label 公司编号;
        private System.Windows.Forms.Label 角色编码;
        private TextBoxContainButton textBoxContainButton1;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label label1;
        private TextBoxContainButton textBoxContainButton3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLrUsr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCtTime;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtRoleID;
    }
}