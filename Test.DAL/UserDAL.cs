using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.IDAL;

namespace Test.DAL
{
    /// <summary>
    /// Users数据访问类
    /// </summary>
    public class UserDAL :BaseDAL<Test.Model.Users>,IUserDAL
    {
        public string GetUserNmae(string Guid)
        {
            return "DAL -- 张三 --- " + Guid;
        }



        /// <summary>
        /// 重写主键匹配抽象方法
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override Expression<Func<Test.Model.Users, bool>> GetByKey(int key)
        {
            return r => r.Ids == key;
        }

        /// <summary>
        /// 扩展分页方法实现
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public IQueryable<Test.Model.Users> Select(int PageSize, int PageIndex)
        {
            return context.Set<Test.Model.Users>().Skip((PageIndex - 1) * PageSize).Take(PageSize);
        }

    }
}
