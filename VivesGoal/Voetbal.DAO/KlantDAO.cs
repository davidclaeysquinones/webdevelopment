using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Voetbal.DAO
{
    public class KlantDAO
    {
        public IEnumerable<AspNetUsers> All()
        {
            using (var db = new VoetbalClubEntities())
            {
                return db.AspNetUsers.ToList();
            }
        }

        public AspNetUsers Get(string id)
        {
            using (var db = new VoetbalClubEntities())
            {
                return db.AspNetUsers.Find(id);
            }
        }
    }
}
