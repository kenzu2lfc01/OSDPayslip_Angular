using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OSDPayslip.Data.Migrations
{
    public partial class update140527082019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfficialDay",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "NoOfDeployee",
                table: "RequestDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "NoOfDeployee",
                table: "RequestDetail",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OfficialDay",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
