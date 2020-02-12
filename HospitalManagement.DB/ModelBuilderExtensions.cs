using HospitalManagement.Domain.Entities;
using HospitalManagement.Domain.Interfaces.Foundations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using static HospitalManagement.Domain.Enums.HospitalmanagementEnums;

namespace HospitalManagement.DB
{
    public static class ModelBuilderExtensions
    {
        public static void ShadowProperties(this ModelBuilder modelBuilder)
        {
            var entityTypes = modelBuilder.Model.GetEntityTypes().ToList();
            foreach (var tp in entityTypes)
            {
                var t = tp.ClrType;

                // set auditing properties
                //if (typeof(IAuditableEntity).IsAssignableFrom(t))
                //{
                //    var method = SetAuditingShadowPropertiesMethodInfo.MakeGenericMethod(t);
                //    method.Invoke(modelBuilder, new object[] { modelBuilder });
                //}

                // set tenant properties

                if (typeof(ISoftDeletable).IsAssignableFrom(t))
                {
                    var method = SetIsDeletableShadowPropertiesMethodInfo.MakeGenericMethod(t);
                    method.Invoke(modelBuilder, new object[] { modelBuilder });
                }
            }
        }


        private static readonly MethodInfo SetAuditingShadowPropertiesMethodInfo = typeof(ModelBuilderExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(t => t.IsGenericMethod && t.Name == "SetAuditingShadowProperties");

        private static readonly MethodInfo SetIsDeletableShadowPropertiesMethodInfo = typeof(ModelBuilderExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Single(t => t.IsGenericMethod && t.Name == "SetIsDeletableShadowProperties");



        public static void SetAuditingShadowProperties<T>(ModelBuilder builder) where T : class, IAuditableEntity
        {
            // define shadow properties
            builder.Entity<T>().Property<DateTime>("CreatedOn");
            builder.Entity<T>().Property<DateTime?>("ModifiedOn");
            builder.Entity<T>().Property<Guid>("CreatedById");
            builder.Entity<T>().Property<Guid?>("ModifiedById");
            builder.Entity<T>().Property<bool>("IsDeleted");
        }
        public static void SetIsDeletableShadowProperties<T>(ModelBuilder builder) where T : class, ISoftDeletable
        {
            // define shadow properties
            builder.Entity<T>().Property<bool>("IsDeleted");
        }

        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var now = DateTime.Now;
            modelBuilder.Entity<Doctor>().HasData(new
            {
                DoctorId=1,
                DoctorName ="Dilip Kumar",
                CreatedOn = now,
                IsDeleted = false,
                CreatedById=1
            });

            modelBuilder.Entity<Doctor>().HasData(new
            {
                DoctorId = 2,
                DoctorName = "sahdab Khan",
                CreatedOn = now,
                IsDeleted = false,
                CreatedById = 1
            });

            modelBuilder.Entity<Doctor>().HasData(new
            {
                DoctorId = 3,
                DoctorName = "Fernades Disuza",
                CreatedOn = now,
                IsDeleted = false,
                CreatedById = 1

            });

            modelBuilder.Entity<Doctor>().HasData(new
            {
                DoctorId = 4,
                DoctorName = "Pablo Rodriguez",
                CreatedOn = now,
                IsDeleted = false,
                CreatedById = 1

            });

            modelBuilder.Entity<Room>().HasData(new
            {
                RoomId=1,
                RoomTypeId=RoomName.SingleSeated,
                CreatedOn = now,
                IsDeleted = false,
                CreatedById = 1

            });

            modelBuilder.Entity<Room>().HasData(new
            {
                RoomId = 2,
                RoomTypeId = RoomName.TwoSeated,
                CreatedOn = now,
                IsDeleted = false,
                CreatedById = 1

            });

            modelBuilder.Entity<Room>().HasData(new
            {
                RoomId = 3,
                RoomTypeId = RoomName.VIP,
                CreatedOn = now,
                IsDeleted = false,
                CreatedById = 1

            });

            

            modelBuilder.Entity<Patient>().HasData(new
            {
                PatientId=1,
                PatientName = "kunal kamra",
                PatientSexId= PatientSex.Male,
                RoomId=2,
                CreatedOn = now,
                IsDeleted = false,
                CreatedById = 1

            });

            modelBuilder.Entity<Patient>().HasData(new
            {
                PatientId = 2,
                PatientName = "Dhara Dikshit",
                PatientSexId = PatientSex.Female,
                RoomId=3,
                CreatedOn = now,
                IsDeleted = false,
                CreatedById = 1

            });

            modelBuilder.Entity<Patient>().HasData(new
            {
                PatientId = 3,
                PatientName = "Sharmila Tagore",
                PatientSexId = PatientSex.Female,
                RoomId=1,
                CreatedOn = now,
                IsDeleted = false,
                CreatedById = 1

            });

            modelBuilder.Entity<DoctorPatient>().HasData(new
            {

                PatientId=1,
                DoctorId=2,
                CreatedOn = now,
                IsDeleted = false,
                CreatedById = 1

            });

           

            modelBuilder.Entity<DoctorPatient>().HasData(new
            {

                PatientId = 2,
                DoctorId = 2,
                CreatedOn = now,
                IsDeleted = false,
                CreatedById = 1

            });

            modelBuilder.Entity<DoctorPatient>().HasData(new
            {

                PatientId = 3,
                DoctorId = 1,
                CreatedOn = now,
                IsDeleted = false,
                CreatedById = 1

            });

            modelBuilder.Entity<Study>().HasData(new
            {
                StudyId=1,
                Descriptions = "Initial check up",
                PlannedStartTime = DateTime.Now.ToShortDateString(),
                EstimatedEndTime = DateTime.Now.ToShortDateString(),
                StudyStatusId =StudyStatus.Planned,
                PatientId=1,
                DoctorId=2,
                CreatedOn = now,
                IsDeleted = false,
                CreatedById = 1

            });

            modelBuilder.Entity<Study>().HasData(new
            {
                StudyId = 2,
                Descriptions = "Initial check up",
                PlannedStartTime = DateTime.Now.ToShortDateString(),
                EstimatedEndTime= DateTime.Now.ToShortDateString(),
                StudyStatusId = StudyStatus.InProgress,
                PatientId = 2,
                DoctorId = 2,
                CreatedOn = now,
                IsDeleted = false,
                CreatedById = 1

            });

            modelBuilder.Entity<Study>().HasData(new
            {
                StudyId = 3,
                Descriptions = "Initial check up",
                PlannedStartTime = DateTime.Now.ToShortDateString(),
                EstimatedEndTime = DateTime.Now.ToShortDateString(),
                StudyStatusId = StudyStatus.InProgress,
                PatientId = 3,
                DoctorId = 1,
                CreatedOn = now,
                IsDeleted = false,
                CreatedById = 1

            });

        }

    }
}
