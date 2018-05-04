using System.Web.Optimization;

namespace Blog.Website
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/ReactJs").Include(
                      "~/Content/bundle.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/main.css"));
        }
    }
}
