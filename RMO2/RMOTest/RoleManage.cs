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
    public partial class RoleManage : Form
    {
        private bool M_select = true;
        private string _treeString = "";
        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }

        private string _Company_Id = "";
        public string Company_Id
        {
            set { _Company_Id = value; }
            get { return _Company_Id; }
        }


        private string _Role_Id = "";
        public string Role_Id
        {
            set { _Role_Id = value; }
            get { return _Role_Id; }
        }
       
        public RoleManage()
        {
            InitializeComponent();
        }

        private void RoleManage_Load(object sender, EventArgs e)
        {
            CreateTreeView();
            if (_Edit == "ADD")
            {
                this.Name = "角色---新增";

            }
            else if(_Edit=="UPD")
            {
                this.textBoxContainButton1.ReadOnly = true;
                this.txtRoleID.ReadOnly=true;
                this.Name = "角色---修改";
                DataTable _dtRole = GetRoleData(_Company_Id, _Role_Id);
                if(_dtRole!=null&&_dtRole.Rows.Count>0)
                {
                    this.textBoxContainButton1.Text = _dtRole.Rows[0]["Company_Id"].ToString();
                    this.txtRoleID.Text = _dtRole.Rows[0]["Role_ID"].ToString();
                    this.txtRoleName.Text = _dtRole.Rows[0]["Desc_01"].ToString();
                    this.textBoxContainButton3.Text = _dtRole.Rows[0]["Parent_Role_Id"].ToString();
                    this.txtLrUsr.Text=_dtRole.Rows[0]["Usr__Id"].ToString();
                    this.txtCtTime.Text = _dtRole.Rows[0]["Create__Time"].ToString();  
                }
            }

            this.textBoxContainButton1.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton3.ButtonSelectClick += textBoxContainButton2_Click;
          
        }

        private DataTable GetRoleData(string _company_id, string _role_id)
        {
            string _sql = "select * from Role where Company_Id=@Company_Id and  Role_id=@Role_Id";
            SqlParameter[] paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@Company_Id", SqlDbType.VarChar, 50);
            paras[0].Value = _company_id;
            paras[1] = new SqlParameter("@Role_Id", SqlDbType.VarChar, 50);
            paras[1].Value = _role_id;
            DataTable dt = SqlHelper.ExecuteDataTable(_sql,paras);
            return dt;
        }

        private void textBoxContainButton1_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _txt.Text = CommomHelper.GetQuery("SysCompany","");
            }
            else
            {
                string _where = "and UsrCompany1.Usr_id='" + LoginInfo._Usr_id + "'";
                _txt.Text = CommomHelper.GetQuery("UsrCompany1", _where);
            }
        }

        private void textBoxContainButton2_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _txt.Text = CommomHelper.GetQuery("Role", "");
            }
            else
            {
                string _where = "and UsrRole.Usr_id='" + LoginInfo._Usr_id + "'";
                _txt.Text = CommomHelper.GetQuery("UsrRole", _where);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxContainButton1.Text))
            {
                MessageBox.Show("公司编码不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(textBoxContainButton1.Text))
            {
                MessageBox.Show("角色编码不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(txtRoleName.Text))
            {
                MessageBox.Show("角色名称不能为空！");
                return;
            }
            if (_Edit == "ADD")
            {
                if (AddRole())
                {
                    this.DialogResult = DialogResult.Yes;
                }  
            }
            else if (_Edit == "UPD")
            {
                if (UpdRole())
                {
                    this.DialogResult = DialogResult.Yes;
                }  
            }
                     
        }

        public void CreateTreeView()
        {
            string sqlStr = "select  PGM_Id, NAME=ShortName_01, Level_Id=Pgm_Level, IS_LOWEST,Itm  from SysPgm Order By Itm Asc";
            DataSet ds = SqlHelper.ExecuteDataSet(sqlStr);
            DataTable dt = ds.Tables[0];

            TreeNode treeNode ;
            Dictionary<int, TreeNode> treeNodeDict = new Dictionary<int, TreeNode>(); 

            if (dt != null && dt.Rows.Count > 0)
            {
                string pgm_Id, pgm_Name, is_Lowest;
                int level_Id, parent_Level_Id,itm;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    level_Id = Int32.Parse(dt.Rows[i]["Level_Id"].ToString());
                    if (level_Id == 0)
                    {
                        Text = dt.Rows[i]["NAME"].ToString();
                        continue;
                    }
                    level_Id = level_Id - 1;
                    parent_Level_Id = level_Id - 1;
                    pgm_Id = dt.Rows[i]["PGM_Id"].ToString();
                    pgm_Name = dt.Rows[i]["NAME"].ToString();
                    is_Lowest = dt.Rows[i]["IS_LOWEST"].ToString();
                    itm = Int32.Parse(dt.Rows[i]["Itm"].ToString());
                    treeNode = new TreeNode();
                    treeNode.Name = pgm_Id;
                    treeNode.Text = pgm_Name;
                    treeNode.Tag = itm;
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

        public void ChackTree(TreeNode trennode, bool Chacked)
        {
            M_select = false;
            if (trennode.Nodes.Count > 0)
            {
                foreach (TreeNode node in trennode.Nodes)
                {
                    node.Checked = Chacked;
                    ChackTree(node, Chacked);
                }
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (M_select)
            {
                if (e.Node.Checked)
                {
                    ChackTree(e.Node, true);
                    if (e.Node.Parent != null)
                    {
                        e.Node.Parent.Checked = true;
                    }
                }
                else
                {
                    ChackTree(e.Node, false);
                }
                M_select = true;
            }
        }

        private  bool AddRole()
        {
            string _sqlStr = "Insert Into Role(Company_Id,Role_Id,Desc_01,Parent_Company_Id,Parent_Role_Id,Level_Id,Sort_Number,Est_Itm,Is_Lowest,Status_Id,Status_Id_BC,"
                           + "Remark,Company__Id,Role__Id,Usr__Id,Create__Time,Global_Id)"
                           + "  VALUES(@Company_Id,@Role_Id,@Desc_01,@Parent_Company_Id,@Parent_Role_Id,@Level_Id,@Sort_Number,@Est_Itm,@Is_Lowest,@Status_Id,@Status_Id_BC,"
                           + "@Remark,@Company__Id,@Role__Id,@Usr__Id,@Create__Time,@Global_Id);";
            string _sqlStr1 = "";
            GetInsertSql();
            _sqlStr1 += _treeString;  
          
            
            SqlParameter[] paras = new SqlParameter[17];
            paras[0] = new SqlParameter("@Company_Id", SqlDbType.VarChar, 50);
            paras[0].Value = this.textBoxContainButton1.Text.Trim();

            paras[1] = new SqlParameter("@Role_Id", SqlDbType.VarChar, 50);
            paras[1].Value = this.txtRoleID.Text.Trim();

            paras[2] = new SqlParameter("@Desc_01", SqlDbType.VarChar, 100);
            paras[2].Value = this.txtRoleName.Text.Trim();

            paras[3] = new SqlParameter("@Parent_Company_Id", SqlDbType.VarChar, 50);
            paras[3].Value = ((LoginInfo._ZT_Admin_Id == "Z") ? "" : LoginInfo._Usr_Company);

            paras[4] = new SqlParameter("@Parent_Role_Id", SqlDbType.VarChar, 50);
            paras[4].Value = this.txtRoleID.Text.Trim();

            paras[5] = new SqlParameter("@Level_Id", SqlDbType.Int);
            paras[5].Value = 0;

            paras[6] = new SqlParameter("@Sort_Number", SqlDbType.Decimal);
            paras[6].Value = 0;

            paras[7] = new SqlParameter("@Est_Itm", SqlDbType.Int);
            paras[7].Value = 0;

            paras[8] = new SqlParameter("@Is_Lowest", SqlDbType.VarChar,1);
            paras[8].Value = 0;

            paras[9] = new SqlParameter("@Status_Id", SqlDbType.VarChar,5);
            paras[9].Value = 130;

            paras[10] = new SqlParameter("@Status_Id_BC", SqlDbType.VarChar,5);
            paras[10].Value = "";

            paras[11] = new SqlParameter("@Remark", SqlDbType.Text);
            paras[11].Value = "";

            paras[12] = new SqlParameter("@Company__Id", SqlDbType.VarChar,50);
            paras[12].Value = ((LoginInfo._ZT_Admin_Id == "Z") ? "" : LoginInfo._Usr_Company);

            paras[13] = new SqlParameter("@Role__Id", SqlDbType.VarChar, 50);
            paras[13].Value = ((LoginInfo._ZT_Admin_Id == "Z") ? "" : LoginInfo._Usr_Role);

            paras[14] = new SqlParameter("@Usr__Id", SqlDbType.VarChar, 50);
            paras[14].Value = LoginInfo._Usr_id;

            paras[15] = new SqlParameter("@Create__Time", SqlDbType.DateTime);
            paras[15].Value = System.DateTime.Now;

            paras[16] = new SqlParameter("@Global_Id", SqlDbType.VarChar,50);
            paras[16].Value = "";

            if (SqlHelper.ExecuteQueryTrans(_sqlStr1 + _sqlStr, paras))
           {
               return true;
           }
           else
           {
               return false;
           }
        }     

        private bool UpdRole()
        {
            string _sqlStr = "Update Role set Desc_01=@Desc_01,Parent_Company_Id=@Parent_Company_Id,Parent_Role_Id=@Parent_Role_Id,Level_Id=@Level_Id,"
                          + "Sort_Number=@Sort_Number,Est_Itm=@Est_Itm,Is_Lowest=@Is_Lowest,Status_Id=@Status_Id,Status_Id_BC=@Status_Id_BC,"
                          + "Remark=@Remark,Global_Id=@Global_Id,Last_Modify_Company_Id=@Last_Modify_Company_Id,Last_Modify_Role_Id=@Last_Modify_Role_Id,"
                          + "Last_Modify_Usr_Id=@Last_Modify_Usr_Id,Last_Modify_Time=@Last_Modify_Time  "
                          + " Where Company_Id=@Company_Id and Role_Id=@Role_Id ; ";

            string _sqlStr1 = " Delete from RolePgm1 Where Company_Id=@Company_Id and Role_Id=@Role_Id; ";
            GetInsertSql();
            _sqlStr1 += _treeString;


            SqlParameter[] paras = new SqlParameter[21];
            paras[0] = new SqlParameter("@Company_Id", SqlDbType.VarChar, 50);
            paras[0].Value = this.textBoxContainButton1.Text.Trim();

            paras[1] = new SqlParameter("@Role_Id", SqlDbType.VarChar, 50);
            paras[1].Value = this.txtRoleID.Text.Trim();

            paras[2] = new SqlParameter("@Desc_01", SqlDbType.VarChar, 100);
            paras[2].Value = this.txtRoleName.Text.Trim();

            paras[3] = new SqlParameter("@Parent_Company_Id", SqlDbType.VarChar, 50);
            paras[3].Value = ((LoginInfo._ZT_Admin_Id == "Z") ? "" : LoginInfo._Usr_Company);

            paras[4] = new SqlParameter("@Parent_Role_Id", SqlDbType.VarChar, 50);
            paras[4].Value = this.txtRoleID.Text.Trim();

            paras[5] = new SqlParameter("@Level_Id", SqlDbType.Int);
            paras[5].Value = 0;

            paras[6] = new SqlParameter("@Sort_Number", SqlDbType.Decimal);
            paras[6].Value = 0;

            paras[7] = new SqlParameter("@Est_Itm", SqlDbType.Int);
            paras[7].Value = 0;

            paras[8] = new SqlParameter("@Is_Lowest", SqlDbType.VarChar, 1);
            paras[8].Value = 0;

            paras[9] = new SqlParameter("@Status_Id", SqlDbType.VarChar, 5);
            paras[9].Value = 130;

            paras[10] = new SqlParameter("@Status_Id_BC", SqlDbType.VarChar, 5);
            paras[10].Value = "";

            paras[11] = new SqlParameter("@Remark", SqlDbType.Text);
            paras[11].Value = "";

            paras[12] = new SqlParameter("@Last_Modify_Company_Id", SqlDbType.VarChar, 50);
            paras[12].Value = ((LoginInfo._ZT_Admin_Id == "Z") ? "" : LoginInfo._Usr_Company);

            paras[13] = new SqlParameter("@Last_Modify_Role_Id", SqlDbType.VarChar, 50);
            paras[13].Value = ((LoginInfo._ZT_Admin_Id == "Z") ? "" : LoginInfo._Usr_Role);

            paras[14] = new SqlParameter("@Last_Modify_Usr_Id", SqlDbType.VarChar, 50);
            paras[14].Value = LoginInfo._Usr_id;

            paras[15] = new SqlParameter("@Last_Modify_Time", SqlDbType.DateTime);
            paras[15].Value = System.DateTime.Now;

            paras[16] = new SqlParameter("@Global_Id", SqlDbType.VarChar, 50);
            paras[16].Value = "";

            paras[17] = new SqlParameter("@Company__Id", SqlDbType.VarChar, 50);
            paras[17].Value = ((LoginInfo._ZT_Admin_Id == "Z") ? "" : LoginInfo._Usr_Company);

            paras[18] = new SqlParameter("@Role__Id", SqlDbType.VarChar, 50);
            paras[18].Value = ((LoginInfo._ZT_Admin_Id == "Z") ? "" : LoginInfo._Usr_Role);

            paras[19] = new SqlParameter("@Usr__Id", SqlDbType.VarChar, 50);
            paras[19].Value = LoginInfo._Usr_id;

            paras[20] = new SqlParameter("@Create__Time", SqlDbType.DateTime);
            paras[20].Value = System.DateTime.Now;

            if (SqlHelper.ExecuteQueryTrans(_sqlStr1 + _sqlStr, paras))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void GetInsertSql()
        {
            _treeString = "";
            foreach(TreeNode tn in treeView1.Nodes)
            {
                GetTreeViewNode(tn);
            }
        }

        private void GetTreeViewNode(TreeNode Tn)
        {
            if (Tn.Checked)
            {
              string pgm_up="";
                if(Tn.Parent!=null)
                {
                    pgm_up = Tn.Parent.Name;
                }
                _treeString += "Insert Into RolePgm1(Company_Id,Role_Id,Pgm_Id,ShortName_01,Query_Rights_Id,Insert_Rights_Id,Update_Rights_Id,Delete_Rights_Id,Print_Rights_Id,"
                         + "Pgm_Up,Itm,Pgm_Level,Is_Lowest,Company__Id,Role__Id,Usr__Id,Create__Time,Global_Id)"
                         + "SELECT Company_Id=@Company_Id,Role_Id=@Role_Id,Pgm_Id='" + Tn.Name + "',ShortName_01='" + Tn.Text + "', "
                         + "Query_Rights_Id='T',Insert_Rights_Id='T',Update_Rights_Id='T',Delete_Rights_Id='T',Print_Rights_Id='T',"
                         + "Pgm_Up='" + pgm_up + "',Itm='"+Tn.Tag+"',Pgm_Level='" + (Tn.Level+1) + "',"
                         + "Is_Lowest='',Company__Id=@Company__Id,Role__Id=@Role__Id,Usr__Id=@Usr__Id,Create__Time=@Create__Time,Global_Id=@Global_Id;";
            }
            foreach (TreeNode tnSub in Tn.Nodes)
            {
                GetTreeViewNode(tnSub);
            }
        }

    }
}
