using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WoWNewsApi.Migrations
{
    /// <inheritdoc />
    public partial class newOnModelUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Token", "Uid" },
                values: new object[,]
                {
                    { 1, "1.07.2023 14:34:08", "deneme@gmail.com", "weirjasdf1245pok", "pwoefasöçdfm2123" },
                    { 2, "1.07.2023 14:34:08", "deneme2@gmail.com", "sadfjwe", "sdkfasdf" }
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
