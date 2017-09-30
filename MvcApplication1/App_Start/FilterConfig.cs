using System.Web;
using System.Web.Mvc;
using Common;

namespace MvcApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new ErrorAttribute());
            //filters.Add(new AuthenticationAttribute());//全局过滤器
        }
    }
}