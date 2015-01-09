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
    public class PassportController : Controller
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
        public ActionResult Index(string id, string validCode, string phone)
        {
            SuggestionRes response = new SuggestionRes();

            #region 各种校验
            if (string.IsNullOrWhiteSpace(validCode))
            {
                response.errorCode = 1;
                return Json(response);
            }

            if (string.IsNullOrWhiteSpace(phone) || (!Validator.IsPhone(phone)))
            {
                response.errorCode = 2;
                return Json(response);
            }

            if (string.IsNullOrWhiteSpace(validCode))
            {
                response.errorCode = 3;
                return Json(response);
            }
            if (Session["__VCode"] == null || (Session["__VCode"].ToString() != validCode))
            {

                response.errorCode = 6;
                return Json(response);

            }

            #endregion
            IHuiYuanBLL m_BLL = new HuiYuanBLL();
            response.errorCode = m_BLL.GetByPhone(phone, id);
            //如果成功了，将手机号放入cookies中 
            Utils.WriteCookie("PhoneFind", phone, 1);


            return Json(response);
        }
        public ActionResult FindPassword(string id)
        {
            Check(id);
            //从cookies中获取手机号码 
            string phone = "";
            ViewBag.Phone = phone;//格式：137****1828
            return View();
        }
        [HttpPost]
        public ActionResult FindPassword(string id, string validCode)
        {
            SuggestionRes response = new SuggestionRes();

            #region 各种校验



            #endregion
            //校验验证码是否正确
            //如果正确
            var vcode = Utils.ReadCookie("vcode");
            //从cookies中获取手机号码 
            var phone = Utils.ReadCookie("PhoneFind");
            IHuiYuanBLL m_BLL = new HuiYuanBLL();
            var data = m_BLL.GetByPhoneVC(phone, vcode, id);
            if (data != null)
            {
                response.errorCode = 0;

            }
            else
            {
                response.errorCode = 1;
            }

            return Json(response);
        }
        [HttpPost]
        public ActionResult SendMobileCheckCode(string id)
        {
            SuggestionRes response = new SuggestionRes();

            #region 各种校验
            //从cookies中获取手机号码 
            var phone = Utils.ReadCookie("PhoneFind");
            if (string.IsNullOrWhiteSpace(phone))
            {
                response.errorCode = 2;
                return Json(response);
            }
            //验证手机号的状态是否是启用，并且标识（id）也正确
            //验证码的时间不能超过半小时

            #endregion
            //随机生成六位数字，并更新到数据库，还有当前时间
            string vnum = Utils.GetByRndNum(6);


            IHuiYuanBLL m_BLL = new HuiYuanBLL();
            response.errorCode = m_BLL.SetVC(phone, vnum, id);
            if (response.errorCode == 0)
            {
                //向手机发送验证码
                ServiceReference1.MessageServiceSoapClient client = new ServiceReference1.MessageServiceSoapClient();
                ServiceReference1.Mess mess = new ServiceReference1.Mess();
                mess.Message1 = "【维修】"+vnum;
                mess.Phone = phone;
                mess.Token = "weixiu123?";
                var data = client.MessageAdd(mess);
                if (data!=1)
                {
                   
                }
                //使用cookies记录验证码，过期时间为1小时
                Utils.WriteCookie("vcode", vnum, 0.1);
            }

            return Json(response);
        }
        public ActionResult NewPassword(string id)
        {
            Check(id);
            return View();
        }
        [HttpPost]
        public ActionResult NewPassword(string id, string newpassword, string password)
        {
            SuggestionRes response = new SuggestionRes();

            #region 各种校验






            // 获取cookies记录的验证码，如果不存在，就给出过期提示，如果存在，则销毁cookies，从安全角度考虑
            string vcode = Utils.ReadCookie("vcode");
            if (string.IsNullOrWhiteSpace(vcode))
            {
                response.errorCode = 1;
                return Json(response);
            }
            else
            {
                Utils.DeleteCookie("vcode");
            }
            #endregion
            //从cookies中获取手机号码phone
            //安全，拒绝漏洞
            //将用户信息写入cookies，这样在下一个页面就可以自动登录了


            string phone = Utils.ReadCookie("PhoneFind");
            if (string.IsNullOrWhiteSpace(phone))
            {
                response.errorCode = 1;
                return Json(response);
            }
            else
            {
                Utils.DeleteCookie("PhoneFind");
            }
            Langben.IBLL.IHuiYuanBLL m_BLL = new HuiYuanBLL();
            ValidationErrors validationErrors = new ValidationErrors();

            HuiYuan item = m_BLL.NewPassword(phone, newpassword, id);
            if (item != null)
            {
                //写cookie
                Account account = new Account();
                account.Name = item.MyName;
                account.PersonName = item.Name;
                account.Id = item.Id;
                account.BiaoShi = id;

                Utils.WriteCookie("myaccount", account, 7);
                Utils.WriteCookie("BiaoShi", id, 7);
                response.errorCode = 0;

            }
            else
            {
                response.errorCode = 1;
            }

            return Json(response);
        }

        public ActionResult Success()
        {
            return View();
        }



    }
}