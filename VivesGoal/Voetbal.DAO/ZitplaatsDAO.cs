﻿using System;
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
                exceptionList.AddRange(db.Abonnement.Select( a => a.zitplaats).ToList());
                var wedstrijd = db.Wedstrijd.Find(wedstijdId);
                var mogelijk = db.ZitPlaats.Where(z => z.Stadion1.id ==wedstrijd.Club1.Stadion.id && z.vak_id==vakId && z.bezet==0).Select(z => z.id).ToList();
              
                return db.ZitPlaats.Where(z => !exceptionList.Contains(z.id) && mogelijk.Contains(z.id)).Include(z => z.Vak).FirstOrDefault();
            }
        }
    }
}
