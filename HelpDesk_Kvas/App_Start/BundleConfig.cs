using System.Web;
using System.Web.Optimization;

namespace HelpDesk_Kvas
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //JQUERY DEBE ESTAR PRESENTE EN LAYOUT
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Content/lib/plugins/jQuery/jquery-2.2.3.min.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/jquery.validate*",
                        "~/Content/lib/plugins/datatables/jquery.dataTables.min.js",
                        "~/Content/lib/plugins/slimScroll/jquery.slimscroll.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js"
                        ));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/lib/bootstrap/dist/js/bootstrap.min.js",
                      "~/Content/lib/plugins/datatables/dataTables.bootstrap.min.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/adminLte").Include(
                      "~/Scripts/respond.js",
                      "~/Content/js/raphael.min.js",
                      "~/Content/js/moment.min.js",
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
