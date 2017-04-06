namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_BudgetReceipt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BudgetReceipts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Year = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Column1 = c.String(),
                        Note1 = c.String(),
                        Column21 = c.String(),
                        Note21 = c.String(),
                        Column22 = c.String(),
                        Note22 = c.String(),
                        Column31 = c.String(),
                        Note31 = c.String(),
                        Column32 = c.String(),
                        Note32 = c.String(),
                        Column33 = c.String(),
                        Note33 = c.String(),
                        Column34 = c.String(),
                        Note34 = c.String(),
                        Column35 = c.String(),
                        Note35 = c.String(),
                        Column36 = c.String(),
                        Note36 = c.String(),
                        Column41 = c.String(),
                        Note41 = c.String(),
                        Column42 = c.String(),
                        Note42 = c.String(),
                        Column43 = c.String(),
                        Note43 = c.String(),
                        Column44 = c.String(),
                        Note44 = c.String(),
                        Column45 = c.String(),
                        Note45 = c.String(),
                        Column46 = c.String(),
                        Note46 = c.String(),
                        Column47 = c.String(),
                        Note47 = c.String(),
                        Column5 = c.String(),
                        Note5 = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BudgetReceipts");
        }
    }
}
