using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.CoreWebApi.Common
{
    public class ResultMessage
    {
        /// <summary>
        /// 是否成功 True | Flase
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 状态代码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Msg { get; set; }


        /// <summary>
        /// 返回的数据集
        /// </summary>
        public object Data { get; set; }


    }
}
