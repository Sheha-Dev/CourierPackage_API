using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourierPackage_API.Migrations
{
    /// <inheritdoc />
    public partial class addRecipientLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipientLocation",
                columns: table => new
                {
                    RecipientLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipientId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipientLocation", x => x.RecipientLocationId);
                    table.ForeignKey(
                        name: "FK_RecipientLocation_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "DistrictId");
                    table.ForeignKey(
                        name: "FK_RecipientLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_RecipientLocation_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "ProvinceId");
                    table.ForeignKey(
                        name: "FK_RecipientLocation_Recipient_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Recipient",
                        principalColumn: "RecipientId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipientLocation_DistrictId",
                table: "RecipientLocation",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipientLocation_LocationId",
                table: "RecipientLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipientLocation_ProvinceId",
                table: "RecipientLocation",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipientLocation_RecipientId",
                table: "RecipientLocation",
                column: "RecipientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipientLocation");
        }
    }
}
