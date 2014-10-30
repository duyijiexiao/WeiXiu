using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class CompanyController : Controller
    {
        //
        // GET: /Company/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CheckName(string id)
        {
            SuggestionRes response = new SuggestionRes();

            #region 各种校验



            #endregion
            response.errorCode = 0; 
            return Json(response);
        }
	}
}