//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TPA_ES.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ScheduleSM
    {
        public int Id { get; set; }
        public Nullable<int> ReportID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<System.DateTime> DateToRepair { get; set; }
        public string ItemStatus { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
