﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcNHS.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NHSPatientServicesEntities : DbContext
    {
        public NHSPatientServicesEntities()
            : base("name=NHSPatientServicesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Fax> Faxes { get; set; }
        public virtual DbSet<GP_Services> GP_Services { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Organisation_Details> Organisation_Details { get; set; }
        public virtual DbSet<Organisation_Type> Organisation_Type { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<ParentOrganisation> ParentOrganisations { get; set; }
        public virtual DbSet<ServicesOrganisation> ServicesOrganisations { get; set; }
        public virtual DbSet<Telephone> Telephones { get; set; }
        public virtual DbSet<Website> Websites { get; set; }
    }
}
