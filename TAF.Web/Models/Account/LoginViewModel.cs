using System.ComponentModel.DataAnnotations;

namespace SCBF.Web.Models.Account
{
    public class LoginViewModel
    {

        [Required]
        public string Name
        {
            get; set;
        }

        [Required]
        public string Password
        {
            get; set;
        }
    }
}