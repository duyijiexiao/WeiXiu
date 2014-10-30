using Senparc.Weixin.QY.AdvancedAPIs;
using Senparc.Weixin.QY.CommonAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public static readonly string EncodingAESKey = "UvqtiWgD_c0scqYq6fZ_DPrzyiJpl1yZT4GYxg69cLU5QXWZzAQ4hm9NwMsO5k4K";//与微信企业账号后台的EncodingAESKey设置保持一致，区分大小写。
        public static readonly string CorpId = "wxde43cbb4067c8f4d";//与微信企业账号后台的EncodingAESKey设置保持一致，区分大小写。


        public ActionResult Index()
        {
  //         var d= CommonApi.GetToken(CorpId, EncodingAESKey);


  //      var dd=    Department.GetDepartmentList(d.access_token);
  //      var id = dd.department[0].id;
  //var asdf=      Member.GetDepartmentMember(d.access_token,  id, 0, 0);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}