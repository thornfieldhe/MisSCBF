using Abp.AutoMapper;
using Abp.Modules;
using System.Reflection;

namespace SCBF
{

    using Microsoft.AspNet.Identity;

    using SCBF.BaseInfo;
    using SCBF.BaseInfo.Dto;
    using SCBF.Finance;
    using SCBF.Finance.Dto;
    using SCBF.Storage;
    using SCBF.Storage.Dto;
    using SCBF.Users;
    using SCBF.Users.Dto;
    using System;
    using System.Linq;

    using Abp.Quartz.Quartz;

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

                mapper.CreateMap<ScheduledTask, ScheduledTaskListDto>()
        .ForMember(m => m.Started, n => n.MapFrom(r => r.Started ? "Y" : "N"));


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

                #endregion

                #region 预算模块

                mapper.CreateMap<BudgetReceipt, BudgetReceiptListDto>()
                    .ForMember(m => m.Total1, n => n.MapFrom(r => r.Column1 + r.Column21 + r.Column22))
                    .ForMember(m => m.Total3, n => n.MapFrom(r => r.Column31 + r.Column32 + r.Column33 + r.Column34 + r.Column35 + r.Column36 + r.Column37))
                    .ForMember(m => m.Total4, n => n.MapFrom(r => r.Column41 + r.Column42 + r.Column43 + r.Column44 + r.Column45 + r.Column46 + r.Column47))
                    .ForMember(m => m.Total, n => n.MapFrom(r => r.Column1 + r.Column21 + r.Column22
                                                                 + r.Column31 + r.Column32 + r.Column33 + r.Column34 + r.Column35 + r.Column36 + r.Column37
                                                                 + r.Column41 + r.Column42 + r.Column43 + r.Column44 + r.Column45 + r.Column46 + r.Column47
                                                                 + r.Column5));

                mapper.CreateMap<BudgetOutlay, BudgetOutlaySimpleListDto>()
                    .ForMember(m => m.Total, n => n.MapFrom(r => r.Amount * r.Price));

                mapper.CreateMap<BudgetOutlay, BudgetOutlayListDto>()
                    .ForMember(m => m.Total1, n => n.MapFrom(r => r.Amount * r.Price))
                    .ForMember(m => m.Total3, n => n.MapFrom(r => r.Column1 + r.Column2))
                    .ForMember(m => m.Total2, n => n.MapFrom(r => r.Column1 + r.Column2 + r.Column3));

                mapper.CreateMap<BudgetOutlay, OutlayListDto>()
                    .ForMember(m => m.Total1, n => n.MapFrom(r => r.Amount * r.Price))
                    .ForMember(m => m.Total3, n => n.MapFrom(r => r.Column1 + r.Column2))
                    .ForMember(m => m.Total2, n => n.MapFrom(r => r.Column1 + r.Column2 + r.Column3))
                    .ForMember(m => m.Total4, n => n.MapFrom(r => decimal.Round(r.ActualOutlays.Sum(o => o.Amount) / 10000, 2, MidpointRounding.AwayFromZero)))
                    .ForMember(m => m.Surplus, n => n.MapFrom(r => r.Amount * r.Price - decimal.Round(r.ActualOutlays.Sum(o => o.Amount) / 10000, 2, MidpointRounding.AwayFromZero)));

                mapper.CreateMap<ActualOutlay, ActualOutlayListDto>()
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.Date.ToString("yyyy-MM-dd HH:mm")));

                #endregion

            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

    }
}
