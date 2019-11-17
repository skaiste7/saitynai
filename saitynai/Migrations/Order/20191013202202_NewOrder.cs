using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace saitynai.Migrations.Order
{
    public partial class NewOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemFK",
                table: "Orders",
                newName: "ItemId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ItemId",
                table: "Orders",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Item_ItemId",
                table: "Orders",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Itid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Item_ItemId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ItemId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Orders",
                newName: "ItemFK");
        }
    }
}
