using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueryableDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddedBuildingTypeIdProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingTypeId",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingTypeId",
                table: "Buildings");
        }
    }
}
