//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zadatak_1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblAbsence
    {
        public int AbsenceId { get; set; }
        public int UserId { get; set; }
        public System.DateTime FirstDay { get; set; }
        public System.DateTime LastDay { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
    
        public virtual tblUser tblUser { get; set; }
    }
}
