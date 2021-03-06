using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BumboPoC.Domain.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NfcCards",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NfcCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekNumber = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iban = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    NfcCardId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_NfcCards_NfcCardId",
                        column: x => x.NfcCardId,
                        principalTable: "NfcCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeBlock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TimeScheduleId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeBlock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeBlock_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeBlock_TimeSchedule_TimeScheduleId",
                        column: x => x.TimeScheduleId,
                        principalTable: "TimeSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StartDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ApproveStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeEntries_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "NfcCards",
                column: "Id",
                value: "933762014625");

            migrationBuilder.InsertData(
                table: "NfcCards",
                column: "Id",
                value: "1047276881072");

            migrationBuilder.InsertData(
                table: "TimeSchedule",
                columns: new[] { "Id", "WeekNumber", "Year" },
                values: new object[] { 1, 42, 2021 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "Iban", "LastName", "MiddleName", "NfcCardId", "PhoneNumber" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2000, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "t.coldenhoff@student.avans.nl", "Tom", null, "Coldenhoff", null, "933762014625", "+0612345678" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "Iban", "LastName", "MiddleName", "NfcCardId", "PhoneNumber" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(1987, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "j.doe@student.avans.nl", "John", null, "Doe", null, "1047276881072", "+0612345678" });

            migrationBuilder.InsertData(
                table: "TimeBlock",
                columns: new[] { "Id", "EmployeeId", "EndTime", "StartTime", "TimeScheduleId" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2021, 10, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 10, 18, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 1 },
                    { 2, 1, new DateTimeOffset(new DateTime(2021, 10, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 10, 19, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 1 },
                    { 3, 1, new DateTimeOffset(new DateTime(2021, 10, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 10, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 1 },
                    { 4, 2, new DateTimeOffset(new DateTime(2021, 10, 18, 17, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 10, 18, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 1 },
                    { 5, 2, new DateTimeOffset(new DateTime(2021, 10, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 10, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 1 },
                    { 6, 2, new DateTimeOffset(new DateTime(2021, 10, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 10, 19, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "TimeEntries",
                columns: new[] { "Id", "ApproveStatus", "EmployeeId", "EndDateTime", "StartDateTime" },
                values: new object[,]
                {
                    { 1, 0, 1, new DateTimeOffset(new DateTime(2021, 10, 18, 21, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 10, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 2, 0, 1, new DateTimeOffset(new DateTime(2021, 10, 19, 12, 2, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 10, 19, 6, 56, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 3, 0, 2, new DateTimeOffset(new DateTime(2021, 10, 21, 21, 15, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 10, 21, 18, 1, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 4, 0, 2, new DateTimeOffset(new DateTime(2021, 10, 18, 17, 45, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 10, 18, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 5, 0, 2, new DateTimeOffset(new DateTime(2021, 10, 19, 21, 8, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 10, 19, 11, 45, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 6, 0, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 10, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NfcCardId",
                table: "Employees",
                column: "NfcCardId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeBlock_EmployeeId",
                table: "TimeBlock",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeBlock_TimeScheduleId",
                table: "TimeBlock",
                column: "TimeScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntries_EmployeeId",
                table: "TimeEntries",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeBlock");

            migrationBuilder.DropTable(
                name: "TimeEntries");

            migrationBuilder.DropTable(
                name: "TimeSchedule");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "NfcCards");
        }
    }
}
