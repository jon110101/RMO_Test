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

namespace RMO.RmoManagement
{
    public partial class ShippingInfoConfirmOrderManage : Form
    {
        public ShippingInfoConfirmOrderManage()
        {
            InitializeComponent();
        }
        private DataTable _dtBodyEwm = null;

        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }

        private string _Shipping_Id = "";
        public string SRC_Shipping_Id
        {
            set { _Shipping_Id = value; }
            get { return _Shipping_Id; }
        }

        private string _Company_Id = "";
        public string Company_Id
        {
            set { _Company_Id = value; }
            get { return _Company_Id; }
        }
        private string HeadTemp = ""; //表头临时表名
        private string BodyTemp = "";//表身临时表名
        private string Body1Temp = "";//表身临时表名
        private string Body1_Tbl_Name = "";
        private DataSet GetData(string _where)
        {
            StringBuilder _sqlstr = new StringBuilder();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from ShippingInfoConfirmOrder ");
            strSql.Append(_where);
            strSql.Append("select ");
            strSql.Append(" '' as Ewm_Id, * ");
            strSql.Append(" from  ShippingInfoConfirmBody ");
            strSql.Append(_where);
            DataSet _ds = SqlHelper.ExecuteDataSet(strSql.ToString());
            return _ds;
        }

        private void BuildBody1Table()
        {
            Body1_Tbl_Name ="RM02"+ Guid.NewGuid().ToString("N");
            //表身二维码表新增表
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select Body1.* into ");
            strSql.Append("[" + Body1_Tbl_Name + "]");
            strSql.Append(" from (select * from ShippingInfoConfirmBody1 where 1<>1  ) Body1 ;");
            bool IsTrue = SqlHelper.ExecuteQueryTrans(strSql.ToString());
        }

        private void ShippingInfoConfirmOrderManage_Load(object sender, EventArgs e)
        {

            StringBuilder _sqlOnly = new StringBuilder();
            string _IsOnly = "";
            _sqlOnly.Append(" Declare @ReadOnlyId nvarchar(1)");
            _sqlOnly.Append(" Exec dbo.usp_Get_ShippingInfoConfirmOrder_ReadOnlyId   @Company_Id='" + LoginInfo._Usr_Company + "',");
            _sqlOnly.Append("  @Shipping_Id='" + _Shipping_Id + "',  ");
            _sqlOnly.Append("   @ReadOnlyId=@ReadOnlyId Output ");
            _sqlOnly.Append("  Select ReadOnlyId=@ReadOnlyId ");
            DataTable _dtRusultOnly = SqlHelper.ExecuteDataTable(_sqlOnly.ToString());
            if (_dtRusultOnly != null && _dtRusultOnly.Rows.Count > 0 && _dtRusultOnly.Columns.Contains("ReadOnlyId"))
            {
                _IsOnly = _dtRusultOnly.Rows[0]["ReadOnlyId"].ToString();
            }
            if (_IsOnly == "T")
            {
                this.dataGridView1.Enabled = false;
                this.tableLayoutPanel1.Enabled = false;
            }

            foreach (Control _ct in tableLayoutPanel1.Controls)
            {
                if (!(_ct is Label))
                {
                    _ct.Tag = "String";
                     if (_ct.Name == "Shipping_Date" )
                    {
                        _ct.Tag = "Datatime";
                    }
                }
            }

            BuildBody1Table();
            //this.txtNo.ReadOnly = true;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.WindowState = FormWindowState.Maximized;
            this.Usr__Id.Text = LoginInfo._Usr_id;
            this.Shipping_Date.Value = System.DateTime.Now;
            string _where = "";

            if (_Edit == "ADD")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" Declare @Bil_Id nvarchar(60) ");
                strSql.Append(" Exec dbo.usp_GetBilId1 ");
                strSql.Append("       @Company_Id='" + LoginInfo._Usr_Company + "', ");
                strSql.Append("       @Pgm_Tag_Id='SC', ");
                strSql.Append("       @Bill_Date='" + System.DateTime.Now.ToShortDateString() + "', ");
                strSql.Append("       @Bil_Id=@Bil_Id OutPut  ");
                strSql.Append("  Select Bil_Id=@Bil_Id  ");
                DataTable _dtRusult = SqlHelper.ExecuteDataTable(strSql.ToString());
                if (_dtRusult != null && _dtRusult.Rows.Count > 0 && _dtRusult.Columns.Contains("Bil_Id"))
                {
                    this.Shipping_Id.Text = _dtRusult.Rows[0]["Bil_Id"].ToString();
                }

                _where = "where 1<>1 ";
                InsertDataForTemp(_where);
                DataSet _ds = GetData(_where);
                InsertDataForTemp(_where);
                DataTable _dtBody = null;
                if (_ds != null)
                {
                    _dtBody = _ds.Tables[1];
                    _dtBody.Columns["Itm"].AutoIncrement = true;
                    _dtBody.Columns["Itm"].AutoIncrementSeed = 1;
                    _dtBody.Columns["Itm"].AutoIncrementStep = 1;
                    _dtBody.Columns["Itm"].ReadOnly = true;
                    BindingSource bindingSource1 = new BindingSource();
                    bindingSource1.DataSource = _dtBody;
                    this.dataGridView1.DataSource = bindingSource1;
                }
            }
            else
            {
                if (_Edit == "UPD")
                {
                    this.BtnOk.Text = "修改";
                }
                else if (_Edit == "SS")
                {
                    this.BtnOk.Text = "发送";
                }
                else if (_Edit == "CH")
                {
                    this.BtnOk.Text = "撤回";
                }
                this.Shipping_Id.ReadOnly = true;
                _where = "where Company_Id='" + _Company_Id + "' and Shipping_Id='" + _Shipping_Id + "'";
                InsertDataForTemp(_where);
                DataSet _dsUpd = GetData(_where);
                if (_dsUpd != null)
                {
                    DataTable _dtUpd = _dsUpd.Tables[0];
                    if (_dtUpd != null && _dtUpd.Rows.Count > 0)
                    {
                            this.Shipping_Id.ReadOnly = true;
                            this.Shipping_Id.Text = _dtUpd.Rows[0]["Shipping_Id"].ToString();
                            this.Usr__Id.Text = _dtUpd.Rows[0]["Usr__Id"].ToString();
                            this.Shipping_Date.Value = Convert.ToDateTime(_dtUpd.Rows[0]["Shipping_Date"].ToString());
                            this.Status_Id.Text = _dtUpd.Rows[0]["Status_Id"].ToString();
                            this.Order_Id.Text = _dtUpd.Rows[0]["Order_Id"].ToString();
                            this.Delivery_Place.Text = _dtUpd.Rows[0]["Delivery_Place"].ToString();
                            this.Pa_Employee_Id.Text = _dtUpd.Rows[0]["Pa_Employee_Id"].ToString();
                            this.Phone_Number.Text = _dtUpd.Rows[0]["Phone_Number"].ToString();
                            this.Remark.Text = _dtUpd.Rows[0]["Remark"].ToString();
                            this.Recipient_Employee_Ids.Text = _dtUpd.Rows[0]["Recipient_Employee_Ids"].ToString(); // 
                            this.CC_Employee_Ids.Text = _dtUpd.Rows[0]["CC_Employee_Ids"].ToString(); // 
                    }
                    DataTable _dtBody = _dsUpd.Tables[1];
                    if (_dtBody != null)
                    {
                        _dtBody.Columns["ITM"].AutoIncrement = true;
                        _dtBody.Columns["ITM"].AutoIncrementSeed = 1;
                        _dtBody.Columns["ITM"].AutoIncrementStep = 1;
                    }
                    BindingSource bindingSource1 = new BindingSource();
                    bindingSource1.DataSource = _dtBody;
                    this.dataGridView1.DataSource = bindingSource1;
            }

           
                for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
                {
                    string _columnsName = this.dataGridView1.Columns[i].DataPropertyName;
                    if (_columnsName == "ITM" || _columnsName == "Remark" || _columnsName == "Item_Id" || _columnsName == "Qty" ||
                      _columnsName == "Project_Id" || _columnsName == "PackageMethod_Id" || _columnsName == "ItemUnit_Id"
                        || _columnsName == "Warehouse_Id" || _columnsName == "Erp_Sales_Id" || _columnsName == "ItemPrpty_Id"
                        || _columnsName == "Item_Tag_Id" || _columnsName == "Brand_Id" || _columnsName == "Made_Country_Id"
                        || _columnsName == "Kzpm_Id" || _columnsName == "NamePlate_Specification_Id" || _columnsName == "NamePlate_Equals_Ewm_Spec"
                          || _columnsName == "Size_Length_Width_Height" || _columnsName == "Per_Net_Weight" || _columnsName == "Total_Net_Weight"
                          || _columnsName == "Src_Input_Id" || _columnsName == "Ewm_Id")
                    {
                        this.dataGridView1.Columns[i].Visible = true;
                    }
                    else
                    {
                        this.dataGridView1.Columns[i].Visible = false;
                    }
                }
            }

            //收件人
            this.Recipient_Employee_Ids.ButtonSelectClick += textBoxContainButton2_Click;
            this.Recipient_Employee_Ids.TextEnter += textBoxContainButton2_TextEnter;
            this.Recipient_Employee_Ids.TextLeave += textBoxContainButton2_TextEnter;

            //抄送人
            this.CC_Employee_Ids.ButtonSelectClick += textBoxContainButton2_Click;
            this.CC_Employee_Ids.TextEnter += textBoxContainButton2_TextEnter;
            this.CC_Employee_Ids.TextLeave += textBoxContainButton2_TextEnter;

        }

        private void textBoxContainButton2_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=Employee_ID,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            string PgmName = "Employee";
            if (_txt.Name == "Recipient_Employee_Ids" || _txt.Name == "CC_Employee_Ids")
            {
                PgmName = "Employee_MutSelect";
            }
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1(PgmName, _columns, "");
            }
            else
            {
                string _where = "and Employee.Company_Id='" + LoginInfo._Usr_Company + "' And (Status_Id In ('130', '130'))";
                _ht = CommomHelper.GetQuery1(PgmName, _columns, _where);
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
        private void textBoxContainButton2_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("Employee", "Employee_ID", e);
        }
        private void textBoxContainButton2_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("Employee", "Employee_ID", e);
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            InputByPlanningOrderForm _InputForm = new InputByPlanningOrderForm();
            _InputForm.Edit = Edit;
            _InputForm.ForPgm = "SC";
            _InputForm.ForCompany_Id = _Company_Id;
            _InputForm.ForId = _Shipping_Id;
            _InputForm.ForHeadTemp = HeadTemp;
            _InputForm.ForBodyTemp = BodyTemp;

            if (_InputForm.ShowDialog() == DialogResult.Yes)
            {
               DataSet _dsBil = _InputForm._dsInput;
                if (_dsBil != null && _dsBil.Tables[0].Rows.Count > 0)
                {
                    BindingSource _bdSource = new BindingSource();
                    _bdSource = dataGridView1.DataSource as BindingSource;
                    DataTable _dt = new DataTable();
                    if (_bdSource != null)
                    {
                        _dt = _bdSource.DataSource as DataTable;
                    }
                    else
                    {
                        return;
                    }

                    this.CsvPo_Id.Text = _dsBil.Tables[0].Rows[0]["CsvPo_Id"].ToString();
                    for (int i = 0; i < _dsBil.Tables[0].Rows.Count; i++)
                    {
                        DataRow _dr = _dt.NewRow();
                        _dr["Src_Company_Id"] = _dsBil.Tables[0].Rows[i]["Src_Company_Id"];
                        _dr["Src_Input_Id"] = _dsBil.Tables[0].Rows[i]["Src_Bil_Id"];
                        _dr["Src_Itm_Full_Id"] = _dsBil.Tables[0].Rows[i]["Src_Itm_Full_Id"];
                        _dr["Project_Id"] = _dsBil.Tables[0].Rows[i]["Project_Id"];
                        _dr["Warehouse_Id"] = _dsBil.Tables[0].Rows[i]["Warehouse_Id"];
                        _dr["Item_Id"] = _dsBil.Tables[0].Rows[i]["Item_Id"];
                        //_dr["ItemPrpty_Id"] = _dsBil.Tables[0].Rows[i]["ItemPrpty_Id"];
                        _dr["ItemUnit_Id"] = _dsBil.Tables[0].Rows[i]["ItemUnit_Id"];
                        _dr["Qty"] = _dsBil.Tables[0].Rows[i]["Qty"];
                        _dt.Rows.Add(_dr);
                    }
                    _bdSource.EndEdit();
                }
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Shipping_Id.Text))
            {
                MessageBox.Show("录入单号不能为空！");
                return;
            }

            if (_Edit == "ADD")
            {
                if (AddShippingInfoConfirmOrder())
                {
                    afterAudit();
                    this.DialogResult = DialogResult.Yes;
                }
            }
            else if (_Edit == "UPD")
            {
                if (UpdShippingInfoConfirmOrder())
                {
                    afterAudit();
                    this.DialogResult = DialogResult.Yes;
                }
            }
            else if (_Edit == "SS")
            {
                afterSendSh();
                this.DialogResult = DialogResult.Yes;
            }
            else if (_Edit == "CH")
            {
                afterSendCh();
                this.DialogResult = DialogResult.Yes;
            }
        }

        /// <summary>
        /// 送审
        /// </summary>
        private void afterSendSh()
        {
            string _Head_Tbl_Name = "";
            string _Body_Tbl_Name = "";
            try
            {
                _Head_Tbl_Name = "[" + HeadTemp + "]";
                _Body_Tbl_Name = "[" + BodyTemp + "]";
                StringBuilder strSql = new StringBuilder();
                strSql.Append("   Exec dbo.usp_ShippingInfoConfirmOrder_Cmt @Pgm_Id='ShippingInfoConfirmOrder',");
                strSql.Append("   @Company_Id='" + LoginInfo._Usr_Company + "', ");
                strSql.Append("   @Shipping_Id='" + this.Shipping_Id.Text + "',");
                strSql.Append("   @User_Id='" + LoginInfo._Usr_id + "'  ");

                DataTable _dtRusult = SqlHelper.ExecuteDataTable(strSql.ToString());
                if (_dtRusult != null && _dtRusult.Rows.Count > 0)
                {
                    string _msg = "";
                    if (_dtRusult.Columns.Contains("Error_Msg"))
                    {
                        _msg = _dtRusult.Rows[0]["Error_Msg"].ToString();
                    }

                    if (!string.IsNullOrEmpty(_msg))
                    {
                        MessageBox.Show("出现错误：" + _msg);
                        return;
                    }
                    else
                    {
                        Dictionary<string, object> _ht = new Dictionary<string, object>();
                        _ht["SEND_SERVER_IP"] = _dtRusult.Rows[0]["SEND_SERVER_IP"].ToString();
                        _ht["SEND_PORT"] = _dtRusult.Rows[0]["SEND_PORT"].ToString();
                        _ht["SEND_EMAIL_ID"] = _dtRusult.Rows[0]["SEND_EMAIL_ID"].ToString();
                        _ht["SEND_PASSWORD"] = _dtRusult.Rows[0]["SEND_PASSWORD"].ToString();
                        _ht["RECIPIENT_EMAIL_IDS"] = _dtRusult.Rows[0]["RECIPIENT_EMAIL_IDS"].ToString();
                        _ht["CC_EMAIL_IDS"] = _dtRusult.Rows[0]["CC_EMAIL_IDS"].ToString();
                        MailClass.SendLargeMsg(tableLayoutPanel1, dataGridView1, "确认单", _ht);
                    }
                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message.ToString());
            }
            finally
            {
                StringBuilder strDel = new StringBuilder();
                strDel.Append("DROP TABLE " + _Head_Tbl_Name + ";");
                strDel.Append("DROP TABLE " + _Body_Tbl_Name + ";");
                SqlHelper.ExecuteQuery(strDel.ToString());
            }
        }

        /// <summary>
        /// 撤回
        /// </summary>
        private void afterSendCh()
        {
            string _Head_Tbl_Name = "";
            string _Body_Tbl_Name = "";
            try
            {
                _Head_Tbl_Name = "[" + HeadTemp + "]";
                _Body_Tbl_Name = "[" + BodyTemp + "]";

                StringBuilder strSql = new StringBuilder();
                strSql.Append(" Exec dbo.usp_ShippingInfoConfirmOrder_Rev @Pgm_Id='ShippingInfoConfirmOrder',");
                strSql.Append("   @Company_Id='" + LoginInfo._Usr_Company + "', ");
                strSql.Append("   @Shipping_Id='" + this.Shipping_Id.Text + "',");
                strSql.Append("       @Loaded_Head_Tbl_Name='" + _Head_Tbl_Name + "', ");
                strSql.Append("       @Loaded_Body_Tbl_Name='" + _Body_Tbl_Name + "', ");
                strSql.Append("    @User_Id='" + LoginInfo._Usr_id + "'  ");

                DataTable _dtRusult = SqlHelper.ExecuteDataTable(strSql.ToString());
                if (_dtRusult != null && _dtRusult.Rows.Count > 0)
                {
                    string _msg = "";
                    if (_dtRusult.Columns.Contains("Error_Msg"))
                    {
                        _msg = _dtRusult.Rows[0]["Error_Msg"].ToString();
                    }

                    if (!string.IsNullOrEmpty(_msg))
                    {
                        MessageBox.Show("出现错误：" + _msg);
                        return;
                    }
                    else
                    {
                        Dictionary<string, object> _ht = new Dictionary<string, object>();
                        _ht["SEND_SERVER_IP"] = _dtRusult.Rows[0]["SEND_SERVER_IP"].ToString();
                        _ht["SEND_PORT"] = _dtRusult.Rows[0]["SEND_PORT"].ToString();
                        _ht["SEND_EMAIL_ID"] = _dtRusult.Rows[0]["SEND_EMAIL_ID"].ToString();
                        _ht["SEND_PASSWORD"] = _dtRusult.Rows[0]["SEND_PASSWORD"].ToString();
                        _ht["RECIPIENT_EMAIL_IDS"] = _dtRusult.Rows[0]["RECIPIENT_EMAIL_IDS"].ToString();
                        _ht["CC_EMAIL_IDS"] = _dtRusult.Rows[0]["CC_EMAIL_IDS"].ToString();
                        MailClass.SendLargeMsg(tableLayoutPanel1, dataGridView1, "确认单", _ht);
                    }
                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message.ToString());
            }
            finally
            {
                StringBuilder strDel = new StringBuilder();
                strDel.Append("DROP TABLE " + _Head_Tbl_Name + ";");
                strDel.Append("DROP TABLE " + _Body_Tbl_Name + ";");
                SqlHelper.ExecuteQuery(strDel.ToString());
            }
        }

        private void afterAudit()
        {
            string _Head_Tbl_Name = "";
            string _Body_Tbl_Name = "";
            try
            {
                _Head_Tbl_Name = "[" + HeadTemp + "]";
                _Body_Tbl_Name = "[" + BodyTemp + "]";

                StringBuilder strSql = new StringBuilder();

                strSql.Append("   Exec dbo.usp_ShippingInfoConfirmOrder_Sav @Pgm_Id='ShippingInfoConfirmOrder', ");
                strSql.Append("   @Company_Id='" + LoginInfo._Usr_Company + "', ");
                strSql.Append("   @Shipping_Id='" + this.Shipping_Id.Text + "',");
                strSql.Append("   @Loaded_Head_Tbl_Name='" + _Head_Tbl_Name + "', ");
                strSql.Append("   @Loaded_Body_Tbl_Name='" + _Body_Tbl_Name + "' ");

                DataTable _dtRusult = SqlHelper.ExecuteDataTable(strSql.ToString());
                if (_dtRusult != null && _dtRusult.Rows.Count > 0)
                {
                    string _msg = "";
                    if (_dtRusult.Columns.Contains("Error_Msg"))
                    {
                        _msg = _dtRusult.Rows[0]["Error_Msg"].ToString();
                    }

                    if (!string.IsNullOrEmpty(_msg))
                    {
                        MessageBox.Show("出现错误：" + _msg);
                    }
                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message.ToString());
            }
            finally
            {
                StringBuilder strDel = new StringBuilder();
                strDel.Append("DROP TABLE " + _Head_Tbl_Name + ";");
                strDel.Append("DROP TABLE " + _Body_Tbl_Name + ";");
                SqlHelper.ExecuteQuery(strDel.ToString());
            }

        }

        /// <summary>
        /// 插入临时表
        /// </summary>
        /// <param name="Where"></param>
        private void InsertDataForTemp(string Where)
        {
            //表头
            HeadTemp = "RM02" + Guid.NewGuid().ToString("N");
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select Head.* into ");
            strSql.Append("[" + HeadTemp + "]");
            strSql.Append(" from (select * from ShippingInfoConfirmOrder " + Where + "  ) Head ;");

            //表身
            BodyTemp = "RM02" + Guid.NewGuid().ToString("N");
            strSql.Append(" select Body.* into ");
            strSql.Append("[" + BodyTemp + "]");
            strSql.Append(" from (select * from ShippingInfoConfirmBody " + Where + "  ) Body ;");

            //表身二维码表
            Body1Temp ="RM02"+ Guid.NewGuid().ToString("N");
            strSql.Append(" select Body1.* into ");
            strSql.Append("[" + Body1Temp + "]");
            strSql.Append(" from (select * from ShippingInfoConfirmBody1 " + Where + "  ) Body1 ;");
            bool IsTrue = SqlHelper.ExecuteQueryTrans(strSql.ToString());
        }
      

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
        private bool AddShippingInfoConfirmOrder()
        {
            #region 表头
            int _Serial_Itm = 0;
            StringBuilder strGetIdSql = new StringBuilder();
            strGetIdSql.Append(" Declare @Serial_Itm int, @Bil_Id nvarchar(60) ");
            strGetIdSql.Append(" Exec dbo.usp_SetBilId1 ");
            strGetIdSql.Append("       @Company_Id='" + LoginInfo._Usr_Company + "', ");
            strGetIdSql.Append("       @Pgm_Tag_Id='SC', ");
            strGetIdSql.Append("       @Bill_Date='" + System.DateTime.Now.ToShortDateString() + "', ");
            strGetIdSql.Append("        @Serial_Itm=@Serial_Itm Output, ");
            strGetIdSql.Append("       @Bil_Id=@Bil_Id OutPut ");
            strGetIdSql.Append("  Select Serial_Itm=@Serial_Itm, Bil_Id=@Bil_Id ");
            DataTable _dtRusult = SqlHelper.ExecuteDataTable(strGetIdSql.ToString());
            if (_dtRusult != null && _dtRusult.Rows.Count > 0 && _dtRusult.Columns.Contains("Serial_Itm"))
            {
                _Serial_Itm = CommomHelper.ToInt(_dtRusult.Rows[0]["Bil_Id"].ToString());
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ShippingInfoConfirmOrder(");
            strSql.Append("Company_Id,Zan_Save_Id,");
            foreach (Control _ct in tableLayoutPanel1.Controls)
            {
                if (!(_ct is Label) && !(_ct is Button))
                {
                    
                    strSql.Append(_ct.Name);
                    strSql.Append(",");
                }
            }
            strSql.Append("Pgm_Tag_Id,Company__Id,Role__Id,Create__Date,Pgm_Id,Serial_Itm)");
            strSql.Append("VALUES(");
            strSql.Append("'" + LoginInfo._Usr_Company + "',");
            strSql.Append("'T',");
            foreach (Control _ct in tableLayoutPanel1.Controls)
            {
                if (!(_ct is Label) && !(_ct is Button))
                {
                    if (_ct is TextBoxContainButton)
                    {
                        TextBoxContainButton _txtBtn = (TextBoxContainButton)_ct;
                        string _id = string.IsNullOrEmpty(_txtBtn.ID) ? "" : _txtBtn.ID;
                        strSql.Append("'");
                        strSql.Append(_id);
                        strSql.Append("'");
                    }
                    else
                    {
                        if (Convert.ToString(_ct.Tag) == "Datatime")
                        {
                            strSql.Append("'");
                            strSql.Append(Convert.ToDateTime(_ct.Text));
                            strSql.Append("'");
                        }
                        else if (Convert.ToString(_ct.Tag) == "Decimal")
                        {
                            strSql.Append(CommomHelper.ToDecimal(_ct.Text));
                        }
                        else
                        {
                            strSql.Append("'");
                            strSql.Append(_ct.Text);
                            strSql.Append("'");
                        }
                    }
                    strSql.Append(",");
                }
            }
            strSql.Append(" 'SC',");
            strSql.Append("'" + LoginInfo._Usr_Company + "','" + LoginInfo._Usr_Role + "', '"
                + System.DateTime.Now.ToString() + "'");
            strSql.Append(",'ShippingInfoConfirmOrder'," + _Serial_Itm + ")");
            #endregion

            #region 表身
            BindingSource _bdSource = new BindingSource();
            _bdSource = dataGridView1.DataSource as BindingSource;
            DataTable _dtBody = _bdSource.DataSource as DataTable;
            StringBuilder strSqlBody = new StringBuilder();
            if (_dtBody != null)
            {
                for (int i = 0; i < _dtBody.Rows.Count; i++)
                {
                  
                    string _ColumnValue = "";
                    strSqlBody.Append("insert into ShippingInfoConfirmBody(Company_Id,");
                    for (int j = 0; j < _dtBody.Columns.Count; j++)
                    {
                         string _ColumnName = _dtBody.Columns[j].ColumnName;
                         if (_ColumnName == "Company_Id" || _ColumnName == "Ewm_Id" || _ColumnName == "Itm_Full_Id" || _ColumnName == "Shipping_Id" || _ColumnName == "Company__Id" || _ColumnName == "Itm_Full_Id" ||
                          _ColumnName == "Role__Id" || _ColumnName == "Usr__Id" || _ColumnName == "Create__Date" || _ColumnName == "Pgm_Id" ||
                           _ColumnName == "Last_Modify_Company_Id" || _ColumnName == "Last_Modify_Role_Id" || _ColumnName == "Last_Modify_Usr_Id" || _ColumnName == "Last_Modify_Date")
                        {
                            continue;
                        }

                        strSqlBody.Append(_dtBody.Columns[j].ColumnName);
                        strSqlBody.Append(",");
                    }
                    strSqlBody.Append("Shipping_Id,Itm_Full_Id,Company__Id,Role__Id,Usr__Id,Create__Date,Pgm_Id)");
                    strSqlBody.Append("VALUES(");
                    strSqlBody.Append("'" +   LoginInfo._Usr_Company  + "',");
                    for (int j = 0; j < _dtBody.Columns.Count; j++)
                    {
                        string _ColumnName = _dtBody.Columns[j].ColumnName;
                        if (_ColumnName == "Company_Id" || _ColumnName == "Ewm_Id" || _ColumnName == "Itm_Full_Id" || _ColumnName == "Shipping_Id" || _ColumnName == "Company__Id" || _ColumnName == "Itm_Full_Id" ||
                          _ColumnName == "Role__Id" || _ColumnName == "Usr__Id" || _ColumnName == "Create__Date" || _ColumnName == "Pgm_Id" ||
                           _ColumnName == "Last_Modify_Company_Id" || _ColumnName == "Last_Modify_Role_Id" || _ColumnName == "Last_Modify_Usr_Id" || _ColumnName == "Last_Modify_Date")
                        {
                            continue;
                        }
                        _ColumnValue = _dtBody.Rows[i][j].ToString();
                        if (_dtBody.Columns[j].DataType == (new DateTime()).GetType())
                        {
                           if(string.IsNullOrEmpty(_ColumnValue))
                           {
                               _ColumnValue = System.DateTime.Now.ToString();
                           }
                            strSqlBody.Append("'");
                            strSqlBody.Append(Convert.ToDateTime(_ColumnValue));
                            strSqlBody.Append("',");
                        }
                        else if (_dtBody.Columns[j].DataType == (new Decimal()).GetType() || (_dtBody.Columns[j].DataType == (new int()).GetType()))
                        {
                            strSqlBody.Append(CommomHelper.ToDecimal(_ColumnValue));
                            strSqlBody.Append(",");
                        }
                        else
                        {
                            strSqlBody.Append("'");
                            strSqlBody.Append(_ColumnValue);
                            strSqlBody.Append("',");
                        }
                    }
                    strSqlBody.Append("'" + this.Shipping_Id.Text + "', Replace(Cast(NewId() As nvarchar(50)),'-','')," + "'" + LoginInfo._Usr_Company + "','" + LoginInfo._Usr_Role + "','" + LoginInfo._Usr_id + "', '" + System.DateTime.Now.ToString() + "','ShippingInfoConfirmOrder')");

                }
            }


            #endregion
            StringBuilder _strSqlBody1 = new StringBuilder();
            //新增Body1   Body1_Tbl_Name
            #region Body1

            _strSqlBody1.Append("  Update TempBody1  Set   Company_Id='" + LoginInfo._Usr_Company + "', Shipping_Id='" + this.Shipping_Id.Text + "' ");
            _strSqlBody1.Append("  From  [" + Body1_Tbl_Name + "] TempBody1  ");
            _strSqlBody1.Append(" Delete From ShippingInfoConfirmBody1  ");
            _strSqlBody1.Append(" Where  ShippingInfoConfirmBody1.Company_Id='" + LoginInfo._Usr_Company + "'  ");
            _strSqlBody1.Append("  And   ShippingInfoConfirmBody1.Shipping_Id='" + this.Shipping_Id.Text + "' ");
            _strSqlBody1.Append("  Insert Into ShippingInfoConfirmBody1 ");
            _strSqlBody1.Append(" Select * From [" + Body1_Tbl_Name + "]  ");
            #endregion


            bool IsTrue = SqlHelper.ExecuteQueryTrans(strSql + strSqlBody.ToString() + _strSqlBody1.ToString());
            return IsTrue;
        }

        private bool UpdShippingInfoConfirmOrder()
        {
            #region 表头

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Update ShippingInfoConfirmOrder ");
            strSql.Append("set Company_Id='" + _Company_Id + "',");
            foreach (Control _ct in tableLayoutPanel1.Controls)
            {
                if (!(_ct is Label) && !(_ct is Button))
                {
                    if (_ct is TextBoxContainButton)
                    {
                        TextBoxContainButton _txtBtn = (TextBoxContainButton)_ct;
                        string _id = string.IsNullOrEmpty(_txtBtn.ID) ? "" : _txtBtn.ID;
                        strSql.Append(_ct.Name + "='" + _id + "'");
                    }
                    else
                    {
                        if (Convert.ToString(_ct.Tag) == "Datatime")
                        {
                            strSql.Append(_ct.Name + "='" + Convert.ToDateTime(_ct.Text) + "'");
                        }
                        else if (Convert.ToString(_ct.Tag) == "Decimal")
                        {
                            strSql.Append(_ct.Name + "='" + CommomHelper.ToDecimal(_ct.Text) + "'");
                        }
                        else
                        {
                            strSql.Append(_ct.Name + "='" + _ct.Text + "'");
                        }
                    }
                    strSql.Append(",");
                }
            }
            strSql.Append(" Pgm_Tag_Id='SC' ");
            strSql.Append(" where Shipping_Id='" + this.Shipping_Id.Text + "' and Company_Id='" + _Company_Id + "' ");
            #endregion

            #region 表身
            BindingSource _bdSource = new BindingSource();
            _bdSource = dataGridView1.DataSource as BindingSource;
            DataTable _dtBody = _bdSource.DataSource as DataTable;
            StringBuilder strSqlBody = new StringBuilder();
            if (_dtBody != null)
            {
                for (int i = 0; i < _dtBody.Rows.Count; i++)
                {

                    if (string.IsNullOrEmpty(_dtBody.Rows[i]["Itm_Full_Id"].ToString()))
                    {
                        #region 表身新增列
                        string _ColumnValue = "";
                        strSqlBody.Append("If ((select 1 from ShippingInfoConfirmBody where Shipping_Id='" + this.Shipping_Id.Text + "' and Company_Id='" + _Company_Id + "') is null) ");
                        strSqlBody.Append("insert into ShippingInfoConfirmBody(Company_Id,");
                        for (int j = 0; j < _dtBody.Columns.Count; j++)
                        {
                            string _ColumnName = _dtBody.Columns[j].ColumnName;
                            if (_ColumnName == "Company_Id" || _ColumnName == "Ewm_Id" || _ColumnName == "Itm_Full_Id" || _ColumnName == "Shipping_Id" || _ColumnName == "Company__Id" || _ColumnName == "Itm_Full_Id" ||
                              _ColumnName == "Role__Id" || _ColumnName == "Usr__Id" || _ColumnName == "Create__Date" || _ColumnName == "Pgm_Id" ||
                               _ColumnName == "Last_Modify_Company_Id" || _ColumnName == "Last_Modify_Role_Id" || _ColumnName == "Last_Modify_Usr_Id" || _ColumnName == "Last_Modify_Date")
                            {
                                continue;
                            }
                            strSqlBody.Append(_dtBody.Columns[j].ColumnName);
                            strSqlBody.Append(",");
                        }
                        strSqlBody.Append("Shipping_Id,Itm_Full_Id,Company__Id,Role__Id,Usr__Id,Create__Date)");
                        strSqlBody.Append("VALUES(");
                        strSqlBody.Append("'" + LoginInfo._Usr_Company + "',");
                        for (int j = 0; j < _dtBody.Columns.Count; j++)
                        {
                            string _ColumnName = _dtBody.Columns[j].ColumnName;
                            if (_ColumnName == "Company_Id" || _ColumnName == "Ewm_Id" || _ColumnName == "Itm_Full_Id" || _ColumnName == "Shipping_Id" || _ColumnName == "Company__Id" || _ColumnName == "Itm_Full_Id" ||
                              _ColumnName == "Role__Id" || _ColumnName == "Usr__Id" || _ColumnName == "Create__Date" || _ColumnName == "Pgm_Id" ||
                               _ColumnName == "Last_Modify_Company_Id" || _ColumnName == "Last_Modify_Role_Id" || _ColumnName == "Last_Modify_Usr_Id" || _ColumnName == "Last_Modify_Date")
                            {
                                continue;
                            }
                            _ColumnValue = _dtBody.Rows[i][j].ToString();
                            if (_dtBody.Columns[j].DataType == (new DateTime()).GetType())
                            {
                                if (string.IsNullOrEmpty(_ColumnValue))
                                {
                                    _ColumnValue = System.DateTime.Now.ToString();
                                }
                                strSqlBody.Append("'");
                                strSqlBody.Append(Convert.ToDateTime(_ColumnValue));
                                strSqlBody.Append("',");
                            }
                            else if (_dtBody.Columns[j].DataType == (new Decimal()).GetType() || (_dtBody.Columns[j].DataType == (new int()).GetType()))
                            {
                                strSqlBody.Append(CommomHelper.ToDecimal(_ColumnValue));
                                strSqlBody.Append(",");
                            }
                            else
                            {
                                strSqlBody.Append("'");
                                strSqlBody.Append(_ColumnValue);
                                strSqlBody.Append("',");
                            }
                        }
                        strSqlBody.Append("'" + this.Shipping_Id.Text + "',Replace(Cast(NewId() As nvarchar(50)),'-','')," + "'" + LoginInfo._Usr_Company + "','" + LoginInfo._Usr_Role + "','" + LoginInfo._Usr_id + "', '" + System.DateTime.Now.ToString() + "')");
                        #endregion
                    }
                    else
                    {
                        #region 修改表身列
                        string _ColumnValue = "";
                        strSqlBody.Append("Update ShippingInfoConfirmBody  set Company_Id='" + LoginInfo._Usr_Company + "',");
                        for (int j = 0; j < _dtBody.Columns.Count; j++)
                        {
                            string _ColumnName = _dtBody.Columns[j].ColumnName;
                            if (_ColumnName == "Company_Id" || _ColumnName == "Ewm_Id" || _ColumnName == "Itm_Full_Id" || _ColumnName == "Shipping_Id" || _ColumnName == "Company__Id" || _ColumnName == "Itm_Full_Id" ||
                              _ColumnName == "Role__Id" || _ColumnName == "Usr__Id" || _ColumnName == "Create__Date" || _ColumnName == "Pgm_Id" ||
                               _ColumnName == "Last_Modify_Company_Id" || _ColumnName == "Last_Modify_Role_Id" || _ColumnName == "Last_Modify_Usr_Id" || _ColumnName == "Last_Modify_Date")
                            {
                                continue;
                            }
                            _ColumnValue = _dtBody.Rows[i][j].ToString();
                            if (_dtBody.Columns[j].DataType == (new DateTime()).GetType())
                            {
                                strSqlBody.Append(_dtBody.Columns[j].ColumnName + "='" + Convert.ToDateTime(_ColumnValue) + "'");
                            }
                            else if (_dtBody.Columns[j].DataType == (new Decimal()).GetType() || (_dtBody.Columns[j].DataType == (new int()).GetType()))
                            {
                                strSqlBody.Append(_dtBody.Columns[j].ColumnName + "=" + CommomHelper.ToDecimal(_ColumnValue) + "");
                            }
                            else
                            {
                                strSqlBody.Append(_dtBody.Columns[j].ColumnName + "='" + _ColumnValue + "'");
                            }
                            strSqlBody.Append(",");
                        }
                        strSqlBody.Append("  Last_Modify_Company_Id='" + LoginInfo._Usr_Company + "',Last_Modify_Role_Id='" + LoginInfo._Usr_Role + "',Last_Modify_Usr_Id='" +
                            LoginInfo._Usr_id + "',Last_Modify_Date='" + System.DateTime.Now.ToString() + "'");
                        strSqlBody.Append(" where Shipping_Id='" + this.Shipping_Id.Text + "' and Company_Id='" + LoginInfo._Usr_Company + "' ");
                        strSqlBody.Append(" and   Itm_Full_Id='" + _dtBody.Rows[i]["Itm_Full_Id"].ToString() + "' ");
                        #endregion
                    }
                }
            }
            #endregion

            #region Body1
            StringBuilder _strSqlBody1 = new StringBuilder();
            _strSqlBody1.Append("  Update TempBody1  Set   Company_Id='" + LoginInfo._Usr_Company + "', Shipping_Id='" + this.Shipping_Id.Text + "' ");
            _strSqlBody1.Append("  From  [" + Body1_Tbl_Name + "] TempBody1  ");
            _strSqlBody1.Append(" Delete From ShippingInfoConfirmBody1  ");
            _strSqlBody1.Append(" Where  ShippingInfoConfirmBody1.Company_Id='" + LoginInfo._Usr_Company + "'  ");
            _strSqlBody1.Append("  And   ShippingInfoConfirmBody1.Shipping_Id='" + this.Shipping_Id.Text + "' ");
            _strSqlBody1.Append("  Insert Into ShippingInfoConfirmBody1 ");
            _strSqlBody1.Append(" Select * From [" + Body1_Tbl_Name + "] ");
            #endregion



            bool IsTrue = SqlHelper.ExecuteQueryTrans(strSql + strSqlBody.ToString() + _strSqlBody1.ToString());
            return IsTrue;
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.Controls.Clear();//移除所有控件 
            if (e.ColumnIndex.Equals(this.dataGridView1.Columns["Item_Id"].Index) ||
                e.ColumnIndex.Equals(this.dataGridView1.Columns["Warehouse_Id"].Index) ||
                e.ColumnIndex.Equals(this.dataGridView1.Columns["ItemUnit_Id"].Index) ||
                e.ColumnIndex.Equals(this.dataGridView1.Columns["Project_Id"].Index) ||
                e.ColumnIndex.Equals(this.dataGridView1.Columns["PackageMethod_Id"].Index)||
                e.ColumnIndex.Equals(this.dataGridView1.Columns["Ewm_Id"].Index) ||
                e.ColumnIndex.Equals(this.dataGridView1.Columns["snc"].Index)
                )
            {
                System.Windows.Forms.Button btn = new System.Windows.Forms.Button();//创建Buttonbtn 
                btn.Text = "...";//设置button文字 
                btn.Font = new System.Drawing.Font("Arial", 7);//设置文字格式 
                btn.Visible = true;//设置控件允许显示 

                btn.Width = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex,
                                e.RowIndex, true).Height;//获取单元格高并设置为btn的宽 
                btn.Height = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex,
                                e.RowIndex, true).Height;//获取单元格高并设置为btn的高 
                btn.Click += new EventHandler(btn_Click);//为btn添加单击事件 
                this.dataGridView1.Controls.Add(btn);//dataGridView1中添加控件btn 

                btn.Location = new System.Drawing.Point(((this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Right) -
                        (btn.Width)), this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Y);//设置btn显示位置 
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
                int _ColumnIndex = dataGridView1.CurrentCell.ColumnIndex;
                int _RowIndex = dataGridView1.CurrentCell.RowIndex;
                DataGridViewColumn _column = dataGridView1.Columns[_ColumnIndex];
                BindingSource _bdSource = new BindingSource();
                _bdSource = dataGridView1.DataSource as BindingSource;
                if (_column.DataPropertyName == "Warehouse_Id")
                {
                    string _columns = " ID=Warehouse_Id,Desc_01=Desc_01 ";
                    string _id = "";
                    if (LoginInfo._ZT_Admin_Id == "Z")
                    {
                        _id = CommomHelper.GetQuery("Warehouse", _columns, "");
                    }
                    else
                    {
                        string _where = "and Warehouse.Company_Id='" + LoginInfo._Usr_Company + "' And (Status_Id In ('130', '130')) And Is_Lowest='T'";
                        _id = CommomHelper.GetQuery("Warehouse", _columns, _where);
                    }
                    this.dataGridView1.Rows[_RowIndex].Cells[_ColumnIndex].Value = _id;
                    _bdSource.EndEdit();
                }
                else if (_column.DataPropertyName == "Item_Id")
                {
                    string _columns = " ID=Item_Id,Desc_01=Desc_01 ";
                    string _where = "and Item.Company_Id='" + LoginInfo._Usr_Company + "' And (Status_Id In ('130', '130')) And Is_Lowest='T'";
                    string _id = CommomHelper.GetQuery("Item", _columns, _where);
                    this.dataGridView1.Rows[_RowIndex].Cells[_ColumnIndex].Value = _id;
                    _bdSource.EndEdit();
                }
                else if (_column.DataPropertyName == "ItemUnit_Id")
                {
                    string _columns = " ID=ItemUnit_Id,Desc_01=ItemUnit_Id ";
                   // string _where = " And (Status_Id In ('130', '130')) ";
                    string _id = CommomHelper.GetQuery("ItemUnit", _columns, "");
                    this.dataGridView1.Rows[_RowIndex].Cells[_ColumnIndex].Value = _id;
                    _bdSource.EndEdit();
                }

                else if (_column.DataPropertyName == "Project_Id")
                {
                    string _columns = " ID=Project_Id,Desc_01=Desc_01 ";
                    string _where = "and Company_Id='" + LoginInfo._Usr_Company + "' And (Status_Id In ('130', '130')) ";
                    string _id = CommomHelper.GetQuery("Project", _columns, _where);
                    this.dataGridView1.Rows[_RowIndex].Cells[_ColumnIndex].Value = _id;
                    _bdSource.EndEdit();
                }
                else if (_column.DataPropertyName == "PackageMethod_Id")
                {
                    string _where = "and (Status_Id In (''130'', ''130'')) ";
                    string _columns = " ID=PackageMethod_Id,Desc_01=Desc_01 ";
                    string _id = CommomHelper.GetQuery("PackageMethod", _columns, _where);
                    this.dataGridView1.Rows[_RowIndex].Cells[_ColumnIndex].Value = _id;
                    _bdSource.EndEdit();
                }
                else if (_column.DataPropertyName == "Ewm_Id") //序列号和二维码
                {
                    if (!string.IsNullOrEmpty(this.CsvPo_Id.Text) && !string.IsNullOrEmpty(this.dataGridView1.Rows[_RowIndex].Cells["ItemPrpty_Id"].Value.ToString()))
                    {
                        ShippingInfoEwmManage _EwmManage = new ShippingInfoEwmManage();
                        _EwmManage.Edit = _Edit;
                        _EwmManage.Shipping_Id = this.Shipping_Id.Text;
                        _EwmManage.Company_Id = LoginInfo._Usr_Company;
                        _EwmManage.CsvPo_Id = this.CsvPo_Id.Text;
                        _EwmManage.ItemPrpty_Id = this.dataGridView1.Rows[_RowIndex].Cells["ItemPrpty_Id"].Value.ToString();
                        _EwmManage.qty = this.dataGridView1.Rows[_RowIndex].Cells["Qty"].Value.ToString();
                        _EwmManage.itemUt = String.IsNullOrEmpty(this.dataGridView1.Rows[_RowIndex].Cells["ItemUnit_Id"].Value.ToString()) ? "" : this.dataGridView1.Rows[_RowIndex].Cells["ItemUnit_Id"].Value.ToString();
                        _EwmManage.Body1_Tbl_Name = Body1_Tbl_Name;
                        if (_EwmManage.ShowDialog() != DialogResult.OK)
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("客户PO和型号必须输入!");
                    }
                }
                else if (_column.DataPropertyName == "snc") //SNC导入导出
                {
                    if (string.IsNullOrEmpty(this.CsvPo_Id.Text) || string.IsNullOrEmpty(this.dataGridView1.Rows[_RowIndex].Cells["ItemPrpty_Id"].Value.ToString()) || string.IsNullOrEmpty(this.dataGridView1.Rows[_RowIndex].Cells["Qty"].Value.ToString()))
                    {
                        MessageBox.Show("客户PO和型号、数量必须输入!");
                        return;
                    }
                    Form3 f3 = new Form3();
                    f3.PO = this.CsvPo_Id.Text;
                    f3.SEL = this.dataGridView1.Rows[_RowIndex].Cells["ItemPrpty_Id"].Value.ToString();
                    f3.QTY = this.dataGridView1.Rows[_RowIndex].Cells["Qty"].Value.ToString();
                    f3.input = this.dataGridView1.Rows[_RowIndex].Cells["Src_Input_Id"].Value.ToString();
                    if (f3.ShowDialog() != DialogResult.OK)
                    {

                    }
                }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            Barcode b = new Barcode();
            b.PO = this.CsvPo_Id.Text;
            b.SHIP = this.Shipping_Id.Text;
            if (b.ShowDialog() != DialogResult.OK)
            {

            }
            
        }

        private void CC_Employee_Ids_Load(object sender, EventArgs e)
        {

        }
        
        

    }
}
