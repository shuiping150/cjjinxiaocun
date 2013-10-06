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
using CJCMS.Domain.Entity;
using CJCMS.Domain.ValueObject;
using CJCMS.Framework.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJCMS.Domain.Service
{
    public class SupplierService
    {
        /// <summary>
        /// 添加供应商
        /// </summary>
        /// <param name="p"></param>
        public void AddSupplier(Supplier p)
        {
            IRepository<Supplier> ir = null;
            ir = AutofacManager<IRepository<Supplier>>.GetConcrete<DefaultRepository<Supplier>>();
            ir.Add(p);
            NHibernateSessionManager.Instance.Session.CommitChanges();
        }
        /// <summary>
        /// 修改供应商
        /// </summary>
        /// <param name="p"></param>
        public void UpdateSupplier(Supplier p)
        {
            IRepository<Supplier> ir = null;
            ir = AutofacManager<IRepository<Supplier>>.GetConcrete<DefaultRepository<Supplier>>();
            Supplier c = ir.GetByKey(p.Id);
            if (c == null) { throw new Exception("have no object"); }
            ir.Update(p);
            NHibernateSessionManager.Instance.Session.CommitChanges();
        }

        /// <summary>
        /// 分页遍历供应商
        /// </summary>
        /// <param name="index">页号</param>
        /// <param name="count">页大小</param>
        /// <param name="allCount">总数</param>
        /// <returns></returns>
        public IList<Supplier> FetchAll(int index, int count, ref int allCount)
        {
            IRepository<Supplier> ir = null;
            ir = AutofacManager<IRepository<Supplier>>.GetConcrete<DefaultRepository<Supplier>>();
            allCount = ir.Count(a => a.Id != null);
            return ir.Table.Where(a => a.Id != null).Skip((index - 1) * count).Take(count).OrderBy(k => k.Created).ToList();
        }

        /// <summary>
        /// 在分类下按照供应商名称模糊查询
        /// </summary>
        /// <param name="name">供应商名称查询Key</param>
        /// <param name="index">页号</param>
        /// <param name="count">页大小</param>
        /// <param name="allCount">总数</param>
        /// <returns></returns>
        public IList<Supplier> FetchAllByName(string name, int index, int count, ref int allCount)
        {
            IRepository<Supplier> ir = null;
            ir = AutofacManager<IRepository<Supplier>>.GetConcrete<DefaultRepository<Supplier>>();
            allCount = ir.Count(a => a.Id != null && a.SupplierName.Contains(name));
            return ir.Table.Where(a => a.Id != null && a.SupplierName.Contains(name)).Skip((index - 1) * count).Take(count).OrderBy(k => k.Created).ToList();
        }

        /// <summary>
        /// 指定供应商上线
        /// </summary>
        /// <param name="supplierId">供应商编号</param>
        public void SetSupplierOn(string supplierId)
        {
            IRepository<Supplier> ir = null;
            ir = AutofacManager<IRepository<Supplier>>.GetConcrete<DefaultRepository<Supplier>>();
            Supplier c = ir.GetByKey(supplierId);
            if (c == null) { throw new Exception("have no object"); }
            c.Status = SupplierStatus.OnLine;
            ir.Update(c);
            NHibernateSessionManager.Instance.Session.CommitChanges();
        }

        /// <summary>
        /// 指定供应商下线
        /// </summary>
        /// <param name="supplierId">供应商编号</param>
        public void SetSupplierOff(string supplierId)
        {
            IRepository<Supplier> ir = null;
            ir = AutofacManager<IRepository<Supplier>>.GetConcrete<DefaultRepository<Supplier>>();
            Supplier c = ir.GetByKey(supplierId);
            if (c == null) { throw new Exception("have no object"); }
            c.Status = SupplierStatus.OffLine;
            ir.Update(c);
            NHibernateSessionManager.Instance.Session.CommitChanges();
        }
    }
}