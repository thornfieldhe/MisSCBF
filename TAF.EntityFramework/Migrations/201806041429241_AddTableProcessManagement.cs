namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableProcessManagement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProcessManagements",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PurchaseId = c.Guid(nullable: false),
                        Type = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                        ProcurementPlanId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProcurementPlans", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Relationships",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PrincipalKey = c.Guid(nullable: false),
                        ForeignKey = c.Guid(nullable: false),
                        Type = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProcessManagements", "Id", "dbo.ProcurementPlans");
            DropIndex("dbo.ProcessManagements", new[] { "Id" });
            DropTable("dbo.Relationships");
            DropTable("dbo.ProcessManagements");
        }
    }
}
