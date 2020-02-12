using HospitalManagement.Domain.Interfaces.Foundations;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Domain.Entities.Foundations
{
    public class AuditableEntity<T> : IAuditableEntity
    {
        public DateTime CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedById { get; set; }
    }
}
