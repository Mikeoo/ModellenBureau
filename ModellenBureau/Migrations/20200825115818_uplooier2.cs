using Microsoft.EntityFrameworkCore.Migrations;

namespace ModellenBureau.Migrations
{
    public partial class uplooier2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AppFile_LogoId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_AppFile_PhotoId",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppFile",
                table: "AppFile");

            migrationBuilder.RenameTable(
                name: "AppFile",
                newName: "AppFiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppFiles",
                table: "AppFiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AppFiles_LogoId",
                table: "Customers",
                column: "LogoId",
                principalTable: "AppFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_AppFiles_PhotoId",
                table: "Models",
                column: "PhotoId",
                principalTable: "AppFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AppFiles_LogoId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_AppFiles_PhotoId",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppFiles",
                table: "AppFiles");

            migrationBuilder.RenameTable(
                name: "AppFiles",
                newName: "AppFile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppFile",
                table: "AppFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AppFile_LogoId",
                table: "Customers",
                column: "LogoId",
                principalTable: "AppFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_AppFile_PhotoId",
                table: "Models",
                column: "PhotoId",
                principalTable: "AppFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
