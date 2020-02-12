using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Domain.Enums
{
    public class HospitalmanagementEnums
    {
        public enum RoomName
        {
            SingleSeated=1,
            TwoSeated=2,
            VIP=3
        }

        public enum StudyStatus
        {
            Planned=1,
            InProgress=2,
            Finished=3

        }

        public enum PatientSex
        {
            Male = 1,
            Female = 2,
            Other = 3

        }
    }
}
