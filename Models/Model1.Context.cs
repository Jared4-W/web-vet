﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Examen1_JaredChavez.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MascotaEntities1 : DbContext
    {
        public MascotaEntities1()
            : base("name=MascotaEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbAreas> tbAreas { get; set; }
        public virtual DbSet<tbEstados> tbEstados { get; set; }
        public virtual DbSet<tbLocalidades> tbLocalidades { get; set; }
        public virtual DbSet<tbMunicipios> tbMunicipios { get; set; }
        public virtual DbSet<tbTipoPersonal> tbTipoPersonal { get; set; }
        public virtual DbSet<tbVeterinarios> tbVeterinarios { get; set; }
    }
}