using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GFeonixBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMarkdown : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Markdown",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Markdown",
                table: "Posts");
        }
    }
}
