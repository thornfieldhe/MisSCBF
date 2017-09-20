using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace SCBF
{

    using System;
    using System.Linq;
    using Abp.Quartz.Quartz;
    using Microsoft.AspNet.Identity;
    using Quartz;
    using SCBF.BaseInfo;
    using SCBF.BaseInfo.Dto;
    using SCBF.Car;
    using SCBF.Car.Dto;
    using SCBF.Finance;
    using SCBF.Finance.Dto;
    using SCBF.Purchase;
    using SCBF.Purchase.Dto;
    using SCBF.Storage;
    using SCBF.Storage.Dto;
    using SCBF.Tasks;
    using SCBF.Users;
    using SCBF.Users.Dto;

    [DependsOn(typeof(TAFCoreModule), typeof(AbpAutoMapperModule), typeof(AbpQuartzModule))]
    public class TAFApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...

                #region 用户模块

                mapper.CreateMap<User, UserListDto>().ForMember(m => m.Roles, n => n.Ignore());
                mapper.CreateMap<User, UserEditDto>().ForMember(m => m.Roles, n => n.Ignore());
                mapper.CreateMap<UserEditDto, User>()
                    .ForMember(m => m.Roles, n => n.Ignore())
                    .ForMember(m => m.Surname, n => n.MapFrom(r => r.Name))
                    .ForMember(m => m.IsEmailConfirmed, n => n.MapFrom(r => true))
                    .ForMember(m => m.IsActive, n => n.MapFrom(r => true))
                    .ForMember(m => m.EmailAddress, n => n.MapFrom(r => $"{r.UserName}@taf.com"))
                    .ForMember(m => m.Password, n => n.MapFrom(r => new PasswordHasher().HashPassword("11111111")));


                #endregion

                #region 基础信息

                mapper.CreateMap<Layer, LayerListDto>();
                mapper.CreateMap<Layer, LayerEditDto>()
                    .ForMember(m => m.Code, n => n.MapFrom(r => r.LevelCode));
                mapper.CreateMap<LayerEditDto, Layer>()
                    .ForMember(m => m.LevelCode, n => n.MapFrom(r => r.Code));
                mapper.CreateMap<SysDictionary, SysDictionaryListDto>();
                mapper.CreateMap<SysDictionary, SysDictionaryEditDto>();


                #endregion


                #region 物资模块

                mapper.CreateMap<Product, ProductListDto>();
                mapper.CreateMap<Product, ProductEditDto>();
                mapper.CreateMap<ProductEditDto, Product>();

                mapper.CreateMap<Product, ProductStockListDto>()
                    .ForMember(m => m.ProductId, n => n.MapFrom(r => r.Id));
                mapper.CreateMap<Stock, ProductStockListDto>()
                    .ForMember(m => m.Code, n => n.MapFrom(r => r.Product.Code))
                    .ForMember(m => m.Name, n => n.MapFrom(r => r.Product.Name))
                    .ForMember(m => m.Specifications, n => n.MapFrom(r => r.Product.Specifications))
                    .ForMember(m => m.Unit, n => n.MapFrom(r => r.Product.Unit))
                    .ForMember(m => m.Amount, n => n.MapFrom(r => 1))
                    .ForMember(m => m.StorageName, n => n.MapFrom(r => r.Storage.Value));

                mapper.CreateMap<Stock, StockListDto>()
                    .ForMember(m => m.Specifications, n => n.MapFrom(r => r.Product.Specifications))
                    .ForMember(m => m.ProductName, n => n.MapFrom(r => r.Product.Name))
                    .ForMember(m => m.Code, n => n.MapFrom(r => r.Product.Code))
                    .ForMember(m => m.Unit, n => n.MapFrom(r => r.Product.Unit))
                    .ForMember(m => m.Total, n => n.MapFrom(r => r.Amount * r.Price))
                    .ForMember(m => m.StorageName, n => n.MapFrom(r => r.Storage.Value));

                mapper.CreateMap<HisStock, StockChangeListDto>()
                    .ForMember(m => m.Specifications, n => n.MapFrom(r => r.Product.Specifications))
                    .ForMember(m => m.ProductName, n => n.MapFrom(r => r.Product.Name))
                    .ForMember(m => m.Id, n => n.MapFrom(r => r.Product.Id))
                    .ForMember(m => m.Code, n => n.MapFrom(r => r.Product.Code))
                    .ForMember(m => m.Unit, n => n.MapFrom(r => r.Product.Unit))
                    .ForMember(m => m.StorageName, n => n.MapFrom(r => r.Storage.Value));

                mapper.CreateMap<StockBillEditDto, EntryBill>()
                    .ForMember(m => m.Entries, n => n.MapFrom(r => r.Items));
                mapper.CreateMap<ProductStockListDto, Entry>();
                mapper.CreateMap<Entry, ProductStockListDto>()
                    .ForMember(m => m.Name, n => n.MapFrom(r => r.Product.Name))
                    .ForMember(m => m.Unit, n => n.MapFrom(r => r.Product.Unit))
                    .ForMember(m => m.StorageName, n => n.MapFrom(r => r.Storage.Value))
                    .ForMember(m => m.Code, n => n.MapFrom(r => r.Product.Code))
                    .ForMember(m => m.Specifications, n => n.MapFrom(r => r.Product.Specifications));

                mapper.CreateMap<StockBillEditDto, DeliveryBill>()
                    .ForMember(m => m.Deliveries, n => n.MapFrom(r => r.Items));
                mapper.CreateMap<ProductStockListDto, Delivery>();
                mapper.CreateMap<Delivery, ProductStockListDto>()
                    .ForMember(m => m.Name, n => n.MapFrom(r => r.Product.Name))
                    .ForMember(m => m.Unit, n => n.MapFrom(r => r.Product.Unit))
                    .ForMember(m => m.StorageName, n => n.MapFrom(r => r.Storage.Value))
                    .ForMember(m => m.Specifications, n => n.MapFrom(r => r.Product.Specifications))
                    .ForMember(m => m.Code, n => n.MapFrom(r => r.Product.Code));

                mapper.CreateMap<Stock, HisStock>()
                .ForMember(m => m.CreationTime, n => n.MapFrom(r => DateTime.Today))
                .ForMember(m => m.LastModificationTime, n => n.Ignore())
                .ForMember(m => m.Date, n => n.MapFrom(r => DateTime.Today.AddDays(-1)));

                mapper.CreateMap<HisStock, HisStockReportListDto>()
                .ForMember(m => m.Category, n => n.MapFrom(r => HisStoreReportCategory.Add))
                .ForMember(m => m.ProductName, n => n.MapFrom(r => r.Product.Name))
                .ForMember(m => m.Amount1, n => n.MapFrom(r => r.Amount.ToString()))
                .ForMember(m => m.Price1, n => n.MapFrom(r => r.Price.ToString()))
                .ForMember(m => m.Total1, n => n.MapFrom(r => (r.Amount * r.Price).ToString("0.00")))
                .ForMember(m => m.Specifications, n => n.MapFrom(r => r.Product.Specifications))
                .ForMember(m => m.ProductId, n => n.MapFrom(r => r.ProductId))
                .ForMember(m => m.StorageName, n => n.MapFrom(r => r.Storage.Value))
                .ForMember(m => m.Date, n => n.MapFrom(r => r.Date.ToString("yyyy-MM-dd")))
                .ForMember(m => m.Unit, n => n.MapFrom(r => r.Product.Unit));

                mapper.CreateMap<Entry, HisStockReportListDto>()
                    .ForMember(m => m.Category, n => n.MapFrom(r => HisStoreReportCategory.Add))
                    .ForMember(m => m.ProductName, n => n.MapFrom(r => r.Product.Name))
                    .ForMember(m => m.Amount2, n => n.MapFrom(r => r.Amount.ToString()))
                    .ForMember(m => m.Price2, n => n.MapFrom(r => r.Price.ToString()))
                    .ForMember(m => m.Total2, n => n.MapFrom(r => (r.Amount * r.Price).ToString("0.00")))
                    .ForMember(m => m.Specifications, n => n.MapFrom(r => r.Product.Specifications))
                    .ForMember(m => m.ProductId, n => n.MapFrom(r => r.ProductId))
                    .ForMember(m => m.StorageName, n => n.MapFrom(r => r.Storage.Value))
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.CreationTime.ToString("yyyy-MM-dd")))
                    .ForMember(m => m.Unit, n => n.MapFrom(r => r.Product.Unit));


                mapper.CreateMap<Delivery, HisStockReportListDto>()
                    .ForMember(m => m.Category, n => n.MapFrom(r => HisStoreReportCategory.Reduce))
                    .ForMember(m => m.ProductName, n => n.MapFrom(r => r.Product.Name))
                    .ForMember(m => m.Amount4, n => n.MapFrom(r => r.Amount.ToString()))
                    .ForMember(m => m.Price4, n => n.MapFrom(r => (r.Price * -1).ToString()))
                    .ForMember(m => m.Total4, n => n.MapFrom(r => (r.Amount * r.Price * -1).ToString("0.00")))
                    .ForMember(m => m.Specifications, n => n.MapFrom(r => r.Product.Specifications))
                    .ForMember(m => m.ProductId, n => n.MapFrom(r => r.ProductId))
                    .ForMember(m => m.StorageName, n => n.MapFrom(r => r.Storage.Value))
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.CreationTime.ToString("yyyy-MM-dd")))
                    .ForMember(m => m.Unit, n => n.MapFrom(r => r.Product.Unit));

                mapper.CreateMap<Entry, HisStockListDto>()
                    .ForMember(m => m.Category, n => n.MapFrom(r => HisStoreReportCategory.Add))
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.CreationTime.ToString("yyyy-MM-dd")))
                    .ForMember(m => m.ProductName, n => n.MapFrom(r => r.Product.Name))
                    .ForMember(m => m.Code, n => n.MapFrom(r => r.EntryBill.Code))
                    .ForMember(m => m.ProductCode, n => n.MapFrom(r => r.Product.Code))
                    .ForMember(m => m.Specifications, n => n.MapFrom(r => r.Product.Specifications))
                    .ForMember(m => m.Total, n => n.MapFrom(r => (r.Amount * r.Price).ToString("0.00")))
                    .ForMember(m => m.StorageName, n => n.MapFrom(r => r.Storage.Value));

                mapper.CreateMap<Delivery, HisStockListDto>()
                    .ForMember(m => m.Category, n => n.MapFrom(r => HisStoreReportCategory.Reduce))
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.CreationTime.ToString("yyyy-MM-dd")))
                    .ForMember(m => m.ProductName, n => n.MapFrom(r => r.Product.Name))
                    .ForMember(m => m.Code, n => n.MapFrom(r => r.DeliveryBill.Code))
                    .ForMember(m => m.ProductCode, n => n.MapFrom(r => r.Product.Code))
                     .ForMember(m => m.Specifications, n => n.MapFrom(r => r.Product.Specifications))
                     .ForMember(m => m.Price, n => n.MapFrom(r => r.Price * -1))
                    .ForMember(m => m.Total, n => n.MapFrom(r => (r.Amount * r.Price * -1).ToString("0.00")))
                    .ForMember(m => m.StorageName, n => n.MapFrom(r => r.Storage.Value));

                mapper.CreateMap<Check, CheckListDto>()
                .ForMember(m => m.Code, n => n.MapFrom(r => r.CheckBill.Code))
                .ForMember(m => m.ProductCode, n => n.MapFrom(r => r.Product.Code))
                .ForMember(m => m.Unit, n => n.MapFrom(r => r.Product.Unit))
                .ForMember(m => m.Specifications, n => n.MapFrom(r => r.Product.Specifications))
                .ForMember(m => m.ChangedAmount, n => n.MapFrom(r => r.Amount - r.StockAmount));
                mapper.CreateMap<Check, CheckEditDto>()
                .ForMember(m => m.Code, n => n.MapFrom(r => r.CheckBill.Code))
                .ForMember(m => m.ProductCode, n => n.MapFrom(r => r.Product.Code))
                .ForMember(m => m.Unit, n => n.MapFrom(r => r.Product.Unit))
                .ForMember(m => m.Specifications, n => n.MapFrom(r => r.Product.Specifications))
                .ForMember(m => m.ChangedAmount, n => n.MapFrom(r => r.Amount - r.StockAmount));

                #endregion

                #region 预算模块

                mapper.CreateMap<BudgetReceipt, BudgetReceiptListDto>()
                    .ForMember(m => m.Total1, n => n.MapFrom(r => r.Column1 + r.Column21 + r.Column22))
                    .ForMember(m => m.Total3, n => n.MapFrom(r => r.Column31 + r.Column32 + r.Column33 + r.Column34 + r.Column35 + r.Column36 + r.Column37))
                    .ForMember(
                        m => m.Total4,
                        n => n.MapFrom(
                            r => r.Column41 + r.Column42 + r.Column43 + r.Column44 + r.Column45 + r.Column46
                                 + r.Column47)).ForMember(
                        m => m.Total,
                        n => n.MapFrom(
                            r => r.Column1 + r.Column21 + r.Column22 + r.Column31 + r.Column32 + r.Column33 + r.Column34
                                 + r.Column35 + r.Column36 + r.Column37 + r.Column41 + r.Column42 + r.Column43 + r.Column44 + r.Column45 + r.Column46 + r.Column47
                                                                 + r.Column5));

                mapper.CreateMap<BudgetOutlay, BudgetOutlaySimpleListDto>()
                    .ForMember(m => m.Total, n => n.MapFrom(r => r.Amount * r.Price));

                mapper.CreateMap<BudgetOutlay, BudgetOutlayListDto>()
                    .ForMember(m => m.Total1, n => n.MapFrom(r => r.Column1 + r.Column2 + r.Column3))
                    .ForMember(m => m.Total2, n => n.MapFrom(r => r.Column1 + r.Column2));

                mapper.CreateMap<BudgetOutlay, OutlayListDto>()
                    .ForMember(m => m.Total1, n => n.MapFrom(r => r.Column1 + r.Column2 + r.Column3))
                    .ForMember(m => m.Total3, n => n.MapFrom(r => r.Column1 + r.Column2))
                    .ForMember(m => m.Total2, n => n.MapFrom(r => r.Column1 + r.Column2 + r.Column3))
                    .ForMember(m => m.Total4, n => n.MapFrom(r => decimal.Round(r.ActualOutlays.Sum(o => o.Amount) / 10000, 2, MidpointRounding.AwayFromZero)))
                    .ForMember(m => m.Surplus, n => n.MapFrom(r => r.Column1 + r.Column2 + r.Column3 - decimal.Round(r.ActualOutlays.Sum(o => o.Amount) / 10000, 2, MidpointRounding.AwayFromZero)));

                mapper.CreateMap<ActualOutlay, ActualOutlayListDto>()
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.Date.ToString("yyyy-MM-dd HH:MM")));

                mapper.CreateMap<VoucherAudit, VoucherAuditListDto>()
                    .ForMember(m => m.Point1, n => n.MapFrom(r => r.Point1 == 0 ? "是" : (r.Point1 == 1 ? "否" : "无此情况")))
                    .ForMember(m => m.Point2, n => n.MapFrom(r => r.Point2 == 0 ? "是" : (r.Point2 == 1 ? "否" : "无此情况")))
                    .ForMember(m => m.Point3, n => n.MapFrom(r => r.Point3 == 0 ? "是" : (r.Point3 == 1 ? "否" : "无此情况")))
                    .ForMember(m => m.Point4, n => n.MapFrom(r => r.Point4 == 0 ? "是" : (r.Point4 == 1 ? "否" : "无此情况")))
                    .ForMember(m => m.Point5, n => n.MapFrom(r => r.Point5 == 0 ? "是" : (r.Point5 == 1 ? "否" : "无此情况")))
                    .ForMember(m => m.Point6, n => n.MapFrom(r => r.Point6 == 0 ? "是" : (r.Point6 == 1 ? "否" : "无此情况")))
                    .ForMember(m => m.Point7, n => n.MapFrom(r => r.Point7 == 0 ? "是" : (r.Point7 == 1 ? "否" : "无此情况")))
                    .ForMember(m => m.Point8, n => n.MapFrom(r => r.Point8 == 0 ? "是" : (r.Point8 == 1 ? "否" : "无此情况")))
                    .ForMember(m => m.Point9, n => n.MapFrom(r => r.Point9 == 0 ? "是" : (r.Point9 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point10,
                        n => n.MapFrom(r => r.Point10 == 0 ? "是" : (r.Point10 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point11,
                        n => n.MapFrom(r => r.Point11 == 0 ? "是" : (r.Point11 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point12,
                        n => n.MapFrom(r => r.Point12 == 0 ? "是" : (r.Point12 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point13,
                        n => n.MapFrom(r => r.Point13 == 0 ? "是" : (r.Point13 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point14,
                        n => n.MapFrom(r => r.Point14 == 0 ? "是" : (r.Point14 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point15,
                        n => n.MapFrom(r => r.Point15 == 0 ? "是" : (r.Point15 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point16,
                        n => n.MapFrom(r => r.Point16 == 0 ? "是" : (r.Point16 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point17,
                        n => n.MapFrom(r => r.Point17 == 0 ? "是" : (r.Point17 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point18,
                        n => n.MapFrom(r => r.Point18 == 0 ? "是" : (r.Point18 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point19,
                        n => n.MapFrom(r => r.Point19 == 0 ? "是" : (r.Point19 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point20,
                        n => n.MapFrom(r => r.Point20 == 0 ? "是" : (r.Point20 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point21,
                        n => n.MapFrom(r => r.Point21 == 0 ? "是" : (r.Point21 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point22,
                        n => n.MapFrom(r => r.Point22 == 0 ? "是" : (r.Point22 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point23,
                        n => n.MapFrom(r => r.Point23 == 0 ? "是" : (r.Point23 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point24,
                        n => n.MapFrom(r => r.Point24 == 0 ? "是" : (r.Point24 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point25,
                        n => n.MapFrom(r => r.Point25 == 0 ? "是" : (r.Point25 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point26,
                        n => n.MapFrom(r => r.Point26 == 0 ? "是" : (r.Point26 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point27,
                        n => n.MapFrom(r => r.Point27 == 0 ? "是" : (r.Point27 == 1 ? "否" : "无此情况")))
                    .ForMember(
                        m => m.Point28,
                        n => n.MapFrom(r => r.Point28 == 0 ? "是" : (r.Point28 == 1 ? "否" : "无此情况"))).ForMember(
                        m => m.Point29,
                        n => n.MapFrom(r => r.Point29 == 0 ? "是" : (r.Point29 == 1 ? "否" : "无此情况"))).ForMember(
                        m => m.Point30,
                        n => n.MapFrom(r => r.Point30 == 0 ? "是" : (r.Point30 == 1 ? "否" : "无此情况")));


                mapper.CreateMap<InvoiceCheck, InvoiceCheckListDto>()
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.CreationTime.ToString("yyyy-MM-dd")));



                mapper.CreateMap<PlanWithBudgetOutlay, PlanWithBudgetOutlayListDto>()
                    .ForMember(m => m.Name, n => n.MapFrom(r => r.BudgetOutlay.Name))
                    .ForMember(m => m.Unit, n => n.MapFrom(r => r.BudgetOutlay.Unit))
                    .ForMember(m => m.Amount, n => n.MapFrom(r => r.BudgetOutlay.Amount))
                    .ForMember(m => m.Price, n => n.MapFrom(r => r.BudgetOutlay.Price));

                mapper.CreateMap<BudgetOutlay, PlanWithBudgetOutlayListDto>();

                #endregion

                #region 车辆模块

                mapper.CreateMap<Driver, DriverListDto>()
                    .ForMember(m => m.ValidDrivingLicense, n => n.MapFrom(r => r.ValidDrivingLicense.ToString("yyyy-MM-dd")))
                    .ForMember(m => m.Level, n => n.MapFrom(r => r.Level.Value));
                mapper.CreateMap<Driver, DriverEditDto>()
                    .ForMember(m => m.ValidDrivingLicense, n => n.MapFrom(r => r.ValidDrivingLicense.ToString("yyyy-MM-dd")))
                    .ForMember(m => m.Level, n => n.MapFrom(r => r.LevelId));
                mapper.CreateMap<DriverEditDto, Driver>()
                .ForMember(m => m.Level, n => n.Ignore())
                .ForMember(m => m.LevelId, n => n.MapFrom(r => r.Level));

                mapper.CreateMap<CarInfo, CarInfoListDto>()
                    .ForMember(m => m.Zbsj, n => n.MapFrom(r => r.Zbsj.ToString("yyyy-MM-dd")))
                    .ForMember(m => m.Clzk, n => n.MapFrom(r => r.Clzk.Value))
                    .ForMember(m => m.Driver, n => n.MapFrom(r => r.Driver.Name));
                mapper.CreateMap<CarInfo, CarInfoEditDto>()
                    .ForMember(m => m.Zbsj, n => n.MapFrom(r => r.Zbsj.ToString("yyyy-MM-dd")))
                    .ForMember(m => m.Clzk, n => n.MapFrom(r => r.ClzkId))
                    .ForMember(m => m.Driver, n => n.MapFrom(r => r.DriverId));
                mapper.CreateMap<CarInfoEditDto, CarInfo>()
                    .ForMember(m => m.ClzkId, n => n.MapFrom(r => r.Clzk))
                    .ForMember(m => m.Clzk, n => n.Ignore())
                    .ForMember(m => m.DriverId, n => n.MapFrom(r => r.Driver))
                    .ForMember(m => m.Driver, n => n.Ignore());

                mapper.CreateMap<OilCard, OilCardListDto>()
                    .ForMember(m => m.CarInfoName, n => n.MapFrom(r => r.CarInfo.Cph));

                mapper.CreateMap<UploadOilCardRoof, UploadOilCarRoofListDto>()
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.Date.ToString("yyyy-MM-dd")));

                mapper.CreateMap<RechargeRecord, RechargeRecordListDto>()
                    .ForMember(m => m.OilCardName, n => n.MapFrom(r => r.OilCard.Code))
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.Date.ToString("yyyy-MM-dd")));
                mapper.CreateMap<RechargeRecord, RechargeRecordEditDto>()
                    .ForMember(m => m.HisAmount, n => n.MapFrom(r => r.OilCard.Amount));
                mapper.CreateMap<RechargeRecordEditDto, RechargeRecord>()
                    .ForMember(m => m.Date, n => n.MapFrom(r => DateTime.Today));

                mapper.CreateMap<ApplicationForBunkerA, ApplicationForBunkerAListDto>()
                    .ForMember(m => m.OilCardName, n => n.MapFrom(r => r.OilCard.Code))
                    .ForMember(m => m.DriverName, n => n.MapFrom(r => r.Driver.Name))
                    .ForMember(m => m.AuditorName, n => n.MapFrom(r => r.AuditorId.HasValue ? r.Auditor.Value : string.Empty))
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.Date.ToString("yyyy-MM-dd")));
                mapper.CreateMap<ApplicationForBunkerA, ApplicationForBunkerAEditDto>()
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.Date.ToString("yyyy-MM-dd")))
                    .ForMember(m => m.DriverName, n => n.MapFrom(r => r.DriverId.HasValue ? r.Driver.Name : string.Empty))
                    .ForMember(m => m.OilCardCode, n => n.MapFrom(r => r.OilCard.Code));
                mapper.CreateMap<ApplicationForBunkerAEditDto, ApplicationForBunkerA>();


                mapper.CreateMap<ApplicationForBunkerB, ApplicationForBunkerBListDto>()
                    .ForMember(m => m.DriverName, n => n.MapFrom(r => r.Driver.Name))
                    .ForMember(m => m.CarCode, n => n.MapFrom(r => r.CarInfo.Cph))
                    .ForMember(m => m.CarSpecifications, n => n.MapFrom(r => r.CarInfo.Clxh))
                    .ForMember(m => m.AuditorName, n => n.MapFrom(r => r.AuditorId.HasValue ? r.Auditor.Value : string.Empty))
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.Date.ToString("yyyy-MM-dd")));
                mapper.CreateMap<ApplicationForBunkerB, ApplicationForBunkerBEditDto>()
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.Date.ToString("yyyy-MM-dd")))
                    .ForMember(m => m.CarCode, n => n.MapFrom(r => r.CarInfo.Cph))
                    .ForMember(m => m.CarSpecifications, n => n.MapFrom(r => r.CarInfo.Clxh))
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.Date.ToString("yyyy-MM-dd")))
                    .ForMember(m => m.DriverName, n => n.MapFrom(r => r.DriverId.HasValue ? r.Driver.Name : string.Empty));
                mapper.CreateMap<ApplicationForBunkerBEditDto, ApplicationForBunkerB>();

                mapper.CreateMap<ApplyForVehicleMaintenance, ApplyForVehicleMaintenanceListDto>()
                    .ForMember(m => m.Clxh, n => n.MapFrom(r => r.CarInfo.Clxh))
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.CreationTime.ToString("yyyy-MM-dd")))
                    .ForMember(m => m.Cph, n => n.MapFrom(r => r.CarInfo.Cph));
                mapper.CreateMap<ApplyForVehicleMaintenance, ApplyForVehicleMaintenanceEditDto>()
                    .ForMember(m => m.Clxh, n => n.MapFrom(r => r.CarInfo.Clxh))
                    .ForMember(m => m.Cph, n => n.MapFrom(r => r.CarInfo.Cph));
                mapper.CreateMap<ApplyForVehicleMaintenanceEditDto, ApplyForVehicleMaintenance>();

                mapper.CreateMap<MaintenanceDeliveryListDto, MaintenanceDelivery>()
                .ForMember(m => m.Id, n => n.MapFrom(r => Guid.NewGuid()))
                .ForMember(m => m.DeliveryId, n => n.MapFrom(r => r.Id));

                mapper.CreateMap<ManHourListDto, ManHour>()
                .ForMember(m => m.Id, n => n.MapFrom(r => Guid.NewGuid()));

                mapper.CreateMap<ServicingMaterialListDto, ServicingMaterial>()
                .ForMember(m => m.Id, n => n.MapFrom(r => Guid.NewGuid()));

                mapper.CreateMap<ApplyForVehicleMaintenance, ApplyForVehicleMaintenanceUpdateDto>()
                .ForMember(m => m.Id, n => n.MapFrom(r => Guid.NewGuid()));

                mapper.CreateMap<MaintenanceDelivery, MaintenanceDeliveryListDto>()
                    .ForMember(m => m.Id, n => n.MapFrom(r => r.DeliveryId));

                mapper.CreateMap<ManHour, ManHourListDto>()
                    .ForMember(m => m.RowId, n => n.MapFrom(r => r.Id));

                mapper.CreateMap<ServicingMaterial, ServicingMaterialListDto>()
                    .ForMember(m => m.RowId, n => n.MapFrom(r => r.Id));

                mapper.CreateMap<ApplyForVehicleMaintenance, ApplyForVehicleMaintenanceUpdateDto>()
                    .ForMember(m => m.ManHour, n => n.MapFrom(r => r.ManHours))
                    .ForMember(m => m.Deliveries, n => n.MapFrom(r => r.MaintenanceDeliveries))
                    .ForMember(m => m.Materials, n => n.MapFrom(r => r.ServicingMaterials));

                mapper.CreateMap<CarOil, CarOilListDto>()
                    .ForMember(m => m.CarInfoName, n => n.MapFrom(r => r.CarInfo.Cph));
                mapper.CreateMap<CarOil, CarOilEditDto>();
                mapper.CreateMap<CarOilEditDto, CarOil>();

                #endregion
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// The post initialize.
        /// </summary>
        /// <suMMary>
        /// 初始化模块时启动任务
        /// </suMMary>
        public override void PostInitialize()
        {
            base.PostInitialize();
            var jobManager = this.IocManager.IocContainer.Resolve<IQuartzScheduleJobManager>();
            jobManager.ScheduleAsync<Yearly>(
                job =>
                {
                    job.WithIdentity(nameof(Yearly), "MyGroup");
                },
                trigger =>
                {
                    trigger.WithIdentity(nameof(Yearly), "MyGroup").WithSchedule(CronScheduleBuilder.CronSchedule(Yearly.Schedule)).Build();

                });

            jobManager.ScheduleAsync<DailyTask>(
                job =>
                {
                    job.WithIdentity(nameof(DailyTask), "MyGroup");
                },
                trigger =>
                {
                    trigger.WithIdentity(nameof(DailyTask), "MyGroup").WithSchedule(CronScheduleBuilder.CronSchedule(DailyTask.Schedule)).Build();

                });

            jobManager.ScheduleAsync<MonthlyTask>(
                job =>
                {
                    job.WithIdentity(nameof(MonthlyTask), "MyGroup");
                },
                trigger =>
                {
                    trigger.WithIdentity(nameof(MonthlyTask), "MyGroup").WithSchedule(CronScheduleBuilder.CronSchedule(MonthlyTask.Schedule)).Build();

                });
        }
    }
}
