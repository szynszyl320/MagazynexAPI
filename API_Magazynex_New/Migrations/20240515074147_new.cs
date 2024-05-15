using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Magazynex_New.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Towars_magazyns_MagazynId",
                table: "Towars");

            migrationBuilder.AlterColumn<int>(
                name: "MagazynId",
                table: "Towars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Firmas",
                keyColumn: "Numer_Telefonu",
                keyValue: null,
                column: "Numer_Telefonu",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Numer_Telefonu",
                table: "Firmas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Firmas",
                keyColumn: "Nazwa",
                keyValue: null,
                column: "Nazwa",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Firmas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Towars_magazyns_MagazynId",
                table: "Towars",
                column: "MagazynId",
                principalTable: "magazyns",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Towars_magazyns_MagazynId",
                table: "Towars");

            migrationBuilder.AlterColumn<int>(
                name: "MagazynId",
                table: "Towars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Numer_Telefonu",
                table: "Firmas",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Firmas",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Towars_magazyns_MagazynId",
                table: "Towars",
                column: "MagazynId",
                principalTable: "magazyns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
