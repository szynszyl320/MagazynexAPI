using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Magazynex_New.Migrations
{
    /// <inheritdoc />
    public partial class EnumFunctionalityV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Klasa_Towarow_Niebezpiecznych",
                table: "Towars");

            migrationBuilder.AddColumn<string>(
                name: "Klasa_Towaru",
                table: "Towars",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Klasa_Towaru",
                table: "Towars");

            migrationBuilder.AddColumn<string>(
                name: "Klasa_Towarow_Niebezpiecznych",
                table: "Towars",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
