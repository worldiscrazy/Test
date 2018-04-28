using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test.BDFactory
{

    /// <summary>
    /// 数据访问类泛型工厂
    /// </summary>
    /// <typeparam name="T"> Factory<T> 需要操作的 Model实体类型</typeparam>
    public class Factory<TEntity>
    { 

        #region 如果更换被调用层，交给在调用层修改调用通用方法

        //BLL:逻辑工厂层，用于创建逻辑层的接口，便于界面层调用
        private static string BLL_NameSpace = ConfigurationManager.AppSettings["BLL_NameSpace"];
        public T CreateBLL<T>(string className)
        {
            Assembly assembly = Assembly.Load(BLL_NameSpace);
            Type type = assembly.GetType(BLL_NameSpace + "." + className); 
            //Console.WriteLine(type);
            return (T)Activator.CreateInstance(type);
        }
        

        //DAL: 数据工厂层，用于创建数据库层的接口，从而让逻辑层调用
        private static string DAL_NameSpace = ConfigurationManager.AppSettings["DAL_NameSpace"];
        public T CreateDAL<T>(string className)
        {
            Assembly assembly = Assembly.Load(DAL_NameSpace);
            Type type = assembly.GetType(DAL_NameSpace + "." + className);
            //Console.WriteLine(type);
            return (T)Activator.CreateInstance(type);
        }

        #endregion


        #region  如果更换被调用层，交给在工厂内修改通用方法
        ///// <summary>
        ///// 返回此泛型Model对应的BLL 
        ///// </summary>
        ///// <returns></returns>
        //public dynamic CreateBLL()
        //{
        //    if (typeof(T) == typeof(Users))
        //        return Assembly.Load(BLL_NameSpace).CreateInstance(BLL_NameSpace + "." + BLL_Users) as IUsersIBLL;
        //    else if (typeof(T) == typeof(Nation))
        //        return Assembly.Load(BLL_NameSpace).CreateInstance(BLL_NameSpace + "." + BLL_Nation) as INationIBLL;

        //    return null;
        //}
        #endregion
        

        #region 
        //private static object GetInstance(string cName)
        //{

        //    string configName = ConfigurationManager.AppSettings["DataSourceDAL"];  
        //    if (string.IsNullOrEmpty(configName))
        //    {

        //        throw new InvalidOperationException();
        //        //LogHandle.WriteLogByWinForm(null, "XSFace.DALFactory", "Factory", System.Reflection.MethodBase.GetCurrentMethod().Name + " throw new InvalidOperationException()");
        //    }

        //    string className = string.Format("{0}.{1}", "Test.DAL", cName);   

        //    System.Reflection.Assembly _assembly = System.Reflection.Assembly.Load(configName);

        //    return _assembly.CreateInstance(className);
        //}


        ///// <summary>
        ///// Get DAL
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="nameSpace"></param>
        ///// <returns></returns>
        //public static T GetDAL<T>(string nameSpace)
        //{
        //    object obj = GetInstance(nameSpace);
        //    T _t = (T)obj;
        //    return _t;
        //}

        #endregion


    }
}
