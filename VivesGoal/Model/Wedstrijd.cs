//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Wedstrijd
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wedstrijd()
        {
            this.Boeking = new HashSet<Boeking>();
        }
    
        public int id { get; set; }
        public System.DateTime datum { get; set; }
        public int thuisploeg { get; set; }
        public int bezoekers { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Boeking> Boeking { get; set; }
        public virtual Club Club { get; set; }
        public virtual Club Club1 { get; set; }
    }
}
