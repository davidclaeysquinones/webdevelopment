﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VoetbalClubEntities : DbContext
    {
        public VoetbalClubEntities()
            : base("name=VoetbalClubEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Abonnement> Abonnement { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Boeking> Boeking { get; set; }
        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<Stadion> Stadion { get; set; }
        public virtual DbSet<Vak> Vak { get; set; }
        public virtual DbSet<Wedstrijd> Wedstrijd { get; set; }
        public virtual DbSet<ZitPlaats> ZitPlaats { get; set; }
    }
}
