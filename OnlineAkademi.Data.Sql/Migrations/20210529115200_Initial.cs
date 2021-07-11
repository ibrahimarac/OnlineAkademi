using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineAkademi.Data.Sql.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(30)", nullable: false),
                    CreateUser = table.Column<string>(type: "varchar(10)", nullable: false),
                    LastupUser = table.Column<string>(type: "varchar(10)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    LastupDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "CreateUser", "LastupDate", "LastupUser", "CategoryName" },
                values: new object[] { 1, new DateTime(2021, 5, 29, 14, 51, 59, 476, DateTimeKind.Local).AddTicks(4223), "admin", new DateTime(2021, 5, 29, 14, 51, 59, 477, DateTimeKind.Local).AddTicks(6750), "admin", "Kategori 1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "CreateUser", "LastupDate", "LastupUser", "CategoryName" },
                values: new object[] { 2, new DateTime(2021, 5, 29, 14, 51, 59, 477, DateTimeKind.Local).AddTicks(7658), "admin", new DateTime(2021, 5, 29, 14, 51, 59, 477, DateTimeKind.Local).AddTicks(7665), "admin", "Kategori 2" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "CreateUser", "LastupDate", "LastupUser", "CategoryName" },
                values: new object[] { 3, new DateTime(2021, 5, 29, 14, 51, 59, 477, DateTimeKind.Local).AddTicks(7669), "admin", new DateTime(2021, 5, 29, 14, 51, 59, 477, DateTimeKind.Local).AddTicks(7670), "admin", "Kategori 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
