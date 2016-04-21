using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Voetbal.DAO
{
    public class WedstrijdDAO
    {
        public IEnumerable<Wedstrijd> All()
        {
            using (var db = new VoetbalClubEntities())
            {
                return db.Wedstrijd.ToList();
            }
        }

        public IEnumerable<Wedstrijd> Get(DateTime date)
        {
            using (var db = new VoetbalClubEntities())
            {
                return db.Wedstrijd.Where(w => w.datum == date).ToList();
            }
        } 
    }
}
