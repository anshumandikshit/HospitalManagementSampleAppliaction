using System;
using System.Collections.Generic;
using System.Text;
using static HospitalManagement.Domain.Enums.HospitalmanagementEnums;

namespace HospitalManagement.Domain.DTOs.ResponseDTOs
{
   public class StudyResponseDto
    {
        public int StudyId { get; set; }

        public string DoctorName { get; set; }

        public string Description { get; set; }

        public string StartDate { get; set; }

        public string EstimatedEndDate { get; set; }

        public StudyStatus StudyStatusId { get; set; }
    }
}
