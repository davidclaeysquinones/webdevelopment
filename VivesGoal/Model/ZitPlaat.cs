namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ZitPlaat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ZitPlaat()
        {
            Abonnements = new HashSet<Abonnement>();
            Boekings = new HashSet<Boeking>();
        }

        public int id { get; set; }

        [Column("vak id")]
        public int vak_id { get; set; }

        public int stadion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Abonnement> Abonnements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Boeking> Boekings { get; set; }

        public virtual Stadion Stadion1 { get; set; }

        public virtual Vak Vak { get; set; }
    }
}
