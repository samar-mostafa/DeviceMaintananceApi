using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeviceMaintanace.DAL.Migrations
{
    /// <inheritdoc />
    public partial class editEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_BrancheDepartments_BrancheDepartmentId1_BrancheDepartmentId2",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "BrancheDepartmentId2",
                table: "Employees",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "BrancheDepartmentId1",
                table: "Employees",
                newName: "BrancheId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_BrancheDepartmentId1_BrancheDepartmentId2",
                table: "Employees",
                newName: "IX_Employees_BrancheId_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_BrancheDepartments_BrancheId_DepartmentId",
                table: "Employees",
                columns: new[] { "BrancheId", "DepartmentId" },
                principalTable: "BrancheDepartments",
                principalColumns: new[] { "BranchId", "DepartmentId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_BrancheDepartments_BrancheId_DepartmentId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Employees",
                newName: "BrancheDepartmentId2");

            migrationBuilder.RenameColumn(
                name: "BrancheId",
                table: "Employees",
                newName: "BrancheDepartmentId1");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_BrancheId_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_BrancheDepartmentId1_BrancheDepartmentId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_BrancheDepartments_BrancheDepartmentId1_BrancheDepartmentId2",
                table: "Employees",
                columns: new[] { "BrancheDepartmentId1", "BrancheDepartmentId2" },
                principalTable: "BrancheDepartments",
                principalColumns: new[] { "BranchId", "DepartmentId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
