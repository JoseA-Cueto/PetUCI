using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetUci.Migrations
{
    public partial class UpdateDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageFiles_Products_ProductId",
                table: "ImageFiles");

            migrationBuilder.DropIndex(
                name: "IX_ImageFiles_ProductId",
                table: "ImageFiles");

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "ImageFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ImageFiles_PetId",
                table: "ImageFiles",
                column: "PetId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageFiles_Pets_PetId",
                table: "ImageFiles",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageFiles_Products_PetId",
                table: "ImageFiles",
                column: "PetId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageFiles_Pets_PetId",
                table: "ImageFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageFiles_Products_PetId",
                table: "ImageFiles");

            migrationBuilder.DropIndex(
                name: "IX_ImageFiles_PetId",
                table: "ImageFiles");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "ImageFiles");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFiles_ProductId",
                table: "ImageFiles",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageFiles_Products_ProductId",
                table: "ImageFiles",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
