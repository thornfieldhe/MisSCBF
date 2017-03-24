namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifytable_stock2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeliveryBills", "StorageId", "dbo.SysDictionaries");
            DropForeignKey("dbo.EntryBills", "StorageId", "dbo.SysDictionaries");
            DropIndex("dbo.DeliveryBills", new[] { "StorageId" });
            DropIndex("dbo.EntryBills", new[] { "StorageId" });
            AddColumn("dbo.Deliveries", "StorageId", c => c.Guid(nullable: false));
            AddColumn("dbo.Entries", "StorageId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Deliveries", "StorageId");
            CreateIndex("dbo.Entries", "StorageId");
            AddForeignKey("dbo.Entries", "StorageId", "dbo.SysDictionaries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Deliveries", "StorageId", "dbo.SysDictionaries", "Id", cascadeDelete: true);
            DropColumn("dbo.DeliveryBills", "StorageId");
            DropColumn("dbo.EntryBills", "StorageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EntryBills", "StorageId", c => c.Guid(nullable: false));
            AddColumn("dbo.DeliveryBills", "StorageId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Deliveries", "StorageId", "dbo.SysDictionaries");
            DropForeignKey("dbo.Entries", "StorageId", "dbo.SysDictionaries");
            DropIndex("dbo.Entries", new[] { "StorageId" });
            DropIndex("dbo.Deliveries", new[] { "StorageId" });
            DropColumn("dbo.Entries", "StorageId");
            DropColumn("dbo.Deliveries", "StorageId");
            CreateIndex("dbo.EntryBills", "StorageId");
            CreateIndex("dbo.DeliveryBills", "StorageId");
            AddForeignKey("dbo.EntryBills", "StorageId", "dbo.SysDictionaries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeliveryBills", "StorageId", "dbo.SysDictionaries", "Id", cascadeDelete: true);
        }
    }
}
