using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Data.Migrations
{
    public partial class PrescriptionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Patients_PatientId",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_PatientId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Medicines");

            migrationBuilder.AddColumn<Guid>(
                name: "PrescriptionId",
                table: "Medicines",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatePrescription = table.Column<DateTime>(type: "date", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_PrescriptionId",
                table: "Medicines",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Prescriptions_PrescriptionId",
                table: "Medicines",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Prescriptions_PrescriptionId",
                table: "Medicines");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_PrescriptionId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "PrescriptionId",
                table: "Medicines");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Patients",
                type: "varchar(1000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                table: "Medicines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_PatientId",
                table: "Medicines",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Patients_PatientId",
                table: "Medicines",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
