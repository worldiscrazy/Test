using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Test.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// 全局异常处理
        /// HttpModule
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Application_Error(object sender,EventArgs e) {

            Exception exception = Server.GetLastError();
            Response.Write("页面出现异常");
            Server.ClearError();

        }

    }
}
