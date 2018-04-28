using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test.IDAL
{
    /// <summary>
    /// 数据访问基础描述接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseDAL<T> where T : class
    {
        IQueryable<T> Select();

        IQueryable<T> Select(Expression<Func<T, bool>> exp);

        T Select(int key);

        int Insert(T entity);

        int Update(T entity);

        int Delete(T entity);
    }
}
