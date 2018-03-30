
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
    public partial class QueryForm : Form
    {
        public QueryForm(string PgmName,string Where)
        {
            InitializeComponent();
            getTreeData(PgmName, Where);
        }

        private string _ID = "";
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private void getTreeData(string PgmName, string _where)
        {
            StringBuilder _sql =new StringBuilder ();
            StringBuilder _Sqlwhere = new StringBuilder();
            _Sqlwhere.Append( "where 1=1 ");
           if (!string.IsNullOrEmpty(_where))
           {
               _Sqlwhere.Append(_where);
           }
            switch (PgmName)
            {
                case "SysCompany":
                    _sql.Append(string.Format("select ID=Company_Id,NAME=Company_Name,Level_Id,Is_Lowest from SysCompany1 {0} order by itm asc", _Sqlwhere));
                    break;
                case "UsrCompany1":
                     _sql.Append(string.Format("select ID=UsrCompany1.Company_Id,NAME=s.Company_Name,s.Level_Id,s.Is_Lowest from UsrCompany1 "
                    + "left join sysCompany1 s on UsrCompany1.Company_Id=S.Company_Id {0} order by s.itm asc", _Sqlwhere));
                    break;
                case "Role":
                     _sql.Append(string.Format("select ID=Role_Id,NAME=Desc_01,Level_Id,Is_Lowest from Role order by Est_Itm asc", _Sqlwhere));
                    break;
                case "UsrRole":
                     _sql.Append( string.Format("select ID=UsrRole.Role_Id,NAME=Desc_01,Level_Id,Is_Lowest from UsrRole "
                        +" left join Role r on UsrRole.Company_Id=r.Company_Id and UsrRole.Role_Id=r.Role_Id "
                        +" {0} order by Est_Itm asc", _Sqlwhere));
                    break;
                case "Usr1":
                     _sql.Append(string.Format( " select ID=USR_ID,NAME=Name  from Usr1", _Sqlwhere));
                    break;
                case "ItemUt":
                    _sql.Append(string.Format(" Select  ID=ItemUt_Id,NAME=Desc_01,Level_Id,Is_Lowest from   ItemUt"));
                    break;
                case "Department":
                    _sql.Append(string.Format(" Select  ID=Department_Id,NAME=Desc_01,Level_Id,Is_Lowest from   Department"));
                    break;
                case "Employee":
                    _sql.Append(string.Format(" Select  ID=Employee_Id,NAME=Desc_01,Level_Id,Is_Lowest from   Employee"));
                    break;
                case "Csv":
                    _sql.Append(string.Format(" Select  ID=Csv_Id,NAME=Desc_01,Level_Id,Is_Lowest from   Csv"));
                    break;
                case "Currency":
                    _sql.Append(string.Format(" Select  ID=Currency_Id,NAME=Desc_01,Level_Id,Is_Lowest from   Currency"));
                    break;
                case "SalesType":
                    _sql.Append(string.Format(" Select  ID=SalesType_Id,NAME=Desc_01,Level_Id,Is_Lowest from   SalesType"));
                    break;
                case "BusinessType":
                    _sql.Append(string.Format(" Select  ID=BusinessType_Id,NAME=Desc_01,Level_Id,Is_Lowest from   BusinessType"));
                    break;
                case "ItemKind":
                    _sql.Append(string.Format(" Select  ID=ItemKind_Id,NAME=Desc_01,Level_Id,Is_Lowest from   ItemKind"));
                    break;  
                case "Item":
                    _sql.Append(string.Format(" Select  ID=Item_Id,NAME=Desc_01,Level_Id,Is_Lowest from   Item"));
                    break;
                case "ProductArea":
                    _sql.Append(string.Format(" Select  ID=ProductArea_Id,NAME=Desc_01,Level_Id,Is_Lowest from   ProductArea"));
                    break;  
                case "Warehouse":
                    _sql.Append(string.Format(" Select  ID=Warehouse_Id,NAME=Desc_01,Level_Id,Is_Lowest from   Warehouse"));
                    break;
                case "PlanningOrderInfoInput":
                    _sql.Append(string.Format(" Select  ID=Warehouse_Id,NAME=Warehouse_Id  from   PlanningOrderInfoInput"));
                    break;
                case "RequestCollectionOrder":
                    _sql.Append(string.Format(" Select  ID=Collection_Id,NAME=Collection_Id from   RequestCollectionOrder"));
                    break; 
                case "TaskNotifyOrder":
                    _sql.Append(string.Format(" Select  ID=Notify_Id,NAME=Notify_Id from   TaskNotifyOrder "));
                    break;
                case "ShippingInfoConfirmOrder":
                    _sql.Append(string.Format(" Select  ID=Shipping_Id,NAME=Shipping_Id  from   ShippingInfoConfirmOrder "));
                    break;
                case "PgmTransferWarningSetting":
                    _sql.Append(string.Format(" Select  ID=Pgm_Id,NAME=Pgm_Id from   ShippingInfoConfirmOrder "));
                    break;
                case "Project":
                    _sql.Append(string.Format(" Select  ID=Project_Id,NAME=Desc_01    from   Project "));
                    break;
                case "ProjectStage":
                    _sql.Append(string.Format(" Select  ID=ProjectStage_Id,NAME=Desc_01,Level_Id,Is_Lowest   from   ProjectStage "));
                    break;
                case "ReqType":
                    _sql.Append(string.Format(" Select ID=ReqType_Id, NAME=Desc_01 From  ReqType "));
                    break;
                case "PackageMethod":
                    _sql.Append(string.Format(" Select ID=PackageMethod_Id, NAME=Desc_01,Level_Id,Is_Lowest  From  PackageMethod "));
                    break;
                case "ItemSrcKind":
                    _sql.Append(string.Format(" Select ID=ItemSrcKind_Id, NAME=Desc_01,Level_Id,Is_Lowest  From  ItemSrcKind "));
                    break;
                case "ItemUnit":
                    _sql.Append(string.Format(" Select  ID=ItemUnit_Id,NAME=ItemUnit_Id  from   ItemUnit"));
                    break;
                case "ShippingAddress":
                    _sql.Append(string.Format(" Select  ID=ShippingAddress_Id,NAME=Desc_01  from   ShippingAddress "));
                    break;
                    
                default:
                    break;

            }
           


            DataSet ds = SqlHelper.ExecuteDataSet(_sql.ToString());
            DataTable dt = ds.Tables[0];

            TreeNode treeNode;
            Dictionary<int, TreeNode> treeNodeDict = new Dictionary<int, TreeNode>();

            ToolStripMenuItem menuItem;
            Dictionary<int, ToolStripMenuItem> menuItemDict = new Dictionary<int, ToolStripMenuItem>();

            if (dt != null && dt.Rows.Count > 0)
            {
                string Id, Name, is_Lowest;
                int level_Id=1, parent_Level_Id=1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Columns.Contains("Level_Id"))
                    {
                        level_Id = CommomHelper.ToInt(dt.Rows[i]["Level_Id"].ToString());
                    }
                    level_Id = level_Id - 1;
                    parent_Level_Id = level_Id - 1;
                    Id = dt.Rows[i]["ID"].ToString();
                    Name = dt.Rows[i]["NAME"].ToString();
                    if (dt.Columns.Contains("IS_LOWEST"))
                    {
                        is_Lowest = dt.Rows[i]["IS_LOWEST"].ToString();
                    }
                    treeNode = new TreeNode();
                    treeNode.Name = Id;
                    treeNode.Text = Id+"/"+Name;

                    menuItem = new ToolStripMenuItem();
                    menuItem.Name = Id; ;
                    menuItem.Text = Name;
                    menuItem.Tag = treeNode;

                    if (!treeNodeDict.ContainsKey(parent_Level_Id))
                    {
                        treeView1.Nodes.Add(treeNode);
                        treeView1.NodeMouseDoubleClick+=treeView1_NodeMouseDoubleClick;
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

        private void treeView1_NodeMouseDoubleClick(object sender, EventArgs e)
        {
            TreeView tree = (TreeView)sender;
            TreeNode selectNode = tree.SelectedNode;
            ID = selectNode.Name;
            this.DialogResult = DialogResult.Yes;
        }
    }
}
