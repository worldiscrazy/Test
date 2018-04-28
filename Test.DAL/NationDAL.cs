using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.IDAL;
using Test.Model;

namespace Test.DAL
{
    public class NationDAL:BaseDAL<Nation>,INationDAL
    {
        /// <summary>
        /// 重写主键匹配抽象方法
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override Expression<Func<Nation, bool>> GetByKey(int key)
        {
            return r => r.NationCode == ("N" + key.ToString("000"));
        }

    }
}
