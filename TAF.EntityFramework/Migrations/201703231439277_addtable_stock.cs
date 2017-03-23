namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable_stock : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryBillId = c.Guid(nullable: false),
                        Note = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeliveryBills", t => t.DeliveryBillId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.DeliveryBillId);
            
            CreateTable(
                "dbo.DeliveryBills",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StorageId = c.Guid(nullable: false),
                        Code = c.String(),
                        Note = c.String(),
                        IsSpecial = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysDictionaries", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.StorageId);
            
            CreateTable(
                "dbo.EntryBills",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StorageId = c.Guid(nullable: false),
                        Code = c.String(),
                        Note = c.String(),
                        IsSpecial = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysDictionaries", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.StorageId);
            
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EntryBillId = c.Guid(nullable: false),
                        Note = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EntryBills", t => t.EntryBillId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.EntryBillId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StorageId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysDictionaries", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.StorageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deliveries", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Deliveries", "DeliveryBillId", "dbo.DeliveryBills");
            DropForeignKey("dbo.Stocks", "StorageId", "dbo.SysDictionaries");
            DropForeignKey("dbo.EntryBills", "StorageId", "dbo.SysDictionaries");
            DropForeignKey("dbo.Entries", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Entries", "EntryBillId", "dbo.EntryBills");
            DropForeignKey("dbo.DeliveryBills", "StorageId", "dbo.SysDictionaries");
            DropIndex("dbo.Stocks", new[] { "StorageId" });
            DropIndex("dbo.Entries", new[] { "EntryBillId" });
            DropIndex("dbo.Entries", new[] { "ProductId" });
            DropIndex("dbo.EntryBills", new[] { "StorageId" });
            DropIndex("dbo.DeliveryBills", new[] { "StorageId" });
            DropIndex("dbo.Deliveries", new[] { "DeliveryBillId" });
            DropIndex("dbo.Deliveries", new[] { "ProductId" });
            DropTable("dbo.Stocks");
            DropTable("dbo.Entries");
            DropTable("dbo.EntryBills");
            DropTable("dbo.DeliveryBills");
            DropTable("dbo.Deliveries");
        }
    }
}
