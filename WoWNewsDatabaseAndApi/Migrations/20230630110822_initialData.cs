using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WoWNewsApi.Migrations
{
    /// <inheritdoc />
    public partial class initialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Token", "Uid" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 30, 14, 8, 22, 343, DateTimeKind.Local).AddTicks(7466), "wownews@gmail.com", "123456", "6789" },
                    { 2, new DateTime(2023, 6, 30, 14, 8, 22, 343, DateTimeKind.Local).AddTicks(7477), "wownews2@gmail.com", "123123456", "6743589" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
