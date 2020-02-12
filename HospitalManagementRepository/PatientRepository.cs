using HospitalManagement.DB;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Repository
{


    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(HospitalManagementContext context) : base(context)
        {

        }




    }
}
