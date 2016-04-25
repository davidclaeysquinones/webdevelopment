using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Voetbal.DAO;

namespace Voetbal.Services
{
    public class WedstrijdService
    {
        private WedstrijdDAO wedstrijdDAO;

        public WedstrijdService()
        {
            wedstrijdDAO = new WedstrijdDAO();
        }
        public IEnumerable<Wedstrijd> All()
        {
            return wedstrijdDAO.All();

        }

        public IEnumerable<Wedstrijd> Get(DateTime date)
        {
            return wedstrijdDAO.Get(date);
        }

        public IEnumerable<Wedstrijd> Get(int clubid)
        {
            return wedstrijdDAO.Get(clubid);
        } 
    }
}
