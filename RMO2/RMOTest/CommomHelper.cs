using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMO
{
    public class CommomHelper
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static string GetMD5(string myString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }
            return byte2String;
        }

        public static string GetQuery(string PgmName, string Columns, string _Where)
        {
            string RtValue = "";
            QueryDataForm _qyFrom = null;
            _qyFrom = new QueryDataForm(PgmName, Columns, _Where);
           // _qyFrom.StartPosition = FormStartPosition.Manual;
           // _qyFrom.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
           // _qyFrom.TopMost = true;
            if (_qyFrom.ShowDialog() == DialogResult.Yes)
            {
                RtValue = _qyFrom.ID;
                _qyFrom.Dispose();
            }
            return RtValue;
        }

        public static Dictionary<string, object> GetQuery1(string PgmName, string Columns, string _Where)
        {
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (PgmName == "Employee_MutSelect" || PgmName == "Item")
            {
                string _PgmName = PgmName;
                bool Mutselect = false;
                if(PgmName=="Employee_MutSelect")
                {
                    _PgmName = "Employee";
                    Mutselect = true;
                }
                QueryTreeDataForm _qyFrom = null;
                _qyFrom = new QueryTreeDataForm(_PgmName, Columns, _Where, Mutselect);
                //_qyFrom.StartPosition = FormStartPosition.Manual;
                //_qyFrom.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
               // _qyFrom.TopMost = true;
                if (_qyFrom.ShowDialog() == DialogResult.Yes)
                {
                    _ht["ID"] = _qyFrom.ID;
                    _ht["DESC"] = _qyFrom.DESC;
                    _qyFrom.Dispose();
                }
            }
            else
            {
                QueryDataForm _qyFrom = null;
                _qyFrom = new QueryDataForm(PgmName, Columns, _Where);
                //_qyFrom.StartPosition = FormStartPosition.Manual;
                //_qyFrom.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                //_qyFrom.TopMost = true;
                if (_qyFrom.ShowDialog() == DialogResult.Yes)
                {
                    _ht["ID"] = _qyFrom.ID;
                    _ht["DESC"] = _qyFrom.DESC;
                    _qyFrom.Dispose();
                }
            }
            return _ht;
        }

        public static bool Exists(string _Tablename, string _where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from "+_Tablename);
            strSql.Append(" where 1=1 ");
            strSql.Append(_where);
            object obj = SqlHelper.GetSingle(strSql.ToString());
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static decimal ToDecimal(object data)
        {
            if (data == null)
                return 0;
            decimal result;
            return decimal.TryParse(data.ToString(), out result) ? result : 0;
        }

        public static int ToInt(object data)
        {
            if (data == null)
                return 0;
            int result;
            return int.TryParse(data.ToString(), out result) ? result : 0;
        }

        public static bool ChkDel(string _msg)
        {
            DialogResult dr = MessageBox.Show(_msg, "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }



    public class LoginInfo
    {
        public static string _Usr_id;
        public static string _ZT_Admin_Id;
        public static string _Usr_Company;
        public static string _Usr_Role;
    }
}
