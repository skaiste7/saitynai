using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace saitynai.Migrations.Order
{
    public partial class NewThird : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Item_ItemFK",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ItemFK",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Itid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    Composition = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ItemType = table.Column<string>(type: "varchar(30)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    Size = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Itid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ItemFK",
                table: "Orders",
                column: "ItemFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Item_ItemFK",
                table: "Orders",
                column: "ItemFK",
                principalTable: "Item",
                principalColumn: "Itid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
