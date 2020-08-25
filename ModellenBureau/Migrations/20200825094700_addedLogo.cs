using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModellenBureau.Migrations
{
    public partial class addedLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogoId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFile", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_PhotoId",
                table: "Models",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LogoId",
                table: "Customers",
                column: "LogoId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AppFile_LogoId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_AppFile_PhotoId",
                table: "Models");

            migrationBuilder.DropTable(
                name: "AppFile");

            migrationBuilder.DropIndex(
                name: "IX_Models_PhotoId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LogoId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "LogoId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
