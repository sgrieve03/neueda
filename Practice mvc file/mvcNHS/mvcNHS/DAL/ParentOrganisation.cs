//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ParentOrganisation
    {
        public int Parent_Organisation_ID { get; set; }
        public Nullable<int> Ref_Organisation_Details_ID { get; set; }
        public Nullable<int> Ref_Parent_ID { get; set; }
    
        public virtual Organisation_Details Organisation_Details { get; set; }
        public virtual Parent Parent { get; set; }
    }
}
