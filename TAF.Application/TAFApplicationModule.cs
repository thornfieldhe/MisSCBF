using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace SCBF
{
    using System.Linq;
    using System.Linq.Dynamic;

    using Microsoft.AspNet.Identity;

    using SCBF.Projects.Dto;
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
                mapper.CreateMap<Project, ProjectListDto>()
                    .ForMember(m => m.TaskItems, n => n.MapFrom(r => r.Tasks.Count))
                    .ForMember(m => m.IsCompleted, n => n.MapFrom(r => r.IsCompleted ? "Y" : "N"))
                    .ForMember(m => m.Schedule, n => n.MapFrom(r => $"{r.Tasks.Count(t => t.Schedule == 100)}/{r.Tasks.Count}"));
                mapper.CreateMap<Project, ProjectEditDto>()
                 .ForMember(m => m.TaskItems, n => n.MapFrom(r => r.Tasks.Count))
                 .ForMember(m => m.Schedule, n => n.MapFrom(r => $"{r.Tasks.Count(t => t.Schedule == 100)}/{r.Tasks.Count}"));
                mapper.CreateMap<ProjectTask, ProjectTaskListDto>()
                    .ForMember(m => m.Schedule, n => n.MapFrom(r => $"{r.Schedule}%"))
                    .ForMember(m => m.ProjectName, n => n.MapFrom(r => r.Project.Name));
                mapper.CreateMap<DailyLog, DailyLogListDto>()
                    .ForMember(m => m.TaskName, n => n.MapFrom(r => r.Task.Name))
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.Date.ToString("yyyy-MM-dd")))
                    .ForMember(m => m.ResponsiblePerson, n => n.MapFrom(r => r.ResponsiblePerson.Name))
                    .ForMember(m => m.ProjectName, n => n.MapFrom(r => r.Task.Project.Name));
                mapper.CreateMap<DailyLog, DailyLogEditDto>()
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.Date.ToString("yyyy-MM-dd")));
                mapper.CreateMap<Project, ProjectSummaryDto>()
                    .ForMember(
                        m => m.Schedule,
                        n => n.MapFrom(r => $"{r.Tasks.Count(b => b.Schedule == 100)}/{r.Tasks.Count}"));
                mapper.CreateMap<DailyLog, DailyLogSummaryDto>()
                    .ForMember(m => m.Date, n => n.MapFrom(r => r.Date.ToString("yyyy-MM-dd")))
                    .ForMember(m => m.ResponsiblePerson, n => n.MapFrom(r => r.ResponsiblePerson.Name));
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

    }
}
