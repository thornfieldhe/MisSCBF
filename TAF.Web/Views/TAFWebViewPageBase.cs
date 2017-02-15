using Abp.Web.Mvc.Views;

namespace SCBF.Web.Views
{
    public abstract class TAFWebViewPageBase : TAFWebViewPageBase<dynamic>
    {

    }

    public abstract class TAFWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected TAFWebViewPageBase()
        {
            LocalizationSourceName = TAFConsts.LocalizationSourceName;
        }
    }
}