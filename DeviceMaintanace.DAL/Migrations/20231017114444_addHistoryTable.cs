using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeviceMaintanace.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addHistoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeadId = table.Column<int>(type: "int", nullable: false),
                    MaintananceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Histories_Deads_DeadId",
                        column: x => x.DeadId,
                        principalTable: "Deads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Histories_Maintanances_MaintananceId",
                        column: x => x.MaintananceId,
                        principalTable: "Maintanances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Histories_DeadId",
                table: "Histories",
                column: "DeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_MaintananceId",
                table: "Histories",
                column: "MaintananceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Histories");
        }
    }
}
