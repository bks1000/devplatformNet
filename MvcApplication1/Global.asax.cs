using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.Web;
using Bo;
using Dao;
using IBO;
using IDao;

namespace MvcApp
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication,IContainerProviderAccessor
    {
        static IContainerProvider _containerProvider;

        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        protected void Application_Start()
        {
            //Asp.NET MVC3添加域（Areas）区分Admin域和用户域
            //http://www.cnblogs.com/chtang/archive/2013/04/06/3002746.html
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //IOC
            ContainerBuilder builder = new ContainerBuilder();
            SetupResolveRules(builder);  //注入

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            _containerProvider = new ContainerProvider(container);
        }

        private void SetupResolveRules(ContainerBuilder builder)
        {
            //UI项目只用引用service和repository的接口，不用引用实现的dll。
            //如需加载实现的程序集，将dll拷贝到bin目录下即可，不用引用dll
            var IServices = Assembly.Load("IBO");
            var Services = Assembly.Load("Bo");
            var IRepository = Assembly.Load("IDao");
            var Repository = Assembly.Load("Dao");

            //根据名称约定（服务层的接口和实现均以Bo结尾），实现服务接口和服务实现的依赖
            builder.RegisterAssemblyTypes(IServices, Services)
              .Where(t => t.Name.EndsWith("Bo"))
              .AsImplementedInterfaces();

            //根据名称约定（数据访问层的接口和实现均以Dao结尾），实现数据访问接口和数据访问实现的依赖
            builder.RegisterAssemblyTypes(IRepository, Repository)
              .Where(t => t.Name.EndsWith("Dao"))
              .AsImplementedInterfaces();
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        protected void Application_EndRequest()
        {
            var statusCode = Context.Response.StatusCode;
            var routingData = Context.Request.RequestContext.RouteData;
            if (statusCode == 404 || statusCode == 500)
            {
                Response.Clear();
                var area = routingData.DataTokens["area"];
                if (area == "BackControl")
                {
                    if (statusCode == 404)
                    {
                        Response.RedirectToRoute("BackControl_default", new { controller = "BackError", action = "NotFound" });
                    }
                    else
                    {
                        Response.RedirectToRoute("BackControl_default", new { controller = "BackError", action = "Error" });
                    }
                }
                else
                {
                    if (statusCode == 404)
                    {
                        Response.RedirectToRoute("Default", new { controller = "HttpError", action = "NotFound", id = UrlParameter.Optional });
                    }
                    else
                    {
                        Response.RedirectToRoute("Default", new { controller = "HttpError", action = "Error", id = UrlParameter.Optional });
                    }
                }
            }
        }
    }
}