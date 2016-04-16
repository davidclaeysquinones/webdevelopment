namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Wedstrijd")]
    public partial class Wedstrijd
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wedstrijd()
        {
            Boekings = new HashSet<Boeking>();
        }

        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime datum { get; set; }

        public int thuisploeg { get; set; }

        public int bezoekers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Boeking> Boekings { get; set; }

        public virtual Club Club { get; set; }

        public virtual Club Club1 { get; set; }
    }
}
