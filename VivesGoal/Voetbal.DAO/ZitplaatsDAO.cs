using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Voetbal.DAO
{
    public class ZitplaatsDAO
    {
        public IEnumerable<ZitPlaats> All()
        {
            using (var db = new VoetbalClubEntities())
            {
                return db.ZitPlaats.ToList();
            }
        }


    }
}
