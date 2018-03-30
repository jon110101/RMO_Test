using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMOTest.BasisManage
{
    public partial class ItemUnitForm : Form
    {
        public ItemUnitForm()
        {
            InitializeComponent();
        }

        private string _ItemId = "";
        public string ItemId
        {
            set { _ItemId = value; }
            get { return _ItemId; }
        }

        public DataTable _dtUnit = null;

        private void BtnOk_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }



    }
}
