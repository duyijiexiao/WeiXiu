using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
//using Langben.BLL;
//using Langben.IBLL;
//using Langben.DAL;

namespace Models
{
    /// <summary>
    ///  此处实现数据字典的功能
    /// </summary>
    public class SysFieldModels
    {

        /// <summary>
        /// 获取字段，首选默认
        /// </summary>
        /// <returns></returns>
        public static SelectList GetSysField(string table, string colum, string parentMyTexts)
        {
            //if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(colum) || string.IsNullOrWhiteSpace(parentMyTexts))
            {
                List<SelectList> sl = new List<SelectList>();
                return new SelectList(sl);
            }
            //ISysFieldHander baseDDL = new SysFieldHander();
            //return new SelectList(baseDDL.GetSysField(table, colum, parentMyTexts), "MyTexts", "MyTexts");

        }
        /// <summary>
        /// 获取字段，首选默认，MyTexts做为value值
        /// </summary>
        /// <returns></returns>
        public static SelectList GetSysField(string table, string colum)
        {
            //if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(colum))
            {
                List<SelectList> sl = new List<SelectList>();
                return new SelectList(sl);
            }
            //ISysFieldHander baseDDL = new SysFieldHander();
            //return new SelectList(baseDDL.GetSysField(table, colum), "MyTexts", "MyTexts");

        }
        public static SelectList GetState()
        {
            List<object> sl = new List<object>();
            sl.Add(new { Id = "未审核", Text = "未审核" });
            sl.Add(new { Id = "已审核", Text = "已审核" });
            return new SelectList(sl,"Id","Text");
        }
        public static SelectList GetState1()
        {
            List<object> sl = new List<object>();
            sl.Add(new { Id = "已提交/待处理", Text = "已提交/待处理" });
              sl.Add(new { Id = "已安排/待维修", Text = "已安排/待维修" });
              sl.Add(new { Id = "已打回/待修改", Text = "已打回/待修改" });
              sl.Add(new { Id = "已维修/待评论", Text = "已维修/待评论" });
            sl.Add(new { Id = "已拒绝", Text = "已拒绝" });
                     sl.Add(new { Id = "结束", Text = "结束" });
            return new SelectList(sl, "Id", "Text");
        }
        /// <summary>
        /// 获取字段，首选默认，Id做为value值
        /// </summary>
        /// <returns></returns>
        public static SelectList GetSysFieldById(string table, string colum)
        {
            //if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(colum))
            {
                List<SelectList> sl = new List<SelectList>();
                return new SelectList(sl);
            }
            //ISysFieldHander baseDDL = new SysFieldHander();
            //return new SelectList(baseDDL.GetSysField(table, colum), "Id", "MyTexts");

        }
        /// <summary>
        /// 根据主键id，获取数据字典的展示字段
        /// </summary>
        /// <param name="id">父亲节点的主键</param>
        /// <returns></returns>
        public static string GetMyTextsById(string id)
        {
            //if (string.IsNullOrWhiteSpace(id))
            {
                return string.Empty;
            }
            //ISysFieldHander baseDDL = new SysFieldHander();
            //return baseDDL.GetMyTextsById(id);

        }
    }
}
