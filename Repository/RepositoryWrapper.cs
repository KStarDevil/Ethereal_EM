using Ethereal_EM;
using Ethereal_EM.Repository;


namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper

    {
        public RepositoryWrapper(AppDb repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        private AppDb _repoContext;
        private IAdminRepository _Admin;
        private IAdminLevelRepository _AdminLevel;
        private ISettingRepository _Setting;
        private IEventLogRepository _EventLog;
        private IAccountRepo _Account;
        private IEmailTemplateRepository _EmailTemplate;
        private IAdminMenuUrlRepository _AdminMenuUrl;
        private IAdminlevelmenuRepository _Adminlevelmenu;
        private IAdminMenuRepository _AdminMenu;
        private IGeneralRepository _General;
        private ICompanyRepository _Company;
        private IDepartmentrepo _Department;
        private Iposition_repo _Position;

        private IProductRepository _Product;

        private ICustomerRepository _Customer;
        private IStorageChargesRepository _StorageCharges;

        private ITankImportRepository _TankImport;

        private ITankRepository _Tank;
        private IBowserRepository _Bowser;
        private ICompartmentRepository _Compartment;
        private IDriverRepository _Driver;
        private ISupplierorderRepository _Supplierorder;
        private ISupplierOrderDetailRepository _SupplierOrderDetail;

        private ILaneRepository _Lane;
        private IHoseRepository _Hose;
        private ITesting_Database _Testing_Database;
        private ICustomerOrderRepository _CustomerOrder;
        private ICustomerOrderDetailRepository _CustomerOrderDetail;
        private IFuelFillingStaffRepository _FuelFillingStaff;
        private ICustomerAssignRepository _CustomerAssign;
        private IUserRepository _User;
        private ICustomerAssignDetailRepository _CustomerAssignDetail;
        private IMovementTransactionRepository _MovementTransaction;
        private IDemandOrderRepository _DemandOrder;
        private IDemandOrderDetailRepository _DemandOrderDetail;
        private ISaleInvoiceRepository _SaleInvoice;
        private ICashReceiptRepository _CashReceipt;
        private IAdmin_Permission_Repo _AdminPermission;
        private IAdmin_Admin_Repo _AdminAdmin;
        private IAdmin_Relationship_Repo _AdminRelationship;
        private ICarRepo _CarRepo;

        private IFileSavingRepo _FileSavingRepo;

        private Ihw_tb1_userRepo _hw_tb1_userRepo;
        private Ihw_tb1_accountRepo _hw_tb1_accountRepo;
        private Ihw_tb1_registerRepo _hw_tb1_registerRepo;
        private IAdmin_Repository _Admin_Repository;
        private IPermission_Repository _Permission_Repository;
        private IRole_Repository _Role_Repository;
        private IMenu_Repository _Menu_Repository;
        private IPermission_Admin_Repository _Permission_Admin_Repository;
        private IRole_Admin_Repository _Role_Admin_Repository;
        private IMenu_Permission_Repository _Menu_Permission_Repository;
        private INotification_Repository _Notification_Repository;
        private IPost_Repository _Post_Repository;
        private IPost_Detail_Repository _Post_Detail_Repository;
        private ICategory_Repository _Category_Repository;
        private IPost_Category_Repository _Post_Category_Repository;

        public IPost_Category_Repository Post_Category_Repository
        {
            get
            {
                if (_Post_Category_Repository == null)
                {
                    _Post_Category_Repository = new Post_Category_Repository(_repoContext);
                }

                return _Post_Category_Repository;
            }
        }
        public ICategory_Repository Category_Repository
        {
            get
            {
                if (_Category_Repository == null)
                {
                    _Category_Repository = new Category_Repository(_repoContext);
                }

                return _Category_Repository;
            }
        }
        public IPost_Detail_Repository Post_Detail_Repository
        {
            get
            {
                if (_Post_Detail_Repository == null)
                {
                    _Post_Detail_Repository = new Post_Detail_Repository(_repoContext);
                }

                return _Post_Detail_Repository;
            }
        }
        public IPost_Repository Post_Repository
        {
            get
            {
                if (_Post_Repository == null)
                {
                    _Post_Repository = new Post_Repository(_repoContext);
                }

                return _Post_Repository;
            }
        }
        public INotification_Repository Notification_Repository
        {
            get
            {
                if (_Notification_Repository == null)
                {
                    _Notification_Repository = new Notification_Repository(_repoContext);
                }

                return _Notification_Repository;
            }
        }
         public IMenu_Permission_Repository Menu_Permission_Repository
        {
            get
            {
                if (_Menu_Permission_Repository == null)
                {
                    _Menu_Permission_Repository = new Menu_Permission_Repository(_repoContext);
                }

                return _Menu_Permission_Repository;
            }
        }
         public IRole_Admin_Repository Role_Admin_Repository
        {
            get
            {
                if (_Role_Admin_Repository == null)
                {
                    _Role_Admin_Repository = new Role_Admin_Repository(_repoContext);
                }

                return _Role_Admin_Repository;
            }
        }

         public IPermission_Admin_Repository Permission_Admin_Repository
        {
            get
            {
                if (_Permission_Admin_Repository == null)
                {
                    _Permission_Admin_Repository = new Permission_Admin_Repository(_repoContext);
                }

                return _Permission_Admin_Repository;
            }
        }
         public IMenu_Repository Menu_Repository
        {
            get
            {
                if (_Menu_Repository == null)
                {
                    _Menu_Repository = new Menu_Repository(_repoContext);
                }

                return _Menu_Repository;
            }
        }
           
         public IRole_Repository Role_Repository
        {
            get
            {
                if (_Role_Repository == null)
                {
                    _Role_Repository = new Role_Repository(_repoContext);
                }

                return _Role_Repository;
            }
        }
         public IPermission_Repository Permission_Repository
        {
            get
            {
                if (_Permission_Repository == null)
                {
                    _Permission_Repository = new Permission_Repository(_repoContext);
                }

                return _Permission_Repository;
            }
        }
         public IAdmin_Repository Admin_Repository
        {
            get
            {
                if (_Admin_Repository == null)
                {
                    _Admin_Repository = new Admin_Repository(_repoContext);
                }

                return _Admin_Repository;
            }
        }
        
         public Ihw_tb1_userRepo hw_tb1_userRepo
        {
            get
            {
                if (_hw_tb1_userRepo == null)
                {
                    _hw_tb1_userRepo = new hw_tb1_userRepo(_repoContext);
                }

                return _hw_tb1_userRepo;
            }
        }

         public Ihw_tb1_accountRepo hw_tb1_accountRepo
        {
            get
            {
                if (_hw_tb1_accountRepo == null)
                {
                    _hw_tb1_accountRepo = new hw_tb1_accountRepo(_repoContext);
                }

                return _hw_tb1_accountRepo;
            }
        }

         public Ihw_tb1_registerRepo hw_tb1_registerRepo
        {
            get
            {
                if (_hw_tb1_registerRepo == null)
                {
                    _hw_tb1_registerRepo = new hw_tb1_registerRepo(_repoContext);
                }

                return _hw_tb1_registerRepo;
            }
        }
         public ICarRepo Car
        {
            get
            {
                if (_CarRepo == null)
                {
                    _CarRepo = new CarRepo(_repoContext);
                }

                return _CarRepo;
            }
        }

         public IFileSavingRepo FileSavingRepo
        {
            get
            {
                if (_FileSavingRepo == null)
                {
                    _FileSavingRepo = new FileSavingRepo(_repoContext);
                }

                return _FileSavingRepo;
            }
        }

        public IAdminMenuRepository AdminMenu
        {
            get
            {
                if (_AdminMenu == null)
                {
                    _AdminMenu = new AdminMenuRepository(_repoContext);
                }

                return _AdminMenu;
            }
        }

        

        public Iposition_repo Position
        {
            get
            {
                if (_Position == null)
                {
                    _Position = new position_repo(_repoContext);
                }

                return _Position;
            }
        }
        public IAdminlevelmenuRepository Adminlevelmenu
        {
            get
            {
                if (_Adminlevelmenu == null)
                {
                    _Adminlevelmenu = new AdminlevelmenuRepository(_repoContext);
                }

                return _Adminlevelmenu;
            }
        }
        public IAdminMenuUrlRepository AdminMenuUrl
        {
            get
            {
                if (_AdminMenuUrl == null)
                {
                    _AdminMenuUrl = new AdminMenuUrlRepository(_repoContext);
                }

                return _AdminMenuUrl;
            }
        }
        public IEmailTemplateRepository EmailTemplate
        {
            get
            {
                if (_EmailTemplate == null)
                {
                    _EmailTemplate = new EmailTemplateRepository(_repoContext);
                }

                return _EmailTemplate;
            }
        }
        public ISettingRepository Setting
        {
            get
            {
                if (_Setting == null)
                {
                    _Setting = new SettingRepository(_repoContext);
                }

                return _Setting;
            }
        }

        public IAdminRepository Admin
        {
            get
            {
                if (_Admin == null)
                {
                    _Admin = new AdminRepository(_repoContext);
                }

                return _Admin;
            }
        }

        public IAdminLevelRepository AdminLevel
        {
            get
            {
                if (_AdminLevel == null)
                {
                    _AdminLevel = new AdminLevelRepository(_repoContext);
                }

                return _AdminLevel;
            }
        }


        public IEventLogRepository EventLog
        {
            get
            {
                if (_EventLog == null)
                {
                    _EventLog = new EventLogRepository(_repoContext);
                }

                return _EventLog;
            }
        }
        public IGeneralRepository General
        {
            get
            {
                if (_General == null)
                {
                    _General = new GeneralRepository(_repoContext);
                }

                return _General;
            }
        }

        public ICompanyRepository Company
        {
            get
            {
                if (_Company == null)
                {
                    _Company = new CompanyRepository(_repoContext);
                }

                return _Company;
            }
        }
        public IProductRepository Product
        {
            get
            {
                if (_Product == null)
                {

                    _Product = new ProductRepository(_repoContext);

                }
                return _Product;

            }
        }
        public ICustomerRepository Customer
        {
            get
            {
                if (_Customer == null)
                {
                    _Customer = new CustomerRepository(_repoContext);
                }

                return _Customer;
            }
        }
        public IStorageChargesRepository StorageCharges
        {
            get
            {
                if (_StorageCharges == null)
                {
                    _StorageCharges = new StorageChargesRepository(_repoContext);
                }

                return _StorageCharges;
            }
        }

        public ITankRepository Tank

        {
            get
            {
                if (_Tank == null)
                {
                    _Tank = new TankRepository(_repoContext);
                }

                return _Tank;
            }
        }
        public IBowserRepository Bowser

        {
            get
            {
                if (_Bowser == null)
                {
                    _Bowser = new BowserRepository(_repoContext);
                }

                return _Bowser;
            }
        }
        public ICompartmentRepository Compartment

        {
            get
            {
                if (_Compartment == null)
                {
                    _Compartment = new CompartmentRepository(_repoContext);
                }

                return _Compartment;
            }
        }
        public IDriverRepository Driver

        {
            get
            {
                if (_Driver == null)
                {
                    _Driver = new DriverRepository(_repoContext);
                }

                return _Driver;
            }
        }
        public ISupplierorderRepository Supplierorder

        {
            get
            {
                if (_Supplierorder == null)
                {
                    _Supplierorder = new SupplierorderRepository(_repoContext);
                }

                return _Supplierorder;
            }
        }
        public ISupplierOrderDetailRepository SupplierOrderDetail

        {
            get
            {
                if (_SupplierOrderDetail == null)
                {
                    _SupplierOrderDetail = new SupplierOrderDetailRepository(_repoContext);
                }

                return _SupplierOrderDetail;
            }
        }

        public ILaneRepository Lane
        {
            get
            {
                if (_Lane == null)
                {
                    _Lane = new LaneRepository(_repoContext);
                }

                return _Lane;
            }
        }

        public IHoseRepository Hose
        {
            get
            {
                if (_Hose == null)
                {
                    _Hose = new HoseRepository(_repoContext);
                }

                return _Hose;
            }
        }
        public ITesting_Database Testing_Database
        {
            get
            {
                if (_Testing_Database == null)
                {
                    _Testing_Database = new Testing_Database(_repoContext);
                }

                return _Testing_Database;
            }
        }
        public ICustomerOrderRepository CustomerOrder
        {
            get
            {
                if (_CustomerOrder == null)
                {
                    _CustomerOrder = new CustomerOrderRepository(_repoContext);
                }

                return _CustomerOrder;
            }
        }
        public ICustomerOrderDetailRepository CustomerOrderDetail
        {
            get
            {
                if (_CustomerOrderDetail == null)
                {
                    _CustomerOrderDetail = new CustomerOrderDetailRepository(_repoContext);
                }

                return _CustomerOrderDetail;
            }
        }
        public IFuelFillingStaffRepository FuelFillingStaff
        {
            get
            {
                if (_FuelFillingStaff == null)
                {
                    _FuelFillingStaff = new FuelFillingStaffRepository(_repoContext);
                }

                return _FuelFillingStaff;
            }
        }
        ITankImportRepository IRepositoryWrapper.TankImport
        {
            get
            {
                if (_TankImport == null)
                {
                    _TankImport = new TankImportRepository(_repoContext);
                }

                return _TankImport;
            }
        }

        public ICustomerAssignRepository CustomerAssign

        {
            get
            {
                if (_CustomerAssign == null)
                {
                    _CustomerAssign = new CustomerAssignRepository(_repoContext);
                }

                return _CustomerAssign;
            }
        }
        public ICustomerAssignDetailRepository CustomerAssignDetail

        {
            get
            {
                if (_CustomerAssignDetail == null)
                {
                    _CustomerAssignDetail = new CustomerAssignDetailRepository(_repoContext);
                }

                return _CustomerAssignDetail;
            }
        }
        public IMovementTransactionRepository MovementTransaction

        {
            get
            {
                if (_MovementTransaction == null)
                {
                    _MovementTransaction = new MovementTransactionRepository(_repoContext);
                }

                return _MovementTransaction;
            }
        }
        public IDemandOrderRepository DemandOrder

        {
            get
            {
                if (_DemandOrder == null)
                {
                    _DemandOrder = new DemandOrderRepository(_repoContext);
                }

                return _DemandOrder;
            }
        }
        public IDemandOrderDetailRepository DemandOrderDetail

        {
            get
            {
                if (_DemandOrderDetail == null)
                {
                    _DemandOrderDetail = new DemandOrderDetailRepository(_repoContext);
                }

                return _DemandOrderDetail;
            }
        }

        public ISaleInvoiceRepository SaleInvoice
        {
            get
            {
                if (_SaleInvoice == null)
                {
                    _SaleInvoice = new SaleInvoiceRepository(_repoContext);
                }

                return _SaleInvoice;
            }
        }



        public ICashReceiptRepository CashReceipt
        {
            get
            {
                if (_CashReceipt == null)
                {
                    _CashReceipt = new CashReceiptRepository(_repoContext);
                }

                return _CashReceipt;
            }
        }
        public IUserRepository User
        {
            get
            {
                if (_User == null)
                {
                    _User = new UserRepository(_repoContext);
                }

                return _User;
            }
        }
        
        public IDepartmentrepo Department

        {
            get
            {
                if (_Department == null)
                {
                    _Department = new Departmentrepo(_repoContext);
                }

                return _Department;
            }
        }

        public IAccountRepo Account

        {
            get
            {
                if (_Account == null)
                {
                    _Account = new AccountRepo(_repoContext);
                }

                return _Account;
            }
        }

        

        

        public IAdmin_Admin_Repo AdminAdmin

        {
            get
            {
                if (_AdminAdmin == null)
                {
                    _AdminAdmin = new Admin_Admin_Repo(_repoContext);
                }

                return _AdminAdmin;
            }
        }
         public IAdmin_Permission_Repo AdminPermission

        {
            get
            {
                if (_AdminPermission == null)
                {
                    _AdminPermission = new Admin_Permission_Repo(_repoContext);
                }

                return _AdminPermission;
            }
        }

         public IAdmin_Relationship_Repo AdminRelationship

        {
            get
            {
                if (_AdminRelationship == null)
                {
                    _AdminRelationship = new Admin_Relationship_Repo(_repoContext);
                }

                return _AdminRelationship;
            }
        }

        
    }


}
