//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Boeking
    {

        public string klant { get; set; }

        public int zitplaats { get; set; }

        public int Wedstrijd { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Wedstrijd Wedstrijd1 { get; set; }
        public virtual ZitPlaats ZitPlaats1 { get; set; }
    }
}
