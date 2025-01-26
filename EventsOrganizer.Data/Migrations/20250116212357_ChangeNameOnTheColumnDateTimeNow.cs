using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsOrganizer.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameOnTheColumnDateTimeNow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RemindDateTime",
                table: "Events",
                newName: "remindDateTime");

            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "Events",
                newName: "dateTimeNow");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "remindDateTime",
                table: "Events",
                newName: "RemindDateTime");

            migrationBuilder.RenameColumn(
                name: "dateTimeNow",
                table: "Events",
                newName: "dateTime");
        }
    }
}
