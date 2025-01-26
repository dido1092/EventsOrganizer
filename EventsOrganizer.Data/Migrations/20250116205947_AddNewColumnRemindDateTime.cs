using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsOrganizer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnRemindDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Events",
                newName: "eventName");

            migrationBuilder.RenameColumn(
                name: "Enable",
                table: "Events",
                newName: "enable");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Events",
                newName: "dateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "RemindDateTime",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemindDateTime",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "eventName",
                table: "Events",
                newName: "EventName");

            migrationBuilder.RenameColumn(
                name: "enable",
                table: "Events",
                newName: "Enable");

            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "Events",
                newName: "DateTime");
        }
    }
}
