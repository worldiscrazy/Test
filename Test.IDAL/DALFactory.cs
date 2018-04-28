using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test.IDAL
{
    public class DALFactory
    {
        string DAL_NameSpace = ConfigurationManager.AppSettings["DAL_NameSpace"];
        string DAL_ClassName = ConfigurationManager.AppSettings["DAL_ClassName"];
        
        public IUserDAL CreateDAL()
        {
            Assembly assembly = Assembly.Load(DAL_NameSpace);
            Type type = assembly.GetType(DAL_NameSpace + "." + DAL_ClassName);
            Console.WriteLine(type);
            return (IUserDAL)Activator.CreateInstance(type); 
        }

        public T CreateDAL<T>(string className)
        {
            Assembly assembly = Assembly.Load(DAL_NameSpace);
            Type type = assembly.GetType(DAL_NameSpace + "." + className);
            Console.WriteLine(type);
            return (T)Activator.CreateInstance(type);
        }

    }
}
