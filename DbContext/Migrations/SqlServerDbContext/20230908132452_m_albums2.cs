using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbContext.Migrations.SqlServerDbContext
{
    /// <inheritdoc />
    public partial class m_albums2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MusicGroupId",
                table: "Albums",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_MusicGroupId",
                table: "Albums",
                column: "MusicGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_MusicGroups_MusicGroupId",
                table: "Albums",
                column: "MusicGroupId",
                principalTable: "MusicGroups",
                principalColumn: "MusicGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_MusicGroups_MusicGroupId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_MusicGroupId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "MusicGroupId",
                table: "Albums");
        }
    }
}
