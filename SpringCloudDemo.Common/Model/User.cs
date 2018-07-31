using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringCloudDemo.Common.Model
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {

        /// <summary>
        /// 编号
        /// </summary>
        public  int Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public  string Name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public  int Age { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public  Address Address { get; set; }
    }

    /// <summary>
    /// 地址
    /// </summary>
    public class Address
    {
        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }
    }
}
