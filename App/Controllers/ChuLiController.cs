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

namespace Langben.App.Controllers
{
    /// <summary>
    /// 维修处理
    /// </summary>
    public class ChuLiController : BaseController
    {

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index()
        {
        
            return View();
        }
         /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexSef()
        {

            return View();
        }


        /// <summary>
        /// 统计列表
        /// </summary>
        /// <returns></returns>
        public ActionResult TongjiIndex()
        {

            return View();
        } 
        /// <summary>
        /// 处理反馈Index
        /// </summary>
        /// <returns></returns>
        public ActionResult FKIndex()
        {
            return View();
        }
        /// <summary>
        /// 处理反馈Create
        /// </summary>
        /// <returns></returns>
        public ActionResult FKCreate()
        {
            return View();
        }
        /// <summary>
        /// 处理反馈Details
        /// </summary>
        /// <returns></returns>
        public ActionResult FKDetails()
        {
            return View();
        }
        /// <summary>
        /// 处理反馈Edit
        /// </summary>
        /// <returns></returns>
        public ActionResult FKEdit()
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
        public JsonResult GetTjData(string id, int page, int rows, string order, string sort, string search)
        {

            int total = 0;
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
                    PaiXu = s.PaiXu
                    ,
                    Remark = s.Remark
                    ,
                    State = s.State
                    ,
                    HuiYuanId = s.HuiYuanId
                    ,
                    JuJueLiYou = s.JuJueLiYou
                    ,
                    JuJueShiJian = s.JuJueShiJian
                    ,
                    Anpai = s.Anpai
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
                    BiaoShi = s.BiaoShi

                }

                    )
            });
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
            List<ChuLi> queryData = m_BLL.GetByParam(id, page, rows, order, sort, search, ref total);
            return Json(new datagrid
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    Id = s.Id
					,XueXiao = s.XueXiao
					,BaoXiuRen = s.BaoXiuRen
					,LianXiDianHua = s.LianXiDianHua
					,MiaoShu = s.MiaoShu
					,TuPian = s.TuPian
					,PaiXu = s.PaiXu
					,Remark = s.Remark
					,State = s.State
					,HuiYuanId = s.HuiYuanId
					,JuJueLiYou = s.JuJueLiYou
					,JuJueShiJian = s.JuJueShiJian
					,Anpai = s.Anpai
					,AnPaiShiJian = s.AnPaiShiJian
					,FanKui = s.FanKui
					,FanKuiTuPian = s.FanKuiTuPian
					,FanKuiShiJian = s.FanKuiShiJian
					,ShenQingId = s.ShenQingId
					,BiaoShi = s.BiaoShi
					
                }

                    )
            });
        }
        /// <summary>
        ///  导出Excle /*在6.0版本中 新增*/
        /// </summary>
        /// <param name="param">Flexigrid传过到后台的参数</param>
        /// <returns></returns>      
        [HttpPost]
        public ActionResult Export(string id, string title, string field, string sortName, string sortOrder, string search)
        {
            string[] titles = title.Split(',');//如果确定显示的名称，可以直接定义
            string[] fields = field.Split(',');
            List<ChuLi> queryData = m_BLL.GetByParam(id, sortOrder, sortName, search);
             
            return Content(WriteExcle(titles, fields, queryData.ToArray()));  
        }
        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SupportFilter]  
        public ActionResult Details(string id)
        {
            ChuLi item = m_BLL.GetById(id);
            return View(item);

        }
 
        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Create(string id)
        { 
            
            return View();
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [SupportFilter]
        public ActionResult Create(ChuLi entity)
        {           
            if (entity != null && ModelState.IsValid)
            {
                string currentPerson = GetCurrentPerson();
                //entity.CreateTime = DateTime.Now;
                //entity.CreatePerson = currentPerson;
              
                entity.Id = Result.GetNewId();   
                string returnValue = string.Empty;
                if (m_BLL.Create(ref validationErrors, entity))
                {
                    GenZong gzg=new GenZong();
                    gzg.BiaoShi=entity.BiaoShi;
                    gzg.ChuLiId=entity.Id;
                    gzg.CreatePerson="";
                    gzg.CreateTime=DateTime.Now;
                    gzg.Id = Result.GetNewId();  
                    gzg.JiLu = "";
                    if (string.IsNullOrEmpty(entity.FanKui))
                        gzg.LeiXing = "维修处理";
                    else
                        gzg.LeiXing = "维修处理反馈";
                    gzg.Remark = "";
                    gzg.ShenQing = null;
                    gzg.ShenQingId =entity.ShenQingId ;
                    gzg.ShenQingIdOld = "";
                    GenZongController ddd = new GenZongController();
                    ddd.Create(gzg);
                    LogClassModels.WriteServiceLog(Suggestion.InsertSucceed  + "，维修处理的信息的Id为" + entity.Id,"维修处理"
                        );//写入日志 
                    //return Json(Suggestion.InsertSucceed);
                    if (Request.Url.AbsoluteUri.ToString().IndexOf("FKCreate") > 0)
                    {
                        
                        return Json(Suggestion.InsertSucceed);//return Redirect("/Chuli/FKIndex");//
                    }
                    else
                    {
                        return Json(Suggestion.InsertSucceed); //return Redirect("/Chuli/Index");//
                    }
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
                    LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，维修处理的信息，" + returnValue,"维修处理"
                        );//写入日志                      
                    return Json(Suggestion.InsertFail  + returnValue); //提示插入失败
                }
            }

            return Json(Suggestion.InsertFail + "，请核对输入的数据的格式"); //提示输入的数据的格式不对 
        }
        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        [SupportFilter] 
        public ActionResult Edit(string id)
        {
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
        [SupportFilter]
        public ActionResult Edit(string id, ChuLi entity)
        {
            if (entity != null && ModelState.IsValid)
            {   //数据校验
            
                string currentPerson = GetCurrentPerson();                 
                //entity.UpdateTime = DateTime.Now;
                //entity.UpdatePerson = currentPerson;
                           
                string returnValue = string.Empty;   
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    GenZong gzg = new GenZong();
                    gzg.BiaoShi = entity.BiaoShi;
                    gzg.ChuLiId = entity.Id;
                    gzg.CreatePerson = "";
                    gzg.CreateTime = DateTime.Now;
                    gzg.Id = Result.GetNewId();
                    gzg.JiLu = "";
                    if (string.IsNullOrEmpty(entity.FanKui))
                        gzg.LeiXing = "维修处理";
                    else
                        gzg.LeiXing = "维修处理反馈";
                    gzg.Remark = "";
                    gzg.ShenQing = null;
                    gzg.ShenQingId = entity.ShenQingId;
                    gzg.ShenQingIdOld = "";
                    GenZongController ddd = new GenZongController();
                    ddd.Create(gzg);
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，维修处理信息的Id为" + id,"维修处理"
                        );//写入日志                           
                    //return Json(Suggestion.UpdateSucceed); //提示更新成功 
                    if (Request.Url.AbsoluteUri.ToString().IndexOf("FKEdit") > 0)
                    {
                        return Json(Suggestion.InsertSucceed); //return Redirect("/Chuli/FKIndex");//
                    }
                    else
                    {
                        return Json(Suggestion.InsertSucceed);
                    }
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，维修处理信息的Id为" + id + "," + returnValue, "维修处理"
                        );//写入日志                           
                    return Json(Suggestion.UpdateFail  + returnValue); //提示更新失败
                }
            }
            return Json(Suggestion.UpdateFail + "请核对输入的数据的格式"); //提示输入的数据的格式不对               
          
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>   
        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            string returnValue = string.Empty;
            string[] deleteId = collection["query"].GetString().Split(',');
            if (deleteId != null && deleteId.Length > 0)
            { 
                if (m_BLL.DeleteCollection(ref validationErrors, deleteId))
                {
                    GenZong gzg = new GenZong();
                    gzg.BiaoShi = "";
                    gzg.ChuLiId = "";
                    gzg.CreatePerson = "";
                    gzg.CreateTime = DateTime.Now;
                    gzg.Id = Result.GetNewId();
                    gzg.JiLu = "";
                    gzg.LeiXing = "维修处理删除";
                    gzg.Remark = deleteId.ToString();
                    gzg.ShenQing = null;
                    gzg.ShenQingId = "";
                    gzg.ShenQingIdOld = "";
                    GenZongController ddd = new GenZongController();
                    ddd.Create(gzg);
                    LogClassModels.WriteServiceLog(Suggestion.DeleteSucceed + "，信息的Id为" + string.Join(",", deleteId), "消息"
                        );//删除成功，写入日志
                    return Json("OK");
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
                    LogClassModels.WriteServiceLog(Suggestion.DeleteFail + "，信息的Id为" + string.Join(",", deleteId)+ "," + returnValue, "消息"
                        );//删除失败，写入日志
                }
            }
            return Json(returnValue);
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


