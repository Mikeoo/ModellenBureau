using Microsoft.EntityFrameworkCore.Migrations;

namespace ModellenBureau.Migrations
{
    public partial class uplooier3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_AppFiles_PhotoId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_PhotoId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Models");

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "AppFiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppFiles_ModelId",
                table: "AppFiles",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFiles_Models_ModelId",
                table: "AppFiles",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFiles_Models_ModelId",
                table: "AppFiles");

            migrationBuilder.DropIndex(
                name: "IX_AppFiles_ModelId",
                table: "AppFiles");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "AppFiles");

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Models",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_PhotoId",
                table: "Models",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_AppFiles_PhotoId",
                table: "Models",
                column: "PhotoId",
                principalTable: "AppFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
