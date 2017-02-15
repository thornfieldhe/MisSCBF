namespace SCBF.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class modifyTable_projectTask : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProjectTasks", "IsCompleted");
        }

        public override void Down()
        {
            AddColumn("dbo.ProjectTasks", "IsCompleted", c => c.Boolean(nullable: false));
        }
    }
}
