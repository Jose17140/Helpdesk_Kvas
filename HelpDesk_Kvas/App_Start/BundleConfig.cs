using System.Web;
using System.Web.Optimization;

namespace HelpDesk_Kvas
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

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/lib/plugins/jQuery/jquery-2.2.3.min.js",
                      "~/Content/lib/bootstrap/dist/js/bootstrap.min.js",
                      "~/Content/lib/plugins/datatables/jquery.dataTables.min.js",
                      "~/Content/lib/plugins/datatables/dataTables.bootstrap.min.js",
                      "~/Scripts/respond.js",
                      "~/Content/js/raphael.min.js",
                      "~/Content/js/moment.min.js",
                      "~/Content/lib/plugins/slimScroll/jquery.slimscroll.min.js",
                      "~/Content/js/app.js",
                      "~/Content/js/demo.js",
                      "~/Content/js/site.js"
                      ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/lib/bootstrap/dist/css/bootstrap.css",
                     "~/Content/lib/font-awesome-4.6.3/css/font-awesome.css",
                     "~/Content/lib/ionicons-2.0.1/css/ionicons.css",
                     "~/Content/css/AdminLTE.css",
                     "~/Content/css/_all-skins.css",
                     "~/Content/lib/plugins/iCheck/flat/blue.css",
                     "~/Content/lib/plugins/morris/morris.css",
                     "~/Content/lib/toastr/build/toastr.css",
                     "~/Content/lib/plugins/datatables/dataTables.bootstrap.css"));
        }
    }
}
