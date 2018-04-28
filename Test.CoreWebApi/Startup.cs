using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Test.CoreWebApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Test.CoreWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<DBContext>(options => options.UseMySql(Configuration.GetConnectionString("MySql")));
            services.AddMvc();
            //    //全局配置Json序列化处理
            //.AddJsonOptions(options =>
            //{
            //    //忽略循环引用
            //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //    //不使用驼峰样式的key
            //    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            //    //设置时间格式
            //    options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
