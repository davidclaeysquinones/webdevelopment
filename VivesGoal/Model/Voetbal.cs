namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Voetbal : DbContext
    {
        public Voetbal()
            : base("name=Voetbal")
        {
        }

        public virtual DbSet<Abonnement> Abonnements { get; set; }
        public virtual DbSet<Boeking> Boekings { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Klant> Klants { get; set; }
        public virtual DbSet<Stadion> Stadions { get; set; }
        public virtual DbSet<Vak> Vaks { get; set; }
        public virtual DbSet<Wedstrijd> Wedstrijds { get; set; }
        public virtual DbSet<ZitPlaat> ZitPlaats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>()
                .Property(e => e.naam)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.logo)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Abonnements)
                .WithRequired(e => e.Club1)
                .HasForeignKey(e => e.club)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Wedstrijds)
                .WithRequired(e => e.Club)
                .HasForeignKey(e => e.bezoekers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Wedstrijds1)
                .WithRequired(e => e.Club1)
                .HasForeignKey(e => e.thuisploeg)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Klant>()
                .Property(e => e.voornaam)
                .IsUnicode(false);

            modelBuilder.Entity<Klant>()
                .Property(e => e.naam)
                .IsUnicode(false);

            modelBuilder.Entity<Klant>()
                .Property(e => e.adres)
                .IsUnicode(false);

            modelBuilder.Entity<Klant>()
                .HasMany(e => e.Abonnements)
                .WithRequired(e => e.Klant1)
                .HasForeignKey(e => e.klant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Klant>()
                .HasMany(e => e.Boekings)
                .WithRequired(e => e.Klant1)
                .HasForeignKey(e => e.klant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stadion>()
                .Property(e => e.naam)
                .IsUnicode(false);

            modelBuilder.Entity<Stadion>()
                .Property(e => e.adres)
                .IsUnicode(false);

            modelBuilder.Entity<Stadion>()
                .HasMany(e => e.Clubs)
                .WithRequired(e => e.Stadion)
                .HasForeignKey(e => e.stadion_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stadion>()
                .HasMany(e => e.ZitPlaats)
                .WithRequired(e => e.Stadion1)
                .HasForeignKey(e => e.stadion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vak>()
                .Property(e => e.naam)
                .IsUnicode(false);

            modelBuilder.Entity<Vak>()
                .HasMany(e => e.ZitPlaats)
                .WithRequired(e => e.Vak)
                .HasForeignKey(e => e.vak_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Wedstrijd>()
                .HasMany(e => e.Boekings)
                .WithRequired(e => e.Wedstrijd1)
                .HasForeignKey(e => e.Wedstrijd)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ZitPlaat>()
                .HasMany(e => e.Abonnements)
                .WithRequired(e => e.ZitPlaat)
                .HasForeignKey(e => e.zitplaats)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ZitPlaat>()
                .HasMany(e => e.Boekings)
                .WithRequired(e => e.ZitPlaat)
                .HasForeignKey(e => e.zitplaats)
                .WillCascadeOnDelete(false);
        }
    }
}
