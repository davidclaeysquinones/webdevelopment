﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Voetbal.DAO
{
    public class ClubDAO
    {
        public IEnumerable<Club> All()
        {
            using (var db = new VoetbalClubEntities())
            {
                return db.Club.Include( c => c.Stadion).ToList();
            }
        }

        public Club Get(int id)
        {
            using (var db = new VoetbalClubEntities())
            {
                return db.Club.Include(c => c.Stadion).FirstOrDefault( c => c.id==id);
            }
        }
    }
}
