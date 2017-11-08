namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_StageInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StageInfoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Category = c.Int(nullable: false),
                        Company = c.Guid(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        ProcurementPlanId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProcurementPlans", t => t.ProcurementPlanId, cascadeDelete: true)
                .Index(t => t.ProcurementPlanId);
            
            CreateTable(
                "dbo.StageInfoActualOutlays",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StageInfoId = c.Guid(nullable: false),
                        ActualOutlayId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StageInfoBudgetOutlays",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StageInfoId = c.Guid(nullable: false),
                        BudgetOutlayId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StageInfoUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StageInfoId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StageInfoes", "ProcurementPlanId", "dbo.ProcurementPlans");
            DropIndex("dbo.StageInfoes", new[] { "ProcurementPlanId" });
            DropTable("dbo.StageInfoUsers");
            DropTable("dbo.StageInfoBudgetOutlays");
            DropTable("dbo.StageInfoActualOutlays");
            DropTable("dbo.StageInfoes");
        }
    }
}
