using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Voetbal.DAO;

namespace Voetbal.Services
{
    public class UserService
    {
        private UserDao userDao;

        public UserService()
        {
            userDao = new UserDao();
        }

        public AspNetUsers Get(string userId)
        {
            return userDao.Get(userId);
        }
    }
}
