using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Web.Models;
using Langben.BLL;
using Langben.DAL;
using Models;
using Common;

namespace Web.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        private void Check(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                ViewBag.Id = id;

            }
            else
            {
                Response.Redirect("http://www.langben.com/");
            }

            return;
        }
        public ActionResult Index(string id)
        {
            Check(id);
            return View();

        }
        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            SuggestionRes response = new SuggestionRes();

            #region 各种校验
            if (string.IsNullOrWhiteSpace(model.BiaoShi))
            {//标识是否存在
                response.errorCode = 11;
                return Json(response);
            }

            if (string.IsNullOrWhiteSpace(model.UserName))
            {
                response.errorCode = 2;
                return Json(response);
            }
            if (string.IsNullOrWhiteSpace(model.Password))
            {
                response.errorCode = 3;
                return Json(response);
            }
            if (model.UserName.Length > 50)
            {
                response.errorCode = 4;
                return Json(response);
            }
            if (model.Password.Length > 20 || model.Password.Length < 6)
            {
                response.errorCode = 5;
                return Json(response);
            }

            #endregion

            Langben.IBLL.IHuiYuanBLL m_BLL = new HuiYuanBLL();
            ValidationErrors validationErrors = new ValidationErrors();

            HuiYuan item = m_BLL.GetByPhone(model.UserName, model.Password, model.BiaoShi);
            if (item != null)
            {
                if (item.State == "未审核")
                {
                    response.errorCode = 6;
                }
                else
                {
                    //写cookie
                    Account account = new Account();
                    account.Name = item.MyName;
                    account.PersonName = item.Name;
                    account.Id = item.Id;
                    account.BiaoShi = model.BiaoShi;
                    Utils.WriteCookie("account", account, 7);
                    Utils.WriteCookie("BiaoShi", model.BiaoShi, 7);
                    response.errorCode = 0;
                }
            }
            else
            {
                response.errorCode = 1;

            }
            return Json(response);

        }
        public ActionResult Register(string id)
        {
            Check(id);

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            SuggestionRes response = new SuggestionRes();

            #region 各种校验

            if (string.IsNullOrWhiteSpace(model.BiaoShi))
            {//标识是否存在
                response.errorCode = 11;
                return Json(response);
            }
            var vali = Validator.IsPassword(model.Password);
            if (vali != 0)
            {//标识是否存在
                response.errorCode = vali;
                return Json(response);
            }

            if (model.Password != model.ConfirmPassword)
            {
                response.errorCode = 9;
                return Json(response);
            }
            if (string.IsNullOrWhiteSpace(model.UserName))
            {
                response.errorCode = 20;
                return Json(response);
            }
            if (model.UserName.Length > 50)
            {
                response.errorCode = 21;
                return Json(response);
            }
            if (!Validator.IsMobile(model.UserName))
            {
                response.errorCode = 22;
                return Json(response);
            }


            #endregion

            Langben.IBLL.IHuiYuanBLL m_BLL = new HuiYuanBLL();

            if (m_BLL.IsPhone(model.UserName, model.BiaoShi))
            {
                response.errorCode = 23;
                return Json(response);
            }
            ValidationErrors validationErrors = new ValidationErrors();

            HuiYuan entity = new HuiYuan()
            {
                Password = model.Password
                ,
                PhoneNumber = model.UserName
                ,
                CreateTime = DateTime.Now
                ,
                BiaoShi = model.BiaoShi
                ,
                State = "未审核"
                ,
                LogonIP = Common.IP.GetIP()
                

            };
            entity.Id = Result.GetNewId();
            string returnValue = string.Empty;
            if (m_BLL.Create(ref validationErrors, entity))
            {
                response.errorCode = 0;
                return Json(response);
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
                //LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，注册的信息，" + returnValue, "注册"
                //      );//写入日志   
                response.errorCode = 99;
                return Json(response);         //提示插入失败
            }


        }


        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }

    }
}