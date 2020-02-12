using HospitalManagement.DB;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Repository
{
    public class DoctorPatientRepository : GenericRepository<DoctorPatient>, IDoctorPatientRepository
    {
        public DoctorPatientRepository(HospitalManagementContext context) : base(context)
        {
        }
    }
}
