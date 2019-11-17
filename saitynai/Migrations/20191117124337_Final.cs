using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace saitynai.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
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
                    table.PrimaryKey("PK_Items", x => x.Itid);
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
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    DispatchDate = table.Column<DateTime>(nullable: false),
                    ReceivedDate = table.Column<DateTime>(nullable: false),
                    TrackingNr = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
