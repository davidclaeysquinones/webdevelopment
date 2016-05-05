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
                var exceptionList = db.Boeking.Where(b => b.ZitPlaats1.vak_id == vakId && b.Wedstrijd == wedstijdId).Select(b =>b.zitplaats).ToList();
                return db.ZitPlaats.FirstOrDefault(z => !exceptionList.Contains(z.id));
            }
        }
    }
}
