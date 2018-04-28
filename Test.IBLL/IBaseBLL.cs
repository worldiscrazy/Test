using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test.IBLL
{
    /// <summary>
    /// 业务逻辑基础描述接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseBLL<T>
    {
        IQueryable<T> Get();

        IQueryable<T> Get(Expression<Func<T, bool>> exp);

        T Get(int id);

        int Add(T entity);

        int Change(T entity);

        int Remove(int id);
    }
}
