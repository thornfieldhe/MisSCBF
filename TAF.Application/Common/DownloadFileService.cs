// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DownloadFileService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   文件下载服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Aspose.Cells;

namespace SCBF.Common
{
    /// <summary>
    /// 文件下载服务
    /// </summary>
    public  class DownloadFileService
    {
        private string[] Parameters { get; set; }


        private string _templateFile;
        private string _fileName;

        public static DownloadFileService Load(string templateFile, string fileName, string[] parameters)
        {
            return new DownloadFileService
            {
                _templateFile =HttpContext.Current.Server.MapPath($"~/App_Data/Template/{templateFile}") ,
                _fileName     = fileName,
                Parameters   = parameters
            };
        }

        public string Excute<T>(List<T> list) where T:new()
        {
            this.DeleteOutPutFiles();
            var designer = new WorkbookDesigner();
            if (File.Exists(this._templateFile))
            {
                designer.Open(this._templateFile);
            }


            if (list != null)
            {
                designer.SetDataSource("Datas",list);
                designer.Process();
                designer.Save(this._fileName, FileFormatType.Excel2003XML);
            }

            return HttpContext.Current.Server.MapPath($"~//App_Data//Out//{this._fileName}");

        }

        public string Excute<T>(List<T> list,Func<WorkbookDesigner,List<T>,WorkbookDesigner> func) where T:new()
        {
            this.DeleteOutPutFiles();
            var designer = new WorkbookDesigner();
            if (File.Exists(this._templateFile))
            {
                designer.Open(this._templateFile);
            }

            designer = func(designer, list);
            designer.Save(HttpContext.Current.Server.MapPath($"~//App_Data//Out//{this._fileName}"), FileFormatType.Excel2003XML);

            return HttpContext.Current.Server.MapPath($"~//App_Data//Out//{this._fileName}");

        }

        private void DeleteOutPutFiles()
        {
            foreach (var item in Directory.GetFiles(HttpContext.Current.Server.MapPath("~//App_Data//Out//"), "*.*"))
            {
                File.Delete(item);
            }

        }
    }
}
