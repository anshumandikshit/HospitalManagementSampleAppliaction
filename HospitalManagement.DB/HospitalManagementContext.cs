using HospitalManagement.Domain.Entities;
using HospitalManagement.Domain.Interfaces.Foundations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalManagement.DB
{
   public class HospitalManagementContext:DbContext
    {
        public HospitalManagementContext(DbContextOptions<HospitalManagementContext> options) : base(options)
        {
            
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<DoctorPatient> DoctorPatients { get; set; }

        public DbSet<Study> Studies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DoctorPatient>()
        .HasKey(dp => new { dp.PatientId, dp.DoctorId });
            modelBuilder.Entity<DoctorPatient>()
                .HasOne(bc => bc.Patient)
                .WithMany(b => b.DoctorPatients)
                .HasForeignKey(bc => bc.PatientId);
            modelBuilder.Entity<DoctorPatient>()
                .HasOne(bc => bc.Doctor)
                .WithMany(c => c.DoctorPatients)
                .HasForeignKey(bc => bc.DoctorId);

            modelBuilder.ShadowProperties();
            SetGlobalQueryFilters(modelBuilder);
            modelBuilder.SeedData();
        }

        public override int SaveChanges()
        {
            try
            {
                OverrideSaveChanges();
                return base.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                OverrideSaveChanges();
                return await base.SaveChangesAsync(true, cancellationToken);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void OverrideSaveChanges()
        {

            var modifiedEntries = ChangeTracker.Entries()
                    .Where(x => x.Entity is IAuditableEntity &&
                                (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));

            //var addedChangeLogs = new List<ChangeLog>();
            var auditableProperties = GetAuditableProperties();
            Guid batchId = Guid.NewGuid();
            int sourceId;
            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity;
                if (entity != null)
                {
                    var now = DateTime.Now;
                    if (entity is IAuditableEntity)
                    {
                        if (entry.State == EntityState.Added)
                        {
                            entry.Property("CreatedOn").CurrentValue = now;
                            //entry.Property("CreatedById").CurrentValue = _userSession.UserId;
                            if (entity is ISoftDeletable)
                            {
                                entry.Property("IsDeleted").CurrentValue = false;
                            }


                           
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            entry.Property("ModifiedOn").CurrentValue = now;
                            //entry.Property("ModifiedById").CurrentValue = _userSession.UserId;

                            //Log The Entity Details
                            //if (entry.Entity is ITrackable)
                            //{
                            //    var entityName = entry.Metadata.Name;
                            //    var primaryKey = GetPrimaryKeyValue(entry);
                            //    int.TryParse(primaryKey.ToString(), out sourceId);
                            //    if (sourceId == 0)
                            //    {
                            //        return;
                            //    }
                            //    foreach (var prop in entry.OriginalValues.Properties.Where(x => !auditableProperties.Contains(x.Name)))
                            //    {
                            //        var originalValue = entry.OriginalValues[prop]?.ToString();
                            //        var currentValue = entry.CurrentValues[prop]?.ToString();
                            //        //if (originalValue != currentValue)
                            //        //{
                            //        //    ChangeLog log = new ChangeLog()
                            //        //    {
                            //        //        EntityName = entityName,
                            //        //        // PrimaryKeyValue = new Guid(primaryKey.ToString()),
                            //        //        PrimaryKeyValue = sourceId,
                            //        //        PropertyName = prop.Name,
                            //        //        OldValue = originalValue,
                            //        //        NewValue = currentValue,
                            //        //        CreatedBy = _userSession.UserId,
                            //        //        CreatedDate = now,
                            //        //        BatchId = batchId
                            //        //    };
                            //        //    addedChangeLogs.Add(log);
                            //        //}
                            //    }
                            //}

                        }
                        else
                        {
                            if (entity is ISoftDeletable)
                            {
                                entry.State = EntityState.Modified;
                                entry.Property("IsDeleted").CurrentValue = true;
                            }

                        }
                    }
                }
            }
            //if (addedChangeLogs.Any())
            //{
            //    ChangeLogs.AddRange(addedChangeLogs);
            //}
        }

        private List<string> GetAuditableProperties()
        {
            return typeof(IAuditableEntity).GetProperties().Select(x => x.Name).ToList();
        }
        private void SetGlobalQueryFilters(ModelBuilder modelBuilder)
        {

            foreach (var tp in modelBuilder.Model.GetEntityTypes())
            {
                var t = tp.ClrType;

                // set global filters
                if (typeof(IAuditableEntity).IsAssignableFrom(t))
                {
                    
                    
                        // softdeletable
                        var method = SetGlobalQueryForSoftDeleteMethodInfo.MakeGenericMethod(t);
                        method.Invoke(this, new object[] { modelBuilder });
                    
                }
            }
        }

        private static readonly MethodInfo SetGlobalQueryForSoftDeleteMethodInfo = typeof(HospitalManagementContext).GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQueryForSoftDelete");

        public void SetGlobalQueryForSoftDelete<T>(ModelBuilder builder) where T : class, IAuditableEntity
        {
            builder.Entity<T>().HasQueryFilter(item => !EF.Property<bool>(item, "IsDeleted"));
        }

    }
}
