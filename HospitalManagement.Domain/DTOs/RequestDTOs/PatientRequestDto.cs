using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static HospitalManagement.Domain.Enums.HospitalmanagementEnums;

namespace HospitalManagement.Domain.DTOs.RequestDTOs
{
    public class PatientRequestDto
    {
        public PatientRequestDto()
        {
            DoctorRequests = new List<DoctorRequestDto>();
            StudyRequests = new List<StudyRequestDto>();
        }

        public int PatientId { get; set; }
        
        [Required(ErrorMessage ="You can not make this field empty")]
        [MaxLength(20,ErrorMessage ="Maximum length can not be more than 20")]
        [MinLength(2, ErrorMessage = "Minimum length should be more than 2")]
        public string PatientName { get; set; }

        public string DOB { get; set; }

        public PatientSex PatientSex { get; set; }

        [Required(ErrorMessage ="you must consult atleast one doctor")]
        public List<DoctorRequestDto> DoctorRequests { get; set; }

        public List<StudyRequestDto> StudyRequests { get; set; }

        [Required(ErrorMessage ="You have to provide a room type" )]
        public RoomName RoomNameId { get; set; }

        
    }
}
