using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Langben.DAL;
using Common;

namespace Langben.BLL
{
    /// <summary>
    /// 会员 
    /// </summary>
    public partial class HuiYuanBLL : IBLL.IHuiYuanBLL, IDisposable
    {
        public int ShenHe(string ids, string State)
        {
            return repository.ShenHe(db, ids, State);
        }

        public HuiYuan GetByPhone(string phone, string pwd, string biaoshi)
        {
            return repository.GetByPhone(db, phone, pwd, biaoshi);
        }

        public HuiYuan NewPassword(string phone, string pwd, string biaoshi)
        {
            return repository.NewPassword(db, phone, pwd, biaoshi);
        }
        public bool IsPhone(string phone, string biaoshi)
        {
            return repository.IsPhone(db, phone, biaoshi);
        }
    }
}

