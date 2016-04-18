using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Voetbal.DAO;


namespace Voetbal.Services
{
    public class AbonnementService
    {
        private AbonnementDAO abonnementDAO;

        public IEnumerable<Abonnement> All()
        {
            return abonnementDAO.All();
        }
    }
}
