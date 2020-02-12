using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagement.DB.Migrations
{
    public partial class updateSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "CreatedById", "CreatedOn", "DoctorName", "IsDeleted", "ModifiedById", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 2, 6, 16, 57, 47, 482, DateTimeKind.Local).AddTicks(3908), "Dilip Kumar", false, null, null },
                    { 2, 1, new DateTime(2020, 2, 6, 16, 57, 47, 482, DateTimeKind.Local).AddTicks(3908), "sahdab Khan", false, null, null },
                    { 3, 1, new DateTime(2020, 2, 6, 16, 57, 47, 482, DateTimeKind.Local).AddTicks(3908), "Fernades Disuza", false, null, null },
                    { 4, 1, new DateTime(2020, 2, 6, 16, 57, 47, 482, DateTimeKind.Local).AddTicks(3908), "Pablo Rodriguez", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "CreatedById", "CreatedOn", "DOB", "IsDeleted", "ModifiedById", "ModifiedOn", "PatientName", "PatientSexId", "RoomId" },
                values: new object[] { 3, 1, new DateTime(2020, 2, 6, 16, 57, 47, 482, DateTimeKind.Local).AddTicks(3908), null, false, null, null, "Sharmila Tagore", 2, 1 });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "CreatedById", "CreatedOn", "DOB", "IsDeleted", "ModifiedById", "ModifiedOn", "PatientName", "PatientSexId", "RoomId" },
                values: new object[] { 1, 1, new DateTime(2020, 2, 6, 16, 57, 47, 482, DateTimeKind.Local).AddTicks(3908), null, false, null, null, "kunal kamra", 1, 2 });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "CreatedById", "CreatedOn", "DOB", "IsDeleted", "ModifiedById", "ModifiedOn", "PatientName", "PatientSexId", "RoomId" },
                values: new object[] { 2, 1, new DateTime(2020, 2, 6, 16, 57, 47, 482, DateTimeKind.Local).AddTicks(3908), null, false, null, null, "Dhara Dikshit", 2, 3 });

            migrationBuilder.InsertData(
                table: "DoctorPatients",
                columns: new[] { "PatientId", "DoctorId", "CreatedById", "CreatedOn", "IsDeleted", "ModifiedById", "ModifiedOn" },
                values: new object[,]
                {
                    { 3, 1, 1, new DateTime(2020, 2, 6, 16, 57, 47, 482, DateTimeKind.Local).AddTicks(3908), false, null, null },
                    { 1, 2, 1, new DateTime(2020, 2, 6, 16, 57, 47, 482, DateTimeKind.Local).AddTicks(3908), false, null, null },
                    { 2, 2, 1, new DateTime(2020, 2, 6, 16, 57, 47, 482, DateTimeKind.Local).AddTicks(3908), false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Studies",
                columns: new[] { "StudyId", "Descriptions", "DoctorId", "EstimatedEndTime", "PatientId", "PlannedStartTime", "StudyStatusId" },
                values: new object[,]
                {
                    { 3, "Initial check up", 1, new DateTime(2020, 2, 6, 16, 57, 47, 485, DateTimeKind.Local).AddTicks(2619), 3, new DateTime(2020, 2, 6, 16, 57, 47, 485, DateTimeKind.Local).AddTicks(2619), 2 },
                    { 1, "Initial check up", 2, new DateTime(2020, 2, 6, 16, 57, 47, 485, DateTimeKind.Local).AddTicks(1384), 1, new DateTime(2020, 2, 6, 16, 57, 47, 485, DateTimeKind.Local).AddTicks(1377), 1 },
                    { 2, "Initial check up", 2, new DateTime(2020, 2, 6, 16, 57, 47, 485, DateTimeKind.Local).AddTicks(2598), 2, new DateTime(2020, 2, 6, 16, 57, 47, 485, DateTimeKind.Local).AddTicks(2596), 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorPatients",
                keyColumns: new[] { "PatientId", "DoctorId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DoctorPatients",
                keyColumns: new[] { "PatientId", "DoctorId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DoctorPatients",
                keyColumns: new[] { "PatientId", "DoctorId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Studies",
                keyColumn: "StudyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Studies",
                keyColumn: "StudyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Studies",
                keyColumn: "StudyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3);
        }
    }
}
