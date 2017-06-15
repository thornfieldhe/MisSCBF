namespace SCBF.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addtable_driver : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(),
                    SoldierId = c.String(),
                    ValidDrivingLicense = c.DateTime(nullable: false),
                    DrivingLicense = c.String(),
                    LevelId = c.Guid(nullable: false),
                    PhoneNumber = c.String(),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                    LastModificationTime = c.DateTime(),
                    LastModifierUserId = c.Long(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysDictionaries", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.LevelId);
            Sql(@"
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'B8DCB833-4332-40AB-87F5-13E700F18968', N'报废', null, N'Car_Status', null, null, null, null, null, null, null, null, N'2017-06-15 21:47:42.057', N'1', null, null, null, null, null, null, null, null, null, null, null, null)
GO
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'44A276CC-3A51-4BF6-9705-1D7ED9B94934', N'A1', null, N'Car_DriveLevel', null, null, null, null, null, null, null, null, N'2017-06-15 21:16:09.367', N'1', null, null, null, null, null, null, null, null, null, null, null, null)
GO
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'AF591F04-218E-4C1E-A516-2A6323A99F66', N'C', null, N'Car_DriveLevel', null, null, null, null, null, null, null, null, N'2017-06-15 21:16:06.117', N'1', null, null, null, null, null, null, null, null, null, null, null, null)
GO
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'8E80F36B-C73D-4430-ABC8-500C2DA35423', N'单位1', null, N'Car_OilHostingUnit', null, null, null, null, null, null, null, null, N'2017-06-15 21:48:31.913', N'1', null, null, null, null, null, null, null, null, null, null, null, null)
GO
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'6AE78D47-7EB7-4E6C-9461-6C22EA38BBD1', N'勘用', null, N'Car_Status', null, null, null, null, null, null, null, null, N'2017-06-15 21:13:16.367', N'1', null, null, null, null, null, null, null, null, null, null, null, null)
GO
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'C4A03511-D5AF-4A9A-B4F4-798145EC883C', N'A', null, N'Car_DriveLevel', null, null, null, null, null, null, null, null, N'2017-06-15 21:15:58.330', N'1', null, null, null, null, null, null, null, null, null, null, null, null)
GO
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'58C40991-5DBA-4815-B430-7E5C68478850', N'B', null, N'Car_DriveLevel', null, null, null, null, null, null, null, null, N'2017-06-15 21:16:02.623', N'1', null, null, null, null, null, null, null, null, null, null, null, null)
GO
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'910722ED-7134-4682-98BE-81A2F1866BA3', N'2017', null, N'Car_Year', N'1/1/2017 12:00:00 AM', N'12/31/2017 12:00:00 AM', N'True', null, null, null, null, null, N'2017-06-15 21:16:18.240', N'1', null, null, null, null, null, null, null, null, null, null, null, null)
GO
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'993863BC-1DB9-4527-8B77-8361434CF982', N'封存', null, N'Car_Status', null, null, null, null, null, null, null, null, N'2017-06-15 21:47:57.103', N'1', null, null, null, null, null, null, null, null, null, null, null, null)
GO
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'23D91147-D181-4E51-9270-8414C9B9AE95', N'张三', null, N'Car_Minister', null, null, null, null, null, null, null, null, N'2017-06-15 21:48:18.747', N'1', null, null, null, null, null, null, null, null, null, null, null, null)
GO
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'691A9302-DD00-45CE-BF47-93E624D6B293', N'新车', null, N'Car_Status', null, null, null, null, null, null, null, null, N'2017-06-15 21:48:03.023', N'1', null, null, null, null, null, null, null, null, null, null, null, null)
GO
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'681E8A07-AF79-4F1B-99B0-94F5732E408F', N'单位2', null, N'Car_OilHostingUnit', null, null, null, null, null, null, null, null, N'2017-06-15 21:48:35.497', N'1', null, null, null, null, null, null, null, null, null, null, null, null)
GO
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'6268FCAE-1321-4BB7-AB8B-9F0C130CD42A', N'修理中', null, N'Car_Status', null, null, null, null, null, null, null, null, N'2017-06-15 21:48:08.403', N'1', null, null, null, null, null, null, null, null, null, null, null, null)
GO
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'5ADB2654-085D-4CDE-B76C-E40ADB8652B7', N'待报废', null, N'Car_Status', null, null, null, null, null, null, null, null, N'2017-06-15 21:47:49.147', N'1', null, null, null, null, null, null, null, null, null, null, null, null)
GO
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'64C62C95-09F8-47BF-89CC-F9FBE7F42647', N'李四', null, N'Car_Attendant', null, null, null, null, null, null, null, null, N'2017-06-15 21:48:24.367', N'1', null, null, null, null, null, null, null, null, null, null, null, null)");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Drivers", "LevelId", "dbo.SysDictionaries");
            DropIndex("dbo.Drivers", new[] { "LevelId" });
            DropTable("dbo.Drivers");
            Sql("delete from SysDictionaries where [category] like '%Car%'");
        }
    }
}
