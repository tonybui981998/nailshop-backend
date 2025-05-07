using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingConfirm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoucherUsages_Bookings_BookingId",
                table: "VoucherUsages");

            migrationBuilder.DropIndex(
                name: "IX_VoucherUsages_BookingId",
                table: "VoucherUsages");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "VoucherUsages",
                newName: "BookingConfirmId");

            migrationBuilder.CreateTable(
                name: "BookingConfirms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    VoucherCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoucherAmount = table.Column<int>(type: "int", nullable: false),
                    TotalPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingConfirms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingConfirms_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfirmServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    selectedService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    BookingConfirmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfirmServices_BookingConfirms_BookingConfirmId",
                        column: x => x.BookingConfirmId,
                        principalTable: "BookingConfirms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoucherUsages_BookingConfirmId",
                table: "VoucherUsages",
                column: "BookingConfirmId",
                unique: true,
                filter: "[BookingConfirmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookingConfirms_BookingId",
                table: "BookingConfirms",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmServices_BookingConfirmId",
                table: "ConfirmServices",
                column: "BookingConfirmId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherUsages_BookingConfirms_BookingConfirmId",
                table: "VoucherUsages",
                column: "BookingConfirmId",
                principalTable: "BookingConfirms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoucherUsages_BookingConfirms_BookingConfirmId",
                table: "VoucherUsages");

            migrationBuilder.DropTable(
                name: "ConfirmServices");

            migrationBuilder.DropTable(
                name: "BookingConfirms");

            migrationBuilder.DropIndex(
                name: "IX_VoucherUsages_BookingConfirmId",
                table: "VoucherUsages");

            migrationBuilder.RenameColumn(
                name: "BookingConfirmId",
                table: "VoucherUsages",
                newName: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherUsages_BookingId",
                table: "VoucherUsages",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherUsages_Bookings_BookingId",
                table: "VoucherUsages",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }
    }
}
