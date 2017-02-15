// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserAppService_Tests.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the UserAppService_Tests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Tests.Users
{
    using System.Data.Entity;
    using System.Threading.Tasks;

    using SCBF.Users;
    using SCBF.Users.Dto;

    using Shouldly;

    using Xunit;

    public class UserAppService_Tests : TAFTestBase
    {
        private readonly IUserAppService _userAppService;

        public UserAppService_Tests()
        {
            _userAppService = Resolve<IUserAppService>();
        }

        [Fact]
        public async Task GetUsers_Test()
        {
            // Act
            var output = await _userAppService.GetAllAsync(new UserQueryDto());

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task CreateUser_Test()
        {
            // Act
            await
                _userAppService.SaveAsync(
                    new UserEditDto
                    {
                        Name = "John",
                        UserName = "john.nash"
                    });

            await UsingDbContextAsync(
                async context =>
                          {
                              var johnNashUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == "john.nash");
                              johnNashUser.ShouldNotBeNull();
                          });
        }
    }
}