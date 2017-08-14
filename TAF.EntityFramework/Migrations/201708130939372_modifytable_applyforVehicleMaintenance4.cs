namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifytable_applyforVehicleMaintenance4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplyForVehicleMaintenances", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ApplyForVehicleMaintenances", "RepairType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplyForVehicleMaintenances", "RepairType");
            DropColumn("dbo.ApplyForVehicleMaintenances", "TotalPrice");
        }
    }
}
