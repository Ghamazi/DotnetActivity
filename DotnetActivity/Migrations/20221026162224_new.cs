using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetActivity.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "ITem1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d38888e9-2ba9-473a-a40f-e38cb54f9b35"), "ITem2" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d48888e9-2ba9-473a-a40f-e38cb54f9b35"), "ITem3" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "ImgUrl", "Name", "Quantity", "price" },
                values: new object[,]
                {
                    { new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "IMg1.png", "arcade", 2, 10f },
                    { new Guid("2ee50fe3-edf2-4f91-8409-3eb25ce6ca51"), new Guid("d38888e9-2ba9-473a-a40f-e38cb54f9b35"), "IMg1.png", "arcade", 2, 10f },
                    { new Guid("2ee51fe3-edf2-4f91-8409-3eb25ce6ca51"), new Guid("d48888e9-2ba9-473a-a40f-e38cb54f9b35"), "IMg1.png", "arcade", 2, 10f },
                    { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "IMg21.png", "color", 12, 120f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
