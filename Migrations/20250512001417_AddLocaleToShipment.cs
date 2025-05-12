using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shipment_track.Migrations
{
    /// <inheritdoc />
    public partial class AddLocaleToShipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Shipments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Eta",
                table: "Shipments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Shipments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ShipDate",
                table: "Shipments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "Eta",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "ShipDate",
                table: "Shipments");
        }
    }
}
