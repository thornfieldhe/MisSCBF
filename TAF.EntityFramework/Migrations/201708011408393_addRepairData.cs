namespace SCBF.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addRepairData : DbMigration
    {
        public override void Up()
        {
            Sql(@"DELETE FROM SysDictionaries WHERE Category IN('Car_Overhaul','Car_Repair','Car_MinorRepair') 
INSERT INTO [dbo].[SysDictionaries]([Id],[Value],[Category] ,[CreationTime] ,[CreatorUserId],[LastModificationTime],[LastModifierUserId])VALUES(NEWID(),'1000','Car_Overhaul',GETDATE(),1,GETDATE(),1) 
INSERT INTO [dbo].[SysDictionaries]([Id],[Value],[Category] ,[CreationTime] ,[CreatorUserId],[LastModificationTime],[LastModifierUserId])VALUES(NEWID(),'2000','Car_Repair',GETDATE(),1,GETDATE(),1) 
INSERT INTO [dbo].[SysDictionaries]([Id],[Value],[Category] ,[CreationTime] ,[CreatorUserId],[LastModificationTime],[LastModifierUserId])VALUES(NEWID(),'3000','Car_MinorRepair',GETDATE(),1,GETDATE(),1) ");
        }

        public override void Down()
        {
        }
    }
}
