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
    
    public partial class EmployeeLeavingPermit
    {
        public int Id { get; set; }
        public int EmployeeID { get; set; }
        public string Reason { get; set; }
        public System.DateTime LeavingDateStart { get; set; }
        public System.DateTime LeavingDateEnd { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}