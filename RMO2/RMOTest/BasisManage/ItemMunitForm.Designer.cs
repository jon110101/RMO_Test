﻿namespace RMO.BasisManage
{
    partial class ItemMunitForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.P_Itm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemUnit_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exc_Rto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Default_Id = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(617, 64);
            this.groupBox1.TabIndex = 3;
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
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.P_Itm,
            this.Item_Id,
            this.Company_Id,
            this.ItemUnit_Id,
            this.Exc_Rto,
            this.Default_Id});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(617, 304);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // P_Itm
            // 
            this.P_Itm.DataPropertyName = "P_Itm";
            this.P_Itm.HeaderText = "序号";
            this.P_Itm.Name = "P_Itm";
            this.P_Itm.Width = 80;
            // 
            // Item_Id
            // 
            this.Item_Id.DataPropertyName = "Item_Id";
            this.Item_Id.HeaderText = "物料";
            this.Item_Id.Name = "Item_Id";
            this.Item_Id.Visible = false;
            // 
            // Company_Id
            // 
            this.Company_Id.DataPropertyName = "Company_Id";
            this.Company_Id.HeaderText = "公司";
            this.Company_Id.Name = "Company_Id";
            this.Company_Id.Visible = false;
            this.Company_Id.Width = 150;
            // 
            // ItemUnit_Id
            // 
            this.ItemUnit_Id.DataPropertyName = "ItemUnit_Id";
            this.ItemUnit_Id.HeaderText = "物料单位";
            this.ItemUnit_Id.Name = "ItemUnit_Id";
            // 
            // Exc_Rto
            // 
            this.Exc_Rto.DataPropertyName = "Exc_Rto";
            this.Exc_Rto.HeaderText = "换算比率";
            this.Exc_Rto.Name = "Exc_Rto";
            // 
            // Default_Id
            // 
            this.Default_Id.DataPropertyName = "Default_Id";
            this.Default_Id.FalseValue = "F";
            this.Default_Id.HeaderText = "缺省单位标识";
            this.Default_Id.Name = "Default_Id";
            this.Default_Id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Default_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Default_Id.TrueValue = "T";
            this.Default_Id.Width = 150;
            // 
            // ItemMunitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 368);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemMunitForm";
            this.Text = "ItemUnitForm";
            this.Load += new System.EventHandler(this.ItemMunitForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_Itm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemUnit_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exc_Rto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Default_Id;
    }
}