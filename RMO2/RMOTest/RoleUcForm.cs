using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RMOTest.DAL;

namespace RMOTest
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
            string _where = "Where 1=1";
            string _NotNullWhere = "";
            if (!string.IsNullOrEmpty(this.textBoxContainButton1.Text) && !string.IsNullOrEmpty(this.textBoxContainButton2.Text))
            {
                _NotNullWhere += string.Format("and Company_Id between '{0}'  and '{1}'", this.textBoxContainButton1.Text, this.textBoxContainButton2.Text);
            }
            if (!string.IsNullOrEmpty(this.textBoxContainButton3.Text) && !string.IsNullOrEmpty(this.textBoxContainButton4.Text))
            {
                _NotNullWhere += string.Format("and Role_Id between '{0}'  and '{1}'", this.textBoxContainButton3.Text, this.textBoxContainButton4.Text);
            }
            if (!string.IsNullOrEmpty(txtRoleName.Text))
            {
                _NotNullWhere += string.Format("and Desc_01 like '%{0}%'", this.txtRoleName.Text);
            }
            if (string.IsNullOrEmpty(_NotNullWhere) && LoginInfo._ZT_Admin_Id != "Z")
            {
                _where = "Where  isnull(Usr__Id,'')='" + LoginInfo._Usr_id + "'";
            }
            else
            {
                _where += _NotNullWhere;
            }
            string sqlStr = "Select ROW_NUMBER() over (order by getdate()) as P_Itm,Company_Id,Role_Id,Desc_01,Parent_Role_Id,Remark,Usr__Id,Create__Time From Role ";
            sqlStr += _where;
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
            string sqlStr = "Select  ROW_NUMBER() over (order by getdate()) as P_Itm,Company_Id,Role_Id,Desc_01,Parent_Role_Id,Remark,Usr__Id,Create__Time From Role  Where 1=1";
            DataTable dt = SqlHelper.ExecuteDataTable(sqlStr);
            this.dataGridView1.DataSource = dt;
        }

        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _txt.Text = CommomHelper.GetQuery("SysCompany", "");
            }
            else
            {
                string _where = "and UsrCompany1.Usr_id='" + LoginInfo._Usr_id + "'";
                _txt.Text = CommomHelper.GetQuery("UsrCompany1", _where);
            }
        }
        private void textBoxContainButton2_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _txt.Text = CommomHelper.GetQuery("Role", "");
            }
            else
            {
                string _where = "and UsrRole.Usr_id='" + LoginInfo._Usr_id + "'";
                _txt.Text = CommomHelper.GetQuery("UsrRole", _where);
            }
        }
        private void RoleUcForm_Load(object sender, EventArgs e)
        {
            this.textBoxContainButton1.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton2.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton3.ButtonSelectClick += textBoxContainButton2_Click;
            this.textBoxContainButton4.ButtonSelectClick += textBoxContainButton2_Click;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            _ownerFrom.CloseThisFrom("Role");
        }

       

    }
}
