namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableoutlay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Outlays",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Year = c.Int(nullable: false),
                        Total1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                        Code = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Outlays");
        }
    }
}
