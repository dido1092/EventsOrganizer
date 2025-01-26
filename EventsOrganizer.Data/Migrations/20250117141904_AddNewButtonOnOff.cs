using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsOrganizer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewButtonOnOff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "buttonOnOffState",
                table: "Events");

            migrationBuilder.CreateTable(
                name: "ButtonOnOffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ButtonOnOffs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ButtonOnOffs");

            migrationBuilder.AddColumn<bool>(
                name: "buttonOnOffState",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
