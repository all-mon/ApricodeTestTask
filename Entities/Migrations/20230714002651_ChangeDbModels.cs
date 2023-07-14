using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDbModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Games_GamesGameId",
                table: "GameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Genres_GenresGenreId",
                table: "GameGenre");

            migrationBuilder.RenameColumn(
                name: "GenresGenreId",
                table: "GameGenre",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "GamesGameId",
                table: "GameGenre",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GameGenre_GenresGenreId",
                table: "GameGenre",
                newName: "IX_GameGenre_GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Games_GameId",
                table: "GameGenre",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Genres_GenreId",
                table: "GameGenre",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Games_GameId",
                table: "GameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Genres_GenreId",
                table: "GameGenre");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "GameGenre",
                newName: "GenresGenreId");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "GameGenre",
                newName: "GamesGameId");

            migrationBuilder.RenameIndex(
                name: "IX_GameGenre_GenreId",
                table: "GameGenre",
                newName: "IX_GameGenre_GenresGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Games_GamesGameId",
                table: "GameGenre",
                column: "GamesGameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Genres_GenresGenreId",
                table: "GameGenre",
                column: "GenresGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
