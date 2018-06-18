namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_PerformanceManages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PerformanceAmountDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PerformanceId = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PerformanceManages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PlanId = c.Guid(nullable: false),
                        HasPrint = c.Int(nullable: false),
                        MarginAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PerformanceManages");
            DropTable("dbo.PerformanceAmountDetails");
        }
    }
}
