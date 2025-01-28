using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueryableDatabase.Migrations
{
    /// <inheritdoc />
    public partial class testforgit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Architect",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Architect",
                table: "Buildings");
        }
    }
}
