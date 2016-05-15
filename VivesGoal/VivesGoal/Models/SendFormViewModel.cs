using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivesGoal.Models
{
  
        public class SendFormViewModel
        {
            [Required, Display(Name = "Jouw naam")]
            public string FromName { get; set; }
            [Required, Display(Name = "jouw email"), EmailAddress]
            public string FromEmail { get; set; }
            [Required]
            public string Message { get; set; }
        }
    
}
