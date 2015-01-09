using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;
using Models;
using Common;
using Langben.DAL;
using Langben.BLL;
using Langben.App.Models;
using Senparc.Weixin.QY.CommonAPIs;
using Senparc.Weixin.QY.AdvancedAPIs;
using Senparc.Weixin;
using Senparc.Weixin.QY;
using Senparc.Weixin.QY.Entities;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 维修处理
    /// </summary>
    public class ChuLiController : BaseController
    {

        [HttpPost]
        public ActionResult UpdataAnPai(ChuLi entity)
        {
            if (entity != null && ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(entity.Anpai))
                {
                    return Content("请选择维修人员");
                }
                string returnValue = string.Empty;

                if (m_BLL.EditAndShenQing(ref validationErrors, entity))
                {
                   
                 


                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，信息的Id为" + entity.Id, "安排"
                        );//写入日志                           
                    return Content("成功");//提示更新成功 
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，信息的Id为" + entity.Id + "," + returnValue, "安排"
                        );//写入日志                           
                    return Content(Suggestion.UpdateFail + returnValue); //提示更新失败
                }

            }

            return Content(Suggestion.InsertFail + "，请核对输入的数据的格式"); //提示输入的数据的格式不对 


        }
        [HttpPost]
        public ActionResult UpdataJJ(ChuLi entity)
        {
            if (entity != null && ModelState.IsValid)
            {
                string returnValue = string.Empty;

                if (m_BLL.EditState(ref validationErrors, entity, "已拒绝"))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，信息的Id为" + entity.Id, "拒绝"
                        );//写入日志                           
                    return Content("成功");//提示更新成功 
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，信息的Id为" + entity.Id + "," + returnValue, "拒绝"
                        );//写入日志                           
                    return Content(Suggestion.UpdateFail + returnValue); //提示更新失败
                }

            }

            return Content(Suggestion.InsertFail + "，请核对输入的数据的格式"); //提示输入的数据的格式不对 


        }
        [HttpPost]
        public ActionResult UpdataDH(ChuLi entity)
        {
            if (entity != null && ModelState.IsValid)
            {
                string returnValue = string.Empty;

                if (m_BLL.EditState(ref validationErrors, entity, "已打回"))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，信息的Id为" + entity.Id, "打回"
                        );//写入日志                           
                    return Content("成功");//提示更新成功 
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，信息的Id为" + entity.Id + "," + returnValue, "打回"
                        );//写入日志                           
                    return Content(Suggestion.UpdateFail + returnValue); //提示更新失败
                }

            }

            return Content(Suggestion.InsertFail + "，请核对输入的数据的格式"); //提示输入的数据的格式不对 


        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
      
        public ActionResult Index()
        {

            return View();
        }



        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetData(string id, int page, int rows, string order, string sort, string search)
        {

            int total = 0;
            Account account = GetCurrentAccount(); string biaoshi = account.BiaoShi; search += "^BiaoShi&" + biaoshi;
            List<ChuLi> queryData = m_BLL.GetByParam(id, page, rows, order, sort, search, ref total);
            return Json(new datagrid
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    Id = s.Id
                    ,
                    XueXiao = s.XueXiao
                    ,
                    BaoXiuRen = s.BaoXiuRen
                    ,
                    LianXiDianHua = s.LianXiDianHua
                    ,
                    MiaoShu = s.MiaoShu
                    ,
                    TuPian = s.TuPian
                    ,
                    TuPianSmall = s.TuPianSmall
                    ,
                    PaiXu = s.PaiXu
                    ,
                    Remark = s.Remark
                    ,
                    State = s.State,
                    YuYue = s.YuYue
                    ,
                    HuiYuanId = s.HuiYuanId
                    ,
                    JuJueLiYou = s.JuJueLiYou
                    ,
                    JuJueShiJian = s.JuJueShiJian
                    ,
                    AnpaiName = s.AnpaiName
                    ,
                    AnpaiName = s.AnpaiName
                    ,
                    AnPaiShiJian = s.AnPaiShiJian
                    ,
                    FanKui = s.FanKui
                    ,
                    FanKuiTuPian = s.FanKuiTuPian
                    ,
                    FanKuiShiJian = s.FanKuiShiJian
                    ,
                    ShenQingId = s.ShenQingId
                    ,
                    ShenQingShiJian = s.CreateTime
                    ,
                    BiaoShi = s.BiaoShi

                })
            });
        }


        IBLL.IChuLiBLL m_BLL;


        ValidationErrors validationErrors = new ValidationErrors();

        public ChuLiController()
            : this(new ChuLiBLL()) { }

        public ChuLiController(ChuLiBLL bll)
        {
            m_BLL = bll;
        }

    }
}


