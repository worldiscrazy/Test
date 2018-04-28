using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.IDAL;

namespace Test.BLLNew
{
    public class BaseBLL<T>: IBLL.IBaseBLL<T> where T : class
    {
        private IBaseDAL<T> _dal;

        public BaseBLL(IBaseDAL<T> dal) {

            _dal = dal;
        }

        public int Add(T entity)
        {
            return _dal.Insert(entity);
        }

        public int Change(T entity)
        {
            return _dal.Update(entity);
        }

        public T Get(int id)
        {
            return _dal.Select(id);
        }


        public IQueryable<T> Get()
        {
            return _dal.Select();
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> exp)
        {
            return _dal.Select(exp);
        } 

        public int Remove(int id)
        {
            T t = _dal.Select(id);
            if (t != null) return _dal.Delete(t);

            return 0;
        }
    }
}
