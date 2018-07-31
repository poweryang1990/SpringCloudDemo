using System.Collections;
using System.Collections.Generic;
using SpringCloudDemo.Common.Model;

namespace SpringCloudDemo.Common.Service
{
    public interface IUserService
    {
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        IList<User> GetAll();
        /// <summary>
        /// 根据用户ID 获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUser(int id);
    }
}