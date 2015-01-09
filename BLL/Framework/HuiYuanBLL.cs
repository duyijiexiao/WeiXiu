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
        public HuiYuan GetByPhoneVC(string phone, string pwd, string biaoshi)
        {
            return repository.GetByPhoneVC(db, phone, pwd, biaoshi);
        }
        public HuiYuan GetByPhone(string phone, string pwd, string biaoshi)
        {
            return repository.GetByPhone(db, phone, pwd, biaoshi);
        }
        public int GetByPhone(string phone, string biaoshi)
        {

            var data = repository.GetByPhone(db, phone, biaoshi);
            if (data != null)
            {
                if (data.State == "未审核")
                {
                    return 5;
                }
                if (data.CodeNum > 5)
                {
                    return 15;
                }
                return 0;
            }
            else
            {
                return 4;
            }

        }
        public int SetVC(string phone,string vc, string biaoshi)
        {

            var data = repository.SetVC(db, phone,vc, biaoshi);
            if (data != null)
            {
                if (data.State == "未审核")
                {
                    return 5;
                }
                if (data.CodeNum > 5)
                {
                    return 15;
                }
                return 0;
            }
            else
            {
                return 4;
            }

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

