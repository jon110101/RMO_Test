using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using RMO.BasisManage;
using RMO.RmoManagement;
using RMO.SysManage;

namespace RMO
{
   
    public partial class SubForm : Form
    {
        public delegate void CloseFromHandle(string Pgm_id);
        public event CloseFromHandle CloseForm;

        public SubForm()
        {
            InitializeComponent();
        }
       
        private void SubForm_Load(object sender, EventArgs e)
        {
           
         
            string Pam_id = Name;
            switch (Pam_id)       
            {
                case "Role":
                    RoleUcForm _RoleForm = new RoleUcForm(this);
                    _RoleForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_RoleForm);
                    break;
                case "Usr":
                    UsrUcForm _UsrForm = new UsrUcForm(this);
                    _UsrForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_UsrForm);
                    break;
                case "Department":
                    DeptForm _deptForm = new DeptForm(this);
                    _deptForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_deptForm);
                    break;
                case "Employee":
                    EmployeeForm _EmployeeForm = new EmployeeForm(this);
                    _EmployeeForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_EmployeeForm);
                    break;
                case "Csv":
                    CsvForm _csvForm = new CsvForm(this);
                    _csvForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_csvForm);
                    break;
                case "Currency":
                    CurrencyForm _currencyForm = new CurrencyForm(this);
                    _currencyForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_currencyForm);
                    break;
                case "SalesType":
                    SalesTypeForm _salesTypeForm = new SalesTypeForm(this);
                    _salesTypeForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_salesTypeForm);
                    break;
                case "BusinessType":
                    BusinessTypeForm _businessTypeForm = new BusinessTypeForm(this);
                    _businessTypeForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_businessTypeForm);
                    break;
                case "ItemUt":
                    ItemUtForm _itemUtForm = new ItemUtForm(this);
                    _itemUtForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_itemUtForm);
                    break;
                case "ItemKind":
                    ItemKindForm _itemKindForm = new ItemKindForm(this);
                    _itemKindForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_itemKindForm);
                    break;
                case "Warehouse":
                    WarehouseForm _warehouseForm = new WarehouseForm(this);
                    _warehouseForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_warehouseForm);
                    break;
                case "ProductArea":
                    ProductAreaForm _productAreaForm = new ProductAreaForm(this);
                    _productAreaForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_productAreaForm);
                    break;
                case "Item":
                    ItemForm _itemForm = new ItemForm(this);
                    _itemForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_itemForm);
                    break;
                case "RequestCollectionOrder":
                    RequestCollectionOrderForm _OrderForm = new RequestCollectionOrderForm(this);
                    _OrderForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_OrderForm);
                    break;
                case "PlanningOrderInfoInput":
                    PlanningOrderInfoInputForm _FrorecastForm = new PlanningOrderInfoInputForm(this);
                    _FrorecastForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_FrorecastForm);
                    break;
                case "TaskNotifyOrder":
                    TaskNotifyOrderForm _TaskNotifyOrderForm = new TaskNotifyOrderForm(this);
                    _TaskNotifyOrderForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_TaskNotifyOrderForm);
                    break;
                case "ShippingInfoConfirmOrder":
                    ShippingInfoConfirmOrderForm _ShippingInfoConfirmOrderForm = new ShippingInfoConfirmOrderForm(this);
                    _ShippingInfoConfirmOrderForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_ShippingInfoConfirmOrderForm);
                    break;
                case "PgmTransferWarningSetting":
                    PgmTransferWarningSettingForm _PgmTransferWarningSettingForm = new PgmTransferWarningSettingForm(this);
                    _PgmTransferWarningSettingForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_PgmTransferWarningSettingForm);
                    break;
                case "Project":
                    ProjectForm _ProjectForm = new ProjectForm(this);
                    _ProjectForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_ProjectForm);
                    break;
                case "ProjectStage":
                    ProjectStageForm _ProjectStageForm = new ProjectStageForm(this);
                    _ProjectStageForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_ProjectStageForm);
                    break;
                case "ShippingAddress":
                    ShippingAddressForm _ShippingAddressForm = new ShippingAddressForm(this);
                    _ShippingAddressForm.Dock = DockStyle.Fill;
                    this.PalView.Controls.Add(_ShippingAddressForm);
                    break;
                default:
                    break;
            }

        } 

       public void CloseThisFrom(string Pgm_id)
        {
            if (CloseForm != null)
            {
                CloseForm(Pgm_id);
            }
        }
    }
}
