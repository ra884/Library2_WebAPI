using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library2_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BorrowedDate",
                table: "Borrowings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "BorrowingId",
                keyValue: 1,
                column: "BorrowedDate",
                value: new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "BorrowingId",
                keyValue: 2,
                column: "BorrowedDate",
                value: new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "BorrowedDate",
                table: "Borrowings",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "BorrowingId",
                keyValue: 1,
                column: "BorrowedDate",
                value: new DateOnly(2023, 1, 15));

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "BorrowingId",
                keyValue: 2,
                column: "BorrowedDate",
                value: new DateOnly(2023, 3, 10));
        }
    }
}
