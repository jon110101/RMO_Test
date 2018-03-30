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
    public partial class EmployeeManage : Form
    {
        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }
        public EmployeeManage()
        {
            InitializeComponent();
        }

        private string _Company_Id = "";
        public string Company_Id
        {
            set { _Company_Id = value; }
            get { return _Company_Id; }
        }


        private string _Employee_Id = "";
        public string Employee_Id
        {
            set { _Employee_Id = value; }
            get { return _Employee_Id; }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNo.Text))
            {
                MessageBox.Show("员工编号不能为空！");
                return;
            }

            if (_Edit == "ADD")
            {
                string _where = "and Employee.Company_Id='" + LoginInfo._Usr_Company + "' And isnull(Employee_Id,'')='" + this.txtNo.Text + "'";
                if (!CommomHelper.Exists("Employee", _where))
                {
                    if (AddEmployee())
                    {
                        this.DialogResult = DialogResult.Yes;
                    }
                }
                else
                {
                    MessageBox.Show("该员工已存在！");
                    return;
                }
            }
            else if (_Edit == "UPD")
            {
                if (UpdateEmployee())
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddEmployee()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Employee(");
            strSql.Append("Company_Id,Employee_Id,Desc_01,Level_Id,Is_Lowest,Sort_Order,Status_Id,Status_Id_BC,Remark,Company__Id,Role__Id,Usr__Id,Create__Date,Department_Id,Usr_Id,ProductArea_Id,Email_id)");
            strSql.Append(" values (");
            strSql.Append("@Company_Id,@Employee_Id,@Desc_01,@Level_Id,@Is_Lowest,@Sort_Order,@Status_Id,@Status_Id_BC,@Remark,@Company__Id,@Role__Id,@Usr__Id,@Create__Date,@Department_Id,@Usr_Id,@ProductArea_Id,@Email_id)");
            SqlParameter[] parameters = {
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Employee_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,200),
					new SqlParameter("@Level_Id", SqlDbType.Int,4),
					new SqlParameter("@Is_Lowest", SqlDbType.NVarChar,1),
					new SqlParameter("@Sort_Order", SqlDbType.NVarChar,500),
					new SqlParameter("@Status_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Status_Id_BC", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@Company__Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Role__Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Usr__Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Create__Date", SqlDbType.DateTime),
					new SqlParameter("@Department_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Usr_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductArea_Id", SqlDbType.NVarChar,50),
                    new SqlParameter("@Email_id", SqlDbType.NVarChar,50)};
            parameters[0].Value = LoginInfo._Usr_Company;
            parameters[1].Value = this.txtNo.Text;
            parameters[2].Value = this.txtName.Text;
            parameters[3].Value = 1;
            parameters[4].Value = "T";
            parameters[5].Value = "";
            parameters[6].Value = "";
            parameters[7].Value = "";
            parameters[8].Value = "";
            parameters[9].Value = LoginInfo._Usr_Company;
            parameters[10].Value = LoginInfo._Usr_Role;
            parameters[11].Value = LoginInfo._Usr_id;
            parameters[12].Value = System.DateTime.Now.ToString();
            parameters[13].Value = string.IsNullOrEmpty(this.textBoxContainButton3.ID) ? "" : this.textBoxContainButton3.ID;
            parameters[14].Value = string.IsNullOrEmpty(this.textBoxContainButton1.ID) ? "" : this.textBoxContainButton1.ID;
            parameters[15].Value = txtArea.Text;
            parameters[16].Value = this.txtEmail.Text;
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
        /// 更新一条数据
        /// </summary>
        public bool UpdateEmployee()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Employee set ");
            strSql.Append("Desc_01=@Desc_01,");
            strSql.Append("Last_Modify_Role_Id=@Last_Modify_Role_Id,");
            strSql.Append("Last_Modify_Usr_Id=@Last_Modify_Usr_Id,");
            strSql.Append("Last_Modify_Date=@Last_Modify_Date,");
            strSql.Append("Department_Id=@Department_Id,");
            strSql.Append("Usr_Id=@Usr_Id,");
            strSql.Append("ProductArea_Id=@ProductArea_Id,");
            strSql.Append("Email_id=@Email_id");
            strSql.Append(" where Company_Id=@Company_Id and Employee_Id=@Employee_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,200),
					new SqlParameter("@Last_Modify_Role_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Usr_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Date", SqlDbType.DateTime),
					new SqlParameter("@Department_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Usr_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductArea_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Employee_Id", SqlDbType.NVarChar,50),
                    new SqlParameter("@Email_id", SqlDbType.NVarChar,50)};
            parameters[0].Value = this.txtName.Text;
            parameters[1].Value = LoginInfo._Usr_Role;
            parameters[2].Value = LoginInfo._Usr_id;
            parameters[3].Value = System.DateTime.Now.ToString();
            parameters[4].Value = string.IsNullOrEmpty(this.textBoxContainButton3.ID) ? "" : this.textBoxContainButton3.ID;
            parameters[5].Value = string.IsNullOrEmpty(this.textBoxContainButton1.ID) ? "" : this.textBoxContainButton1.ID;
            parameters[6].Value = this.txtArea.Text;
            parameters[7].Value = LoginInfo._Usr_Company;
            parameters[8].Value = this.txtNo.Text;
            parameters[9].Value = this.txtEmail.Text;
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

        private void EmployeeManage_Load(object sender, EventArgs e)
        {
            this.txtLrUsr.Text = LoginInfo._Usr_id;
            this.txtCtTime.Text = System.DateTime.Now.ToString();
            if (_Edit == "ADD")
            {
                this.Text = "员工--新增";
            }
            else if (_Edit == "UPD")
            {
                this.Text = "员工--修改";
                this.txtNo.Text = _Employee_Id;
                this.txtNo.ReadOnly = true;
                DataTable _dtEmp = GetData(_Company_Id, this.txtNo.Text);
                if (_dtEmp != null && _dtEmp.Rows.Count > 0)
                {
                    this.txtNo.Text = _Employee_Id;
                    this.txtName.Text = _dtEmp.Rows[0]["Desc_01"].ToString();
                    this.textBoxContainButton3.Text = _dtEmp.Rows[0]["Department_Id"].ToString();
                    this.txtArea.Text = _dtEmp.Rows[0]["ProductArea_Id"].ToString();
                    this.textBoxContainButton1.Text = _dtEmp.Rows[0]["Usr_Id"].ToString();
                    this.txtLrUsr.Text = _dtEmp.Rows[0]["Usr__Id"].ToString();
                    this.txtCtTime.Text = _dtEmp.Rows[0]["Create__Date"].ToString();
                    this.txtEmail.Text = _dtEmp.Rows[0]["Email_Id"].ToString();
                }
            }
            this.textBoxContainButton3.ButtonSelectClick += textBoxContainButton1_Click; //部门
            this.textBoxContainButton1.ButtonSelectClick += textBoxContainButton2_Click; //用户
            this.textBoxContainButton1.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton1.TextLeave += textBoxContainButton1_TextLeave;
            this.textBoxContainButton3.TextEnter += textBoxContainButton3_TextEnter;
            this.textBoxContainButton3.TextLeave += textBoxContainButton3_TextLeave;
        }

        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=Department_Id,Desc_01=Desc_01 ";
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

        private void textBoxContainButton2_Click(object sender, EventArgs e)
        {
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
            _txt.ToFormatStringEnter("Department", "Department_Id", e);
        }

        private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("Department", "Department_Id", e);
        }

        private void textBoxContainButton3_TextEnter(object sender, EventArgs e)
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

        private void textBoxContainButton3_TextLeave(object sender, EventArgs e)
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


        private DataTable GetData(string _company_id, string _employee_Id)
        {
            string _sql = "select * from Employee where Company_Id=@Company_Id and  Employee_Id=@Employee_Id";
            SqlParameter[] paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@Company_Id", SqlDbType.VarChar, 50);
            paras[0].Value = _company_id;
            paras[1] = new SqlParameter("@Employee_Id", SqlDbType.VarChar, 50);
            paras[1].Value = _employee_Id;
            DataTable dt = SqlHelper.ExecuteDataTable(_sql, paras);
            return dt;
        }
    }
}
