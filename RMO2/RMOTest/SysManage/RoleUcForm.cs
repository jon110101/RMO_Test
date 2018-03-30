using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMO
{
    public partial class RoleUcForm : UserControl
    {
        private SubForm _ownerFrom;
        public RoleUcForm(SubForm ownerForm)
        {
            InitializeComponent();
            this._ownerFrom = ownerForm;
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            StringBuilder _where = new StringBuilder();
            _where.Append("Where 1=1 ");
            if (LoginInfo._ZT_Admin_Id != "Z")
            {
                _where.Append("and Company_Id='" + LoginInfo._Usr_Company + "'");
            }
            if (!string.IsNullOrEmpty(this.textBoxContainButton1.ID) && !string.IsNullOrEmpty(this.textBoxContainButton2.ID))
            {
                _where.Append(string.Format("and Company_Id between '{0}'  and '{1}'", this.textBoxContainButton1.ID, this.textBoxContainButton2.ID));
            }
            if (!string.IsNullOrEmpty(this.textBoxContainButton3.ID) && !string.IsNullOrEmpty(this.textBoxContainButton4.ID))
            {
                _where.Append(string.Format("and Role_Id between '{0}'  and '{1}'", this.textBoxContainButton3.ID, this.textBoxContainButton4.ID));
            }
            if (!string.IsNullOrEmpty(txtRoleName.Text))
            {
                _where.Append(string.Format("and Desc_01 like '%{0}%'", this.txtRoleName.Text));
            }
            string sqlStr = "Select ROW_NUMBER() over (order by getdate()) as P_Itm,Company_Id,Role_Id,Desc_01,Parent_Role_Id,Remark,Usr__Id,Create__Date From Role ";
            sqlStr += _where.ToString();
            DataTable dt = SqlHelper.ExecuteDataTable(sqlStr);
            dt.Columns["P_Itm"].AutoIncrement = true;
            dt.Columns["P_Itm"].AutoIncrementSeed = 1;
            dt.Columns["P_Itm"].AutoIncrementStep = 1;
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.AllowUserToAddRows = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            RoleManage _roleMge = new RoleManage();
            _roleMge.Edit = "ADD";
            if(_roleMge.ShowDialog() !=DialogResult.OK)
            {
                ResetView();
            }
           
        }

        private void BtnUpd_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string _Company_Id = "";
                    string _Role_Id = "";
                    DataGridViewRow _dr = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index];
                    if (_dr != null)
                    {
                        _Company_Id = string.IsNullOrEmpty(_dr.Cells["Company_Id"].Value.ToString()) ? "" : (_dr.Cells["Company_Id"].Value.ToString()).ToString();
                        _Role_Id = string.IsNullOrEmpty((_dr.Cells["Role_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["Role_Id"].Value.ToString()).ToString();
                    }
                    RoleManage _roleMge = new RoleManage();
                    _roleMge.Edit = "UPD";
                    _roleMge.Company_Id = _Company_Id;
                    _roleMge.Role_Id = _Role_Id;
                    if (_roleMge.ShowDialog() != DialogResult.OK)
                    {
                        ResetView();
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
                        string _Role_Id = string.IsNullOrEmpty((_dr.Cells["Role_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["Role_Id"].Value.ToString()).ToString();
                        string slqStr = string.Format("Delete Role Where Company_Id='{0}' and Role_Id='{1}'; Delete RolePgm1 Where Company_Id='{0}' and Role_Id='{1}'; ", _Company_Id, _Role_Id);
                        try
                        {
                            int i = SqlHelper.ExecuteQuery(slqStr);
                            if (i > 0)
                            {
                                ResetView();
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

        private void ResetView()
        {
            string sqlStr = "Select  ROW_NUMBER() over (order by getdate()) as P_Itm,Company_Id,Role_Id,Desc_01,Parent_Role_Id,Remark,Usr__Id,Create__Date From Role  Where 1=1";
            DataTable dt = SqlHelper.ExecuteDataTable(sqlStr);
            this.dataGridView1.DataSource = dt;
        }

        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                string _columns = " ID=Company_Id,Desc_01=Company_Name ";
                _ht = CommomHelper.GetQuery1("SysCompany1", _columns, "");
            }
            else
            {
                string _columns = " ID=Company_Id,Desc_01=Company_Id ";
                string _where = "and UsrCompany1.Usr_id='" + LoginInfo._Usr_id + "'";
                _ht = CommomHelper.GetQuery1("UsrCompany1", _columns, _where);
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
            _txt.ToFormatStringEnter("UsrCompany1", "Usr_id", e);
        }
        private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("UsrCompany1", "Usr_id", e);
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
        

        private void RoleUcForm_Load(object sender, EventArgs e)
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            _ownerFrom.CloseThisFrom("Role");
        }

       

    }
}
