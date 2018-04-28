using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BDFactory;
using Test.IBLL;
using Test.Model;

namespace Test.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //IUserBLL userBll = new BLLFactory().CreateBLL();
            IUserBLL userBll2 = new Factory<Users>().CreateBLL<IUserBLL>("UserBLL");

            string guid = System.Guid.NewGuid().ToString("N");

            string userName = userBll2.GetUserNmae(guid);

            Console.WriteLine(" Name:" + userName + " GUID:" + guid);
            Console.ReadLine();

        }
    }
}
