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
    public partial class ShippingInfoEwmManage : Form
    {
        public ShippingInfoEwmManage()
        {
            InitializeComponent();
        }

        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }

        private string _Shipping_Id = "";
        public string Shipping_Id
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
        private string _CsvPo_Id = "";
        public string CsvPo_Id
        {
            set { _CsvPo_Id = value; }
            get { return _CsvPo_Id; }
        }

        private string _ItemPrpty_Id = "";
        public string ItemPrpty_Id
        {
            set { _ItemPrpty_Id = value; }
            get { return _ItemPrpty_Id; }
        }

        private string _itemUt = "";
        public string itemUt
        {
            set { _itemUt = value; }
            get { return _itemUt; }
        }

        private string _qty = "";
        public string qty
        {
            set { _qty = value; }
            get { return _qty; }
        }

        private string _itm_Full_Id = "";
        public string itm_Full_Id
        {
            set { _itm_Full_Id = value; }
            get { return _itm_Full_Id; }
        }

        private string _Body1_Tbl_Name = "";
         public string Body1_Tbl_Name
        {
            set { _Body1_Tbl_Name = value; }
            get { return _Body1_Tbl_Name; }
        }

        private  DataTable _dtEwm = null;
        

        private void ShippingInfoEwmManage_Load(object sender, EventArgs e)
        {
            this.txtPo.Text = _CsvPo_Id;
            this.txtXh.Text=_ItemPrpty_Id;
            this.txtUt.Text = _itemUt;
            this.txtQty.Text = _qty;
            this.WindowState = FormWindowState.Maximized;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            string _where = "";
            if(_Edit=="ADD")
            {
                _where = "Where 1<>1 ";
            }
            else if (_Edit == "UPD")
            {
                _where = "where Company_Id='" + _Company_Id + "' and Shipping_Id='" + _Shipping_Id + "'"+
                   "' and CsvPo_Id='" + _CsvPo_Id + "' and _ItemPrpty_Id='" + _ItemPrpty_Id + "'";
            }
            DataSet _dsUpd = GetData(_where);
            if (_dsUpd != null)
            {
                DataTable _dtBody = _dsUpd.Tables[0];
                if (_dtBody.Rows.Count > 0)
                {
                    _dtBody.Columns["Itm"].AutoIncrement = true;
                    _dtBody.Columns["Itm"].AutoIncrementSeed = 1;
                    _dtBody.Columns["Itm"].AutoIncrementStep = 1;
                }
                BindingSource bindingSource1 = new BindingSource();
                bindingSource1.DataSource = _dtBody;
                this.dataGridView1.DataSource = bindingSource1;
                for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
                {
                    string _columnsName = this.dataGridView1.Columns[i].DataPropertyName;
                    if (_columnsName == "Company_Id" || _columnsName == "Shipping_Id" || _columnsName == "Itm_Full_Id" || _columnsName == "CsvPo_Id" ||
                          _columnsName == "ItemPrpty_Id" )
                    {
                        this.dataGridView1.Columns[i].Visible = false;
                    }
                    else
                    {
                        this.dataGridView1.Columns[i].Visible = true;
                    }
                }
                
            }
        }

        private DataSet GetData(string _where)
        {
            StringBuilder _sqlstr = new StringBuilder();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select  ROW_NUMBER() over (order by getdate()) as  Itm,'' as  ItemUnit_Id,'' as Qty,* ");
            strSql.Append("  from ShippingInfoConfirmBody1 ");
            strSql.Append(_where);
            DataSet _ds = SqlHelper.ExecuteDataSet(strSql.ToString());
            return _ds;

        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            decimal _qty=CommomHelper.ToDecimal(this.txtQty.Text);
            if (string.IsNullOrEmpty(this.txtQty.Text))
            {
                MessageBox.Show("数量必须输入！");
            }
            else
            {
                DataTable _dtnew = new DataTable();
                BindingSource _bdSource = new BindingSource();
                _bdSource = dataGridView1.DataSource as BindingSource;
                if (_bdSource != null)
                {
                    DataTable _dtBody = _bdSource.DataSource as DataTable;
                    if(_dtBody.Rows.Count>0)
                    {
                        _dtnew = _dtBody.Copy();
                    }
                    else
                    {
                        _dtnew = _dtBody.Clone();
                    }
                    for(int i=0;i<_qty;i++)
                    {
                        if (_dtnew == null)
                            return;
                        DataRow _dr = _dtnew.NewRow();
                        _dr["Company_Id"] = _Company_Id;
                        _dr["Shipping_Id"] = _Shipping_Id;
                        _dr["CsvPo_Id"] = _CsvPo_Id;
                        _dr["ItemPrpty_Id"] = _ItemPrpty_Id;
                        _dr["Itm_Full_Id"] = _itm_Full_Id;
                        if (Edit == "ADD")
                        {
                            _dr["Itm_Full_Id"] = System.Guid.NewGuid().ToString("N");
                        }
                        _dr["Scan_Ewm_Id"] = System.Guid.NewGuid().ToString("N");
                        _dr["ItemUnit_Id"] = _itemUt;
                        _dr["Qty"] = 1;
                        int _itm = 1;
                        if (_dtnew.Rows.Count > 0)
                        {
                            _itm = _dtnew.AsEnumerable().Select(t => t.Field<int>("Po_itm")).Max();
                            _itm += 1;
                        }
                        _dr["Itm"] = _itm;
                        _dr["Po_Itm"] = _itm;
                        _dr["Qty_Shipping"] = 1;
                        _dr["V"] = "V" + _itm;
                        _dr["Planning_Shipping_Date"] = System.DateTime.Now;
                        _dr["Shipping_Date"] = System.DateTime.Now;
                        _dr["Planning_Arrive_Date"] = System.DateTime.Now;
                        if (_dtnew.Select("Itm_Full_Id='" + _dr["Itm_Full_Id"].ToString() + "'").Length == 0)
                        {
                            _dtnew.Rows.Add(_dr);
                        }
                        else
                        {
                            MessageBox.Show("存在相同项！");//  _dr["Itm_Full_Id"].ToString()
                            return;
                        }
                    }
                }
                BindingSource bindingSource1 = new BindingSource();
                bindingSource1.DataSource = _dtnew;
                this.dataGridView1.DataSource = bindingSource1;
            }
        }


        private void BtnOk_Click(object sender, EventArgs e)
        {
            DataTable _dtnew = new DataTable();
            BindingSource _bdSource = new BindingSource();
            _bdSource = dataGridView1.DataSource as BindingSource;
            if (_bdSource != null)
            {
                try
                {
                    _dtEwm = _bdSource.DataSource as DataTable;
                    #region 表身二维码
                    StringBuilder strSqlBodyEwm = new StringBuilder();
                    if (_dtEwm != null)
                    {
                        for (int i = 0; i < _dtEwm.Rows.Count; i++)
                        {
                            strSqlBodyEwm.Append("insert into [" + _Body1_Tbl_Name + "] (");
                            strSqlBodyEwm.Append("Company_Id,Shipping_Id,Itm_Full_Id,Scan_Ewm_Id,Po_Itm,Xm_Id,Item_Desc,Shipping_Address,Qty_Shipping,Available_Qty_Serial_Id,Manufacturer_Id,Serial_Id,AQID,");
                            strSqlBodyEwm.Append(" PurType_Id,Qty_Po,Planning_Shipping_Date,Already_Shipping_Id,Shipping_Date,Planning_Arrive_Date,Carrier_Id,Lading_Shipping_Id,BarCode_Print_Qty,ItemPrpty_Id_Before,");
                            strSqlBodyEwm.Append(" ItemSerial_Id_Before,AQID_Before,CsvPo_Id,ItemPrpty_Id,V,APO)");
                            strSqlBodyEwm.Append("VALUES(@Company_Id,@Shipping_Id,'" + _dtEwm.Rows[i]["Itm_Full_Id"].ToString() + "','" + _dtEwm.Rows[i]["Scan_Ewm_Id"].ToString() + "',");
                            strSqlBodyEwm.Append(+CommomHelper.ToInt(_dtEwm.Rows[i]["Po_Itm"].ToString()) + ",'" + _dtEwm.Rows[i]["Xm_Id"].ToString() + "','" + _dtEwm.Rows[i]["Item_Desc"].ToString() + "',");
                            strSqlBodyEwm.Append("'" + _dtEwm.Rows[i]["Shipping_Address"].ToString() + "'," + CommomHelper.ToDecimal(_dtEwm.Rows[i]["Qty_Shipping"].ToString()) + ",'" + _dtEwm.Rows[i]["Available_Qty_Serial_Id"].ToString() + "',");
                            strSqlBodyEwm.Append("'" + _dtEwm.Rows[i]["Manufacturer_Id"].ToString() + "','" + _dtEwm.Rows[i]["Serial_Id"].ToString() + "','" + _dtEwm.Rows[i]["AQID"].ToString() + "',");

                            strSqlBodyEwm.Append("'" + _dtEwm.Rows[i]["PurType_Id"].ToString() + "'," + CommomHelper.ToDecimal(_dtEwm.Rows[i]["Qty_Po"].ToString()) + ",'" + _dtEwm.Rows[i]["Planning_Shipping_Date"].ToString() + "',");
                            strSqlBodyEwm.Append("'" + _dtEwm.Rows[i]["Already_Shipping_Id"].ToString() + "','" + _dtEwm.Rows[i]["Shipping_Date"].ToString() + "','" + _dtEwm.Rows[i]["Planning_Arrive_Date"].ToString() + "',");
                            strSqlBodyEwm.Append("'" + _dtEwm.Rows[i]["Carrier_Id"].ToString() + "','" + _dtEwm.Rows[i]["Lading_Shipping_Id"].ToString() + "'," + CommomHelper.ToDecimal(_dtEwm.Rows[i]["BarCode_Print_Qty"].ToString()) + ",");

                            strSqlBodyEwm.Append("'" + _dtEwm.Rows[i]["ItemPrpty_Id_Before"].ToString() + "','" + _dtEwm.Rows[i]["ItemSerial_Id_Before"].ToString() + "','" + _dtEwm.Rows[i]["AQID_Before"].ToString() + "','" + _dtEwm.Rows[i]["CsvPo_Id"].ToString() + "',");
                            strSqlBodyEwm.Append("'" + _dtEwm.Rows[i]["ItemPrpty_Id"].ToString() + "','" + _dtEwm.Rows[i]["V"].ToString() + "','" + _dtEwm.Rows[i]["APO"].ToString() + "')");
                        }
                    }
                    SqlParameter[] parameters = {
					new SqlParameter("@Company_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Shipping_Id", SqlDbType.NVarChar,50)};
                    parameters[0].Value = _Company_Id;
                    parameters[1].Value = _Shipping_Id;
                    #endregion
                    bool IsTrue = SqlHelper.ExecuteQueryTrans(strSqlBodyEwm.ToString(), parameters);
                    if (IsTrue)
                    {
                        this.DialogResult = DialogResult.Yes;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }         
            else
            {
                MessageBox.Show("表身二维码未生成！");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
