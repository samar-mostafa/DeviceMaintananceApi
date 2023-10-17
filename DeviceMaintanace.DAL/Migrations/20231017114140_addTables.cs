using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeviceMaintanace.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnteryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProblemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackToDevices = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeMobilePhone = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ItEmployeeMobilePhone = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceDetails_Employees_EmployeeMobilePhone",
                        column: x => x.EmployeeMobilePhone,
                        principalTable: "Employees",
                        principalColumn: "MobilePhone");
                    table.ForeignKey(
                        name: "FK_DeviceDetails_Employees_ItEmployeeMobilePhone",
                        column: x => x.ItEmployeeMobilePhone,
                        principalTable: "Employees",
                        principalColumn: "MobilePhone");
                });

            migrationBuilder.CreateTable(
                name: "Deads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mobilePhone = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ITLEADER = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FIRSTMEMBER = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SECONDMEMBER = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deads_DeviceDetails_DeviceDetailId",
                        column: x => x.DeviceDetailId,
                        principalTable: "DeviceDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deads_Employees_FIRSTMEMBER",
                        column: x => x.FIRSTMEMBER,
                        principalTable: "Employees",
                        principalColumn: "MobilePhone");
                    table.ForeignKey(
                        name: "FK_Deads_Employees_ITLEADER",
                        column: x => x.ITLEADER,
                        principalTable: "Employees",
                        principalColumn: "MobilePhone");
                    table.ForeignKey(
                        name: "FK_Deads_Employees_SECONDMEMBER",
                        column: x => x.SECONDMEMBER,
                        principalTable: "Employees",
                        principalColumn: "MobilePhone");
                    table.ForeignKey(
                        name: "FK_Deads_Employees_mobilePhone",
                        column: x => x.mobilePhone,
                        principalTable: "Employees",
                        principalColumn: "MobilePhone");
                });

            migrationBuilder.CreateTable(
                name: "Maintanances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceDetailId = table.Column<int>(type: "int", nullable: false),
                    CompanyDelivaryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeDelivaryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SolutionDescribtion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliverToEmployeeStatus = table.Column<bool>(type: "bit", nullable: false),
                    warrantyCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    checkReturnedFromExternalCompany = table.Column<bool>(type: "bit", nullable: false),
                    checkGoToDead = table.Column<bool>(type: "bit", nullable: false),
                    maintanceDoneInsideOffice = table.Column<bool>(type: "bit", nullable: false),
                    DeviceDeliveredCompletelyToCompany = table.Column<bool>(type: "bit", nullable: false),
                    WhatWasDeliveredToCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceStatusId = table.Column<int>(type: "int", nullable: false),
                    ItEmployeeFromCompany = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeMobileNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ItEmployeeToCompany = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ItEmployeeMaintainer = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ItEmployeeToEmployee = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintanances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintanances_DeviceDetails_DeviceDetailId",
                        column: x => x.DeviceDetailId,
                        principalTable: "DeviceDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maintanances_DeviceStatuses_DeviceStatusId",
                        column: x => x.DeviceStatusId,
                        principalTable: "DeviceStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maintanances_Employees_EmployeeMobileNumber",
                        column: x => x.EmployeeMobileNumber,
                        principalTable: "Employees",
                        principalColumn: "MobilePhone");
                    table.ForeignKey(
                        name: "FK_Maintanances_Employees_ItEmployeeFromCompany",
                        column: x => x.ItEmployeeFromCompany,
                        principalTable: "Employees",
                        principalColumn: "MobilePhone");
                    table.ForeignKey(
                        name: "FK_Maintanances_Employees_ItEmployeeMaintainer",
                        column: x => x.ItEmployeeMaintainer,
                        principalTable: "Employees",
                        principalColumn: "MobilePhone");
                    table.ForeignKey(
                        name: "FK_Maintanances_Employees_ItEmployeeToCompany",
                        column: x => x.ItEmployeeToCompany,
                        principalTable: "Employees",
                        principalColumn: "MobilePhone");
                    table.ForeignKey(
                        name: "FK_Maintanances_Employees_ItEmployeeToEmployee",
                        column: x => x.ItEmployeeToEmployee,
                        principalTable: "Employees",
                        principalColumn: "MobilePhone");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deads_DeviceDetailId",
                table: "Deads",
                column: "DeviceDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Deads_FIRSTMEMBER",
                table: "Deads",
                column: "FIRSTMEMBER");

            migrationBuilder.CreateIndex(
                name: "IX_Deads_ITLEADER",
                table: "Deads",
                column: "ITLEADER");

            migrationBuilder.CreateIndex(
                name: "IX_Deads_mobilePhone",
                table: "Deads",
                column: "mobilePhone");

            migrationBuilder.CreateIndex(
                name: "IX_Deads_SECONDMEMBER",
                table: "Deads",
                column: "SECONDMEMBER");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDetails_EmployeeMobilePhone",
                table: "DeviceDetails",
                column: "EmployeeMobilePhone");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDetails_ItEmployeeMobilePhone",
                table: "DeviceDetails",
                column: "ItEmployeeMobilePhone");

            migrationBuilder.CreateIndex(
                name: "IX_Maintanances_DeviceDetailId",
                table: "Maintanances",
                column: "DeviceDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintanances_DeviceStatusId",
                table: "Maintanances",
                column: "DeviceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintanances_EmployeeMobileNumber",
                table: "Maintanances",
                column: "EmployeeMobileNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Maintanances_ItEmployeeFromCompany",
                table: "Maintanances",
                column: "ItEmployeeFromCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Maintanances_ItEmployeeMaintainer",
                table: "Maintanances",
                column: "ItEmployeeMaintainer");

            migrationBuilder.CreateIndex(
                name: "IX_Maintanances_ItEmployeeToCompany",
                table: "Maintanances",
                column: "ItEmployeeToCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Maintanances_ItEmployeeToEmployee",
                table: "Maintanances",
                column: "ItEmployeeToEmployee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deads");

            migrationBuilder.DropTable(
                name: "Maintanances");

            migrationBuilder.DropTable(
                name: "DeviceDetails");
        }
    }
}
