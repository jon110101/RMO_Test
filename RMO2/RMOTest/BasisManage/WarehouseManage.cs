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
    public partial class WarehouseManage : Form
    {
        public WarehouseManage()
        {
            InitializeComponent();
        }
        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }

        private string _Warehouse_Id = "";
        public string Warehouse_Id
        {
            set { _Warehouse_Id = value; }
            get { return _Warehouse_Id; }
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
                MessageBox.Show("仓库/仓位编码不能为空！");
                return;
            }

            if (_Edit == "ADD")
            {
                string _where = "and Warehouse.Company_Id='" + LoginInfo._Usr_Company + "' And isnull(Warehouse_Id,'')='" + this.txtNo.Text + "'";
                if (!CommomHelper.Exists("Warehouse", _where))
                {
                    if (AddWarehouse())
                    {
                        this.DialogResult = DialogResult.Yes;
                    }
                }
                else
                {
                    MessageBox.Show("该仓库/仓位已存在！");
                    return;
                }
              
            }
            else if (_Edit == "UPD")
            {
                if (UpdateWarehouse())
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void WarehouseManage_Load(object sender, EventArgs e)
        {
            this.txtLrUsr.Text = LoginInfo._Usr_id;
            this.txtCtTime.Text = System.DateTime.Now.ToString();
            if (_Edit == "UPD")
            {
                this.txtNo.ReadOnly = true;
                DataTable _dtCsv = GetData(_Company_Id, _Warehouse_Id);
                if (_dtCsv != null && _dtCsv.Rows.Count > 0)
                {
                    this.txtNo.ReadOnly = true;
                    this.txtNo.Text = _dtCsv.Rows[0]["Warehouse_Id"].ToString();
                    this.txtName.Text = _dtCsv.Rows[0]["Desc_01"].ToString();
                    this.txtLrUsr.Text = _dtCsv.Rows[0]["Usr__Id"].ToString();
                    this.txtCtTime.Text = _dtCsv.Rows[0]["Create__Date"].ToString();
                    this.txtRemark.Text = _dtCsv.Rows[0]["Remark"].ToString();
                    this.textBoxContainButton2.Text = _dtCsv.Rows[0]["Parent_Warehouse_Id"].ToString();
                }
            }
            this.textBoxContainButton2.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton2.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton2.TextLeave += textBoxContainButton1_TextLeave;
        }

        private void textBoxContainButton1_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("Warehouse", "Warehouse_ID", e);
        }

        private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("Warehouse", "Warehouse_ID", e);
        }

        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=Warehouse_Id,Desc_01=Desc_01 ";
           
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("Warehouse", _columns, "and Warehouse_Id not in('" + this.txtNo.Text + "') ");
            }
            else
            {
                string _where = "and Warehouse.Company_Id='" + LoginInfo._Usr_Company + "' and Warehouse_Id not in('" + this.txtNo.Text + "')";
                _ht = CommomHelper.GetQuery1("Warehouse", _columns, _where);
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

        private DataTable GetData(string _company_id, string _warehouse_Id)
        {
            string _sql = "select * from Warehouse where Company_Id=@Company_Id and  Warehouse_Id=@Warehouse_Id";
            SqlParameter[] paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@Company_Id", SqlDbType.VarChar, 50);
            paras[0].Value = _company_id;
            paras[1] = new SqlParameter("@Warehouse_Id", SqlDbType.VarChar, 50);
            paras[1].Value = _warehouse_Id;
            DataTable dt = SqlHelper.ExecuteDataTable(_sql, paras);
            return dt;
        }
        private bool AddWarehouse()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Warehouse(");
            strSql.Append("Company_Id,Warehouse_Id,Desc_01,Parent_Warehouse_Id,Level_Id,Is_Lowest,Sort_Number,Status_Id,Status_Id_BC,Remark,Company__Id,Role__Id,Usr__Id,Create__Date)");
            strSql.Append(" values (");
            strSql.Append("@Company_Id,@Warehouse_Id,@Desc_01,@Parent_Warehouse_Id,@Level_Id,@Is_Lowest,@Sort_Number,@Status_Id,@Status_Id_BC,@Remark,@Company__Id,@Role__Id,@Usr__Id,@Create__Date)");
            SqlParameter[] parameters = {
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Warehouse_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,200),
					new SqlParameter("@Parent_Warehouse_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Level_Id", SqlDbType.Int,4),
					new SqlParameter("@Is_Lowest", SqlDbType.NVarChar,1),
					new SqlParameter("@Sort_Number", SqlDbType.Decimal,13),
					new SqlParameter("@Status_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Status_Id_BC", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@Company__Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Role__Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Usr__Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Create__Date", SqlDbType.DateTime)};
            parameters[0].Value = LoginInfo._Usr_Company;
            parameters[1].Value = this.txtNo.Text;
            parameters[2].Value = this.txtName.Text;
            parameters[3].Value = string.IsNullOrEmpty(this.textBoxContainButton2.ID) ? "" : this.textBoxContainButton2.ID;
            parameters[4].Value = 0;
            parameters[5].Value = "";
            parameters[6].Value =0;
            parameters[7].Value = "";
            parameters[8].Value = "";
            parameters[9].Value = this.txtRemark.Text;
            parameters[10].Value = LoginInfo._Usr_Company;
            parameters[11].Value = LoginInfo._Usr_Role;
            parameters[12].Value = LoginInfo._Usr_id;
            parameters[13].Value = System.DateTime.Now.ToString();

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

        private bool UpdateWarehouse()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Warehouse set ");
            strSql.Append("Desc_01=@Desc_01,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Parent_Warehouse_Id=@Parent_Warehouse_Id,");
            strSql.Append("Last_Modify_Company_Id=@Last_Modify_Company_Id,");
            strSql.Append("Last_Modify_Role_Id=@Last_Modify_Role_Id,");
            strSql.Append("Last_Modify_Usr_Id=@Last_Modify_Usr_Id,");
            strSql.Append("Last_Modify_Date=@Last_Modify_Date");
            strSql.Append(" where Company_Id=@Company_Id and Warehouse_Id=@Warehouse_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,200),
                  	new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@Parent_Warehouse_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Role_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Usr_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Date", SqlDbType.DateTime),
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Warehouse_Id", SqlDbType.NVarChar,50)};
            parameters[0].Value = this.txtName.Text;
            parameters[1].Value = this.txtRemark.Text;
            parameters[2].Value = this.textBoxContainButton2.ID;
            parameters[3].Value = LoginInfo._Usr_Company;
            parameters[4].Value = LoginInfo._Usr_Role;
            parameters[5].Value = LoginInfo._Usr_id;
            parameters[6].Value = System.DateTime.Now.ToString();
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
    }
}
