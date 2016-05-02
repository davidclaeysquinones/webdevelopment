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
    }
}
