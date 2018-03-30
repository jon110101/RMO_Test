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

namespace RMO.SysManage
{
    public partial class PgmTransferWarningSettingForm : UserControl
    {
         private SubForm _ownerFrom;
        public PgmTransferWarningSettingForm(SubForm ownerForm)
        {
            InitializeComponent();
            this._ownerFrom = ownerForm;
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            StringBuilder _NotNullWhere = new StringBuilder();
            _NotNullWhere.Append(" Where 1=1 and Company_Id='" + LoginInfo._Usr_Company + "'");
            if (!string.IsNullOrEmpty(this.textBoxContainButton1.ID) && !string.IsNullOrEmpty(this.textBoxContainButton2.ID))
            {
                _NotNullWhere.Append(string.Format("and Pgm_Id between '{0}'  and '{1}'", this.textBoxContainButton1.ID, this.textBoxContainButton2.ID));
            }
            if (!string.IsNullOrEmpty(this.textBoxContainButton3.ID) && !string.IsNullOrEmpty(this.textBoxContainButton4.ID))
            {
                _NotNullWhere.Append(string.Format("and Pgm_Usr_Id between '{0}'  and '{1}'", this.textBoxContainButton3.ID, this.textBoxContainButton4.ID));
            }
            QueryData(_NotNullWhere.ToString());
        }

        private void QueryData(string _where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ROW_NUMBER() over (order by getdate()) as  ITM,Pgm_Id,Pgm_Usr_Id,Usr__Id,Create__Date,Company_Id from PgmTransferWarningSetting ");
            strSql.Append(_where);
            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            dt.Columns["ITM"].AutoIncrement = true;
            dt.Columns["ITM"].AutoIncrementSeed = 1;
            dt.Columns["ITM"].AutoIncrementStep = 1;
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.AllowUserToAddRows = false;
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string Company_Id, string Shipping_Id, string Pgm_Usr_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PgmTransferWarningSetting ");
            strSql.Append(" where Company_Id=@Company_Id and Pgm_Id=@Pgm_Id and Pgm_Usr_Id=@Pgm_Usr_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Pgm_Id", SqlDbType.NVarChar,100),
					new SqlParameter("@Pgm_Usr_Id", SqlDbType.NVarChar,50)			};
            parameters[0].Value = Company_Id;
            parameters[1].Value = Pgm_Id;
            parameters[2].Value = Pgm_Usr_Id;

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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            PgmTransferWarningSettingManage _Manage = new PgmTransferWarningSettingManage();
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
                    string _Pgm_Id = "";
                    string _Pgm_Usr_Id = "";
                    DataGridViewRow _dr = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index];
                    if (_dr != null)
                    {
                        _Company_Id = string.IsNullOrEmpty(_dr.Cells["Company_Id"].Value.ToString()) ? "" : (_dr.Cells["Company_Id"].Value.ToString()).ToString();
                        _Pgm_Id = string.IsNullOrEmpty((_dr.Cells["Pgm_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["Pgm_Id"].Value.ToString()).ToString();
                        _Pgm_Usr_Id = string.IsNullOrEmpty((_dr.Cells["Pgm_Usr_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["Pgm_Usr_Id"].Value.ToString()).ToString();
                    }
                    PgmTransferWarningSettingManage _Manage = new PgmTransferWarningSettingManage();
                    _Manage.Edit = "UPD";
                    _Manage.PgmId = _Pgm_Id;
                    _Manage.CompanyId = _Company_Id;
                    _Manage.Pgm_UsrId = _Pgm_Usr_Id;
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
                        string _Pgm_Id = string.IsNullOrEmpty((_dr.Cells["Pgm_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["Pgm_Id"].Value.ToString()).ToString();
                        string _Pgm_Usr_Id = string.IsNullOrEmpty((_dr.Cells["Pgm_Usr_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["Pgm_Usr_Id"].Value.ToString()).ToString();
                        try
                        {
                            bool _delOk = Delete(_Company_Id, _Pgm_Id,_Pgm_Usr_Id);
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
            _ownerFrom.CloseThisFrom("PgmTransferWarningSetting");
        }

        private void PgmTransferWarningSettingForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.textBoxContainButton1.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton2.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton1.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton1.TextLeave += textBoxContainButton1_TextLeave;
            this.textBoxContainButton2.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton2.TextLeave += textBoxContainButton1_TextLeave;

            this.textBoxContainButton3.ButtonSelectClick += textBoxContainButton2_Click;
            this.textBoxContainButton4.ButtonSelectClick += textBoxContainButton2_Click;   
            this.textBoxContainButton3.TextEnter += textBoxContainButton2_TextEnter;
            this.textBoxContainButton3.TextLeave += textBoxContainButton2_TextLeave;
            this.textBoxContainButton4.TextEnter += textBoxContainButton2_TextEnter;
            this.textBoxContainButton4.TextLeave += textBoxContainButton2_TextLeave;
        }

        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=Pgm_ID,Desc_01=Pgm_ID ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("PgmTransferWarningSetting", _columns, "");
            }
            else
            {
                string _where = "and PgmTransferWarningSetting.Company_Id='" + LoginInfo._Usr_Company + "'";
                _ht = CommomHelper.GetQuery1("PgmTransferWarningSetting", _columns, _where);
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

        private void textBoxContainButton1_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("PgmTransferWarningSetting", "Pgm_ID", e);
        }
        private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("PgmTransferWarningSetting", "Pgm_ID", e);
        }


        private void textBoxContainButton2_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                string _columns = " ID=Role_ID,Desc_01=Desc_01 ";
                _ht = CommomHelper.GetQuery1("Role", _columns, "");
            }
            else
            {
                string _columns = " ID=Role_ID,Desc_01=Role_ID ";
                string _where = "and UsrRole.Usr_id='" + LoginInfo._Usr_id + "'";
                _ht = CommomHelper.GetQuery1("UsrRole", _columns, _where);
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

        private void textBoxContainButton2_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _txt.ToFormatStringEnter("Role", "Role_ID", e);
            }
            else
            {
                _txt.ToFormatStringEnter("UsrRole", "Role_ID", e);
            }
        }
        private void textBoxContainButton2_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _txt.ToFormatStringLeave("Role", "Role_ID", e);
            }
            else
            {
                _txt.ToFormatStringLeave("UsrRole", "Role_ID", e);
            }
        }

    }
}
