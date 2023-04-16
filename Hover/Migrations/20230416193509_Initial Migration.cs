using Hover.Models;
using Hover.Util;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hover.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            var user = new AppUser
            {
                Id = 1,
                Username = "iot_hover_win",
                Password = "@hover_12356"
            };

            user.Password =  SecurityProvider.HashPassword(user);

            migrationBuilder.InsertData("AppUsers", new[] { "Id", "Username", "Password" }, new object[] { user.Id, user.Username, user.Password });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
