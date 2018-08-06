using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }
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
    /// 性别 0: 男; 1: 女
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// 男性
        /// </summary>
        [Description("男")]
        Male = 0,

        /// <summary>
        /// 女性
        /// </summary>
        [Description("女")]
        Female = 1
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
