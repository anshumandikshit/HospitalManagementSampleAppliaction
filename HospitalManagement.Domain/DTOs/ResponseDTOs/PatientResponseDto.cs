using System;
using System.Collections.Generic;
using System.Text;
using static HospitalManagement.Domain.Enums.HospitalmanagementEnums;

namespace HospitalManagement.Domain.DTOs.ResponseDTOs
{
    public class PatientResponseDto
    {
        public int PatientId { get; set; }

        public string PatientName { get; set; }

        public ICollection<DoctorResponseDto> DoctorDetails { get; set; }

        public PatientSex PatientSexId { get; set; }

        public RoomName RoomTypeId { get; set; }

        public ICollection<StudyResponseDto> StudyDetails { get; set; }
    }
}
