//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NHS_Patient_Services
{
    using System;
    using System.Collections.Generic;
    
    public partial class Telephone
    {
        public int Ref_Organisation_Details_ID { get; set; }
        public string Telephone_Number { get; set; }
    
        public virtual Organisation_Details Organisation_Details { get; set; }
    }
}
