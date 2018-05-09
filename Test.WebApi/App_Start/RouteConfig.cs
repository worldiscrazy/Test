using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Test.WebApi
{
    public class RouteConfig
    {
        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapRoute(
        //        name: "Default",
        //        url: "{controller}/{action}/{id}",
        //        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        //    );
        //}

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.Add(new Route("Eleven", new ElevenRouteHandler()));

            routes.Add("myRoute", new MyRoute());
            routes.MapRoute("Controller", "Test/{action}/{id}",//篡改控制器
                new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            //静态路由
            routes.MapRoute("About", "About", new { controller = "Home", action = "About", id = UrlParameter.Optional });
            routes.MapRoute(
                name: "Regex",
                url: "{controller}/{action}_{year}_{month}_{day}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               constraints: new { year = @"^\d{4}", month = @"^\d{1,2}", day = @"^\d{1,2}", });

            routes.MapRoute(
                name: "Default",
                 url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );//命名参数
        }
    }

    public class MyRoute : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)//真的是可以为所欲为的
        {
            if (httpContext.Request.UserAgent.Contains("Edge/16.16299"))
            {
                RouteData routeData = new RouteData(this, new MvcRouteHandler());
                routeData.Values.Add("controller", "Home");
                routeData.Values.Add("action", "Refuse");
                return routeData;
            }
            else
            {
                return null;
            }

        }
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }

    public class ElevenRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new ElevenHandler();
        }
    }

    public class ElevenHandler : IHttpHandler
    {
        public bool IsReusable { get { return true; } }


        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("这里是ElevenHandler");
        }
    }


}
