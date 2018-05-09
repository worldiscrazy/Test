using System.Web;
using System.Web.Mvc;
using Test.WebApi.Utility;

namespace Test.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //全局注册
            filters.Add(new CustomAuthorizeAttribute("~/Home/Refuse"));
            filters.Add(new CustomHandleErrorAttribute());

        }
    }
}
