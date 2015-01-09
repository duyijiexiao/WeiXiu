using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.cookie.js"));


            bundles.Add(new ScriptBundle("~/bundles/my").Include(             
                     "~/Scripts/my.js",
                          "~/Content/My97DatePicker/WdatePicker.js"));

            bundles.Add(new StyleBundle("~/Content/base").Include(

                    "~/css/base.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                
                      "~/css/base2.css"));
        }
    }
}
