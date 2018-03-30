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
    public partial class ItemKindManage : Form
    {
        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }
        public ItemKindManage()
        {
            InitializeComponent();
        }

        private string _ItemKind_Id = "";
        public string ItemKind_Id
        {
            set { _ItemKind_Id = value; }
            get { return _ItemKind_Id; }
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
                MessageBox.Show("物料类别编码不能为空！");
                return;
            }

            if (_Edit == "ADD")
            {
                string _where = "and ItemKind.Company_Id='" + LoginInfo._Usr_Company + "' And isnull(ItemKind_Id,'')='" + this.txtNo.Text + "'";
                if (!CommomHelper.Exists("ItemKind", _where))
                {
                    if (AddItemKind())
                    {
                        this.DialogResult = DialogResult.Yes;
                    }
                }
                else
                {
                    MessageBox.Show("该物料类别已存在！");
                    return;
                }
                
            }
            else if (_Edit == "UPD")
            {
                if (UpdateItemKind())
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void ItemKindManage_Load(object sender, EventArgs e)
        {
            this.txtLrUsr.Text = LoginInfo._Usr_id;
            this.txtCtTime.Text = System.DateTime.Now.ToString();
            if (_Edit == "UPD")
            {
                this.txtNo.ReadOnly = true;
                DataTable _dtKind = GetData(_Company_Id, _ItemKind_Id);
                if (_dtKind != null && _dtKind.Rows.Count > 0)
                {
                    this.txtNo.Text = _ItemKind_Id;
                    this.txtName.Text = _dtKind.Rows[0]["Desc_01"].ToString();
                    this.txtRemark.Text = _dtKind.Rows[0]["Remark"].ToString();
                    this.txtLrUsr.Text = _dtKind.Rows[0]["Usr__Id"].ToString();
                    this.txtCtTime.Text = _dtKind.Rows[0]["Create__Date"].ToString();
                }
            }
        }

        private DataTable GetData(string _company_id, string _itemKind_Id)
        {
            string _sql = "select * from ItemKind where Company_Id=@Company_Id and  ItemKind_Id=@ItemKind_Id";
            SqlParameter[] paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@Company_Id", SqlDbType.VarChar, 50);
            paras[0].Value = _company_id;
            paras[1] = new SqlParameter("@ItemKind_Id", SqlDbType.VarChar, 50);
            paras[1].Value = _itemKind_Id;
            DataTable dt = SqlHelper.ExecuteDataTable(_sql, paras);
            return dt;
        }

        private bool AddItemKind()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ItemKind(");
            strSql.Append("Company_Id,ItemKind_Id,Desc_01,Parent_Company_Id,Parent_ItemKind_Id,Level_Id,Sort_Number,Est_Itm,Is_Lowest,Status_Id,Status_Id_BC,Remark,Company__Id,Role__Id,Usr__Id,Create__Date)");
            strSql.Append(" values (");
            strSql.Append("@Company_Id,@ItemKind_Id,@Desc_01,@Parent_Company_Id,@Parent_ItemKind_Id,@Level_Id,@Sort_Number,@Est_Itm,@Is_Lowest,@Status_Id,@Status_Id_BC,@Remark,@Company__Id,@Role__Id,@Usr__Id,@Create__Date)");
            SqlParameter[] parameters = {
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemKind_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,100),
					new SqlParameter("@Parent_Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Parent_ItemKind_Id", SqlDbType.NVarChar,50),
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
            parameters[6].Value = 1;
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

        private bool UpdateItemKind()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ItemKind set ");
            strSql.Append("Desc_01=@Desc_01,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Last_Modify_Company_Id=@Last_Modify_Company_Id,");
            strSql.Append("Last_Modify_Role_Id=@Last_Modify_Role_Id,");
            strSql.Append("Last_Modify_Usr_Id=@Last_Modify_Usr_Id,");
            strSql.Append("Last_Modify_Date=@Last_Modify_Date");
            strSql.Append(" where ItemKind_Id=@ItemKind_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,200),
                    new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@Last_Modify_Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Role_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Usr_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Date", SqlDbType.DateTime),
					new SqlParameter("@ItemKind_Id", SqlDbType.NVarChar,50)};
            parameters[0].Value = this.txtName.Text;
            parameters[1].Value = this.txtRemark.Text;
            parameters[2].Value = LoginInfo._Usr_Company;
            parameters[3].Value = LoginInfo._Usr_Role;
            parameters[4].Value = LoginInfo._Usr_id;
            parameters[5].Value = System.DateTime.Now.ToString();
            parameters[6].Value = this.txtNo.Text;

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
