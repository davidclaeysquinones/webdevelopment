using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Cart
    {
        public List<Ticket> Items { get; set; }

        public Cart()
        {
            Items = new List<Ticket>();
        }
    }
}
