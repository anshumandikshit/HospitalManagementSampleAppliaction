using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HospitalManagement.Domain.DTOs.RequestDTOs
{
    public class DoctorRequestDto
    {
        [Required(ErrorMessage = "Provide a doctor Name")]
        public int DoctorId { get; set; }

        [MaxLength(20)]
        
        public string DoctorName { get; set; }
    }
}
