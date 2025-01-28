using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueryableDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddedBuildingShowStopperProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShowStopper",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowStopper",
                table: "Buildings");
        }
    }
}
