using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaturalRemediesApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedDescriptionandBenefitcolumnfortheproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Benefits",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Benefits",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");
        }
    }
}
