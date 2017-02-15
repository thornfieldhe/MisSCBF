// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultEditionsCreator.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the DefaultEditionsCreator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Migrations.SeedData
{
    using System.Linq;

    using Abp.Application.Editions;

    using SCBF.Editions;
    using SCBF.EntityFramework;

    public class DefaultEditionsCreator : DefaultCreator
    {

        public DefaultEditionsCreator(TAFDbContext context)
            : base(context)
        {
        }

        public override void Create()
        {
            CreateEditions();
        }

        private void CreateEditions()
        {
            var defaultEdition = Context.Editions.FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
            if (defaultEdition == null)
            {
                defaultEdition = new Edition { Name = EditionManager.DefaultEditionName, DisplayName = EditionManager.DefaultEditionName };
                Context.Editions.Add(defaultEdition);
                Context.SaveChanges();

                //TODO: Add desired features to the standard edition, if wanted!
            }
        }

    }
}