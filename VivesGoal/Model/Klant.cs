namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Klant")]
    public partial class Klant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klant()
        {
            Abonnements = new HashSet<Abonnement>();
            Boekings = new HashSet<Boeking>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string voornaam { get; set; }

        [Required]
        [StringLength(255)]
        public string naam { get; set; }

        [StringLength(255)]
        public string adres { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Abonnement> Abonnements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Boeking> Boekings { get; set; }
    }
}
