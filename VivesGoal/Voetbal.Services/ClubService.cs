using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Voetbal.DAO;

namespace Voetbal.Services
{
    public class ClubService
    {
        private ClubDAO clubDAO;

        public IEnumerable<Club> All()
        {
            return clubDAO.All();
        }
    }
}
