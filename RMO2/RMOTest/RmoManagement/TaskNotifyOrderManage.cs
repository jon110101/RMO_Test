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
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace RMO.RmoManagement
{
    public partial class TaskNotifyOrderManage : Form
    {
        public TaskNotifyOrderManage()
        {
            InitializeComponent();
        }


        private DataTable _dtInputBody = null;
        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }

        private string _Notify_Id = "";
        public string Src_Notify_Id
        {
            set { _Notify_Id = value; }
            get { return _Notify_Id; }
        }

        private string _Company_Id = "";
        public string Company_Id
        {
            set { _Company_Id = value; }
            get { return _Company_Id; }
        }


        private string HeadTemp = ""; //表头临时表名
        private string BodyTemp = "";//表身临时表名

        private void TaskNotifyOrderManage_Load(object sender, EventArgs e)
        {

            StringBuilder _sqlOnly = new StringBuilder();
            string _IsOnly = "";
            _sqlOnly.Append(" Declare @ReadOnlyId nvarchar(1)");
            _sqlOnly.Append(" Exec dbo.usp_Get_TaskNotifyOrder_ReadOnlyId   @Company_Id='" + LoginInfo._Usr_Company + "',");
            _sqlOnly.Append("  @Notify_Id='" + _Notify_Id + "',  ");
            _sqlOnly.Append("   @ReadOnlyId=@ReadOnlyId Output ");
            _sqlOnly.Append("  Select ReadOnlyId=@ReadOnlyId ");
            DataTable _dtRusultOnly = SqlHelper.ExecuteDataTable(_sqlOnly.ToString());
            if (_dtRusultOnly != null && _dtRusultOnly.Rows.Count > 0 && _dtRusultOnly.Columns.Contains("ReadOnlyId"))
            {
                _IsOnly = _dtRusultOnly.Rows[0]["ReadOnlyId"].ToString();
            }
            if (_IsOnly == "T")
            {
                this.tableLayoutPanel1.Enabled = false;
                this.tableLayoutPanel3.Enabled = false;
                this.tableLayoutPanel4.Enabled = false;
            }

            foreach (Control _ct in tableLayoutPanel1.Controls)
            {
                if (!(_ct is Label))
                {
                    _ct.Tag = "String";
                    if (_ct.Name == "Qty")
                    {
                        _ct.Tag = "Decimal";
                    }
                    else if (_ct.Name == "Notify_Date" || _ct.Name == "Order_Date")
                    {
                        _ct.Tag = "Datatime";
                    }
                }
            }
            
            this.Notify_Id.ReadOnly = true;
            this.WindowState = FormWindowState.Maximized;
            this.Usr__Id.Text = LoginInfo._Usr_id;
            this.Notify_Date.Value = System.DateTime.Now;
            if(_Edit=="ADD")
            {
                this.Create__Date.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" Declare @Bil_Id nvarchar(60) ");
                strSql.Append(" Exec dbo.usp_GetBilId1 ");
                strSql.Append("       @Company_Id='" + LoginInfo._Usr_Company + "', ");
                strSql.Append("       @Pgm_Tag_Id='TN', ");
                strSql.Append("       @Bill_Date='" + System.DateTime.Now.ToShortDateString() + "', ");
                strSql.Append("       @Bil_Id=@Bil_Id OutPut  ");
                strSql.Append("  Select Bil_Id=@Bil_Id  ");
                DataTable _dtRusult = SqlHelper.ExecuteDataTable(strSql.ToString());
                if (_dtRusult != null && _dtRusult.Rows.Count > 0 && _dtRusult.Columns.Contains("Bil_Id"))
                {
                    this.Notify_Id.Text = _dtRusult.Rows[0]["Bil_Id"].ToString();
                }
                string _where = "where 1<>1";
                DataSet _dsUpd = GetData(_where);
                InsertDataForTemp(_where);
                if (_dsUpd != null)
                {
                    _dtInputBody = _dsUpd.Tables[1].Copy();
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
                this.Notify_Id.ReadOnly = true;
                string _where = "where Company_Id='" + _Company_Id + "' and Notify_Id='" + _Notify_Id + "'";
                InsertDataForTemp(_where);
                DataSet _dsUpd = GetData(_where);
                if (_dsUpd != null)
                {
                    _dtInputBody = _dsUpd.Tables[1].Copy();
                    DataTable _dtUpd = _dsUpd.Tables[0];
                    if (_dtUpd != null && _dtUpd.Rows.Count > 0)
                    {
                        this.Notify_Date.Value = Convert.ToDateTime(_dtUpd.Rows[0]["Notify_Date"].ToString());
                        this.Notify_Id.Text = _dtUpd.Rows[0]["Notify_Id"].ToString();
                        this.Project_Id.Text = _dtUpd.Rows[0]["Project_Id"].ToString();
                        //this.ProjectPrpty_Id.Text = _dtUpd.Rows[0]["ProjectStage_Id"].ToString();
                        this.Item_Id.Text = _dtUpd.Rows[0]["Item_Id"].ToString();
                        this.ItemUnit_Id.Text = _dtUpd.Rows[0]["ItemUnit_Id"].ToString();
                        this.Qty.Text = _dtUpd.Rows[0]["Qty"].ToString();
                        this.CsvPo_Id.Text = _dtUpd.Rows[0]["CsvPo_Id"].ToString();
                        this.Lettering_Information.Text = _dtUpd.Rows[0]["Lettering_Information"].ToString();
                        this.Surface_Pasted_Information.Text = _dtUpd.Rows[0]["Surface_Pasted_Information"].ToString();
                        this.Part_Lettering_Information.Text = _dtUpd.Rows[0]["Part_Lettering_Information"].ToString();
                        this.Project_Progress.Text = _dtUpd.Rows[0]["Project_Progress"].ToString();
                        //this.PCBA_Progress_Management.Text = _dtUpd.Rows[0]["PCBA_Progress_Management"].ToString();
                        //this.Project_Cost.Text = _dtUpd.Rows[0]["Project_Cost"].ToString();
                        this.Order_Date.Value =string.IsNullOrEmpty(_dtUpd.Rows[0]["Order_Date"].ToString())?System.DateTime.Now:Convert.ToDateTime(_dtUpd.Rows[0]["Order_Date"].ToString());
                        this.Project_Task_Set_Employee_Id.Text = _dtUpd.Rows[0]["Project_Task_Set_Employee_Id"].ToString();
                        this.Project_Mng_Grp_Employee_Id.Text = _dtUpd.Rows[0]["Project_Mng_Grp_Employee_Id"].ToString();
                        this.Mech_Tech_Grp_Employee_Id.Text = _dtUpd.Rows[0]["Mech_Tech_Grp_Employee_Id"].ToString();
                        this.Elect_Tech_Grp_Employee_Id.Text = _dtUpd.Rows[0]["Elect_Tech_Grp_Employee_Id"].ToString();
                        this.Software_Dev_Grp_Employee_Id.Text = _dtUpd.Rows[0]["Software_Dev_Grp_Employee_Id"].ToString();
                        this.FAE_Employee_Id.Text = _dtUpd.Rows[0]["FAE_Employee_Id"].ToString();
                        this.General_Manager_Employee_Id.Text = _dtUpd.Rows[0]["General_Manager_Employee_Id"].ToString();
                        this.Remark.Text = _dtUpd.Rows[0]["Remark"].ToString();
                        this.Usr__Id.Text = _dtUpd.Rows[0]["Usr__Id"].ToString();
                        this.Create__Date.Text = _dtUpd.Rows[0]["Create__Date"].ToString();
                        this.Status_Id.Text = _dtUpd.Rows[0]["Status_Id"].ToString();
                    }
                }
            }
            Project_Task_Set_Employee_Id.ButtonSelectClick += textBoxContainButton1_Click;
            this.Project_Task_Set_Employee_Id.TextEnter += textBoxContainButton1_TextEnter;
            this.Project_Task_Set_Employee_Id.TextLeave += textBoxContainButton1_TextLeave;
           

            Project_Mng_Grp_Employee_Id.ButtonSelectClick += textBoxContainButton1_Click;
            this.Project_Mng_Grp_Employee_Id.TextEnter += textBoxContainButton1_TextEnter;
            this.Project_Mng_Grp_Employee_Id.TextLeave += textBoxContainButton1_TextLeave;

            Mech_Tech_Grp_Employee_Id.ButtonSelectClick += textBoxContainButton1_Click;
            this.Mech_Tech_Grp_Employee_Id.TextEnter += textBoxContainButton1_TextEnter;
            this.Mech_Tech_Grp_Employee_Id.TextLeave += textBoxContainButton1_TextLeave;

            Elect_Tech_Grp_Employee_Id.ButtonSelectClick += textBoxContainButton1_Click;
            this.Elect_Tech_Grp_Employee_Id.TextEnter += textBoxContainButton1_TextEnter;
            this.Elect_Tech_Grp_Employee_Id.TextLeave += textBoxContainButton1_TextLeave;

            Software_Dev_Grp_Employee_Id.ButtonSelectClick += textBoxContainButton1_Click;
            this.Software_Dev_Grp_Employee_Id.TextEnter += textBoxContainButton1_TextEnter;
            this.Software_Dev_Grp_Employee_Id.TextLeave += textBoxContainButton1_TextLeave;

            FAE_Employee_Id.ButtonSelectClick += textBoxContainButton1_Click;
            this.FAE_Employee_Id.TextEnter += textBoxContainButton1_TextEnter;
            this.FAE_Employee_Id.TextLeave += textBoxContainButton1_TextLeave;

            General_Manager_Employee_Id.ButtonSelectClick += textBoxContainButton1_Click;
            this.General_Manager_Employee_Id.TextEnter += textBoxContainButton1_TextEnter;
            this.General_Manager_Employee_Id.TextLeave += textBoxContainButton1_TextLeave;

            Item_Id.ButtonSelectClick += textBoxContainButton8_Click;
            this.Item_Id.TextEnter += textBoxContainButton8_TextEnter;
            this.Item_Id.TextLeave += textBoxContainButton8_TextLeave;

            Project_Id.ButtonSelectClick += textBoxContainButton9_Click;
            this.Project_Id.TextEnter += textBoxContainButton9_TextEnter;
            this.Project_Id.TextLeave += textBoxContainButton9_TextLeave;

            ProjectPrpty_Id.ButtonSelectClick += textBoxContainButton10_Click;
            this.ProjectPrpty_Id.TextEnter += textBoxContainButton10_TextEnter;
            this.ProjectPrpty_Id.TextLeave += textBoxContainButton10_TextLeave;

            //收件人
            this.Recipient_Employee_Ids.ButtonSelectClick += textBoxContainButton1_Click;
            this.Recipient_Employee_Ids.TextEnter += textBoxContainButton1_TextEnter;
            this.Recipient_Employee_Ids.TextLeave += textBoxContainButton1_TextEnter;

            //抄送人
            this.CC_Employee_Ids.ButtonSelectClick += textBoxContainButton1_Click;
            this.CC_Employee_Ids.TextEnter += textBoxContainButton1_TextEnter;
            this.CC_Employee_Ids.TextLeave += textBoxContainButton1_TextEnter;
        }



        private void textBoxContainButton1_Click(object sender, EventArgs e)
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

        private void textBoxContainButton1_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("Employee", "Employee_ID", e);
        }
        private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("Employee", "Employee_ID", e);
        }


        private void textBoxContainButton8_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _where = "and  Company_Id='" + LoginInfo._Usr_Company + "' And (Status_Id In ('130', '130')) And Is_Lowest='T'";
            string _columns = " ID=Item_ID,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            _ht = CommomHelper.GetQuery1("Item", _columns, _where);
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
        private void textBoxContainButton8_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("Item", "Item_ID", e);
        }
        private void textBoxContainButton8_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("Item", "Item_ID", e);
        }

        private void textBoxContainButton9_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _where = "and Project.Company_Id='" + LoginInfo._Usr_Company + "' And (Status_Id In ('130', '130')) ";
            string _columns = " ID=Project_ID,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            _ht = CommomHelper.GetQuery1("Project", _columns, _where);
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
        private void textBoxContainButton9_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("Project", "Project_ID", e);
        }
        private void textBoxContainButton9_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("Project", "Project_ID", e);
        }


        private void textBoxContainButton10_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _where = "and  (Status_Id In ('130', '130')) ";
            string _columns = " ID=ProjectPrpty_ID,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            _ht = CommomHelper.GetQuery1("ProjectPrpty", _columns, _where);
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
        private void textBoxContainButton10_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("ProjectStage", "ProjectStage_ID", e);
        }
        private void textBoxContainButton10_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("ProjectStage", "ProjectStage_ID", e);
        }


        private void btnInput_Click(object sender, EventArgs e)
        {
            InputByPlanningOrderForm _InputForm = new InputByPlanningOrderForm();
            _InputForm.Edit = Edit;
            _InputForm.ForPgm = "TN";
            _InputForm.ForCompany_Id = _Company_Id;
            _InputForm.ForId = _Notify_Id;
            _InputForm.ForHeadTemp = HeadTemp;
            _InputForm.ForBodyTemp = BodyTemp;
            if (_InputForm.ShowDialog() == DialogResult.Yes)
            {
                DataSet _dsBil = _InputForm._dsInput;
                if (_dsBil != null && _dsBil.Tables[0].Rows.Count > 0)
                {
                    #region 表头
                    this.Project_Id.Text = _dsBil.Tables[0].Rows[0]["Project_Id"].ToString();
                    this.Item_Id.Text = _dsBil.Tables[0].Rows[0]["Item_Id"].ToString();
                    this.CsvPo_Id.Text = _dsBil.Tables[0].Rows[0]["CsvPo_Id"].ToString();
                    this.Qty.Text = CommomHelper.ToDecimal(_dsBil.Tables[0].Compute("SUM(Qty)", "")).ToString();
                    #endregion
                    #region 表身
                    for (int i = 0; i < _dsBil.Tables[0].Rows.Count; i++)
                    {
                        DataRow _dr = _dtInputBody.NewRow();
                        _dr["Company_Id"] = LoginInfo._Usr_Company;
                        _dr["Notify_Id"] = this.Notify_Id.Text;
                        _dr["ITM"] = (_dtInputBody.Rows.Count + 1);
                        _dr["Src_Pgm_Id"] = _dsBil.Tables[0].Rows[i]["Src_Pgm_Id"];
                        _dr["Src_Company_Id"] = _dsBil.Tables[0].Rows[i]["Src_Company_Id"];
                        _dr["Src_Input_Id"] = _dsBil.Tables[0].Rows[i]["Src_Bil_Id"];
                        _dr["Src_Itm_Full_Id"] = _dsBil.Tables[0].Rows[i]["Src_Itm_Full_Id"];
                        _dr["Warehouse_Id"] = _dsBil.Tables[0].Rows[i]["Warehouse_Id"];
                        _dr["Item_Id"] = _dsBil.Tables[0].Rows[i]["Item_Id"];
                        //_dr["ItemPrpty_Id"] = _dsBil.Tables[0].Rows[i]["ItemPrpty_Id"];
                        _dr["ItemUnit_Id"] = _dsBil.Tables[0].Rows[i]["ItemUnit_Id"];
                        _dr["Qty"] = _dsBil.Tables[0].Rows[i]["Qty"];
                        _dr["Itm_Full_Id"] = _dsBil.Tables[0].Rows[i]["Src_Itm_Full_Id"];
                       
                        _dtInputBody.Rows.Add(_dr);
                    } 
                    #endregion
                }
            }
        }
        

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Notify_Id.Text))
            {
                MessageBox.Show("通知单号不能为空！");
                return;
            }

            if (_Edit == "ADD")
            {
                if (AddTaskNotifyOrder())
                {
                    afterAudit();
                    this.DialogResult = DialogResult.Yes;
                }
            }
            else if (_Edit == "UPD")
            {
                if (UpdTaskNotifyOrder())
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
                strSql.Append("   Exec dbo.usp_TaskNotifyOrder_Cmt @Pgm_Id='TaskNotifyOrder',");
                strSql.Append("   @Company_Id='" + LoginInfo._Usr_Company + "', ");
                strSql.Append("   @Notify_Id='" + this.Notify_Id.Text + "',");
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
                        MailClass.SendLargeMsg(tableLayoutPanel1, null, "通知单", _ht);
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
                strSql.Append(" Exec dbo.usp_TaskNotifyOrder_Rev @Pgm_Id='TaskNotifyOrder',");
                strSql.Append("   @Company_Id='" + LoginInfo._Usr_Company + "', ");
                strSql.Append("   @Notify_Id='" + this.Notify_Id.Text + "',");
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
                        MailClass.SendLargeMsg(tableLayoutPanel1, null, "通知单", _ht);
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private DataSet GetData(string _where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select *   from TaskNotifyOrder ");
            strSql.Append(_where);
            strSql.Append("select ");
            strSql.Append(" * ");
            strSql.Append(" from  TaskNotifyBody ");
            strSql.Append(_where);
            DataSet _ds = SqlHelper.ExecuteDataSet(strSql.ToString());
            return _ds;
        }

        private void InsertDataForTemp(string Where)
        {
            //表头
            HeadTemp = "RM02"+ Guid.NewGuid().ToString("N");
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select Head.* into ");
            strSql.Append("[" + HeadTemp + "]");
            strSql.Append(" from (select * from TaskNotifyOrder " + Where + "  ) Head ;");

            //表身
            BodyTemp ="RM02"+ Guid.NewGuid().ToString("N");
            strSql.Append(" select Body.* into ");
            strSql.Append("[" + BodyTemp + "]");
            strSql.Append(" from (select * from TaskNotifyBody " + Where + "  ) Body ;");
            bool IsTrue = SqlHelper.ExecuteQueryTrans(strSql.ToString());
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

                strSql.Append("   Exec dbo.usp_TaskNotifyOrder_Sav @Pgm_Id='TaskNotifyOrder', ");
                strSql.Append("   @Company_Id='" + LoginInfo._Usr_Company + "', ");
                strSql.Append("   @Notify_Id='" + this.Notify_Id.Text + "',");
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

        private bool AddTaskNotifyOrder()
        {
            #region 表头
            int _Serial_Itm = 0;
            StringBuilder strGetIdSql = new StringBuilder();
            strGetIdSql.Append(" Declare @Serial_Itm int, @Bil_Id nvarchar(60) ");
            strGetIdSql.Append(" Exec dbo.usp_SetBilId1 ");
            strGetIdSql.Append("       @Company_Id='" + LoginInfo._Usr_Company + "', ");
            strGetIdSql.Append("       @Pgm_Tag_Id='TN', ");
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
            strSql.Append("insert into TaskNotifyOrder(");
            strSql.Append("Company_Id,Zan_Save_Id,");
            foreach (Control _ct in tableLayoutPanel1.Controls)
            {
                if (!(_ct is Label) && !(_ct is Button))
                {
                    if (_ct.Name != "txtProjectName" && _ct.Name != "Create__Date")
                    {
                        strSql.Append(_ct.Name);
                        strSql.Append(",");
                    }
                }
            }
            foreach (Control _ct in tableLayoutPanel3.Controls)
            {
                if (!(_ct is Label) && !(_ct is Button))
                {
                    if (_ct.Name != "txtProjectName" && _ct.Name != "Create__Date")
                    {
                        strSql.Append(_ct.Name);
                        strSql.Append(",");
                    }
                }
            }
            foreach (Control _ct in tableLayoutPanel4.Controls)
            {
                if (!(_ct is Label) && !(_ct is Button))
                {
                    if (_ct.Name != "txtProjectName" && _ct.Name != "Create__Date")
                    {
                        strSql.Append(_ct.Name);
                        strSql.Append(",");
                    }
                }
            }

            strSql.Append("Pgm_Tag_Id,Company__Id,Role__Id,Create__Date,Pgm_Id,Serial_Itm)");
            strSql.Append("VALUES(");
            strSql.Append("'" + LoginInfo._Usr_Company + "',");
            strSql.Append("'T',");
            foreach (Control _ct in tableLayoutPanel1.Controls)
            {
                if (!(_ct is Label)&& !(_ct is Button))
                {
                    if (_ct.Name == "txtProjectName" || _ct.Name == "Create__Date")
                    {
                        continue;
                    }
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
            foreach (Control _ct in tableLayoutPanel3.Controls)
            {
                if (!(_ct is Label) && !(_ct is Button))
                {
                    if (_ct.Name == "txtProjectName" || _ct.Name == "Create__Date")
                    {
                        continue;
                    }
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
            foreach (Control _ct in tableLayoutPanel4.Controls)
            {
                if (!(_ct is Label) && !(_ct is Button))
                {
                    if (_ct.Name == "txtProjectName" || _ct.Name == "Create__Date")
                    {
                        continue;
                    }
                    if (_ct is TextBoxContainButton)
                    {
                        TextBoxContainButton _txtBtn = (TextBoxContainButton)_ct;
                        string _id = string.IsNullOrEmpty(_txtBtn.ID) ? "" : _txtBtn.ID;
                        strSql.Append("'");
                        strSql.Append(_txtBtn.ID);
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


            strSql.Append(" 'TN',");
            strSql.Append("'" + LoginInfo._Usr_Company + "','" + LoginInfo._Usr_Role + "', '"
                + System.DateTime.Now.ToString() + "'");
            strSql.Append(",'TaskNotifyOrder'," + _Serial_Itm + ")");
            #endregion

            #region 表身
            DataTable _dtBody = _dtInputBody;
            StringBuilder strSqlBody = new StringBuilder();
            if (_dtBody != null)
            {
                for (int i = 0; i < _dtBody.Rows.Count; i++)
                {
                    string _ColumnValue = "";
                    strSqlBody.Append("insert into TaskNotifyBody(Company_Id,");
                    for (int j = 0; j < _dtBody.Columns.Count; j++)
                    {
                        string _ColumnName = _dtBody.Columns[j].ColumnName;
                        if (_ColumnName == "Company_Id" || _ColumnName == "Itm_Full_Id" || _ColumnName == "Notify_Id" || _ColumnName == "Itm_Full_Id" ||_ColumnName=="Company__Id"||
                            _ColumnName == "Role__Id" || _ColumnName == "Usr__Id" || _ColumnName == "Create__Date" || _ColumnName == "Pgm_Id" ||
                             _ColumnName == "Last_Modify_Company_Id" || _ColumnName == "Last_Modify_Role_Id" || _ColumnName == "Last_Modify_Usr_Id" || _ColumnName == "Last_Modify_Date")
                        {
                            continue;
                        }

                        strSqlBody.Append(_dtBody.Columns[j].ColumnName);
                        strSqlBody.Append(",");
                    }
                    strSqlBody.Append("Notify_Id,Itm_Full_Id,Company__Id,Role__Id,Usr__Id,Create__Date,Pgm_Id)");
                    strSqlBody.Append("VALUES(");
                    strSqlBody.Append("'" + LoginInfo._Usr_Company + "',");
                    for (int j = 0; j < _dtBody.Columns.Count; j++)
                    {
                        string _ColumnName = _dtBody.Columns[j].ColumnName;
                        if (_ColumnName == "Company_Id"||_ColumnName == "Itm_Full_Id" || _ColumnName == "Notify_Id" || _ColumnName == "Itm_Full_Id" || _ColumnName == "Company__Id" ||
                           _ColumnName == "Role__Id" || _ColumnName == "Usr__Id" || _ColumnName == "Create__Date" || _ColumnName == "Pgm_Id"||
                            _ColumnName == "Last_Modify_Company_Id" || _ColumnName == "Last_Modify_Role_Id" || _ColumnName == "Last_Modify_Usr_Id" || _ColumnName == "Last_Modify_Date")
                        {
                            continue;
                        }
                        _ColumnValue = _dtBody.Rows[i][j].ToString();
                        if (_dtBody.Columns[j].DataType == (new DateTime()).GetType())
                        {
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
                    strSqlBody.Append("'" + this.Notify_Id.Text + "',Replace(Cast(NewId() As nvarchar(50)),'-','')," + "'" + LoginInfo._Usr_Company + "','" + LoginInfo._Usr_Role + "','" + LoginInfo._Usr_id + "', '" + System.DateTime.Now.ToString() + "','ShippingInfoConfirmOrder')");


                }
            }
            #endregion

            bool IsTrue = SqlHelper.ExecuteQueryTrans(strSql + strSqlBody.ToString());
            return IsTrue;
        }

        private bool UpdTaskNotifyOrder()
        {
            #region 表头
           
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Update TaskNotifyOrder ");
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
            foreach (Control _ct in tableLayoutPanel3.Controls)
            {
                if (!(_ct is Label) && !(_ct is Button))
                {
                    if (_ct is TextBoxContainButton)
                    {
                        TextBoxContainButton _txtBtn = (TextBoxContainButton)_ct;
                        string _id = string.IsNullOrEmpty(_txtBtn.ID) ? "" : _txtBtn.ID;
                        strSql.Append(_ct.Name + "='" + _txtBtn.ID + "'");
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
            foreach (Control _ct in tableLayoutPanel4.Controls)
            {
                if (!(_ct is Label) && !(_ct is Button))
                {
                    if (_ct is TextBoxContainButton)
                    {
                        TextBoxContainButton _txtBtn = (TextBoxContainButton)_ct;
                        string _id = string.IsNullOrEmpty(_txtBtn.ID) ? "" : _txtBtn.ID;
                        strSql.Append(_ct.Name + "='" + _txtBtn.ID + "'");
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
            strSql.Append(" Pgm_Tag_Id='TN' ");
            strSql.Append(" where Notify_Id='" + this.Notify_Id.Text + "' and Company_Id='" + _Company_Id + "' ");

         

            #endregion
            #region 表身
            DataTable _dtBody = _dtInputBody;
            StringBuilder strSqlBody = new StringBuilder();
            if (_dtBody != null)
            {
                for (int i = 0; i < _dtBody.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(_dtBody.Rows[i]["Company_Id"].ToString()) && !string.IsNullOrEmpty(_dtBody.Rows[i]["Notify_Id"].ToString()))
                    {
                        if (string.IsNullOrEmpty(_dtBody.Rows[i]["Itm_Full_Id"].ToString()))
                        {
                            #region 表身新增列
                            string _ColumnValue = "";
                            strSqlBody.Append("If ((select 1 from TaskNotifyBody where Notify_Id='" + this.Notify_Id.Text + "' and Company_Id='" + _Company_Id + "') is null) ");
                            strSqlBody.Append("insert into TaskNotifyBody(Company_Id,");
                            for (int j = 0; j < _dtBody.Columns.Count; j++)
                            {
                                string _ColumnName = _dtBody.Columns[j].ColumnName;
                                if (_ColumnName=="Company_Id"||_ColumnName == "Itm_Full_Id" || _ColumnName == "Notify_Id" || _ColumnName == "Itm_Full_Id" || _ColumnName == "Company__Id" ||
                          _ColumnName == "Role__Id" || _ColumnName == "Usr__Id" || _ColumnName == "Create__Date" || _ColumnName == "Pgm_Id" ||
                           _ColumnName == "Last_Modify_Company_Id" || _ColumnName == "Last_Modify_Role_Id" || _ColumnName == "Last_Modify_Usr_Id" || _ColumnName == "Last_Modify_Date")
                                {
                                    continue;
                                }
                                strSqlBody.Append(_dtBody.Columns[j].ColumnName);
                                strSqlBody.Append(",");
                            }
                            strSqlBody.Append("Notify_Id,Itm_Full_Id,Company__Id,Role__Id,Usr__Id,Create__Date)");
                            strSqlBody.Append("VALUES(");
                            strSqlBody.Append("'" + LoginInfo._Usr_Company + "',");
                            for (int j = 0; j < _dtBody.Columns.Count; j++)
                            {
                                string _ColumnName = _dtBody.Columns[j].ColumnName;
                                if (_ColumnName == "Company_Id" || _ColumnName == "Itm_Full_Id" || _ColumnName == "Notify_Id" || _ColumnName == "Itm_Full_Id" || _ColumnName == "Company__Id" ||
                          _ColumnName == "Role__Id" || _ColumnName == "Usr__Id" || _ColumnName == "Create__Date" || _ColumnName == "Pgm_Id" ||
                           _ColumnName == "Last_Modify_Company_Id" || _ColumnName == "Last_Modify_Role_Id" || _ColumnName == "Last_Modify_Usr_Id" || _ColumnName == "Last_Modify_Date")
                                {
                                    continue;
                                }
                                _ColumnValue = _dtBody.Rows[i][j].ToString();
                                if (_dtBody.Columns[j].DataType == (new DateTime()).GetType())
                                {
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
                            strSqlBody.Append("'" + this.Notify_Id.Text + "',Replace(Cast(NewId() As nvarchar(50)),'-','')," + "'" + LoginInfo._Usr_Company + "','" + LoginInfo._Usr_Role + "','" + LoginInfo._Usr_id + "', '" + System.DateTime.Now.ToString() + "')");
                            #endregion
                        }
                        else
                        {
                            #region 修改表身列
                            string _ColumnValue = "";
                            strSqlBody.Append("Update TaskNotifyBody  set Company_Id='" + LoginInfo._Usr_Company + "',");
                            for (int j = 0; j < _dtBody.Columns.Count; j++)
                            {
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
                            strSqlBody.Append(" where Notify_Id='" + this.Notify_Id.Text + "' and Company_Id='" + LoginInfo._Usr_Company + "' ");
                            strSqlBody.Append(" and   Itm_Full_Id='" + _dtBody.Rows[i]["Itm_Full_Id"].ToString() + "' ");
                            #endregion
                        }

                    }
                }
            } 
            #endregion

            bool IsTrue = SqlHelper.ExecuteQueryTrans(strSqlBody + strSql.ToString());
            return IsTrue;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "请选择导出路径";
            sfd.Filter = "xlsx文件|*.xlsx";
            sfd.FileName = this.Notify_Id.Text;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Excel.Application app = new Excel.Application();
                Excel.Workbooks wbs = app.Workbooks;
                string s = AppDomain.CurrentDomain.BaseDirectory;
                Excel._Workbook wb = wbs.Add(s + "renwutest.xlsx");
                Excel.Sheets sheets = wb.Sheets;
                Excel._Worksheet worksheet = (Excel._Worksheet)sheets.get_Item(1);
                
                worksheet.Cells[4, 3] = this.txtProjectName.Text;//项目名称
                worksheet.Cells[5, 3] = this.Qty.Text;//数量
                worksheet.Cells[5, 5] = "";
                worksheet.Cells[5, 9] = this.CsvPo_Id.Text;//客户订单号
                worksheet.Cells[28, 2] = this.Order_Date.Text;//
                worksheet.Cells[28, 3] = this.Project_Task_Set_Employee_Id.Text;//项目经理
                worksheet.Cells[28, 4] = this.Project_Mng_Grp_Employee_Id.Text;//项目管理组
                worksheet.Cells[28, 5] = this.Mech_Tech_Grp_Employee_Id.Text;//机械管理组
                worksheet.Cells[28, 6] = this.Elect_Tech_Grp_Employee_Id.Text;//电子组
                worksheet.Cells[28, 7] = this.Software_Dev_Grp_Employee_Id.Text;//软件组
                worksheet.Cells[28, 8] = this.FAE_Employee_Id.Text;//FAE
                worksheet.Cells[28, 9] = this.General_Manager_Employee_Id.Text;//总经理
                worksheet.Cells[7, 5] = this.Item_Id.Text;//母件编码

                //铭牌
                worksheet.Cells[8, 5] = (this.Lettering_Information.Text.Split('\n')[0]).Split('：')[1];
                worksheet.Cells[9, 5] = (this.Lettering_Information.Text.Split('\n')[1]).Split('：')[1];
                worksheet.Cells[10, 5] = (this.Lettering_Information.Text.Split('\n')[2]).Split('：')[1];
                worksheet.Cells[11, 5] = (this.Lettering_Information.Text.Split('\n')[3]).Split('：')[1];
                worksheet.Cells[12, 5] = (this.Lettering_Information.Text.Split('\n')[4]).Split('：')[1];
                worksheet.Cells[13, 5] = (this.Lettering_Information.Text.Split('\n')[5]).Split('：')[1];
                worksheet.Cells[14, 5] = (this.Lettering_Information.Text.Split('\n')[6]).Split('：')[1];

                //面贴
                worksheet.Cells[15, 5] = (this.Surface_Pasted_Information.Text.Split('\n')[0]).Split('：')[1];
                worksheet.Cells[15, 7] = (this.Surface_Pasted_Information.Text.Split('\n')[1]).Split('：')[1];
                
                //零件
                worksheet.Cells[16, 5] = (this.Part_Lettering_Information.Text.Split('\n')[0]).Split('：')[1];
                worksheet.Cells[16, 7] = (this.Part_Lettering_Information.Text.Split('\n')[1]).Split('：')[1];
                worksheet.Cells[17, 5] = (this.Part_Lettering_Information.Text.Split('\n')[2]).Split('：')[1];
                worksheet.Cells[17, 7] = (this.Part_Lettering_Information.Text.Split('\n')[3]).Split('：')[1];

                //项目进度
                worksheet.Cells[18, 4] = (this.Project_Progress.Text.Split('\n')[0]).Split('：')[1];
                worksheet.Cells[19, 4] = (this.Project_Progress.Text.Split('\n')[1]).Split('：')[1];
                worksheet.Cells[20, 4] = (this.Project_Progress.Text.Split('\n')[2]).Split('：')[1];
                worksheet.Cells[21, 4] = (this.Project_Progress.Text.Split('\n')[3]).Split('：')[1];

                //项目质量
                worksheet.Cells[24, 4] = this.Project_Quality.Text.Split('\n')[0];
                worksheet.Cells[25, 4] = this.Project_Quality.Text.Split('\n')[1];
                worksheet.Cells[26, 4] = this.Project_Quality.Text.Split('\n')[2];


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
    }
}
