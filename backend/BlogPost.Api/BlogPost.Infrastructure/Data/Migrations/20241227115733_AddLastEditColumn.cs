using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogPost.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLastEditColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastEdit",
                table: "Blogs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastEdit",
                table: "Blogs");
        }
    }
}
