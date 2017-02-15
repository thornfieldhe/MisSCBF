using System.Web.Optimization;

namespace SCBF.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new StyleBundle("~/assets/login/css").Include(
                    "~/assets/css/bootstrap.min.css",
                    "~/assets/css/font-awesome.min.css",
                    "~/assets/js/sweetalert/sweet-alert.css",
                    "~/assets/css/beyond.min.css"));
            bundles.Add(new ScriptBundle("~/assets/login/js").Include(
                   "~/assets/js/jquery-2.2.0.min.js",
                   "~/assets/js/bootstrap.min.js",
                   "~/assets/js/vue.min.js",
                   "~/assets/js/vue-validator.min.js",
                   "~/assets/js/jquery.blockUI.js",
                   "~/assets/js/sweetalert/sweet-alert.min.js",
                   "~/Abp/Framework/scripts/abp.js",
                   "~/Abp/Framework/scripts/libs/abp.jquery.js",
                   "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                   "~/Abp/Framework/scripts/libs/abp.spin.js",
                   "~/Abp/Framework/scripts/libs/abp.sweet-alert.js"));



            bundles.Add(new StyleBundle("~/assets/basiccss").Include(
          "~/assets/css/bootstrap.min.css",
            "~/assets/css/font-awesome.min.css",
          "~/Content/weather-icons.min.css")
          .Include("~/Scripts/sweetalert/sweet-alert.css", new CssRewriteUrlTransform()));

            bundles.Add(bundle: new StyleBundle("~/assets/beyondcss").Include(
                      "~/assets/css/beyond.min.css",
                      "~/assets/css/demo.min.css",
                      "~/assets/css/typicons.min.css",
                      "~/assets/css/animate.min.css",
                      "~/assets/css/dataTables.bootstrap.css",
                      "~/assets/js/ztree/zTreeStyle.css",
                    "~/assets/js/ztree/metro.css"));

            bundles.Add(new ScriptBundle("~/assets/basicjs").Include(
                    "~/assets/js/jquery-2.2.0.min.js",
                    "~/assets/js/bootstrap.min.js",
                    "~/assets/js/modal.js",
                    "~/assets/js/slimscroll/jquery.slimscroll.min.js",
                    "~/assets/js/lodash.min.js",
                    "~/assets/js/beyond.js",
                    "~/assets/js/bootbox/bootbox.js",
                    "~/assets/js/lodash.min.js",
                    "~/assets/js/juicer-min.js",
                    "~/assets/js/ztree/jquery.ztree.core-3.5.js",
                    "~/assets/js/toastr/toastr.js",
                    "~/assets/js/fuelux/spinbox/fuelux.spinbox.min.js",
                    "~/assets/js/validation/bootstrapValidator.js",
                    "~/assets/js/vue.min.js",
                    "~/assets/js/vue-validator.min.js",
                    "~/assets/js/select2/select2.js",
                    "~/assets/js/jquery.blockUI.js",
                    "~/assets/js/sweetalert/sweet-alert.min.js",
                    "~/assets/js/spinjs/spin.js",
                    "~/assets/js/spinjs/jquery.spin.js",
                    "~/assets/js/vue-router.min.js",
                    "~/Abp/Framework/scripts/abp.js",
                    "~/Abp/Framework/scripts/libs/abp.jquery.js",
                    "~/Abp/Framework/scripts/libs/abp.toastr.js",
                    "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                    "~/Abp/Framework/scripts/libs/abp.spin.js",
                    "~/Abp/Framework/scripts/libs/abp.sweet-alert.js",
                    "~/Abp/Framework/scripts/libs/angularjs/abp.ng.js"));

            bundles.Add(new ScriptBundle("~/assets/app").Include(
                     "~/scripts/home/index.js",
                     "~/scripts/home/base.js",
                     "~/scripts/home/utility.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}