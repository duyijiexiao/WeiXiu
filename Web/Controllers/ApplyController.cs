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

        Langben.IBLL.IShenQingBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public ApplyController()
            : this(new ShenQingBLL()) { }

        public ApplyController(ShenQingBLL bll)
        {
            m_BLL = bll;
        }

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
            entity.CreateTime = DateTime.Now;
            entity.BiaoShi = account.BiaoShi;
            entity.CreatePerson = account.PersonName;
            entity.State = "已提交";
            entity.Id = Result.GetNewId(); 

            string returnValue = string.Empty;
            if (!m_BLL.Create(ref validationErrors, entity))
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
            ShenQing item = m_BLL.GetById(id);
            return View(item);

        }
        [HttpPost]

        public ActionResult Comment(string id, ShenQing entity)
        {
            SuggestionRes response = new SuggestionRes();

            #region 各种校验



            #endregion

            string currentPerson = GetCurrentPerson();
            //entity.CreateTime = DateTime.Now;

            //entity.CreatePerson = currentPerson;
            entity.State = "已评论";
            //entity.Id = Result.GetNewId().Substring(0, 12).ToString();
            string returnValue = string.Empty;
            if (!m_BLL.Edit(ref validationErrors, entity))
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

            ViewBag.PersonName = account.PersonName;

            IShenQingBLL baseDDL = new ShenQingBLL();
            List<ShenQing> list = baseDDL.GetAll();
            return View(list);

        }
        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 

        public ActionResult Edit(string id)
        {
            ShenQing item = m_BLL.GetById(id);
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


            if (entity != null && ModelState.IsValid)
            {   //数据校验
                entity.CreateTime = DateTime.Now;

                //string currentPerson = GetCurrentPerson();
                //entity.UpdateTime = DateTime.Now;
                //entity.UpdatePerson = currentPerson;


                string returnValue = string.Empty;
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    // LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，维修申请信息的Id为" + id, "维修申请"
                    // );//写入日志                           
                    //  return Json(Suggestion.UpdateSucceed); //提示更新成功 

                    return RedirectToAction("List", "Apply");
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    //LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，维修申请信息的Id为" + id + "," + returnValue, "维修申请"
                    //    );//写入日志                           
                    return Json(Suggestion.UpdateFail + returnValue); //提示更新失败
                }
            }
            return Json(Suggestion.UpdateFail + "请核对输入的数据的格式"); //提示输入的数据的格式不对               

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
                Utils.DeleteCookie("account");
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
