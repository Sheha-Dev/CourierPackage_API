using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourierPackage_API.Migrations
{
    /// <inheritdoc />
    public partial class packageMasterTableRecipientIdDataTypeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageMaster_User_RecipientId",
                table: "PackageMaster");

            migrationBuilder.DropTable(
                name: "senderRecipient");

            migrationBuilder.AlterColumn<int>(
                name: "RecipientId",
                table: "PackageMaster",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageMaster_Recipient_RecipientId",
                table: "PackageMaster",
                column: "RecipientId",
                principalTable: "Recipient",
                principalColumn: "RecipientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageMaster_Recipient_RecipientId",
                table: "PackageMaster");

            migrationBuilder.AlterColumn<string>(
                name: "RecipientId",
                table: "PackageMaster",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "senderRecipient",
                columns: table => new
                {
                    RecipientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_senderRecipient", x => x.RecipientId);
                    table.ForeignKey(
                        name: "FK_senderRecipient_User_SenderId",
                        column: x => x.SenderId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_senderRecipient_SenderId",
                table: "senderRecipient",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageMaster_User_RecipientId",
                table: "PackageMaster",
                column: "RecipientId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
