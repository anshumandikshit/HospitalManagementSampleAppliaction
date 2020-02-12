using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Domain.Interfaces.Foundations
{
    public interface IAuditableEntity
    {
        DateTime CreatedOn { get; set; }
        int CreatedById { get; set; }
        DateTime? ModifiedOn { get; set; }
        int? ModifiedById { get; set; }

    }
}
