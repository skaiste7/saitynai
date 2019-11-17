using Microsoft.EntityFrameworkCore.Migrations;

namespace saitynai.Migrations.Order
{
    public partial class Order5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Orders");
        }
    }
}
