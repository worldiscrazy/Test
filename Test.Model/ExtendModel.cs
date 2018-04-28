using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    //全部扩展实体类属性

    public partial class Users
    {
        private DbContext context = new Test1DbContext();
        public string NationName
        {
            get { return context.Set<Nation>().Where(r => r.NationCode == this.NationCode).First().NationName; }
        }

        public string SexStr
        {
            get { return this.Sex == true ? "男" : "女"; }
        }
    }
}
