using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RMO;
using System.Data.SqlClient;

namespace RMO.BasisManage
{
    public partial class ShippingAddressForm : UserControl
    {
         private SubForm _ownerFrom;
         public ShippingAddressForm(SubForm ownerForm)
        {
            InitializeComponent();
            this._ownerFrom = ownerForm;
        }

         private void QueryData(string _where)
         {
             StringBuilder strSql = new StringBuilder();
             strSql.Append("select ROW_NUMBER() over (order by getdate()) as  Itm,Company_Id,ShippingAddress_Id,Desc_01,Parent_ShippingAddress_Id,Remark,Usr__Id,Create__Date from ShippingAddress ");
             strSql.Append(_where);
             DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString());
             dt.Columns["ITM"].AutoIncrement = true;
             dt.Columns["ITM"].AutoIncrementSeed = 1;
             dt.Columns["ITM"].AutoIncrementStep = 1;
             this.dataGridView1.DataSource = dt;
             this.dataGridView1.AllowUserToAddRows = false;
         }



         public bool Delete(string Company_Id, string Department_Id)
         {
             StringBuilder strSql = new StringBuilder();
             strSql.Append("delete from ShippingAddress ");
             strSql.Append(" where Company_Id=@Company_Id and ShippingAddress_Id=@ShippingAddress_Id ");
             SqlParameter[] parameters = {
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@ShippingAddress_Id", SqlDbType.NVarChar,50)			};
             parameters[0].Value = Company_Id;
             parameters[1].Value = Department_Id;

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


        private void BtnQuery_Click(object sender, EventArgs e)
        {
            StringBuilder _NotNullWhere = new StringBuilder();
            _NotNullWhere.Append(" Where 1=1 and Company_Id='" + LoginInfo._Usr_Company + "'");
            if (!string.IsNullOrEmpty(this.textBoxContainButton1.ID) && !string.IsNullOrEmpty(this.textBoxContainButton2.ID))
            {
                _NotNullWhere.Append(string.Format("and ShippingAddress_Id between '{0}'  and '{1}'", this.textBoxContainButton1.ID, this.textBoxContainButton2.ID));
            }
            if (!string.IsNullOrEmpty(txtDeptName.Text))
            {
                _NotNullWhere.Append(string.Format("and Desc_01 like '%{0}%'", this.txtDeptName.Text));
            }
            QueryData(_NotNullWhere.ToString());
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ShippingAddressManage _Manage = new ShippingAddressManage();
            _Manage.Edit = "ADD";
            if (_Manage.ShowDialog() != DialogResult.OK)
            {
                string _where = " Where 1=1 and Company_Id='" + LoginInfo._Usr_Company + "'";
                QueryData(_where);
            }
        }

        private void BtnUpd_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string _Company_Id = "";
                    string _ShippingAddress_Id = "";
                    DataGridViewRow _dr = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index];
                    if (_dr != null)
                    {
                        _Company_Id = string.IsNullOrEmpty(_dr.Cells["Company_Id"].Value.ToString()) ? "" : (_dr.Cells["Company_Id"].Value.ToString()).ToString();
                        _ShippingAddress_Id = string.IsNullOrEmpty((_dr.Cells["ShippingAddress_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["ShippingAddress_Id"].Value.ToString()).ToString();
                    }
                    ShippingAddressManage _Manage = new ShippingAddressManage();
                    _Manage.Edit = "UPD";
                    _Manage.ShippingAddress_Id = _ShippingAddress_Id;
                    _Manage.Company_Id = _Company_Id;
                    if (_Manage.ShowDialog() != DialogResult.OK)
                    {
                        string _where = " Where 1=1 and Company_Id='" + LoginInfo._Usr_Company + "'";
                        QueryData(_where);
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
                        string _Company_Id = string.IsNullOrEmpty(_dr.Cells["Company_Id"].Value.ToString()) ? "" : (_dr.Cells["Company_Id"].Value.ToString()).ToString();
                        string _ShippingAddress_Id = string.IsNullOrEmpty((_dr.Cells["ShippingAddress_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["Department_Id"].Value.ToString()).ToString();
                        try
                        {
                            bool _delOk = Delete(_Company_Id, _ShippingAddress_Id);
                            if (_delOk)
                            {
                                string _where = " Where 1=1 and Company_Id='" + LoginInfo._Usr_Company + "'";
                                QueryData(_where);
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
            _ownerFrom.CloseThisFrom("ShippingAddress");
        }

        private void ShippingAddressForm_Load(object sender, EventArgs e)
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

        private void textBoxContainButton1_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("ShippingAddress", "ShippingAddress_Id", e);
        }

        private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("ShippingAddress", "ShippingAddress_Id", e);
        }

        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=ShippingAddress_Id,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("ShippingAddress", _columns, "");
            }
            else
            {
                string _where = "and ShippingAddress.Company_Id='" + LoginInfo._Usr_Company + "' ";
                _ht = CommomHelper.GetQuery1("ShippingAddress", _columns, _where);
            }
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

    }
}
