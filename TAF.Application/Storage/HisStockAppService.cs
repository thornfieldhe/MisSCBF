// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HisStockAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   计划任务服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Abp.Domain.Repositories;
using Aspose.Cells;
using SCBF.Common;
using SCBF.Users;

namespace SCBF.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;
    using Abp.UI;
    using SCBF.BaseInfo;
    using SCBF.Storage.Dto;
    using TAF.Utility;

    /// <summary>
    /// 历史库存服务
    /// </summary>
    [AbpAuthorize]
    public class HisStockAppService : TAFAppServiceBase, IHisStockAppService
    {
        private readonly IHisStockRepository hisStockRepository;
        private readonly IStockRepository stockRepository;
        private readonly IDeliveryRepository deliveryRepository;
        private readonly IEntryRepository entryRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;
        private readonly IRepository<User, long> _userRepository;

        public HisStockAppService(
            IHisStockRepository hisStockRepository,
            IStockRepository stockRepository,
            IDeliveryRepository deliveryRepository,
            IEntryRepository entryRepository,
            ISysDictionaryRepository sysDictionaryRepository
          , IRepository<User, long> userRepository)
        {
            this.hisStockRepository = hisStockRepository;
            this.stockRepository = stockRepository;
            this.entryRepository = entryRepository;
            this.deliveryRepository = deliveryRepository;
            this.sysDictionaryRepository = sysDictionaryRepository;
            _userRepository = userRepository;
        }

        public ListResultDto<HisStockListDto> GetAll(HisStockQueryDto request)
        {
            if (request.DateTo.HasValue){
                request.DateTo = request.DateTo.Value.AddDays(1);
            }
            var query1 = this.entryRepository.GetAll()
                .WhereIf(request.Name != null, r => r.Product.Name.Contains(request.Name))
                .WhereIf(request.Code != null, r => r.EntryBill.Code.Contains(request.Code))
                .WhereIf(request.ProductCode != null, r => r.Product.Code.Contains(request.ProductCode))
                .WhereIf(request.DateFrom.HasValue, r => r.CreationTime >= request.DateFrom.Value)
                .WhereIf(request.DateTo.HasValue, r => r.CreationTime <= request.DateTo.Value);

            var list1 = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query1.OrderBy(request.Sorting).MapTo<List<HisStockListDto>>()
                        : query1.OrderBy(r => r.CreationTime).MapTo<List<HisStockListDto>>();

            var query2 = this.deliveryRepository.GetAll()
                .WhereIf(request.Name != null, r => r.Product.Name.Contains(request.Name))
                .WhereIf(request.Code != null, r => r.DeliveryBill.Code.Contains(request.Code))
                .WhereIf(request.DateFrom.HasValue, r => r.CreationTime >= request.DateFrom.Value)
                .WhereIf(request.DateTo.HasValue, r => r.CreationTime <= request.DateTo.Value);

            var list2 = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query2.OrderBy(request.Sorting).MapTo<List<HisStockListDto>>()
                        : query2.OrderBy(r => r.CreationTime).MapTo<List<HisStockListDto>>();
            var count = query1.Count() + query2.Count();
            var list = list1.Union(list2).ToList().AsQueryable().OrderByDescending(r=>r.CreationTime).PageBy(request).ToList();

            var userIds = list.Select(r => r.CreatorUserId.ToLong()).Distinct().ToList();
            var users = _userRepository.GetAllList(r => userIds.Contains(r.Id))
                                       .Select(r => new{r.Id, r.Name}).ToList();
            
            foreach (var l in list){
                l.CreatorUserId = users.First(r => r.Id.ToString() == l.CreatorUserId).Name;
            }
            return new PagedResultDto<HisStockListDto>(count, list);
        }

        public ListResultDto<StockChangeListDto> GetStockChange(DateRangeQueryDto request)
        {
            var query1 = this.hisStockRepository
                .Get(r => r.Date == request.DateFrom.Date)
                .OrderBy(r => r.Date).MapTo<List<StockChangeListDto>>();
            var query2 = this.hisStockRepository
                .Get(r => r.Date == request.DateTo.Date)
                .OrderBy(r => r.Date).MapTo<List<StockChangeListDto>>();
            var list0 = new List<StockChangeListDto>();
            var list1 = new List<StockChangeListDto>();
            var list2 = new List<StockChangeListDto>();
            var ids = query1.Select(r => r.Id).Union(query2.Select(r => r.Id)).Distinct().ToList();
            foreach (var id in ids)
            {
                var item1 = query1.Where(r => r.Id == id).ToList();
                var item2 = query2.Where(r => r.Id == id).ToList();
                if (item1.Count > 0)
                {
                    list0.Add(new StockChangeListDto()
                    {
                        Amount = item1.Sum(r => r.Amount),
                        Code = item1[0].Code,
                        Id = item1[0].Id,
                        ProductName = item1[0].ProductName,
                        Specifications = item1[0].Specifications,
                        StorageName = item1[0].StorageName
                    });
                }
                else
                {
                    list0.Add(new StockChangeListDto()
                    {
                        Amount = 0,
                        Code = item2[0].Code,
                        Id = item2[0].Id,
                        ProductName = item2[0].ProductName,
                        Specifications = item2[0].Specifications,
                        StorageName = item2[0].StorageName
                    });
                }

                if (item2.Count > 0)
                {
                    list1.Add(new StockChangeListDto()
                    {
                        Amount = item2.Sum(r => r.Amount),
                        Code = item2[0].Code,
                        Id = item2[0].Id,
                        ProductName = item2[0].ProductName,
                        Specifications = item2[0].Specifications,
                        StorageName = item2[0].StorageName
                    });
                }
                else
                {
                    list1.Add(new StockChangeListDto()
                    {
                        Amount = 0,
                        Code = item1[0].Code,
                        Id = item1[0].Id,
                        ProductName = item1[0].ProductName,
                        Specifications = item1[0].Specifications,
                        StorageName = item1[0].StorageName
                    });
                }
            }

            foreach (var item in list1)
            {
                list2.Add(new StockChangeListDto()
                {
                    Amount = item.Amount - list0.Find(r => r.Id == item.Id).Amount,
                    Code = item.Code,
                    Id = item.Id,
                    ProductName = item.ProductName,
                    Specifications = item.Specifications,
                    StorageName = item.StorageName
                });
            }

            var count = list2.Count;
            var list = list2.AsQueryable().PageBy(request).ToList();

            return new PagedResultDto<StockChangeListDto>(count, list);
        }

        public List<HisStockReportListDto> GetHistory(int quarter)
        {
            var defaultYear =
                   this.sysDictionaryRepository.FirstOrDefault(
                       r => r.Category == DictionaryCategory.Material_Year && r.Value4 == true.ToString());
            if (defaultYear == null)
            {
                throw new UserFriendlyException("会计年度不存在");
            }
            var year = defaultYear.Value.ToInt();
            var dtFrom = new DateTime(year, 1, 1);
            var dtTo = new DateTime(year, 3, 31);

            switch (quarter)
            {
                case 0:
                    dtTo = new DateTime(year,3 , 31);
                    break;
                case 1:
                    dtTo = new DateTime(year, 6, 30);
                    break;
                case 2:
                    dtTo = new DateTime(year, 9, 30);
                    break;
                case 3:
                    dtTo = new DateTime(year, 12, 31);
                    break;
            }

            var initialDate = dtFrom.AddDays(-1);
            var endDate = dtTo.AddDays(1);
            var initialNumbers = this.hisStockRepository.Get(r => r.Date == initialDate).MapTo<List<HisStockReportListDto>>();
            var addNumbers = this.deliveryRepository.Get(r => r.CreationTime >= dtFrom && r.CreationTime < endDate).MapTo<List<HisStockReportListDto>>();
            var reduceNumbers = this.entryRepository.Get(r => r.CreationTime >= dtFrom && r.CreationTime < endDate).MapTo<List<HisStockReportListDto>>();
            var endNumbers = this.hisStockRepository.Get(r => r.Date == dtTo).MapTo<List<HisStockReportListDto>>();
            endNumbers.ForEach(
                item =>
                    {
                        item.Price3 = item.Price1;
                        item.Amount3 = item.Amount1;
                        item.Total3 = item.Total1;
                        item.Price1 = string.Empty;
                        item.Amount1 = string.Empty;
                        item.Total1 = string.Empty;
                    });
            var result = new List<HisStockReportListDto>();
            result.AddRange(initialNumbers);
            result.AddRange(addNumbers);
            result.AddRange(reduceNumbers);
            result.AddRange(endNumbers);
            return result.OrderBy(r => r.Date).ToList();
        }

        /// <summary>
        /// 备份所有库存>0的库存量
        /// </summary>
        [AbpAllowAnonymous]
        public void BackupData()
        {
            var stocks =
                this.stockRepository.Get(
                        r => r.Amount != 0)
                    .ToList()
                    .MapTo<List<HisStock>>();
            foreach (var hisStock in stocks)
            {
                hisStock.Id = Guid.NewGuid();
            }
            this.hisStockRepository.InsertRange(stocks);
        }
        
        private List<HisStockListDto> LoadData(DateTime dateFrom, DateTime dataTo){
            dataTo = dataTo.AddDays(1);
            var list1 = entryRepository.GetAllList(r => r.CreationTime >= dateFrom
                                                     && r.CreationTime <= dataTo).MapTo<List<HisStockListDto>>();
            var list2 = deliveryRepository.GetAllList(r => r.CreationTime >= dateFrom
                                                        && r.CreationTime <= dataTo).MapTo<List<HisStockListDto>>();

            var list = list1.Union(list2).ToList().AsQueryable().OrderByDescending(r=>r.CreationTime).ToList();

            var userIds = list.Select(r => r.CreatorUserId.ToLong()).Distinct().ToList();
            var users = _userRepository.GetAllList(r => userIds.Contains(r.Id))
                                       .Select(r => new{r.Id, r.Name}).ToList();
            
            foreach (var l in list){
                l.CreatorUserId = users.First(r => r.Id.ToString() == l.CreatorUserId).Name;
            }
            return list; 
        }
        
        public string ExportExs(DateTime dateFrom,DateTime dataTo){
            var result = LoadData(dateFrom,dataTo);
            var dtos   = result.MapTo<List<HisStockListDto>>();
            return DownloadFileService.Load("HisStock.xls", "出入库记录.xls", new string[]{ })
                                      .ExcuteXls(dtos.OrderBy(r => r.ProductName).ToList(), this.ExportToXls);
        }

        private WorkbookDesigner ExportToXls(WorkbookDesigner designer, List<HisStockListDto> list){
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
                var cell7 = designer.Workbook.Worksheets[0].Cells[i+numStart, 7];
                var cell8 = designer.Workbook.Worksheets[0].Cells[i+numStart, 8];

                cell0.Value = i+1;
                cell1.Value = list[i].Date;
                cell2.Value = list[i].Code;
                cell3.Value = list[i].ProductCode;
                cell4.Value = list[i].ProductName;
                cell5.Value = list[i].Specifications;
                cell6.Value = list[i].Unit;
                cell7.Value = list[i].Amount.ToString("N");
                cell8.Value = list[i].CreatorUserId;
                
                cell0.SetStyle(st);
                cell1.SetStyle(st);
                cell2.SetStyle(st);
                cell3.SetStyle(st);
                cell4.SetStyle(st);
                cell5.SetStyle(st);
                cell6.SetStyle(st);
                cell7.SetStyle(st);
                cell8.SetStyle(st);
            }

            return designer;
        }
    }
}