// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditUserInput.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the EditUserInput type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Users.Dto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Abp.Authorization.Users;
    using Abp.AutoMapper;

    [AutoMapFrom(typeof(User))]
    public class UserEditDto
    {
        public UserEditDto()
        {
            this.Roles = new List<string>();
        }

        public long Id
        {
            get; set;
        }

        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName
        {
            get; set;
        }

        [Required]
        [StringLength(User.MaxNameLength)]
        public string Name
        {
            get; set;
        }

        public IList<string> Roles
        {
            get; set;
        }
    }
}