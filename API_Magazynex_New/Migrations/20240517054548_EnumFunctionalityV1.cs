using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Magazynex_New.Migrations
{
    /// <inheritdoc />
    public partial class EnumFunctionalityV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Przechowywane_Materialy",
                table: "Magazyns",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Przechowywane_Materialy",
                table: "Magazyns");
        }
    }
}
