﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NHSPatServ
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NHSPatientServicesEntities6 : DbContext
    {
        public NHSPatientServicesEntities6()
            : base("name=NHSPatientServicesEntities6")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Fax> Faxes { get; set; }
        public virtual DbSet<GP_Disease_Prevalence> GP_Disease_Prevalence { get; set; }
        public virtual DbSet<GP_Practice_Code> GP_Practice_Code { get; set; }
        public virtual DbSet<GP_Ratings> GP_Ratings { get; set; }
        public virtual DbSet<GP_Services> GP_Services { get; set; }
        public virtual DbSet<GP_Staff> GP_Staff { get; set; }
        public virtual DbSet<GP_Total_Numbers> GP_Total_Numbers { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Organisation_Details> Organisation_Details { get; set; }
        public virtual DbSet<Organisation_Type> Organisation_Type { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<ParentOrganisation> ParentOrganisations { get; set; }
        public virtual DbSet<ServicesOrganisation> ServicesOrganisations { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Telephone> Telephones { get; set; }
        public virtual DbSet<Website> Websites { get; set; }
    
        public virtual ObjectResult<sp_All_England_Disease_Avg_Result> sp_All_England_Disease_Avg()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_All_England_Disease_Avg_Result>("sp_All_England_Disease_Avg");
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual ObjectResult<sp_AverageAllDiseaseInNHSTrust_Result> sp_AverageAllDiseaseInNHSTrust(string organisationCode)
        {
            var organisationCodeParameter = organisationCode != null ?
                new ObjectParameter("organisationCode", organisationCode) :
                new ObjectParameter("organisationCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_AverageAllDiseaseInNHSTrust_Result>("sp_AverageAllDiseaseInNHSTrust", organisationCodeParameter);
        }
    
        public virtual ObjectResult<sp_AverageRatingInEngland_Result> sp_AverageRatingInEngland()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_AverageRatingInEngland_Result>("sp_AverageRatingInEngland");
        }
    
        public virtual ObjectResult<sp_AverageRatingInTrust_Result> sp_AverageRatingInTrust(string organisationCode)
        {
            var organisationCodeParameter = organisationCode != null ?
                new ObjectParameter("organisationCode", organisationCode) :
                new ObjectParameter("organisationCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_AverageRatingInTrust_Result>("sp_AverageRatingInTrust", organisationCodeParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_AverageSpecificDiseaseInNHSTrust(string organisationCode, string indicator_group)
        {
            var organisationCodeParameter = organisationCode != null ?
                new ObjectParameter("organisationCode", organisationCode) :
                new ObjectParameter("organisationCode", typeof(string));
    
            var indicator_groupParameter = indicator_group != null ?
                new ObjectParameter("indicator_group", indicator_group) :
                new ObjectParameter("indicator_group", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_AverageSpecificDiseaseInNHSTrust", organisationCodeParameter, indicator_groupParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_MaxAllDiseaseInEngland_Result> sp_MaxAllDiseaseInEngland()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_MaxAllDiseaseInEngland_Result>("sp_MaxAllDiseaseInEngland");
        }
    
        public virtual ObjectResult<sp_MaxAllDiseaseInNHSTrust_Result> sp_MaxAllDiseaseInNHSTrust(string organisationCode)
        {
            var organisationCodeParameter = organisationCode != null ?
                new ObjectParameter("organisationCode", organisationCode) :
                new ObjectParameter("organisationCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_MaxAllDiseaseInNHSTrust_Result>("sp_MaxAllDiseaseInNHSTrust", organisationCodeParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_MaxSpecificDiseaseInEngland(string indicatorGroup)
        {
            var indicatorGroupParameter = indicatorGroup != null ?
                new ObjectParameter("IndicatorGroup", indicatorGroup) :
                new ObjectParameter("IndicatorGroup", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_MaxSpecificDiseaseInEngland", indicatorGroupParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_MaxSpecificDiseaseInNHSTrust(string organisationCode, string indicatorGroup)
        {
            var organisationCodeParameter = organisationCode != null ?
                new ObjectParameter("organisationCode", organisationCode) :
                new ObjectParameter("organisationCode", typeof(string));
    
            var indicatorGroupParameter = indicatorGroup != null ?
                new ObjectParameter("IndicatorGroup", indicatorGroup) :
                new ObjectParameter("IndicatorGroup", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_MaxSpecificDiseaseInNHSTrust", organisationCodeParameter, indicatorGroupParameter);
        }
    
        public virtual ObjectResult<sp_MinAllDiseaseInEngland_Result> sp_MinAllDiseaseInEngland()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_MinAllDiseaseInEngland_Result>("sp_MinAllDiseaseInEngland");
        }
    
        public virtual ObjectResult<sp_MinAllDiseaseInNHSTrust_Result> sp_MinAllDiseaseInNHSTrust(string organisationCode)
        {
            var organisationCodeParameter = organisationCode != null ?
                new ObjectParameter("organisationCode", organisationCode) :
                new ObjectParameter("organisationCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_MinAllDiseaseInNHSTrust_Result>("sp_MinAllDiseaseInNHSTrust", organisationCodeParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_MinSpecificDiseaseInEngland(string indicatorGroup)
        {
            var indicatorGroupParameter = indicatorGroup != null ?
                new ObjectParameter("IndicatorGroup", indicatorGroup) :
                new ObjectParameter("IndicatorGroup", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_MinSpecificDiseaseInEngland", indicatorGroupParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_MinSpecificDiseaseInNHSTrust(string organisationCode, string indicatorGroup)
        {
            var organisationCodeParameter = organisationCode != null ?
                new ObjectParameter("organisationCode", organisationCode) :
                new ObjectParameter("organisationCode", typeof(string));
    
            var indicatorGroupParameter = indicatorGroup != null ?
                new ObjectParameter("IndicatorGroup", indicatorGroup) :
                new ObjectParameter("IndicatorGroup", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_MinSpecificDiseaseInNHSTrust", organisationCodeParameter, indicatorGroupParameter);
        }
    
        public virtual ObjectResult<string> sp_NameOfTrust(string organisationCode)
        {
            var organisationCodeParameter = organisationCode != null ?
                new ObjectParameter("organisationCode", organisationCode) :
                new ObjectParameter("organisationCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("sp_NameOfTrust", organisationCodeParameter);
        }
    
        public virtual ObjectResult<sp_plot_Result> sp_plot()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_plot_Result>("sp_plot");
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual ObjectResult<sp_Specified_England_Disease_Avg_Result> sp_Specified_England_Disease_Avg(string @ref)
        {
            var refParameter = @ref != null ?
                new ObjectParameter("ref", @ref) :
                new ObjectParameter("ref", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Specified_England_Disease_Avg_Result>("sp_Specified_England_Disease_Avg", refParameter);
        }
    
        public virtual ObjectResult<sp_TotalAllDiseaseInSpecificGp_Result> sp_TotalAllDiseaseInSpecificGp(string organisationCode)
        {
            var organisationCodeParameter = organisationCode != null ?
                new ObjectParameter("organisationCode", organisationCode) :
                new ObjectParameter("organisationCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_TotalAllDiseaseInSpecificGp_Result>("sp_TotalAllDiseaseInSpecificGp", organisationCodeParameter);
        }
    
        public virtual ObjectResult<sp_TotalRatingInGP_Result> sp_TotalRatingInGP(string organisationCode)
        {
            var organisationCodeParameter = organisationCode != null ?
                new ObjectParameter("organisationCode", organisationCode) :
                new ObjectParameter("organisationCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_TotalRatingInGP_Result>("sp_TotalRatingInGP", organisationCodeParameter);
        }
    
        public virtual ObjectResult<sp_TotalSpecificDiseaseInGP_Result> sp_TotalSpecificDiseaseInGP(string indicatorGroup, string organisationCode)
        {
            var indicatorGroupParameter = indicatorGroup != null ?
                new ObjectParameter("indicatorGroup", indicatorGroup) :
                new ObjectParameter("indicatorGroup", typeof(string));
    
            var organisationCodeParameter = organisationCode != null ?
                new ObjectParameter("organisationCode", organisationCode) :
                new ObjectParameter("organisationCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_TotalSpecificDiseaseInGP_Result>("sp_TotalSpecificDiseaseInGP", indicatorGroupParameter, organisationCodeParameter);
        }
    
        public virtual ObjectResult<sp_TotalStaffInSpecificGP_Result> sp_TotalStaffInSpecificGP(string @ref)
        {
            var refParameter = @ref != null ?
                new ObjectParameter("ref", @ref) :
                new ObjectParameter("ref", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_TotalStaffInSpecificGP_Result>("sp_TotalStaffInSpecificGP", refParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}