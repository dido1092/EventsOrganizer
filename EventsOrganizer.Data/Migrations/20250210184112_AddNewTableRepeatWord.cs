﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsOrganizer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTableRepeatWord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepeatWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BgWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    minutes = table.Column<int>(type: "int", nullable: false),
                    Repeat = table.Column<bool>(type: "bit", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepeatWords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepeatWords");
        }
    }
}
