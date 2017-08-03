namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTable_ApplyForVehicleMaintenance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplyForVehicleMaintenances", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplyForVehicleMaintenances", "Code");
        }
    }
}
