using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthDocument.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Documents");
        }
    }
}
