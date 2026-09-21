using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourierPackage_API.Migrations
{
    /// <inheritdoc />
    public partial class packageDestinationRelationshipChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageMaster_Warehouse_DestinationId",
                table: "PackageMaster");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageMaster_Location_DestinationId",
                table: "PackageMaster",
                column: "DestinationId",
                principalTable: "Location",
                principalColumn: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageMaster_Location_DestinationId",
                table: "PackageMaster");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageMaster_Warehouse_DestinationId",
                table: "PackageMaster",
                column: "DestinationId",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId");
        }
    }
}
