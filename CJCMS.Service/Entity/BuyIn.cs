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
using CJCMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJCMS.Domain.Entity
{
    public  class BuyIn : IEntity
    {
        /// <summary>
        /// 采购编号
        /// </summary>
        public virtual string Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime Created { get; set; }
        /// <summary>
        /// 折扣1~10
        /// </summary>
        public virtual int Discount { get; set; }
        /// <summary>
        /// 单据号
        /// </summary>
        public virtual string TicketNo { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public virtual decimal AllPrice { get; set; }
        /// <summary>
        /// 单据类型
        /// </summary>
        public virtual int Type { get; set; }
        /// <summary>
        /// 已付款额
        /// </summary>
        public virtual decimal PaiedPrice { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public virtual int Status { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string OtherInfo { get; set; }
    }
}
