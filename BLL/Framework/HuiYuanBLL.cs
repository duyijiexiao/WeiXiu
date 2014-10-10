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
    public partial class HuiYuanBLL :  IBLL.IHuiYuanBLL, IDisposable
    {
        public int ShenHe(string ids,string State)
        {
         return repository.ShenHe(db, ids, State);
        }

    }
}

