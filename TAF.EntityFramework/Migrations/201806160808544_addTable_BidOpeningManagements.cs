namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_BidOpeningManagements : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BidOpeningManagements",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PlanId = c.Guid(nullable: false),
                        HasPrint = c.Int(nullable: false),
                        ExpertId = c.Guid(nullable: false),
                        SuccessfulTender = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BidOpeningManagements");
        }
    }
}
