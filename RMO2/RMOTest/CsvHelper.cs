using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace RMO
{
    class CsvHelper
    {
        public static void SaveCSV(DataTable dt, string fullPath)//table数据写入csv  
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(fullPath);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            System.IO.FileStream fs = new System.IO.FileStream(fullPath, System.IO.FileMode.Create,
                System.IO.FileAccess.Write);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding("utf-16"));
            string data = "";

            //for (int i = 0; i < dt.Columns.Count; i++)//写入列名  
            //{
            //    data += dt.Columns[i].ColumnName.ToString();
            //    if (i < dt.Columns.Count - 1)
            //    {
            //        data += ",";
            //    }
            //}
            string s1 = "******************* DO NOT CHANGE DATA IN ROW 1 TO 5 AND COLUMNS A TO H ***************************************************";
            string s2 = "******************* 请不要对此文件的第1行到第5行以及第A列到第H列做任何变更 ***************************************";
            string s3 = "PO号\tPO行号\t项目代码\t采购类型\t设备描述\tPO数量\t送货数量	可用数量序号	制造商	设备序列号	AQID	设备型号	送货地址	预计发货日期 (MM/DD/YYYY)	是否发货 (Y/N)	实际发货日期 (MM/DD/YYYY)	预计到达日期 (MM/DD/YYYY)	承运人代码	提单/送货单编号	条码打印数量	设备型号 (改机前一次)	设备序列号 (改机前一次)	AQID (改机前一次)";
            string s4 = "PO Number	PO Line Number	Program Module	Spend Type	Material Description	PO Qty	Shipped Qty	Open Sequence Number	Manufacturer	Serial Number	AQID	MFG Model Number	CM Site	ETD - Estimated Time of Dispatch (MM/DD/YYYY)	To Ship Y/N	Ship Date (MM/DD/YYYY)	ETA - Estimated Time of Arrival (MM/DD/YYYY)	Carrier	AWB/Supplier Ref	Barcode Print QTY	Previous Model	Previous Serial	Previous AQID";
            string s5 = "Mandatory (30)	Mandatory ( 5)	Mandatory (40)	Mandatory (10)	Optional (80)	Optional (13)	Optional (13)	Optional (13)	Mandatory (30)	Mandatory (30)	Optional (18)	Mandatory (150)	Mandatory (20)	Optional (10)	Mandatory ( 1)	Mandatory (10)	Mandatory (10)	Optional ( 4)	Optional (20)	Mandatory ( 5)	Optional (150)	Optional (30)	Optional (18)";
            string s6 = "******************* DO NOT ADD NEW ROWS IN THE FILE  … 不要添加新行到文件 ***************************************************																						";
            sw.WriteLine(s1);
            sw.WriteLine(s2);
            sw.WriteLine(s3);
            sw.WriteLine(s4);
            sw.WriteLine(s5);


            for (int i = 0; i < dt.Rows.Count; i++) //写入各行数据  
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    //string str;
                    //if (j == 11 || j == 13 || j == 14)
                    //{

                    //    str = ((DateTime)dt.Rows[i][j]).ToString("dd.MM.yyyy");

                    //}
                    //else
                    //{
                    string str = dt.Rows[i][j].ToString();
                    //}
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号  
                    if (str.Contains(',') || str.Contains('"')
                        || str.Contains('\r') || str.Contains('\n')) //含逗号 冒号 换行符的需要放到引号中  
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += "\t";
                    }
                }
                sw.WriteLine(data);
            }
            sw.WriteLine(s6);
            sw.Close();
            fs.Close();
        }
        //public static DataTable OpenCSV(string filePath)//从csv读取数据返回table  
        //{
        //    //System.Text.Encoding encoding = GetType(filePath); //Encoding.ASCII;//  
        //    DataTable dt = new DataTable();
        //    System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open,
        //        System.IO.FileAccess.Read);

        //    System.IO.StreamReader sr = new System.IO.StreamReader(fs, Encoding.GetEncoding("gb2312"));

        //    //记录每次读取的一行记录  
        //    string strLine = "";
        //    //记录每行记录中的各字段内容  
        //    string[] aryLine = null;
        //    string[] tableHead = null;
        //    //标示列数  
        //    int columnCount = 0;
        //    //标示是否是读取的第一行  
        //    bool IsFirst = true;
        //    //逐行读取CSV中的数据  
        //    while ((strLine = sr.ReadLine()) != null)
        //    {
        //        if (IsFirst == true)
        //        {
        //            tableHead = strLine.Split(',');
        //            IsFirst = false;
        //            columnCount = tableHead.Length;
        //            //创建列  
        //            for (int i = 0; i < columnCount; i++)
        //            {
        //                DataColumn dc = new DataColumn(tableHead[i]);
        //                dt.Columns.Add(dc);
        //            }
        //        }
        //        else
        //        {
        //            aryLine = strLine.Split(',');
        //            DataRow dr = dt.NewRow();
        //            for (int j = 0; j < columnCount; j++)
        //            {
        //                dr[j] = aryLine[j];
        //            }
        //            dt.Rows.Add(dr);
        //        }
        //    }
        //    if (aryLine != null && aryLine.Length > 0)
        //    {
        //        dt.DefaultView.Sort = tableHead[0] + " " + "asc";
        //    }

        //    sr.Close();
        //    fs.Close();
        //    return dt;
        //}

        public static DataTable OpenCSV(string filePath)
        {
            DataTable dt = new DataTable();
            List<string> list = new List<string>();
            FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("utf-16"));
            //StreamReader sr = new StreamReader(fs, encoding);
            //string fileContent = sr.ReadToEnd();
            //记录每次读取的一行记录

            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            string[] tableHead = null;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;
            //逐行读取CSV中的数据
            string[][] res;
            string[] temp;
            int index = 0;
            while ((strLine = sr.ReadLine()) != null)
            {
                //if (index <= 4)
                //{
                //    index++;
                //    continue;
                //}
                //strLine = new System.Text.RegularExpressions.Regex("[\\s]+").Replace(strLine, " ");
                //if (strLine.Contains("****"))
                //{
                //    break;
                //}
                //list.Add(strLine);
                if (strLine.Contains("***"))
                {
                    list.Add(strLine);
                    continue;
                }
                if (IsFirst == true)
                {
                    tableHead = strLine.Split('\t');
                    IsFirst = false;
                    columnCount = tableHead.Length;
                    //创建列
                    for (int i = 0; i < columnCount; i++)
                    {
                        tableHead[i] = tableHead[i].Replace("\"", "");
                        DataColumn dc = new DataColumn(i.ToString());
                        dt.Columns.Add(dc);
                    }
                }

                else
                {
                    aryLine = strLine.Split('\t');
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < columnCount; j++)
                    {

                        dr[j] = aryLine[j].Replace("\"", "");
                    }
                    dt.Rows.Add(dr);
                }
            }
            //if (aryLine != null && aryLine.Length > 0)
            //{
            //    dt.DefaultView.Sort = tableHead[2] + " " + "DESC";
            //}
            sr.Close();
            fs.Close();
            return dt;

        }

        public void op()
        {

        }
        //public static DataTable ReadExcelToTable(string path)//excel存放的路径
        //{
        //    try
        //    {

        //        //连接字符串
        //        string connstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1';"; // Office 07及以上版本 不能出现多余的空格 而且分号注意
        //        //string connstring = Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1';"; //Office 07以下版本 
        //        using (OleDbConnection conn = new OleDbConnection(connstring))
        //        {
        //            conn.Open();
        //            DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" }); //得到所有sheet的名字
        //            string firstSheetName = sheetsName.Rows[0][2].ToString(); //得到第一个sheet的名字
        //            string sql = string.Format("SELECT * FROM [{0}]", firstSheetName); //查询字符串
        //            //string sql = string.Format("SELECT * FROM [{0}] WHERE [日期] is not null", firstSheetName); //查询字符串

        //            OleDbDataAdapter ada = new OleDbDataAdapter(sql, connstring);
        //            DataSet set = new DataSet();
        //            ada.Fill(set);
        //            return set.Tables[0];
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
        //private Stopwatch wath = new Stopwatch();
        /// <summary>
        /// 使用COM读取Excel
        /// </summary>
        /// <param name="excelFilePath">路径</param>
        /// <returns>DataTabel</returns>
        public static System.Data.DataTable GetExcelData(string excelFilePath)
        {
            Excel.Application app = new Excel.Application();
            Excel.Sheets sheets;
            Excel.Workbook workbook = null;
            object oMissiong = System.Reflection.Missing.Value;
            System.Data.DataTable dt = new System.Data.DataTable();
            //wath.Start();
            try
            {
                if (app == null)
                {
                    return null;
                }
                workbook = app.Workbooks.Open(excelFilePath, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong,
                  oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                //将数据读入到DataTable中——Start  
                sheets = workbook.Worksheets;
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);//读取第一张表
                if (worksheet == null)
                    return null;
                string cellContent;
                int iRowCount = worksheet.UsedRange.Rows.Count;
                int iColCount = worksheet.UsedRange.Columns.Count;
                Excel.Range range;
                //负责列头Start
                DataColumn dc;
                int ColumnID = 1;
                range = (Excel.Range)worksheet.Cells[1, 1];
                while (range.Text.ToString().Trim() != "")
                {
                    dc = new DataColumn();
                    dc.DataType = System.Type.GetType("System.String");
                    dc.ColumnName = range.Text.ToString().Trim();
                    dt.Columns.Add(dc);

                    range = (Excel.Range)worksheet.Cells[1, ++ColumnID];
                }
                //End
                for (int iRow = 2; iRow <= iRowCount; iRow++)
                {
                    DataRow dr = dt.NewRow();
                    for (int iCol = 1; iCol <= iColCount; iCol++)
                    {
                        range = (Excel.Range)worksheet.Cells[iRow, iCol];
                        cellContent = (range.Value2 == null) ? "" : range.Text.ToString();
                        dr[iCol - 1] = cellContent;
                    }
                    dt.Rows.Add(dr);
                }
                //wath.Stop();
                //TimeSpan ts = wath.Elapsed;
                //将数据读入到DataTable中——End
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                workbook.Close(false, oMissiong, oMissiong);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                app = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        public static DataTable GetDgvToTable(DataGridView dgv)
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
    }
}
