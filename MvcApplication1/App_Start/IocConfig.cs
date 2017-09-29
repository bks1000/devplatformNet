using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Bo;
using Dao;
using IBO;
using IDao;

namespace MvcApp
{
    /// <summary>
    /// http://autofac.readthedocs.io/en/latest/getting-started/index.html
    /// </summary>
    public class IocConfig
    {
        private static IContainer Container { get; set; }
        /// <summary>
        /// 注册IOC组件
        /// </summary>
        public static void RegIoc()
        {
            // Create your builder.
            var builder = new ContainerBuilder();

            builder.RegisterType<RolesDao>().As<IRolesDao>();

            builder.RegisterType<RolesBo>().As<IRolesBo>();

            Container = builder.Build();
        }
    }
}