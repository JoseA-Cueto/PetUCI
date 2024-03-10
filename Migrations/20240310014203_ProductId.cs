using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetUci.Migrations
{
    public partial class ProductId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPet",
                table: "Vaccines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Vaccines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_PetId",
                table: "Vaccines",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccines_Pets_PetId",
                table: "Vaccines",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccines_Pets_PetId",
                table: "Vaccines");

            migrationBuilder.DropIndex(
                name: "IX_Vaccines_PetId",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "IdPet",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Vaccines");
        }
    }
}
