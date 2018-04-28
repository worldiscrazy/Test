using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.CoreWebApi.Common
{
    public class AppSettingServices
    {
        private static IConfigurationSection appSections = null;


        /// <summary>
        /// private string connString = AppSettingServices.AppSetting("connString");
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string AppSetting(string key)
        {
            string str = "";
            if (appSections.GetSection(key) != null)
            {
                str = appSections.GetSection(key).Value;
            }
            return str;
        }


        /// <summary>
        /// AppSettings.SetAppSetting(Configuration.GetSection("AppSetting"));
        /// </summary>
        /// <param name="section"></param>
        public static void SetAppSetting(IConfigurationSection section)
        {
            appSections = section;
        }

        

    }
}
