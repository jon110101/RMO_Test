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
    public partial class RequestCollectionOrderForm : UserControl
    {
        private SubForm _ownerFrom;
        public RequestCollectionOrderForm(SubForm ownerForm)
        {
            InitializeComponent();
            this._ownerFrom = ownerForm;
        }
        private string HeadTemp = ""; //表头临时表名
        private string BodyTemp = "";//表身临时表名

        #region function

        private void InsertDataForTemp(string Where)
        {
            //表头
            HeadTemp = "RM02" + Guid.NewGuid().ToString("N");
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select Head.* into ");
            strSql.Append("[" + HeadTemp + "]");
            strSql.Append(" from (select * from RequestCollectionOrder " + Where + "  ) Head ;");

            //表身
            BodyTemp = "RM02" + Guid.NewGuid().ToString("N");
            strSql.Append(" select Body.* into ");
            strSql.Append("[" + BodyTemp + "]");
            strSql.Append(" from (select * from RequestCollectionBody " + Where + "  ) Body ;");
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
                strSql.Append(" Exec dbo.usp_RequestCollectionOrder_Del @Pgm_Id='RequestCollectionOrder',    ");
                strSql.Append("   @Company_Id='" + Company_Id + "', ");
                strSql.Append("   @Collection_Id='" + Bil_id + "',");
                strSql.Append("				@Loaded_Head_Tbl_Name='" + HeadTemp + "',  ");
                strSql.Append("                  @Loaded_Body_Tbl_Name='" + BodyTemp + "'  ");

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
                        isEor=false;
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
        private void QueryData(string _where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ROW_NUMBER() over (order by getdate()) as  ITM,  Company_Id,Collection_Id,ReqType_Id,SalesType_Id,CsvPo_Id,Req_Csv_Id,Status_Id,Usr__Id,Create__Date from RequestCollectionOrder ");
            strSql.Append(_where);
            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            dt.Columns["ITM"].AutoIncrement = true;
            dt.Columns["ITM"].AutoIncrementSeed = 1;
            dt.Columns["ITM"].AutoIncrementStep = 1;
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.AllowUserToAddRows = false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string Company_Id, string Collection_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RequestCollectionOrder ");
            strSql.Append(" where Company_Id=@Company_Id and Collection_Id=@Collection_Id;");
            strSql.Append("delete from RequestCollectionBody ");
            strSql.Append(" where Company_Id=@Company_Id and Collection_Id=@Collection_Id;");
            SqlParameter[] parameters = {
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Collection_Id", SqlDbType.NVarChar,50)			};
            parameters[0].Value = Company_Id;
            parameters[1].Value = Collection_Id;

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
        #endregion


        #region event
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            StringBuilder _NotNullWhere = new StringBuilder();
            _NotNullWhere.Append(" Where 1=1 and Company_Id='" + LoginInfo._Usr_Company + "'");
            if (!string.IsNullOrEmpty(this.textBoxContainButton1.ID) && !string.IsNullOrEmpty(this.textBoxContainButton2.ID))
            {
                _NotNullWhere.Append(string.Format("and Collection_Id between '{0}'  and '{1}'", this.textBoxContainButton1.ID, this.textBoxContainButton2.ID));
            }
            if (!string.IsNullOrEmpty(this.textBoxContainButton3.ID) && !string.IsNullOrEmpty(this.textBoxContainButton4.ID))
            {
                _NotNullWhere.Append(string.Format("and Req_Csv_Id between '{0}'  and '{1}'", this.textBoxContainButton3.ID, this.textBoxContainButton4.ID));
            }
            if (this.cbxReqType.SelectedIndex > 0)
            {
                _NotNullWhere.Append(string.Format("and ReqType_Id ='{0}'  ", this.cbxReqType.SelectedIndex));
            }
            //存货
            //if (!string.IsNullOrEmpty(this.textBoxContainButton1.Text) && !string.IsNullOrEmpty(this.textBoxContainButton2.Text))
            //{
            //    _NotNullWhere.Append(string.Format("and Collection_Id between '{0}'  and '{1}'", this.textBoxContainButton1.Text, this.textBoxContainButton2.Text));
            //}

            //库位
            //if (!string.IsNullOrEmpty(this.textBoxContainButton1.Text) && !string.IsNullOrEmpty(this.textBoxContainButton2.Text))
            //{
            //    _NotNullWhere.Append(string.Format("and Collection_Id between '{0}'  and '{1}'", this.textBoxContainButton1.Text, this.textBoxContainButton2.Text));
            //}

            //状态
            QueryData(_NotNullWhere.ToString());

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            RequestCollectionOrderManage _Manage = new RequestCollectionOrderManage();
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
        private void openManageForm(string _Edit)
        {
            if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string _Company_Id = "";
                    string _Collection_Id = "";
                    DataGridViewRow _dr = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index];
                    if (_dr != null)
                    {
                        _Company_Id = string.IsNullOrEmpty((_dr.Cells["Company_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["Company_Id"].Value.ToString()).ToString();
                        _Collection_Id = string.IsNullOrEmpty((_dr.Cells["Collection_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["Collection_Id"].Value.ToString()).ToString();
                    }
                    RequestCollectionOrderManage _roleMge = new RequestCollectionOrderManage();
                    _roleMge.Edit = _Edit;
                    _roleMge.BilCollection_Id = _Collection_Id;
                    _roleMge.CompanyId = _Company_Id;
                    if (_roleMge.ShowDialog() != DialogResult.OK)
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
                        string _Collection_Id = string.IsNullOrEmpty((_dr.Cells["Collection_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["Collection_Id"].Value.ToString()).ToString();

                        if(!CommomHelper.ChkDel("确认删除单据[" + _Collection_Id + "]?"))
                        {
                            return;
                        }
                        try
                        {
                            string insertWhere = " Where 1=1 and Company_Id='" + _Company_Id + "' and Collection_Id='" + _Collection_Id + "'";
                            InsertDataForTemp(insertWhere);
                            bool _delOk = false;
                            if (DelteAudit(_Company_Id, _Collection_Id))
                            {
                                _delOk = Delete(_Company_Id, _Collection_Id);
                            }
                            if (_delOk)
                            {
                                StringBuilder strGetIdSql = new StringBuilder();
                                strGetIdSql.Append(" Exec dbo.usp_DelBilId1 ");
                                strGetIdSql.Append("       @Company_Id='" + LoginInfo._Usr_Company + "', ");
                                strGetIdSql.Append("       @Pgm_Tag_Id='RC', ");
                                strGetIdSql.Append("       @Bill_Date='" + System.DateTime.Now.ToShortDateString() + "', ");
                                strGetIdSql.Append("        @Serial_Number=1 , ");
                                strGetIdSql.Append("       @Bil_Id='" + _Collection_Id + "' ");
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

        /// <summary>
        /// 插入临时表
        /// </summary>
        /// <param name="Where"></param>
      
        private void BtnClose_Click(object sender, EventArgs e)
        {
            _ownerFrom.CloseThisFrom("RequestCollectionOrder");
        }

        private void RequestCollectionOrderForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //收集单号
            this.textBoxContainButton1.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton2.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton1.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton1.TextLeave += textBoxContainButton1_TextLeave;
            this.textBoxContainButton2.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton2.TextLeave += textBoxContainButton1_TextLeave;

            //收集客户
            this.textBoxContainButton3.ButtonSelectClick += textBoxContainButton2_Click;
            this.textBoxContainButton4.ButtonSelectClick += textBoxContainButton2_Click;
            this.textBoxContainButton3.TextEnter += textBoxContainButton2_TextEnter;
            this.textBoxContainButton3.TextLeave += textBoxContainButton2_TextLeave;
            this.textBoxContainButton4.TextEnter += textBoxContainButton2_TextEnter;
            this.textBoxContainButton4.TextLeave += textBoxContainButton2_TextLeave;

            //仓库
            this.textBoxContainButton5.ButtonSelectClick += textBoxContainButton3_Click;
            this.textBoxContainButton6.ButtonSelectClick += textBoxContainButton3_Click;
            this.textBoxContainButton5.TextEnter += textBoxContainButton3_TextEnter;
            this.textBoxContainButton5.TextLeave += textBoxContainButton3_TextLeave;
            this.textBoxContainButton6.TextEnter += textBoxContainButton3_TextEnter;
            this.textBoxContainButton6.TextLeave += textBoxContainButton3_TextLeave;

            //存货编码
            this.textBoxContainButton7.ButtonSelectClick += textBoxContainButton4_Click;
            this.textBoxContainButton8.ButtonSelectClick += textBoxContainButton4_Click;
            this.textBoxContainButton7.TextEnter += textBoxContainButton4_TextEnter;
            this.textBoxContainButton7.TextLeave += textBoxContainButton4_TextLeave;
            this.textBoxContainButton8.TextEnter += textBoxContainButton4_TextEnter;
            this.textBoxContainButton8.TextLeave += textBoxContainButton4_TextLeave;
        }

        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=Collection_Id,Desc_01=Collection_Id ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("RequestCollectionOrder", _columns, "");
            }
            else
            {
                string _where = "and RequestCollectionOrder.Company_Id='" + LoginInfo._Usr_Company + "'";
                _ht = CommomHelper.GetQuery1("RequestCollectionOrder", _columns, _where);
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
            _txt.ToFormatStringEnter("RequestCollectionOrder", "Collection_Id", e);
        }

        private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("RequestCollectionOrder", "Collection_Id", e);
        }

        private void textBoxContainButton2_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=Csv_Id,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("Csv", _columns, "");
            }
            else
            {
                string _where = "and Csv.Company_Id='" + LoginInfo._Usr_Company + "'";
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

        private void textBoxContainButton2_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("Csv", "Csv_Id", e);
        }

        private void textBoxContainButton2_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("Csv", "Csv_Id", e);
        }

        private void textBoxContainButton3_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=Warehouse_Id,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("Warehouse", _columns, "");
            }
            else
            {
                string _where = "and Warehouse.Company_Id='" + LoginInfo._Usr_Company + "'";
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

        private void textBoxContainButton3_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("Warehouse", "Warehouse_Id", e);
        }

        private void textBoxContainButton3_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("Warehouse", "Warehouse_Id", e);
        }

        private void textBoxContainButton4_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=Item_Id,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("Item", _columns, "");
            }
            else
            {
                string _where = "and Item.Company_Id='" + LoginInfo._Usr_Company + "'";
                _ht = CommomHelper.GetQuery1("Item", _columns, _where);
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
            _txt.ToFormatStringEnter("Item", "Item_Id", e);
        }

        private void textBoxContainButton4_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("Item", "Item_Id", e);
        }
        #endregion

    }
}
