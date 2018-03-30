using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMO
{
    public partial class Barcode : Form
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
        public string _SHIP = "";
        public string SHIP
        {
            set { _SHIP = value; }
            get { return _SHIP; }
        }
        public Barcode()
        {
            
            InitializeComponent();
            
        }


        private void Barcode_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = _PO;

            load();
            
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OpenFileDialog myDLG1 = new OpenFileDialog();
            if (myDLG1.ShowDialog() == DialogResult.OK)
            {
                dt = CsvHelper.GetExcelData(myDLG1.FileName);
                int index = 0;
                //if (dt.Rows.Count - 1 != (Convert.ToInt32(textBox2.Text) * 2))
                //{
                //    MessageBox.Show("导入错误，可能是文件不匹配");
                //    return;
                //}
                if (dt == null || dt.Rows.Count < 1)
                {
                    MessageBox.Show("输入错误");
                    return;
                } 
                int number = 0;
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][2].ToString() == textBox1.Text)
                    {
                        string sql2 = "select count(*) from ShippingInfoConfirmBody2 where CsvPo_Id = '" + textBox1.Text + "' and Serial_Id = '" + dt.Rows[i][1] + "' ";
                        DataTable dt2 = SqlHelper.ExecuteDataTable(sql2);
                        if (Convert.ToInt32(dt2.Rows[0][0].ToString()) > 1 ) continue;
                        string v = (dt.Rows[i][4].ToString().Split(';')[0]).Split(':')[1];
                        string model = dt.Rows[i][3].ToString();
                        string sql1 = "select count(*) from ShippingInfoConfirmBody2 where CsvPo_Id = '" + textBox1.Text + "' and Item_Spec = '" + model + "' ";
                        DataTable dt1 = SqlHelper.ExecuteDataTable(sql1);
                        index = Convert.ToInt32(dt1.Rows[0][0].ToString());
                        int item = index + 1;
                        string bar = dt.Rows[i][1].ToString() + i;
                        string sql = "insert into ShippingInfoConfirmBody2 (Company_Id, Shipping_Id, Itm_Full_Id, Scan_Ewm_Id, Itm2, AQID, APO, Serial_Id, Item_Spec, V, Bar_Code, CsvPo_Id, Print_Times) values ('" + DateTime.Now.ToString() + "', '"+ SHIP + "asdsa', '"+ DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','"+ item + "','" + dt.Rows[i][0] + "','" + dt.Rows[i][2] + "', '" + dt.Rows[i][1] + "', '" + model + "', '" + v + "', '" + dt.Rows[i][4].ToString() + "', '" + textBox1.Text+ "', '" + 0 + "') ";

                        int rst = SqlHelper.ExecuteQuery(sql);
                        number++;
                    }
                }
                MessageBox.Show("导入" + number + "条记录");
            }
            load();
        }

        public void load()
        {
            string sql = "select V,AQID,Serial_Id,APO, Item_Spec, Bar_Code, Print_Times, Itm2 from ShippingInfoConfirmBody2 order by Itm2 ASC";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            dataGridView1.Rows.Clear();
            if (dt.Rows.Count == 0) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value= 0;
                dataGridView1.Rows[i].Cells[1].Value = i + 1;
                dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][0];
                dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][1];
                dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][2];
                dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][3];
                dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][4];
                dataGridView1.Rows[i].Cells[7].Value = dt.Rows[i][5];
                dataGridView1.Rows[i].Cells[8].Value = dt.Rows[i][6];
                dataGridView1.Rows[i].Cells[9].Value = dt.Rows[i][7];

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = System.AppDomain.CurrentDomain.BaseDirectory + @"\newTest1.Lab"; 
            DataTable dt = GetDgvToTable(dataGridView1);
            int number = 0;


            for (int i = 0; i < dt.Rows.Count; i++)
            { 
                if ( (dt.Rows[i][0]).ToString() == "True" )
                {
                    LabelManager2.ApplicationClass lbl = new LabelManager2.ApplicationClass();

                    lbl.Documents.Open(fileName, false);//比较费时间   
                    LabelManager2.Document labeldoc = lbl.ActiveDocument;

                    labeldoc.Variables.FormVariables.Item("变量2").Value = dt.Rows[i][2].ToString();
                    labeldoc.Variables.FormVariables.Item("变量3").Value = dt.Rows[i][3].ToString();
                    labeldoc.Variables.FormVariables.Item("变量4").Value = dt.Rows[i][4].ToString();
                    labeldoc.Variables.FormVariables.Item("变量5").Value = dt.Rows[i][5].ToString();
                    labeldoc.Variables.FormVariables.Item("变量6").Value = dt.Rows[i][6].ToString();
                    labeldoc.Variables.FormVariables.Item("变量9").Value = dt.Rows[i][7].ToString(); ;
                    labeldoc.PrintDocument(); //打印一次

                    //labeldoc.formfeed();
                    number++;
                    
                    string sql1 = "select Print_Times from ShippingInfoConfirmBody2 where Itm2 = '" + dt.Rows[i][9] + "'";
                    DataTable dt1 = SqlHelper.ExecuteDataTable(sql1);
                    int bar = Convert.ToInt32(dt1.Rows[0][0]) + 1;
                    string sql2 = "update ShippingInfoConfirmBody2 set Print_Times = '" + bar + "' where Itm2 = '" + dt.Rows[i][9] + "'";
                    int rst = SqlHelper.ExecuteQuery(sql2);

                }
            }
            MessageBox.Show("共打印" + number + "条记录");
            load();

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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
