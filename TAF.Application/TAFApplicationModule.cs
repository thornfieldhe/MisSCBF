using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace SCBF
{

    using Microsoft.AspNet.Identity;

    using SCBF.BaseInfo;
    using SCBF.BaseInfo.Dto;
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
                mapper.CreateMap<Layer, LayerEditDto>();
                mapper.CreateMap<SysDictionary, SysDictionaryListDto>();
                mapper.CreateMap<SysDictionary, SysDictionaryEditDto>();
                mapper.CreateMap<Product, ProductListDto>();
                mapper.CreateMap<Product, ProductEditDto>();
                mapper.CreateMap<ProductEditDto, Product>();

                mapper.CreateMap<StockBillEditDto, EntryBill>();
                mapper.CreateMap<ProductStockListDto, Entry>()
                .ForMember(m => m.ProductId, n => n.MapFrom(r => r.Id));
                mapper.CreateMap<Product, ProductStockListDto>();
                mapper.CreateMap<Entry, ProductStockListDto>()
                                .ForMember(m => m.Name, n => n.MapFrom(r => r.Product.Name))
                                .ForMember(m => m.StorageName, n => n.MapFrom(r => r.EntryBill.Storage.Value))
                                .ForMember(m => m.Code, n => n.MapFrom(r => r.EntryBill.Code))
                                .ForMember(m => m.StockBalance, n => n.MapFrom(r => 0));
                mapper.CreateMap<Stock, ProductStockListDto>()
                    .ForMember(m => m.Code, n => n.MapFrom(r => r.Product.Code))
                    .ForMember(m => m.StockBalance, n => n.MapFrom(r => r.Amount))
                    .ForMember(m => m.Name, n => n.MapFrom(r => r.Product.Name))
                    .ForMember(m => m.Id, n => n.MapFrom(r => r.Product.Id))
                    .ForMember(m => m.Amount, n => n.MapFrom(r => 1))
                    .ForMember(m => m.StorageName, n => n.MapFrom(r => r.Storage.Value));
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

    }
}
