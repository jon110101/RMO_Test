using RMO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMO.BasisManage
{
    public partial class EmployeeForm : UserControl
    {
        private SubForm _ownerFrom;
        public EmployeeForm(SubForm ownerForm)
        {
            InitializeComponent();
            this._ownerFrom = ownerForm;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string Company_Id, string Employee_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Employee ");
            strSql.Append(" where Company_Id=@Company_Id and Employee_Id=@Employee_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Employee_Id", SqlDbType.NVarChar,50)			};
            parameters[0].Value = Company_Id;
            parameters[1].Value = Employee_Id;

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


        /// <summary>
        /// 查询
        /// </summary>
        public void  QueryData(string _where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ROW_NUMBER() over (order by getdate()) as  Itm,Company_Id,Employee_Id,Desc_01,Remark,Usr__Id,Create__Date,ProductArea_Id from Employee ");
            strSql.Append(_where);
            DataTable  dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            if (dt!=null)
            {
                dt.Columns["ITM"].AutoIncrement = true;
                dt.Columns["ITM"].AutoIncrementSeed = 1;
                dt.Columns["ITM"].AutoIncrementStep = 1;
                this.dataGridView1.DataSource = dt;
                this.dataGridView1.AllowUserToAddRows = false;
            }
           
        }


        private void BtnQuery_Click(object sender, EventArgs e)
        {
            StringBuilder _NotNullWhere = new StringBuilder();
            _NotNullWhere.Append("Where 1=1 and Company_Id='" + LoginInfo._Usr_Company + "'");
            if (!string.IsNullOrEmpty(this.textBoxContainButton1.ID) && !string.IsNullOrEmpty(this.textBoxContainButton2.ID))
            {
                _NotNullWhere.Append(string.Format("and Employee_Id between '{0}'  and '{1}'", this.textBoxContainButton1.ID, this.textBoxContainButton2.ID));
            }
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                _NotNullWhere.Append(string.Format("and Desc_01 like '%{0}%'", this.txtName.Text));
            }
            if (!string.IsNullOrEmpty(this.textBoxContainButton3.ID) && !string.IsNullOrEmpty(this.textBoxContainButton4.ID))
            {
                _NotNullWhere.Append(string.Format("and Department_Id between '{0}'  and '{1}'", this.textBoxContainButton3.ID, this.textBoxContainButton4.ID));
            }
            if (!string.IsNullOrEmpty(this.textBoxContainButton5.ID) && !string.IsNullOrEmpty(this.textBoxContainButton6.ID))
            {
                _NotNullWhere.Append(string.Format("and Usr_Id between '{0}'  and '{1}'", this.textBoxContainButton5.ID, this.textBoxContainButton6.ID));
            }
            QueryData(_NotNullWhere.ToString());
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            EmployeeManage  _Manage = new EmployeeManage();
            _Manage.Edit = "ADD";
            if (_Manage.ShowDialog() != DialogResult.OK)
            {
                string _where = "Where 1=1 and Company_Id='" + LoginInfo._Usr_Company + "'";
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
                    string _Employee_Id = "";
                    DataGridViewRow _dr = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index];
                    if (_dr != null)
                    {
                        _Company_Id = string.IsNullOrEmpty(_dr.Cells["Company_Id"].Value.ToString()) ? "" : (_dr.Cells["Company_Id"].Value.ToString()).ToString();
                        _Employee_Id = string.IsNullOrEmpty((_dr.Cells["Employee_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["Employee_Id"].Value.ToString()).ToString();
                    }
                    EmployeeManage _Manage = new EmployeeManage();
                    _Manage.Edit = "UPD";
                    _Manage.Company_Id = _Company_Id;
                    _Manage.Employee_Id = _Employee_Id;
                    if (_Manage.ShowDialog() != DialogResult.OK)
                    {
                        string _where = "Where 1=1 and Company_Id='" + LoginInfo._Usr_Company + "'";
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
                        string _Employee_Id = string.IsNullOrEmpty((_dr.Cells["Employee_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["Employee_Id"].Value.ToString()).ToString();
                        try
                        {
                            bool _delOk = Delete(_Company_Id, _Employee_Id);
                            if (_delOk)
                            {
                                string _where = "Where 1=1 and Company_Id='" + LoginInfo._Usr_Company + "'";
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
            _ownerFrom.CloseThisFrom("Employee");
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //员工编码
            this.textBoxContainButton1.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton2.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton1.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton1.TextLeave += textBoxContainButton1_TextLeave;
            this.textBoxContainButton2.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton2.TextLeave += textBoxContainButton1_TextLeave;


            //部门编码
            this.textBoxContainButton3.ButtonSelectClick += textBoxContainButton2_Click;
            this.textBoxContainButton4.ButtonSelectClick += textBoxContainButton2_Click;
            this.textBoxContainButton3.TextEnter += textBoxContainButton3_TextEnter;
            this.textBoxContainButton3.TextLeave += textBoxContainButton3_TextLeave;
            this.textBoxContainButton4.TextEnter += textBoxContainButton3_TextEnter;
            this.textBoxContainButton4.TextLeave += textBoxContainButton3_TextLeave;

            //角色编码
            this.textBoxContainButton5.ButtonSelectClick += textBoxContainButton3_Click;
            this.textBoxContainButton6.ButtonSelectClick += textBoxContainButton3_Click;
            this.textBoxContainButton5.TextEnter += textBoxContainButton5_TextEnter;
            this.textBoxContainButton5.TextLeave += textBoxContainButton5_TextLeave;
            this.textBoxContainButton6.TextEnter += textBoxContainButton5_TextEnter;
            this.textBoxContainButton6.TextLeave += textBoxContainButton5_TextLeave;

        }

        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=Employee_ID,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("Employee", _columns, "");
            }
            else
            {
                string _where = "and Employee.Company_Id='" + LoginInfo._Usr_Company + "'";
                _ht = CommomHelper.GetQuery1("Employee", _columns, _where);
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

        private void textBoxContainButton2_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=Department_ID,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("Department", _columns, "");
            }
            else
            {
                string _where = "and Department.Company_Id='" + LoginInfo._Usr_Company + "'";
                _ht = CommomHelper.GetQuery1("Department", _columns, _where);
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

        private void textBoxContainButton3_Click(object sender, EventArgs e)
        {
            //TextBoxContainButton _txt = (TextBoxContainButton)sender;
            //if (LoginInfo._ZT_Admin_Id == "Z")
            //{
            //    string _columns = " ID=Role_ID,Desc_01=Desc_01 ";
            //    _txt.Text = CommomHelper.GetQuery("Role", _columns, "");
            //}
            //else
            //{
            //    string _columns = " ID=Role_ID,Desc_01=Role_ID ";
            //    string _where = "and UsrRole.Usr_id='" + LoginInfo._Usr_id + "'";
            //    _txt.Text = CommomHelper.GetQuery("UsrRole", _columns, _where);
            //}
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                string _columns = " ID=Usr_ID,Desc_01=Name ";
                _ht = CommomHelper.GetQuery1("Usr1", _columns, "");
            }
            else
            {
                string _columns = " ID=Usr_ID,Desc_01=Usr_ID ";
                string _where = "and UsrRole.Usr_id='" + LoginInfo._Usr_id + "' and UsrRole.Company_Id='" + LoginInfo._Usr_Company + "' ";
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


        private void textBoxContainButton1_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("Employee", "Employee_ID", e);
        }

        private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("Employee", "Employee_ID", e);
        }

        private void textBoxContainButton3_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("Department", "Department_ID", e);
        }

        private void textBoxContainButton3_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("Department", "Department_ID", e);
        }

        private void textBoxContainButton5_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _txt.ToFormatStringEnter("Usr1", "Usr_ID", e);
            }
            else
            {
                _txt.ToFormatStringEnter("UsrRole", "Usr_ID", e);
            }
        }
           
        private void textBoxContainButton5_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _txt.ToFormatStringLeave("Usr1", "Usr_ID", e);
            }
            else
            {
                _txt.ToFormatStringLeave("UsrRole", "Usr_ID", e);
            }
        }
    }
}
