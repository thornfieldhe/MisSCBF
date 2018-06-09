namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTable_attachment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attachments", "ModelId", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attachments", "ModelId");
        }
    }
}
