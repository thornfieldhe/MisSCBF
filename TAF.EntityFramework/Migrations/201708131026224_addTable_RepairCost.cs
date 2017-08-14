namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_RepairCost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RepairCosts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Category = c.String(),
                        Year = c.Int(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApplyForVehicleMaintenanceId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RepairCosts");
        }
    }
}
