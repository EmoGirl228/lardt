using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmoBase.Migrations
{
    /// <inheritdoc />
    public partial class Vladosik229 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Product = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Basket__B40CC6CD8AFFEB2C", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "int", nullable: false),
                    categoryname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__category__23CDE5908FEBBC0A", x => x.categoryid);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userid = table.Column<int>(type: "int", nullable: false),
                    login1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    role1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__CBA1B2572BA314F5", x => x.userid);
                    table.ForeignKey(
                        name: "FK_users_Basket",
                        column: x => x.userid,
                        principalTable: "Basket",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "int", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__products__111C97436F226216", x => new { x.categoryid, x.productid });
                    table.ForeignKey(
                        name: "FK_products_Basket",
                        column: x => x.productid,
                        principalTable: "Basket",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_products_category",
                        column: x => x.categoryid,
                        principalTable: "category",
                        principalColumn: "categoryid");
                });

            migrationBuilder.CreateTable(
                name: "BuyHistory",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false),
                    buyid = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BuyHisto__00E17E3B8614CD83", x => new { x.userid, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BuyHistory_Basket",
                        column: x => x.ProductId,
                        principalTable: "Basket",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_BuyHistory_users",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    userid = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__reviews__CBA1B2571CAA06B3", x => x.userid);
                    table.ForeignKey(
                        name: "FK_reviews_users",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyHistory_ProductId",
                table: "BuyHistory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_products_productid",
                table: "products",
                column: "productid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyHistory");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Basket");
        }
    }
}
