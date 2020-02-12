using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static HospitalManagement.Domain.Enums.HospitalmanagementEnums;

namespace HospitalManagement.Domain.Entities
{
   public class Room
    {
        public Room()
        {
            Patients = new List<Patient>();
        }
        [Key]
        
        public int RoomId { get; set; }

        
        [Required]
        public RoomName RoomTypeId { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
