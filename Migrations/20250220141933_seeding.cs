using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideoGameApi.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VideoGames",
                columns: new[] { "Id", "Developer", "Platform", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Nintendo", "Nintendo Switch", 2017, "The Legend of Zelda: Breath of the Wild" },
                    { 2, "Nintendo", "Nintendo Switch", 2017, "Super Mario Odyssey" },
                    { 3, "CD Projekt Red", "PlayStation 4", 2015, "The Witcher 3: Wild Hunt" },
                    { 4, "Rockstar Games", "PlayStation 4", 2018, "Red Dead Redemption 2" },
                    { 5, "Naughty Dog", "PlayStation 4", 2020, "The Last of Us Part II" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
