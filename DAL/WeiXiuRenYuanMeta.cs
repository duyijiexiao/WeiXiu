using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(WeiXiuRenYuanMetadata))]//使用WeiXiuRenYuanMetadata对WeiXiuRenYuan进行数据验证
    public partial class WeiXiuRenYuan 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class WeiXiuRenYuanMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object Id { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "用户名", Order = 2)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object Name { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "姓名", Order = 3)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object MyName { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "单位", Order = 4)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object SchoolName { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "密码", Order = 5)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
			public object Password { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "手机号码", Order = 6)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[DataType(System.ComponentModel.DataAnnotations.DataType.PhoneNumber,ErrorMessage="号码格式不正确")]
			public object PhoneNumber { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "验证码", Order = 7)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object VCode { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "邮箱", Order = 8)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object MyEmail { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "验证码时间", Order = 9)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? CodeTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 10)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "IP地址", Order = 11)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object LogonIP { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 12)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object State { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标识", Order = 13)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object BiaoShi { get; set; }


    }
}
 

