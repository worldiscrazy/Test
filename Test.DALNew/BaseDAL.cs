using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.IDAL;

namespace Test.DALNew
{
    public abstract class BaseDAL<T> : IBaseDAL<T> where T : class
    {

        protected DbContext context = DbContextFactory.Test1Context;
        public int Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            return context.SaveChanges();
        }

        public int Insert(T entity)
        {
            context.Set<T>().Add(entity);
            return context.SaveChanges();
        }

        public IQueryable<T> Select()
        {
            return context.Set<T>();
        }

        /// <summary>
        /// 主键匹配
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public abstract Expression<Func<T, bool>> GetByKey(int key);

        public T Select(int key)
        {
            return context.Set<T>().Where(GetByKey(key)).FirstOrDefault();
        }

        public IQueryable<T> Select(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Where(exp);
        }

        public int Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = System.Data.EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
