namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Club")]
    public partial class Club
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Club()
        {
            Abonnements = new HashSet<Abonnement>();
            Wedstrijds = new HashSet<Wedstrijd>();
            Wedstrijds1 = new HashSet<Wedstrijd>();
        }

        public int id { get; set; }

        [Column("stadion id")]
        public int stadion_id { get; set; }

        [StringLength(30)]
        public string naam { get; set; }

        [StringLength(255)]
        public string logo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Abonnement> Abonnements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wedstrijd> Wedstrijds { get; set; }

        public virtual Stadion Stadion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wedstrijd> Wedstrijds1 { get; set; }
    }
}
