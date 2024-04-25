using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class EditNewsmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "News");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "News");
        }
    }
}
