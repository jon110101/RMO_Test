using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMO
{
    public partial class TextBoxContainButton : UserControl
    {
        public TextBoxContainButton()
        {
            InitializeComponent();
        }

        [Category("自定义"), Description("显示文本内容")]
        public override string Text
        {
            get
            {
                return this.textBox1.Text;
            }
            set
            {
                this.textBox1.Text = value;
                _AddID = value;
            }
        }

        public  string _AddID;
        private string _ID;
        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        private string _Desc;
        public  string Desc
        {
            get
            {
                return _Desc;
            }
            set
            {
                _Desc = value;
            }
        }

        public bool ReadOnly
        {
            get
            {
                return textBox1.ReadOnly;
            }
            set
            {
                textBox1.ReadOnly = value;
            }
        }

        public string Format { get; set; }
        [Browsable(true)]
        [DefaultValue("")]
        [Description("默认提示咨讯,在报表自定义字段时必填,无法显示资源")]
        [Localizable(true)]

        public delegate void ButtonClick(object sender, EventArgs e);
        public event ButtonClick ButtonSelectClick;

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonSelectClick.DynamicInvoke(this,e);
            }
            catch (Exception)
            {

                return;
            }
        }


        public delegate void textEnter(object sender, EventArgs e);
        public event textEnter TextEnter;
        public delegate void textLeave(object sender, EventArgs e);
        public event textLeave TextLeave;
       
        public void ToFormatStringEnter(string keyValue, string valueField, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.textBox1.Text))
            {
                if(!string.IsNullOrEmpty(_ID))
                {
                    this.textBox1.Text = _ID;
                }
                else
                {
                    this.textBox1.Text = _AddID;
                }
            }
            else
            {
                _ID = "";
                _Desc = "";
            }
        }

        public void ToFormatStringLeave(string keyValue, string valueField, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.textBox1.Text))
            {
                if (this.textBox1.Text != _ID)
                {
                    FormatDesc(keyValue, valueField, this.textBox1.Text);
                    if (!string.IsNullOrEmpty(_Desc))
                    {
                        this.textBox1.Text = _Desc;
                    }   
                }
                else
                {
                    if (String.IsNullOrEmpty(_Desc))
                    {
                        _Desc = _ID;
                    }
                    this.textBox1.Text = _Desc;
                }
                                           
            }
        }

       

        private void textBox1_Enter(object sender, EventArgs e)
        {
            try
            {
               TextEnter.DynamicInvoke(this, e);

            }
            catch (Exception)
            {

                return;
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                TextLeave.DynamicInvoke(this, e);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void FormatDesc(string TableName,string columnId,string _id)
        {
            string _desc = ",Desc_01 ";
            string _NewId = _id;
            string _NewDesc = "";
            if (TableName == "PgmTransferWarningSetting" || TableName == "PlanningOrderInfoInput"||
                TableName == "RequestCollectionOrder" || TableName == "TaskNotifyOrder"||
                TableName == "ShippingInfoConfirmOrder" || TableName == "Usr1" || TableName == "UsrCompany1")
            {
                _desc = ","+columnId+ " as Desc_01 ";
                if(TableName == "Usr1")
                {
                    _desc = ",Name as Desc_01 ";
                }
            }            
            StringBuilder _sqlstr = new StringBuilder();
            _sqlstr.Append("Select ");
            _sqlstr.Append(columnId);
            _sqlstr.Append(_desc);
            _sqlstr.Append(" From ");
            _sqlstr.Append(TableName);
            _sqlstr.Append(" where ");
            _sqlstr.Append(columnId);
            _sqlstr.Append(" ='" + _id + "'");

            DataTable dt = SqlHelper.ExecuteDataTable(_sqlstr.ToString());
            if(dt!=null&&dt.Rows.Count>0)
            {
                _NewId = dt.Rows[0][0].ToString();
                _NewDesc = dt.Rows[0]["Desc_01"].ToString();            
            }
            _ID = _NewId;
            _Desc = _NewDesc;
        }

           
    }

  
}
