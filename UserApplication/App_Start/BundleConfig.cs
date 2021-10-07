using System.Web;
using System.Web.Optimization;

namespace UserApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862

        public static void RegisterBundles(BundleCollection bundles)
        {

            
            BundleTable.EnableOptimizations = false;
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                     "~/Scripts/jquery-3.3.1.min.js",
                     "~/Scripts/popper.js",
                     "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap-select.min.js",
                     "~/Scripts/jquery.dataTables.js",
                     "~/Scripts/dataTables.bootstrap4.js",
                     "~/Scripts/dataTables.js",
                     "~/Scripts/perfect-scrollbar.min.js",
                     "~/Scripts/select2.min.js",
                     "~/Scripts/sweetalert2.min.js",
                     "~/Scripts/coreui.min.js",
                     "~/Scripts/jquery.easy-ticker.min.js",
                     "~/Scripts/barcode.min.js"));



            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/coreui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/scriptsval").Include(
                      "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                    "~/Content/coreui-icons.min.css",
                    "~/Content/dataTables.bootstrap4.css",
                    "~/Content/font-awesome.min.css",
                     "~/Content/fontawesome-webfont",
                    "~/Content/select2.min.css",
                    "~/Content/simple-line-icons.css",
                    "~/Content/style.css",
                    "~/Content/sweetalert2.min.css"));

          


        }
    }
}
