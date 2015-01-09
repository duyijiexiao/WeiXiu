using Common;
using Langben.BLL;
using Langben.DAL;
using Langben.IBLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ApplyController : BaseController
    {


        ValidationErrors validationErrors = new ValidationErrors();


        public ActionResult Finished()
        {

            return View();
        }

        // GET: Apply
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public JsonResult Index(ShenQing entity)
        {
            SuggestionRes response = new SuggestionRes();

            #region 各种校验

            if (string.IsNullOrWhiteSpace(entity.BaoXiuRen))
            {
                response.errorCode = 2;
                return Json(response);
            }
            if (string.IsNullOrWhiteSpace(entity.LianXiDianHua))
            {
                response.errorCode = 3;
                return Json(response);
            }
            if (string.IsNullOrWhiteSpace(entity.MiaoShu))
            {
                response.errorCode = 4;
                return Json(response);
            }
            #endregion

            Account account = GetCurrentAccount();
            entity.HuiYuanId = account.Id;
            entity.BiaoShi = account.BiaoShi;
            entity.CreatePerson = account.PersonName;

            string returnValue = string.Empty;
            IChuLiBLL m_BLL = new ChuLiBLL();
            if (!m_BLL.CreateAndCopy(ref validationErrors, entity))
            {

                if (validationErrors != null && validationErrors.Count > 0)
                {
                    validationErrors.All(a =>
                    {
                        returnValue += a.ErrorMessage;
                        return true;
                    });
                }
                response.errorCode = 99;
                response.content = returnValue;
                return Json(response);
            }

            response.errorCode = 0;
            return Json(response);
        }

        public ActionResult OK()
        {

            return View();
        }


        public ActionResult Comment(string id)
        {
            IChuLiBLL m_BLL = new ChuLiBLL();
            var item = m_BLL.GetById(id);
            return View(item);

        }
        [HttpPost]

        public ActionResult Comment(string id, ChuLi entity)
        {
            SuggestionRes response = new SuggestionRes();

            #region 各种校验
            if (!Validator.IsNumber(entity.DaFen.GetString()))
            {
                response.errorCode = 2;
                return Json(response);
            }
            if (string.IsNullOrWhiteSpace(entity.PingLun))
            {
                response.errorCode = 4;
                return Json(response);
            }

            #endregion

            string currentPerson = GetCurrentPerson();

            string returnValue = string.Empty;
            IChuLiBLL m_BLL = new ChuLiBLL();
            if (!m_BLL.Comment(ref validationErrors, entity))
            {

                if (validationErrors != null && validationErrors.Count > 0)
                {
                    validationErrors.All(a =>
                    {
                        returnValue += a.ErrorMessage;
                        return true;
                    });
                }
                response.errorCode = 1;
                response.content = returnValue;
                return Json(response);
            }

            response.errorCode = 0;
            return Json(response);


        }
        public ActionResult List()
        {
            Account account = GetCurrentAccount();
            string biaoshi = account.BiaoShi;
            IChuLiBLL m_BLL = new ChuLiBLL();
            var list = m_BLL.GetList(biaoshi);
            return View(list);

        }
        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 

        public ActionResult Edit(string id)
        {
            IChuLiBLL m_BLL = new ChuLiBLL();
            ChuLi item = m_BLL.GetById(id);
            return View(item);
        }
        /// <summary>
        /// 提交编辑信息
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="collection">客户端传回的集合</param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult Edit(string id, ShenQing entity)
        {
            entity.Id = id;
            SuggestionRes response = new SuggestionRes();

            #region 各种校验

            if (string.IsNullOrWhiteSpace(entity.BaoXiuRen))
            {
                response.errorCode = 2;
                return Json(response);
            }
            if (string.IsNullOrWhiteSpace(entity.LianXiDianHua))
            {
                response.errorCode = 3;
                return Json(response);
            }
            if (string.IsNullOrWhiteSpace(entity.MiaoShu))
            {
                response.errorCode = 4;
                return Json(response);
            }
            #endregion

            Account account = GetCurrentAccount();
            entity.HuiYuanId = account.Id;
            entity.BiaoShi = account.BiaoShi;
            entity.CreatePerson = account.PersonName;

            string returnValue = string.Empty;
            IChuLiBLL m_BLL = new ChuLiBLL();
            if (!m_BLL.EditAndCopy(ref validationErrors, entity))
            {

                if (validationErrors != null && validationErrors.Count > 0)
                {
                    validationErrors.All(a =>
                    {
                        returnValue += a.ErrorMessage;
                        return true;
                    });
                }
                response.errorCode = 99;
                response.content = returnValue;
                return Json(response);
            }

            response.errorCode = 0;
            return Json(response);


        }


        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOff()
        {
            Account account = GetCurrentAccount();

            if (account != null)
            {
                Utils.DeleteCookie("myaccount");


                return RedirectToAction("Index", "Account", new { id = account.BiaoShi });

            }
            else
            {
                Response.Redirect("http://www.langben.com/");

            }
            return View();
        }



    }
}
