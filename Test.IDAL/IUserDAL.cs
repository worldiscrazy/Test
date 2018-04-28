using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Test.IDAL
{
    public interface IUserDAL : IBaseDAL<Test.Model.Users>
    {

        //扩展方法描述写在这里

        /// <summary>
        /// 扩展分页方法
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        IQueryable<Test.Model.Users> Select(int PageSize, int PageIndex);


        string GetUserNmae(string Guid);
    }
}
