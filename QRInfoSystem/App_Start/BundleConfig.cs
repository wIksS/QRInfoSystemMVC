using System.Web;
using System.Web.Optimization;

namespace QRInfoSystem.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular-lib").Include(
                        "~/Scripts/angular/angular.js",
                        "~/Scripts/angular/angular-route.js",
                        "~/Scripts/angular-file-upload.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/Scripts/jquery/jquery-ui.js",
                        "~/Scripts/jquery/jquery-timepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-spa")
    .IncludeDirectory("~/Js", "*.js", true));

            //bundles.Add(new ScriptBundle("~/bundles/angular-spa")
            //            .IncludeDirectory("~/Js/controllers", "*.js")
            //            .IncludeDirectory("~/Js/services", "*.js")
            //            .IncludeDirectory("~/Js/services/account", "*.js")
            //            .IncludeDirectory("~/Js/services/resources", "*.js")
            //            .IncludeDirectory("~/Js/services/teacher", "*.js")
            //            .Include("~/Js/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/toastr/toastr.js",
                        "~/Scripts/qrcode.js",
                        "~/Scripts/calendar/fullcalendar-2.1.1/lib/moment.min.js",
                        "~/Scripts/calendar/fullcalendar.js",
                        "~/Scripts/glDatePicker/glDatePicker.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Scripts/glDatePicker/styles/glDatePicker.flatwhite.css",
                      "~/Scripts/calendar/fullcalendar.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/AwesomeAngularMVCApp")
            //            .IncludeDirectory("~/js/Controllers", "*.js")
            //            .IncludeDirectory("~/js/services", "*.js")
            //            .IncludeDirectory("~/js/services/account", "*.js")
            //            .IncludeDirectory("~/js/services/teacher", "*.js")
            //            .Include("~/js/app.js"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.min.css",
            //          "~/Content/site.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
