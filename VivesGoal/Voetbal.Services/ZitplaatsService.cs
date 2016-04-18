using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Voetbal.DAO;

namespace Voetbal.Services
{
    public class ZitplaatsService
    {
        private ZitplaatsDAO zitplaatsDAO;

        public IEnumerable<ZitPlaats> All()
        {
            return zitplaatsDAO.All();
        }
    }
}
