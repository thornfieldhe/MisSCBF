namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteTable_SchaduleTasks : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ScheduledTasks");
        }
        
        public override void Down()
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
    }
}
