
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
    public partial class MainForm : Form
    {
        DataSet ds;
        bool isGeneratingSubForm = false;

        public delegate void CloseHandle(string msg);
        public MainForm()
        {
            InitializeComponent();
            LoadMenuItemAndMenuTree();
            this.toolStrip1.Visible = false;
        }

        private void LoadMenuItemAndMenuTree()
        {
            string sqlStr = "";
            if (LoginInfo._ZT_Admin_Id == "Z")
            {
                sqlStr = "Select PGM_Id, NAME=ShortName_01, Level_Id=Pgm_Level, IS_LOWEST From SysPgm1 Order By Itm Asc;";
            }
            else
            {
                sqlStr = string.Format("Select Pgm_Id, NAME=ShortName_01, Level_Id, IS_LOWEST From  RolePgm1 Where Role_Id='{0}' and Company_Id='{1}'  Order By Itm Asc;", LoginInfo._Usr_Role,LoginInfo._Usr_Company);
            }
            ds = SqlHelper.ExecuteDataSet(sqlStr);
            DataTable dt = ds.Tables[0];

            treeView1.HideSelection = false;
            treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treeView1.Nodes.Clear();
            menuStrip1.Items.Clear();

            TreeNode treeNode;
            Dictionary<int, TreeNode> treeNodeDict = new Dictionary<int, TreeNode>(); 
            
            ToolStripMenuItem menuItem;
            Dictionary<int, ToolStripMenuItem> menuItemDict = new Dictionary<int, ToolStripMenuItem>();

            string pgm_Id, pgm_Name, is_Lowest;
            int level_Id=0, parent_Level_Id=0;

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

                treeNode = new TreeNode();
                treeNode.Name = pgm_Id;
                treeNode.Text = pgm_Name;

                menuItem = new ToolStripMenuItem();
                menuItem.Name = pgm_Id; ;
                menuItem.Text = pgm_Name;
                menuItem.Tag = treeNode;
                if (is_Lowest == "T")
                {
                    menuItem.Click += new System.EventHandler(menuItem_Click);
                }

                if (!treeNodeDict.ContainsKey(parent_Level_Id))
                {
                    treeView1.Nodes.Add(treeNode);
                    menuStrip1.Items.Add(menuItem);
                }
                else
                {
                    treeNodeDict[parent_Level_Id].Nodes.Add(treeNode);
                    menuItemDict[parent_Level_Id].DropDownItems.Add(menuItem);
                }

                if (!treeNodeDict.ContainsKey(level_Id))
                {
                    treeNodeDict.Add(level_Id, treeNode);
                    menuItemDict.Add(level_Id, menuItem);
                }
                else
                {
                    treeNodeDict[level_Id] = treeNode;
                    menuItemDict[level_Id] = menuItem;
                }
            }

            ToolStripMenuItem menuItem1 = new ToolStripMenuItem();
            menuItem1.Name = "logout" ;
            menuItem1.Text = "退出";
            menuItem1.Click += new System.EventHandler(menuItem1_Click);
            menuStrip1.Items.Add(menuItem1);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized; 
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
                generateSubForm(e.Node);
        }

        private void generateSubForm(TreeNode treeNode)
        {
            isGeneratingSubForm = true;
            try
            {
                TabPage tabPage = (TabPage)treeNode.Tag;
                if (tabPage != null)
                {
                    tabControl1.SelectedTab = tabPage;
                    if (!tabControl1.TabPages.Contains(tabPage)){
                        tabControl1.TabPages.Add(tabPage);
                    }
                    
                }
                else
                {
                    tabPage = new TabPage();
                    tabPage.Name = treeNode.Name;
                    tabPage.Text = treeNode.Text;
                    treeNode.Tag = tabPage;

                    //Form fm = (SubForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(GetType().Namespace + "." + "SubForm");
                    SubForm fm = new SubForm();
                    fm.FormBorderStyle = FormBorderStyle.None;
                    fm.TopLevel = false;
                    fm.ControlBox = false;
                    fm.Parent = tabPage;
                    fm.Dock = DockStyle.Fill;
                    fm.Name = treeNode.Name;
                    fm.Text = treeNode.Text;

                    tabPage.Tag = fm;
                    tabControl1.TabPages.Add(tabPage);
                    tabControl1.SelectedTab = tabPage;

                    fm.Tag = treeNode;

                    fm.CloseForm += (a) =>
                    {
                        CloseHandle _handle = new CloseHandle(CloseForm);
                        this.BeginInvoke(_handle, a);
                    }; 
                    fm.Show();
                    fm.Focus();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                isGeneratingSubForm = false;
            }            
        }

        private void CloseForm(string Pgm_id)
        {
            foreach (TabPage _tg in tabControl1.TabPages)
            {
                if (_tg.Name == Pgm_id)
                {
                    tabControl1.TabPages.Remove(_tg);
                }
            }     
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.Controls.Count > 0)
            {
                if (isGeneratingSubForm) return;
                SubForm fm = (SubForm)tabControl1.SelectedTab.Tag;
                treeView1.SelectedNode = (TreeNode)(fm.Tag);
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            LoginForm _login = new LoginForm();
            this.Hide();
            _login.ShowDialog();
            this.Close();
            this.Dispose();
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            TreeNode treeNode = (TreeNode)((ToolStripMenuItem)sender).Tag;
            generateSubForm(treeNode);
            if (treeView1.SelectedNode != treeNode)                
                treeView1.SelectedNode = treeNode;
        }

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                e.Graphics.FillRectangle(Brushes.DodgerBlue, e.Node.Bounds);
                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White,
                    Rectangle.Inflate(e.Bounds, 2, 0));
            }
            else
            {
                e.DrawDefault = true;
            }
        }

       

    }
}
