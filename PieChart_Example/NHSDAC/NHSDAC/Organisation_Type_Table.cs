//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NHSDAC
{
    using System;
    using System.Collections.Generic;
    
    public partial class Organisation_Type_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organisation_Type_Table()
        {
            this.Organisation_Details = new HashSet<Organisation_Details>();
        }
    
        public int Organisation_Type_ID { get; set; }
        public string Organisation_Type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Organisation_Details> Organisation_Details { get; set; }
    }
}