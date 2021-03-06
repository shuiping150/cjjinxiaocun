﻿// 作者:					曹军 
// 邮件：               869722304@qq.com(仅仅支持商业合作洽谈)
// 创建时间:			    2012-08-8
// 最后修改时间:			2012-08-11
// 
// 未经修改的文件版权属于原作者所有，但是你可以阅读，修改，调试。本项目不建议商用，不能确保稳定性。
// 同时由于项目Bug引起的一切问题，原作者概不负责。
//
// 本项目所引用的所有类库，仍然遵循其原本的协议，不得侵害其版权。
//
// 您一旦下载就视为您已经阅读此声明。
//
// 您不可以移除项目中任何声明。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace CJCMS.Contracts.DTO.Category
{
    [Serializable]
    public class CategoryInfo
    {
        /// <summary>
        /// 数据字典编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 数据字典名称
        /// </summary>
        [NotNullValidator]
        [StringLengthValidator(1, 50, Ruleset = "RuleSetA", MessageTemplate = "分类名称必须介于1~50个字符")]
        public string CategoryName { get; set; }
        /// <summary>
        /// 附加信息
        /// </summary>
        public string ExInfo { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        [NotNullValidator]
        [RangeValidator(0, RangeBoundaryType.Inclusive, 500, RangeBoundaryType.Inclusive)]
        public int SortNum { get; set; }
        /// <summary>
        /// 父节点编号
        /// </summary>
        [NotNullValidator]
        public string ParentId { get; set; }
        /// <summary>
        /// 图标名称
        /// </summary>
        [NotNullValidator]
        public string IconName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [NotNullValidator]
        public string Status { get; set; }
    }
}
