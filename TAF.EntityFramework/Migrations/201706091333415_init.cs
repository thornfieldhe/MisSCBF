namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActualOutlays",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VoucherNo = c.String(),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                        OutlayId = c.Guid(),
                        FileId = c.Guid(nullable: false),
                        Year = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BudgetOutlays", t => t.OutlayId)
                .Index(t => t.OutlayId);
            
            CreateTable(
                "dbo.BudgetOutlays",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Year = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        FileId = c.Guid(nullable: false),
                        SheetName = c.String(),
                        Unit = c.String(),
                        HasRelated = c.Boolean(nullable: false),
                        Name = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetReceiptId = c.Guid(),
                        Column1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Column2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Column3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BudgetReceipts", t => t.BudgetReceiptId)
                .Index(t => t.BudgetReceiptId);
            
            CreateTable(
                "dbo.BudgetReceipts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Year = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        FileId = c.Guid(nullable: false),
                        Column1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note1 = c.String(),
                        Column21 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note21 = c.String(),
                        Column22 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note22 = c.String(),
                        Column31 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note31 = c.String(),
                        Column32 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note32 = c.String(),
                        Column33 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note33 = c.String(),
                        Column34 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note34 = c.String(),
                        Column35 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note35 = c.String(),
                        Column36 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note36 = c.String(),
                        Column37 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note37 = c.String(),
                        Column41 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note41 = c.String(),
                        Column42 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note42 = c.String(),
                        Column43 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note43 = c.String(),
                        Column44 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note44 = c.String(),
                        Column45 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note45 = c.String(),
                        Column46 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note46 = c.String(),
                        Column47 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note47 = c.String(),
                        Column5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note5 = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Size = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Path = c.String(),
                        Ext = c.String(),
                        Category = c.String(),
                        ModuleId = c.Guid(nullable: false),
                        Note = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryBillId = c.Guid(nullable: false),
                        Note = c.String(),
                        StorageId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeliveryBills", t => t.DeliveryBillId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SysDictionaries", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.DeliveryBillId)
                .Index(t => t.StorageId);
            
            CreateTable(
                "dbo.DeliveryBills",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Note = c.String(),
                        IsSpecial = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CategoryId = c.Guid(nullable: false),
                        Specifications = c.String(),
                        Code = c.String(),
                        PYCode = c.String(),
                        Note1 = c.String(),
                        Note2 = c.String(),
                        Unit = c.String(),
                        Order = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EntryBillId = c.Guid(nullable: false),
                        Note = c.String(),
                        StorageId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EntryBills", t => t.EntryBillId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SysDictionaries", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.EntryBillId)
                .Index(t => t.StorageId);
            
            CreateTable(
                "dbo.EntryBills",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Note = c.String(),
                        IsSpecial = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysDictionaries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Value = c.String(),
                        Note = c.String(),
                        Category = c.String(),
                        Value2 = c.String(),
                        Value3 = c.String(),
                        Value4 = c.String(),
                        Value5 = c.String(),
                        Value6 = c.String(),
                        Value7 = c.String(),
                        Value8 = c.String(),
                        Value9 = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HisStocks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StorageId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SysDictionaries", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.StorageId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StorageId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SysDictionaries", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.StorageId);
            
            CreateTable(
                "dbo.Layers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PId = c.Guid(),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        LevelCode = c.String(),
                        Note = c.String(),
                        Category = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Year = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Code = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.AbpUsers", "EmailConfirmationCode", c => c.String(maxLength: 328));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deliveries", "StorageId", "dbo.SysDictionaries");
            DropForeignKey("dbo.Deliveries", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Entries", "StorageId", "dbo.SysDictionaries");
            DropForeignKey("dbo.Stocks", "StorageId", "dbo.SysDictionaries");
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropForeignKey("dbo.HisStocks", "StorageId", "dbo.SysDictionaries");
            DropForeignKey("dbo.HisStocks", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Entries", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Entries", "EntryBillId", "dbo.EntryBills");
            DropForeignKey("dbo.Deliveries", "DeliveryBillId", "dbo.DeliveryBills");
            DropForeignKey("dbo.BudgetOutlays", "BudgetReceiptId", "dbo.BudgetReceipts");
            DropForeignKey("dbo.ActualOutlays", "OutlayId", "dbo.BudgetOutlays");
            DropIndex("dbo.Stocks", new[] { "StorageId" });
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            DropIndex("dbo.HisStocks", new[] { "StorageId" });
            DropIndex("dbo.HisStocks", new[] { "ProductId" });
            DropIndex("dbo.Entries", new[] { "StorageId" });
            DropIndex("dbo.Entries", new[] { "EntryBillId" });
            DropIndex("dbo.Entries", new[] { "ProductId" });
            DropIndex("dbo.Deliveries", new[] { "StorageId" });
            DropIndex("dbo.Deliveries", new[] { "DeliveryBillId" });
            DropIndex("dbo.Deliveries", new[] { "ProductId" });
            DropIndex("dbo.BudgetOutlays", new[] { "BudgetReceiptId" });
            DropIndex("dbo.ActualOutlays", new[] { "OutlayId" });
            AlterColumn("dbo.AbpUsers", "EmailConfirmationCode", c => c.String(maxLength: 128));
            DropTable("dbo.Receipts");
            DropTable("dbo.Layers");
            DropTable("dbo.Stocks");
            DropTable("dbo.HisStocks");
            DropTable("dbo.SysDictionaries");
            DropTable("dbo.EntryBills");
            DropTable("dbo.Entries");
            DropTable("dbo.Products");
            DropTable("dbo.DeliveryBills");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Attachments");
            DropTable("dbo.BudgetReceipts");
            DropTable("dbo.BudgetOutlays");
            DropTable("dbo.ActualOutlays");
        }
    }
}
