using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class AddNewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NewsPrecis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NewsBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewsImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
