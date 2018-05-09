using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.WebApi.Utility
{

    /// <summary>
    /// 异常扩展
    /// 1.action异常
    /// 2.view 异常
    /// 3.server（BLL）异常
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CustomHandleErrorAttribute: HandleErrorAttribute
    {
    }
}