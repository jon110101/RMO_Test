using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RMO.BasisManage
{
    public partial class ProjectStageForm : UserControl
    {
        private SubForm _ownerFrom;
        public ProjectStageForm(SubForm ownerForm)
        {
            InitializeComponent();
            this._ownerFrom = ownerForm;
        }

        private void QueryData(string _where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ROW_NUMBER() over (order by getdate()) as  Itm,ProjectStage_Id,Desc_01,Parent_ProjectStage_Id,Remark,Usr__Id,Create__Date from ProjectStage ");
            strSql.Append(_where);
            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            dt.Columns["ITM"].AutoIncrement = true;
            dt.Columns["ITM"].AutoIncrementSeed = 1;
            dt.Columns["ITM"].AutoIncrementStep = 1;
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.AllowUserToAddRows = false;
        }

        public bool Delete(string ProjectStage_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProjectStage ");
            strSql.Append(" where  ProjectStage_Id=@ProjectStage_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProjectStage_Id", SqlDbType.NVarChar,50)			};
            parameters[0].Value = ProjectStage_Id;
            int rows = SqlHelper.ExecuteQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            StringBuilder _NotNullWhere = new StringBuilder();
            _NotNullWhere.Append(" Where 1=1 ");
            if (!string.IsNullOrEmpty(this.textBoxContainButton1.ID) && !string.IsNullOrEmpty(this.textBoxContainButton2.ID))
            {
                _NotNullWhere.Append(string.Format("and ProjectStage_Id between '{0}'  and '{1}'", this.textBoxContainButton1.ID, this.textBoxContainButton2.ID));
            }
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                _NotNullWhere.Append(string.Format("and Desc_01 like '%{0}%'", this.txtName.Text));
            }
            QueryData(_NotNullWhere.ToString());
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ProjectStageManage _Manage = new ProjectStageManage();
            _Manage.Edit = "ADD";
            if (_Manage.ShowDialog() != DialogResult.OK)
            {
                string _where = " Where 1=1 ";
                QueryData(_where);
            }
        }

        private void BtnUpd_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string _Company_Id = "";
                    string _ProjectStage_Id = "";
                    DataGridViewRow _dr = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index];
                    if (_dr != null)
                    {
                        _ProjectStage_Id = string.IsNullOrEmpty((_dr.Cells["ProjectStage_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["ProjectStage_Id"].Value.ToString()).ToString();
                    }
                    ProjectStageManage _Manage = new ProjectStageManage();
                    _Manage.Edit = "UPD";
                    _Manage.ProjectStage_Id = _ProjectStage_Id;
                    if (_Manage.ShowDialog() != DialogResult.OK)
                    {
                        string _where = " Where 1=1 ";
                        QueryData(_where);
                    }
                }
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    DataGridViewRow _dr = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index];
                    if (_dr != null)
                    {
                        string _ProjectStage_Id = string.IsNullOrEmpty((_dr.Cells["ProjectStage_Id"].Value.ToString()).ToString()) ? "" : (_dr.Cells["ProjectStage_Id"].Value.ToString()).ToString();
                        try
                        {
                            bool _delOk = Delete(_ProjectStage_Id);
                            if (_delOk)
                            {
                                string _where = " Where 1=1 ";
                                QueryData(_where);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            _ownerFrom.CloseThisFrom("ProjectStage");
        }

        private void ProjectStageForm_Load(object sender, EventArgs e)
        {
            this.textBoxContainButton1.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton2.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton1.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton1.TextLeave += textBoxContainButton1_TextLeave;
            this.textBoxContainButton2.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton2.TextLeave += textBoxContainButton1_TextLeave;

            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void textBoxContainButton1_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("ProjectStage", "ProjectStage_ID", e);
        }

        private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("ProjectStage", "ProjectStage_ID", e);
        }

        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            string _columns = " ID=ProjectStage_ID,Desc_01=Desc_01 ";
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _ht = CommomHelper.GetQuery1("ProjectStage", _columns, "");
            }
            else
            {
                string _where = "and ProjectStage.Company_Id='" + LoginInfo._Usr_Company + "' ";
                _ht = CommomHelper.GetQuery1("ProjectStage", _columns, _where);
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
