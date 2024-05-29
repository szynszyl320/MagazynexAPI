using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Magazynex_New.Migrations
{
    /// <inheritdoc />
    public partial class AgeNatAproximation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AproxAge",
                table: "Pracowniks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AproxNat",
                table: "Pracowniks",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AproxAge",
                table: "Pracowniks");

            migrationBuilder.DropColumn(
                name: "AproxNat",
                table: "Pracowniks");
        }
    }
}
