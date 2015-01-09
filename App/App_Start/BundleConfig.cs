using System.Web;
using System.Web.Optimization;

namespace App
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery1.8.3.min.js",
                        "~/Scripts/JScriptCommon.js"));
            bundles.Add(new ScriptBundle("~/bundles/easyui").Include(
                       "~/Res/easyui/jquery.easyui.min.js",
                      "~/Res/easyui/locale/easyui-lang-zh_CN.js",
                         "~/Res/My97DatePicker/WdatePicker.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js"));


 
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Res/easyui/themes/default/easyui.css",
                      "~/Res/easyui/themes/icon.css",
                      "~/Content/default.css",
                      "~/Content/StyleSheet.css"));
        }
    }
}
