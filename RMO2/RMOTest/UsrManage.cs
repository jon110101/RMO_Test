using RMOTest.DAL;
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

namespace RMOTest
{   
    public partial class UsrManage : Form
    {
        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }

        private string _Usr_id = "";
        public string Usr_id
        {
            set { _Usr_id = value; }
            get { return _Usr_id; }
        }

        public UsrManage()
        {
            InitializeComponent();
        }

        private void UsrManage_Load(object sender, EventArgs e)
        {
            this.txtPwd.PasswordChar = '*';
            this.txtPwd1.PasswordChar = '*';
            string _where="";
            DataTable _dtUsrRole = null;
            DataTable _dtUsr = null;
             if (_Edit == "ADD")
            {
                this.Name = "用户---新增";
                 _where="Where 1<>1";
                 _dtUsrRole=GetDataUsrRole(_where);
                 _dtUsrRole.Columns["ITM"].AutoIncrement = true;
                 _dtUsrRole.Columns["ITM"].AutoIncrementSeed = 1;
                 _dtUsrRole.Columns["ITM"].AutoIncrementStep = 1;
            }
            else if(_Edit=="UPD")
            {
                this.Name = "用户---修改";
                _where = "Where 1=1 and Usr_Id='" + _Usr_id + "'";
                _dtUsrRole = GetDataUsrRole(_where);
                _dtUsr = GetDataUsr(_where);

                if (_dtUsr != null && _dtUsr.Rows.Count > 0)
                {
                    this.txtUsrId.ReadOnly = true;
                    this.txtUsrId.Text = _Usr_id;
                    this.txtName.Text = _dtUsr.Rows[0]["Name"].ToString();
                    this.txtZt.Text = _dtUsr.Rows[0]["ZT_Admin_Id"].ToString();
                    this.txtEmail.Text = _dtUsr.Rows[0]["Remark"].ToString(); //Email暂时存在Remark
                    this.txtLrUsr.Text = _dtUsr.Rows[0]["Usr__Id"].ToString();
                    this.txtCTime.Text = _dtUsr.Rows[0]["Create__Date"].ToString();
                    if (_dtUsr.Rows[0]["ZT_Admin_Id"].ToString()=="Z")
                    {
                          this.dataGridView1.Enabled = false;
                    }
                }
            }

             BindingSource bindingSource1 = new BindingSource();
             bindingSource1.DataSource = _dtUsrRole;
             this.dataGridView1.DataSource = bindingSource1; 
        }

        #region event
        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsrId.Text))
            {
                MessageBox.Show("用户编码不能为空！");
                return;
            }

            if (_Edit == "ADD")
            {
                if (AddUsr())
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
            else if (_Edit == "UPD")
            {
                if (UpdUsr())
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        #endregion

        #region function
        private bool AddUsr()
        {
            string _sqlStr = "Insert Into Usr1(ZT_Id,Usr_Id,Name,Pwd,B_Date,E_Date,ZT_Admin_Id,Status_Id,Usr__Id,Role__Id,Create__Date,Remark )"
                           + "  VALUES(@ZT_Id,@Usr_Id,@Name,@Pwd,@B_Date,@E_Date,@ZT_Admin_Id,@Status_Id,@Usr__Id,@Role__Id,@Create__Date,@Remark );";
            string _sqlCompany = "";
            string _sqlRole = " ";
            DataTable _dt = this.dataGridView1.DataSource as DataTable;
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(_dt.Rows[i]["Company_Id"].ToString()))
                {
                    _sqlCompany += "If ((select 1 from UsrCompany1 where ZT_Id=@ZT_Id and Usr_Id=@Usr_Id and Company_Id='" + _dt.Rows[i]["Company_Id"].ToString() + "') is null) "
                        + "Insert Into UsrCompany1(ZT_Id,Usr_Id,Company_Id,Role__Id,Usr__Id,Create__Date)"
                        + "VALUES(@ZT_Id,@Usr_Id,'" + _dt.Rows[i]["Company_Id"].ToString() + "',@Role__Id,@Usr__Id,@Create__Date ) ; ";
                }
                if (!string.IsNullOrEmpty(_dt.Rows[i]["Company_Id"].ToString()) && !string.IsNullOrEmpty(_dt.Rows[i]["Role_Id"].ToString()))
                {
                    _sqlRole += "If ((select 1 from UsrRole where Usr_Id=@Usr_Id and Company_Id='" + _dt.Rows[i]["Company_Id"].ToString() + "'"
                         + " and Role_Id='" + _dt.Rows[i]["Role_Id"].ToString() + "') is null)"
                         + "Insert Into UsrRole(Usr_Id,Company_Id,Role_Id,Role__Id,Usr__Id,Create__Date)"
                        + "VALUES(@Usr_Id,'" + _dt.Rows[i]["Company_Id"].ToString() + "','"
                        + _dt.Rows[i]["Role_Id"].ToString() + "',@Role__Id,@Usr__Id,@Create__Date) ; ";
                }
            }

            SqlParameter[] paras = new SqlParameter[12];
            paras[0] = new SqlParameter("@ZT_Id", SqlDbType.VarChar, 50);
            paras[0].Value = "RMOTest";

            paras[1] = new SqlParameter("@Usr_Id", SqlDbType.VarChar, 50);
            paras[1].Value = this.txtUsrId.Text.Trim();

            paras[2] = new SqlParameter("@Name", SqlDbType.VarChar, 100);
            paras[2].Value = this.txtName.Text.Trim();

            paras[3] = new SqlParameter("@Pwd", SqlDbType.VarChar, 100);
            paras[3].Value = CommomHelper.GetMD5(this.txtPwd.Text.Trim());

            paras[4] = new SqlParameter("@B_Date", SqlDbType.DateTime);
            paras[4].Value = System.DateTime.Now;

            paras[5] = new SqlParameter("@E_Date", SqlDbType.DateTime);
            paras[5].Value = DBNull.Value;

            paras[6] = new SqlParameter("@ZT_Admin_Id", SqlDbType.VarChar, 1);
            paras[6].Value = "";

            paras[7] = new SqlParameter("@Status_Id", SqlDbType.VarChar, 5);
            paras[7].Value = "";

            paras[8] = new SqlParameter("@Usr__Id", SqlDbType.VarChar, 50);
            paras[8].Value = LoginInfo._Usr_id;

            paras[9] = new SqlParameter("@Role__Id", SqlDbType.VarChar, 50);
            paras[9].Value = ((LoginInfo._ZT_Admin_Id == "Z") ? "" : LoginInfo._Usr_Role);

            paras[10] = new SqlParameter("@Create__Date", SqlDbType.DateTime);
            paras[10].Value = System.DateTime.Now;

            paras[11] = new SqlParameter("@Remark", SqlDbType.Text);
            paras[11].Value = "";

            if (SqlHelper.ExecuteQueryTrans(_sqlCompany + _sqlRole + _sqlStr, paras))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool UpdUsr()
        {
            string UpdColmn = "Name=@Name,B_Date=@B_Date,E_Date=@E_Date,ZT_Admin_Id=@ZT_Admin_Id,Status_Id=@Status_Id,Usr__Id=@Usr__Id,Role__Id=@Role__Id,Create__Date=@Create__Date,Remark=@Remark";
            if (!string.IsNullOrEmpty(this.txtPwd.Text))
            {
                UpdColmn += ",Pwd=@Pwd ";
            }
            string _sqlStr = string.Format("Update   Usr1 set {0}   Where ZT_Id=@ZT_Id and Usr_Id=@Usr_Id ; ",
                UpdColmn);
            string _sqlCompany = " Delete from UsrCompany1 Where ZT_Id=@ZT_Id and Usr_Id=@Usr_Id ;";
            string _sqlRole = " ";

            DataTable _dt = this.dataGridView1.DataSource as DataTable;
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(_dt.Rows[i]["Company_Id"].ToString()))
                {
                    _sqlCompany += "If ((select 1 from UsrCompany1 where ZT_Id=@ZT_Id and Usr_Id=@Usr_Id and Company_Id='" + _dt.Rows[i]["Company_Id"].ToString() + "') is null) "
                        + "Insert Into UsrCompany1(ZT_Id,Usr_Id,Company_Id,Role__Id,Usr__Id,Create__Date)"
                        + "VALUES(@ZT_Id,@Usr_Id,'" + _dt.Rows[i]["Company_Id"].ToString() + "',@Role__Id,@Usr__Id,@Create__Date) ;";
                }
                if (!string.IsNullOrEmpty(_dt.Rows[i]["Company_Id"].ToString()) && !string.IsNullOrEmpty(_dt.Rows[i]["Role_Id"].ToString()))
                {
                    _sqlRole = " Delete from UsrRole Where Company_Id='" + _dt.Rows[i]["Company_Id"].ToString() + "' and Usr_Id=@Usr_Id;";
                    _sqlRole += "If ((select 1 from UsrRole where Usr_Id=@Usr_Id and Company_Id='" + _dt.Rows[i]["Company_Id"].ToString() + "'"
                         + "and Role_Id='" + _dt.Rows[i]["Role_Id"].ToString() + "') is null)"
                         + "Insert Into UsrRole(Usr_Id,Company_Id,Role_Id,Role__Id,Usr__Id,Create__Date)"
                        + "VALUES(@Usr_Id,'" + _dt.Rows[i]["Company_Id"].ToString() + "','"
                        + _dt.Rows[i]["Role_Id"].ToString() + "',@Role__Id,@Usr__Id,@Create__Date) ; ";
                }
            }

            SqlParameter[] paras = new SqlParameter[12];
            paras[0] = new SqlParameter("@ZT_Id", SqlDbType.VarChar, 50);
            paras[0].Value = "RMOTest";

            paras[1] = new SqlParameter("@Usr_Id", SqlDbType.VarChar, 50);
            paras[1].Value = this.txtUsrId.Text.Trim();

            paras[2] = new SqlParameter("@Name", SqlDbType.VarChar, 100);
            paras[2].Value = this.txtName.Text.Trim();

            paras[3] = new SqlParameter("@Pwd", SqlDbType.VarChar, 100);
            paras[3].Value = CommomHelper.GetMD5(this.txtPwd.Text.Trim());

            paras[4] = new SqlParameter("@B_Date", SqlDbType.DateTime);
            paras[4].Value = System.DateTime.Now;

            paras[5] = new SqlParameter("@E_Date", SqlDbType.DateTime);
            paras[5].Value = DBNull.Value;

            paras[6] = new SqlParameter("@ZT_Admin_Id", SqlDbType.VarChar, 1);
            paras[6].Value = "";

            paras[7] = new SqlParameter("@Status_Id", SqlDbType.VarChar, 5);
            paras[7].Value = "";

            paras[8] = new SqlParameter("@Usr__Id", SqlDbType.VarChar, 50);
            paras[8].Value = LoginInfo._Usr_id;

            paras[9] = new SqlParameter("@Role__Id", SqlDbType.VarChar, 50);
            paras[9].Value = ((LoginInfo._ZT_Admin_Id == "Z") ? "" : LoginInfo._Usr_Role);

            paras[10] = new SqlParameter("@Create__Date", SqlDbType.DateTime);
            paras[10].Value = System.DateTime.Now;

            paras[11] = new SqlParameter("@Remark", SqlDbType.Text);
            paras[11].Value = "";

            if (SqlHelper.ExecuteQueryTrans(_sqlCompany + _sqlRole + _sqlStr, paras))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private DataTable GetDataUsrRole(string _where)
        {
            string TableName = "UsrRole";
            string SelectColmn = " ROW_NUMBER() over (order by getdate()) as  itm,Company_Id,Role_Id,Usr_Id ";
            string _sql = string.Format("Select {1}  from {0} ", TableName, SelectColmn);
            _sql += _where;
            DataTable dt = SqlHelper.ExecuteDataTable(_sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                dt.Columns["ITM"].AutoIncrement = true;
                dt.Columns["ITM"].AutoIncrementSeed = (dt.Rows.Count+1);
                dt.Columns["ITM"].AutoIncrementStep = 1;
            }
            return dt;
        }

        private DataTable GetDataUsr(string _where)
        {
            string TableName = "Usr1";
            string SelectColmn = " ZT_Id,Usr_Id,Name,Pwd,B_Date,E_Date,ZT_Admin_Id,Status_Id,Usr__Id,Role__Id,Create__Date,Remark  ";
            string _sql = string.Format("Select {1}  from {0} ", TableName, SelectColmn);
            _sql += _where;
            DataTable dt = SqlHelper.ExecuteDataTable(_sql);
            return dt;
        } 
        #endregion


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn _column = dataGridView1.Columns[e.ColumnIndex];
                BindingSource _bdSource = new BindingSource();
                _bdSource = dataGridView1.DataSource as BindingSource;
                if (_column.DataPropertyName == "Company_Id")
                {
                    QueryForm _qyFrom = null;
                    _qyFrom = new QueryForm("SysCompany", "");
                    _qyFrom.StartPosition = FormStartPosition.Manual;
                    _qyFrom.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                    _qyFrom.TopMost = true;
                    if (_qyFrom.ShowDialog() == DialogResult.Yes)
                    {
                        this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _qyFrom.ID;
                        _bdSource.EndEdit();
                    }
                }
                else if (_column.DataPropertyName == "Role_Id")
                {
                    QueryForm _qyFrom = null;
                    _qyFrom = new QueryForm("Role", "");
                    _qyFrom.StartPosition = FormStartPosition.Manual;
                    _qyFrom.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                    _qyFrom.TopMost = true;
                    if (_qyFrom.ShowDialog() == DialogResult.Yes)
                    {
                        this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _qyFrom.ID;
                        _bdSource.EndEdit();
                    }
                }

            }
        }

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "1";
        }

    }
}
