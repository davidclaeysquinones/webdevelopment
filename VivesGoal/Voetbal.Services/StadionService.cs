using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Voetbal.DAO;

namespace Voetbal.Services
{
    public class StadionService
    {
        private StadionDAO stadionDAO;

        public IEnumerable<Stadion> All()
        {
            return stadionDAO.All();
        }
    }
}
