using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(DepartmentMetadata))]//使用DepartmentMetadata对Department进行数据验证
    public partial class Department 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "父部门")]
        public string parentidOld { get; set; }
        
        #endregion

    }
    public partial class DepartmentMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object id { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "名称", Order = 2)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object name { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "父部门", Order = 3)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			public object parentid { get; set; }


    }
}
 

