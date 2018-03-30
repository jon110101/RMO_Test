using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMO.BasisManage
{
    public partial class CsvEmployeeForm : Form
    {
        public CsvEmployeeForm()
        {
            InitializeComponent();
        }

        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }

          private string _Company_Id = "";
        public string Src_Company_Id
        {
            set { _Company_Id = value; }
            get { return _Company_Id; }
        }
        private string _Csv_Id = "";
        public string Src_Csv_Id
        {
            set { _Csv_Id = value; }
            get { return _Csv_Id; }
        }
        public DataTable _dtCE;

        private void CsvEmployeeForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
            string _where="";
            if(_Edit=="ADD")
            {
                _where = "Where 1<>1 ";
            }
            else if (_Edit == "UPD")
            {
                _where = "where Company_Id='" + _Company_Id + "' and Csv_Id='" + _Csv_Id + "'";
            }
            DataSet _dsUpd = GetData(_where);
            if (_dsUpd != null)
            {
                DataTable _dtBody = _dsUpd.Tables[0];
                if (_dtBody.Rows.Count > 0)
                {
                    _dtBody.Columns["Itm"].AutoIncrement = true;
                    _dtBody.Columns["Itm"].AutoIncrementSeed = 1;
                    _dtBody.Columns["Itm"].AutoIncrementStep = 1;
                }
                BindingSource bindingSource1 = new BindingSource();
                bindingSource1.DataSource = _dtBody;
                this.dataGridView1.DataSource = bindingSource1;
            }
        }


        private DataSet GetData(string _where)
        {
            StringBuilder _sqlstr = new StringBuilder();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select  ROW_NUMBER() over (order by getdate()) as  Itm,* ");
            strSql.Append("  from CsvEmployee ");
            strSql.Append(_where);
            DataSet _ds = SqlHelper.ExecuteDataSet(strSql.ToString());
            return _ds;

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DataTable _dtnew = new DataTable();
            BindingSource _bdSource = new BindingSource();
            _bdSource = dataGridView1.DataSource as BindingSource;
            if (_bdSource != null)
            {

                _dtCE = _bdSource.DataSource as DataTable;
                this.DialogResult = DialogResult.Yes;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.Controls.Clear();//移除所有控件 
            if (e.ColumnIndex.Equals(this.dataGridView1.Columns["Employee_Id"].Index) 
                )
            {
                System.Windows.Forms.Button btn = new System.Windows.Forms.Button();//创建Buttonbtn 
                btn.Text = "...";//设置button文字 
                btn.Font = new System.Drawing.Font("Arial", 7);//设置文字格式 
                btn.Visible = true;//设置控件允许显示 

                btn.Width = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex,
                                e.RowIndex, true).Height;//获取单元格高并设置为btn的宽 
                btn.Height = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex,
                                e.RowIndex, true).Height;//获取单元格高并设置为btn的高 
                btn.Click += new EventHandler(btn_Click);//为btn添加单击事件 
                this.dataGridView1.Controls.Add(btn);//dataGridView1中添加控件btn 

                btn.Location = new System.Drawing.Point(((this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Right) -
                        (btn.Width)), this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Y);//设置btn显示位置 
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            int _ColumnIndex = dataGridView1.CurrentCell.ColumnIndex;
            int _RowIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridViewColumn _column = dataGridView1.Columns[_ColumnIndex];
            BindingSource _bdSource = new BindingSource();
            _bdSource = dataGridView1.DataSource as BindingSource;
            if (_column.DataPropertyName == "Employee_Id")
            {
                QueryForm _qyFrom = null;
                _qyFrom = new QueryForm("Employee", "");
                _qyFrom.StartPosition = FormStartPosition.Manual;
                _qyFrom.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                _qyFrom.TopMost = true;
                if (_qyFrom.ShowDialog() == DialogResult.Yes)
                {
                    this.dataGridView1.Rows[_RowIndex].Cells[_ColumnIndex].Value = _qyFrom.ID;
                    _bdSource.EndEdit();
                }
            }
        }
    }
}
