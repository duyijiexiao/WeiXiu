using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(SchoolMetadata))]//使用SchoolMetadata对School进行数据验证
    public partial class School 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class SchoolMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object Id { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "名称", Order = 2)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
            [Required(ErrorMessage="必填")]
			public object Name { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "地址", Order = 3)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
            [Required(ErrorMessage = "必填")]
			public object Address { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "排序", Order = 4)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
            [Required(ErrorMessage = "必填")]
			public int? PaiXu { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 5)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 6)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object State { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标识", Order = 7)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object BiaoShi { get; set; }


    }
}
 

