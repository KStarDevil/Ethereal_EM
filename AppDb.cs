using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;

using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using OfficeOpenXml;

namespace Ethereal_EM
{
    public class AppDb : DbContext
    {
        public string _connectionString = "";
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {
            //context.Database.EnsureCreated();   //uncomment to create new database 
            /*   var appsettingbuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
              var Configuration = appsettingbuilder.Build();
              _connectionString = Configuration.GetConnectionString("DefaultConnection"); */
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Adminlevel> Adminlevel { get; set; }
        public DbSet<Adminlevelmenu> Adminlevelmenu { get; set; }
        public DbSet<Adminmenu> Adminmenu { get; set; }
        public DbSet<AdminMenuDetails> AdminMenuDetails { get; set; }
        public DbSet<EventLog> EventLog { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<AccountModel> Account { get; set; }
        public DbSet<AdminMenuUrl> AdminMenuUrl { get; set; }
        public DbSet<EmailTemplate> EmailTemplate { get; set; }
        public DbSet<General>General { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Company1> Company1 { get; set; }
        public DbSet<User> Users { get ; set;}
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<StorageCharges> StorageCharges { get; set; }
        public DbSet<Tank> Tank { get; set; }
        public DbSet<TankImport> TankImport { get; set; }
        public DbSet<Bowser> Bowser { get; set; }
        public DbSet<Compartment> Compartment { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Lane> Lane { get; set; }
        public DbSet<Hose> Hose { get; set; }
        public DbSet<Bun> Bun { get; set; }
        public DbSet<position_model> position_model {get; set;}
        public DbSet<CustomerOrder> CustomerOrder { get; set; }
        public DbSet<CustomerOrderDetail> CustomerOrderDetail { get; set; }
        public DbSet<CustomerAssign> CustomerAssign { get; set; }
        public DbSet<CustomerAssignDetail> CustomerAssignDetail { get; set; }
        public DbSet<DemandOrder> DemandOrder { get; set; }
        public DbSet<DemandOrderDetail> DemandOrderDetail { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<DeliveryDetail> DeliveryDetail { get; set; }
        //public DbSet<FuelFilling> FuelFilling { get; set; }
        public DbSet<MovementTransaction> MovementTransaction { get; set; }
        public DbSet<SupplierOrder> SupplierOrder { get; set; }
        public DbSet<SupplierOrderDetail> SupplierOrderDetail { get; set; }
        public DbSet<SaleInvoice> SaleInvoice { get; set; }
        public DbSet<SaleInvoiceItem> SaleInvoiceItem { get; set; }
         public DbSet<FuelFillingStaff> FuelFillingStaff { get; set; }

         public DbSet <TankImport> TankImports {get;set;}

         public DbSet <CashReceipt> CashReceipt{get;set;}
         public DbSet <tb_adminmodel> tb_adminmodel{get;set;}
          public DbSet <tb_permissionmodel> tb_permissionmodel{get;set;}
          public DbSet <tb_relationmodel> tb_relationmodel{get;set;}
          public DbSet <carmodel> carmodel{get;set;}

          public DbSet <FileSaveModel> FileSaveModel{get;set;}
          public DbSet <hw_tb1_user> hw_tb1_user{get;set;}
          public DbSet <hw_tb1_account> hw_tb1_account{get;set;}
          public DbSet <hw_tb1_register> hw_tb1_register{get;set;}
          //project
          public DbSet <tbAdmin> tbAdmin{get;set;}
          public DbSet <tbl_role> tbl_role{get;set;}
          public DbSet <tbl_permission> tbl_permission{get;set;}
          public DbSet <tbl_menu> tbl_menu{get;set;}
          public DbSet <tbl_permission_admin> tbl_permission_admin{get;set;}
          public DbSet <tbl_role_admin> tbl_role_admin{get;set;}
          public DbSet <tbl_menu_permission> tbl_menu_permission{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<hw_tb1_user>()
              .HasKey(c => new { c.id });
            //project
            modelBuilder.Entity<tbAdmin>()
              .HasKey(c => new { c.admin_id });
            
            modelBuilder.Entity<tbl_role>()
              .HasKey(c => new { c.role_id });

            modelBuilder.Entity<tbl_permission>()
              .HasKey(c => new { c.permission_id});
            
            modelBuilder.Entity<tbl_menu>()
              .HasKey(c => new { c.menu_id });
            
            modelBuilder.Entity<tbl_permission_admin>()
              .HasKey(c => new {c.permission_admin_id});

            modelBuilder.Entity<tbl_role_admin>()
              .HasKey(c => new {c.role_admin_id});

            modelBuilder.Entity<tbl_menu_permission>()
              .HasKey(c => new {c.menu_permission_id});
            //project
            modelBuilder.Entity<hw_tb1_account>()
              .HasKey(c => new { c.name });

              modelBuilder.Entity<hw_tb1_register>()
              .HasKey(c => new { c.password });

            modelBuilder.Entity<FileSaveModel>()
              .HasKey(c => new { c.id });
              

            modelBuilder.Entity<tb_adminmodel>()
              .HasKey(c => new { c.admin_id });
            
            modelBuilder.Entity<carmodel>()
              .HasKey(c => new { c.car_id });

              modelBuilder.Entity<tb_relationmodel>()
              .HasKey(c => new { c.relation_id });

             modelBuilder.Entity<tb_permissionmodel>()
            .HasKey(c => new { c.permission_id });

            modelBuilder.Entity<General>()
              .HasKey(c => new { c.id });

            modelBuilder.Entity<User>()
              .HasKey(c => new { c.id });

            modelBuilder.Entity<position_model>()
              .HasKey(c => new { c.ID });

             modelBuilder.Entity<AccountModel>()
              .HasKey(c => new { c.A_Name });

            modelBuilder.Entity<AdminMenuUrl>()
                .HasKey(c => new { c.AdminMenuID, c.ServiceUrl });

            modelBuilder.Entity<Adminlevelmenu>()
                .HasKey(c => new { c.AdminLevelID, c.AdminMenuID });

            modelBuilder.Entity<AdminMenuDetails>()
                .HasKey(c => new { c.MenuID, c.ControllerName });

            modelBuilder.Entity<EventLog>()
                .HasKey(c => new { c.ID });

            modelBuilder.Entity<Company>()
            .HasKey(c => new { c.companyID });

            modelBuilder.Entity<Company1>()
            .HasKey(c => new { c.id });

            modelBuilder.Entity<Product>()
           .HasKey(c => new { c.productID });

            modelBuilder.Entity<Customer>()
          .HasKey(c => new { c.customerID });

            modelBuilder.Entity<StorageCharges>()
          .HasKey(c => new { c.storagechargeID });

            modelBuilder.Entity<Tank>()
          .HasKey(c => new { c.tankID });
          
           modelBuilder.Entity<TankImport>()
         .HasKey(c => new { c.ID });
          
           modelBuilder.Entity<Bowser>()
         .HasKey(c => new { c.bowserID });
            
            modelBuilder.Entity<Compartment>()
         .HasKey(c => new { c.compartmentID });
           
            modelBuilder.Entity<Driver>()
         .HasKey(c => new { c.driverID });
           
            modelBuilder.Entity<Lane>()
          .HasKey(c => new { c.laneID });
           
            modelBuilder.Entity<Hose>()
          .HasKey(c => new { c.hoseID });

              modelBuilder.Entity<Bun>()
          .HasKey(c => new { c.id });
            
            modelBuilder.Entity<CustomerOrder>()
          .HasKey(c => new { c.customerOrderID });
           
            modelBuilder.Entity<CustomerOrderDetail>()
          .HasKey(c => new { c.customerorderDetailID });
          
            modelBuilder.Entity<CustomerAssign>()
          .HasKey(c => new { c.customerassignID });
            
            modelBuilder.Entity<CustomerAssignDetail>()
          .HasKey(c => new { c.assigndetailID });
           
            modelBuilder.Entity<DemandOrder>()
           .HasKey(c => new { c.demandorderID });
           
            modelBuilder.Entity<DemandOrderDetail>()
           .HasKey(c => new { c.orderdetailID });
           
            modelBuilder.Entity<Delivery>()
           .HasKey(c => new { c.deliveryID });

            modelBuilder.Entity<Department>()
           .HasKey(c => new { c.D_ID });

            modelBuilder.Entity<DeliveryDetail>()
          .HasKey(c => new { c.deliverydetailID });
            
          //   modelBuilder.Entity<FuelFilling>()
          //  .HasKey(c => new { c.fillingID });
           
            modelBuilder.Entity<MovementTransaction>()
           .HasKey(c => new { c.movementID });
           
            modelBuilder.Entity<SupplierOrder>()
           .HasKey(c => new { c.supplierOrderID });
          
            modelBuilder.Entity<SupplierOrderDetail>()
           .HasKey(c => new { c.supplierorderdetailID });
          
            modelBuilder.Entity<SaleInvoice>()
           .HasKey(c => new { c.saleinvoiceID });
           
            modelBuilder.Entity<SaleInvoiceItem>()
           .HasKey(c => new { c.saleinvoiceitemID });

            modelBuilder.Entity<FuelFillingStaff>()
           .HasKey(c => new { c.staffID });

            modelBuilder.Entity<TankImport>()
           .HasKey(c => new { c.ID });

           modelBuilder.Entity<CashReceipt>()
           .HasKey(c => new { c.cashreceiptID});

        }
    }
}