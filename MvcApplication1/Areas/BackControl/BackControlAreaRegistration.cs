using System.Web.Mvc;

namespace MvcApp.Areas.BackControl
{
    public class BackControlAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BackControl";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BackControl_default",
                "sys/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MvcApp.Areas.BackControl.Controllers" } 
            );

            //后台登录路由器
            context.MapRoute(
                name: "SysLogin",
                url: "sys/home/login"
            );
        }
    }
}
