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
                return db.Boeking.Where(b => b.klant == id).Include( b =>b.Wedstrijd1.Club).Include(b=> b.Wedstrijd1.Club1).Include(b=> b.Wedstrijd1).Include( b=> b.ZitPlaats1.Vak.PrijsVak).ToList();
            }
        }
        
        public Boeking Get(int id)
        {
            using (var db = new VoetbalClubEntities())
            {
                return db.Boeking.Find(id);
            }
        }

        public void Add(Boeking boeking)
        {
            using (var db = new VoetbalClubEntities())
            {
                //db.Bierens.Attach(entity);
                db.Entry(boeking).State = EntityState.Added;
                db.SaveChanges();
            }
        }
    }
}
