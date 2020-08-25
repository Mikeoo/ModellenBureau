using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModellenBureau.Migrations
{
    public partial class uplooier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "AppFile");

            migrationBuilder.AddColumn<string>(
                name: "UploadedContentString",
                table: "AppFile",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadedContentString",
                table: "AppFile");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "AppFile",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
