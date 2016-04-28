using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace VivesGoal.ViewModel
{
    public class CalenderViewModel
    {

        public IEnumerable<Wedstrijd> wedstrijden { get; set; } 

        public DateTime beginDatum { get; set; }

        public DateTime eindDatum { get; set; }


        public CalenderViewModel()
        {

        }

        public CalenderViewModel(IEnumerable<Wedstrijd> wedstrijden, DateTime beginDatum, DateTime eindDatum)
        {
            this.wedstrijden = wedstrijden;
            this.beginDatum = beginDatum;
            this.eindDatum = eindDatum;
        }
    }
}
