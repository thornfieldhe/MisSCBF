using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

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

    [DependsOn(typeof(TAFCoreModule), typeof(AbpAutoMapperModule))]
    public class TAFApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                mapper.CreateMap<User, UserListDto>().ForMember(m => m.Roles, n => n.Ignore());
                mapper.CreateMap<User, UserEditDto>().ForMember(m => m.Roles, n => n.Ignore());
                mapper.CreateMap<UserEditDto, User>()
                .ForMember(m => m.Roles, n => n.Ignore())
                .ForMember(m => m.Surname, n => n.MapFrom(r => r.Name))
                .ForMember(m => m.IsEmailConfirmed, n => n.MapFrom(r => true))
                .ForMember(m => m.IsActive, n => n.MapFrom(r => true))
                .ForMember(m => m.EmailAddress, n => n.MapFrom(r => $"{r.UserName}@taf.com"))
                .ForMember(m => m.Password, n => n.MapFrom(r => new PasswordHasher().HashPassword("11111111")));
                mapper.CreateMap<Layer, LayerListDto>();
                mapper.CreateMap<Layer, LayerEditDto>()
                .ForMember(m => m.Code, n => n.MapFrom(r => r.LevelCode));
                mapper.CreateMap<LayerEditDto, Layer>()
                .ForMember(m => m.LevelCode, n => n.MapFrom(r => r.Code));
                mapper.CreateMap<SysDictionary, SysDictionaryListDto>();
                mapper.CreateMap<SysDictionary, SysDictionaryEditDto>();
                mapper.CreateMap<Product, ProductListDto>();
                mapper.CreateMap<Product, ProductEditDto>();
                mapper.CreateMap<ProductEditDto, Product>();

                mapper.CreateMap<Product, ProductStockListDto>()
                    .ForMember(m => m.ProductId, n => n.MapFrom(r => r.Id));
                mapper.CreateMap<Stock, ProductStockListDto>()
                    .ForMember(m => m.Code, n => n.MapFrom(r => r.Product.Code))
                    .ForMember(m => m.StockBalance, n => n.MapFrom(r => r.Amount))
                    .ForMember(m => m.Name, n => n.MapFrom(r => r.Product.Name))
                    .ForMember(m => m.Amount, n => n.MapFrom(r => 1))
                    .ForMember(m => m.StorageName, n => n.MapFrom(r => r.Storage.Value));

                mapper.CreateMap<StockBillEditDto, EntryBill>()
                .ForMember(m => m.Entries, n => n.MapFrom(r => r.Items));
                mapper.CreateMap<ProductStockListDto, Entry>();
                mapper.CreateMap<Entry, ProductStockListDto>()
                                .ForMember(m => m.Name, n => n.MapFrom(r => r.Product.Name))
                                .ForMember(m => m.StorageName, n => n.MapFrom(r => r.Storage.Value))
                                .ForMember(m => m.Code, n => n.MapFrom(r => r.EntryBill.Code))
                                .ForMember(m => m.StockBalance, n => n.MapFrom(r => 0));

                mapper.CreateMap<StockBillEditDto, DeliveryBill>()
                    .ForMember(m => m.Deliveries, n => n.MapFrom(r => r.Items));
                mapper.CreateMap<ProductStockListDto, Delivery>();
                mapper.CreateMap<Delivery, ProductStockListDto>()
                                .ForMember(m => m.Name, n => n.MapFrom(r => r.Product.Name))
                                .ForMember(m => m.StorageName, n => n.MapFrom(r => r.Storage.Value))
                                .ForMember(m => m.Code, n => n.MapFrom(r => r.DeliveryBill.Code))
                                .ForMember(m => m.StockBalance, n => n.MapFrom(r => 0));

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


                mapper.CreateMap<ActualOutlay, ActualOutlayListDto>()
                .ForMember(m => m.Date, n => n.MapFrom(r => r.Date.ToString("yyyy-MM-dd HH:mm")));
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

    }
}
