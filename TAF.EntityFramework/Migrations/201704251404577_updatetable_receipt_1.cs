namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetable_receipt_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receipts", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receipts", "Code");
        }
    }
}
