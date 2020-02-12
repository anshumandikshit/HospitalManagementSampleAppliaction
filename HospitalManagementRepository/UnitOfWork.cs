using HospitalManagement.DB;
using HospitalManagement.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private HospitalManagementContext _context;

        public UnitOfWork(HospitalManagementContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_context == null) return;
            _context.Dispose();
            _context = null;
        }
    }
}
