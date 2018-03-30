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
    public partial class BusinessTypeManage : Form
    {
        public BusinessTypeManage()
        {
            InitializeComponent();
        }

        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }

        private string _BusinessType_Id = "";
        public string BusinessType_Id
        {
            set { _BusinessType_Id = value; }
            get { return _BusinessType_Id; }
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
                MessageBox.Show("销售类型编码不能为空！");
                return;
            }

            if (_Edit == "ADD")
            {
                string _where = "and BusinessType.Company_Id='" + LoginInfo._Usr_Company + "' And isnull(BusinessType_Id,'')='" + this.txtNo.Text + "'";
                if (!CommomHelper.Exists("BusinessType", _where))
                 {
                     if (AddBusinessType())
                     {
                         this.DialogResult = DialogResult.Yes;
                     }
                 }
                 else
                 {
                     MessageBox.Show("该业务类型已存在！");
                     return;
                 }

            }
            else if (_Edit == "UPD")
            {
                if (UpdateBusinessType())
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void BusinessTypeManage_Load(object sender, EventArgs e)
        {
            this.txtLrUsr.Text = LoginInfo._Usr_id;
            this.txtCtTime.Text = System.DateTime.Now.ToString();
            if (_Edit == "UPD")
            {
                this.txtNo.ReadOnly = true;
                DataTable _dtBusiness = GetData(_Company_Id, _BusinessType_Id);
                if (_dtBusiness != null && _dtBusiness.Rows.Count > 0)
                {
                    this.txtNo.Text = _BusinessType_Id;
                    this.txtName.Text = _dtBusiness.Rows[0]["Desc_01"].ToString();
                    this.txtRemark.Text = _dtBusiness.Rows[0]["Remark"].ToString();
                    this.txtLrUsr.Text = _dtBusiness.Rows[0]["Usr__Id"].ToString();
                    this.txtCtTime.Text = _dtBusiness.Rows[0]["Create__Date"].ToString();
                }
            }
        }

        private DataTable GetData(string _company_id, string _businessType_Id)
        {
            string _sql = "select * from BusinessType where Company_Id=@Company_Id and  BusinessType_Id=@BusinessType_Id";
            SqlParameter[] paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@Company_Id", SqlDbType.VarChar, 50);
            paras[0].Value = _company_id;
            paras[1] = new SqlParameter("@BusinessType_Id", SqlDbType.VarChar, 50);
            paras[1].Value = _businessType_Id;
            DataTable dt = SqlHelper.ExecuteDataTable(_sql, paras);
            return dt;
        }

        private bool AddBusinessType()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BusinessType(");
            strSql.Append("Company_Id,BusinessType_Id,Desc_01,Parent_Company_Id,Parent_BusinessType_Id,Level_Id,Sort_Number,Est_Itm,Is_Lowest,Status_Id,Status_Id_BC,Remark,Company__Id,Role__Id,Usr__Id,Create__Date)");
            strSql.Append(" values (");
            strSql.Append("@Company_Id,@BusinessType_Id,@Desc_01,@Parent_Company_Id,@Parent_BusinessType_Id,@Level_Id,@Sort_Number,@Est_Itm,@Is_Lowest,@Status_Id,@Status_Id_BC,@Remark,@Company__Id,@Role__Id,@Usr__Id,@Create__Date)");
            SqlParameter[] parameters = {
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinessType_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,100),
					new SqlParameter("@Parent_Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Parent_BusinessType_Id", SqlDbType.NVarChar,50),
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
            parameters[4].Value = "";
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
            parameters[15].Value = System.DateTime.Now.ToString();

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

        private bool UpdateBusinessType()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BusinessType set ");
            strSql.Append("Desc_01=@Desc_01,");
            strSql.Append("Remark=@Remark,");
            //strSql.Append("Last_Modify_ZT_Id=@Last_Modify_ZT_Id,");
            strSql.Append("Last_Modify_Company_Id=@Last_Modify_Company_Id,");
            strSql.Append("Last_Modify_Role_Id=@Last_Modify_Role_Id,");
            strSql.Append("Last_Modify_Usr_Id=@Last_Modify_Usr_Id,");
            strSql.Append("Last_Modify_Date=@Last_Modify_Date ");
            strSql.Append(" where Company_Id=@Company_Id and BusinessType_Id=@BusinessType_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,100),
					new SqlParameter("@Remark", SqlDbType.NText),
                    //new SqlParameter("@Last_Modify_ZT_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Role_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Usr_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Date", SqlDbType.DateTime),
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinessType_Id", SqlDbType.NVarChar,50)};
            parameters[0].Value = this.txtName.Text;
            parameters[1].Value = this.txtRemark.Text;
            //parameters[2].Value = "";
            parameters[2].Value = LoginInfo._Usr_Company;
            parameters[3].Value = LoginInfo._Usr_Role;
            parameters[4].Value = LoginInfo._Usr_id;
            parameters[5].Value = System.DateTime.Now.ToString();
            parameters[6].Value = LoginInfo._Usr_Company;
            parameters[7].Value = this.txtNo.Text;

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

    }
}
