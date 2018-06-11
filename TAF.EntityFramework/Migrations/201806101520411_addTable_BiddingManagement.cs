namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_BiddingManagement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BiddingManagements",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PlanId = c.Guid(nullable: false),
                        HasPrint = c.Boolean(nullable: false),
                        BiddingAgencyId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PlanDateFrom = c.DateTime(nullable: false),
                        PlanDateTo = c.DateTime(nullable: false),
                        PlanDateEnd = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Schedule = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CostLists",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BiddingManagementId = c.Guid(nullable: false),
                        Category = c.String(),
                        Details = c.String(),
                        Unit = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CostLists");
            DropTable("dbo.BiddingManagements");
        }
    }
}
