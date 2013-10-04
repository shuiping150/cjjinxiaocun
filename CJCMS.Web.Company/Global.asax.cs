﻿using CJCMS.Application;
using CJCMS.Framework.Task;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CJCMS.Web.Company
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new CJAuthorizeAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );
            routes.MapRoute(
               "Admin", // 路由名称
               "{controller}/{action}/{id}/{newpid}", // 带有参数的 URL
               new { controller = "Admin", action = "Index", id = UrlParameter.Optional, newpid = UrlParameter.Optional } // 参数默认值
           );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // 默认情况下对 Entity Framework 使用 LocalDB
            //Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //全局领域对象和传输对象映射关系注册
            CoreManager corem = new CoreManager();
            corem.BeforeDoCoreJob();

            //任务框架启动
            DefaultBackgroundTaskManager taskManager = new DefaultBackgroundTaskManager(0.1);
            //DefaultBackgroundTaskManager.TryAdd("voteTask", new VoteTask(true));
        }
    }
}