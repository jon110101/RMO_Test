using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RMOTest.DAL;

namespace RMOTest
{
    public partial class UsrUcForm : UserControl
    {
        private SubForm _ownerFrom;
        public UsrUcForm(SubForm ownerForm)
        {
            InitializeComponent();
            this._ownerFrom = ownerForm;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            _ownerFrom.CloseThisFrom("Usr");
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            string _where = "Where 1=1";
            string _NotNullWhere="";
            if (!string.IsNullOrEmpty(this.textBoxContainButton1.Text) && !string.IsNullOrEmpty(this.textBoxContainButton2.Text))
            {
                _NotNullWhere += string.Format("and Usr_Id between '{0}'  and '{1}'", this.textBoxContainButton1.Text, this.textBoxContainButton2.Text);
            }
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                _NotNullWhere += string.Format("and Name like '%{0}%'", this.txtName.Text);
            }
            if(string.IsNullOrEmpty(_NotNullWhere)&&  LoginInfo._ZT_Admin_Id != "Z")
            {
                _where = "Where isnull(Usr__Id,'')='" + LoginInfo._Usr_id + "'";
            }
            else
            {
                _where += _NotNullWhere;
            }

            string sqlStr = "Select ROW_NUMBER() over (order by getdate()) as P_Itm,Usr_Id,Name,ZT_Admin_Id,Usr__Id,Create__Date,Remark From Usr1 ";
            sqlStr += _where;
            DataTable dt = SqlHelper.ExecuteDataTable(sqlStr);
            dt.Columns["P_Itm"].AutoIncrement = true;
            dt.Columns["P_Itm"].AutoIncrementSeed = 1;
            dt.Columns["P_Itm"].AutoIncrementStep = 1;
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.AllowUserToAddRows = false;
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string _Usr_Id = (this.dataGridView1.SelectedRows[0].Cells["Usr_id"].Value).ToString();
                    string _ZT_Id = (this.dataGridView1.SelectedRows[0].Cells["ZT_Id"].Value).ToString();
                    string slqStr = string.Format("Delete Usr1 Where Usr_id='{0}' and ZT_Id='{1}' ", _Usr_Id, _ZT_Id);
                    try
                    {
                        int i = SqlHelper.ExecuteQuery(slqStr);
                        if (i > 0)
                        {
                            BtnQuery_Click(null, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            UsrManage _roleMge = new UsrManage();
            _roleMge.Edit = "ADD";
            if (_roleMge.ShowDialog() != DialogResult.OK)
            {
                ResetView();
            }
        }

        private void BtnUpd_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string _Usr_id = "";
                    DataGridViewRow _dr = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index];
                    if (_dr != null)
                    {
                        _Usr_id = string.IsNullOrEmpty((_dr.Cells["Usr_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["Usr_Id"].Value.ToString()).ToString();
                    }
                    UsrManage _roleMge = new UsrManage();
                    _roleMge.Edit = "UPD";
                    _roleMge.Usr_id = _Usr_id;
                    if (_roleMge.ShowDialog() != DialogResult.OK)
                    {
                        ResetView();
                    }
                }
            }
        }

        private void UsrUcForm_Load(object sender, EventArgs e)
        {
            this.textBoxContainButton1.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton2.ButtonSelectClick += textBoxContainButton1_Click;
        }

        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.Text = CommomHelper.GetQuery("Usr1","");
        }

        private void ResetView()
        {
            string sqlStr = "Select ROW_NUMBER() over (order by getdate()) as P_Itm,Usr_Id,Name,ZT_Admin_Id,Usr__Id,Create__Date,Remark From Usr1  Where 1=1";
            DataTable dt = SqlHelper.ExecuteDataTable(sqlStr);
            this.dataGridView1.DataSource = dt;
        }

      
    }
}
