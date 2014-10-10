using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace Langben.DAL
{
    /// <summary>
    /// 会员
    /// </summary>
    public partial class HuiYuanRepository : BaseRepository<HuiYuan>, IDisposable
    {
        /// <summary>
        /// 根据id审核
        /// </summary>
        /// <param name="id"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        public int ShenHe(SysEntities db,string ids,string State)
        {
            var entity=from o in db.HuiYuan where o.Id.Contains(ids) select o;
            int result= 0;//db.HuiYuan
            return result;
        }
    }
}

