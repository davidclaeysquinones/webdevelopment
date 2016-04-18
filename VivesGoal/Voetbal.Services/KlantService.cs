using System;
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
        private KlantDAO klantDao;

        public IEnumerable<Klant> All()
        {
            return klantDao.All();
        }
    }
}
