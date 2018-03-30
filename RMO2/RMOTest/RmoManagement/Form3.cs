using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Timers;
using System.Globalization;
using System.Data.OleDb;
using LabelManager2;

namespace RMO
{
    public partial class Form3 : Form
    {
        public string _PO = "";
        public string PO
        {
            set { _PO = value; }
            get { return _PO; }
        }
        public string _SEL = "";
        public string SEL
        {
            set { _SEL = value; }
            get { return _SEL; }
        }
        public string _QTY = "";
        public string QTY
        {
            set { _QTY = value; }
            get { return _QTY; }
        }
        public Form3()
        {
            InitializeComponent();
            
        }
        public static string _temp = "";
        public string temp
        {
            set { _temp = value; }
            get { return _temp; }
        }
        public static string _input= "";
        public string input
        {
            set { _input = value; }
            get { return _input; }
        }

        
        
        private void button1_Click(object sender, EventArgs e)
        {
            //form4 f4 = new form4();
            //f4.showdialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            DataTable dt1 = new DataTable();
            OpenFileDialog myDLG1 = new OpenFileDialog();
            myDLG1.Title = "请选择导入csv文件";
            myDLG1.Filter = "csv文件|*.csv";
            if (myDLG1.ShowDialog() == DialogResult.OK)
            {
                
                string fileName = myDLG1.FileName;
                try
                {
                    dt1 = CsvHelper.OpenCSV(fileName);
                }
                catch (InvalidOperationException ee)
                {
                    MessageBox.Show(ee.ToString());
                }
                
                for (int i = 2; i < dt1.Rows.Count; i++)
                {
                    //string[] str = list[i].Split('\t');
                    
                }
                //if (textBox2.Text != dt1.Rows[2][11] || textBox1.Text != dt1.Rows[2][0])
                //{
                //    MessageBox.Show("型号不对");
                //    return;
                //}
                string sql1 = "";
                try
                {
                    sql1 = "select Count(*) from ShippingInfoConfirmBody1 where CsvPo_Id = '" + dt1.Rows[2][0].ToString() + "'";

                }
                catch
                {
                    MessageBox.Show("导入错误");
                    return;

                }
                DataTable d = SqlHelper.ExecuteDataTable(sql1);
                //int qty = Convert.ToInt32(textBox3.Text) - Convert.ToInt32(d.Rows[0][0].ToString());
                //if (qty <= 0)
                //{
                //    MessageBox.Show("数量不对啊");
                //    return;
                //}
                if (Convert.ToInt32(textBox3.Text) > dt1.Rows.Count - 2)
                {
                    //qty = dt1.rows.count - 2;
                    MessageBox.Show("数量不对啊");
                    return;
                }

                int index = Convert.ToInt32(d.Rows[0][0].ToString());
                int num = Convert.ToInt32(textBox3.Text) - index;
                if (num < 1)
                {
                    MessageBox.Show("不允许导入");
                    return;
                }
                //int index = dataGridView1.Rows.Count  ;
                //if (index  >= Convert.ToInt32(textBox3.Text))
                //{
                //    MessageBox.Show("数量不对啊");
                //    return;
                //}
                
                //if (Convert.ToInt32(d.Rows[0][0].ToString()) != 0)
                //{ 
                //    string sql3 = "select MAX(Serial_Id) from ShippingInfoConfirmBody1";
                //    DataTable dt3 = SqlHelper.ExecuteDataTable(sql3);
                //    string[] ser = (dt1.Rows[0][0].ToString()).Split('-');
                //    string MAX = ser[ser.Length - 1 ];
                //    char[] c = MAX.ToCharArray();
                //    serial = Convert.ToInt32(c[0]) * 1000 + Convert.ToInt32(c[1]) * 100 + Convert.ToInt32(c[2]) * 100 + Convert.ToInt32(c[3]);
                //}

                string serial = "select Count(*) from serial_item where serial = '" + textBox2.Text + "'";
                DataTable dt4 = SqlHelper.ExecuteDataTable(serial);
                int ser = Convert.ToInt32(dt4.Rows[0][0].ToString());

                string Ser = textBox2.Text;

                string csv_ser = "Select Req_Csv_Id From PlanningOrderInfoInput Where Company_Id='CYGIA' And Input_Id='" + input+ "'";
                DataTable dt_ser = SqlHelper.ExecuteDataTable(csv_ser);
                string req_csv = dt_ser.Rows[0][0].ToString();

                string baseon = "Select Serial_Id_Based_On From Csv Where Company_Id='CYGIA' And Csv_Id='" + req_csv +"'";
                DataTable dt_bas = SqlHelper.ExecuteDataTable(baseon);
                string Src_base = dt_bas.Rows[0][0].ToString();
                if (Src_base != "")
                {
                    string project = "Select ProjectPrpty_Id  ProjectPrpty_Id From PlanningOrderInfoInputBody Where Company_Id='CYGIA' And Input_Id='" + input + "' And Itm_Full_Id='sadas'";
                    DataTable dt_pro = SqlHelper.ExecuteDataTable(project);
                    Ser = req_csv + dt_pro.Rows[0][0].ToString();
                }

                int j;
                int ij;
                int jj = 0;
                for (int i = 2; i < dt1.Rows.Count; i++)
                {
                    //if (textBox2.Text != (dt1.Rows[i][11].ToString()) || textBox1.Text != dt1.Rows[i][0].ToString())
                    //{
                    //    return;
                    //}
                    
                    if (jj  == num)
                    {
                        return;
                    }
                    jj++;
                    if (textBox2.Text != dt1.Rows[i][11].ToString() || textBox1.Text != dt1.Rows[i][0].ToString())
                    {
                        continue; ;
                    }
                    ij = i - 2;
                  
                    this.dataGridView1.Rows.Add();


                    
                    
                    
                    j = index + i - 2 ;
                    dataGridView1.Rows[j].Cells[0].Value = j + 1;

                    dataGridView1.Rows[j].Cells[1].Value = dt1.Rows[i][0];
                    dataGridView1.Rows[j].Cells[2].Value = dt1.Rows[i][1];
                    dataGridView1.Rows[j].Cells[3].Value = dt1.Rows[i][2];
                    dataGridView1.Rows[j].Cells[4].Value = dt1.Rows[i][3];
                    dataGridView1.Rows[j].Cells[5].Value = dt1.Rows[i][4];
                    dataGridView1.Rows[j].Cells[6].Value = dt1.Rows[i][5];
                    dataGridView1.Rows[j].Cells[7].Value = dt1.Rows[i][6];
                    dataGridView1.Rows[j].Cells[8].Value = dt1.Rows[i][7];
                    dataGridView1.Rows[j].Cells[9].Value = "CYGIA";
                    dataGridView1.Rows[j].Cells[10].Value = Ser + "-" + String.Format("{0:0000}", ser + jj);
                    dataGridView1.Rows[j].Cells[11].Value = dt1.Rows[i][10];
                    dataGridView1.Rows[j].Cells[12].Value = dt1.Rows[i][11];
                    dataGridView1.Rows[j].Cells[13].Value = dt1.Rows[i][12];
                    dataGridView1.Rows[j].Cells[14].Value = dt1.Rows[i][13];
                    dataGridView1.Rows[j].Cells[15].Value = dt1.Rows[i][14];
                    dataGridView1.Rows[j].Cells[16].Value = dt1.Rows[i][15];
                    dataGridView1.Rows[j].Cells[17].Value = dt1.Rows[i][16];
                    dataGridView1.Rows[j].Cells[18].Value = dt1.Rows[i][17];
                    dataGridView1.Rows[j].Cells[19].Value = dt1.Rows[i][18];
                    dataGridView1.Rows[j].Cells[20].Value = dt1.Rows[i][19];
                    dataGridView1.Rows[j].Cells[21].Value = dt1.Rows[i][20];
                    dataGridView1.Rows[j].Cells[22].Value = dt1.Rows[i][21];
                    dataGridView1.Rows[j].Cells[23].Value = dt1.Rows[i][22];

                    if (i > 2)
                    {
                        dataGridView1.Rows[j].Cells[6].Value = "";
                        dataGridView1.Rows[j].Cells[7].Value = "";
                    }

                 
                    
                }
                //load();
            }
        }

        Object myConvert(string s)
        {
            int i;
            try
            {
                i = Convert.ToInt32(s);
            }
            catch
            {
                return 0;
            }
            return i;
        }
        DateTime myDatetime(string time)
        {

            DateTime dt = DateTime.ParseExact(time, "dd.MM.yyyy", System.Globalization.CultureInfo.CurrentCulture);

            return dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string sql = "select  Po_Itm, Xm_Id, Item_Desc, Shipping_Address, Qty_Shipping, Available_Qty_Serial_Id, Manufacturer_Id, Serial_Id, AQID, PurType_Id, Qty_Po, Planning_Shipping_Date, Already_Shipping_Id, Shipping_Date, Planning_Arrive_Date, Carrier_Id, Lading_Shipping_Id, BarCode_Print_Qty, ItemPrpty_Id_Before, ItemSerial_Id_Before, AQID_Before, CsvPo_Id, ItemPrpty_Id from [RMOTest].[dbo].[ShippingInfoConfirmBody1]";
            //DataTable dt = SqlHelper.ExecuteDataTable(sql);
            
            DataTable dt1 = GetDgvToTable(dataGridView1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (dt1.Rows[i][1].ToString() == "")
                {
                    dt1.Rows.RemoveAt(i);
                }
            }
            dt1.Columns.RemoveAt(0);


            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string[] test;
                test = dt1.Rows[i][11].ToString().Split('-');
                if(test[3] == "R")
                {
                    if (dt1.Rows[i][dt1.Columns.Count - 3].ToString() == "")
                    {
                        MessageBox.Show("设备型号 (改机前一次)未输入");
                        return;
                    }
                    if (dt1.Rows[i][dt1.Columns.Count - 2].ToString() == "")
                    {
                        MessageBox.Show("设备序列号 (改机前一次)未输入");
                        return;
                    }
                    if (dt1.Rows[i][dt1.Columns.Count - 1].ToString() == "")
                    {
                        MessageBox.Show("AQID (改机前一次)未输入");
                        return;
                    }
                    
                }
                if (dt1.Rows[i][13].ToString() == "")
                {
                    MessageBox.Show("送货地址未输入");
                    return;
                }
                
            }



            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "请选择导出路径";
            sfd.Filter = "csv文件|*.csv";
            sfd.FileName = textBox1.Text + DateTime.Now.ToString("-yyyyMMdd-HHmm");
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                CsvHelper.SaveCSV(dt1, path);
            }
        }

        public DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 列强制转换
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }

            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = _PO;
            this.textBox2.Text = _SEL;
            this.textBox3.Text = _QTY;
            this.textBox4.Text = _input;
            load();
            
        }
        void load()
        {
            string sql = "select  Po_Itm, Xm_Id, Item_Desc, Shipping_Address, Qty_Shipping, Available_Qty_Serial_Id, Manufacturer_Id, Serial_Id, AQID, PurType_Id, Qty_Po, Planning_Shipping_Date, Already_Shipping_Id, Shipping_Date, Planning_Arrive_Date, Carrier_Id, Lading_Shipping_Id, BarCode_Print_Qty, Item_Spec_Before, ItemSerial_Id_Before, AQID_Before, CsvPo_Id, Item_Spec from ShippingInfoConfirmBody1 where CsvPo_Id = '" + textBox1.Text + "' and Item_Spec = '" + textBox2.Text  + "'";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = i + 1;

                dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][21];
                dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][0];
                dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][1];
                dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][9];
                dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][2];
                dataGridView1.Rows[i].Cells[6].Value = Convert.ToInt32(dt.Rows[i][10]);
                dataGridView1.Rows[i].Cells[7].Value = Convert.ToInt32(dt.Rows[i][4]);
                dataGridView1.Rows[i].Cells[8].Value = (dt.Rows[i][5]);
                dataGridView1.Rows[i].Cells[9].Value = (dt.Rows[i][6]);
                dataGridView1.Rows[i].Cells[10].Value = dt.Rows[i][7];
                dataGridView1.Rows[i].Cells[11].Value = dt.Rows[i][8];
                dataGridView1.Rows[i].Cells[12].Value = dt.Rows[i][22];
                dataGridView1.Rows[i].Cells[13].Value = dt.Rows[i][3];
                dataGridView1.Rows[i].Cells[14].Value = ((DateTime)(dt.Rows[i][11])).ToString("dd.MM.yyyy");
                dataGridView1.Rows[i].Cells[15].Value = dt.Rows[i][12];
                dataGridView1.Rows[i].Cells[16].Value = ((DateTime)(dt.Rows[i][13])).ToString("dd.MM.yyyy");
                dataGridView1.Rows[i].Cells[17].Value = ((DateTime)(dt.Rows[i][14])).ToString("dd.MM.yyyy");
                dataGridView1.Rows[i].Cells[18].Value = dt.Rows[i][15];
                dataGridView1.Rows[i].Cells[19].Value = dt.Rows[i][16];
                dataGridView1.Rows[i].Cells[20].Value = dt.Rows[i][17];
                dataGridView1.Rows[i].Cells[21].Value = dt.Rows[i][18];
                dataGridView1.Rows[i].Cells[22].Value = dt.Rows[i][19];
                dataGridView1.Rows[i].Cells[23].Value = dt.Rows[i][20];
                if (i > 0)
                {
                    dataGridView1.Rows[i].Cells[6].Value = "";
                    dataGridView1.Rows[i].Cells[7].Value = "";
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt;
            OpenFileDialog myDLG1 = new OpenFileDialog();
            if (myDLG1.ShowDialog() == DialogResult.OK)
            {
                string fileName = myDLG1.FileName;
                dt = ReadExcelToTable(fileName);
                string[,] rst = new string[5, 2];
                Dictionary<string, string> dic = new Dictionary<string, string>();
                if (dt.Rows.Count -1 != Convert.ToInt32(textBox3.Text) )
                {
                    MessageBox.Show("不匹配啊");
                    return;
                }
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    //for (int j = 0; j < dt.Columns.Count; j++)

                    //{
                    string[] str;
                    str = dt.Rows[i][4].ToString().Split(';');
                    for (int j = 0; j < str.Length -1 ; j++)
                    {
                        string[] sstr;
                        sstr = str[j].Split(':');
                        //dic.Add(sstr[0], sstr[1]);
                        rst[j, 0] = sstr[0];
                        rst[j, 1] = sstr[1];
                    }
                    //}
                }
                string sss = "";
                for (int i = 0; i < 5; i++ )
                {
                    
                    sss += rst[i, 0] + "哈哈" + rst[i, 1];
                    if (rst[4, 1] != textBox2.Text)
                    {
                        MessageBox.Show("哈哈哈  型号不对");
                        return;
                    }
                    
                    sss += "\r\n";
                }
                myPrint(@"E:\soft\newTest.Lab", dt);
            }
            
        }
        public static DataTable ReadExcelToTable(string path)//excel存放的路径
        {
            try
            {

                //连接字符串
                string connstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1';"; // Office 07及以上版本 不能出现多余的空格 而且分号注意
                //string connstring = Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1';"; //Office 07以下版本 
                using (OleDbConnection conn = new OleDbConnection(connstring))
                {
                    conn.Open();
                    DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" }); //得到所有sheet的名字
                    string firstSheetName = sheetsName.Rows[0][2].ToString(); //得到第一个sheet的名字
                    string sql = string.Format("SELECT * FROM [{0}]", firstSheetName); //查询字符串
                    //string sql = string.Format("SELECT * FROM [{0}] WHERE [日期] is not null", firstSheetName); //查询字符串

                    OleDbDataAdapter ada = new OleDbDataAdapter(sql, connstring);
                    DataSet set = new DataSet();
                    ada.Fill(set);
                    return set.Tables[0];
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void myPrint(string strFile, DataTable dt)
        {

            for (int i = 1; i < dt.Rows.Count; i++)
            {
                //for (int j = 0; j < dt.Columns.Count; j++)

                //{
                string[] str;
                str = dt.Rows[i][4].ToString().Split(';');
                for (int j = 0; j < str.Length - 1; j++)
                {

                    //str[j] = str[j].Substring(str[j].IndexOf(':'), str[j].Length-1);
                   str[j] = str[j].Split(':')[1];
                }
                //}
                
                LabelManager2.ApplicationClass lbl = new LabelManager2.ApplicationClass();

                lbl.Documents.Open(strFile, false);//比较费时间   
                LabelManager2.Document labeldoc = lbl.ActiveDocument;

                labeldoc.Variables.FormVariables.Item("变量2").Value = str[0];
                labeldoc.Variables.FormVariables.Item("变量3").Value = str[1];
                labeldoc.Variables.FormVariables.Item("变量4").Value = str[2];
                labeldoc.Variables.FormVariables.Item("变量5").Value = str[3];
                labeldoc.Variables.FormVariables.Item("变量6").Value = str[4];
                labeldoc.Variables.FormVariables.Item("变量7").Value = "";
                labeldoc.Variables.FormVariables.Item("变量8").Value = "";
                labeldoc.Variables.FormVariables.Item("变量9").Value = "";
                labeldoc.PrintDocument(); //打印一次

                labeldoc.FormFeed();

            }
            string sss = "";
            

            
 
            MessageBox.Show("\"打印条码\"完成！");
                   
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            string sql1 = "select Count(*) from ShippingInfoConfirmBody1 where CsvPo_Id = '" + textBox1.Text + "'";
            DataTable d = SqlHelper.ExecuteDataTable(sql1);
            int index = Convert.ToInt32(d.Rows[0][0].ToString());
            DataTable dt1 = GetDgvToTable(dataGridView1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (dt1.Rows[i][1].ToString() == "")
                {
                    dt1.Rows.RemoveAt(i);
                }
            }
            dt1.Columns.RemoveAt(0);


            for (int i = index; i < dt1.Rows.Count; i++)
            {
                string[] test;
                test = dt1.Rows[i][11].ToString().Split('-');
                if (test[3] == "R")
                {
                    if (dt1.Rows[i][dt1.Columns.Count - 3].ToString() == "")
                    {
                        MessageBox.Show("设备型号 (改机前一次)未输入");
                        return;
                    }
                    if (dt1.Rows[i][dt1.Columns.Count - 2].ToString() == "")
                    {
                        MessageBox.Show("设备序列号 (改机前一次)未输入");
                        return;
                    }
                    if (dt1.Rows[i][dt1.Columns.Count - 1].ToString() == "")
                    {
                        MessageBox.Show("AQID (改机前一次)未输入");
                        return;
                    }
                }
                if (dt1.Rows[i][13].ToString() == "")
                {
                    MessageBox.Show("送货地址未输入");
                    return;
                }

            }
            int number = 0;
            string serial = "select Count(*) from serial_item where serial = '" + textBox2.Text + "'";
            DataTable dt4 = SqlHelper.ExecuteDataTable(serial);
            int ser = Convert.ToInt32(dt4.Rows[0][0].ToString());

            for (int i = index, j=0; i < dt1.Rows.Count; i++, j++)
            {
                string sql2 = "insert into ShippingInfoConfirmBody1 (Company_Id, Shipping_Id, Itm_Full_Id, Scan_Ewm_Id, Po_Itm, Xm_Id, Item_Desc, Shipping_Address, Qty_Shipping, Available_Qty_Serial_Id, Manufacturer_Id, Serial_Id, AQID, PurType_Id, Qty_Po, Planning_Shipping_Date, Already_Shipping_Id, Shipping_Date, Planning_Arrive_Date, Carrier_Id, Lading_Shipping_Id, BarCode_Print_Qty, Item_Spec_Before, ItemSerial_Id_Before, AQID_Before, CsvPo_Id, Item_Spec) values ( @Company_Id, @Shipping_Id, @Itm_Full_Id, @Scan_Ewm_Id, @Po_Itm, @Xm_Id, @Item_Desc, @Shipping_Address, @Qty_Shipping, @Available_Qty_Serial_Id, @Manufacturer_Id, @Serial_Id, @AQID, @PurType_Id, @Qty_Po, @Planning_Shipping_Date, @Already_Shipping_Id, @Shipping_Date, @Planning_Arrive_Date, @Carrier_Id, @Lading_Shipping_Id, @BarCode_Print_Qty, @ItemPrpty_Id_Before, @ItemSerial_Id_Before, @AQID_Before, @CsvPo_Id, @Item_Spec)";

                List<SqlParameter> pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@Company_Id", "company01" + DateTime.Now.ToString() + i.ToString()));
                pars.Add(new SqlParameter("@Shipping_Id", "sadsadas" + DateTime.Now.ToString() + i.ToString()));
                pars.Add(new SqlParameter("@Itm_Full_Id", "asdsadsa" + DateTime.Now.ToString()));
                pars.Add(new SqlParameter("@Scan_Ewm_Id", DateTime.Now));
                pars.Add(new SqlParameter("@Po_Itm", myConvert(dt1.Rows[i][1].ToString())));
                pars.Add(new SqlParameter("@Xm_Id", dt1.Rows[i][2]));
                pars.Add(new SqlParameter("@Item_Desc", dt1.Rows[i][4]));
                pars.Add(new SqlParameter("@Shipping_Address", dt1.Rows[i][12]));
                pars.Add(new SqlParameter("@Qty_Shipping", myConvert(dt1.Rows[i][6].ToString())));
                pars.Add(new SqlParameter("@Available_Qty_Serial_Id", myConvert(dt1.Rows[i][7].ToString())));
                pars.Add(new SqlParameter("@Manufacturer_Id", "CYGIA"));
                pars.Add(new SqlParameter("@Serial_Id", (dt1.Rows[i][9]).ToString()));
                pars.Add(new SqlParameter("@AQID", dt1.Rows[i][10]));
                pars.Add(new SqlParameter("@PurType_Id", dt1.Rows[i][3]));
                pars.Add(new SqlParameter("@Qty_Po", myConvert(dt1.Rows[i][5].ToString())));
                pars.Add(new SqlParameter("@Planning_Shipping_Date", myDatetime(dt1.Rows[i][13].ToString())));
                pars.Add(new SqlParameter("@Already_Shipping_Id", dt1.Rows[i][14]));
                pars.Add(new SqlParameter("@Shipping_Date", myDatetime(dt1.Rows[i][15].ToString())));
                pars.Add(new SqlParameter("@Planning_Arrive_Date", myDatetime(dt1.Rows[i][16].ToString())));
                pars.Add(new SqlParameter("@Carrier_Id", dt1.Rows[i][17]));
                pars.Add(new SqlParameter("@Lading_Shipping_Id", dt1.Rows[i][18]));
                pars.Add(new SqlParameter("@BarCode_Print_Qty", myConvert(dt1.Rows[i][19].ToString())));
                pars.Add(new SqlParameter("@ItemPrpty_Id_Before", dt1.Rows[i][20]));
                pars.Add(new SqlParameter("@ItemSerial_Id_Before", dt1.Rows[i][21]));
                pars.Add(new SqlParameter("@AQID_Before", dt1.Rows[i][22]));
                pars.Add(new SqlParameter("@CsvPo_Id", dt1.Rows[i][0]));
                pars.Add(new SqlParameter("@Item_Spec", dt1.Rows[i][11]));
                //pars.Add(new SqlParameter("@V", ""));
                //pars.Add(new SqlParameter("@APO", ""));

                int rst = SqlHelper.ExecuteQuery(sql2, pars.ToArray());
                number++;
                string ine = "insert into serial_item (id, serial) values ( '" + (ser + 1 + j) + "', '" + dt1.Rows[i][11].ToString() + "')";
                int rstt = SqlHelper.ExecuteQuery(ine);
            }
            MessageBox.Show("共保存" + number + "条数据");
            load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }
        void form5_setFormTextValue(string textValue)
        {
            //具体实现。
            this.textBox1.Text = textValue;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                using (Form5 f5 = new Form5())
                {
                    if (f5.ShowDialog(this) == DialogResult.OK)
                    {
                        dataGridView1.CurrentRow.Cells[e.ColumnIndex].Value = _temp;
                    }
                }
            }
        }
    }
}
