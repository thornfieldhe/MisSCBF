namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_StoreStocks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HisCarStoreStocks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OctaneStoreId = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        YearMonth = c.String(),
                        Category = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HisCarStoreStocks");
        }
    }
}
