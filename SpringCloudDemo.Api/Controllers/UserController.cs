using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpringCloudDemo.Common.Model;
using SpringCloudDemo.Common.Service;

namespace SpringCloudDemo.Api.Controllers
{
    /// <summary>
    /// 用户接口
    /// </summary>
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private  readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
       [Route("")]
        public IEnumerable<User> GetAll()
       {
           return _userService.GetAll();
       }
        /// <summary>
        /// 根据ID获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        public User Get(int id)
        {
            return _userService.GetUser(id);
        }
    }
}