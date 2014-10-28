using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(CompanyMetadata))]//使用CompanyMetadata对Company进行数据验证
    public partial class Company 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class CompanyMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object Id { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "手机号", Order = 2)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[DataType(System.ComponentModel.DataAnnotations.DataType.PhoneNumber,ErrorMessage="号码格式不正确")]
			public object PhoneNumber { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "邮箱", Order = 3)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object MyEmail { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "联系人姓名", Order = 4)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object PersonName { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "公司名称", Order = 5)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object CompanyName { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "公司地址", Order = 6)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object MyName { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "密码", Order = 7)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
			public object Password { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "固定电话", Order = 8)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object PersonPhone { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "联系人手机号", Order = 9)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object PersonPhoneNumber { get; set; }

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
			[Display(Name = "备注", Order = 13)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object Remark { get; set; }


    }
}
 

