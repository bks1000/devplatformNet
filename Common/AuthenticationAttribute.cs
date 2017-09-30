using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApp
{
    /// <summary>
    /// 登录过滤器
    /// 可以用于Class OR Method
    /// </summary>
    public class AuthenticationAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session[Common.Constant.SessionName] == null)
                filterContext.Result = new RedirectToRouteResult("Login", new RouteValueDictionary { { "from", filterContext.RequestContext.HttpContext.Request.Url.ToString() } });

            base.OnActionExecuting(filterContext);
        }
    }
}