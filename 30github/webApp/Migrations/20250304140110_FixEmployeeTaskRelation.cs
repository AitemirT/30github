using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApp.Migrations
{
    /// <inheritdoc />
    public partial class FixEmployeeTaskRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheTasks_Employees_ExecutorId",
                table: "TheTasks");

            migrationBuilder.AddForeignKey(
                name: "FK_TheTasks_Employees_ExecutorId",
                table: "TheTasks",
                column: "ExecutorId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheTasks_Employees_ExecutorId",
                table: "TheTasks");

            migrationBuilder.AddForeignKey(
                name: "FK_TheTasks_Employees_ExecutorId",
                table: "TheTasks",
                column: "ExecutorId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
