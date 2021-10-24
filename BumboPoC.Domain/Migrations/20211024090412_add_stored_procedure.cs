using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BumboPoC.Domain.Migrations
{
    public partial class add_stored_procedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkedShifts",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeIban = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeDateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EmployeeNfcCardId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeBlockId = table.Column<int>(type: "int", nullable: false),
                    TimeBlockEmployeeId = table.Column<int>(type: "int", nullable: false),
                    TimeBlockTimeScheduleId = table.Column<int>(type: "int", nullable: false),
                    TimeBlockStartTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TimeBlockEndTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TimeEntryId = table.Column<int>(type: "int", nullable: false),
                    TimeEntryEmployeeId = table.Column<int>(type: "int", nullable: false),
                    TimeEntryStartDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TimeEntryEndDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TimeApproveStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.UpdateData(
                table: "TimeBlocks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 10, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 10, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkedShifts");

            migrationBuilder.UpdateData(
                table: "TimeBlocks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 10, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 10, 19, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) });
        }
    }
}
