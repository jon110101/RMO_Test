
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

namespace RMO
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.cbxGroup.SelectedIndex = 0;
            this.txtPwd.PasswordChar = '*';
            WindowState = FormWindowState.Maximized;
            this.textBoxContainButton1.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton2.ButtonSelectClick += textBoxContainButton2_Click;
            this.textBoxContainButton1.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton1.TextLeave += textBoxContainButton1_TextLeave;
            this.textBoxContainButton2.TextEnter += textBoxContainButton2_TextEnter;
            this.textBoxContainButton2.TextLeave += textBoxContainButton2_TextLeave;

            
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtUsr.Text) || string.IsNullOrEmpty(this.txtPwd.Text))
            {
                MessageBox.Show("用户和密码必须输入！");
            }
            else
            {
                DataTable _dtUsr = GetUsrInfo();
                if (_dtUsr != null && _dtUsr.Rows.Count > 0)
                {
                    if (_dtUsr.Rows[0]["ZT_Admin_Id"].ToString() == "Z") //超级用户
                    {
                        Login(_dtUsr);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(this.textBoxContainButton1.Text) || string.IsNullOrEmpty(this.textBoxContainButton2.Text))
                        {
                            MessageBox.Show("非超级用户必须输入公司和对应角色！");
                        }
                        else
                        {
                            Login(_dtUsr);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("用户不存在！");
                }
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private DataTable GetUsrInfo()
        {
            string sqlStr = "Select  *  from Usr1 where Usr_Id=@Usr_Id";
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@Usr_Id", SqlDbType.VarChar, 50);
            paras[0].Value = this.txtUsr.Text.Trim();
            DataTable _dtUsr = SqlHelper.ExecuteDataTable(sqlStr, paras);
            return _dtUsr;
        }

        private void Login(DataTable _dtUsr)
        {
            if (_dtUsr.Rows[0]["Pwd_Web"].ToString() == CommomHelper.GetMD5(this.txtPwd.Text.Trim()))
            {
                LoginInfo._Usr_id = _dtUsr.Rows[0]["Usr_Id"].ToString();
                LoginInfo._ZT_Admin_Id = _dtUsr.Rows[0]["ZT_Admin_Id"].ToString();
                if (_dtUsr.Rows[0]["ZT_Admin_Id"].ToString() != "Z") //超级用户
                {
                    LoginInfo._Usr_Company = string.IsNullOrEmpty(this.textBoxContainButton1.ID) ? "" : this.textBoxContainButton1.ID;
                    LoginInfo._Usr_Role = string.IsNullOrEmpty(this.textBoxContainButton2.ID) ? "" : this.textBoxContainButton2.ID;
                }
                else
                {
                    string sqlStr = "Select  Company_Id  from SysCompany1 where isnull(Company_Up,'')=''";
                    object _dtCompany = SqlHelper.ExecuteScalar(sqlStr);
                    LoginInfo._Usr_Company = _dtCompany.ToString();
                    LoginInfo._Usr_Role = string.IsNullOrEmpty(this.textBoxContainButton2.ID) ? "" : this.textBoxContainButton2.ID;
                }
                MainForm _main = new MainForm();
                this.Hide();
                _main.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("密码错误！");
            }
        }

        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _where = "and UsrCompany1.Usr_id='" + txtUsr.Text + "'";
            string _columns = " ID=Usr_Id,Desc_01=Usr_Id ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            _ht = CommomHelper.GetQuery1("UsrCompany1", _columns, _where);
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
            string _company_id = string.IsNullOrEmpty(this.textBoxContainButton1.ID) ? "" : this.textBoxContainButton1.ID;
            string _where = "and UsrRole.Usr_id='" + txtUsr.Text + "' and UsrRole.Company_Id='" + _company_id + "' ";
            string _columns = " ID=Role_Id,Desc_01=Role_Id ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            _ht = CommomHelper.GetQuery1("UsrRole", _columns, _where);
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
            _txt.ToFormatStringEnter("UsrCompany1", "Usr_ID", e);
        }
        private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("UsrCompany1", "Usr_ID", e);
        }

        private void textBoxContainButton2_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("UsrRole", "Usr_ID", e);
        }
        private void textBoxContainButton2_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("UsrRole", "Usr_ID", e);
        }

    }
}
