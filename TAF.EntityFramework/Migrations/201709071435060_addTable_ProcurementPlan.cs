namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_ProcurementPlan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanWithBudgetOutlays",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProcurementPlanId = c.Guid(nullable: false),
                        BudgetOutlayId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BudgetOutlays", t => t.BudgetOutlayId, cascadeDelete: true)
                .ForeignKey("dbo.ProcurementPlans", t => t.ProcurementPlanId, cascadeDelete: true)
                .Index(t => t.ProcurementPlanId)
                .Index(t => t.BudgetOutlayId);
            
            CreateTable(
                "dbo.ProcurementPlans",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Category = c.String(),
                        Mode = c.String(),
                        Code = c.String(),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Department = c.Guid(nullable: false),
                        User = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlanWithBudgetOutlays", "ProcurementPlanId", "dbo.ProcurementPlans");
            DropForeignKey("dbo.PlanWithBudgetOutlays", "BudgetOutlayId", "dbo.BudgetOutlays");
            DropIndex("dbo.PlanWithBudgetOutlays", new[] { "BudgetOutlayId" });
            DropIndex("dbo.PlanWithBudgetOutlays", new[] { "ProcurementPlanId" });
            DropTable("dbo.ProcurementPlans");
            DropTable("dbo.PlanWithBudgetOutlays");
        }
    }
}
