using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Voetbal.DAO
{
    public class BoekingDAO
    {
        public IEnumerable<Boeking> All()
        {
            using (var db = new VoetbalClubEntities())
            {
                return db.Boeking.ToList();
            }
        }

        public IEnumerable<Boeking> BoekingenKlant(string id)
        {
            using (var db = new VoetbalClubEntities())
            {
                return db.Boeking.Where(b => b.klant == id).Include( b =>b.Wedstrijd1.Club).Include(b=> b.Wedstrijd1.Club1).Include(b=> b.Wedstrijd1).ToList();
            }
        } 
    }
}
