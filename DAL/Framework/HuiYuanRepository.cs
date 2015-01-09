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
        public HuiYuan GetByPhone(SysEntities db, string phone, string pwd, string biaoshi)
        {
            return db.HuiYuan.SingleOrDefault(s => s.PhoneNumber == phone && s.Password == pwd && s.BiaoShi == biaoshi && s.State == "已审核");

        }
        public HuiYuan GetByPhoneVC(SysEntities db, string phone, string vc, string biaoshi)
        {
            return db.HuiYuan.SingleOrDefault(s => s.PhoneNumber == phone  && s.BiaoShi == biaoshi && s.State == "已审核" && s.VCode == vc);

        }
        public HuiYuan GetByPhone(SysEntities db, string phone,  string biaoshi)
        {
            return db.HuiYuan.SingleOrDefault(s => s.PhoneNumber == phone &&  s.BiaoShi == biaoshi);

        }
        public HuiYuan SetVC(SysEntities db, string phone,string vc, string biaoshi)
        {
            var data= db.HuiYuan.SingleOrDefault(s => s.PhoneNumber == phone && s.BiaoShi == biaoshi);
            if (data!=null)
            {
                data.VCode = vc.Trim();
                data.CodeTime = DateTime.Now;
                data.CodeNum++;
                db.SaveChanges();

            }
            return data;
        }
        public HuiYuan NewPassword(SysEntities db, string phone, string pwd, string biaoshi)
        {
            return db.HuiYuan.SingleOrDefault(s => s.PhoneNumber == phone && s.Password == pwd && s.BiaoShi == biaoshi && s.State == "已审核");

        }
        public bool IsPhone(SysEntities db, string phone, string biaoshi)
        {
            var data = db.HuiYuan.FirstOrDefault(s => s.PhoneNumber == phone && s.BiaoShi == biaoshi);
            if (data == null)
            {
                return false;
            }
            return true;
        }



        /// <summary>
        /// 根据id审核
        /// </summary>
        /// <param name="id"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        public int ShenHe(SysEntities db, string ids, string State)
        {
            string sql = string.Format("update huiyuan set State='{0}' where id in({1})", State, ids);
            return db.Database.ExecuteSqlCommand(sql);
        }
    }
}

