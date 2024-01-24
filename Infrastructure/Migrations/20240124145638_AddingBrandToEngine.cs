using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingBrandToEngine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BrandId",
                table: "Engines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Engines_BrandId",
                table: "Engines",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Engines_Brands_BrandId",
                table: "Engines",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engines_Brands_BrandId",
                table: "Engines");

            migrationBuilder.DropIndex(
                name: "IX_Engines_BrandId",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Engines");
        }
    }
}
