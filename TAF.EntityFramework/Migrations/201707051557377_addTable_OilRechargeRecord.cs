namespace SCBF.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addTable_OilRechargeRecord : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OilRechargeRecords",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Code = c.String(),
                    OctanceId = c.Guid(nullable: false),
                    Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Note = c.String(),
                    AttachmentId = c.String(),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                    LastModificationTime = c.DateTime(),
                    LastModifierUserId = c.Long(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OctaneStores", t => t.OctanceId, cascadeDelete: true)
                .Index(t => t.OctanceId);

            AddColumn("dbo.OctaneStores", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }

        public override void Down()
        {
            DropForeignKey("dbo.OilRechargeRecords", "OctanceId", "dbo.OctaneStores");
            DropIndex("dbo.OilRechargeRecords", new[] { "OctanceId" });
            DropColumn("dbo.OctaneStores", "Amount");
            DropTable("dbo.OilRechargeRecords");
        }
    }
}
