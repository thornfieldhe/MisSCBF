namespace SCBF.EntityFramework
{
    using Abp.Zero.EntityFramework;
    using SCBF.Authorization.Roles;
    using SCBF.BaseInfo;
    using SCBF.Car;
    using SCBF.Finance;
    using SCBF.MultiTenancy;
    using SCBF.Storage;
    using SCBF.Users;
    using System.Data.Common;
    using System.Data.Entity;

    public class TAFDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */

        public TAFDbContext() : base("Default") { }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in TAFDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of TAFDbContext since ABP automatically handles it.
         */

        public TAFDbContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        //This constructor is used in tests
        public TAFDbContext(DbConnection connection) : base(connection, true) { }

        #region 基本信息

        public DbSet<Layer> Layers
        {
            get; set;
        }

        public DbSet<Attachment> Attachments
        {
            get; set;
        }

        public DbSet<SysDictionary> SysDictionaries
        {
            get; set;
        }

        #endregion

        #region 物资

        public DbSet<Product> Products
        {
            get; set;
        }

        public DbSet<Stock> Stocks
        {
            get; set;
        }

        public DbSet<HisStock> HisStocks
        {
            get; set;
        }


        public DbSet<Delivery> Deliveries
        {
            get; set;
        }

        public DbSet<Entry> Entries
        {
            get; set;
        }

        public DbSet<DeliveryBill> DeliveryBills
        {
            get; set;
        }

        public DbSet<EntryBill> EntrBills
        {
            get; set;
        }

        public DbSet<Check> Checks
        {
            get; set;
        }

        public DbSet<CheckBill> CheckBills
        {
            get; set;
        }

        #endregion

        #region 预算

        public DbSet<BudgetReceipt> BudgetReceipts
        {
            get; set;
        }

        public DbSet<BudgetOutlay> BudgetOutlays
        {
            get; set;
        }

        public DbSet<ActualOutlay> ActualOutlays
        {
            get; set;
        }


        public DbSet<Receipt> Receipts
        {
            get; set;
        }

        public DbSet<Outlay> Outlaies
        {
            get; set;
        }


        #endregion

        #region 车辆

        public DbSet<Driver> Drivers
        {
            get; set;
        }

        public DbSet<CarInfo> CarInfos
        {
            get; set;
        }

        public DbSet<ApplicationForBunkerA> ApplicationForBunkerAs
        {
            get; set;
        }

        public DbSet<OctaneStore> OctaneStores
        {
            get; set;
        }

        public DbSet<OilCardProof> OilCardProofs
        {
            get; set;
        }

        public DbSet<UploadOilCardRoof> UploadOilCardRoofs
        {
            get; set;
        }

        public DbSet<OilRechargeRecord> OilRechargeRecords
        {
            get; set;
        }

        public DbSet<UploadOilCarRoofRelationship> UploadOilCarRoofRelationships
        {
            get; set;
        }

        #endregion


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DeliveryMap());
            modelBuilder.Configurations.Add(new EntryMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}