﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Voetbal.DAO;

namespace Voetbal.Services
{
    public class KlantService
    {
        private KlantDAO klantDAO;

        public KlantService()
        {
            klantDAO = new KlantDAO();
        }

        public IEnumerable<Klant> All()
        {
            return klantDAO.All();
        }
    }
}
