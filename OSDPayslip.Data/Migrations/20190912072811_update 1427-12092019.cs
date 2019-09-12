using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OSDPayslip.Data.Migrations
{
    public partial class update142712092019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyBy",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Employees",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ModifyBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Employees");
        }
    }
}
