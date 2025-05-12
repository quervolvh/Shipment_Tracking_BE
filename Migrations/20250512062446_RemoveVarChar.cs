using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shipment_track.Migrations
{
    /// <inheritdoc />
    public partial class RemoveVarChar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Shipments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "varchar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Shipments",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
