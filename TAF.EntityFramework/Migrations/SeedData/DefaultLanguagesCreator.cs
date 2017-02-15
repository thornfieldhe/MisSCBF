using System.Collections.Generic;
using System.Linq;
using Abp.Localization;

namespace SCBF.Migrations.SeedData
{
    using SCBF.EntityFramework;

    public class DefaultLanguagesCreator : DefaultCreator
    {
        public static List<ApplicationLanguage> InitialLanguages
        {
            get; private set;
        }


        static DefaultLanguagesCreator()
        {
            InitialLanguages = new List<ApplicationLanguage>
            {
                new ApplicationLanguage(null, "en", "English", "famfamfam-flag-gb"),
                new ApplicationLanguage(null, "zh-CN", "简体中文", "famfamfam-flag-cn")
            };
        }

        public DefaultLanguagesCreator(TAFDbContext context) : base(context) { }

        public override void Create()
        {
            CreateLanguages();
        }

        private void CreateLanguages()
        {
            foreach (var language in InitialLanguages)
            {
                AddLanguageIfNotExists(language);
            }
        }

        private void AddLanguageIfNotExists(ApplicationLanguage language)
        {
            if (Context.Languages.Any(l => l.TenantId == language.TenantId && l.Name == language.Name))
            {
                return;
            }

            Context.Languages.Add(language);

            Context.SaveChanges();
        }
    }
}
