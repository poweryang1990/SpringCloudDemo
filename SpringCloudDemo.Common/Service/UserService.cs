using System;
using System.Collections.Generic;
using System.Linq;
using SpringCloudDemo.Common.Model;

namespace SpringCloudDemo.Common.Service
{
    public class UserService : IUserService
    {
        private  static readonly IList<User> _dbUsers=new List<User>()
        {
            new User(){Id=1,Age =18,Name = "PowerYang"},
            new User(){Id=2,Age =20,Name = "Jon"},
            new User(){Id=3,Age =21,Name = "Tomthon"},
            new User(){Id=4,Age =28,Name = "James"},
        };

        public IList<User> GetAll()
        {
            return _dbUsers;
        }

        public User GetUser(int id)
        {
            return _dbUsers.FirstOrDefault(t => t.Id == id);
        }

    }
}