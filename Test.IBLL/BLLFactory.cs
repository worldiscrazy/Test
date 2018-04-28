using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Test.IDAL;

namespace Test.IBLL
{
    /// <summary>
    /// 采用工厂模式实现解耦（松耦合），配置文件,Ioc控制反转+反射
    /// </summary>
    public class BLLFactory
    {

        static string BLL_NameSpace = ConfigurationManager.AppSettings["BLL_NameSpace"];
        static string BLL_ClassName = ConfigurationManager.AppSettings["BLL_ClassName"];

        public IUserBLL CreateBLL()
        {
            Assembly assembly = Assembly.Load(BLL_NameSpace);
            Type type = assembly.GetType(BLL_NameSpace + "." + BLL_ClassName);

            Console.WriteLine(type);
            return (IUserBLL)Activator.CreateInstance(type);
        }

        public T CreateBLL<T>(string className)
        {
            Assembly assembly = Assembly.Load(BLL_NameSpace);
            Type type = assembly.GetType(BLL_NameSpace + "." + className);

            Console.WriteLine(type);
            return (T)Activator.CreateInstance(type);
        }
        

    }
}
