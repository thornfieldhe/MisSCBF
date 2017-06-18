namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable_RechargeRecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RechargeRecords", "HisAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.RechargeRecords", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RechargeRecords", "Date");
            DropColumn("dbo.RechargeRecords", "HisAmount");
        }
    }
}
