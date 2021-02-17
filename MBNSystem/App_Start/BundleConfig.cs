using System.Web;
using System.Web.Optimization;

namespace MBNSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/ComponentScripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/ComponentScripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/ComponentScripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/ComponentScripts/bootstrap.bundle.min.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/adminlte/css").Include(
                "~/adminlte/css/adminlte.min.css"));

            bundles.Add(new StyleBundle("~/Content/adminlte/plugins/fontawesome-free/css/").Include(
                "~/adminlte/plugins/fontawesome-free/css/all.min.css"));

            bundles.Add(new ScriptBundle("~/adminlte/js").Include(
                "~/adminlte/js/adminlte.min.js"));
        }
    }
}
