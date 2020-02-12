using HospitalManagement.DB;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Repository
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(HospitalManagementContext context) : base(context)
        {
        }
    }
}
