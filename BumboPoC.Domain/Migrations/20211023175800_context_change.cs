using Microsoft.EntityFrameworkCore.Migrations;

namespace BumboPoC.Domain.Migrations
{
    public partial class context_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeBlock_Employees_EmployeeId",
                table: "TimeBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeBlock_TimeSchedule_TimeScheduleId",
                table: "TimeBlock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeBlock",
                table: "TimeBlock");

            migrationBuilder.RenameTable(
                name: "TimeBlock",
                newName: "TimeBlocks");

            migrationBuilder.RenameIndex(
                name: "IX_TimeBlock_TimeScheduleId",
                table: "TimeBlocks",
                newName: "IX_TimeBlocks_TimeScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_TimeBlock_EmployeeId",
                table: "TimeBlocks",
                newName: "IX_TimeBlocks_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeBlocks",
                table: "TimeBlocks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeBlocks_Employees_EmployeeId",
                table: "TimeBlocks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeBlocks_TimeSchedule_TimeScheduleId",
                table: "TimeBlocks",
                column: "TimeScheduleId",
                principalTable: "TimeSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeBlocks_Employees_EmployeeId",
                table: "TimeBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeBlocks_TimeSchedule_TimeScheduleId",
                table: "TimeBlocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeBlocks",
                table: "TimeBlocks");

            migrationBuilder.RenameTable(
                name: "TimeBlocks",
                newName: "TimeBlock");

            migrationBuilder.RenameIndex(
                name: "IX_TimeBlocks_TimeScheduleId",
                table: "TimeBlock",
                newName: "IX_TimeBlock_TimeScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_TimeBlocks_EmployeeId",
                table: "TimeBlock",
                newName: "IX_TimeBlock_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeBlock",
                table: "TimeBlock",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeBlock_Employees_EmployeeId",
                table: "TimeBlock",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeBlock_TimeSchedule_TimeScheduleId",
                table: "TimeBlock",
                column: "TimeScheduleId",
                principalTable: "TimeSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
