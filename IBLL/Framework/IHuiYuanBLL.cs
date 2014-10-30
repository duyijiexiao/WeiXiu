using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 会员 接口
    /// </summary>
    public partial interface IHuiYuanBLL
    {
    /// <summary>
    /// 审核会员
    /// </summary>
    /// <param name="ids">id组合</param>
    /// <param name="state">状态值</param>
    /// <returns></returns>
     [OperationContract]
     int ShenHe(string ids,string State);
     /// <summary>
     /// 根据电话号码，查看详细信息
     /// </summary>
     /// <param name="id">根据电话号码</param>
     /// <returns></returns>
     [OperationContract]
     HuiYuan GetByPhone(string phone, string pwd, string biaoshi);
     /// <summary>
     /// 找回密码
     /// </summary>
     /// <param name="phone"></param>
     /// <param name="pwd"></param>
     /// <param name="biaoshi"></param>
     /// <returns></returns>
     [OperationContract]
     HuiYuan NewPassword(string phone, string pwd, string biaoshi);

     [OperationContract]
     bool IsPhone(string phone, string biaoshi);
    }
}

