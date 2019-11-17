using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace saitynai.Migrations.Order
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Itid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Size = table.Column<string>(type: "varchar(20)", nullable: false),
                    ItemType = table.Column<string>(type: "varchar(30)", nullable: false),
                    Composition = table.Column<string>(type: "varchar(50)", nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Rating = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Itid);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    State = table.Column<string>(type: "varchar(20)", nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: true),
                    DispatchDate = table.Column<DateTime>(nullable: true),
                    ReceivedDate = table.Column<DateTime>(nullable: true),
                    TrackingNr = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ItemFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Item_ItemFK",
                        column: x => x.ItemFK,
                        principalTable: "Item",
                        principalColumn: "Itid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ItemFK",
                table: "Orders",
                column: "ItemFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
