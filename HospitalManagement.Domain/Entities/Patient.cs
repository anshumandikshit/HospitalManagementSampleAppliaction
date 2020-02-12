using HospitalManagement.Domain.Entities.Foundations;
using HospitalManagement.Domain.Interfaces.Foundations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static HospitalManagement.Domain.Enums.HospitalmanagementEnums;

namespace HospitalManagement.Domain.Entities
{
   public class Patient: AuditableEntity<Patient>, ISoftDeletable
    {
        public Patient()
        {
            DoctorPatients = new List<DoctorPatient>();
            Studies = new List<Study>();
        }
        
        [Key]
        
        public int PatientId { get; set; }

        [MaxLength(20)]
        public string PatientName { get; set; }

        public string DOB { get; set; }

        public PatientSex PatientSexId { get; set; }

        public virtual ICollection<DoctorPatient> DoctorPatients { get; set; }

        [Required]
        public int RoomId { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

        public virtual ICollection<Study> Studies { get; set; }
    }
}
