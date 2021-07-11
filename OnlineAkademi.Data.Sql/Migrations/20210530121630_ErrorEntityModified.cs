using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineAkademi.Data.Sql.Migrations
{
    public partial class ErrorEntityModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastupDate" },
                values: new object[] { new DateTime(2021, 5, 30, 15, 16, 30, 89, DateTimeKind.Local).AddTicks(8231), new DateTime(2021, 5, 30, 15, 16, 30, 90, DateTimeKind.Local).AddTicks(8499) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastupDate" },
                values: new object[] { new DateTime(2021, 5, 30, 15, 16, 30, 90, DateTimeKind.Local).AddTicks(9109), new DateTime(2021, 5, 30, 15, 16, 30, 90, DateTimeKind.Local).AddTicks(9114) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastupDate" },
                values: new object[] { new DateTime(2021, 5, 30, 15, 16, 30, 90, DateTimeKind.Local).AddTicks(9117), new DateTime(2021, 5, 30, 15, 16, 30, 90, DateTimeKind.Local).AddTicks(9118) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastupDate" },
                values: new object[] { new DateTime(2021, 5, 30, 15, 14, 0, 591, DateTimeKind.Local).AddTicks(6492), new DateTime(2021, 5, 30, 15, 14, 0, 592, DateTimeKind.Local).AddTicks(6759) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastupDate" },
                values: new object[] { new DateTime(2021, 5, 30, 15, 14, 0, 592, DateTimeKind.Local).AddTicks(7379), new DateTime(2021, 5, 30, 15, 14, 0, 592, DateTimeKind.Local).AddTicks(7384) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastupDate" },
                values: new object[] { new DateTime(2021, 5, 30, 15, 14, 0, 592, DateTimeKind.Local).AddTicks(7387), new DateTime(2021, 5, 30, 15, 14, 0, 592, DateTimeKind.Local).AddTicks(7388) });
        }
    }
}
