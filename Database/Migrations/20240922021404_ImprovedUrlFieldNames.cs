using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class ImprovedUrlFieldNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeriesVideoLink",
                table: "Series",
                newName: "VideoLink");

            migrationBuilder.RenameColumn(
                name: "SeriesImage",
                table: "Series",
                newName: "ImageLink");

            migrationBuilder.RenameColumn(
                name: "ProducerImage",
                table: "Producers",
                newName: "ImageLink");

            migrationBuilder.RenameColumn(
                name: "GenreImage",
                table: "Genres",
                newName: "ImageLink");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoLink",
                table: "Series",
                newName: "SeriesVideoLink");

            migrationBuilder.RenameColumn(
                name: "ImageLink",
                table: "Series",
                newName: "SeriesImage");

            migrationBuilder.RenameColumn(
                name: "ImageLink",
                table: "Producers",
                newName: "ProducerImage");

            migrationBuilder.RenameColumn(
                name: "ImageLink",
                table: "Genres",
                newName: "GenreImage");
        }
    }
}
