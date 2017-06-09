namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initData : DbMigration
    {
        public override void Up()
        {
            this.Sql(
                @"INSERT [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value2], [Value3], [Value4], [Value5]) VALUES (N'fa9fc03f-dd53-4a1e-82c5-c3c4f580ac1e', N'~/App_Data/Attachment', N'', N'Attachment_BasePath', CAST(N'2017-04-10 22:28:02.337' AS DateTime), 1, CAST(N'2017-04-10 22:32:05.950' AS DateTime), 1, N'', N'', N'', N'')
            INSERT[dbo].[SysDictionaries]([Id], [Value], [Note], [Category], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value2], [Value3], [Value4], [Value5]) VALUES(N'774c73f2-ce98-4a18-a0ef-30c9f6e31bd9', N'.json,.jpg,.png,.rar,.zip,.doc,.xls,.docx,.xlsx', N'', N'Attachment_Ext', CAST(N'2017-04-12 22:56:44.350' AS DateTime), 1, CAST(N'2017-04-26 22:18:01.310' AS DateTime), 1, N'', N'', N'', N'')
            INSERT[dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId]) VALUES (N'15dd8fe7-956c-4164-ae13-5c47fdc834ff', N'2017', NULL, N'Budget_Year', N'2017-01-01', N'2018-03-31', N'True', NULL, CAST(N'2017-06-09 21:14:35.727' AS DateTime), 1, NULL, NULL)
            ");
        }
        
        public override void Down()
        {
        }
    }
}
