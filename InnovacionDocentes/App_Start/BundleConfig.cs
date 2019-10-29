using System.Web;
using System.Web.Optimization;

namespace InnovacionDocentes
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include(
               "~/Content/vendors/bootstrap/dist/css/bootstrap.min.css",
               "~/Content/vendors/font-awesome/css/font-awesome.min.css",
               "~/Content/build/css/custom.min.css",
                "~/Content/vendors/nprogress/nprogress.css",
                       "~/Content/vendors /bootstrap/dist/css/bootstrap.min.css",
                       "~/Content/vendors/font-awesome/css/font-awesome.min.css",
                       "~/Content/vendors/nprogress/nprogress.css",
                       "~/Content/vendors/iCheck/skins/flat/green.css",
                       "~/Content/vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css",
                       "~/Content/vendors/jqvmap/dist/jqvmap.min.css",
                       "~/Content/vendors/bootstrap-daterangepicker/daterangepicker.css",
                       "~/Content/build/css/custom.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Content/build/js/custom.min.js",
                "~/Content/vendors/bootstrap-daterangepicker/daterangepicker.js",
                "~/Content/vendors/moment/min/moment.min.js",
                "~/Content/vendors/jqvmap/examples/js/jquery.vmap.sampledata.js",
                "~/Content/vendors/jqvmap/dist/maps/jquery.vmap.world.js",
                "~/Content/vendors/jqvmap/dist/jquery.vmap.js",
                "~/Content/vendors/DateJS/build/date.js",
                "~/Content/vendors/flot.curvedlines/curvedLines.js",
                "~/Content/vendors/flot-spline/js/jquery.flot.spline.min.js",
                "~/Content/vendors/flot.orderbars/js/jquery.flot.orderBars.js",
                "~/Content/vendors/Flot/jquery.flot.resize.js",
                "~/Content/vendors/Flot/jquery.flot.stack.js",
                "~/Content/vendors/Flot/jquery.flot.time.js",
                "~/Content//vendors/Flot/jquery.flot.pie.js",
                "~/Content/vendors/Flot/jquery.flot.js",
                "~/Content/vendors/skycons/skycons.js",
                "~/Content/vendors/iCheck/icheck.min.js",
                "~/Content/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js",
                "~/Content/vendors/Chart.js/dist/Chart.min.js",
                "~/Content/vendors/gauge.js/dist/gauge.min.js",
                "~/Content/vendors/nprogress/nprogress.js",
                "~/Content/vendors/fastclick/lib/fastclick.js",
                "~/Content/vendors/bootstrap/dist/js/bootstrap.bundle.min.js",
                "~/Content/vendors/jquery/dist/jquery.min.js",
                "~/Scripts/jquery-3.4.1.min.js",
                 "~/Scripts/jquery.validate.min.js",
                 "~/Content/build/js/custom.min.js",
                 "~/Content/vendors/nprogress/nprogress.js",
                 "~/Content/vendors/fastclick/lib/fastclick.js",
                 "~/Content/vendors/bootstrap/dist/js/bootstrap.bundle.min.js",
                 "~/Content/vendors/jquery/dist/jquery.min.js",
                 "~/Content/vendors/bootstrap-daterangepicker/daterangepicker.js",
                 "~/Content/vendors/Flot/jquery.flot.pie.js",
                 "~/Content/vendors/Flot/jquery.flot.js",
                 "~/Content/vendors/skycons/skycons.js",
                 "~/Content/vendors/gauge.js/dist/gauge.min.js",
                 "~/Content/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js",
                 "~/Content/vendors/DateJS/build/date.js",
                 "~/Content/vendors/jqvmap/dist/jquery.vmap.js",
                 "~/Content/vendors/jqvmap/dist/maps/jquery.vmap.world.js",
                 "~/Content/vendors/jqvmap/examples/js/jquery.vmap.sampledata.js",
                 "~/Content/vendors/moment/min/moment.min.js",
                 "~/Content/vendors/Flot/jquery.flot.time.js",
                     "~/Content/vendors/Flot/jquery.flot.stack.js",
                         "~/Content/vendors/Flot/jquery.flot.resize.js",
                             "~/Content/vendors/skycons/skycons.js",
                             "~/Content/vendors/Chart.js/dist/Chart.min.js",
                               "~/Content/vendors/gauge.js/dist/gauge.min.js",
                                 "~/Content/vendors/nprogress/nprogress.j",
                                 "~/Content/vendors/fastclick/lib/fastclick.js",
                                 "~/Content/ vendors / jquery / dist / jquery.min.js",
                                 "~/Content/vendors/jquery/dist/jquery.min.js",
                                 "~/Content/vendors/bootstrap/dist/js/bootstrap.bundle.min.js",
                                 "~/Content/vendors/fastclick/lib/fastclick.js",
                                 "~/Content/vendors/nprogress/nprogress.js"


               ));
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //          "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            //// para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
