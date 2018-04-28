using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.CoreWebApi.Common
{
    /// <summary>
    /// 数据验证扩展类
    /// </summary>
    public class DataValidateExtend
    {
        public static bool Validate<T>(T tModel)
        {
            bool result = true;
            Type type = tModel.GetType();
            foreach (var prop in type.GetProperties()) {

                if (prop.IsDefined(typeof(AbstractValidateAttribute),true)) {

                    object[] oAttributeArray = prop.GetCustomAttributes(typeof(AbstractValidateAttribute),true);
                    foreach (AbstractValidateAttribute attribute in oAttributeArray)
                    {
                        if (!attribute.Validate(prop.GetValue(tModel)))
                        {
                            return false;
                        }
                    }
                }

            }

            return result;
        }


    }
}
