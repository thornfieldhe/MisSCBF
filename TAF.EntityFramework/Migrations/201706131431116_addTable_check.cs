namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_check : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckBills",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Code = c.String(),
                        Year = c.Int(nullable: false),
                        StorageId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Checks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        StockAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Reason = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckBillId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CheckBills", t => t.CheckBillId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CheckBillId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checks", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Checks", "CheckBillId", "dbo.CheckBills");
            DropIndex("dbo.Checks", new[] { "CheckBillId" });
            DropIndex("dbo.Checks", new[] { "ProductId" });
            DropTable("dbo.Checks");
            DropTable("dbo.CheckBills");
        }
    }
}
