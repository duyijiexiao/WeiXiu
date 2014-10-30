using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.IO;
 
using System.Text.RegularExpressions;
using Common;

namespace Models
{
    public  class  orderstates
    {

        
    }

    public enum states
    {
        Single = 0,//只包含单项目
        Multi = 1,//可包含多项
        UploadFile = 2,//上传文件项

//已提交，待处理
//已拒绝
//已安排，待维修
//已打回，待修改
//结束
//已维修，待评论
    }



}
