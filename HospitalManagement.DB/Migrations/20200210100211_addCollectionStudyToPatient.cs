using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagement.DB.Migrations
{
    public partial class addCollectionStudyToPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DoctorPatients",
                keyColumns: new[] { "PatientId", "DoctorId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedOn",
                value: new DateTime(2020, 2, 10, 15, 32, 10, 666, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "DoctorPatients",
                keyColumns: new[] { "PatientId", "DoctorId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedOn",
                value: new DateTime(2020, 2, 10, 15, 32, 10, 666, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "DoctorPatients",
                keyColumns: new[] { "PatientId", "DoctorId" },
                keyValues: new object[] { 3, 1 },
                column: "CreatedOn",
                value: new DateTime(2020, 2, 10, 15, 32, 10, 666, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 2, 10, 15, 32, 10, 666, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 2, 10, 15, 32, 10, 666, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 2, 10, 15, 32, 10, 666, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 2, 10, 15, 32, 10, 666, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 2, 10, 15, 32, 10, 666, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 2, 10, 15, 32, 10, 666, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 2, 10, 15, 32, 10, 666, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "Studies",
                keyColumn: "StudyId",
                keyValue: 1,
                columns: new[] { "EstimatedEndTime", "PlannedStartTime" },
                values: new object[] { new DateTime(2020, 2, 10, 15, 32, 10, 669, DateTimeKind.Local).AddTicks(6258), new DateTime(2020, 2, 10, 15, 32, 10, 669, DateTimeKind.Local).AddTicks(6254) });

            migrationBuilder.UpdateData(
                table: "Studies",
                keyColumn: "StudyId",
                keyValue: 2,
                columns: new[] { "EstimatedEndTime", "PlannedStartTime" },
                values: new object[] { new DateTime(2020, 2, 10, 15, 32, 10, 669, DateTimeKind.Local).AddTicks(7602), new DateTime(2020, 2, 10, 15, 32, 10, 669, DateTimeKind.Local).AddTicks(7599) });

            migrationBuilder.UpdateData(
                table: "Studies",
                keyColumn: "StudyId",
                keyValue: 3,
                columns: new[] { "EstimatedEndTime", "PlannedStartTime" },
                values: new object[] { new DateTime(2020, 2, 10, 15, 32, 10, 669, DateTimeKind.Local).AddTicks(7627), new DateTime(2020, 2, 10, 15, 32, 10, 669, DateTimeKind.Local).AddTicks(7626) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DoctorPatients",
                keyColumns: new[] { "PatientId", "DoctorId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedOn",
                value: new DateTime(2020, 2, 9, 13, 2, 6, 211, DateTimeKind.Local).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "DoctorPatients",
                keyColumns: new[] { "PatientId", "DoctorId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedOn",
                value: new DateTime(2020, 2, 9, 13, 2, 6, 211, DateTimeKind.Local).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "DoctorPatients",
                keyColumns: new[] { "PatientId", "DoctorId" },
                keyValues: new object[] { 3, 1 },
                column: "CreatedOn",
                value: new DateTime(2020, 2, 9, 13, 2, 6, 211, DateTimeKind.Local).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 2, 9, 13, 2, 6, 211, DateTimeKind.Local).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 2, 9, 13, 2, 6, 211, DateTimeKind.Local).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 2, 9, 13, 2, 6, 211, DateTimeKind.Local).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 2, 9, 13, 2, 6, 211, DateTimeKind.Local).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 2, 9, 13, 2, 6, 211, DateTimeKind.Local).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 2, 9, 13, 2, 6, 211, DateTimeKind.Local).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 2, 9, 13, 2, 6, 211, DateTimeKind.Local).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "Studies",
                keyColumn: "StudyId",
                keyValue: 1,
                columns: new[] { "EstimatedEndTime", "PlannedStartTime" },
                values: new object[] { new DateTime(2020, 2, 9, 13, 2, 6, 214, DateTimeKind.Local).AddTicks(3336), new DateTime(2020, 2, 9, 13, 2, 6, 214, DateTimeKind.Local).AddTicks(3331) });

            migrationBuilder.UpdateData(
                table: "Studies",
                keyColumn: "StudyId",
                keyValue: 2,
                columns: new[] { "EstimatedEndTime", "PlannedStartTime" },
                values: new object[] { new DateTime(2020, 2, 9, 13, 2, 6, 214, DateTimeKind.Local).AddTicks(4584), new DateTime(2020, 2, 9, 13, 2, 6, 214, DateTimeKind.Local).AddTicks(4582) });

            migrationBuilder.UpdateData(
                table: "Studies",
                keyColumn: "StudyId",
                keyValue: 3,
                columns: new[] { "EstimatedEndTime", "PlannedStartTime" },
                values: new object[] { new DateTime(2020, 2, 9, 13, 2, 6, 214, DateTimeKind.Local).AddTicks(4608), new DateTime(2020, 2, 9, 13, 2, 6, 214, DateTimeKind.Local).AddTicks(4607) });
        }
    }
}
