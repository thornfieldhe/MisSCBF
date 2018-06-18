namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTable_BiddingManagement2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BiddingManagements", "Note", c => c.String());
            DropColumn("dbo.BiddingManagements", "Date");
            DropColumn("dbo.BiddingManagements", "PlanDateFrom");
            DropColumn("dbo.BiddingManagements", "PlanDateTo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BiddingManagements", "PlanDateTo", c => c.DateTime(nullable: false));
            AddColumn("dbo.BiddingManagements", "PlanDateFrom", c => c.DateTime(nullable: false));
            AddColumn("dbo.BiddingManagements", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.BiddingManagements", "Note");
        }
    }
}
