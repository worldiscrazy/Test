using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Test.CoreWebApi.Common
{
    public class HttpResponseExtension
    {
        /// <summary>
        /// 返回Json数据,设置编码格式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static HttpResponseMessage toJson(Object obj)
        {
            String str;
            if (obj is String || obj is Char)
            {
                str = obj.ToString();
            }
            else
            {
                //JavaScriptSerializer serializer = new JavaScriptSerializer();
                //str = serializer.Serialize(obj);
                str = JsonConvert.SerializeObject(obj);
            }

            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }



        /// <summary>
        /// 返回XML数据,设置编码格式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static HttpResponseMessage toXML(Object obj)
        {
            String str;
            if (obj is String || obj is Char)
            {
                str = obj.ToString();
            }
            else
            {
                //JavaScriptSerializer serializer = new JavaScriptSerializer();
                str = "xml";  // serializer.Serialize(obj);
            }

            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/XML") };
            return result;
        }



        /// <summary>
        /// 直接传code，msg,返回Json数据
        /// </summary>
        /// <param name="codeNum"></param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static HttpResponseMessage ResultResponseMsgData(int codeNum, string msg, object data)
        {

            ResultMessage resultMsg = new ResultMessage();
            resultMsg.Code = codeNum;
            resultMsg.Msg = msg;
            resultMsg.Data = data;

            return toJson(JsonConvert.SerializeObject(resultMsg));
        }

    }
}
