namespace SCBF.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addTable_project : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysDictionaries",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Key = c.String(),
                    Value = c.String(),
                    Text = c.String(),
                    Note = c.String(),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                    LastModificationTime = c.DateTime(),
                    LastModifierUserId = c.Long(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Projects",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(),
                    Goal = c.String(),
                    IsCompleted = c.Boolean(nullable: false),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                    LastModificationTime = c.DateTime(),
                    LastModifierUserId = c.Long(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ProjectTasks",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(),
                    ProjectId = c.Guid(nullable: false),
                    IsCompleted = c.Boolean(nullable: false),
                    Schedule = c.String(),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                    LastModificationTime = c.DateTime(),
                    LastModifierUserId = c.Long(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.ProjectTasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectTasks", new[] { "ProjectId" });
            DropTable("dbo.ProjectTasks");
            DropTable("dbo.Projects");
            DropTable("dbo.SysDictionaries");
        }
    }
}
