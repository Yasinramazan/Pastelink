using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Pastes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomURL",
                table: "Pastes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireTime",
                table: "Pastes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Pastes_AppUserId",
                table: "Pastes",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pastes_AspNetUsers_AppUserId",
                table: "Pastes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pastes_AspNetUsers_AppUserId",
                table: "Pastes");

            migrationBuilder.DropIndex(
                name: "IX_Pastes_AppUserId",
                table: "Pastes");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Pastes");

            migrationBuilder.DropColumn(
                name: "CustomURL",
                table: "Pastes");

            migrationBuilder.DropColumn(
                name: "ExpireTime",
                table: "Pastes");
        }
    }
}
