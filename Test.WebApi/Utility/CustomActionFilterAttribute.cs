using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.WebApi.Utility
{

    /// <summary>
    /// Action:请求验证拦截，记录日志，缓存，参数验证，处理sql注入，性能监控，双语言切换
    /// </summary>
    public class CustomActionFilterAttribute:ActionFilterAttribute
    {

        private Stopwatch stopWatch = null;

        /// <summary>
        /// 方法执行前
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
            string controller = filterContext.RouteData.Values["controller"].ToString();
            string action = filterContext.RouteData.Values["action"].ToString();


            //base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// 方法执行后
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            stopWatch.Stop();
            filterContext.HttpContext.Response.Write($"Action耗时：{stopWatch.ElapsedMilliseconds}ms");
            //base.OnActionExecuted(filterContext);
        }





        /// <summary>
        ///  结果返回前
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();//stopWatch.Restart(); 
            filterContext.HttpContext.Response.Write($"Result耗时：{stopWatch.ElapsedMilliseconds}ms");


            base.OnResultExecuting(filterContext);
        }

        /// <summary>
        /// 结果返回后
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            stopWatch.Stop();
            base.OnResultExecuted(filterContext);
        }




    }
}