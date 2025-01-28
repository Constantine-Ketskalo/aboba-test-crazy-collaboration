using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueryableDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddedMyTaskProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MyTaskProperty",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyTaskProperty",
                table: "Buildings");
        }
    }
}
