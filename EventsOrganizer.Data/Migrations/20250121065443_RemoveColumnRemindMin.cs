using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsOrganizer.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColumnRemindMin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "remindMin",
                table: "Events");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "remindMin",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
