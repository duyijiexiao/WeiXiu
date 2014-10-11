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
            List<string> list = ids.Split(',').ToList();
            IQueryable<HuiYuan> entity = from o in db.HuiYuan where list.Contains(o.Id) select o;
            IQueryable<HuiYuan>  entList = Edit(db, entity);
            List<HuiYuan> ent = entList.ToList();
            foreach (HuiYuan item in ent)
            {
                item.State = State;
            }
            return db.SaveChanges();
        }
        public IQueryable<HuiYuan> Edit(SysEntities db, IQueryable<HuiYuan> entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity;
        }
    }
}

