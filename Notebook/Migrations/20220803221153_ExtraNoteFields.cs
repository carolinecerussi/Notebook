using Microsoft.EntityFrameworkCore.Migrations;

namespace Notebook.Migrations
{
    public partial class ExtraNoteFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NoteContent",
                table: "Notes",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoteDate",
                table: "Notes",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteContent",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "NoteDate",
                table: "Notes");
        }
    }
}
