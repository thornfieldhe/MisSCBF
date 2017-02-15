using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace SCBF.Web.Controllers
{
    using Abp.Domain.Repositories;

    using SCBF.Users;

    [AbpMvcAuthorize]
    public class HomeController : TAFControllerBase
    {
        private readonly IRepository<User, long> _userRepository;

        public HomeController(IRepository<User, long> userRepository)
        {
            this._userRepository = userRepository;
        }

        public ActionResult Index()
        {
            var user = this._userRepository.FirstOrDefault(r => r.UserName == User.Identity.Name);
            return View("Index", user);
        }

        public ActionResult Dashboard()
        {
            return PartialView("_Dashboard");
        }

        public ActionResult ProductCategory()
        {
            return PartialView("_ProductCategory");
        }
    }
}