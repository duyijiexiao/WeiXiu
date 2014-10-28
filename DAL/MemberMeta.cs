using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(MemberMetadata))]//使用MemberMetadata对Member进行数据验证
    public partial class Member 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class MemberMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object userid { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "成员名称", Order = 2)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object name { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "成员所属部门id列表", Order = 3)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object department { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "职位信息", Order = 4)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object position { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "手机号码", Order = 5)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object mobile { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "性别", Order = 6)]
			[StringLength(20, ErrorMessage = "长度不可超过20")]
			public object gender { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "办公电话", Order = 7)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object tel { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "邮箱", Order = 8)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object email { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "微信号", Order = 9)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object weixinid { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "头像url", Order = 10)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object avatar { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "关注状态", Order = 11)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object status { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 12)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标识", Order = 13)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object Remark { get; set; }


    }
}
 

