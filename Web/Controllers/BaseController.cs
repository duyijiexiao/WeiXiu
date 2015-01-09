using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Common;
using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;


using System.IO;
using System.Data;

using System.Web;
using Langben.DAL;
namespace  Models
{
    //[SupportFilter]//此处如果去掉注释，则全部继承BaseController的Controller，都将执行SupportFilter过滤
    public class BaseController : Controller
    {
        protected void Check(string id)
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
        
      

          /// <summary>
        /// 获取当前登陆人的用户名
        /// </summary>
        /// <returns></returns>
        public string GetCurrentPerson()
        {
            return AccountModel.GetCurrentPerson();


        }
        /// <summary>
        /// 获取当前登陆人的账户信息
        /// </summary>
        /// <returns>账户信息</returns>
        public Account GetCurrentAccount()
        {
            var account = AccountModel.GetCurrentAccount();

            return account;
        }


         //<summary>
         //重写基类在Action之前执行的方法
         //</summary>
         //<param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            //Account account = GetCurrentAccount();
            //if (account == null)
            //{
            //   // return Content("<script type='text/javascript'> window.top.location = 'Account'; </script>");

            //    Response.Redirect("/Account/Login");
            //}
        }

     


    
   }
}
