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
    public partial class ItemUtManage : Form
    {
        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }
        public ItemUtManage()
        {
            InitializeComponent();
        }
        private string _ItemUt_Id = "";
        public string ItemUt_Id
        {
            set { _ItemUt_Id = value; }
            get { return _ItemUt_Id; }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNo.Text))
            {
                MessageBox.Show("物料单位编码不能为空！");
                return;
            }

            if (_Edit == "ADD")
            {
                string _where = " And isnull(ItemUt_Id,'')='" + this.txtNo.Text + "'";
                if (!CommomHelper.Exists("ItemUt", _where))
                {
                    if (AddItemUt())
                    {
                        this.DialogResult = DialogResult.Yes;
                    }
                }
                else
                {
                    MessageBox.Show("该物料单位已存在！");
                    return;
                }               
            }
            else if (_Edit == "UPD")
            {
                if (UpdateItemUt())
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void ItemUtManage_Load(object sender, EventArgs e)
        {
            this.txtLrUsr.Text = LoginInfo._Usr_id;
            this.txtCtTime.Text = System.DateTime.Now.ToString();
            if (_Edit == "UPD")
            {
                this.txtNo.ReadOnly = true;
                DataTable _dtsales = GetData(ItemUt_Id);
                if (_dtsales != null && _dtsales.Rows.Count > 0)
                {
                    this.txtNo.Text = ItemUt_Id;
                    this.txtName.Text = _dtsales.Rows[0]["Desc_01"].ToString();
                    this.txtRemark.Text = _dtsales.Rows[0]["Remark"].ToString();
                    this.txtLrUsr.Text = _dtsales.Rows[0]["Usr__Id"].ToString();
                    this.txtCtTime.Text = _dtsales.Rows[0]["Create__Date"].ToString();
                }
            }
        }

        private DataTable GetData(string _itemUt_Id)
        {
            string _sql = "select * from ItemUt where  ItemUt_Id=@ItemUt_Id";
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@ItemUt_Id", SqlDbType.VarChar, 50);
            paras[0].Value = _itemUt_Id;
            DataTable dt = SqlHelper.ExecuteDataTable(_sql, paras);
            return dt;
        }

        private bool AddItemUt()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ItemUt(");
            strSql.Append("ItemUt_Id,Desc_01,Parent_ItemUt_Id,Level_Id,Is_Lowest,Sort_Number,Status_Id,Status_Id_BC,Remark,Company__Id,Role__Id,Usr__Id,Create__Date)");
            strSql.Append(" values (");
            strSql.Append("@ItemUt_Id,@Desc_01,@Parent_ItemUt_Id,@Level_Id,@Is_Lowest,@Sort_Number,@Status_Id,@Status_Id_BC,@Remark,@Company__Id,@Role__Id,@Usr__Id,@Create__Date)");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemUt_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,200),
					new SqlParameter("@Parent_ItemUt_Id", SqlDbType.NVarChar,50),
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
            parameters[0].Value = this.txtNo.Text;
            parameters[1].Value = this.txtName.Text;
            parameters[2].Value = "";
            parameters[3].Value = 0;
            parameters[4].Value = "";
            parameters[5].Value = 0;
            parameters[6].Value = "130";
            parameters[7].Value = "";
            parameters[8].Value = this.txtRemark.Text;
            parameters[9].Value = LoginInfo._Usr_Company;
            parameters[10].Value = LoginInfo._Usr_Role;
            parameters[11].Value = LoginInfo._Usr_id;
            parameters[12].Value = System.DateTime.Now.ToString();

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
        
        private bool UpdateItemUt()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ItemUt set ");
            strSql.Append("Desc_01=@Desc_01,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Last_Modify_Company_Id=@Last_Modify_Company_Id,");
            strSql.Append("Last_Modify_Role_Id=@Last_Modify_Role_Id,");
            strSql.Append("Last_Modify_Usr_Id=@Last_Modify_Usr_Id,");
            strSql.Append("Last_Modify_Date=@Last_Modify_Date");
            strSql.Append(" where ItemUt_Id=@ItemUt_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,200),
                    new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@Last_Modify_Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Role_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Usr_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Date", SqlDbType.DateTime),
					new SqlParameter("@ItemUt_Id", SqlDbType.NVarChar,50)};
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
