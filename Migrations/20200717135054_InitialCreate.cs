using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Webkom.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Switches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IPAddress = table.Column<string>(nullable: false),
                    MACAddress = table.Column<string>(nullable: false),
                    VLanId = table.Column<int>(nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 20, nullable: false),
                    InventoryNumber = table.Column<string>(maxLength: 10, nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    ConnectDate = table.Column<DateTime>(nullable: false),
                    FloorNumber = table.Column<short>(nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Switches", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Switches");
        }
    }
}
