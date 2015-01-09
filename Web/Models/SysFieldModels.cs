using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Langben.BLL;
using Langben.IBLL;
using Langben.DAL;
using Common;

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

            Account account = AccountModel.GetCurrentAccount();
            string biaoshi = account.BiaoShi;
            ISchoolBLL baseDDL = new SchoolBLL();
            var ar = baseDDL.GetByBiaoShi(biaoshi);
            return new SelectList(baseDDL.GetByBiaoShi(biaoshi), "Name", "Name");


        }

    }
}
