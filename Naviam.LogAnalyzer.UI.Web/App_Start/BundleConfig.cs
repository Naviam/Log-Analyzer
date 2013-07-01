using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Optimization;

namespace Naviam.DataAnalyzer.UI.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            var layoutBundle = new ScriptBundle("~/bundles/layout").Include(
                "~/Scripts/jquery-{version}.js",
                "~/scripts/jquery-ui-{version}.js",
                "~/scripts/jquery.validate.js",
                "~/scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/json2.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/knockout-2.2.0.js",
                "~/Scripts/dropdown.js");

            layoutBundle.Orderer = new AsIsBundleOrderer();
            bundles.Add(layoutBundle);

            bundles.Add(new ScriptBundle("~/bundles/addDataSource").Include("~/Scripts/ViewModels/AddDataSourceViewModel.js"));

            bundles.Add(new ScriptBundle("~/bundles/memberDashBoard").Include("~/Scripts/jquery.signalR-1.1.2.js", "~/Scripts/ViewModels/MemberDashboardViewModel.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/site.css", "~/Content/dropdowns.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
            
        }
    }

    /// <summary>
    /// The bundle order.
    /// </summary>
    public class AsIsBundleOrderer : IBundleOrderer
    {
        /// <summary>
        /// The order files.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="files">
        /// The files.
        /// </param>
        /// <returns>
        /// Collection of file info objects.
        /// </returns>
        public virtual IEnumerable<FileInfo> OrderFiles(BundleContext context, IEnumerable<FileInfo> files)
        {
            return files;
        }
    }
}