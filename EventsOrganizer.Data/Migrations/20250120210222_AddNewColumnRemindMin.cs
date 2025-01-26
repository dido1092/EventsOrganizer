using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsOrganizer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnRemindMin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "remindMin",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "remindMin",
                table: "Events");
        }
    }
}
