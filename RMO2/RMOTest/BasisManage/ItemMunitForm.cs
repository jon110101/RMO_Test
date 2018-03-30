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
    public partial class ItemMunitForm : Form
    {
        public ItemMunitForm()
        {
            InitializeComponent();
        }

        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }

        private string _ItemId = "";
        public string ItemId
        {
            set { _ItemId = value; }
            get { return _ItemId; }
        }

        private string _ItemUtId = "";
        public string ItemUtId
        {
            set { _ItemUtId = value; }
            get { return _ItemUtId; }
        }

        public DataTable _dtUnit = null;

        private void BtnOk_Click(object sender, EventArgs e)
        {
            BindingSource _bdSource = new BindingSource();
            _bdSource = dataGridView1.DataSource as BindingSource;
            _bdSource.EndEdit();
            _dtUnit = _bdSource.DataSource as DataTable;
            this.DialogResult = DialogResult.Yes;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void ItemMunitForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string _where = " 1=1  and ItemUnit_Id not in ('" + _ItemUtId + "') ";
            if (_Edit == "ADD")
            {
                _where += "and  1<>1";
            }
            else
            {
                _where += "and  1=1 and Item_Id='"+_ItemId+"'";
            }
            ReSetView(_where);
        }


        private  void  ReSetView(string _where)
        {
            string sqlStr = string.Format("Select  ROW_NUMBER() over (order by getdate()) as P_Itm,Company_Id,Item_Id,ItemUnit_Id,Exc_Rto, (case isnull(Default_Id,'') when  'T'  then  'T' else  'F' end) as Default_Id From ItemUnit  Where {0}",_where);
            DataTable dt = SqlHelper.ExecuteDataTable(sqlStr);
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = dt;
            this.dataGridView1.DataSource = bindingSource1; 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn _column = dataGridView1.Columns[e.ColumnIndex];
                BindingSource _bdSource = new BindingSource();
                _bdSource = dataGridView1.DataSource as BindingSource;
                if (_column.DataPropertyName == "ItemUnit_Id")
                {
                    string _columns = " ID=ItemUt_ID,Desc_01=Desc_01 ";
                    string _where = "and (Status_Id In ('130', '130')) and ItemUt_Id not in ('" + _ItemUtId + "')";
                     Dictionary<string, object> _ht = CommomHelper.GetQuery1("ItemUt", _columns, _where);
                     if (_ht != null)
                     {
                         if (_ht.ContainsKey("ID") && _ht.ContainsKey("DESC"))
                         {
                             this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _ht["ID"].ToString();
                             _bdSource.EndEdit();
                         }
                     }
                }
            }
        }


    }
}
