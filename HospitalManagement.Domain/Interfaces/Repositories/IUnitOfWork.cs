using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork:IDisposable
    {
        int Commit();
        Task<int> CommitAsync();
        void Dispose(bool disposing);
    }
}
