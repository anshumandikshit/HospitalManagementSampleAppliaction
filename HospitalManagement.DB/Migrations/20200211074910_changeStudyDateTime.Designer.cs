﻿// <auto-generated />
using System;
using HospitalManagement.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalManagement.DB.Migrations
{
    [DbContext(typeof(HospitalManagementContext))]
    [Migration("20200211074910_changeStudyDateTime")]
    partial class changeStudyDateTime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedById");

                    b.Property<DateTime?>("ModifiedOn");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            DoctorId = 1,
                            CreatedById = 1,
                            CreatedOn = new DateTime(2020, 2, 11, 13, 19, 9, 543, DateTimeKind.Local).AddTicks(4447),
                            DoctorName = "Dilip Kumar",
                            IsDeleted = false
                        },
                        new
                        {
                            DoctorId = 2,
                            CreatedById = 1,
                            CreatedOn = new DateTime(2020, 2, 11, 13, 19, 9, 543, DateTimeKind.Local).AddTicks(4447),
                            DoctorName = "sahdab Khan",
                            IsDeleted = false
                        },
                        new
                        {
                            DoctorId = 3,
                            CreatedById = 1,
                            CreatedOn = new DateTime(2020, 2, 11, 13, 19, 9, 543, DateTimeKind.Local).AddTicks(4447),
                            DoctorName = "Fernades Disuza",
                            IsDeleted = false
                        },
                        new
                        {
                            DoctorId = 4,
                            CreatedById = 1,
                            CreatedOn = new DateTime(2020, 2, 11, 13, 19, 9, 543, DateTimeKind.Local).AddTicks(4447),
                            DoctorName = "Pablo Rodriguez",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.DoctorPatient", b =>
                {
                    b.Property<int>("PatientId");

                    b.Property<int>("DoctorId");

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedById");

                    b.Property<DateTime?>("ModifiedOn");

                    b.HasKey("PatientId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("DoctorPatients");

                    b.HasData(
                        new
                        {
                            PatientId = 1,
                            DoctorId = 2,
                            CreatedById = 1,
                            CreatedOn = new DateTime(2020, 2, 11, 13, 19, 9, 543, DateTimeKind.Local).AddTicks(4447),
                            IsDeleted = false
                        },
                        new
                        {
                            PatientId = 2,
                            DoctorId = 2,
                            CreatedById = 1,
                            CreatedOn = new DateTime(2020, 2, 11, 13, 19, 9, 543, DateTimeKind.Local).AddTicks(4447),
                            IsDeleted = false
                        },
                        new
                        {
                            PatientId = 3,
                            DoctorId = 1,
                            CreatedById = 1,
                            CreatedOn = new DateTime(2020, 2, 11, 13, 19, 9, 543, DateTimeKind.Local).AddTicks(4447),
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DOB");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedById");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("PatientName")
                        .HasMaxLength(20);

                    b.Property<int>("PatientSexId");

                    b.Property<int>("RoomId");

                    b.HasKey("PatientId");

                    b.HasIndex("RoomId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            PatientId = 1,
                            CreatedById = 1,
                            CreatedOn = new DateTime(2020, 2, 11, 13, 19, 9, 543, DateTimeKind.Local).AddTicks(4447),
                            IsDeleted = false,
                            PatientName = "kunal kamra",
                            PatientSexId = 1,
                            RoomId = 2
                        },
                        new
                        {
                            PatientId = 2,
                            CreatedById = 1,
                            CreatedOn = new DateTime(2020, 2, 11, 13, 19, 9, 543, DateTimeKind.Local).AddTicks(4447),
                            IsDeleted = false,
                            PatientName = "Dhara Dikshit",
                            PatientSexId = 2,
                            RoomId = 3
                        },
                        new
                        {
                            PatientId = 3,
                            CreatedById = 1,
                            CreatedOn = new DateTime(2020, 2, 11, 13, 19, 9, 543, DateTimeKind.Local).AddTicks(4447),
                            IsDeleted = false,
                            PatientName = "Sharmila Tagore",
                            PatientSexId = 2,
                            RoomId = 1
                        });
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoomTypeId");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            RoomTypeId = 1
                        },
                        new
                        {
                            RoomId = 2,
                            RoomTypeId = 2
                        },
                        new
                        {
                            RoomId = 3,
                            RoomTypeId = 3
                        });
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Study", b =>
                {
                    b.Property<int>("StudyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descriptions")
                        .IsRequired();

                    b.Property<int>("DoctorId");

                    b.Property<string>("EstimatedEndTime");

                    b.Property<int>("PatientId");

                    b.Property<string>("PlannedStartTime")
                        .IsRequired();

                    b.Property<int>("StudyStatusId");

                    b.HasKey("StudyId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Studies");

                    b.HasData(
                        new
                        {
                            StudyId = 1,
                            Descriptions = "Initial check up",
                            DoctorId = 2,
                            EstimatedEndTime = "2/11/2020",
                            PatientId = 1,
                            PlannedStartTime = "2/11/2020",
                            StudyStatusId = 1
                        },
                        new
                        {
                            StudyId = 2,
                            Descriptions = "Initial check up",
                            DoctorId = 2,
                            EstimatedEndTime = "2/11/2020",
                            PatientId = 2,
                            PlannedStartTime = "2/11/2020",
                            StudyStatusId = 2
                        },
                        new
                        {
                            StudyId = 3,
                            Descriptions = "Initial check up",
                            DoctorId = 1,
                            EstimatedEndTime = "2/11/2020",
                            PatientId = 3,
                            PlannedStartTime = "2/11/2020",
                            StudyStatusId = 2
                        });
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.DoctorPatient", b =>
                {
                    b.HasOne("HospitalManagement.Domain.Entities.Doctor", "Doctor")
                        .WithMany("DoctorPatients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HospitalManagement.Domain.Entities.Patient", "Patient")
                        .WithMany("DoctorPatients")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Patient", b =>
                {
                    b.HasOne("HospitalManagement.Domain.Entities.Room", "Room")
                        .WithMany("Patients")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Study", b =>
                {
                    b.HasOne("HospitalManagement.Domain.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HospitalManagement.Domain.Entities.Patient", "Patient")
                        .WithMany("Studies")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
