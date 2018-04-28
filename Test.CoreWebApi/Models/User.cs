using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.CoreWebApi.Common;

namespace Test.CoreWebApi.Models
{
    public class User
    {
        [Empty]
        [Length(5,12)]
        public int ID { get; set; }

        
        public string Account { get; set; }

         
        public string NikeName { get; set; }
         


    }
}
