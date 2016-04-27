using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace VivesGoal.ViewModel
{
    class CalenderViewModel
    {
        private IEnumerable<Wedstrijd> wedstrijden { get; set; } 

        private DateTime begindDatum { get; set; }

        private DateTime eindDatum { get; set; }
    }
}
