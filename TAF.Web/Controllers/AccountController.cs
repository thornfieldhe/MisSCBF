// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="">
//   
// </copyright>
// <summary>
//   账号控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Abp.Authorization;
    using Abp.Authorization.Users;
    using Abp.Configuration.Startup;
    using Abp.Domain.Uow;
    using Abp.UI;
    using Abp.Web.Models;
    using Authorization;
    using Authorization.Roles;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;
    using Models.Account;
    using MultiTenancy;
    using TAF.Utility;
    using Users;

    public class AccountController : TAFControllerBase
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IMultiTenancyConfig _multiTenancyConfig;
        private readonly LogInManager _logInManager;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return this.HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController(
            UserManager userManager,
            RoleManager roleManager,
            IUnitOfWorkManager unitOfWorkManager,
            IMultiTenancyConfig multiTenancyConfig,
            LogInManager logInManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._unitOfWorkManager = unitOfWorkManager;
            this._multiTenancyConfig = multiTenancyConfig;
            this._logInManager = logInManager;
        }

        #region Login / Logout

        public ActionResult Login(string returnUrl = "")
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = this.Request.ApplicationPath;
            }

            return this.View(
                new LoginFormViewModel
                {
                    ReturnUrl = returnUrl,
                    IsMultiTenancyEnabled = this._multiTenancyConfig.IsEnabled
                });
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(PermissionNames.PagesAdmins)]
        public ActionResult UserList()
        {
            var roles = this._roleManager.Roles.Select(r => new KeyValue<string, int, string> { Key = r.DisplayName, Value = r.Id, Item3 = r.Name }).ToList();
            return this.PartialView("_UserIndex", roles);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(PermissionNames.Default)]
        public ActionResult ChangePwd()
        {
            return this.PartialView("_ChangePwd");
        }

        [HttpPost]
        public async Task<JsonResult> Login(LoginViewModel loginModel, string returnUrl = "", string returnUrlHash = "")
        {
            this.CheckModelState();

            var loginResult = await this.GetLoginResultAsync(
                loginModel.Name,
                loginModel.Password);

            if (loginResult.Result!=AbpLoginResultType.Success)
            {
                throw new UserFriendlyException("用户名或密码错误");

//                return this.Json(new AjaxResponse { Error =new ErrorInfo(){Details = "用户名或密码错误",Code = 500,Message = "用户名或密码错误"}  });
            }

            await this.SignInAsync(loginResult.User, loginResult.Identity, true);

            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = this.Request.ApplicationPath;
            }

            if (!string.IsNullOrWhiteSpace(returnUrlHash))
            {
                returnUrl = returnUrl + returnUrlHash;
            }

            return this.Json(new AjaxResponse { TargetUrl = returnUrl });
        }


        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(PermissionNames.Default)]
        public ActionResult Logout()
        {
            this.AuthenticationManager.SignOut();
            return this.RedirectToAction("Login");
        }

        private async Task<AbpLoginResult<Tenant, User>> GetLoginResultAsync(string usernameOrEmailAddress, string password)
        {
            var loginResult = await this._logInManager.LoginAsync(usernameOrEmailAddress, password, null);

                    return loginResult;
        }

        private async Task SignInAsync(User user, ClaimsIdentity identity = null, bool rememberMe = false)
        {
            if (identity == null)
            {
                identity = await this._userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }

            this.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            this.AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = rememberMe }, identity);
        }

        private Exception CreateExceptionForFailedLoginAttempt(AbpLoginResultType result, string usernameOrEmailAddress)
        {
            switch (result)
            {
                case AbpLoginResultType.Success:
                    return new ApplicationException("Don't call this method with a success result!");
                case AbpLoginResultType.InvalidUserNameOrEmailAddress:
                case AbpLoginResultType.InvalidPassword:
                    return new UserFriendlyException(this.L("LoginFailed"), this.L("InvalidUserNameOrPassword"));
                case AbpLoginResultType.UserIsNotActive:
                    return new UserFriendlyException(this.L("LoginFailed"), this.L("UserIsNotActiveAndCanNotLogin", usernameOrEmailAddress));
                case AbpLoginResultType.UserEmailIsNotConfirmed:
                    return new UserFriendlyException(this.L("LoginFailed"), "Your email address is not confirmed. You can not login"); //TODO: localize message
                default: //Can not fall to default actually. But other result types can be added in the future and we may forget to handle it
                    this.Logger.Warn("Unhandled login fail reason: " + result);
                    return new UserFriendlyException(this.L("LoginFailed"));
            }
        }

        #endregion

    }
}