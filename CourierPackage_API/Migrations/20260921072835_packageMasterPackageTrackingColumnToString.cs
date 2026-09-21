using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourierPackage_API.Migrations
{
    /// <inheritdoc />
    public partial class packageMasterPackageTrackingColumnToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PackageTrackingId",
                table: "PackageMaster",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PackageTrackingId",
                table: "PackageMaster",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
