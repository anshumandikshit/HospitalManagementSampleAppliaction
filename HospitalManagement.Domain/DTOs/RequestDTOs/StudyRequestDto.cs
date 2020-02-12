using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static HospitalManagement.Domain.Enums.HospitalmanagementEnums;

namespace HospitalManagement.Domain.DTOs.RequestDTOs
{
   public class StudyRequestDto
    {
        [Required(ErrorMessage ="You must provide a description")]
        public string Descriptions { get; set; }

        [Required]
        public StudyStatus StudyStatusId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        public string EstimatedEndTime { get; set; }
    }
}
