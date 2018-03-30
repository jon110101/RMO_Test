using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;

namespace RMO.RmoManagement
{
    public partial class PlanningOrderInfoInputManage : Form
    {
        public PlanningOrderInfoInputManage()
        {
            InitializeComponent();
        }

         private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }

        private string _Input_Id = "";
        public string Src_Input_Id
        {
            set { _Input_Id = value; }
            get { return _Input_Id; }
        }

        private string _CompanyId = "";
        public string Src_CompanyId
        {
            set { _CompanyId = value; }
            get { return _CompanyId; }
        }
        private string HeadTemp = ""; //表头临时表名
        private string BodyTemp = "";//表身临时表名
       

        private void PlanningOrderInfoInputManage_Load(object sender, EventArgs e)
        {
            StringBuilder _sqlOnly = new StringBuilder();
            string _IsOnly="";
            _sqlOnly.Append(" Declare @ReadOnlyId nvarchar(1)");
            _sqlOnly.Append(" Exec dbo.usp_Get_PlanningOrderInfoInput_ReadOnlyId   @Company_Id='" + LoginInfo._Usr_Company + "',");
            _sqlOnly.Append("  @Input_Id='" + _Input_Id + "',  ");
            _sqlOnly.Append("   @ReadOnlyId=@ReadOnlyId Output ");
            _sqlOnly.Append("  Select ReadOnlyId=@ReadOnlyId ");
            DataTable _dtRusultOnly = SqlHelper.ExecuteDataTable(_sqlOnly.ToString());
            if (_dtRusultOnly != null && _dtRusultOnly.Rows.Count > 0 && _dtRusultOnly.Columns.Contains("ReadOnlyId"))
            {
                _IsOnly = _dtRusultOnly.Rows[0]["ReadOnlyId"].ToString();
            }
            if(_IsOnly=="T")
            {
                this.dataGridView1.ReadOnly = true;
                this.tableLayoutPanel1.Enabled = false;
            }                                              
            this.Input_Id.ReadOnly = true;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.WindowState = FormWindowState.Maximized;
            foreach (Control _ct in tableLayoutPanel1.Controls)
            {
                if (!(_ct is Label))
                {
                    _ct.Tag = "String";
                    if (_ct.Name == "Tax_Rate")
                    {
                        _ct.Tag = "Decimal";
                    }
                    else if (_ct.Name == "Input_Date" || _ct.Name == "Order_Date"
                        || _ct.Name == "Planning_Producted_Date" || _ct.Name == "Planning_Shipping_Date")
                    {
                        _ct.Tag = "Datatime";
                    }
                }
            }


            string _where = "";
            DataTable _dtOrder = null;
            DataTable _dtBody = null;
            if (_Edit == "ADD")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" Declare @Bil_Id nvarchar(60) ");
                strSql.Append(" Exec dbo.usp_GetBilId1 ");
                strSql.Append("       @Company_Id='" + LoginInfo._Usr_Company + "', ");
                strSql.Append("       @Pgm_Tag_Id='OI', ");
                strSql.Append("       @Bill_Date='" + System.DateTime.Now.ToShortDateString() + "', ");
                strSql.Append("       @Bil_Id=@Bil_Id OutPut  ");
                strSql.Append("  Select Bil_Id=@Bil_Id  ");
                DataTable _dtRusult = SqlHelper.ExecuteDataTable(strSql.ToString());
                if (_dtRusult != null && _dtRusult.Rows.Count > 0 && _dtRusult.Columns.Contains("Bil_Id"))
                {
                    this.Input_Id.Text = _dtRusult.Rows[0]["Bil_Id"].ToString();
                }
                this.Usr__Id.Text = LoginInfo._Usr_id;
                _where = "Where 1<>1";
                DataSet _ds = GetData(_where);
                InsertDataForTemp(_where);
                if (_ds != null)
                {
                    _dtBody = _ds.Tables[1];
                    _dtBody.Columns["Itm"].AutoIncrement = true;
                    _dtBody.Columns["Itm"].AutoIncrementSeed = 1;
                    _dtBody.Columns["Itm"].AutoIncrementStep = 1;
                    _dtBody.Columns["Itm"].ReadOnly = true;
                }
                BindingSource bindingSource1 = new BindingSource();
                bindingSource1.DataSource = _dtBody;
                this.dataGridView1.DataSource = bindingSource1;
            }
            else
            {
                 if(_Edit=="UPD")
                 {
                     this.BtnOk.Text = "修改";
                 }
                 else if(_Edit=="SS")
                 {
                     this.BtnOk.Text = "发送";
                 }
                 else if (_Edit == "CH")
                 {
                     this.BtnOk.Text = "撤回";
                 }
                this.Input_Id.ReadOnly = true;
                _where = "Where 1=1  and Company_Id='" + _CompanyId + "' and Input_Id='" + _Input_Id + "'";
                DataSet _ds = GetData(_where);
                InsertDataForTemp(_where);
                if (_ds != null)
                {
                    _dtOrder = _ds.Tables[0];
                    _dtBody = _ds.Tables[1];
                    if (_dtOrder != null && _dtOrder.Rows.Count > 0)
                    {
                        //表头数据绑定
                        #region 表头数据绑定
                        this.Input_Date.Value = Convert.ToDateTime(_dtOrder.Rows[0]["Order_Date"].ToString());
                        this.Input_Id.Text = _dtOrder.Rows[0]["Input_Id"].ToString();
                        
                        this.SalesType_Id.Text = _dtOrder.Rows[0]["SalesType_Id"].ToString(); //销售类型
                        this.ProductArea_Id.Text = _dtOrder.Rows[0]["ProductArea_Id"].ToString(); //生产厂区
                        this.Rd_Department_Id.Text = _dtOrder.Rows[0]["Rd_Department_Id"].ToString(); //研发部门
                        this.Sales_Employee_Id.Text = _dtOrder.Rows[0]["Sales_Employee_Id"].ToString(); //业务员
                        this.Pa_Employee_Id.Text = _dtOrder.Rows[0]["Pa_Employee_Id"].ToString();
                        this.Dri_Employee_Id.Text = _dtOrder.Rows[0]["Dri_Employee_Id"].ToString();
                        this.CsvPo_Id.Text = _dtOrder.Rows[0]["CsvPo_Id"].ToString();
                        this.Req_Csv_Id.Text = _dtOrder.Rows[0]["Req_Csv_Id"].ToString(); //
                        this.Invoice_Csv_Id.Text = _dtOrder.Rows[0]["Invoice_Csv_Id"].ToString(); //
                        this.Ar_Csv_Id.Text = _dtOrder.Rows[0]["Ar_Csv_Id"].ToString(); //
                        this.Delivery_Csv_Id.Text = _dtOrder.Rows[0]["Delivery_Csv_Id"].ToString(); //
                        this.Cm_Employee_Id.Text = _dtOrder.Rows[0]["Cm_Employee_Id"].ToString(); //
                        this.Receive_Csv_Id.Text = _dtOrder.Rows[0]["Receive_Csv_Id"].ToString(); //
                        this.Invoice_Create_Method.Text = _dtOrder.Rows[0]["Invoice_Create_Method"].ToString(); //
                        this.PayTerm_Id.Text = _dtOrder.Rows[0]["PayTerm_Id"].ToString(); //
                        this.Cm_Employee_Id.Text = _dtOrder.Rows[0]["Currency_Id"].ToString(); //
                        this.Tax_Rate.Text = _dtOrder.Rows[0]["Tax_Rate"].ToString(); //
                        this.Remark.Text = _dtOrder.Rows[0]["Remark"].ToString(); //
                        this.Usr__Id.Text = _dtOrder.Rows[0]["Usr__Id"].ToString(); //
                        this.Status_Id.Text = _dtOrder.Rows[0]["Status_Id"].ToString(); // 
                        #endregion
                    }
                    BindingSource bindingSource1 = new BindingSource();
                    bindingSource1.DataSource = _dtBody;
                    this.dataGridView1.DataSource = bindingSource1;
                }
            }
            //销售类型
            this.SalesType_Id.ButtonSelectClick += textBoxContainButton4_Click;
            this.SalesType_Id.TextEnter += textBoxContainButton4_TextEnter;
            this.SalesType_Id.TextLeave += textBoxContainButton4_TextLeave;

            //生产厂区
            this.ProductArea_Id.ButtonSelectClick += textBoxContainButton5_Click;
            this.ProductArea_Id.TextEnter += textBoxContainButton5_TextEnter;
            this.ProductArea_Id.TextLeave += textBoxContainButton5_TextLeave;

            //研发部门
            this.Rd_Department_Id.ButtonSelectClick += textBoxContainButton3_Click;
            this.Rd_Department_Id.TextEnter += textBoxContainButton3_TextEnter;
            this.Rd_Department_Id.TextLeave += textBoxContainButton3_TextLeave;

            //业务员
            this.Sales_Employee_Id.ButtonSelectClick += textBoxContainButton2_Click;
            this.Sales_Employee_Id.TextEnter += textBoxContainButton2_TextEnter;
            this.Sales_Employee_Id.TextLeave += textBoxContainButton2_TextLeave;

            //业务类型
            this.BusinessType_Id.ButtonSelectClick += textBoxContainButton1_Click;
            this.BusinessType_Id.TextEnter += textBoxContainButton1_TextEnter;
            this.BusinessType_Id.TextLeave += textBoxContainButton1_TextLeave;

            //需求客户
            this.Req_Csv_Id.ButtonSelectClick += textBoxContainButton6_Click;
            this.Req_Csv_Id.TextEnter += textBoxContainButton6_TextEnter;
            this.Req_Csv_Id.TextLeave += textBoxContainButton6_TextLeave;

            //开票客户
            this.Invoice_Csv_Id.ButtonSelectClick += textBoxContainButton6_Click;
            this.Invoice_Csv_Id.TextEnter += textBoxContainButton6_TextEnter;
            this.Invoice_Csv_Id.TextLeave += textBoxContainButton6_TextLeave;

            //应收客户
            this.Ar_Csv_Id.ButtonSelectClick += textBoxContainButton6_Click;
            this.Ar_Csv_Id.TextEnter += textBoxContainButton6_TextEnter;
            this.Ar_Csv_Id.TextLeave += textBoxContainButton6_TextLeave;

            //送货客户
            this.Delivery_Csv_Id.ButtonSelectClick += textBoxContainButton6_Click;
            this.Delivery_Csv_Id.TextEnter += textBoxContainButton6_TextEnter;
            this.Delivery_Csv_Id.TextLeave += textBoxContainButton6_TextLeave;

            //CM业务员
            this.Cm_Employee_Id.ButtonSelectClick += textBoxContainButton2_Click;
            this.Cm_Employee_Id.TextEnter += textBoxContainButton2_TextEnter;
            this.Cm_Employee_Id.TextLeave += textBoxContainButton2_TextLeave;

            //币别
            this.Currency_Id.ButtonSelectClick += textBoxContainButton11_Click;
            this.Currency_Id.TextEnter += textBoxContainButton11_TextEnter;
            this.Currency_Id.TextLeave += textBoxContainButton11_TextLeave;

            //收件人
            this.Recipient_Employee_Ids.ButtonSelectClick += textBoxContainButton2_Click;
            this.Recipient_Employee_Ids.TextEnter += textBoxContainButton2_TextEnter;
            this.Recipient_Employee_Ids.TextLeave += textBoxContainButton2_TextEnter;

            //抄送人
            this.CC_Employee_Ids.ButtonSelectClick += textBoxContainButton2_Click;
            this.CC_Employee_Ids.TextEnter += textBoxContainButton2_TextEnter;
            this.CC_Employee_Ids.TextLeave += textBoxContainButton2_TextEnter;

        
        }

        #region function
        private DataSet GetData(string _where)
        {
            StringBuilder _sqlstr = new StringBuilder();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * ");
            strSql.Append(" from PlanningOrderInfoInput ");
            strSql.Append(_where);
            strSql.Append("  select Itm,Remark,Item_Id,Qty,Up_Tax,Item_Src_Kind_Id,ItemUnit_Id,Project_Id,Up_No_Tax,Amt_No_Tax,Standard_Money_Sum_Amt_Tax,ProductionType_Id,Has_Src_Order_Id,Warehouse_Id,ItemPrpty_Id,Itm_Full_Id  from PlanningOrderInfoInputBody ");
            strSql.Append(_where);
            DataSet _ds = SqlHelper.ExecuteDataSet(strSql.ToString());
            return _ds;
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
            strSql.Append(" from (select * from PlanningOrderInfoInput " + Where + "  ) Head ;");

            //表身
            BodyTemp = "RM02" + Guid.NewGuid().ToString("N");
            strSql.Append(" select Body.* into ");
            strSql.Append("[" + BodyTemp + "]");
            strSql.Append(" from (select * from PlanningOrderInfoInputBody " + Where + "  ) Body ;");
            bool IsTrue = SqlHelper.ExecuteQueryTrans(strSql.ToString());
        }

        /// <summary>
        /// 新增，修改
        /// </summary>
        private void afterAudit()
        {
            string _Head_Tbl_Name = "";
            string _Body_Tbl_Name = "";
            try
            {
                _Head_Tbl_Name = "[" + HeadTemp + "]";
                _Body_Tbl_Name = "[" + BodyTemp + "]";

                StringBuilder strSql = new StringBuilder();

                strSql.Append("   Exec dbo.usp_PlanningOrderInfoInput_Sav @Pgm_Id='PlanningOrderInfoInput', ");
                strSql.Append("   @Company_Id='" + LoginInfo._Usr_Company + "', ");
                strSql.Append("   @Input_Id='" + this.Input_Id.Text + "',");
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
                        return;
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
                strSql.Append("   Exec dbo.usp_PlanningOrderInfoInput_Cmt @Pgm_Id='PlanningOrderInfoInput',");
                strSql.Append("   @Company_Id='" + LoginInfo._Usr_Company + "', ");
                strSql.Append("   @Input_Id='" + this.Input_Id.Text + "',");
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
                        MailClass.SendLargeMsg(tableLayoutPanel1, dataGridView1, "录入单", _ht);
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
                strSql.Append(" Exec dbo.usp_PlanningOrderInfoInput_Rev @Pgm_Id='PlanningOrderInfoInput',");
                strSql.Append("   @Company_Id='" + LoginInfo._Usr_Company + "', ");
                strSql.Append("   @Input_Id='" + this.Input_Id.Text + "',");
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
                        MailClass.SendLargeMsg(tableLayoutPanel1, dataGridView1, "需求单", _ht);
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

        private bool AddPlanningOrderInfoInput()
        {
            int _Serial_Itm = 0;
            StringBuilder strGetIdSql = new StringBuilder();
            strGetIdSql.Append(" Declare @Serial_Itm int, @Bil_Id nvarchar(60) ");
            strGetIdSql.Append(" Exec dbo.usp_SetBilId1 ");
            strGetIdSql.Append("       @Company_Id='" + LoginInfo._Usr_Company + "', ");
            strGetIdSql.Append("       @Pgm_Tag_Id='OI', ");
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

            #region 表头
            strSql.Append("insert into PlanningOrderInfoInput(");
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
            strSql.Append("'" + LoginInfo._Usr_Company + "','T',");
            foreach (Control _ct in tableLayoutPanel1.Controls)
            {
                if (!(_ct is Label) && !(_ct is Button))
                {
                    if (_ct is TextBoxContainButton)
                    {
                        TextBoxContainButton _txtBtn = (TextBoxContainButton)_ct;
                        string _addid = string.IsNullOrEmpty(_txtBtn._AddID) ? "" : _txtBtn._AddID;
                        string _id = string.IsNullOrEmpty(_txtBtn.ID) ? _addid : _txtBtn.ID;
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
            strSql.Append(" 'OI' ");
            strSql.Append(",'" + LoginInfo._Usr_Company + "','" + LoginInfo._Usr_Role + "', '"
                + System.DateTime.Now.ToString() + "'");
            strSql.Append(",'PlanningOrderInfoInput'," + _Serial_Itm + ")");

            #endregion

            #region 表身


            BindingSource _bdSource = new BindingSource();
            _bdSource = dataGridView1.DataSource as BindingSource;
            DataTable _dt = _bdSource.DataSource as DataTable;
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                string _ColumnValue = "";
                strSql.Append("If ((select 1 from PlanningOrderInfoInputBody where Input_Id='" + this.Input_Id.Text + "' and Company_Id='" + _CompanyId + "') is null) ");
                strSql.Append("insert into PlanningOrderInfoInputBody(Company_Id,");
                for (int j = 0; j < _dt.Columns.Count; j++)
                {
                    if (_dt.Columns[j].ColumnName == "Itm_Full_Id")
                    {
                        continue;
                    }

                    strSql.Append(_dt.Columns[j].ColumnName);
                    strSql.Append(",");
                }
                strSql.Append("Input_Id,Itm_Full_Id,Company__Id,Role__Id,Usr__Id,Create__Date,Pgm_Id)");
                strSql.Append("VALUES(");
                strSql.Append("'" + LoginInfo._Usr_Company + "',");
                for (int j = 0; j < _dt.Columns.Count; j++)
                {
                    if (_dt.Columns[j].ColumnName == "Itm_Full_Id")
                    {
                        continue;
                    }
                    _ColumnValue = _dt.Rows[i][j].ToString();
                    if (_dt.Columns[j].DataType == (new DateTime()).GetType())
                    {
                        strSql.Append("'");
                        strSql.Append(Convert.ToDateTime(_ColumnValue));
                        strSql.Append("',");
                    }
                    else if (_dt.Columns[j].DataType == (new Decimal()).GetType() || (_dt.Columns[j].DataType == (new int()).GetType()))
                    {
                        strSql.Append(CommomHelper.ToDecimal(_ColumnValue));
                        strSql.Append(",");
                    }
                    else
                    {
                        strSql.Append("'");
                        strSql.Append(_ColumnValue);
                        strSql.Append("',");
                    }
                }
                strSql.Append("'" + this.Input_Id.Text + "',Replace(Cast(NewId() As nvarchar(50)),'-','')," + "'" + LoginInfo._Usr_Company + "','" + LoginInfo._Usr_Role + "','" + LoginInfo._Usr_id + "', '" + System.DateTime.Now.ToString() + "','PlanningOrderInfoInput')");
            }
            #endregion

            bool IsTrue = SqlHelper.ExecuteQueryTrans(strSql.ToString());
            return IsTrue;

        }

        private bool UpdPlanningOrderInfoInput()
        {
            StringBuilder strSql = new StringBuilder();

            #region 表头
            strSql.Append(" Update PlanningOrderInfoInput ");
            strSql.Append("set Company_Id='" + _CompanyId + "',");
            foreach (Control _ct in tableLayoutPanel1.Controls)
            {
                if (!(_ct is Label) && !(_ct is Button))
                {
                    if (_ct is TextBoxContainButton)
                    {
                        TextBoxContainButton _txtBtn = (TextBoxContainButton)_ct;
                        string _addid = string.IsNullOrEmpty(_txtBtn._AddID) ? "" : _txtBtn._AddID;
                        string _id = string.IsNullOrEmpty(_txtBtn.ID) ? _addid : _txtBtn.ID;
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
            strSql.Append(" Pgm_Tag_Id='OI' ");
            strSql.Append(" where Input_Id='" + this.Input_Id.Text + "' and Company_Id='" + LoginInfo._Usr_Company + "' ");

            #endregion

            #region 表身
            BindingSource _bdSource = new BindingSource();
            _bdSource = dataGridView1.DataSource as BindingSource;
            DataTable _dt = _bdSource.DataSource as DataTable;
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(this.Input_Id.Text))
                {
                    //int _itm = CommomHelper.ToInt(_dt.Rows[i]["Itm"].ToString());
                    //decimal _qty = CommomHelper.ToDecimal(_dt.Rows[i]["Qty"].ToString());
                    //decimal _Up_Tax = CommomHelper.ToDecimal(_dt.Rows[i]["Up_Tax"].ToString());
                    //decimal _Up_No_Tax = CommomHelper.ToDecimal(_dt.Rows[i]["Up_No_Tax"].ToString());
                    //decimal _Amt_No_Tax = CommomHelper.ToDecimal(_dt.Rows[i]["Amt_No_Tax"].ToString());
                    //decimal _Standard_Money_Sum_Amt_Tax = CommomHelper.ToDecimal(_dt.Rows[i]["Standard_Money_Sum_Amt_Tax"].ToString());

                    //strSql.Append(" Delete from  PlanningOrderInfoInputBody where Company_Id='" + _dt.Rows[i]["Company_Id"].ToString() + "' and  Input_Id=@Input_Id; ");
                    //strSql.Append("If ((select 1 from PlanningOrderInfoInputBody where Input_Id=@Input_Id and Company_Id='" + _dt.Rows[i]["Company_Id"].ToString() + "') is null) ");
                    //strSql.Append("insert into PlanningOrderInfoInputBody(");
                    //strSql.Append("Company_Id,Input_Id,Itm,Itm_Full_Id,Status_Id,Remark,Company__Id,Role__Id,Usr__Id,Create__Date,Item_Id,Qty,Up_Tax,Project_Id,Up_No_Tax,Amt_No_Tax,Standard_Money_Sum_Amt_Tax,ProductionType_Id,Has_Src_Order_Id,Warehouse_Id,ItemPrpty_Id,Item_Src_Kind_Id,ItemUnit_Id )  ");
                    //strSql.Append("VALUES(@Company_Id,@Input_Id," + _itm + ",Replace(Cast(NewId() As nvarchar(50)),'-',''),'100','" + _dt.Rows[i]["Remark"].ToString() + "',  ");
                    //strSql.Append("'" + LoginInfo._Usr_Company + "','" + LoginInfo._Usr_Role + "','" + LoginInfo._Usr_id + "', '" + System.DateTime.Now.ToString() + "', ");
                    //strSql.Append("'" + _dt.Rows[i]["Item_Id"].ToString() + "','" + _qty + "','" + _Up_Tax + "',");
                    //strSql.Append("'" + _dt.Rows[i]["Project_Id"].ToString() + "','" + _Up_No_Tax + "','" + _Amt_No_Tax + "',");
                    //strSql.Append("'" + _Standard_Money_Sum_Amt_Tax + "','" + _dt.Rows[i]["ProductionType_Id"].ToString() + "','" + _dt.Rows[i]["Has_Src_Order_Id"].ToString() + "',");
                    //strSql.Append("'" + _dt.Rows[i]["Warehouse_Id"].ToString() + "','" + _dt.Rows[i]["ItemPrpty_Id"].ToString() + "','" + _dt.Rows[i]["Item_Src_Kind_Id"].ToString() + "','" + _dt.Rows[i]["ItemUnit_Id"].ToString() + "')  ");

                    if (string.IsNullOrEmpty(_dt.Rows[i]["Itm_Full_Id"].ToString()))
                    {                
                        #region 表身新增列
                        string _ColumnValue = "";
                        strSql.Append("If ((select 1 from PlanningOrderInfoInputBody where Input_Id='" + this.Input_Id.Text + "' and Company_Id='" + _CompanyId + "') is null) ");
                        strSql.Append("insert into PlanningOrderInfoInputBody(Company_Id,");
                        for (int j = 0; j < _dt.Columns.Count; j++)
                        {
                            if (_dt.Columns[j].ColumnName == "Itm_Full_Id")
                            {
                                continue;
                            }
                            strSql.Append(_dt.Columns[j].ColumnName);
                            strSql.Append(",");
                        }
                        strSql.Append("Input_Id,Itm_Full_Id,Status_Id,Company__Id,Role__Id,Usr__Id,Create__Date)");
                        strSql.Append("VALUES(");
                        strSql.Append("'" + LoginInfo._Usr_Company + "',");
                        for (int j = 0; j < _dt.Columns.Count; j++)
                        {
                            if (_dt.Columns[j].ColumnName == "Itm_Full_Id")
                            {
                                continue;
                            }
                            _ColumnValue = _dt.Rows[i][j].ToString();
                            if (_dt.Columns[j].DataType == (new DateTime()).GetType())
                            {
                                strSql.Append("'");
                                strSql.Append(Convert.ToDateTime(_ColumnValue));
                                strSql.Append("',");
                            }
                            else if (_dt.Columns[j].DataType == (new Decimal()).GetType() || (_dt.Columns[j].DataType == (new int()).GetType()))
                            {
                                strSql.Append(CommomHelper.ToDecimal(_ColumnValue));
                                strSql.Append(",");
                            }
                            else
                            {
                                strSql.Append("'");
                                strSql.Append(_ColumnValue);
                                strSql.Append("',");
                            }
                        }
                        strSql.Append("'" + this.Input_Id.Text + "',Replace(Cast(NewId() As nvarchar(50)),'-',''),'130'," + "'" + LoginInfo._Usr_Company + "','" + LoginInfo._Usr_Role + "','" + LoginInfo._Usr_id + "', '" + System.DateTime.Now.ToString() + "')");
                        #endregion
                    }
                    else
                    {
                        #region 修改表身列
                        string _ColumnValue = "";
                        strSql.Append("Update PlanningOrderInfoInputBody  set Company_Id='"+LoginInfo._Usr_Company+"',");
                        for (int j = 0; j < _dt.Columns.Count; j++)
                        {
                            _ColumnValue = _dt.Rows[i][j].ToString();
                            if (_dt.Columns[j].DataType == (new DateTime()).GetType())
                            {
                                strSql.Append(_dt.Columns[j].ColumnName + "='" + Convert.ToDateTime(_ColumnValue) + "'");
                            }
                            else if (_dt.Columns[j].DataType == (new Decimal()).GetType() || (_dt.Columns[j].DataType == (new int()).GetType()))
                            {
                                strSql.Append(_dt.Columns[j].ColumnName + "=" + CommomHelper.ToDecimal(_ColumnValue) + "");
                            }
                            else
                            {
                                strSql.Append(_dt.Columns[j].ColumnName + "='" + _ColumnValue + "'");
                            }
                            strSql.Append(",");
                        }
                        strSql.Append("  Last_Modify_Company_Id='" + LoginInfo._Usr_Company + "',Last_Modify_Role_Id='" + LoginInfo._Usr_Role + "',Last_Modify_Usr_Id='" +
                            LoginInfo._Usr_id + "',Last_Modify_Date='" + System.DateTime.Now.ToString() + "'");
                        strSql.Append(" where Input_Id='" + this.Input_Id.Text + "' and Company_Id='" + LoginInfo._Usr_Company + "' ");
                        strSql.Append(" and   Itm_Full_Id='" + _dt.Rows[i]["Itm_Full_Id"].ToString() + "' ");
                        #endregion
                    } 
                }
            }
            #endregion

            bool IsTrue = SqlHelper.ExecuteQueryTrans(strSql.ToString());
            return IsTrue;

        } 
        #endregion

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Input_Id.Text))
            {
                MessageBox.Show("收集单号不能为空！");
                return;
            }
            DataTable _dt = this.dataGridView1.DataSource as DataTable;
            if (_dt != null && _dt.Rows.Count > 0)
            {
                MessageBox.Show("表身不能为空！");
                return;
            }

            if (_Edit == "ADD")
            {
                if (AddPlanningOrderInfoInput())
                {
                    afterAudit();
                    this.DialogResult = DialogResult.Yes;
                }
            }
            else if (_Edit == "UPD")
            {
                if (UpdPlanningOrderInfoInput())
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn _column = dataGridView1.Columns[e.ColumnIndex];
                BindingSource _bdSource = new BindingSource();
                _bdSource = dataGridView1.DataSource as BindingSource;
                if (_column.DataPropertyName == "Warehouse_Id")
                {
                    string _id = "";
                    string _columns = " ID=Warehouse_ID,Desc_01=Desc_01 ";
                    if (LoginInfo._ZT_Admin_Id == "Z")
                    {
                        _id = CommomHelper.GetQuery("Warehouse", _columns, "");
                    }
                    else
                    {
                        string _where = "and Warehouse.Company_Id='" + LoginInfo._Usr_Company + "' And (Status_Id In ('130', '130')) And Is_Lowest='T'";
                        _id = CommomHelper.GetQuery("Warehouse", _columns, _where);
                    }
                    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _id;
                    _bdSource.EndEdit();
                }
                else if (_column.DataPropertyName == "Item_Id")
                {
                    string _columns = " ID=Item_Id,Desc_01=Desc_01 ";
                    string _where = "and Item.Company_Id='" + LoginInfo._Usr_Company + "' And (Status_Id In ('130', '130')) And Is_Lowest='T'";
                    string _id = CommomHelper.GetQuery("Item", _columns, _where);
                    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _id;
                    _bdSource.EndEdit();
                }
                else if (_column.DataPropertyName == "ItemUnit_Id")
                {
                    string _columns = " ID=ItemUnit_Id,Desc_01=ItemUnit_Id ";
                   
                    string _id = CommomHelper.GetQuery("ItemUnit", _columns, "");
                    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _id;
                    _bdSource.EndEdit();
                }

                else if (_column.DataPropertyName == "Item_Src_Kind_Id")
                {
                    string _columns = " ID=ItemSrcKind_Id,Desc_01=Desc_01 ";
                    string _where = " And (Status_Id In ('130', '130')) ";
                    string _id = CommomHelper.GetQuery("ItemSrcKind", _columns, _where);
                    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _id;
                    _bdSource.EndEdit();
                }
                else if (_column.DataPropertyName == "Project_Id")
                {
                    string _columns = " ID=Project_Id,Desc_01=Desc_01 ";
                    string _where = "and Item.Company_Id='" + LoginInfo._Usr_Company + "' And (Status_Id In ('130', '130')) ";
                    string _id = CommomHelper.GetQuery("Project", _columns, _where);
                    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _id;
                    _bdSource.EndEdit();
                }
                else if (_column.DataPropertyName == "ProductionType_Id")
                {
                    string _columns = " ID=ProductionType_Id,Desc_01=Desc_01 ";
                    string _where = "and (Status_Id In (''130'', ''130'')) ";
                    string _id = CommomHelper.GetQuery("ProductionType", _columns, _where);
                    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _id;
                    _bdSource.EndEdit();
                }
            }
        }

        private void btnSh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Input_Id.Text))
            {
                MessageBox.Show("收集单号不能为空！");
                return;
            }
            DataTable _dt = this.dataGridView1.DataSource as DataTable;
            if (_dt != null && _dt.Rows.Count > 0)
            {
                MessageBox.Show("表身不能为空！");
                return;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }


        private void textBoxContainButton4_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=SalesType_ID,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("SalesType", _columns, "");
            }
            else
            {
                string _where = "and SalesType.Company_Id='" + LoginInfo._Usr_Company + "' And (Status_Id In ('130', '130'))";
                _ht = CommomHelper.GetQuery1("SalesType", _columns, _where);
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
        private void textBoxContainButton4_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("SalesType", "SalesType_ID", e);
        }
        private void textBoxContainButton4_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("SalesType", "SalesType_ID", e);
        }


        private void textBoxContainButton5_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=ProductArea_ID,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("ProductArea", _columns, "");
            }
            else
            {
                string _where = "and ProductArea.Company_Id='" + LoginInfo._Usr_Company + "'";
                _ht = CommomHelper.GetQuery1("ProductArea", _columns, _where);
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
        private void textBoxContainButton5_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("ProductArea", "ProductArea_ID", e);
        }
        private void textBoxContainButton5_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("ProductArea", "ProductArea_ID", e);
        }


        private void textBoxContainButton3_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=Department_ID,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("Department", _columns, "");
            }
            else
            {
                string _where = "and Department.Company_Id='" + LoginInfo._Usr_Company + "'";
                _ht = CommomHelper.GetQuery1("Department", _columns, _where);
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
        private void textBoxContainButton3_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("Department", "Department_ID", e);
        }
        private void textBoxContainButton3_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("Department", "Department_ID", e);
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


        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=BusinessType_ID,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("BusinessType", _columns, "");
            }
            else
            {
                string _where = "and BusinessType.Company_Id='" + LoginInfo._Usr_Company + "' And (Status_Id In ('130', '130'))";
                _ht = CommomHelper.GetQuery1("BusinessType", _columns, _where);
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
            _txt.ToFormatStringEnter("BusinessType", "BusinessType_ID", e);
        }
        private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("BusinessType", "BusinessType_ID", e);
        }

        private void textBoxContainButton6_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            string _columns = " ID=Csv_ID,Desc_01=Desc_01 ";
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("Csv", _columns, "");
            }
            else
            {
                string _where = "and Csv.Company_Id='" + LoginInfo._Usr_Company + "' And  Customer_Id='T' And  (Status_Id In ('130', '130'))";
                _ht = CommomHelper.GetQuery1("Csv", _columns, _where);
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
        private void textBoxContainButton6_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("Csv", "Csv_ID", e);
        }
        private void textBoxContainButton6_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("Csv", "Csv_ID", e);
        }


        private void textBoxContainButton11_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=Currency_ID,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("Currency", _columns, "");
            }
            else
            {
                string _where = "and Currency.Company_Id='" + LoginInfo._Usr_Company + "' And (Status_Id In ('130', '130'))";
                _ht = CommomHelper.GetQuery1("Currency", _columns, _where);
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
        private void textBoxContainButton11_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("Currency", "Currency_ID", e);
        }
        private void textBoxContainButton11_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("Currency", "Currency_ID", e);
        }



        private void textBoxContainButton12_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _where = "and (ReqType.Status_Id In ('130', '130'))	";
            string _columns = " ID=ReqType_ID,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            _ht = CommomHelper.GetQuery1("ReqType", _columns, _where);
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
        private void textBoxContainButton12_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("ReqType", "ReqType_ID", e);
        }
        private void textBoxContainButton12_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("ReqType", "ReqType_ID", e);
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            InputByCollectionOrderForm _InputForm = new InputByCollectionOrderForm();
            _InputForm.Edit = Edit;
            _InputForm.Input_Id = _Input_Id;
            _InputForm.ForCompany_Id = _CompanyId;
            _InputForm.ForHeadTemp = HeadTemp;
            _InputForm.ForBodyTemp = BodyTemp;
            
            if (_InputForm.ShowDialog() == DialogResult.Yes)
            {
                DataSet _ds=null;
                try
                {
                    string _Src_pgm_id = "", _Src_Commany_Id = "", _Src_Bil_Id = "", _Src_Itm_Full_Id = "";
                    _Src_pgm_id = _InputForm.Get_Pgm_Id;
                    _Src_Commany_Id = _InputForm.Get_Company_Id;
                    _Src_Bil_Id = _InputForm.Get_Bil_Id;
                    _Src_Itm_Full_Id = _InputForm.Get_Itm_Full_Id;

                    StringBuilder _strSql = new StringBuilder();
                    _strSql.Append(" Select *   From  RequestCollectionOrder  ");
                    _strSql.Append(" Where  Pgm_Id='" + _Src_pgm_id + "'   And   Company_Id='" + _Src_Commany_Id + "'  And   Collection_Id='" + _Src_Bil_Id + "'; ");

                    _strSql.Append(" Select RequestCollectionBody.*,         Item_Spec=Item.Spec   From  RequestCollectionBody    ");
                    _strSql.Append(" Left  Join Item On Item.Company_Id=RequestCollectionBody.Company_Id And Item.Item_Id=RequestCollectionBody.Item_Id  ");
                    _strSql.Append(" Where  RequestCollectionBody.Pgm_Id='" + _Src_pgm_id + "'    And   RequestCollectionBody.Company_Id='" + _Src_Commany_Id + "'   ");
                    _strSql.Append(" And   RequestCollectionBody.Collection_Id='" + _Src_Bil_Id + "'   And   RequestCollectionBody.Itm_Full_Id in (" + _Src_Itm_Full_Id + ") ");

                    _ds = SqlHelper.ExecuteDataSet(_strSql.ToString());
                }
                catch(Exception _ex)
                {
                    MessageBox.Show(_ex.Message.ToString());
                }

                if(_ds!=null&&_ds.Tables.Count>0)
                {
                    DataTable _dtOrder = _ds.Tables[0];
                    DataTable _dtBody = _ds.Tables[1];
                    //表头数据绑定
                    #region 表头数据绑定
                    if (_dtOrder.Rows.Count > 0)
                    {
                        this.Input_Date.Value = Convert.ToDateTime(_dtOrder.Rows[0]["Order_Date"].ToString());
                        this.SalesType_Id.Text = _dtOrder.Rows[0]["SalesType_Id"].ToString(); //销售类型
                        this.ProductArea_Id.Text = _dtOrder.Rows[0]["ProductArea_Id"].ToString(); //生产厂区
                        this.Rd_Department_Id.Text = _dtOrder.Rows[0]["Rd_Department_Id"].ToString(); //研发部门
                        this.Sales_Employee_Id.Text = _dtOrder.Rows[0]["Sales_Employee_Id"].ToString(); //业务员
                        this.Pa_Employee_Id.Text = _dtOrder.Rows[0]["Pa_Employee_Id"].ToString();
                        this.Dri_Employee_Id.Text = _dtOrder.Rows[0]["Dri_Employee_Id"].ToString();
                        this.CsvPo_Id.Text = _dtOrder.Rows[0]["CsvPo_Id"].ToString();
                        this.Req_Csv_Id.Text = _dtOrder.Rows[0]["Req_Csv_Id"].ToString(); //
                        this.Invoice_Csv_Id.Text = _dtOrder.Rows[0]["Invoice_Csv_Id"].ToString(); //
                        this.Ar_Csv_Id.Text = _dtOrder.Rows[0]["Ar_Csv_Id"].ToString(); //
                        this.Delivery_Csv_Id.Text = _dtOrder.Rows[0]["Delivery_Csv_Id"].ToString(); //
                        this.Cm_Employee_Id.Text = _dtOrder.Rows[0]["Cm_Employee_Id"].ToString(); //
                        this.Receive_Csv_Id.Text = _dtOrder.Rows[0]["Receive_Csv_Id"].ToString(); //
                        this.Invoice_Create_Method.Text = _dtOrder.Rows[0]["Invoice_Create_Method"].ToString(); //
                        this.PayTerm_Id.Text = _dtOrder.Rows[0]["PayTerm_Id"].ToString(); //
                        this.Cm_Employee_Id.Text = _dtOrder.Rows[0]["Currency_Id"].ToString(); //
                        this.Tax_Rate.Text = _dtOrder.Rows[0]["Tax_Rate"].ToString(); //
                        this.Remark.Text = _dtOrder.Rows[0]["Remark"].ToString(); //
                        this.Usr__Id.Text = _dtOrder.Rows[0]["Usr__Id"].ToString(); //
                        this.Status_Id.Text = _dtOrder.Rows[0]["Status_Id"].ToString(); // 
                        this.Recipient_Employee_Ids.Text = _dtOrder.Rows[0]["Recipient_Employee_Ids"].ToString(); // 
                        this.CC_Employee_Ids.Text = _dtOrder.Rows[0]["CC_Employee_Ids"].ToString(); // 
                    }
                    #endregion

                    #region 表身数据
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
                    for (int i = 0; i < _dtBody.Rows.Count; i++)
                    {
                        DataRow _dr = _dt.NewRow();
                        for (int j = 0; j < _dtBody.Columns.Count; j++)
                        {
                            string _ColumnName = _dtBody.Columns[j].ColumnName;
                            if(_dt.Columns.Contains(_ColumnName))
                            {
                                _dr[_ColumnName] = _dtBody.Rows[i][j];
                            }
                        }
                        _dt.Rows.Add(_dr);
                    }
                    _bdSource.EndEdit();
                    #endregion
                }

                
            }
        }
        private void CalculateAMTN()
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

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Columns.Contains("Up_No_Tax"))
                {
                    _dt.Rows[i]["Up_No_Tax"] = CommomHelper.ToDecimal(_dt.Rows[i]["Up_Tax"]) * (1 + CommomHelper.ToDecimal(_dt.Rows[i]["Tax_Rate"]) / CommomHelper.ToDecimal((100 * 1.000000)));
                    _dt.Rows[i]["Amt_No_Tax"] = CommomHelper.ToDecimal(_dt.Rows[i]["Up_No_Tax"]) * CommomHelper.ToDecimal(_dt.Rows[i]["Qty"]);
                    _dt.Rows[i]["Standard_Money_Sum_Amt_Tax"] = CommomHelper.ToDecimal(_dt.Rows[i]["Up_Tax"]) * CommomHelper.ToDecimal(_dt.Rows[i]["Qty"]);
                }
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.Controls.Clear();//移除所有控件 
            if (e.ColumnIndex.Equals(this.dataGridView1.Columns["Item_Id"].Index) ||
                e.ColumnIndex.Equals(this.dataGridView1.Columns["Warehouse_Id"].Index) ||
                e.ColumnIndex.Equals(this.dataGridView1.Columns["ItemUnit_Id"].Index) ||
                e.ColumnIndex.Equals(this.dataGridView1.Columns["Item_Src_Kind_Id"].Index) ||
                e.ColumnIndex.Equals(this.dataGridView1.Columns["Project_Id"].Index) ||
                e.ColumnIndex.Equals(this.dataGridView1.Columns["ProductionType_Id"].Index)
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
            if (dataGridView1.CurrentCell.RowIndex >= 0 && dataGridView1.CurrentCell.ColumnIndex >= 0)
            {
                int _ColumnIndex = dataGridView1.CurrentCell.ColumnIndex;
                int _RowIndex = dataGridView1.CurrentCell.RowIndex;
                DataGridViewColumn _column = dataGridView1.Columns[_ColumnIndex];
                BindingSource _bdSource = new BindingSource();
                _bdSource = dataGridView1.DataSource as BindingSource;
                if (_column.DataPropertyName == "Warehouse_Id")
                {
                    string _id = "";
                    string _columns = " ID=Warehouse_ID,Desc_01=Desc_01 ";
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

                    string _id = CommomHelper.GetQuery("ItemUnit", _columns, "");
                    this.dataGridView1.Rows[_RowIndex].Cells[_ColumnIndex].Value = _id;
                    _bdSource.EndEdit();
                }

                else if (_column.DataPropertyName == "Item_Src_Kind_Id")
                {
                    string _columns = " ID=ItemSrcKind_Id,Desc_01=Desc_01 ";
                    string _where = " And (Status_Id In ('130', '130')) ";
                    string _id = CommomHelper.GetQuery("ItemSrcKind", _columns, _where);
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
                else if (_column.DataPropertyName == "ProductionType_Id")
                {
                    string _columns = " ID=ProductionType_Id,Desc_01=Desc_01 ";
                    string _where = "and (Status_Id In (''130'', ''130'')) ";
                    string _id = CommomHelper.GetQuery("ProductionType", _columns, _where);
                    this.dataGridView1.Rows[_RowIndex].Cells[_ColumnIndex].Value = _id;
                    _bdSource.EndEdit();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataTable dt = CsvHelper.GetDgvToTable(dataGridView1);
            
            int count = this.dataGridView1.Rows.Count - 1;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "请选择导出路径";
            sfd.Filter = "xlsx文件|*.xlsx";
            sfd.FileName = this.Input_Id.Text;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Excel.Application app = new Excel.Application();
                Excel.Workbooks wbs = app.Workbooks;
                string s = AppDomain.CurrentDomain.BaseDirectory;
                Excel._Workbook wb = wbs.Add(s + "lurutest.xlsx");
                Excel.Sheets sheets = wb.Sheets;
                Excel._Worksheet worksheet = (Excel._Worksheet)sheets.get_Item(1);
                for (int i = 16; i < 16 + count -1 ; i++)
                {
                    ((Excel.Range)worksheet.Rows[+i, Missing.Value]).Insert(Missing.Value, Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove);
                    worksheet.Cells[i, 10] = "=IF(C8=\"美金\",K" + i + ",IF(C8=\"人民币\",K" + i + "*1.17, \"\"))";
                    worksheet.Cells[i, 12] = "=K" + i + "*H" + i + "";
                    worksheet.Cells[i, 13] = "=IF(J" + i + " =\"\",\"\",J" + i + "*H" + i + ")";
                    worksheet.Cells[2][i] = i - 14;
                }
                worksheet.Cells[4, 3] = this.Input_Id.Text;//订单号
                worksheet.Cells[4, 6] = this.SalesType_Id.Text;//业务类型： 普通销售，免费打样，内部验证
                worksheet.Cells[4, 9] = this.Pa_Employee_Id.Text;//负责PA
                worksheet.Cells[4, 12] = this.Req_Csv_Id.Text;//需求客户名称
                worksheet.Cells[4, 15] = this.Order_Date.Text;//订单日期
                worksheet.Cells[6, 3] = this.ProductArea_Id.Text;//生产厂区：珠海，深圳，苏州，武汉，其他
                worksheet.Cells[6, 6] = this.Rd_Department_Id.Text;//研发部门：BU1-5,业务部，苏州公司，深圳公司，中央研发部
                worksheet.Cells[6, 9] = this.Tax_Rate.Text;//税率
                worksheet.Cells[6, 12] = this.Invoice_Csv_Id.Text;//开票客户名称
                worksheet.Cells[6, 15] = this.Receive_Csv_Id.Text;//收款单位：珠海、运泰利（香港）自动化有限公司
                worksheet.Cells[8, 3] = this.Currency_Id.Text;//币种：美金、人民币、英镑、欧元
                worksheet.Cells[8, 6] = this.Sales_Employee_Id.Text;//业务员
                worksheet.Cells[8, 9] = this.PayTerm_Id.Text;//付款条件:0,30,45,60,90,120,180
                worksheet.Cells[8, 12] = this.Ar_Csv_Id.Text;//应收客户名称
                worksheet.Cells[8, 15] = this.Invoice_Create_Method.Text;//开票方式：增值税普通发票，增值税专用发票，出口发票，形成发票
                worksheet.Cells[10, 3] = this.Planning_Producted_Date.Text;//预完工日期
                worksheet.Cells[10, 6] = this.Planning_Shipping_Date.Text;//预发货日期
                worksheet.Cells[10, 9] = this.CsvPo_Id.Text;//客户PO
                worksheet.Cells[10, 12] = this.Delivery_Csv_Id.Text;//送货客户名称
                worksheet.Cells[12, 3] = this.Dri_Employee_Id.Text;//商务DRI：陈启法，吴佩珊，王雨洁，黄静娜，胡婷，袁钰芳，杨凯迪
                worksheet.Cells[12, 6] = this.Cm_Employee_Id.Text;//CM业务员：
                worksheet.Cells[12, 10] = this.Napa_Id.Text;//是否属于NAPA项目：是，否
                worksheet.Cells[20, 5] = "";//申请人
                worksheet.Cells[20, 8] = "";//部门审核
                worksheet.Cells[20, 13] = "";//业务签收
                worksheet.Cells[22, 3] = this.Remark.Text;//备注



                for (int i = 16; i < 15 + count; i++)
                {
                    for (int j = 2; j < 18; j++)
                    {
                        Excel.Range r = worksheet.Range[worksheet.Cells[i, j], worksheet.Cells[i, j]];

                        r.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous;
                        r.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous;
                        r.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;
                        r.Borders.get_Item(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous;
                    }
                }
                try
                {
                    for (int i = 15; i < 15 + count; i++)
                    {
                        int j = i - 15;
                        worksheet.Cells[i, 2] = i - 14;
                        worksheet.Cells[i, 3] = this.dataGridView1.Rows[j].Cells["Item_Src_Kind_Id"].Value.ToString();
                        worksheet.Cells[i, 4] = this.dataGridView1.Rows[j].Cells["Item_Id"].Value.ToString();
                        worksheet.Cells[i, 5] = this.dataGridView1.Rows[j].Cells["ItemPrpty_Id"].Value.ToString();
                        worksheet.Cells[i, 6] = this.dataGridView1.Rows[j].Cells["ItemPrpty_Id"].Value.ToString();
                        worksheet.Cells[i, 7] = this.dataGridView1.Rows[j].Cells["ItemUnit_Id"].Value.ToString();
                        worksheet.Cells[i, 8] = this.dataGridView1.Rows[j].Cells["Qty"].Value.ToString();
                        worksheet.Cells[i, 9] = this.dataGridView1.Rows[j].Cells["Project_Id"].Value.ToString();
                        //worksheet.Cells[i, 10] = this.dataGridView1.Rows[j].Cells["Up_Tax"].Value.ToString();
                        worksheet.Cells[i, 11] = this.dataGridView1.Rows[j].Cells["Up_No_Tax"].Value.ToString();
                        //worksheet.Cells[i, 12] = this.dataGridView1.Rows[j].Cells["Amt_No_Tax"].Value.ToString();
                        //worksheet.Cells[i, 13] = this.dataGridView1.Rows[j].Cells["Standard_Money_Sum_Amt_Tax"].Value.ToString();
                        worksheet.Cells[i, 14] = this.dataGridView1.Rows[j].Cells["ProductionType_Id"].Value.ToString();
                        worksheet.Cells[i, 15] = this.dataGridView1.Rows[j].Cells["Has_Src_Order_Id"].Value.ToString();
                        //worksheet.Cells[i, 16] = dt.Rows[j][14];
                        worksheet.Cells[i, 17] = this.dataGridView1.Rows[j].Cells["Remark_body"].Value.ToString();

                    }

                }
                catch { 
                    
                }
                

                    //titleRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;//设置边框
                    //titleRange.Borders.LineStyle=10;
                    //titleRange.Borders.Weight = Excel.XlBorderWeight.xlMedium;//常规粗细
                    //titleRange.BorderAround(Excel.XlLineStyle.xlContinuous, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, System.Drawing.);
                    //titleRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous;

                    wb.SaveAs(@"D:\luru1.xlsx", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                               Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                wb.Close(false, Missing.Value, Missing.Value);

                System.GC.Collect();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public static string myToString(object o)
        {
            string s;
            try
            {
                s = o.ToString();
            }
            catch {
                s = "";
            }
            return s;
        }
        
    }

  
}
