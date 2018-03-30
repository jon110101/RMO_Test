namespace RMO.SysManage
{
    partial class PgmTransferWarningSettingForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ITM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pgm_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pgm_Usr_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usr__Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create__Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.部门编号 = new System.Windows.Forms.Label();
            this.textBoxContainButton1 = new RMO.TextBoxContainButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxContainButton2 = new RMO.TextBoxContainButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxContainButton3 = new RMO.TextBoxContainButton();
            this.textBoxContainButton4 = new RMO.TextBoxContainButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
            this.BtnUpd = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnQuery = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 520);
            this.panel1.TabIndex = 12;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ITM,
            this.Pgm_Id,
            this.Pgm_Usr_Id,
            this.Status_Id,
            this.Usr__Id,
            this.Create__Date});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(832, 420);
            this.dataGridView1.TabIndex = 1;
            // 
            // ITM
            // 
            this.ITM.DataPropertyName = "ITM";
            this.ITM.HeaderText = "序号";
            this.ITM.Name = "ITM";
            this.ITM.Width = 80;
            // 
            // Pgm_Id
            // 
            this.Pgm_Id.DataPropertyName = "Pgm_Id";
            this.Pgm_Id.HeaderText = "单据";
            this.Pgm_Id.Name = "Pgm_Id";
            this.Pgm_Id.Width = 150;
            // 
            // Pgm_Usr_Id
            // 
            this.Pgm_Usr_Id.DataPropertyName = "Pgm_Usr_Id";
            this.Pgm_Usr_Id.HeaderText = "录入人";
            this.Pgm_Usr_Id.Name = "Pgm_Usr_Id";
            // 
            // Status_Id
            // 
            this.Status_Id.DataPropertyName = "Usr__Id";
            this.Status_Id.HeaderText = "状态";
            this.Status_Id.Name = "Status_Id";
            this.Status_Id.Width = 150;
            // 
            // Usr__Id
            // 
            this.Usr__Id.DataPropertyName = "Usr__Id";
            this.Usr__Id.HeaderText = "创建用户";
            this.Usr__Id.Name = "Usr__Id";
            // 
            // Create__Date
            // 
            this.Create__Date.DataPropertyName = "Create__Date";
            this.Create__Date.HeaderText = "创建时间";
            this.Create__Date.Name = "Create__Date";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 100);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Controls.Add(this.部门编号, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton3, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContainButton4, 9, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 58);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(832, 42);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // 部门编号
            // 
            this.部门编号.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.部门编号.AutoSize = true;
            this.部门编号.Location = new System.Drawing.Point(3, 7);
            this.部门编号.Name = "部门编号";
            this.部门编号.Size = new System.Drawing.Size(29, 12);
            this.部门编号.TabIndex = 0;
            this.部门编号.Text = "单据";
            // 
            // textBoxContainButton1
            // 
            this.textBoxContainButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton1.Location = new System.Drawing.Point(35, 0);
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
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "----";
            // 
            // textBoxContainButton2
            // 
            this.textBoxContainButton2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton2.Location = new System.Drawing.Point(220, 0);
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
            this.label2.Location = new System.Drawing.Point(393, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "录入人";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(590, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "----";
            // 
            // textBoxContainButton3
            // 
            this.textBoxContainButton3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton3.Location = new System.Drawing.Point(437, 0);
            this.textBoxContainButton3.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton3.Name = "textBoxContainButton3";
            this.textBoxContainButton3.ReadOnly = false;
            this.textBoxContainButton3.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton3.TabIndex = 14;
            // 
            // textBoxContainButton4
            // 
            this.textBoxContainButton4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxContainButton4.Location = new System.Drawing.Point(622, 0);
            this.textBoxContainButton4.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxContainButton4.Name = "textBoxContainButton4";
            this.textBoxContainButton4.ReadOnly = false;
            this.textBoxContainButton4.Size = new System.Drawing.Size(150, 27);
            this.textBoxContainButton4.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(832, 58);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(417, 32);
            this.tableLayoutPanel2.TabIndex = 1;
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
            this.BtnAdd.Text = "新建";
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
            // PgmTransferWarningSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PgmTransferWarningSettingForm";
            this.Size = new System.Drawing.Size(832, 520);
            this.Load += new System.EventHandler(this.PgmTransferWarningSettingForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label 部门编号;
        private TextBoxContainButton textBoxContainButton1;
        private System.Windows.Forms.Label label1;
        private TextBoxContainButton textBoxContainButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private TextBoxContainButton textBoxContainButton3;
        private TextBoxContainButton textBoxContainButton4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pgm_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pgm_Usr_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usr__Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create__Date;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.Button BtnUpd;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnQuery;
    }
}
