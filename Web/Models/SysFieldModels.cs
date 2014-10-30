using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Langben.BLL;
using Langben.IBLL;
using Langben.DAL;

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
        public static SelectList GetSysField()
        {


            ISchoolBLL baseDDL = new SchoolBLL();
            return new SelectList(baseDDL.GetAll(), "Name", "Name");
           

        }
     
    }
}
