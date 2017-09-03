namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable_invoice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "Code", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "Code", c => c.Long(nullable: false));
        }
    }
}
