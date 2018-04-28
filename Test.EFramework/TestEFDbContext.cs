using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;

namespace Test.EFramework
{ 
        public class TestEFDbContext : DbContext
        {
            private string connection = "xxxxx"; //数据库链接

            //public TestEFDbContext():base(connection)
            //{ }

            public DbSet<Users> users { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//移除复数表名的契约
                modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
                //防止黑幕交易 要不然每次都要访问 EdmMetadata这个表
            }
        }
}
