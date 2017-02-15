namespace SCBF.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addTable_dailylog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyLogs",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    TaskId = c.Guid(nullable: false),
                    Date = c.DateTime(nullable: false),
                    ProjectId = c.Guid(nullable: false),
                    Note = c.String(),
                    ResponsiblePersonId = c.Long(nullable: false),
                    TimeConsuming = c.Int(nullable: false),
                    Schedule = c.Int(nullable: false),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                    LastModificationTime = c.DateTime(),
                    LastModifierUserId = c.Long(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.ResponsiblePersonId, cascadeDelete: true)
                .ForeignKey("dbo.ProjectTasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId)
                .Index(t => t.ResponsiblePersonId);

            AddColumn("dbo.ProjectTasks", "Note", c => c.String());
            AlterColumn("dbo.ProjectTasks", "Schedule", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropForeignKey("dbo.DailyLogs", "TaskId", "dbo.ProjectTasks");
            DropForeignKey("dbo.DailyLogs", "ResponsiblePersonId", "dbo.AbpUsers");
            DropIndex("dbo.DailyLogs", new[] { "ResponsiblePersonId" });
            DropIndex("dbo.DailyLogs", new[] { "TaskId" });
            AlterColumn("dbo.ProjectTasks", "Schedule", c => c.String());
            DropColumn("dbo.ProjectTasks", "Note");
            DropTable("dbo.DailyLogs");
        }
    }
}
