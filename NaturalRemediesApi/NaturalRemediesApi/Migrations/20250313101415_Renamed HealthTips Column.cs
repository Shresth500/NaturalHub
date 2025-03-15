using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaturalRemediesApi.Migrations
{
    /// <inheritdoc />
    public partial class RenamedHealthTipsColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tips",
                table: "HealthTips",
                newName: "TipName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HealthTips",
                newName: "TipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipName",
                table: "HealthTips",
                newName: "Tips");

            migrationBuilder.RenameColumn(
                name: "TipId",
                table: "HealthTips",
                newName: "Id");
        }
    }
}
