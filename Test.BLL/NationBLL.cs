using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BDFactory;
using Test.IBLL;
using Test.IDAL;
using Test.Model;

namespace Test.BLL
{
    public class NationBLL:BaseBLL<Nation>,INationBLL
    {
        private static INationDAL dal = new Factory<Nation>().CreateDAL<INationDAL>("NationDAL");
        public NationBLL() : base(dal)
        {
        }

    }
}
