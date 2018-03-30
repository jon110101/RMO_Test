using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RMO.BasisManage
{
    public partial class ItemUtForm : UserControl
    {
         private SubForm _ownerFrom;
         public ItemUtForm(SubForm ownerForm)
        {
            InitializeComponent();
            this._ownerFrom = ownerForm;
        }

         public bool Delete(string ItemUt_Id)
         {

             StringBuilder strSql = new StringBuilder();
             strSql.Append("delete from ItemUt ");
             strSql.Append(" where ItemUt_Id=@ItemUt_Id ");
             SqlParameter[] parameters = {
					new SqlParameter("@ItemUt_Id", SqlDbType.NVarChar,50)			};
             parameters[0].Value = ItemUt_Id;

             int rows = SqlHelper.ExecuteQuery(strSql.ToString(), parameters);
             if (rows > 0)
             {
                 return true;
             }
             else
             {
                 return false;
             }
         }

         private void QueryData(string _where)
         {
             StringBuilder strSql = new StringBuilder();
             strSql.Append("select top 10 ROW_NUMBER() over (order by getdate()) as  ITM,ItemUt_Id,Desc_01,Parent_ItemUt_Id,Remark,Usr__Id,Create__Date from ItemUt ");
             strSql.Append(_where);
             DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString());
             dt.Columns["ITM"].AutoIncrement = true;
             dt.Columns["ITM"].AutoIncrementSeed = 1;
             dt.Columns["ITM"].AutoIncrementStep = 1;
             this.dataGridView1.DataSource = dt;
             this.dataGridView1.AllowUserToAddRows = false;
         }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            StringBuilder _NotNullWhere = new StringBuilder();
            _NotNullWhere.Append("where 1=1 ");
            if (!string.IsNullOrEmpty(this.textBoxContainButton1.ID) && !string.IsNullOrEmpty(this.textBoxContainButton2.ID))
            {
                _NotNullWhere.Append(string.Format("and ItemUt_Id between '{0}'  and '{1}'", this.textBoxContainButton1.ID, this.textBoxContainButton2.ID));
            }
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                _NotNullWhere.Append(string.Format("and Desc_01 like '%{0}%'", this.txtName.Text));
            }
            QueryData(_NotNullWhere.ToString());
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ItemUtManage _Manage = new ItemUtManage();
            _Manage.Edit = "ADD";
            if (_Manage.ShowDialog() != DialogResult.OK)
            {
                QueryData("");
            }
        }

        private void BtnUpd_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string _ItemUt_Id = "";
                    DataGridViewRow _dr = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index];
                    if (_dr != null)
                    {
                        _ItemUt_Id = string.IsNullOrEmpty((_dr.Cells["ItemUt_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["ItemUt_Id"].Value.ToString()).ToString();
                    }
                    ItemUtManage _Manage = new ItemUtManage();
                    _Manage.Edit = "UPD";
                    _Manage.ItemUt_Id = _ItemUt_Id;
                    if (_Manage.ShowDialog() != DialogResult.OK)
                    {
                        QueryData("");
                    }
                }
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
        if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
             {
                 if (dataGridView1.CurrentRow != null)
                 {
                     DataGridViewRow _dr = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index];
                     if (_dr != null)
                     {
                         string _ItemUt_Id = string.IsNullOrEmpty((_dr.Cells["ItemUt_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["ItemUt_Id"].Value.ToString()).ToString();
                         try
                         {
                             bool _delOk = Delete(_ItemUt_Id);
                             if (_delOk)
                             {
                                 QueryData("");
                             }
                         }
                         catch (Exception ex)
                         {
                             MessageBox.Show(ex.ToString());
                         }
                     }
                 }
             }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            _ownerFrom.CloseThisFrom("ItemUt");
        }

        private void ItemUtForm_Load(object sender, EventArgs e)
        {
            this.textBoxContainButton1.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton2.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton1.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton1.TextLeave += textBoxContainButton1_TextLeave;
            this.textBoxContainButton2.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton2.TextLeave += textBoxContainButton1_TextLeave;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=ItemUt_ID,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            _ht = CommomHelper.GetQuery1("ItemUt", _columns, "");
            if (_ht != null)
            {
                if (_ht.ContainsKey("ID") && _ht.ContainsKey("DESC"))
                {
                    _txt.ID = _ht["ID"].ToString();
                    _txt.Desc = _ht["DESC"].ToString();
                    _txt.Text = _ht["DESC"].ToString();
                }
            }
        }

        private void textBoxContainButton1_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("ItemUt", "ItemUt_ID", e);
        }

        private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("ItemUt", "ItemUt_ID", e);
        }
    }
}
