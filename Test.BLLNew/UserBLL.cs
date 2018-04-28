using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BDFactory;
using Test.IBLL;
using Test.IDAL;
using Test.Model;

namespace Test.BLLNew
{
    public class UserBLL : BaseBLL<Test.Model.Users>, Test.IBLL.IUserBLL //BaseBLL<Test.Model.User> ,Test.IBLL.IUser
    {
        //private static IDAL.IUserDAL dal = new DALFactory().CreateDAL();
        private static IDAL.IUserDAL dal2 = new Factory<Users>().CreateDAL<IUserDAL>("UserDAL");


        public UserBLL():base(dal2){

        }

        public string GetUserNmae(string Guid)
        {
            return dal2.GetUserNmae("BLLNew--" + Guid);
        }


        public IQueryable<Users> Get(int pageSize, int pageIndex)
        {
            return dal2.Select(pageSize, pageIndex);
        }
    }
}
