using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.IDAL;

namespace Test.BLL
{
    public class BaseBLL<T>: IBLL.IBaseBLL<T> where T : class
    {
        /// 注意，这里需要子类来实例化所需要的数据访问类，构造函数中指定
        private IBaseDAL<T> _Dal;

        //构造
        public BaseBLL(IBaseDAL<T> dal) {

            _Dal = dal;
        }

        public int Add(T entity)
        {
            return _Dal.Insert(entity);
        }

        public int Change(T entity)
        {
            return _Dal.Update(entity);
        }

        public IQueryable<T> Get()
        {
            return _Dal.Select();
        }

        public T Get(int id)
        {
            return _Dal.Select(id);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> exp)
        {
            return _Dal.Select(exp);
        }

        public int Remove(int id)
        {
            T t = _Dal.Select(id);
            if (t != null) return _Dal.Delete(t);
            return 0;
        }
         
    }
}
