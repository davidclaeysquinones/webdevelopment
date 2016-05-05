using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;

namespace Voetbal.DAO
{
    public class ZitplaatsDAO
    {
        public IEnumerable<ZitPlaats> All()
        {
            using (var db = new VoetbalClubEntities())
            {
                return db.ZitPlaats.Include(z => z.Vak).ToList();
            }
        }

        public ZitPlaats GetAvailable(int wedstijdId, int vakId)
        {
            using (var db = new VoetbalClubEntities())
            {
                var exceptionList = db.Boeking.Where(b => b.ZitPlaats1.vak_id == vakId && b.Wedstrijd == wedstijdId).Select(b =>b.ZitPlaats1.id).ToList();

                var wedstrijd = db.Wedstrijd.Find(wedstijdId);
                var mogelijk = db.ZitPlaats.Where(z => z.Stadion1.id ==wedstrijd.Club1.Stadion.id).Select(z => z.id).ToList();
              
                return db.ZitPlaats.FirstOrDefault(z => !exceptionList.Contains(z.id) && mogelijk.Contains(z.id) && z.Vak.id==vakId);
            }
        }
    }
}
