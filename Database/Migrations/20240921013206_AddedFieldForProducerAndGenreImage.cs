using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedFieldForProducerAndGenreImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProducerImage",
                table: "Producers",
                type: "int",
                maxLength: 255,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenreImage",
                table: "Genres",
                type: "int",
                maxLength: 255,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProducerImage",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "GenreImage",
                table: "Genres");
        }
    }
}
