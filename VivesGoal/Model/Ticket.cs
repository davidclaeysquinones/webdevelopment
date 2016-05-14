using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ticket
    {
        public int vakId { get; set; }

        public string vakNaam { get; set; }

        public int wedstrijdId { get; set; }
        public string wedstrijd { get; set; }
        public string prijs { get; set; }
        
        public int aantal { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Ticket objAsTicket = obj as Ticket;
            if (objAsTicket == null) return false;
            else return Equals(objAsTicket);
        }
        public override int GetHashCode()
        {
            return wedstrijdId;
        }
        public bool Equals(Ticket other)
        {
            if (other == null) return false;
            return (this.wedstrijdId.Equals(other.wedstrijdId) && this.vakId.Equals(other.vakId));
        }
    }
}
