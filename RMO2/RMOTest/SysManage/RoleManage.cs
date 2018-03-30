
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMO
{
    public partial class RoleManage : Form
    {
        public Dictionary<string, UsrManageModel> PgmPowerStateList = new Dictionary<string, UsrManageModel>();
        private bool M_select = true;
        StringBuilder _treeString = new StringBuilder();
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
                    this.txtCtTime.Text = _dtRole.Rows[0]["Create__Date"].ToString();  
                }
            }

            this.textBoxContainButton1.ButtonSelectClick += textBoxContainButton1_Click;
            this.textBoxContainButton3.ButtonSelectClick += textBoxContainButton2_Click;
            this.textBoxContainButton1.TextEnter += textBoxContainButton1_TextEnter;
            this.textBoxContainButton1.TextLeave += textBoxContainButton1_TextLeave;
            this.textBoxContainButton3.TextEnter += textBoxContainButton2_TextEnter;
            this.textBoxContainButton3.TextLeave += textBoxContainButton2_TextLeave;
              
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            //LoadSysPgm();
            //LoadParentRoleList();
            //LoadTreeNodes();

            CreateTreeView();
            ViewDataGrid("BasicData","F"); //初始显示基础数据
        }


        void LoadSysPgm(DataTable _dt)
        {
          //  dataGridView1.Rows.Clear();
          //  dataGridView1.Columns.Clear();
          //  dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
          //  Pgm_Id,
          //  Name_Body,
          //  Query_Rights_Id,
          //  Insert_Rights_Id,
          //  Update_Rights_Id,
          //  Delete_Rights_Id,
          //  Print_Rights_Id,
          //  Export_Rights_Id
          //});
            dataGridView1.Rows.Clear();
            foreach (DataRow row in _dt.Rows)
            {
                UsrManageModel   pgmPowState = null;
                //try
                //{
                //     pgmPowState = PgmPowerStateList[row["Pgm_Id"].ToString()];
                //}
                //catch
                //{
                //     pgmPowState = new UsrManageModel()
                //    {
                //        Pgm_Id = row["Pgm_Id"].ToString(),
                //        Name = row["Name"].ToString(),
                //        Insert_Rights_Id = "F",
                //        Delete_Rights_Id = "F",
                //        Update_Rights_Id = "F",
                //        Print_Rights_Id = "F",
                //        Query_Rights_Id = "F",
                //        Export_Rights_Id = "F",
                //        Itm = CommomHelper.ToInt(row["Itm"])
                //    };
                //}
                if (PgmPowerStateList != null && PgmPowerStateList.Count > 0 && PgmPowerStateList.ContainsKey(row["Pgm_Id"].ToString()))
                {
                    pgmPowState = PgmPowerStateList[row["Pgm_Id"].ToString()];
                }
                else
                {
                     pgmPowState = new UsrManageModel()
                    {
                        Pgm_Id = row["Pgm_Id"].ToString(),
                        Name = row["Name"].ToString(),
                        Insert_Rights_Id = row["Insert_Rights_Id"].ToString(),
                        Delete_Rights_Id = row["Delete_Rights_Id"].ToString(),
                        Update_Rights_Id = row["Update_Rights_Id"].ToString(),
                        Print_Rights_Id = row["Print_Rights_Id"].ToString(),
                        Query_Rights_Id = row["Query_Rights_Id"].ToString(),
                        Export_Rights_Id = row["Export_Rights_Id"].ToString(),
                        Itm = CommomHelper.ToInt(row["Itm"])
                    };
                }
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dataGridView1, new object[] {
                    row["Pgm_Id"],
                    row["Name"],
                    pgmPowState.Query_Rights_Id,
                    pgmPowState.Insert_Rights_Id,
                    pgmPowState.Update_Rights_Id,
                    pgmPowState.Delete_Rights_Id,
                    pgmPowState.Print_Rights_Id,
                    pgmPowState.Export_Rights_Id,
                    pgmPowState.Itm
                });
                dataGridView1.Rows.Add(r);
            
            }

            _dt.Dispose();
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
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                string _columns = " ID=Company_Id,Desc_01=Company_Name ";
                _ht = CommomHelper.GetQuery1("SysCompany1", _columns, "");
            }
            else
            {
                string _columns = " ID=Company_Id,Desc_01=Company_Id ";
                string _where = "and UsrCompany1.Usr_id='" + LoginInfo._Usr_id + "'";
                _ht = CommomHelper.GetQuery1("UsrCompany1", _columns, _where);
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

        private void textBoxContainButton1_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringEnter("UsrCompany1", "Usr_id", e);
        }
        private void textBoxContainButton1_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            _txt.ToFormatStringLeave("UsrCompany1", "Usr_id", e);
        }


        private void textBoxContainButton2_Click(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                string _columns = " ID=Role_ID,Desc_01=Desc_01 ";
                _ht = CommomHelper.GetQuery1("Role", _columns, "");
            }
            else
            {
                string _columns = " ID=Role_ID,Desc_01=Role_ID ";
                string _where = "and UsrRole.Usr_id='" + LoginInfo._Usr_id + "'";
                _ht = CommomHelper.GetQuery1("UsrRole", _columns, _where);
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

        private void textBoxContainButton2_TextEnter(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _txt.ToFormatStringEnter("Role", "Role_ID", e);
            }
            else
            {
                _txt.ToFormatStringEnter("UsrRole", "Role_ID", e);
            }
        }
        private void textBoxContainButton2_TextLeave(object sender, EventArgs e)
        {
            TextBoxContainButton _txt = (TextBoxContainButton)sender;
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                _txt.ToFormatStringLeave("Role", "Role_ID", e);
            }
            else
            {
                _txt.ToFormatStringLeave("UsrRole", "Role_ID", e);
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
            StringBuilder sqlStr = new StringBuilder();
            if(LoginInfo._ZT_Admin_Id!="Z")
            {
                sqlStr.Append("select  PGM_Id, NAME=ShortName_01, Level_Id, IS_LOWEST,Itm  from RolePgm1 where Company_Id='" + LoginInfo._Usr_Company + "' AND  Role_Id='" + LoginInfo._Usr_Role + "'"
                       + " Order By Itm Asc");
            }
            else
            {
                 sqlStr.Append("select  PGM_Id, NAME=ShortName_01, Level_Id=Pgm_Level, IS_LOWEST,Itm  from SysPgm1 Order By Itm Asc");
            }
            DataSet ds = SqlHelper.ExecuteDataSet(sqlStr.ToString());
            DataTable dt = ds.Tables[0];

            TreeNode treeNode ;
            Dictionary<int, TreeNode> treeNodeDict = new Dictionary<int, TreeNode>(); 

            if (dt != null && dt.Rows.Count > 0)
            {
                string pgm_Id, pgm_Name, is_Lowest;
                int level_Id, parent_Level_Id=0,itm;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    level_Id = Int32.Parse(dt.Rows[i]["Level_Id"].ToString());
                    //if (level_Id == 0)
                    //{
                    //    Text = dt.Rows[i]["NAME"].ToString();
                    //    continue;
                    //}
                    //level_Id = level_Id - 1;
                    if (level_Id > 0)
                    {
                        parent_Level_Id = level_Id - 1;
                    }
                    pgm_Id = dt.Rows[i]["PGM_Id"].ToString();
                    pgm_Name = dt.Rows[i]["NAME"].ToString();
                    is_Lowest = dt.Rows[i]["IS_LOWEST"].ToString();
                    itm = Int32.Parse(dt.Rows[i]["Itm"].ToString());
                    treeNode = new TreeNode();
                    treeNode.Name = pgm_Id;
                    treeNode.Text = pgm_Name;
                    treeNode.Tag = is_Lowest;
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
            StringBuilder _sqlStr = new StringBuilder();
            _sqlStr.Append("Insert Into Role(Company_Id,Role_Id,Desc_01,Parent_Company_Id,Parent_Role_Id,Level_Id,Sort_Number,Est_Itm,Is_Lowest,Status_Id,Status_Id_BC,"
                          + "Remark,Company__Id,Role__Id,Usr__Id,Create__Date)"
                          + "  VALUES(@Company_Id,@Role_Id,@Desc_01,@Parent_Company_Id,@Parent_Role_Id,@Level_Id,@Sort_Number,@Est_Itm,@Is_Lowest,@Status_Id,@Status_Id_BC,"
                          + "@Remark,@Company__Id,@Role__Id,@Usr__Id,@Create__Date);");
            string _sqlStr1 = "";
            GetInsertSql();
            if (_treeString != null)
            {
                _sqlStr1 += _treeString.ToString();
            }
          
            
            SqlParameter[] paras = new SqlParameter[16];
            paras[0] = new SqlParameter("@Company_Id", SqlDbType.VarChar, 50);
            paras[0].Value = string.IsNullOrEmpty(this.textBoxContainButton1.ID) ? "" : this.textBoxContainButton1.ID;

            paras[1] = new SqlParameter("@Role_Id", SqlDbType.VarChar, 50);
            paras[1].Value = this.txtRoleID.Text.Trim();

            paras[2] = new SqlParameter("@Desc_01", SqlDbType.VarChar, 100);
            paras[2].Value = this.txtRoleName.Text.Trim();

            paras[3] = new SqlParameter("@Parent_Company_Id", SqlDbType.VarChar, 50);
            paras[3].Value = ((LoginInfo._ZT_Admin_Id == "Z") ? "" : LoginInfo._Usr_Company);

            paras[4] = new SqlParameter("@Parent_Role_Id", SqlDbType.VarChar, 50);
            paras[4].Value = string.IsNullOrEmpty(this.textBoxContainButton3.ID) ? "" : this.textBoxContainButton3.ID;

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

            paras[15] = new SqlParameter("@Create__Date", SqlDbType.DateTime);
            paras[15].Value = System.DateTime.Now;


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
            StringBuilder _sqlStr = new StringBuilder();
            _sqlStr.Append( "Update Role set Desc_01=@Desc_01,Parent_Company_Id=@Parent_Company_Id,Parent_Role_Id=@Parent_Role_Id,Level_Id=@Level_Id,"
                          + "Sort_Number=@Sort_Number,Est_Itm=@Est_Itm,Is_Lowest=@Is_Lowest,Status_Id=@Status_Id,Status_Id_BC=@Status_Id_BC,"
                          + "Remark=@Remark,Last_Modify_Company_Id=@Last_Modify_Company_Id,Last_Modify_Role_Id=@Last_Modify_Role_Id,"
                          + "Last_Modify_Usr_Id=@Last_Modify_Usr_Id,Last_Modify_Date=@Last_Modify_Date  "
                          + " Where Company_Id=@Company_Id and Role_Id=@Role_Id ; ");

            string _sqlStr1 = " Delete from RolePgm1 Where Company_Id=@Company_Id and Role_Id=@Role_Id; ";
            GetInsertSql();
            if (_treeString != null)
            {
                _sqlStr1 += _treeString.ToString();
            }


            SqlParameter[] paras = new SqlParameter[20];
            paras[0] = new SqlParameter("@Company_Id", SqlDbType.VarChar, 50);
            paras[0].Value = string.IsNullOrEmpty(this.textBoxContainButton1.ID) ? "" : this.textBoxContainButton1.ID;

            paras[1] = new SqlParameter("@Role_Id", SqlDbType.VarChar, 50);
            paras[1].Value = this.txtRoleID.Text.Trim();

            paras[2] = new SqlParameter("@Desc_01", SqlDbType.VarChar, 100);
            paras[2].Value = this.txtRoleName.Text.Trim();

            paras[3] = new SqlParameter("@Parent_Company_Id", SqlDbType.VarChar, 50);
            paras[3].Value = ((LoginInfo._ZT_Admin_Id == "Z") ? "" : LoginInfo._Usr_Company);

            paras[4] = new SqlParameter("@Parent_Role_Id", SqlDbType.VarChar, 50);
            paras[4].Value = string.IsNullOrEmpty(this.textBoxContainButton3.ID) ? "" : this.textBoxContainButton3.ID;

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

            paras[15] = new SqlParameter("@Last_Modify_Date", SqlDbType.DateTime);
            paras[15].Value = System.DateTime.Now;

            //paras[16] = new SqlParameter("@Global_Id", SqlDbType.VarChar, 50);
            //paras[16].Value = "";

            paras[16] = new SqlParameter("@Company__Id", SqlDbType.VarChar, 50);
            paras[16].Value = ((LoginInfo._ZT_Admin_Id == "Z") ? "" : LoginInfo._Usr_Company);

            paras[17] = new SqlParameter("@Role__Id", SqlDbType.VarChar, 50);
            paras[17].Value = ((LoginInfo._ZT_Admin_Id == "Z") ? "" : LoginInfo._Usr_Role);

            paras[18] = new SqlParameter("@Usr__Id", SqlDbType.VarChar, 50);
            paras[18].Value = LoginInfo._Usr_id;

            paras[19] = new SqlParameter("@Create__Date", SqlDbType.DateTime);
            paras[19].Value = System.DateTime.Now;

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
            _treeString =new StringBuilder();
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
                string _is_lowest =Convert.ToString(Tn.Tag);
                BindingSource _bdSource = new BindingSource();
                _bdSource = dataGridView1.DataSource as BindingSource;

                UsrManageModel _usrMge = null;
                if(PgmPowerStateList.ContainsKey(Tn.Name))
                {
                  _usrMge = PgmPowerStateList[Tn.Name];
                }
                if(_usrMge!=null)
                {
                    _treeString.Append("Insert Into RolePgm1(Company_Id,Role_Id,Pgm_Id,ShortName_01,Query_Rights_Id,Insert_Rights_Id,Update_Rights_Id,Delete_Rights_Id,Print_Rights_Id,"
                      + "Pgm_Up,Itm,Level_Id,Is_Lowest)"
                      + "SELECT Company_Id=@Company_Id,Role_Id=@Role_Id,Pgm_Id='" + Tn.Name + "',ShortName_01='" + Tn.Text + "', "
                      + "Query_Rights_Id='" + _usrMge.Query_Rights_Id + "',Insert_Rights_Id='" + _usrMge.Insert_Rights_Id + "', "
                      + "Update_Rights_Id='" + _usrMge.Update_Rights_Id + "',Delete_Rights_Id='" + _usrMge.Delete_Rights_Id + "',Print_Rights_Id='" + _usrMge.Print_Rights_Id + "',"
                      + "Pgm_Up='" + pgm_up + "',Itm='" + _usrMge.Itm + "',Level_Id='" + (Tn.Level + 1) + "',"
                      + "Is_Lowest='" + _is_lowest + "';");   
                }

                //DataRow[] _dr = _dtRole.Select("Pgm_Id='" + Tn.Name + "'");
                //if (_dr != null && _dr.Length > 0)
                //{
                //    _treeString.Append("Insert Into RolePgm1(Company_Id,Role_Id,Pgm_Id,ShortName_01,Query_Rights_Id,Insert_Rights_Id,Update_Rights_Id,Delete_Rights_Id,Print_Rights_Id,"
                //       + "Pgm_Up,Itm,Level_Id,Is_Lowest)"
                //       + "SELECT Company_Id=@Company_Id,Role_Id=@Role_Id,Pgm_Id='" + Tn.Name + "',ShortName_01='" + Tn.Text + "', "
                //       + "Query_Rights_Id='" + _dr[0]["Query_Rights_Id"].ToString() + "',Insert_Rights_Id='" + _dr[0]["Insert_Rights_Id"].ToString() + "', "
                //       + "Update_Rights_Id='" + _dr[0]["Update_Rights_Id"].ToString() + "',Delete_Rights_Id='" + _dr[0]["Delete_Rights_Id"].ToString() + "',Print_Rights_Id='" + _dr[0]["Print_Rights_Id"].ToString() + "',"
                //       + "Pgm_Up='" + pgm_up + "',Itm='" + _dr[0]["Itm"].ToString() + "',Level_Id='" + (Tn.Level + 1) + "',"
                //       + "Is_Lowest='" + _is_lowest + "';");   
                //}                         
            }
            foreach (TreeNode tnSub in Tn.Nodes)
            {
                GetTreeViewNode(tnSub);
            }
        }


        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string _pgm_id = e.Node.Name;
            string _Is_Lowest = Convert.ToString(e.Node.Tag);
            ViewDataGrid(_pgm_id, _Is_Lowest);
        }

        private void ViewDataGrid(string Pgm_id, string Is_Lowest)
        {
            StringBuilder sqlStr = new StringBuilder();
            if (Edit == "ADD")
            {
                if (LoginInfo._ZT_Admin_Id == "Z")
                {
                    sqlStr.Append(" Select ");
                    sqlStr.Append("     Pgm_Id=SysPgm1.Pgm_Id,");
                    sqlStr.Append("    Name=SysPgm1.ShortName_01,");
                    sqlStr.Append("    Query_Rights_Id=IsNull(RolePgm1.Query_Rights_Id, 'F'),");
                    sqlStr.Append("  Export_Rights_Id=IsNull(RolePgm1.Export_Rights_Id, 'F'),");
                    sqlStr.Append("  Insert_Rights_Id=IsNull(RolePgm1.Insert_Rights_Id, 'F'),");
                    sqlStr.Append("    Update_Rights_Id=IsNull(RolePgm1.Update_Rights_Id, 'F'),");
                    sqlStr.Append("    Delete_Rights_Id=IsNull(RolePgm1.Delete_Rights_Id, 'F'),");
                    sqlStr.Append("    Print_Rights_Id=IsNull(RolePgm1.Print_Rights_Id, 'F'),");
                    sqlStr.Append("  SysPgm1.Itm From  SysPgm1");
                    sqlStr.Append(" Left Join RolePgm1 On RolePgm1.Company_Id='' And RolePgm1.Role_Id='' And RolePgm1.Pgm_Id=SysPgm1.Pgm_Id");
                    sqlStr.Append(" Where  1=1 AND  SysPgm1.Pgm_Id    IN (select Pgm_Id from   dbo.fn_GetSubSysPgm1('" + Pgm_id + "','" + Is_Lowest + "') )");
                    sqlStr.Append(" Order  By SysPgm1.Itm");
                }
                else
                {
                    sqlStr.Append("select Company_Id,Role_Id,Pgm_Id,Name=ShortName_01,'F' as Query_Rights_Id,'F' as Insert_Rights_Id,'F' as Update_Rights_Id,'F' as Delete_Rights_Id,'F' as Print_Rights_Id,Pgm_Up,Itm  from RolePgm1 ");
                    sqlStr.Append("where  Pgm_Id IN (select Pgm_Id from   dbo.fn_GetSubSysPgm1('" + Pgm_id + "','" + Is_Lowest + "') ) ");
                    sqlStr.Append("  AND Role_Id='" + LoginInfo._Usr_Role + "' ");
                    if (LoginInfo._ZT_Admin_Id != "Z")
                    {
                        sqlStr.Append("  and Company_Id='" + LoginInfo._Usr_Company + "'");
                    }
                    sqlStr.Append("  Order By Itm Asc");
                }
            }
            else if (Edit == "UPD")
            {
                string isZt = "1<>1";
                string company_id = string.IsNullOrEmpty(this.textBoxContainButton1._AddID)?"":this.textBoxContainButton1._AddID;
                string roleid = this.txtRoleID.Text;
                if( LoginInfo._ZT_Admin_Id == "Z")
                {
                    isZt = "1=1";
                }
                sqlStr.Append("  If (" + isZt + ")");
                sqlStr.Append("  Begin");
                sqlStr.Append(" Select ");
                sqlStr.Append("     Pgm_Id=SysPgm1.Pgm_Id,");
                sqlStr.Append("    Name=SysPgm1.ShortName_01,");
                sqlStr.Append("    Query_Rights_Id=IsNull(RolePgm1.Query_Rights_Id, 'F'),");
                sqlStr.Append("  Export_Rights_Id=IsNull(RolePgm1.Export_Rights_Id, 'F'),");
                sqlStr.Append("  Insert_Rights_Id=IsNull(RolePgm1.Insert_Rights_Id, 'F'),");
                sqlStr.Append("    Update_Rights_Id=IsNull(RolePgm1.Update_Rights_Id, 'F'),");
                sqlStr.Append("    Delete_Rights_Id=IsNull(RolePgm1.Delete_Rights_Id, 'F'),");
                sqlStr.Append("    Print_Rights_Id=IsNull(RolePgm1.Print_Rights_Id, 'F'),");
                sqlStr.Append(" SysPgm1.Itm  From  SysPgm1");
                sqlStr.Append(" Left Join RolePgm1 On RolePgm1.Company_Id='" + company_id + "' And RolePgm1.Role_Id='" + roleid + "' And RolePgm1.Pgm_Id=SysPgm1.Pgm_Id");
                sqlStr.Append(" Where  1=1 AND  SysPgm1.Pgm_Id    IN (select Pgm_Id from   dbo.fn_GetSubSysPgm1('" + Pgm_id + "','" + Is_Lowest + "') )");
                sqlStr.Append(" Order  By SysPgm1.Itm");
                sqlStr.Append(" End");
                sqlStr.Append(" Else");
                sqlStr.Append(" Begin");
                sqlStr.Append(" Select ");
                sqlStr.Append("       Pgm_Id=CurRolePgm.Pgm_Id,");
                sqlStr.Append("       Name=CurRolePgm.ShortName_01,");
                sqlStr.Append("      Query_Rights_Id=IsNull(DestRolePgm.Query_Rights_Id, 'F'),");
                sqlStr.Append("     Export_Rights_Id=IsNull(DestRolePgm.Export_Rights_Id, 'F'),");
                sqlStr.Append("     Insert_Rights_Id=IsNull(DestRolePgm.Insert_Rights_Id, 'F'),");
                sqlStr.Append("      Update_Rights_Id=IsNull(DestRolePgm.Update_Rights_Id, 'F'),");
                sqlStr.Append("      Delete_Rights_Id=IsNull(DestRolePgm.Delete_Rights_Id, 'F'),");
                sqlStr.Append("      Print_Rights_Id=IsNull(DestRolePgm.Print_Rights_Id, 'F'),");
                sqlStr.Append("CurRolePgm.Itm  From  RolePgm1 CurRolePgm");
                sqlStr.Append(" Left  Join RolePgm1 DestRolePgm On DestRolePgm.Company_Id='" + company_id + "' And DestRolePgm.Role_Id='" + roleid + "' And DestRolePgm.Pgm_Id=CurRolePgm.Pgm_Id");
                sqlStr.Append("  Where  CurRolePgm.Company_Id='"+LoginInfo._Usr_Company+"' And CurRolePgm.Role_Id='"+LoginInfo._Usr_Role+"' ");
                sqlStr.Append(" AND  CurRolePgm.Pgm_Id    IN (select Pgm_Id from   dbo.fn_GetSubSysPgm1('" + Pgm_id + "','" + Is_Lowest + "') )");
                sqlStr.Append(" Order  By CurRolePgm.Itm");
                sqlStr.Append(" End");
            }
            //fn_SysPgmTree  pgm树结构函数

            DataSet ds = SqlHelper.ExecuteDataSet(sqlStr.ToString());
            DataTable dt = ds.Tables[0];
            this.dataGridView1.AllowUserToAddRows = false;
            //BindingSource bindingSource1 = new BindingSource();
            //bindingSource1.DataSource = dt;
            //this.dataGridView1.DataSource = bindingSource1;

            LoadSysPgm(dt);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                UsrManageModel pmgPowState =new  UsrManageModel();
                pmgPowState.Pgm_Id = (string)dataGridView1.Rows[e.RowIndex].Cells["Pgm_Id"].Value;
                pmgPowState.Name = (string)dataGridView1.Rows[e.RowIndex].Cells["Name_Body"].Value;
                pmgPowState.Query_Rights_Id = dataGridView1.Rows[e.RowIndex].Cells["Query_Rights_Id"].Value.ToString();
                pmgPowState.Insert_Rights_Id = dataGridView1.Rows[e.RowIndex].Cells["Insert_Rights_Id"].Value.ToString();
                pmgPowState.Update_Rights_Id = dataGridView1.Rows[e.RowIndex].Cells["Update_Rights_Id"].Value.ToString();
                pmgPowState.Print_Rights_Id = dataGridView1.Rows[e.RowIndex].Cells["Print_Rights_Id"].Value.ToString();
                pmgPowState.Export_Rights_Id = dataGridView1.Rows[e.RowIndex].Cells["Export_Rights_Id"].Value.ToString();
                pmgPowState.Delete_Rights_Id =dataGridView1.Rows[e.RowIndex].Cells["Delete_Rights_Id"].Value.ToString();
                pmgPowState.Itm =CommomHelper.ToInt(dataGridView1.Rows[e.RowIndex].Cells["Itm"].Value);
                if (PgmPowerStateList.ContainsKey(pmgPowState.Pgm_Id))
                {
                    PgmPowerStateList[pmgPowState.Pgm_Id] = pmgPowState;
                }
                else
                {
                    PgmPowerStateList.Add(pmgPowState.Pgm_Id, pmgPowState);
                }
            }
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox _chk = sender as CheckBox;
            string columnName = Convert.ToString(_chk.Tag);
            if (_chk.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[columnName].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[columnName].Value = false;
                }
            }
            dataGridView1.EndEdit();
        }

    }
}
