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
    public partial class QueryTreeDataForm : Form
    {
        public QueryTreeDataForm()
        {
            InitializeComponent();
        }

        private string _SysPgm;
        private string _SlectColumn;
        private string _Where;
        private string _WhereQuery;
        private string _WhereTree;
        private bool _MutSelect;
        public QueryTreeDataForm(string SysPgm, string SlectColumn, string Where,bool MutSelect)
        {
            InitializeComponent();
            this._SysPgm = SysPgm;
            this._SlectColumn = SlectColumn;
            this._Where = Where;
            this._MutSelect = MutSelect;
        }

        public string ID;
        public string DESC;

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtWhere.Text))
            {
                _WhereQuery = "   and  Tab.ID like '%" + this.txtWhere.Text.Trim() + "%' or  Tab.Desc_01 like '%" + this.txtWhere.Text.Trim() + "%'";
            }
            GetViewData();
        }

        private void btnSlect_Click(object sender, EventArgs e)
        {
            if (_MutSelect)
            {
                BindingSource _bdSource = new BindingSource();
                _bdSource = dataGridView1.DataSource as BindingSource;
                if (_bdSource != null)
                {
                    DataTable _dtRole = _bdSource.DataSource as DataTable;
                    if (_dtRole.Rows.Count > 0)
                    {
                        string _id = "";
                        string _desc = "";
                        foreach(DataRow _dr in _dtRole.Rows)
                        {
                            if(_dr["Select_Id"].ToString()=="T")
                            {
                               _id += _dr["ID"].ToString()+";";
                               _desc += _dr["Desc_01"].ToString() + ";";
                            }
                        }
                        ID = _id;
                        DESC = _desc;
                        //ID = dataGridView1.CurrentRow.Cells["ID_body"].Value.ToString();
                        //DESC = dataGridView1.CurrentRow.Cells["Desc_body"].Value.ToString();
                    }
                }
            }
            else
            {
                ID = dataGridView1.CurrentRow.Cells["ID_body"].Value.ToString();
                DESC = dataGridView1.CurrentRow.Cells["Desc_body"].Value.ToString();
            }
            this.DialogResult = DialogResult.Yes;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void QueryTreeDataForm_Load(object sender, EventArgs e)
        {
            CreateTree();
            GetViewData();
        }


        private void CreateTree()
        {
            StringBuilder sqlStr = new StringBuilder();
            if (_SysPgm == "Employee")
            {
                sqlStr.Append("select  PGM_Id=Department_Id, NAME=Desc_01, Level_Id, IS_LOWEST  from Department where Company_Id='" + LoginInfo._Usr_Company + "' ");
            }
            else if (_SysPgm == "Item")
            {
                sqlStr.Append("select  PGM_Id=ItemKind_Id, NAME=Desc_01, Level_Id, IS_LOWEST  from ItemKind where Company_Id='" + LoginInfo._Usr_Company + "' ");
            }

            DataSet ds = SqlHelper.ExecuteDataSet(sqlStr.ToString());
            DataTable dt = ds.Tables[0];

            TreeNode treeNode;
            Dictionary<int, TreeNode> treeNodeDict = new Dictionary<int, TreeNode>();

            if (dt != null && dt.Rows.Count > 0)
            {
                string pgm_Id, pgm_Name, is_Lowest;
                int level_Id, parent_Level_Id, itm;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    level_Id = CommomHelper.ToInt(dt.Rows[i]["Level_Id"].ToString());
                    if (level_Id == 0)
                    {
                        //Text = dt.Rows[i]["NAME"].ToString();
                        //continue;
                    }
                    level_Id = level_Id - 1;
                    parent_Level_Id = level_Id - 1;
                    pgm_Id = dt.Rows[i]["PGM_Id"].ToString();
                    pgm_Name = dt.Rows[i]["NAME"].ToString();
                    is_Lowest = dt.Rows[i]["IS_LOWEST"].ToString();
                    treeNode = new TreeNode();
                    treeNode.Name = pgm_Id;
                    treeNode.Text = pgm_Name;
                    if (!treeNodeDict.ContainsKey(parent_Level_Id))
                    {
                        treeView1.Nodes.Add(treeNode);
                    }
                    else
                    {
                        treeNodeDict[parent_Level_Id].Nodes.Add(treeNode);
                    }

                    if (!treeNodeDict.ContainsKey(level_Id))
                    {
                        treeNodeDict.Add(level_Id, treeNode);
                    }
                    else
                    {
                        treeNodeDict[level_Id] = treeNode;
                    }
                }
            }
        }

        private void GetViewData()
        {
            string _mstring = "";
            if(_MutSelect)
            {
                this.dataGridView1.Columns["Select_Id"].Visible = true;
                _mstring = "Select 'F' as Select_Id, ";
            }
            else
            {
                _mstring = "Select 'T' as Select_Id, ";
            }
            StringBuilder _strsql = new StringBuilder();
            _strsql.Append("select * from ( " + _mstring);
            _strsql.Append(_SlectColumn);
            _strsql.Append(" From ");
            _strsql.Append(_SysPgm);
            _strsql.Append(" Where 1=1  ");
            _strsql.Append(_Where);
            _strsql.Append(_WhereTree);
            _strsql.Append(" ) Tab  where 1=1 ");
            _strsql.Append(_WhereQuery);
            DataSet ds = SqlHelper.ExecuteDataSet(_strsql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                BindingSource bindingSource1 = new BindingSource();
                bindingSource1.DataSource = dt;
                this.dataGridView1.DataSource = bindingSource1;
            }
            _WhereTree = "";
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string _pgm_id = e.Node.Name;
            ViewDataGrid(_pgm_id);
        }

        private void ViewDataGrid(string Pgm_id)
        {
            if (_SysPgm == "Employee")
            {
                _WhereTree = " and Department_Id='" + Pgm_id + "'";
            }
            else if (_SysPgm == "Item")
            {
                _WhereTree = " and ItemKind_Id='" + Pgm_id + "'";
            }

            GetViewData();
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (!_MutSelect)
            {
                ID = dataGridView1.CurrentRow.Cells["ID_body"].Value.ToString();
                DESC = dataGridView1.CurrentRow.Cells["Desc_body"].Value.ToString();
                this.DialogResult = DialogResult.Yes;
            }
        }
      
    }
}
