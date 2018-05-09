using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.WebApi.Utility
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private string _LoginUrl = "~/Home/Login";
        public CustomAuthorizeAttribute(string loginUrl = null)
        {
            if (!string.IsNullOrEmpty(loginUrl))
            {
                this._LoginUrl = loginUrl;
            }
        }

        /// <summary>
        /// 第一时间执行，完成权限认证
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;//方法上面有这个特性，通过检查
            }
            if (filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;//控制器上面有这个特性，通过检查
            }
            //filterContext.HttpContext.Session[""] 
            //filterContext.HttpContext.Request.Cookies
            if (filterContext.HttpContext.Request.QueryString["Account"] != null
                 && filterContext.HttpContext.Request.QueryString["Account"].Equals("Admin")
                 && filterContext.HttpContext.Request.QueryString["Pwd"] != null
                 && filterContext.HttpContext.Request.QueryString["Pwd"].Equals("123456"))//模拟检测，实际应该是cookie/session
            {
                return;//表示验证通过
            }
            else
            {
                filterContext.HttpContext.Session["CurrentUrl"] = filterContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectResult(this._LoginUrl);
            }
            //base.OnAuthorization(filterContext);//表示调用父类的方法  默认验证
        }


        //方法执行前，执行后，......
        //public override void OnActionExecuting()
        //{

        //}

    }
}