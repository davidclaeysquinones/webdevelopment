using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Voetbal.DAO;

namespace Voetbal.Services
{
    public class BoekingService
    {
        private BoekingDAO boekingDAO;

        public BoekingService()
        {
            boekingDAO = new BoekingDAO();
        }
        public IEnumerable<Boeking> All()
        {
            return boekingDAO.All();
        }

        public IEnumerable<Boeking> BoekingenKlant(string id)
        {
            return boekingDAO.BoekingenKlant(id);
        }

        public Boeking get(int id)
        {
            return boekingDAO.Get(id);
        }

        public void Add(Boeking boeking)
        {
            boekingDAO.Add(boeking);
        }
    }


}
