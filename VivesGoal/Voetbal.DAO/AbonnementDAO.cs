using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Voetbal.DAO
{
    public class AbonnementDAO
    {
        public IEnumerable<Abonnement> All()
        {
            using (var db = new VoetbalClubEntities())
            {
                return db.Abonnement.ToList();
            }
        }
    }
}
