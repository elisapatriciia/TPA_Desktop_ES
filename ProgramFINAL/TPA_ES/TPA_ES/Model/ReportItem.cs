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
    
    public partial class ReportItem
    {
        public int Id { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> EmployeePositionID { get; set; }
        public Nullable<int> ItemCode { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> ReportDate { get; set; }
        public Nullable<System.DateTime> RepairDate { get; set; }
        public string ReportStatus { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Item Item { get; set; }
    }
}
