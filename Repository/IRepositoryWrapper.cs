using System;
using System.Collections.Generic;
using System.Text;


namespace Ethereal_EM.Repository
{
    public interface IRepositoryWrapper
    {
        IAdminRepository Admin { get; }
        IAdminLevelRepository AdminLevel { get; }
        IEventLogRepository EventLog { get; }
        ISettingRepository Setting { get; }
        IEmailTemplateRepository EmailTemplate { get; }
        IAdminMenuUrlRepository AdminMenuUrl { get; }
        IAdminlevelmenuRepository Adminlevelmenu { get; }
        ICarRepo Car{get;}
        IAdminMenuRepository AdminMenu { get; }
        IAdmin_Admin_Repo AdminAdmin { get; }
        IAdmin_Permission_Repo AdminPermission { get; }
        IAdmin_Relationship_Repo AdminRelationship { get; }
        IGeneralRepository General { get; }
        IUserRepository User { get; }
        ICompanyRepository Company { get; }
        IDepartmentrepo Department {get;}
        IAccountRepo Account {get;}
        IProductRepository Product { get; }
        ICustomerRepository Customer { get; }
        IStorageChargesRepository StorageCharges { get; }
        Iposition_repo Position {get;}
        ITankRepository Tank { get; }
        IBowserRepository Bowser { get; }
        ICompartmentRepository Compartment { get; }
        IDriverRepository Driver { get; }
        ISupplierorderRepository Supplierorder { get; }
        ISupplierOrderDetailRepository SupplierOrderDetail { get; }
        ILaneRepository Lane { get; }
        IHoseRepository Hose { get; }
        ITesting_Database Testing_Database { get; }
        ICustomerOrderRepository CustomerOrder { get; }
        ICustomerOrderDetailRepository CustomerOrderDetail { get; }
        IFuelFillingStaffRepository FuelFillingStaff { get; }
        ITankImportRepository TankImport { get; }
        ICustomerAssignRepository CustomerAssign { get; }
        ICustomerAssignDetailRepository CustomerAssignDetail { get; }
        IMovementTransactionRepository MovementTransaction { get; }
        IDemandOrderRepository DemandOrder { get; }
        IDemandOrderDetailRepository DemandOrderDetail { get; }
        ISaleInvoiceRepository SaleInvoice{get;}

        ICashReceiptRepository CashReceipt {get;}
        IFileSavingRepo FileSavingRepo{get;}
        Ihw_tb1_userRepo hw_tb1_userRepo{get;}
        Ihw_tb1_accountRepo hw_tb1_accountRepo{get;}
        Ihw_tb1_registerRepo hw_tb1_registerRepo{get;}
        IAdmin_Repository Admin_Repository{get;}
        //////Template Place Holder/////
    }
}
