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
    public partial class CsvManage : Form
    {
        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }
        public CsvManage()
        {
            InitializeComponent();
        }

        private string _Csv_Id = "";
        public string Csv_Id
        {
            set { _Csv_Id = value; }
            get { return _Csv_Id; }
        }

        private string _Company_Id = "";
        public string Company_Id
        {
            set { _Company_Id = value; }
            get { return _Company_Id; }
        }
        private DataTable _dtEc;

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddCsv()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Csv(");
            strSql.Append("Company_Id,Csv_Id,Desc_01,Parent_Company_Id,Parent_Csv_Id,Level_Id,Sort_Number,Est_Itm,Is_Lowest,Status_Id,Status_Id_BC,Remark,Company__Id,Role__Id,Usr__Id,Create__Date,Customer_Id,Snm_01,Domestic_Id,Abroad_Id,Area_Name,Address_Desc,Taxer_Registration_Number,Development_Date,PayTerm_Id,Stop_Date,Cm_Employee_Id)");
            strSql.Append(" values (");
            strSql.Append("@Company_Id,@Csv_Id,@Desc_01,@Parent_Company_Id,@Parent_Csv_Id,@Level_Id,@Sort_Number,@Est_Itm,@Is_Lowest,@Status_Id,@Status_Id_BC,@Remark,@Company__Id,@Role__Id,@Usr__Id,@Create__Date,@Customer_Id,@Snm_01,@Domestic_Id,@Abroad_Id,@Area_Name,@Address_Desc,@Taxer_Registration_Number,@Development_Date,@PayTerm_Id,@Stop_Date,@Cm_Employee_Id)");
            SqlParameter[] parameters = {
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Csv_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,100),
					new SqlParameter("@Parent_Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Parent_Csv_Id", SqlDbType.NVarChar,50),
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
					new SqlParameter("@Customer_Id", SqlDbType.NVarChar,1),
					new SqlParameter("@Snm_01", SqlDbType.NVarChar,100),
					new SqlParameter("@Domestic_Id", SqlDbType.NVarChar,1),
					new SqlParameter("@Abroad_Id", SqlDbType.NVarChar,1),
					new SqlParameter("@Area_Name", SqlDbType.NVarChar,100),
					new SqlParameter("@Address_Desc", SqlDbType.NVarChar,200),
					new SqlParameter("@Taxer_Registration_Number", SqlDbType.NVarChar,50),
					new SqlParameter("@Development_Date", SqlDbType.DateTime),
					new SqlParameter("@PayTerm_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Stop_Date", SqlDbType.DateTime),
                    new SqlParameter("@Cm_Employee_Id", SqlDbType.NVarChar,50)};
                   
            parameters[0].Value = LoginInfo._Usr_Company;
            parameters[1].Value = this.txtNo.Text;
            parameters[2].Value = this.txtName.Text;
            parameters[3].Value = "";
            parameters[4].Value = "";  //上级客户
            parameters[5].Value = 0;
            parameters[6].Value = 0;
            parameters[7].Value =0;
            parameters[8].Value = "";
            parameters[9].Value = "";
            parameters[10].Value = "";
            parameters[11].Value = this.txtRemark.Text;
            parameters[12].Value = LoginInfo._Usr_Company;
            parameters[13].Value = LoginInfo._Usr_Role;
            parameters[14].Value = LoginInfo._Usr_id;
            parameters[15].Value = System.DateTime.Now;
            parameters[16].Value = "T";
            parameters[17].Value = this.txtEname.Text;
            parameters[18].Value = this.checkBox1.Checked ? "T" : "F";
            parameters[19].Value = this.checkBox2.Checked ? "T" : "F";
            parameters[20].Value = this.txtAreaName.Text;
            parameters[21].Value = this.txtArea.Text;
            parameters[22].Value = this.txtNsNo.Text;
            parameters[23].Value = Convert.ToDateTime(this.dateTimePicker1.Value);
            parameters[24].Value = this.txtFk.Text;
            parameters[25].Value = Convert.ToDateTime(this.dateTimePicker2.Value);
            parameters[26].Value = string.IsNullOrEmpty(this.textBoxContainButton1.ID) ? "" : this.textBoxContainButton1.ID;

            StringBuilder _strEc = new StringBuilder();
            for (int i = 0; i < _dtEc.Rows.Count; i++)
            {
                  string _Employee_id = _dtEc.Rows[i]["Employee_id"].ToString();
                  _strEc.Append(" If ((select 1 from CsvEmployee where Company_Id='" + LoginInfo._Usr_Company + "' and Csv_Id='" + Csv_Id + "' and Employee_id='" + _Employee_id + "') is null) ");
                  _strEc.Append("insert into PlanningOrderInfoInputBody(Company_Id,Csv_Id,Employee_Company_Id,Employee_Id");
                  _strEc.Append(" values ('" + LoginInfo._Usr_Company + "','" + this.txtNo.Text + "','" + LoginInfo._Usr_Company + "','" + _Employee_id + "')");
            }

            int rows = SqlHelper.ExecuteQuery(strSql + _strEc.ToString(), parameters);
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
        public bool UpdateCsv()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Csv set ");
            strSql.Append("Desc_01=@Desc_01,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Last_Modify_Company_Id=@Last_Modify_Company_Id,");
            strSql.Append("Last_Modify_Role_Id=@Last_Modify_Role_Id,");
            strSql.Append("Last_Modify_Usr_Id=@Last_Modify_Usr_Id,");
            strSql.Append("Last_Modify_Date=@Last_Modify_Date,");
            strSql.Append("Customer_Id=@Customer_Id,");
            strSql.Append("Snm_01=@Snm_01,");
            strSql.Append("Domestic_Id=@Domestic_Id,");
            strSql.Append("Abroad_Id=@Abroad_Id,");
            strSql.Append("Area_Name=@Area_Name,");
            strSql.Append("Address_Desc=@Address_Desc,");
            strSql.Append("Taxer_Registration_Number=@Taxer_Registration_Number,");
            strSql.Append("Development_Date=@Development_Date,");
            strSql.Append("Cm_Employee_Id=@Cm_Employee_Id,");
            strSql.Append("PayTerm_Id=@PayTerm_Id,");
            strSql.Append("Stop_Date=@Stop_Date");
            strSql.Append(" where Company_Id=@Company_Id and Csv_Id=@Csv_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,100),
                  	new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@Last_Modify_Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Role_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Usr_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Date", SqlDbType.DateTime),
					new SqlParameter("@Customer_Id", SqlDbType.NVarChar,1),
					new SqlParameter("@Snm_01", SqlDbType.NVarChar,100),
					new SqlParameter("@Domestic_Id", SqlDbType.NVarChar,1),
					new SqlParameter("@Abroad_Id", SqlDbType.NVarChar,1),
					new SqlParameter("@Area_Name", SqlDbType.NVarChar,100),
					new SqlParameter("@Address_Desc", SqlDbType.NVarChar,200),
					new SqlParameter("@Taxer_Registration_Number", SqlDbType.NVarChar,50),
					new SqlParameter("@Development_Date", SqlDbType.DateTime),
					new SqlParameter("@Cm_Employee_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@PayTerm_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Stop_Date", SqlDbType.DateTime),
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Csv_Id", SqlDbType.NVarChar,50)};
            parameters[0].Value = this.txtName.Text;
            parameters[1].Value = this.txtRemark.Text;
            parameters[2].Value = LoginInfo._Usr_Company;
            parameters[3].Value = LoginInfo._Usr_Role;
            parameters[4].Value = LoginInfo._Usr_id;
            parameters[5].Value = System.DateTime.Now.ToString();
            parameters[6].Value = "T";
            parameters[7].Value = this.txtEname.Text;
            parameters[8].Value = this.checkBox1.Checked ? "T" : "F";
            parameters[9].Value = this.checkBox2.Checked ? "T" : "F";
            parameters[10].Value = this.txtAreaName.Text;
            parameters[11].Value = this.txtArea.Text;
            parameters[12].Value = this.txtNsNo.Text;
            parameters[13].Value = this.dateTimePicker1.Value;
            parameters[14].Value = this.textBoxContainButton1.ID;
            parameters[15].Value = this.txtFk.Text;
            parameters[16].Value = this.dateTimePicker2.Value;
            parameters[17].Value = LoginInfo._Usr_Company;
            parameters[18].Value = this.txtNo.Text;

            StringBuilder _strEc = new StringBuilder();
            for (int i = 0; i < _dtEc.Rows.Count; i++)
            {
                string _Employee_id = _dtEc.Rows[i]["Employee_id"].ToString();
                _strEc.Append("update PlanningOrderInfoInputBody set Employee_Company_Id='" + LoginInfo._Usr_Company + "',Employee_Id='" + _Employee_id + "'");
                _strEc.Append(" Where Company_Id='" + LoginInfo._Usr_Company + "' and Csv_Id='" + this.txtNo.Text + "' ");
            }

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

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNo.Text))
            {
                MessageBox.Show("员工编号不能为空！");
                return;
            }

            if (_Edit == "ADD")
            {
                string _where = "and Csv.Company_Id='" + LoginInfo._Usr_Company + "' And isnull(Csv_Id,'')='" + this.txtNo.Text + "'";
                if (!CommomHelper.Exists("Csv", _where))
                {
                    if (AddCsv())
                    {
                        this.DialogResult = DialogResult.Yes;
                    }
                }
                else
                {
                    MessageBox.Show("该客户已存在！");
                    return;
                }
            }
            else if (_Edit == "UPD")
            {
                if (UpdateCsv())
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void CsvManage_Load(object sender, EventArgs e)
        {
            this.txtLrUsr.Text = LoginInfo._Usr_id;
            this.txtCtTime.Text = System.DateTime.Now.ToString();
            if (_Edit == "ADD")
            {
                this.Text = "客户--新增";
            }
            else if (_Edit == "UPD")
            {
                this.Text = "客户--修改";
                this.txtNo.ReadOnly = true;
                DataTable _dtCsv = GetData(_Company_Id, _Csv_Id);
                if (_dtCsv != null && _dtCsv.Rows.Count > 0)
                {
                    this.txtNo.ReadOnly = true;
                    this.txtNo.Text = _dtCsv.Rows[0]["Csv_Id"].ToString();
                    this.txtName.Text = _dtCsv.Rows[0]["Desc_01"].ToString();
                    this.txtEname.Text = _dtCsv.Rows[0]["Snm_01"].ToString();
                    this.checkBox1.Checked = _dtCsv.Rows[0]["Domestic_Id"].ToString() == "T" ? true : false;
                    this.checkBox2.Checked = _dtCsv.Rows[0]["Abroad_Id"].ToString() == "T" ? true : false;
                    this.txtAreaName.Text = _dtCsv.Rows[0]["Area_Name"].ToString();
                    this.txtArea.Text = _dtCsv.Rows[0]["Address_Desc"].ToString();
                    this.txtNsNo.Text = _dtCsv.Rows[0]["Taxer_Registration_Number"].ToString();
                    this.dateTimePicker1.Value =string.IsNullOrEmpty(_dtCsv.Rows[0]["Development_Date"].ToString())?DateTime.Now:Convert.ToDateTime(_dtCsv.Rows[0]["Development_Date"].ToString());
                    this.dateTimePicker2.Text = _dtCsv.Rows[0]["Stop_Date"].ToString();
                    this.dateTimePicker3.Text = _dtCsv.Rows[0]["Last_Modify_Date"].ToString();
                    this.textBoxContainButton1.Text = _dtCsv.Rows[0]["CM_Employee_Id"].ToString();
                    this.txtFk.Text = _dtCsv.Rows[0]["PayTerm_Id"].ToString();
                    this.txtLrUsr.Text = _dtCsv.Rows[0]["Usr__Id"].ToString();
                    this.txtCtTime.Text = _dtCsv.Rows[0]["Create__Date"].ToString();
                    this.txtRemark.Text = _dtCsv.Rows[0]["Remark"].ToString();
                }
            }
            this.textBoxContainButton1.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton1.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton1.TextLeave += textBoxContainButton1_TextLeave;
        }

        private DataTable GetData(string _company_id, string _csv_Id)
        {
            string _sql = "select * from Csv where Company_Id=@Company_Id and  Csv_Id=@Csv_Id";
            SqlParameter[] paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@Company_Id", SqlDbType.VarChar, 50);
            paras[0].Value = _company_id;
            paras[1] = new SqlParameter("@Csv_Id", SqlDbType.VarChar, 50);
            paras[1].Value = _csv_Id;
            DataTable dt = SqlHelper.ExecuteDataTable(_sql, paras);
            return dt;
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

        private void textBoxContainButton1_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("Employee", "Employee_Id", e);
        }

        private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("Employee", "Employee_Id", e);
        }

        private void btnCrv_Click(object sender, EventArgs e)
        {
            CsvEmployeeForm _manage = new CsvEmployeeForm();
            _manage.Src_Company_Id = LoginInfo._Usr_Company;
            _manage.Src_Csv_Id = this.txtNo.Text;
            _manage.Edit = _Edit;
            if(_manage.ShowDialog()==DialogResult.Yes)
            {
                _dtEc = _manage._dtCE;
            }
        }
    }
}
