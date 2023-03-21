using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class RemovedAirportIdColumnAndAddedPriceColumnToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Airports_AirportId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AirportId",
                table: "Orders");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AirportId",
                table: "Orders",
                column: "AirportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Airports_AirportId",
                table: "Orders",
                column: "AirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
