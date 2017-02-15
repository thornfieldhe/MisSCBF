// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultSettingsCreator.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the DefaultSettingsCreator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Migrations.SeedData
{
    using System.Linq;

    using Abp.Configuration;
    using Abp.Localization;
    using Abp.Net.Mail;

    using SCBF.EntityFramework;

    public class DefaultSettingsCreator : DefaultCreator
    {
        public DefaultSettingsCreator(TAFDbContext context)
            : base(context)
        {
        }

        public override void Create()
        {
            //Emailing
            AddSettingIfNotExists(EmailSettingNames.DefaultFromAddress, "admin@mydomain.com");
            AddSettingIfNotExists(EmailSettingNames.DefaultFromDisplayName, "mydomain.com mailer");

            //Languages
            AddSettingIfNotExists(LocalizationSettingNames.DefaultLanguage, "en");
        }

        private void AddSettingIfNotExists(string name, string value, int? tenantId = null)
        {
            if (this.Context.Settings.Any(s => s.Name == name && s.TenantId == tenantId && s.UserId == null))
            {
                return;
            }

            this.Context.Settings.Add(new Setting(tenantId, null, name, value));
            this.Context.SaveChanges();
        }
    }
}