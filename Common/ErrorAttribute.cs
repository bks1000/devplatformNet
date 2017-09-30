using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Common
{
    class ErrorAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Exception exception = filterContext.Exception;
            if (filterContext.ExceptionHandled == true)
            {
                return;
            }
            HttpException httpException = new HttpException(null, exception);
            //filterContext.Exception.Message可获取错误信息

            /*
             * 1、根据对应的HTTP错误码跳转到错误页面
             * 2、这里对HTTP 404/400错误进行捕捉和处理
             * 3、其他错误默认为HTTP 500服务器错误
             */
            if (httpException != null && (httpException.GetHttpCode() == 400 || httpException.GetHttpCode() == 404))
            {
                //filterContext.HttpContext.Response.StatusCode = 404;
                //filterContext.HttpContext.Response.Write("错误的请求路径");
                //filterContext.HttpContext.Response.WriteFile("~/HttpError/404.html");
                filterContext.Result = new RedirectResult("/HttpError/Show/404");//跳转至错误提示页面 
            }
            else
            {
                //filterContext.HttpContext.Response.StatusCode = 500;
                //filterContext.HttpContext.Response.Write("服务器内部错误");
                //filterContext.HttpContext.Response.WriteFile("~/HttpError/500.html");
                filterContext.Result = new RedirectResult("/HttpError/Show/500");//跳转至错误提示页面 
            }
            /*---------------------------------------------------------
             * 这里可进行相关自定义业务处理，比如日志记录等
             ---------------------------------------------------------*/

            //设置异常已经处理,否则会被其他异常过滤器覆盖
            filterContext.ExceptionHandled = true;

            //在派生类中重写时，获取或设置一个值，该值指定是否禁用IIS自定义错误。
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}
