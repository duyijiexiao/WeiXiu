using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(GenZongMetadata))]//使用GenZongMetadata对GenZong进行数据验证
    public partial class GenZong 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "维修申请")]
        public string ShenQingIdOld { get; set; }
        
        #endregion

    }
    public partial class GenZongMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object Id { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "记录", Order = 2)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			public object JiLu { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "类型", Order = 3)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object LeiXing { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 4)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 5)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "备注", Order = 6)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			public object Remark { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "维修处理", Order = 7)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			public object ChuLiId { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "维修申请", Order = 8)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			public object ShenQingId { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标识", Order = 9)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object BiaoShi { get; set; }


    }
}
 

