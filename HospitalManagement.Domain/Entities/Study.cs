using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static HospitalManagement.Domain.Enums.HospitalmanagementEnums;

namespace HospitalManagement.Domain.Entities
{
    public class Study
    {
        [Key]
        
        public int StudyId { get; set; }

        [Required]
        public string Descriptions { get; set; }

        [Required]
        public string PlannedStartTime { get; set; } 

        public string EstimatedEndTime { get; set; } 

        [Required]
        public StudyStatus StudyStatusId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
    }
}
