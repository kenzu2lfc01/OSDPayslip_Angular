using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OSDPayslip.Data.Migrations
{
    public partial class update141826082019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    DeptTeam = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    StartDay = table.Column<DateTime>(nullable: false),
                    OfficialDay = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "RequestDetail",
                columns: table => new
                {
                    RequestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<int>(nullable: false),
                    NoOfDeployee = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDetail", x => x.RequestID);
                });

            migrationBuilder.CreateTable(
                name: "PayslipDetails",
                columns: table => new
                {
                    PayslipID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<string>(nullable: true),
                    StandardWorkingDay = table.Column<int>(nullable: false),
                    ActualWorkingDay = table.Column<int>(nullable: false),
                    UnpaidLeave = table.Column<int>(nullable: false),
                    LeaveBalance = table.Column<int>(nullable: false),
                    Holidays = table.Column<int>(nullable: false),
                    BasicSalary = table.Column<double>(nullable: true),
                    GrossSalary = table.Column<double>(nullable: true),
                    ActuaSalary = table.Column<double>(nullable: true),
                    Allowance = table.Column<double>(nullable: true),
                    Bonus = table.Column<double>(nullable: true),
                    Salary13Th = table.Column<double>(nullable: true),
                    IncomeOther = table.Column<double>(nullable: true),
                    OtherDeductions = table.Column<double>(nullable: true),
                    Insurance = table.Column<double>(nullable: true),
                    SocialInsurance = table.Column<double>(nullable: true),
                    HealthInsurance = table.Column<double>(nullable: true),
                    UnemploymentInsurance = table.Column<double>(nullable: true),
                    NoOfDependants = table.Column<int>(nullable: true),
                    PersonalIncomeTax = table.Column<double>(nullable: true),
                    PaymentFromSocialInsurance = table.Column<double>(nullable: true),
                    FinalizationOfPIT = table.Column<double>(nullable: true),
                    PaymentOther = table.Column<double>(nullable: true),
                    NetIncome = table.Column<double>(nullable: true),
                    EmployeeID = table.Column<string>(nullable: true),
                    RequestID = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayslipDetails", x => x.PayslipID);
                    table.ForeignKey(
                        name: "FK_PayslipDetails_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayslipDetails_RequestDetail_RequestID",
                        column: x => x.RequestID,
                        principalTable: "RequestDetail",
                        principalColumn: "RequestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayslipDetails_EmployeeID",
                table: "PayslipDetails",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_PayslipDetails_RequestID",
                table: "PayslipDetails",
                column: "RequestID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayslipDetails");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "RequestDetail");
        }
    }
}
