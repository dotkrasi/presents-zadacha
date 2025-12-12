using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presents.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiftID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gifts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Decription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsTaken = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Gifts_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_GiftID",
                table: "Categories",
                column: "GiftID");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_CategoryID",
                table: "Gifts",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Gifts_GiftID",
                table: "Categories",
                column: "GiftID",
                principalTable: "Gifts",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Gifts_GiftID",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Gifts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
