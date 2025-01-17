﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Somativa_2.Migrations
{
    /// <inheritdoc />
    public partial class pacimg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img",
                table: "Pacientes");
        }
    }
}
