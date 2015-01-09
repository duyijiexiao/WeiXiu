using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(ChuLiMetadata))]//使用ChuLiMetadata对ChuLi进行数据验证
    public partial class ChuLi 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class ChuLiMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object Id { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "单位", Order = 2)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object XueXiao { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "报修人", Order = 3)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object BaoXiuRen { get; set; }

			[ScaffoldColumn(true)]
            [Display(Name = "联系方式", Order = 4)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object LianXiDianHua { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "描述", Order = 5)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			public object MiaoShu { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "图片", Order = 6)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object TuPian { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "排序", Order = 7)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? PaiXu { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "备注", Order = 8)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			public object Remark { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 9)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object State { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "会员", Order = 10)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			public object HuiYuanId { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "拒绝理由", Order = 11)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object JuJueLiYou { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "拒绝时间", Order = 12)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? JuJueShiJian { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "安排", Order = 13)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object Anpai { get; set; }


            [ScaffoldColumn(true)]
            [Display(Name = "安排人员", Order = 13)]
            [StringLength(200, ErrorMessage = "长度不可超过200")]
            public object AnpaiName { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "安排时间", Order = 14)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? AnPaiShiJian { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "反馈", Order = 15)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object FanKui { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "反馈图片", Order = 16)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object FanKuiTuPian { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "反馈时间", Order = 17)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? FanKuiShiJian { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "申请", Order = 18)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			public object ShenQingId { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标识", Order = 19)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object BiaoShi { get; set; }


    }
}
 

