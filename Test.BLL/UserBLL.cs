using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.BDFactory;
using Test.IBLL;
using Test.IDAL;
using Test.Model;

namespace Test.BLL
{
    public class UserBLL : BaseBLL<Test.Model.Users>, Test.IBLL.IUserBLL 
    {
        //private static IDAL.IUserDAL dal = new DALFactory().CreateDAL();
        private static IDAL.IUserDAL dal2 = new Factory<Users>().CreateDAL<IUserDAL>("UserDAL");


        public UserBLL():base(dal2){

        }

        public string GetUserNmae(string Guid)
        {
            return dal2.GetUserNmae("BLL--"+Guid);
        }

        public IQueryable<Users> Get(int pageSize, int pageIndex)
        {
            return dal2.Select(pageSize, pageIndex);
        }

    }
}
