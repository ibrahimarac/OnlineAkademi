using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineAkademi.Data.Sql.Migrations
{
    public partial class ErrorRequestTypeChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Errors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(10)", nullable: true),
                    Url = table.Column<string>(type: "varchar(300)", nullable: true),
                    QueryString = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "200"),
                    StatusCode = table.Column<int>(type: "int", nullable: false),
                    Exception = table.Column<string>(type: "varchar(max)", nullable: false),
                    RequestType = table.Column<int>(type: "int", nullable: false),
                    IsAjaxRequest = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errors", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastupDate" },
                values: new object[] { new DateTime(2021, 5, 30, 14, 19, 31, 467, DateTimeKind.Local).AddTicks(5907), new DateTime(2021, 5, 30, 14, 19, 31, 468, DateTimeKind.Local).AddTicks(5660) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastupDate" },
                values: new object[] { new DateTime(2021, 5, 30, 14, 19, 31, 468, DateTimeKind.Local).AddTicks(6287), new DateTime(2021, 5, 30, 14, 19, 31, 468, DateTimeKind.Local).AddTicks(6293) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastupDate" },
                values: new object[] { new DateTime(2021, 5, 30, 14, 19, 31, 468, DateTimeKind.Local).AddTicks(6295), new DateTime(2021, 5, 30, 14, 19, 31, 468, DateTimeKind.Local).AddTicks(6297) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Errors");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastupDate" },
                values: new object[] { new DateTime(2021, 5, 29, 14, 51, 59, 476, DateTimeKind.Local).AddTicks(4223), new DateTime(2021, 5, 29, 14, 51, 59, 477, DateTimeKind.Local).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastupDate" },
                values: new object[] { new DateTime(2021, 5, 29, 14, 51, 59, 477, DateTimeKind.Local).AddTicks(7658), new DateTime(2021, 5, 29, 14, 51, 59, 477, DateTimeKind.Local).AddTicks(7665) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastupDate" },
                values: new object[] { new DateTime(2021, 5, 29, 14, 51, 59, 477, DateTimeKind.Local).AddTicks(7669), new DateTime(2021, 5, 29, 14, 51, 59, 477, DateTimeKind.Local).AddTicks(7670) });
        }
    }
}
