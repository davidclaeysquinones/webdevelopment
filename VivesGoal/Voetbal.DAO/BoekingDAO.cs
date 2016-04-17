using System;
using System.Collections.Generic;
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
    }
}
