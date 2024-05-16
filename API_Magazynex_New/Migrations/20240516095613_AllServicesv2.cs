using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Magazynex_New.Migrations
{
    /// <inheritdoc />
    public partial class AllServicesv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pracowniks_magazyns_MagazynId",
                table: "Pracowniks");

            migrationBuilder.DropForeignKey(
                name: "FK_Towars_magazyns_MagazynId",
                table: "Towars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_magazyns",
                table: "magazyns");

            migrationBuilder.RenameTable(
                name: "magazyns",
                newName: "Magazyns");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Magazyns",
                table: "Magazyns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pracowniks_Magazyns_MagazynId",
                table: "Pracowniks",
                column: "MagazynId",
                principalTable: "Magazyns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Towars_Magazyns_MagazynId",
                table: "Towars",
                column: "MagazynId",
                principalTable: "Magazyns",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pracowniks_Magazyns_MagazynId",
                table: "Pracowniks");

            migrationBuilder.DropForeignKey(
                name: "FK_Towars_Magazyns_MagazynId",
                table: "Towars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Magazyns",
                table: "Magazyns");

            migrationBuilder.RenameTable(
                name: "Magazyns",
                newName: "magazyns");

            migrationBuilder.AddPrimaryKey(
                name: "PK_magazyns",
                table: "magazyns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pracowniks_magazyns_MagazynId",
                table: "Pracowniks",
                column: "MagazynId",
                principalTable: "magazyns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Towars_magazyns_MagazynId",
                table: "Towars",
                column: "MagazynId",
                principalTable: "magazyns",
                principalColumn: "Id");
        }
    }
}
