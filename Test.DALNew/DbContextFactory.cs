using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;

namespace Test.DALNew
{
    /// <summary>
    /// 上下文对象单例工厂
    /// </summary>
    public class DbContextFactory
    {
        private static DbContext _Test1Context;

        public static DbContext Test1Context
        {
            get
            {
                if (_Test1Context == null) _Test1Context = new Test1DbContext();
                return _Test1Context;
            }
        }
    }
}
