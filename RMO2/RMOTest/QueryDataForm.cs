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
    public partial class QueryDataForm : Form
    {
        public QueryDataForm()
        {
            InitializeComponent();
        }
        private string _SysPgm;
        private string _SlectColumn;
        private string _Where;
        private string _WhereQuery;

        public QueryDataForm(string _SysPgm, string SlectColumn, string Where)
        {
            InitializeComponent();
            this._SysPgm = _SysPgm;
            this._SlectColumn = SlectColumn;
            this._Where = Where;
        }

        public string ID;
        public string DESC;

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtWhere.Text))
            {
                _WhereQuery = "   Where Tab.ID like '%" + this.txtWhere.Text.Trim() + "%' or  Tab.Desc_01 like '%" + this.txtWhere.Text.Trim() + "%'";
            }
            GetViewData();
        }

        private void btnSlect_Click(object sender, EventArgs e)
        {
            ID = dataGridView1.CurrentRow.Cells["NO"].Value.ToString();
            DESC = dataGridView1.CurrentRow.Cells["Desc"].Value.ToString();
            this.DialogResult = DialogResult.Yes;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void QueryDataForm_Load(object sender, EventArgs e)
        {
            GetViewData();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dataGridView1.CurrentRow.Cells["NO"].Value.ToString();
            DESC = dataGridView1.CurrentRow.Cells["Desc"].Value.ToString();
            this.DialogResult = DialogResult.Yes;
        }

        private void GetViewData()
        {
            StringBuilder _strsql = new StringBuilder();
            _strsql.Append("select * from ( Select ");
            _strsql.Append(_SlectColumn);
            _strsql.Append(" From ");
            _strsql.Append(_SysPgm);
            _strsql.Append(" Where 1=1  ");
            _strsql.Append(_Where);
            _strsql.Append(" ) Tab");
            _strsql.Append(_WhereQuery);
            DataSet ds = SqlHelper.ExecuteDataSet(_strsql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                BindingSource bindingSource1 = new BindingSource();
                bindingSource1.DataSource = dt;
                this.dataGridView1.DataSource = bindingSource1;
            }
        }

    }
}
