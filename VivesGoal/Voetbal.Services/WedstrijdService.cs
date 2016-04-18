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

        public IEnumerable<Wedstrijd> All()
        {
            return wedstrijdDAO.All();
        }
    }
}
