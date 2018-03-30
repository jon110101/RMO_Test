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
    public partial class CurrencyManage : Form
    {
        public CurrencyManage()
        {
            InitializeComponent();
        }

        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }

        private string _Currency_Id = "";
        public string Currency_Id
        {
            set { _Currency_Id = value; }
            get { return _Currency_Id; }
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
                MessageBox.Show("币别编码不能为空！");
                return;
            }

            if (_Edit == "ADD")
            {
                string _where = "and Currency.Company_Id='" + LoginInfo._Usr_Company + "' And isnull(Currency_Id,'')='" + this.txtNo.Text + "'";
                if (!CommomHelper.Exists("Currency", _where))
                 {
                     if (AddCurency())
                     {
                         this.DialogResult = DialogResult.Yes;
                     }
                 }
                 else
                 {
                     MessageBox.Show("该币别已存在！");
                     return;
                 }
            }
            else if (_Edit == "UPD")
            {
                if (UpdateCurency())
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private bool AddCurency()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Currency(");
            strSql.Append("Company_Id,Currency_Id,Desc_01,Parent_Company_Id,Parent_Currency_Id,Level_Id,Sort_Number,Est_Itm,Is_Lowest,Status_Id,Status_Id_BC,Remark,Company__Id,Role__Id,Usr__Id,Create__Date,Exc_Rate)");
            strSql.Append(" values (");
            strSql.Append("@Company_Id,@Currency_Id,@Desc_01,@Parent_Company_Id,@Parent_Currency_Id,@Level_Id,@Sort_Number,@Est_Itm,@Is_Lowest,@Status_Id,@Status_Id_BC,@Remark,@Company__Id,@Role__Id,@Usr__Id,@Create__Date,@Exc_Rate)");
            SqlParameter[] parameters = {
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Currency_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,100),
					new SqlParameter("@Parent_Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Parent_Currency_Id", SqlDbType.NVarChar,50),
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
					new SqlParameter("@Create__Date", SqlDbType.DateTime),
					new SqlParameter("@Exc_Rate", SqlDbType.Decimal,13)};
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
            parameters[16].Value = string.IsNullOrEmpty(this.txtHl.Text)?0:Convert.ToDecimal(this.txtHl.Text);

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

        private bool UpdateCurency()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Currency set ");
            strSql.Append("Desc_01=@Desc_01,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Last_Modify_Company_Id=@Last_Modify_Company_Id,");
            strSql.Append("Last_Modify_Role_Id=@Last_Modify_Role_Id,");
            strSql.Append("Last_Modify_Usr_Id=@Last_Modify_Usr_Id,");
            strSql.Append("Last_Modify_Date=@Last_Modify_Date,");
            strSql.Append("Exc_Rate=@Exc_Rate");
            strSql.Append(" where Company_Id=@Company_Id and Currency_Id=@Currency_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,100),
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@Last_Modify_Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Role_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Usr_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Date", SqlDbType.DateTime),
					new SqlParameter("@Exc_Rate", SqlDbType.Decimal,13),
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Currency_Id", SqlDbType.NVarChar,50)};
            parameters[0].Value = this.txtNo.Text;
            parameters[1].Value = this.txtRemark.Text;
            parameters[2].Value = LoginInfo._Usr_Company;
            parameters[3].Value = LoginInfo._Usr_Role;
            parameters[4].Value = LoginInfo._Usr_id;
            parameters[5].Value = System.DateTime.Now.ToString();
            parameters[6].Value = this.txtHl.Text;
            parameters[7].Value = LoginInfo._Usr_Company;
            parameters[8].Value = this.txtNo.Text;

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

        private void CurrencyManage_Load(object sender, EventArgs e)
        {
            this.txtLrUsr.Text = LoginInfo._Usr_id;
            this.txtCtTime.Text = System.DateTime.Now.ToString();
            if (_Edit == "UPD")
            {
                this.txtNo.ReadOnly = true;
                DataTable _dtCur = GetData(_Company_Id, _Currency_Id);
                if (_dtCur != null && _dtCur.Rows.Count > 0)
                {
                    this.txtNo.Text = _Currency_Id;
                    this.txtName.Text = _dtCur.Rows[0]["Desc_01"].ToString();
                    this.txtHl.Text = _dtCur.Rows[0]["Exc_Rate"].ToString();
                    this.txtLrUsr.Text = _dtCur.Rows[0]["Usr__Id"].ToString();
                    this.txtCtTime.Text = System.DateTime.Now.ToString();
                    this.txtRemark.Text = _dtCur.Rows[0]["Remark"].ToString();
                }
            }
        }

        private DataTable GetData(string _company_id, string _currency_Id)
        {
            string _sql = "select * from Currency where Company_Id=@Company_Id and  Currency_Id=@Currency_Id";
            SqlParameter[] paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@Company_Id", SqlDbType.VarChar, 50);
            paras[0].Value = _company_id;
            paras[1] = new SqlParameter("@Currency_Id", SqlDbType.VarChar, 50);
            paras[1].Value = _currency_Id;
            DataTable dt = SqlHelper.ExecuteDataTable(_sql, paras);
            return dt;
        }

        private void txtHl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键  
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数  
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符  
                }
            }  
        }

    }
}
