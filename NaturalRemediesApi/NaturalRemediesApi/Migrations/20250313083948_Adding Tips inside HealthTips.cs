using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaturalRemediesApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingTipsinsideHealthTips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tips",
                table: "HealthTips",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tips",
                table: "HealthTips");
        }
    }
}
