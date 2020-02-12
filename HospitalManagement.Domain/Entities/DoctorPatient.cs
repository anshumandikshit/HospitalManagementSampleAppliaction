using HospitalManagement.Domain.Entities.Foundations;
using HospitalManagement.Domain.Interfaces.Foundations;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Domain.Entities
{
   public class DoctorPatient:AuditableEntity<DoctorPatient>, ISoftDeletable
    {
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
