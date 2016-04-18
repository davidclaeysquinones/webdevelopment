using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Voetbal.DAO;

namespace Voetbal.Services
{
    public class VakService
    {
        private VakDAO vakDAO;
        public IEnumerable<Vak> All()
        {
            return vakDAO.All();
        }
    }
}
