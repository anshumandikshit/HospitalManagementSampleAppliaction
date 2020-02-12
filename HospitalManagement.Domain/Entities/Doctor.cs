using HospitalManagement.Domain.Entities.Foundations;
using HospitalManagement.Domain.Interfaces.Foundations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalManagement.Domain.Entities
{

    public class Doctor : AuditableEntity<Doctor>, ISoftDeletable
    {
        public Doctor()
        {
            DoctorPatients = new List<DoctorPatient>();
        }
        [Key]
        
        public int DoctorId { get; set; }

        [MaxLength(20)]
        [Required]
        public string DoctorName { get; set; }

        public virtual ICollection<DoctorPatient> DoctorPatients { get; set; }

        
    }

}
