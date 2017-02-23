using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace SCBF
{

    using Microsoft.AspNet.Identity;

    using SCBF.BaseInfo;
    using SCBF.BaseInfo.Dto;
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
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

    }
}
