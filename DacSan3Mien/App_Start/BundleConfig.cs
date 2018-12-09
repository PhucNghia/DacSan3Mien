using System.Web;
using System.Web.Optimization;

namespace DacSan3Mien
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you"re
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Notify
            bundles.Add(new StyleBundle("~/Content/notifycss").Include(
                      "~/Content/toastr.css",
                      "~/Content/toastr.min.css"));

            bundles.Add(new ScriptBundle("~/Content/notifyjs").Include(
                       "~/Scripts/toastr.js",
                       "~/Scripts/toastr.min.js"));

            //==================================================================================================

            // Layout
            bundles.Add(new StyleBundle("~/Assets/css/css1").Include(
                "~/Assets/css/bootstrap.min.css",
                "~/Assets/css/settings.css",
                "~/Assets/css/owl.carousel.css",
                "~/Assets/css/owl.theme.css",
                "~/Assets/css/font-awesome.min.css"));    // + googleapis +

            bundles.Add(new StyleBundle("~/Assets/css/css2").Include(
                "~/Assets/css/style.css",
                "~/Assets/css/custom.css",
                "~/Assets/css/magnific-popup.css",
                "~/Assets/css/style-selector.css"));

            bundles.Add(new ScriptBundle("~/Assets/js/layout").Include(
                "~/Assets/js/jquery.min.js",
                "~/Assets/js/bootstrap.min.js",
                //"~/Assets/js/jquery-migrate.min.js",
                "~/Assets/js/modernizr-2.7.1.min.js",
                "~/Assets/js/off-cavnass.js",
                "~/Assets/js/jquery.cookie.js",
                "~/Assets/js/style.selector.js",
                "~/Assets/js/script.js",
                "~/Assets/js/custom.js",
                "~/Assets/js/imagesloaded.pkgd.min.js",
                "~/Assets/js/isotope.pkgd.min.js",
                "~/Assets/js/portfolio.js",
                "~/Assets/js/jquery.touchSwipe.min.js",
                "~/Assets/js/jquery.carouFredSel-6.2.1.js",
                "~/Assets/js/jquery.isotope.min.js",
                "~/Assets/js/owl.carousel.min.js",
                "~/Assets/js/jflickrfeed.min.js",
                "~/Assets/js/jquery.magnific-popup.js",

                "~/Assets/js/jquery.themepunch.tools.min.js",
                "~/Assets/js/jquery.themepunch.revolution.min.js"));

            // Login
            bundles.Add(new StyleBundle("~/Assets/css/Login").Include(
                "~/Assets/Login/fonts/Linearicons-Free-v1.0.0/icon-font.min.css",
                "~/Assets/Login/vendor/animate/animate.css",
                "~/Assets/Login/vendor/css-hamburgers/hamburgers.min.css",
                "~/Assets/Login/vendor/animsition/css/animsition.min.css",
                "~/Assets/Login/vendor/select2/select2.min.css",
                "~/Assets/Login/vendor/daterangepicker/daterangepicker.css",
                "~/Assets/Login/css/util.css",
                "~/Assets/Login/css/main.css",
                "~/Assets/Login/css/custom.css"));

            bundles.Add(new ScriptBundle("~/Assets/js/Login").Include(
                "~/Assets/Login/vendor/animsition/js/animsition.min.js",
                "~/Assets/Login/vendor/bootstrap/js/popper.js",
                "~/Assets/Login/vendor/select2/select2.min.js",
                "~/Assets/Login/vendor/daterangepicker/moment.min.js",
                "~/Assets/Login/vendor/daterangepicker/daterangepicker.js",
                "~/Assets/Login/vendor/countdowntime/countdowntime.js"
                //"~/assets/Login/js/main.js"
                ));

            // Register
            bundles.Add(new StyleBundle("~/Assets/css/Register").Include(
                "~/Assets/Register/css/style.css"));

            //
        }
    }
}
