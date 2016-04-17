using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Voetbal.DAO;
using Model;

namespace Voetbal.Services
{
    public class AbonnementService
    {
        private AbonnementDAO abonnementDAO;

        public AbonnementService()
        {
            abonnementDAO = new AbonnementDAO();
        }

        public IEnumerable<Abonnement> All()
        {
            return abonnementDAO.All();
        }
    }
}
