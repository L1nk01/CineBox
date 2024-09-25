using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedBetterNamesForGenreProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoLink",
                table: "Series",
                newName: "SeriesVideoLink");

            migrationBuilder.RenameColumn(
                name: "CoverImage",
                table: "Series",
                newName: "SeriesImage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeriesVideoLink",
                table: "Series",
                newName: "VideoLink");

            migrationBuilder.RenameColumn(
                name: "SeriesImage",
                table: "Series",
                newName: "CoverImage");
        }
    }
}
