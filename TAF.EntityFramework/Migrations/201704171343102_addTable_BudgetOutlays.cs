namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_BudgetOutlays : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BudgetOutlays",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Year = c.Int(nullable: false),
                        FileId = c.String(),
                        SheetName = c.String(),
                        Unit = c.String(),
                        HasRelated = c.Boolean(nullable: false),
                        Name = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceiptId = c.Guid(),
                        Column1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Column31 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Column3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BudgetOutlays");
        }
    }
}
