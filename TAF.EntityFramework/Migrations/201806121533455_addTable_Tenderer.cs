namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_Tenderer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tenderers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BiddingManagementId = c.Guid(nullable: false),
                        Name = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tenderers");
        }
    }
}
