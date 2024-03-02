using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetUci.Migrations
{
    public partial class UpdateDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diseases_Treatments_idTreatment",
                table: "Diseases");

            migrationBuilder.DropForeignKey(
                name: "FK_Forums_Users_userid",
                table: "Forums");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_rolID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Forums_userid",
                table: "Forums");

            migrationBuilder.DropIndex(
                name: "IX_Diseases_idTreatment",
                table: "Diseases");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Forums");

            migrationBuilder.RenameColumn(
                name: "rolID",
                table: "Users",
                newName: "rolId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_rolID",
                table: "Users",
                newName: "IX_Users_rolId");

            migrationBuilder.RenameColumn(
                name: "idTreatment",
                table: "Diseases",
                newName: "treatmentid");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_idDisease",
                table: "Treatments",
                column: "idDisease");

            migrationBuilder.CreateIndex(
                name: "IX_Forums_idUser",
                table: "Forums",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_treatmentid",
                table: "Diseases",
                column: "treatmentid");

            migrationBuilder.AddForeignKey(
                name: "FK_Diseases_Treatments_treatmentid",
                table: "Diseases",
                column: "treatmentid",
                principalTable: "Treatments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Forums_Users_idUser",
                table: "Forums",
                column: "idUser",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Diseases_idDisease",
                table: "Treatments",
                column: "idDisease",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_rolId",
                table: "Users",
                column: "rolId",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diseases_Treatments_treatmentid",
                table: "Diseases");

            migrationBuilder.DropForeignKey(
                name: "FK_Forums_Users_idUser",
                table: "Forums");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Diseases_idDisease",
                table: "Treatments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_rolId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_idDisease",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Forums_idUser",
                table: "Forums");

            migrationBuilder.DropIndex(
                name: "IX_Diseases_treatmentid",
                table: "Diseases");

            migrationBuilder.RenameColumn(
                name: "rolId",
                table: "Users",
                newName: "rolID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_rolId",
                table: "Users",
                newName: "IX_Users_rolID");

            migrationBuilder.RenameColumn(
                name: "treatmentid",
                table: "Diseases",
                newName: "idTreatment");

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "Forums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Forums_userid",
                table: "Forums",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_idTreatment",
                table: "Diseases",
                column: "idTreatment",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Diseases_Treatments_idTreatment",
                table: "Diseases",
                column: "idTreatment",
                principalTable: "Treatments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Forums_Users_userid",
                table: "Forums",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_rolID",
                table: "Users",
                column: "rolID",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
