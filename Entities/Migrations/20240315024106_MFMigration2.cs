using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class MFMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentDate_DoctorId",
                table: "Appointments",
                columns: new[] { "AppointmentDate", "DoctorId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentDate_PatientId",
                table: "Appointments",
                columns: new[] { "AppointmentDate", "PatientId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Appointments_AppointmentDate_DoctorId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_AppointmentDate_PatientId",
                table: "Appointments");
        }
    }
}
