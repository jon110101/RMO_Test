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
    public partial class ItemManage : Form
    {
        DataTable _dtUnit = null;
        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }
        public ItemManage()
        {
            InitializeComponent();
        }

        private string _Item_Id = "";
        public string Item_Id
        {
            set { _Item_Id = value; }
            get { return _Item_Id; }
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
                MessageBox.Show("部门编码不能为空！");
                return;
            }

            if (_Edit == "ADD")
            {
                string _where = "and Item.Company_Id='" + LoginInfo._Usr_Company + "' And isnull(Item_Id,'')='" + this.txtNo.Text + "'";
                if (!CommomHelper.Exists("Item", _where))
                {
                    if (AddItem())
                    {

                        this.DialogResult = DialogResult.Yes;
                    }
                }
                else
                {
                    MessageBox.Show("该物料已存在！");
                    return;
                }
            }
            else if (_Edit == "UPD")
            {
                if (UpdateItem())
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
        }

        private StringBuilder UpdUt(DataRow _dr)
        {
            StringBuilder _strSql = new StringBuilder();
            _strSql.Append("     Delete From ItemUnit   Where  ItemUnit.Company_Id='" + LoginInfo._Usr_Company + "'   And isnull(Item_Id,'')='" + this.txtNo.Text + "'");

            _strSql.Append("    Insert Into ItemUnit(Company_Id, Item_Id,   ItemUnit_Id, Exc_Rto,   Default_Id ) ");  //Default_Scan_Id, Default_Scan_Qty

            _strSql.Append("    Select '" + LoginInfo._Usr_Company + "', '" + this.txtNo.Text + "', '" + _dr["ItemUnit_Id"].ToString() + "','" + _dr["Exc_Rto"].ToString() + "','" + _dr["Exc_Rto"].ToString() + "'");
            _strSql.Append("      From  ##ItemAdministrator_ItemUnit  ");
            _strSql.Append("     Where  ItemUnit_Id<>当前最小主单位 ");
            _strSql.Append("     Union   ");
            _strSql.Append("    Select 当前公司, 当前物料,                ");
            _strSql.Append("           ItemUnit_Id=当前最小主单位, Exc_Rto=1, ");
            _strSql.Append("         Default_Id=动态判断(用户有在ItemUnit UI临时表设置缺省单位，则为F；没有设置缺省单位，则为T) ");

            return _strSql;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private bool AddItem()
        {
            StringBuilder strSqlUnit = new StringBuilder();
            StringBuilder strSql = new StringBuilder();

            string _Default_Id = "T";
            if(_dtUnit!=null&&_dtUnit.Rows.Count>0)
            {
                strSqlUnit.Append("     Delete From ItemUnit   Where  ItemUnit.Company_Id='" + LoginInfo._Usr_Company + "'   And isnull(Item_Id,'')='" + this.txtNo.Text + "'; ");
                foreach (DataRow _dr in _dtUnit.Rows)
                {
                    if (_dr["Default_Id"].ToString()=="T")
                    {
                        _Default_Id = "F";
                    }
                    if (_dr["ItemUnit_Id"].ToString() != this.textBoxContainButton1.ID)
                    {
                        strSqlUnit.Append(" insert into ItemUnit(");
                        strSqlUnit.Append("Company_Id,Item_Id,ItemUnit_Id,Exc_Rto,Default_Id )");
                        strSqlUnit.Append(" values('" + LoginInfo._Usr_Company + "','" + this.txtNo.Text + "','" + _dr["ItemUnit_Id"].ToString() + "','" + _dr["Exc_Rto"].ToString() + "','" + _dr["Default_Id"].ToString() + "'); ");
                    }
                }
                strSqlUnit.Append(" insert into ItemUnit(");
                strSqlUnit.Append("Company_Id,Item_Id,ItemUnit_Id,Exc_Rto,Default_Id )");
                strSqlUnit.Append(" values('" + LoginInfo._Usr_Company + "','" + this.txtNo.Text + "','" + this.textBoxContainButton1.ID + "','1','" + _Default_Id + "'); ");
            }

            strSql.Append(" insert into Item(");
            strSql.Append("Company_Id,Item_Id,Desc_01,Parent_Company_Id,Parent_Item_Id,Level_Id,Is_Lowest,Sort_Number,Status_Id,Status_Id_BC,Remark,Company__Id,Role__Id,Usr__Id,Create__Date,ItemKind_Id,ItemType_Id,Min_ItemUnit_Id,ItemLot_Control_Id,ItemEwm_Control_Id)");
            strSql.Append(" values (");
            strSql.Append("@Company_Id,@Item_Id,@Desc_01,@Parent_Company_Id,@Parent_Item_Id,@Level_Id,@Is_Lowest,@Sort_Number,@Status_Id,@Status_Id_BC,@Remark,@Company__Id,@Role__Id,@Usr__Id,@Create__Date,@ItemKind_Id,@ItemType_Id,@Min_ItemUnit_Id,@ItemLot_Control_Id,@ItemEwm_Control_Id)");
            SqlParameter[] parameters = {
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Item_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,200),
					new SqlParameter("@Parent_Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Parent_Item_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Level_Id", SqlDbType.Int,4),
					new SqlParameter("@Is_Lowest", SqlDbType.NVarChar,1),
					new SqlParameter("@Sort_Number", SqlDbType.Decimal,13),
					new SqlParameter("@Status_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Status_Id_BC", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@Company__Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Role__Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Usr__Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Create__Date", SqlDbType.DateTime),
					new SqlParameter("@ItemKind_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemType_Id", SqlDbType.NVarChar,1),
					new SqlParameter("@Min_ItemUnit_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemLot_Control_Id", SqlDbType.NVarChar,1),
					new SqlParameter("@ItemEwm_Control_Id", SqlDbType.NVarChar,1)};
            parameters[0].Value = LoginInfo._Usr_Company;
            parameters[1].Value = this.txtNo.Text;
            parameters[2].Value = this.txtName.Text;
            parameters[3].Value = "";
            parameters[4].Value = "";
            parameters[5].Value = 0;
            parameters[6].Value = "";
            parameters[7].Value = 0;
            parameters[8].Value = "";
            parameters[9].Value = "";
            parameters[10].Value = this.txtRemark.Text;
            parameters[11].Value = LoginInfo._Usr_Company;
            parameters[12].Value = LoginInfo._Usr_Role;
            parameters[13].Value = LoginInfo._Usr_id;
            parameters[14].Value = System.DateTime.Now.ToString();
            parameters[15].Value = string.IsNullOrEmpty(this.textBoxContainButton3.ID) ? "" : this.textBoxContainButton3.ID;
            parameters[16].Value = this.cbxLx.SelectedIndex;
            parameters[17].Value = string.IsNullOrEmpty(this.textBoxContainButton1.ID) ? "" : this.textBoxContainButton1.ID;
            parameters[18].Value = this.chkbat.Checked ? "T" : "F";
            parameters[19].Value = this.chkCode.Checked ? "T" : "F";

            bool isTrue= SqlHelper.ExecuteQueryTrans(strSqlUnit+strSql.ToString(), parameters);
            return isTrue;
        }

        private bool UpdateItem()
        {
            StringBuilder strSqlUnit = new StringBuilder();
            string _Default_Id = "T";
            if (_dtUnit != null && _dtUnit.Rows.Count > 0)
            {
                strSqlUnit.Append("     Delete From ItemUnit   Where  ItemUnit.Company_Id='" + LoginInfo._Usr_Company + "'   And isnull(Item_Id,'')='" + this.txtNo.Text + "'; ");
                foreach (DataRow _dr in _dtUnit.Rows)
                {
                    if (_dr["Default_Id"].ToString() == "T")
                    {
                        _Default_Id = "F";
                    }
                    if (_dr["ItemUnit_Id"].ToString() != this.textBoxContainButton1.ID)
                    {
                        strSqlUnit.Append(" insert into ItemUnit(");
                        strSqlUnit.Append("Company_Id,Item_Id,ItemUnit_Id,Exc_Rto,Default_Id )");
                        strSqlUnit.Append(" values('" + LoginInfo._Usr_Company + "','" + this.txtNo.Text + "','" + _dr["ItemUnit_Id"].ToString() + "','" + _dr["Exc_Rto"].ToString() + "','" + _dr["Default_Id"].ToString() + "'); ");
                    }
                }
                strSqlUnit.Append(" insert into ItemUnit(");
                strSqlUnit.Append("Company_Id,Item_Id,ItemUnit_Id,Exc_Rto,Default_Id )");
                strSqlUnit.Append(" values('" + LoginInfo._Usr_Company + "','" + this.txtNo.Text + "','" + this.textBoxContainButton1.ID + "','1','" + _Default_Id + "'); ");
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Item set ");
            strSql.Append("Desc_01=@Desc_01,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Last_Modify_Company_Id=@Last_Modify_Company_Id,");
            strSql.Append("Last_Modify_Role_Id=@Last_Modify_Role_Id,");
            strSql.Append("Last_Modify_Usr_Id=@Last_Modify_Usr_Id,");
            strSql.Append("Last_Modify_Date=@Last_Modify_Date,");
            strSql.Append("ItemKind_Id=@ItemKind_Id,");
            strSql.Append("ItemType_Id=@ItemType_Id,");
            strSql.Append("Min_ItemUnit_Id=@Min_ItemUnit_Id,");
            strSql.Append("ItemLot_Control_Id=@ItemLot_Control_Id,");
            strSql.Append("ItemEwm_Control_Id=@ItemEwm_Control_Id");
            strSql.Append(" where Company_Id=@Company_Id and Item_Id=@Item_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Desc_01", SqlDbType.NVarChar,200),
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@Last_Modify_Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Role_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Usr_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Modify_Date", SqlDbType.DateTime),
					new SqlParameter("@ItemKind_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemType_Id", SqlDbType.NVarChar,1),
					new SqlParameter("@Min_ItemUnit_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemLot_Control_Id", SqlDbType.NVarChar,1),
					new SqlParameter("@ItemEwm_Control_Id", SqlDbType.NVarChar,1),
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Item_Id", SqlDbType.NVarChar,50)};
            parameters[0].Value = this.txtNo.Text;
            parameters[1].Value = this.txtRemark.Text;
            parameters[2].Value = LoginInfo._Usr_Company;
            parameters[3].Value = LoginInfo._Usr_Role;
            parameters[4].Value = LoginInfo._Usr_id;
            parameters[5].Value = System.DateTime.Now.ToString();
            parameters[6].Value = this.textBoxContainButton3.ID;
            parameters[7].Value = this.cbxLx.SelectedIndex;
            parameters[8].Value = this.textBoxContainButton1.ID;
            parameters[9].Value = this.chkbat.Checked ? "T" : "F";
            parameters[10].Value = this.chkCode.Checked ? "T" : "F";
            parameters[11].Value = LoginInfo._Usr_Company;
            parameters[12].Value = this.txtNo.Text;
            bool isTrue = SqlHelper.ExecuteQueryTrans(strSqlUnit + strSql.ToString(), parameters);
            return isTrue;
        }

        private void btnUt_Click(object sender, EventArgs e)
        {
            ItemMunitForm _itemUnitForm = new ItemMunitForm();
            _itemUnitForm.Edit = _Edit;
            _itemUnitForm.ItemUtId = this.textBoxContainButton1.Text;
            if (_Edit=="UPD")
            {
                _itemUnitForm.ItemId = this.txtNo.Text;
            }
            if(_itemUnitForm.ShowDialog()==DialogResult.Yes)
            {
                 _dtUnit = _itemUnitForm._dtUnit;
            }
        }

        private void ItemManage_Load(object sender, EventArgs e)
        {
            this.txtLrUsr.Text = LoginInfo._Usr_id;
            this.txtCtTime.Text = System.DateTime.Now.ToString();
            if (_Edit == "UPD")
            {
                this.txtNo.ReadOnly = true;
                DataTable _dtDep = GetData(_Company_Id, _Item_Id);
                if (_dtDep != null && _dtDep.Rows.Count > 0)
                {
                    this.txtNo.ReadOnly = true;
                    this.txtNo.Text = _dtDep.Rows[0]["Item_Id"].ToString();
                    this.txtName.Text = _dtDep.Rows[0]["Desc_01"].ToString();
                    this.txtgg.Text = "";  //规格
                    this.textBoxContainButton3.Text = _dtDep.Rows[0]["ItemKind_Id"].ToString();
                    this.cbxLx.SelectedIndex = string.IsNullOrEmpty(_dtDep.Rows[0]["ItemType_Id"].ToString()) ? 0 : Convert.ToInt16(_dtDep.Rows[0]["ItemType_Id"].ToString());
                    this.txtRemark.Text = _dtDep.Rows[0]["Remark"].ToString();
                    this.textBoxContainButton1.Text = _dtDep.Rows[0]["Min_ItemUnit_Id"].ToString();
                    this.chkbat.Checked = _dtDep.Rows[0]["ItemLot_Control_Id"].ToString() == "T" ? true : false; //批号管制否
                    this.chkCode.Checked = _dtDep.Rows[0]["ItemEwm_Control_Id"].ToString() == "T" ? true : false; ; //二维码管制否
                    this.txtLrUsr.Text = _dtDep.Rows[0]["Usr__Id"].ToString();
                    this.txtCtTime.Text = _dtDep.Rows[0]["Create__Date"].ToString();
                }
            }
            else if(_Edit=="ADD")
            {
               this.cbxLx.SelectedIndex = 0;
            }
            this.textBoxContainButton3.ButtonSelectClick += textBoxContainButton3_Click;
            this.textBoxContainButton1.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton1.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton1.TextLeave += textBoxContainButton1_TextLeave;
            this.textBoxContainButton3.TextEnter += textBoxContainButton3_TextEnter;
            this.textBoxContainButton3.TextLeave += textBoxContainButton3_TextLeave;
        }

        private void textBoxContainButton1_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("ItemUt", "ItemUt_Id", e);
        }

        private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("ItemUt", "ItemUt_Id", e);
        }

        private void textBoxContainButton3_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("ItemKind", "ItemKind_ID", e);
        }

        private void textBoxContainButton3_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("ItemKind", "ItemKind_ID", e);
        }

        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=ItemUt_ID,Desc_01=Desc_01 ";
            string _where = "and (Status_Id In ('130', '130'))";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            _ht = CommomHelper.GetQuery1("ItemUt", _columns, _where);
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
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=ItemKind_ID,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("ItemKind", _columns, " And (Status_Id In ('130', '130')) ");
            }
            else
            {
                string _where = "and Department.Company_Id='" + LoginInfo._Usr_Company + "' And (Status_Id In ('130', '130'))";
                _ht = CommomHelper.GetQuery1("ItemKind", _columns, _where);
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

        private DataTable GetData(string _company_id, string _item_Id)
        {
            string _sql = "select * from Item where Company_Id=@Company_Id and  Item_Id=@Item_Id";
            SqlParameter[] paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@Company_Id", SqlDbType.VarChar, 50);
            paras[0].Value = _company_id;
            paras[1] = new SqlParameter("@Item_Id", SqlDbType.VarChar, 50);
            paras[1].Value = _item_Id;
            DataTable dt = SqlHelper.ExecuteDataTable(_sql, paras);
            return dt;
        }
    }
}
