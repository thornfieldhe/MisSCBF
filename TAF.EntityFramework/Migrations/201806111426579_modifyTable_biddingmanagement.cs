namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTable_biddingmanagement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProcurementPlans", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.BiddingManagements", "ExpertId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BiddingManagements", "ExpertId");
            DropColumn("dbo.ProcurementPlans", "Year");
        }
    }
}
