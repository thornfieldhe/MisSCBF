using EntityFramework.DynamicFilters;

namespace SCBF.Migrations.SeedData
{
    using System.Collections.Generic;

    using SCBF.EntityFramework;

    public class InitialHostDbBuilder
    {
        private readonly TAFDbContext _context;
        private readonly List<DefaultCreator> _creators;

        public InitialHostDbBuilder(TAFDbContext context)
        {
            _context = context;
            this._creators = new List<DefaultCreator>
                                 {
                                     new DefaultEditionsCreator(_context),
                                     new DefaultLanguagesCreator(_context),
                                     new DefaultRolesCreator(_context),
                                     new DefaultRolePermissionCreator(_context),
                                     new HostRoleAndUserCreator(_context),
                                     new DefaultSettingsCreator(_context)
                                 };
        }

        public void Create()
        {
            _context.DisableAllFilters();
            foreach (var creator in this._creators)
            {
                creator.Create();
            }
        }
    }
}
