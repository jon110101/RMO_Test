using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMO.RmoManagement
{
    public partial class InputByCollectionOrderForm : Form
    {
        public InputByCollectionOrderForm()
        {
            InitializeComponent();
        }
        public DataSet _dsInput = null;

        private string _Input_Id = "";
        public string Input_Id
        {
            set { _Input_Id = value; }
            get { return _Input_Id; }
        }

        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }

        private string _Company_Id = "";
        public string ForCompany_Id
        {
            set { _Company_Id = value; }
            get { return _Company_Id; }
        }
        private string HeadTemp = "";
        public string ForHeadTemp
        {
            set { HeadTemp = value; }
            get { return HeadTemp; }
        }

        private string BodyTemp = "";
        public string ForBodyTemp
        {
            set { BodyTemp = value; }
            get { return BodyTemp; }
        }

        private string _Get_Bil_Id = "";
        public string Get_Bil_Id
        {
            set { _Get_Bil_Id = value; }
            get { return _Get_Bil_Id; }
        }

        private string _Get_Pgm_Id = "";
        public string Get_Pgm_Id
        {
            set { _Get_Pgm_Id = value; }
            get { return _Get_Pgm_Id; }
        }

        private string _Get_Company_Id = "";
        public string Get_Company_Id
        {
            set { _Get_Company_Id = value; }
            get { return _Get_Company_Id; }
        }

        private string _Get_Itm_Full_Id = "";
        public string Get_Itm_Full_Id
        {
            set { _Get_Itm_Full_Id = value; }
            get { return _Get_Itm_Full_Id; }
        }


        private void BtnOk_Click(object sender, EventArgs e)
        {
            BindingSource _bdSource = new BindingSource();
            _bdSource = dataGridView1.DataSource as BindingSource;
            if (_bdSource != null)
            {
                DataTable _dtBody = _bdSource.DataSource as DataTable;
                if (_dtBody != null && _dtBody.Rows.Count > 0)
                {
                    DataTable _dtNew = _dtBody.Clone();
                    DataRow[] _drs = _dtBody.Select("Choose_Id='T'");
                    if(_drs.Length>0)
                    {
                        string _Src_Company_Id = _drs[0]["Src_Company_Id"].ToString();
                        string _Src_Bil_Id = _drs[0]["Src_Bil_Id"].ToString();
                        string _Src_Pgm_Id = _drs[0]["Src_Pgm_Id"].ToString();
                        int i = 1;
                        foreach(DataRow _dr in _drs)
                        {
                            if(_Src_Company_Id!=_dr["Src_Company_Id"].ToString())
                            {
                                MessageBox.Show("所选内容公司不一致！");
                                return;
                            }
                            if (_Src_Bil_Id != _dr["Src_Bil_Id"].ToString())
                            {
                                MessageBox.Show("所选内容单号不一致！");
                                return;
                            }
                            if (_Src_Pgm_Id != _dr["Src_Pgm_Id"].ToString())
                            {
                                MessageBox.Show("所选内容单据不一致！");
                                return;
                            }
                            if (_drs.Length != i)
                            {
                                _Get_Itm_Full_Id += "'" + _dr["Src_Itm_Full_Id"].ToString() + "',";
                            }
                            else
                            {
                                _Get_Itm_Full_Id += "'" + _dr["Src_Itm_Full_Id"].ToString() + "' ";
                            }
                            i++;
                        }
                        _Get_Company_Id = _Src_Company_Id;
                        _Get_Pgm_Id = _Src_Pgm_Id;
                        _Get_Bil_Id = _Src_Bil_Id;
                        this.DialogResult = DialogResult.Yes;
                    }                  
                }
            }
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            StringBuilder _SqlWhere = new StringBuilder();
            _SqlWhere.Append("and 1=1");
            if (!string.IsNullOrEmpty(this.textBoxContainButton1.ID))
            {
                _SqlWhere.Append("And SrcHead.Company_Id='" + this.textBoxContainButton1.ID + "'");
            }
            if (!string.IsNullOrEmpty(this.textBoxContainButton2.ID))
            {
                _SqlWhere.Append("And SrcHead.Collection_Id='" + this.textBoxContainButton2.ID + "'");
            }
            if (!string.IsNullOrEmpty(this.textBoxContainButton3.ID))
            {
                _SqlWhere.Append("And SrcBody.Item_Id='" + this.textBoxContainButton3.ID + "'");
            }
            if (!string.IsNullOrEmpty(this.textBoxContainButton4.ID))
            {
                _SqlWhere.Append("And SrcBody.Warehouse_Id='" + this.textBoxContainButton4.ID + "'");
            }
            DataSet _dsBody= QueryData(_SqlWhere.ToString());
            if(_dsBody!=null&&_dsBody.Tables[0].Rows.Count>0)
            {
                _dsBody.Tables[0].Columns["ITM"].AutoIncrement = true;
                _dsBody.Tables[0].Columns["ITM"].AutoIncrementSeed = 1;
                _dsBody.Tables[0].Columns["ITM"].AutoIncrementStep = 1;
                BindingSource bindingSource1 = new BindingSource();
                bindingSource1.DataSource = _dsBody.Tables[0];
                this.dataGridView1.DataSource = bindingSource1;
                for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
                {
                    string _columnsName = this.dataGridView1.Columns[i].DataPropertyName;
                    if (_columnsName == "ITM" || _columnsName == "Choose_Id" || _columnsName == "Src_Company_Id" || _columnsName == "Src_Bil_Id" ||
                      _columnsName == "CsvPo_Id" || _columnsName == "Project_Id" || _columnsName == "Item_Id" || _columnsName == "Item_Spec" || _columnsName == "Qty")
                    {
                        this.dataGridView1.Columns[i].Visible = true;
                    }
                    else
                    {
                        this.dataGridView1.Columns[i].Visible = false;
                    }
                }
            }

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }


        private DataSet QueryData(string _where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("   Select ROW_NUMBER() over (order by getdate()) as  ITM,  Choose_Id='F', ");
            strSql.Append("    Src_Pgm_Id=SrcHead.Pgm_Id, ");
            strSql.Append("    Src_Company_Id=SrcHead.Company_Id, ");
            strSql.Append("    Src_Bil_Id=SrcHead.Collection_Id, ");
            strSql.Append("    Src_Itm_Full_Id=SrcBody.Itm_Full_Id, ");
            strSql.Append("    CsvPo_Id=SrcHead.CsvPo_Id, ");
            strSql.Append("    Project_Id=SrcBody.Project_Id, ");
            strSql.Append("    Warehouse_Id=SrcBody.Warehouse_Id, ");
            strSql.Append("    Item_Id=SrcBody.Item_Id, ");
            strSql.Append("    Item_Spec=Item.Spec, ");
            strSql.Append("    ItemUnit_Id=SrcBody.ItemUnit_Id, ");
            strSql.Append("    Qty=SrcBody.Qty-IsNull(SrcBody.Qty_Nexted_PlanningOrder,0)  ");
            strSql.Append("      +dbo.fn_GetNewItemNewUnitQty_fn(LoadedBody.Company_Id,   ");
            strSql.Append("                                     LoadedBody.Item_Id,      ");
            strSql.Append("                                     LoadedBody.ItemUnit_Id,  ");
            strSql.Append("                                    LoadedBody.Qty,          ");
            strSql.Append("                                   SrcBody.Company_Id,      ");
            strSql.Append("                                   SrcBody.Item_Id,        ");
            strSql.Append("                                   SrcBody.ItemUnit_Id   ),   ");
            strSql.Append("     Itm_Full_Id = IsNull(LoadedBody.Itm_Full_Id, Replace(Cast(NewId() As nvarchar(50)),'-','')) ");
            strSql.Append("   From  RequestCollectionOrder SrcHead ");
            strSql.Append("   Inner Join RequestCollectionBody SrcBody On SrcBody.Company_Id=SrcHead.Company_Id And SrcBody.Collection_Id=SrcHead.Collection_Id ");
            strSql.Append("   Left  Join Item On Item.Company_Id=SrcBody.Company_Id And Item.Item_Id=SrcBody.Item_Id ");
            strSql.Append("   Left  Join  [" + BodyTemp + "] LoadedBody On LoadedBody.Company_Id='" + _Company_Id + "' And LoadedBody.Input_Id='" + _Input_Id + "'	");
            strSql.Append("                                       And LoadedBody.Src_Pgm_Id=SrcBody.Pgm_Id And LoadedBody.Src_Company_Id=SrcBody.Company_Id ");
            strSql.Append("                                        And LoadedBody.Src_Collection_Id=SrcBody.Collection_Id And LoadedBody.Src_Itm_Full_Id=SrcBody.Itm_Full_Id ");
            strSql.Append("  Where  ((SrcBody.Status_Id In ('130', '160')) ");
            strSql.Append("      Or ");
            strSql.Append(" 	 (LoadedBody.Company_Id='" + _Company_Id + "' And LoadedBody.Input_Id='" + _Input_Id + "') ");
            strSql.Append("     )And 1=1 ");
            strSql.Append(_where);

            DataSet _ds = SqlHelper.ExecuteDataSet(strSql.ToString());
            return _ds;
        }

        private void InputByCollectionOrderForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.textBoxContainButton1.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton2.ButtonSelectClick += textBoxContainButton2_Click;
            this.textBoxContainButton3.ButtonSelectClick += textBoxContainButton3_Click;
            this.textBoxContainButton4.ButtonSelectClick += textBoxContainButton4_Click;


            this.textBoxContainButton1.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton1.TextLeave += textBoxContainButton1_TextLeave;
            this.textBoxContainButton2.TextEnter += textBoxContainButton2_TextEnter;
            this.textBoxContainButton2.TextLeave += textBoxContainButton2_TextLeave;
            this.textBoxContainButton3.TextEnter += textBoxContainButton3_TextEnter;
            this.textBoxContainButton3.TextLeave += textBoxContainButton3_TextLeave;
            this.textBoxContainButton4.TextEnter += textBoxContainButton4_TextEnter;
            this.textBoxContainButton4.TextLeave += textBoxContainButton4_TextLeave;
        }

        private void textBoxContainButton1_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("SysCompany1", "Company_Id", e);
        }

        private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("SysCompany1", "Company_Id", e);
        }

        private void textBoxContainButton2_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("RequestCollectionOrder", "Collection_Id", e);
        }

        private void textBoxContainButton2_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("RequestCollectionOrder", "Collection_Id", e);
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

        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=Company_Id,Desc_01=Company_Name ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("SysCompany1", _columns, "");
            }
            else
            {
                string _where = "and SysCompany1.Company_Id='" + LoginInfo._Usr_Company + "'";
                _ht = CommomHelper.GetQuery1("SysCompany1", _columns, _where);
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


        private void textBoxContainButton2_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=Collection_Id,Desc_01=Collection_Id ";
            Dictionary<string, object> _ht = CommomHelper.GetQuery1("RequestCollectionOrder", _columns, "");
            if (_ht.ContainsKey("ID") && _ht.ContainsKey("DESC"))
            {
                _txt.ID = _ht["ID"].ToString();
                _txt.Desc = _ht["DESC"].ToString();
                _txt.Text = _ht["DESC"].ToString();
            }
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

        private void textBoxContainButton4_Click(object sender, EventArgs e)
        {
           
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=Item_ID,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("Item", _columns, "");
            }
            else
            {
                string _where = "and Item.Company_Id='" + LoginInfo._Usr_Company + "'";
                _ht = CommomHelper.GetQuery1("Item", _columns, "");
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
       
    }
}
