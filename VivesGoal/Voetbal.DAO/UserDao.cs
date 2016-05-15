using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Voetbal.DAO
{
    public class UserDao
    {
        public AspNetUsers Get(string userId)
        {
            using (var db = new VoetbalClubEntities())
            {
                return db.AspNetUsers.FirstOrDefault( u=> u.Id==userId);
            }
        }
    }
}
