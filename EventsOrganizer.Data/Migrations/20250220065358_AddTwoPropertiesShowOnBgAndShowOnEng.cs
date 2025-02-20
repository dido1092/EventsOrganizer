using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsOrganizer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTwoPropertiesShowOnBgAndShowOnEng : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "minutes",
                table: "RepeatWords",
                newName: "Minutes");

            migrationBuilder.AddColumn<bool>(
                name: "ShowOnBg",
                table: "RepeatWords",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowOnEng",
                table: "RepeatWords",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowOnBg",
                table: "RepeatWords");

            migrationBuilder.DropColumn(
                name: "ShowOnEng",
                table: "RepeatWords");

            migrationBuilder.RenameColumn(
                name: "Minutes",
                table: "RepeatWords",
                newName: "minutes");
        }
    }
}
