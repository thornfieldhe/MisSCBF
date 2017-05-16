namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_ScheduledTask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScheduledTasks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Started = c.Boolean(nullable: false),
                        Schedule = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ScheduledTasks");
        }
    }
}
