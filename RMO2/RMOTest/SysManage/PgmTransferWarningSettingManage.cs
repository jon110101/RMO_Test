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

namespace RMO.SysManage
{
    public partial class PgmTransferWarningSettingManage : Form
    {
        public PgmTransferWarningSettingManage()
        {
            InitializeComponent();
        }

        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }

        private string _Pgm_Id = "";
        public string PgmId
        {
            set { _Pgm_Id = value; }
            get { return _Pgm_Id; }
        }

        private string _Pgm_Usr_Id = "";
        public string Pgm_UsrId
        {
            set { _Pgm_Usr_Id = value; }
            get { return _Pgm_Usr_Id; }
        }

        private string _Company_Id = "";
        public string CompanyId
        {
            set { _Company_Id = value; }
            get { return _Company_Id; }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxContainButton1.Text))
            {
                MessageBox.Show("单据不能为空！");
                return;
            }

            if (_Edit == "ADD")
            {
                if (AddPgmTransferWarningSetting())
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
            else if (_Edit == "UPD")
            {
                if (UpdPgmTransferWarningSetting())
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void PgmTransferWarningSettingManage_Load(object sender, EventArgs e)
        {
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.txtLrUsr.Text = LoginInfo._Usr_id;
            this.txtctime.Text = System.DateTime.Now.ToString();
            if (_Edit == "UPD")
            {

            }
            this.textBoxContainButton1.ButtonSelectClick += textBoxContainButton1_Click;
        }

        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            
        }

        private bool AddPgmTransferWarningSetting()
        {
            BindingSource _bdSource = new BindingSource();
            _bdSource = dataGridView1.DataSource as BindingSource;
            DataTable _dtBody = _bdSource.DataSource as DataTable;
            StringBuilder strSqlBody = new StringBuilder();
            if (_dtBody != null)
            {
                for (int i = 0; i < _dtBody.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(_dtBody.Rows[i]["Company_Id"].ToString()) && !string.IsNullOrEmpty(_dtBody.Rows[i]["Pgm_Id"].ToString()))
                    {
                        strSqlBody.Append("insert into PgmTransferWarningSetting(");
                        strSqlBody.Append("Company_Id,Pgm_Id,Pgm_Usr_Id,Itm,Remark,Status_Id,Company__Id,Role__Id,Usr__Id,Create__Date,Est_Itm,");
                        strSqlBody.Append("Warning_Company_Id,Warning_Employee_Id,Warning_Method_Id,Warning_Order");
                        strSqlBody.Append("VALUES(@Company_Id,Pgm_Id,Pgm_Usr_Id,'" + _dtBody.Rows[i]["Itm"].ToString() + "','" + _dtBody.Rows[i]["Remark"].ToString() + "',");
                        strSqlBody.Append("'" + _dtBody.Rows[i]["Status_Id"].ToString() + "','" + LoginInfo._Usr_Company + "','" + LoginInfo._Usr_Role + "',");
                        strSqlBody.Append("'" + LoginInfo._Usr_id + "','" + System.DateTime.Now.ToString() + "','" + 0 + "',");
                        strSqlBody.Append("'" + _dtBody.Rows[i]["Warning_Company_Id"].ToString() + "','" + _dtBody.Rows[i]["Warning_Employee_Id"].ToString() + "','" + _dtBody.Rows[i]["Warning_Method_Id"].ToString() + "','" + _dtBody.Rows[i]["Warning_Order"].ToString() + "',');");
                    }
                }
            }

            #region 表头
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PgmTransferWarningSetting(");
            strSql.Append("Company_Id,Pgm_Id,Pgm_Usr_Id,Remark,Company__Id,Role__Id,Usr__Id,Status_Id,Create__Date,Prior_Audit_Usr,Prior_Audit_Itm,Next_Audit_Usr,Next_Audit_Itm,Max_End_Audit_Itm,End_Audit_Usr,End_Audit_Date)");
            strSql.Append(" values (");
            strSql.Append("@Company_Id,@Pgm_Id,@Pgm_Usr_Id,@Remark,@Company__Id,@Role__Id,@Usr__Id,@Status_Id,@Create__Date,@Prior_Audit_Usr,@Prior_Audit_Itm,@Next_Audit_Usr,@Next_Audit_Itm,@Max_End_Audit_Itm,@End_Audit_Usr,@End_Audit_Date)");
            SqlParameter[] parameters = {
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Pgm_Id", SqlDbType.NVarChar,100),
					new SqlParameter("@Pgm_Usr_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@Company__Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Role__Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Usr__Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Status_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Create__Date", SqlDbType.DateTime),
					new SqlParameter("@Prior_Audit_Usr", SqlDbType.NVarChar,50),
					new SqlParameter("@Prior_Audit_Itm", SqlDbType.Int,4),
					new SqlParameter("@Next_Audit_Usr", SqlDbType.NVarChar,50),
					new SqlParameter("@Next_Audit_Itm", SqlDbType.Int,4),
					new SqlParameter("@Max_End_Audit_Itm", SqlDbType.Int,4),
					new SqlParameter("@End_Audit_Usr", SqlDbType.NVarChar,50),
					new SqlParameter("@End_Audit_Date", SqlDbType.DateTime)	};
            parameters[0].Value = _Company_Id;
            parameters[1].Value = _Pgm_Id;
            parameters[2].Value = _Pgm_Usr_Id;
            parameters[3].Value = this.txtRemark.Text;
            parameters[4].Value = LoginInfo._Usr_Company;
            parameters[5].Value = LoginInfo._Usr_Role;
            parameters[6].Value = LoginInfo._Usr_id;
            parameters[7].Value = this.txtStatus_Id.Text;
            parameters[8].Value = System.DateTime.Now;
            parameters[9].Value = "";
            parameters[10].Value = 0;
            parameters[11].Value = "";
            parameters[12].Value = 0;
            parameters[13].Value = 0;
            parameters[14].Value = "";
            parameters[15].Value = System.DateTime.Now;
            #endregion

            bool IsTrue = SqlHelper.ExecuteQueryTrans(strSqlBody + strSql.ToString(), parameters);
            return IsTrue;
        }

        private bool UpdPgmTransferWarningSetting()
        {
            BindingSource _bdSource = new BindingSource();
            _bdSource = dataGridView1.DataSource as BindingSource;
            DataTable _dtBody = _bdSource.DataSource as DataTable;
            StringBuilder strSqlBody = new StringBuilder();
            if (_dtBody != null)
            {
                for (int i = 0; i < _dtBody.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(_dtBody.Rows[i]["Company_Id"].ToString()) && !string.IsNullOrEmpty(_dtBody.Rows[i]["Pgm_Id"].ToString()))
                    {
                        strSqlBody.Append("Delete from  PgmTransferWarningSetting Company_Id=@Company_Id and  Pgm_Id=@Pgm_Id and Pgm_Usr_Id=@Pgm_Usr_Id;");
                        strSqlBody.Append("insert into PgmTransferWarningSetting(");
                        strSqlBody.Append("Company_Id,Pgm_Id,Pgm_Usr_Id,Itm,Remark,Status_Id,Company__Id,Role__Id,Usr__Id,Create__Date,Est_Itm,");
                        strSqlBody.Append("Warning_Company_Id,Warning_Employee_Id,Warning_Method_Id,Warning_Order");
                        strSqlBody.Append("VALUES(@Company_Id,Pgm_Id,Pgm_Usr_Id,'" + _dtBody.Rows[i]["Itm"].ToString() + "','" + _dtBody.Rows[i]["Remark"].ToString() + "',");
                        strSqlBody.Append("'" + _dtBody.Rows[i]["Status_Id"].ToString() + "','" + LoginInfo._Usr_Company + "','" + LoginInfo._Usr_Role + "',");
                        strSqlBody.Append("'" + LoginInfo._Usr_id + "','" + System.DateTime.Now.ToString() + "','" + 0 + "',");
                        strSqlBody.Append("'" + _dtBody.Rows[i]["Warning_Company_Id"].ToString() + "','" + _dtBody.Rows[i]["Warning_Employee_Id"].ToString() + "','" + _dtBody.Rows[i]["Warning_Method_Id"].ToString() + "','" + _dtBody.Rows[i]["Warning_Order"].ToString() + "',');");
                    }
                }
            }

            #region 表头
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PgmTransferWarningSetting set ");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Status_Id=@Status_Id,");
            strSql.Append("Last_Modify_Company_Id=@Last_Modify_Company_Id,");
            strSql.Append("Last_Modify_Role_Id=@Last_Modify_Role_Id,");
            strSql.Append("Last_Modify_Usr_Id=@Last_Modify_Usr_Id,");
            strSql.Append("Last_Modify_Date=@Last_Modify_Date");
            strSql.Append(" where Company_Id=@Company_Id and Pgm_Id=@Pgm_Id and Pgm_Usr_Id=@Pgm_Usr_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@Status_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Role_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Usr_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Date", SqlDbType.DateTime),
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Pgm_Id", SqlDbType.NVarChar,100),
					new SqlParameter("@Pgm_Usr_Id", SqlDbType.NVarChar,50)};
            parameters[0].Value = this.txtRemark.Text;
            parameters[1].Value = this.txtStatus_Id.Text;
            parameters[2].Value = LoginInfo._Usr_Company;
            parameters[3].Value = LoginInfo._Usr_Role;
            parameters[4].Value = LoginInfo._Usr_id;
            parameters[5].Value = System.DateTime.Now;
            parameters[6].Value = _Company_Id;
            parameters[7].Value = _Pgm_Id;
            parameters[8].Value = _Pgm_Usr_Id;
            #endregion
            bool IsTrue = SqlHelper.ExecuteQueryTrans(strSqlBody + strSql.ToString(), parameters);
            return IsTrue;
        }

    }
}
