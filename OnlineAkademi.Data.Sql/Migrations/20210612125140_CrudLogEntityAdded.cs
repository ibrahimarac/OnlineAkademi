using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineAkademi.Data.Sql.Migrations
{
    public partial class CrudLogEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrudLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(10)", nullable: false),
                    EntityName = table.Column<string>(type: "varchar(30)", nullable: false),
                    Old = table.Column<string>(type: "varchar(max)", nullable: true),
                    New = table.Column<string>(type: "varchar(max)", nullable: true),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrudLogs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastupDate" },
                values: new object[] { new DateTime(2021, 6, 12, 15, 51, 40, 227, DateTimeKind.Local).AddTicks(1654), new DateTime(2021, 6, 12, 15, 51, 40, 228, DateTimeKind.Local).AddTicks(2599) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastupDate" },
                values: new object[] { new DateTime(2021, 6, 12, 15, 51, 40, 228, DateTimeKind.Local).AddTicks(3327), new DateTime(2021, 6, 12, 15, 51, 40, 228, DateTimeKind.Local).AddTicks(3332) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastupDate" },
                values: new object[] { new DateTime(2021, 6, 12, 15, 51, 40, 228, DateTimeKind.Local).AddTicks(3335), new DateTime(2021, 6, 12, 15, 51, 40, 228, DateTimeKind.Local).AddTicks(3336) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrudLogs");

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
    }
}
