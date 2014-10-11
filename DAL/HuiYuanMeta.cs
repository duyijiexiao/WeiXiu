using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(HuiYuanMetadata))]//使用HuiYuanMetadata对HuiYuan进行数据验证
    public partial class HuiYuan 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class HuiYuanMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object Id { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "学校单位", Order = 2)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object Name { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "姓名", Order = 3)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object MyName { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "密码", Order = 4)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
			public object Password { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "手机号码", Order = 5)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
            [RegularExpression(@"13[0-9]{9}$|14[0-9]{9}|15[0-9]{9}$|18[0-9]{9}", ErrorMessage = "格式不正确")]
			public object PhoneNumber { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "邮箱", Order = 6)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
            [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "{0}的格式不正确")]
			public object MyEmail { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 7)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "IP地址", Order = 8)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object LogonIP { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 9)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object State { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标识", Order = 10)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object BiaoShi { get; set; }


    }
}
 

