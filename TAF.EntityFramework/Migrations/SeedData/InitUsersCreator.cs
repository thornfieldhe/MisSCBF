// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InitUsersCreator.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   InitUsersCreator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Migrations.SeedData
{
    using System.Linq;

    using Microsoft.AspNet.Identity;

    using SCBF.EntityFramework;
    using SCBF.Users;

    /// <summary>
    /// 
    /// </summary>
    public class InitUsersCreator : DefaultCreator
    {
        public InitUsersCreator(TAFDbContext context)
            : base(context)
        {
        }

        public override void Create()
        {
            if (!this.Context.Users.Any(r => r.UserName.StartsWith("user")))
            {
                for (var i = 0; i < 50; i++)
                {
                    Context.Users.Add(
                            new User
                            {
                                UserName = $"user{i}",
                                Name = $"System{i}",
                                Surname = $"user{i}",
                                EmailAddress = $"user{i}@taf.com",
                                IsEmailConfirmed = true,
                                Password = new PasswordHasher().HashPassword(User.DefaultPassword)
                            });
                }
            }
        }
    }
}