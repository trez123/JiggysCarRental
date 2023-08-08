using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JiggysCarRental.Migrations
{
    /// <inheritdoc />
    public partial class CarRental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    RentCost = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GPSNavigation = table.Column<bool>(type: "bit", nullable: false),
                    InfantAndChildSeats = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    RentCost = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NumberOfPassengers = table.Column<int>(type: "int", nullable: false),
                    NumberOLargeBags = table.Column<int>(type: "int", nullable: false),
                    UsbAdapter = table.Column<bool>(type: "bit", nullable: false),
                    ReverseCamera = table.Column<bool>(type: "bit", nullable: false),
                    PushStart = table.Column<bool>(type: "bit", nullable: false),
                    Bluetooth = table.Column<bool>(type: "bit", nullable: false),
                    ToolsControl = table.Column<bool>(type: "bit", nullable: false),
                    SteeringControl = table.Column<bool>(type: "bit", nullable: false),
                    ThermalControl = table.Column<bool>(type: "bit", nullable: false),
                    HeatedSeat = table.Column<bool>(type: "bit", nullable: false),
                    AutomaticTransmission = table.Column<bool>(type: "bit", nullable: false),
                    FourWheelDrive = table.Column<bool>(type: "bit", nullable: false),
                    LeatherSeats = table.Column<bool>(type: "bit", nullable: false),
                    Aux = table.Column<bool>(type: "bit", nullable: false),
                    StartDateAvailable = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateAvailable = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
