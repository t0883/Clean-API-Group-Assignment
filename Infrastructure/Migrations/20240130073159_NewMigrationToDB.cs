using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    EngineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EngineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineFuel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorsePower = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.EngineId);
                    table.ForeignKey(
                        name: "FK_Engines_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GearBoxes",
                columns: table => new
                {
                    GearboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GearboxModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SixGears = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearBoxes", x => x.GearboxId);
                    table.ForeignKey(
                        name: "FK_GearBoxes_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tires",
                columns: table => new
                {
                    TireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TireModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TireSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TireTreadDepth = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tires", x => x.TireId);
                    table.ForeignKey(
                        name: "FK_Tires_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_BrandName",
                table: "Brands",
                column: "BrandName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Engines_BrandId",
                table: "Engines",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GearBoxes_BrandId",
                table: "GearBoxes",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Tires_BrandId",
                table: "Tires",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "GearBoxes");

            migrationBuilder.DropTable(
                name: "Tires");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
