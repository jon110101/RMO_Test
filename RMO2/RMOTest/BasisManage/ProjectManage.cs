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
    public partial class ProjectManage : Form
    {
        public ProjectManage()
        {
            InitializeComponent();
        }
        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }

        private string _Project_Id = "";
        public string Project_Id
        {
            set { _Project_Id = value; }
            get { return _Project_Id; }
        }

        private string _Company_Id = "";
        public string Company_Id
        {
            set { _Company_Id = value; }
            get { return _Company_Id; }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNo.Text))
            {
                MessageBox.Show("项目编码不能为空！");
                return;
            }

            if (_Edit == "ADD")
            {
                string _where = "and Project.Company_Id='" + LoginInfo._Usr_Company + "' And isnull(Project_Id,'')='" + this.txtNo.Text + "'";
                if (!CommomHelper.Exists("Project", _where))
                {
                    if (AddProject())
                    {
                        this.DialogResult = DialogResult.Yes;
                    }
                }
                else
                {
                    MessageBox.Show("该项目编码已存在！");
                    return;
                }
            }
            else if (_Edit == "UPD")
            {
                if (UpdateProject())
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
        }

        private bool AddProject()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Project(");
            strSql.Append("Company_Id,Project_Id,Desc_01,Parent_Company_Id,Parent_Project_Id,Level_Id,Sort_Number,Est_Itm,Is_Lowest,Status_Id,Status_Id_BC,Remark,Company__Id,Role__Id,Usr__Id,Create__Date)");
            strSql.Append(" values (");
            strSql.Append("@Company_Id,@Project_Id,@Desc_01,@Parent_Company_Id,@Parent_Project_Id,@Level_Id,@Sort_Number,@Est_Itm,@Is_Lowest,@Status_Id,@Status_Id_BC,@Remark,@Company__Id,@Role__Id,@Usr__Id,@Create__Date)");
            SqlParameter[] parameters = {
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Project_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,100),
					new SqlParameter("@Parent_Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Parent_Project_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Level_Id", SqlDbType.Int,4),
					new SqlParameter("@Sort_Number", SqlDbType.Decimal,13),
					new SqlParameter("@Est_Itm", SqlDbType.Int,4),
					new SqlParameter("@Is_Lowest", SqlDbType.NVarChar,1),
					new SqlParameter("@Status_Id", SqlDbType.NVarChar,5),
					new SqlParameter("@Status_Id_BC", SqlDbType.NVarChar,5),
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@Company__Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Role__Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Usr__Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Create__Date", SqlDbType.DateTime)};
            parameters[0].Value = LoginInfo._Usr_Company;
            parameters[1].Value = this.txtNo.Text;
            parameters[2].Value = this.txtName.Text;
            parameters[3].Value = "";
            parameters[4].Value = string.IsNullOrEmpty(this.textBoxContainButton3.ID) ? "" : this.textBoxContainButton3.ID;
            parameters[5].Value = 0;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            parameters[8].Value = "";
            parameters[9].Value = "";
            parameters[10].Value = "";
            parameters[11].Value = this.txtRemark.Text;
            parameters[12].Value = LoginInfo._Usr_Company;
            parameters[13].Value = LoginInfo._Usr_Role;
            parameters[14].Value = LoginInfo._Usr_id;
            parameters[15].Value = System.DateTime.Now;

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

        private bool UpdateProject()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Project set ");
            strSql.Append("Desc_01=@Desc_01,");
            strSql.Append("Parent_Company_Id=@Parent_Company_Id,");
            strSql.Append("Parent_Project_Id=@Parent_Project_Id,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Last_Modify_Company_Id=@Last_Modify_Company_Id,");
            strSql.Append("Last_Modify_Role_Id=@Last_Modify_Role_Id,");
            strSql.Append("Last_Modify_Usr_Id=@Last_Modify_Usr_Id,");
            strSql.Append("Last_Modify_Date=@Last_Modify_Date");
            strSql.Append(" where Company_Id=@Company_Id and Project_Id=@Project_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,100),
					new SqlParameter("@Parent_Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Parent_Project_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@Last_Modify_Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Role_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Usr_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Date", SqlDbType.DateTime),
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Project_Id", SqlDbType.NVarChar,50)};
            parameters[0].Value = this.txtName.Text;
            parameters[1].Value = "";
            parameters[2].Value = this.textBoxContainButton3.ID;
            parameters[3].Value = this.txtRemark.Text;
            parameters[4].Value = LoginInfo._Usr_Company;
            parameters[5].Value = LoginInfo._Usr_Role;
            parameters[6].Value = LoginInfo._Usr_id;
            parameters[7].Value = System.DateTime.Now;
            parameters[8].Value = _Company_Id;
            parameters[9].Value = _Project_Id;
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void ProjectManage_Load(object sender, EventArgs e)
        {
            this.txtLrUsr.Text = LoginInfo._Usr_id;
            this.txtCtTime.Text = System.DateTime.Now.ToString();
            if (_Edit == "ADD")
            {
                this.Text = "项目--新增";
            }
            else if (_Edit == "UPD")
            {
                this.Text = "项目--修改";
                this.txtNo.ReadOnly = true;
                DataTable _dtDep = GetData(_Company_Id, _Project_Id);
                if (_dtDep != null && _dtDep.Rows.Count > 0)
                {
                    this.txtNo.ReadOnly = true;
                    this.txtNo.Text = _dtDep.Rows[0]["Project_Id"].ToString();
                    this.txtName.Text = _dtDep.Rows[0]["Desc_01"].ToString();
                    this.textBoxContainButton3.Text = _dtDep.Rows[0]["Parent_Project_Id"].ToString();
                    this.txtRemark.Text = _dtDep.Rows[0]["Remark"].ToString();
                    this.txtLrUsr.Text = _dtDep.Rows[0]["Usr__Id"].ToString();
                    this.txtCtTime.Text = _dtDep.Rows[0]["Create__Date"].ToString();
                }
            }
            this.textBoxContainButton3.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton3.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton3.TextLeave += textBoxContainButton1_TextLeave;
        }

        private void textBoxContainButton1_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("Project", "Project_Id", e);
        }

        private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("Project", "Project_Id", e);
        }

        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=Project_Id,Desc_01=Desc_01 ";
            string _where = "";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _where = " And isnull(Project_Id,'')<>'" + this.txtNo.Text + "' ";

            }
            else
            {
                 _where = " and Project.Company_Id='" + LoginInfo._Usr_Company + "' And isnull(Project_Id,'')<>'" + this.txtNo.Text + "'";
            }
            _ht = CommomHelper.GetQuery1("Project", _columns, _where);
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


        private DataTable GetData(string _company_id, string _project_Id)
        {
            string _sql = "select * from Project where Company_Id=@Company_Id and  Project_Id=@Project_Id";
            SqlParameter[] paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@Company_Id", SqlDbType.VarChar, 50);
            paras[0].Value = _company_id;
            paras[1] = new SqlParameter("@Project_Id", SqlDbType.VarChar, 50);
            paras[1].Value = _project_Id;
            DataTable dt = SqlHelper.ExecuteDataTable(_sql, paras);
            return dt;
        }

    }
}
