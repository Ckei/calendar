//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebCalendar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentMessage { get; set; }
        public int UserId { get; set; }
        public string AppointmentColor { get; set; }
        public Nullable<long> AppointmentStartTime { get; set; }
        public Nullable<long> AppointmentEndTime { get; set; }
    
        public virtual User User { get; set; }
    }
}
