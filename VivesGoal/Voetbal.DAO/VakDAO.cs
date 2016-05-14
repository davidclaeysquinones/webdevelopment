using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Voetbal.DAO
{
    public class VakDAO
    {
        public IEnumerable<Vak> All()
        {
            using (var db = new VoetbalClubEntities())
            {
                return db.Vak.ToList();
            }
        }

        public Vak Get(int id)
        {
            using ( var db = new VoetbalClubEntities())
            {
                return db.Vak.Find(id);
            }
        }
    }
}
