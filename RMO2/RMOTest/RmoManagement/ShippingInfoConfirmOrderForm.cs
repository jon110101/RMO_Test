using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RMO.RmoManagement
{
    public partial class ShippingInfoConfirmOrderForm : UserControl
    {
       private SubForm _ownerFrom;
       public ShippingInfoConfirmOrderForm(SubForm ownerForm)
        {
            InitializeComponent();
            this._ownerFrom = ownerForm;
        }
       private string HeadTemp = ""; //表头临时表名
       private string BodyTemp = "";//表身临时表名
       private string Body1Temp = "";//表身临时表名

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(string Company_Id, string Shipping_Id)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from ShippingInfoConfirmOrder ");
           strSql.Append(" where Company_Id=@Company_Id and Shipping_Id=@Shipping_Id; ");
           strSql.Append("delete from ShippingInfoConfirmBody ");
           strSql.Append(" where Company_Id=@Company_Id and Shipping_Id=@Shipping_Id; ");
           strSql.Append("delete from ShippingInfoConfirmBody1 ");
           strSql.Append(" where Company_Id=@Company_Id and Shipping_Id=@Shipping_Id; ");
           SqlParameter[] parameters = {
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Shipping_Id", SqlDbType.NVarChar,50)			};
           parameters[0].Value = Company_Id;
           parameters[1].Value = Shipping_Id;

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

       private void BtnQuery_Click(object sender, EventArgs e)
       {
           StringBuilder _NotNullWhere = new StringBuilder();
           _NotNullWhere.Append(" Where 1=1 and Company_Id='" + LoginInfo._Usr_Company + "'");
           if (!string.IsNullOrEmpty(this.dateTimePicker1.Value.ToString()) && !string.IsNullOrEmpty(this.dateTimePicker2.Value.ToString()))
           {
               _NotNullWhere.Append(string.Format("and Shipping_Date between '{0}'  and '{1}'", DateTime.Parse(this.dateTimePicker1.Value.ToShortDateString() + " 00:00:00"), DateTime.Parse(this.dateTimePicker2.Value.ToShortDateString() + " 23:59:59")));
           }
           if (!string.IsNullOrEmpty(this.textBoxContainButton1.ID) && !string.IsNullOrEmpty(this.textBoxContainButton2.ID))
           {
               _NotNullWhere.Append(string.Format("and Shipping_Id between '{0}'  and '{1}'", this.textBoxContainButton1.ID, this.textBoxContainButton2.ID));
           }
           if (comboBox1.SelectedIndex > 0)
           {
               string _Status = (comboBox1.SelectedIndex).ToString();
               _NotNullWhere.Append(string.Format("and Status_Id={0}", _Status));
           }
           QueryData(_NotNullWhere.ToString());
       }

       private void BtnAdd_Click(object sender, EventArgs e)
       {
           ShippingInfoConfirmOrderManage _Manage = new ShippingInfoConfirmOrderManage();
           _Manage.Edit = "ADD";
           if (_Manage.ShowDialog() != DialogResult.OK)
           {
               string _where = " Where 1=1 and Company_Id='" + LoginInfo._Usr_Company + "'";
               QueryData(_where);
           }
       }

       private void BtnUpd_Click(object sender, EventArgs e)
       {
           openManageForm("UPD");
       }

       private void BtnDel_Click(object sender, EventArgs e)
       {
           if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
           {
               if (dataGridView1.CurrentRow != null)
               {
                   DataGridViewRow _dr = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index];
                   if (_dr != null)
                   {
                       string _Company_Id = string.IsNullOrEmpty(_dr.Cells["Company_Id"].Value.ToString()) ? "" : (_dr.Cells["Company_Id"].Value.ToString()).ToString();
                       string _Shipping_Id = string.IsNullOrEmpty((_dr.Cells["Shipping_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["Shipping_Id"].Value.ToString()).ToString();
                       if (!CommomHelper.ChkDel("确认删除单据[" + _Shipping_Id + "]?"))
                       {
                           return;
                       }
                       try
                       {
                           string insertWhere = " Where 1=1 and Company_Id='" + LoginInfo._Usr_Company + "' and Shipping_Id='" + _Shipping_Id + "'";
                           InsertDataForTemp(insertWhere);
                           bool _delOk = false;
                           if (DelteAudit(_Company_Id, _Shipping_Id))
                           {
                               _delOk = Delete(_Company_Id, _Shipping_Id);
                           }
                           if (_delOk)
                           {
                               StringBuilder strGetIdSql = new StringBuilder();
                               strGetIdSql.Append(" Exec dbo.usp_DelBilId1 ");
                               strGetIdSql.Append("       @Company_Id='" + LoginInfo._Usr_Company + "', ");
                               strGetIdSql.Append("       @Pgm_Tag_Id='SC', ");
                               strGetIdSql.Append("       @Bill_Date='" + System.DateTime.Now.ToShortDateString() + "', ");
                               strGetIdSql.Append("        @Serial_Number=1 , ");
                               strGetIdSql.Append("       @Bil_Id='" + _Shipping_Id + "' ");
                               DataTable _dtRusult = SqlHelper.ExecuteDataTable(strGetIdSql.ToString());
                               string _where = " Where 1=1 and Company_Id='" + LoginInfo._Usr_Company + "'";
                               QueryData(_where);
                           }
                       }
                       catch (Exception ex)
                       {
                           MessageBox.Show(ex.ToString());
                       }
                   }
               }
           }
       }

       private void QueryData(string _where)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select ROW_NUMBER() over (order by getdate()) as  ITM,Shipping_Date,Shipping_Id,Order_Id,CsvPo_Id,Status_Id,Usr__Id,Create__Date,Company_Id from ShippingInfoConfirmOrder ");
           strSql.Append(_where);
           DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString());
           dt.Columns["ITM"].AutoIncrement = true;
           dt.Columns["ITM"].AutoIncrementSeed = 1;
           dt.Columns["ITM"].AutoIncrementStep = 1;
           this.dataGridView1.DataSource = dt;
           this.dataGridView1.AllowUserToAddRows = false;
       }
       
       /// <summary>
       /// 插入临时表
       /// </summary>
       /// <param name="Where"></param>
       private void InsertDataForTemp(string Where)
       {
           //表头
           HeadTemp ="RM02"+  Guid.NewGuid().ToString("N");
           StringBuilder strSql = new StringBuilder();
           strSql.Append(" select Head.* into ");
           strSql.Append("[" + HeadTemp + "]");
           strSql.Append(" from (select * from ShippingInfoConfirmOrder " + Where + "  ) Head ;");

           //表身
           BodyTemp ="RM02"+  Guid.NewGuid().ToString("N");
           strSql.Append(" select Body.* into ");
           strSql.Append("[" + BodyTemp + "]");
           strSql.Append(" from (select * from ShippingInfoConfirmBody " + Where + "  ) Body ;");

                //表身
           Body1Temp = "RM02" + Guid.NewGuid().ToString("N");
           strSql.Append(" select Body1.* into ");
           strSql.Append("[" + Body1Temp + "]");
           strSql.Append(" from (select * from ShippingInfoConfirmBody1 " + Where + "  ) Body1 ;");
           bool IsTrue = SqlHelper.ExecuteQueryTrans(strSql.ToString());
       }

       private bool DelteAudit(string Company_Id, string Bil_id)
       {
           bool isEor = true;
           string _Head_Tbl_Name = "";
           string _Body_Tbl_Name = "";
           try
           {
               _Head_Tbl_Name = "[" + HeadTemp + "]";
               _Body_Tbl_Name = "[" + BodyTemp + "]";
               StringBuilder strSql = new StringBuilder();
               strSql.Append(" Exec dbo.usp_ShippingInfoConfirmOrder_Del @Pgm_Id='ShippingInfoConfirmOrder',    ");
               strSql.Append("   @Company_Id='" + Company_Id + "', ");
               strSql.Append("   @Shipping_Id='" + Bil_id + "',");
               strSql.Append("				@Loaded_Head_Tbl_Name='" + _Head_Tbl_Name + "',  ");
               strSql.Append("                  @Loaded_Body_Tbl_Name='" + _Body_Tbl_Name + "'  ");

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
                       isEor = false;
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
               strDel.Append("DROP TABLE [" + HeadTemp + "];");
               strDel.Append("DROP TABLE [" + BodyTemp + "];");
               SqlHelper.ExecuteQuery(strDel.ToString());
           }
           return isEor;
       }

       private void openManageForm(string _Edit)
       {
           if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
           {
               if (dataGridView1.CurrentRow != null)
               {
                   string _Company_Id = "";
                   string _Shipping_Id = "";
                   DataGridViewRow _dr = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index];
                   if (_dr != null)
                   {
                       _Company_Id = string.IsNullOrEmpty(_dr.Cells["Company_Id"].Value.ToString()) ? "" : (_dr.Cells["Company_Id"].Value.ToString()).ToString();
                       _Shipping_Id = string.IsNullOrEmpty((_dr.Cells["Shipping_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["Shipping_Id"].Value.ToString()).ToString();
                   }
                   ShippingInfoConfirmOrderManage _Manage = new ShippingInfoConfirmOrderManage();
                   _Manage.Edit = _Edit;
                   _Manage.SRC_Shipping_Id = _Shipping_Id;
                   _Manage.Company_Id = _Company_Id;
                   if (_Manage.ShowDialog() != DialogResult.OK)
                   {
                       string _where = " Where 1=1 and Company_Id='" + LoginInfo._Usr_Company + "'";
                       QueryData(_where);
                   }
               }
           }
       }

       private void btnSs_Click(object sender, EventArgs e)
       {
           openManageForm("SS");
       }

       private void btnCh_Click(object sender, EventArgs e)
       {
           openManageForm("CH");
       }
   

       private void BtnClose_Click(object sender, EventArgs e)
       {
           _ownerFrom.CloseThisFrom("ShippingInfoConfirmOrder");
       }

       private void ShippingInfoConfirmOrderForm_Load(object sender, EventArgs e)
       {
           this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
           this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
           this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           this.textBoxContainButton1.ButtonSelectClick += textBoxContainButton1_Click;
           this.textBoxContainButton2.ButtonSelectClick += textBoxContainButton1_Click;
           this.textBoxContainButton1.TextEnter += textBoxContainButton1_TextEnter;
           this.textBoxContainButton1.TextLeave += textBoxContainButton1_TextLeave;
           this.textBoxContainButton2.TextEnter += textBoxContainButton1_TextEnter;
           this.textBoxContainButton2.TextLeave += textBoxContainButton1_TextLeave;
       }

       private void textBoxContainButton1_Click(object sender, EventArgs e)
       {
           TextBoxContainButton _txt = (TextBoxContainButton)sender;
           string _columns = " ID=Shipping_Id,Desc_01=Shipping_Id ";
           Dictionary<string, object> _ht = new Dictionary<string, object>();
           if (LoginInfo._ZT_Admin_Id == "Z")
           {
               _ht = CommomHelper.GetQuery1("ShippingInfoConfirmOrder", _columns, "");
           }
           else
           {
               string _where = "and ShippingInfoConfirmOrder.Company_Id='" + LoginInfo._Usr_Company + "'";
               _ht = CommomHelper.GetQuery1("ShippingInfoConfirmOrder", _columns, _where);
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
           _txt.ToFormatStringEnter("ShippingInfoConfirmOrder", "Shipping_Id", e);
       }
       private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
       {
           TextBoxContainButton _txt = (TextBoxContainButton)sender;
           _txt.ToFormatStringLeave("ShippingInfoConfirmOrder", "Shipping_Id", e);
       }

       private void button1_Click(object sender, EventArgs e)
       {  }

    

     


      
    }
}
