namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_CarRepairTimes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarRepairTimes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PartId = c.Guid(nullable: false),
                        ApplyForVehicleMaintenanceId = c.Guid(nullable: false),
                        ServiceDepotId = c.Guid(nullable: false),
                        CatInfoId = c.Guid(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(),
                        Hours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ManHourId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CarRepairTimes");
        }
    }
}
