using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Magazynex_New.Migrations
{
    /// <inheritdoc />
    public partial class Enum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mozliwosc_Pechowywania_Materialow",
                table: "magazyns");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Towars",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Pracowniks",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "magazyns",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Firmas",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Towars");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Pracowniks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "magazyns");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Firmas");

            migrationBuilder.AddColumn<string>(
                name: "Mozliwosc_Pechowywania_Materialow",
                table: "magazyns",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
