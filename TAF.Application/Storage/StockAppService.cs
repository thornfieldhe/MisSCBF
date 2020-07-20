// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   库存服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Abp.UI;
using Aspose.Cells;
using SCBF.BaseInfo;
using SCBF.Common;
using SCBF.Purchase.Dto;
using TAF.Utility;

namespace SCBF.Storage{
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;
    using AutoMapper;
    using SCBF.Storage.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Threading.Tasks;

    /// <summary>
    /// 库存服务
    /// </summary>
    [AbpAuthorize]
    public class StockAppService : TAFAppServiceBase, IStockAppService{
        private readonly IStockRepository stockRepository;

        public StockAppService(IStockRepository stockRepository){
            this.stockRepository = stockRepository;
        }

        public ListResultDto<StockListDto> GetAll(StockQueryDto request){
            var query = this.stockRepository.GetAll()
                            .Where(r => r.Amount != 0)
                            .WhereIf(!string.IsNullOrWhiteSpace(request.ProductName)
                                   , r => r.Product.Name.Contains(request.ProductName))
                            .WhereIf(!string.IsNullOrWhiteSpace(request.Code)
                                   , r => r.Product.Code.Contains(request.Code));

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                ? query.OrderBy(request.Sorting)
                : query.OrderBy(r => r.Product.Name);
            var count = query.Count();
            var list  = query.AsQueryable().PageBy(request).ToList();
            var dtos  = list.MapTo<List<StockListDto>>();

            return new PagedResultDto<StockListDto>(count, dtos);
        }

        public StockEditDto Get(Guid id){
            var output = this.stockRepository.Get(id);
            return output.MapTo<StockEditDto>();
        }

        public async Task SaveAsync(StockEditDto input){
            var item = input.MapTo<Stock>();
            if(input.Id == Guid.Empty){
                await this.stockRepository.InsertAsync(item);
            } else{
                var old = this.stockRepository.Get(input.Id);
                Mapper.Map(input, old);
                await this.stockRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id){
            this.stockRepository.Delete(id);
        }


        public string ExportExs(){
            var result = stockRepository.GetAllList();
            var dtos   = result.MapTo<List<StockListDto>>();
            return DownloadFileService.Load("Stock.xls", "库存清单.xls", new string[]{ })
                                      .ExcuteXls(dtos.OrderBy(r => r.ProductName).ToList(), this.ExportToXls);
        }

        private WorkbookDesigner ExportToXls(WorkbookDesigner designer, List<StockListDto> list){
            designer.Workbook.Worksheets[0].Name = DateTime.Today.ToString("yy-MM-dd");
            // 设置样式
            var st = new Style{
                Font                = {Size = 10, Name = "宋体"}
              , Pattern             = BackgroundType.Solid
              , HorizontalAlignment = TextAlignmentType.Center
            };
            st.Borders[BorderType.LeftBorder].LineStyle   = CellBorderType.Thin; //应用边界线 左边界线
            st.Borders[BorderType.RightBorder].LineStyle  = CellBorderType.Thin; //应用边界线 右边界线
            st.Borders[BorderType.TopBorder].LineStyle    = CellBorderType.Thin; //应用边界线 上边界线
            st.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin; //应用边界线 下边界线


            var numStart = 2;
            for(var i = 0; i < list.Count; i++){
                var cell0 = designer.Workbook.Worksheets[0].Cells[i+numStart, 0];
                var cell1 = designer.Workbook.Worksheets[0].Cells[i+numStart, 1];
                var cell2 = designer.Workbook.Worksheets[0].Cells[i+numStart, 2];
                var cell3 = designer.Workbook.Worksheets[0].Cells[i+numStart, 3];
                var cell4 = designer.Workbook.Worksheets[0].Cells[i+numStart, 4];
                var cell5 = designer.Workbook.Worksheets[0].Cells[i+numStart, 5];
                var cell6 = designer.Workbook.Worksheets[0].Cells[i+numStart, 6];

                cell0.Value = i+1;
                cell1.Value = list[i].Code;
                cell2.Value = list[i].ProductName;
                cell3.Value = list[i].Specifications;
                cell4.Value = list[i].Unit;
                cell5.Value = list[i].Amount.ToString("N");
                cell6.Value = list[i].StorageName;
                
                cell0.SetStyle(st);
                cell1.SetStyle(st);
                cell2.SetStyle(st);
                cell3.SetStyle(st);
                cell4.SetStyle(st);
                cell5.SetStyle(st);
                cell6.SetStyle(st);
            }

            return designer;
        }
    }
}
