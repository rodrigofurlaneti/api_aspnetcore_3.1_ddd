using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    CreateAt = table.Column<DateTime>(nullable: false),
                    Authenticated = table.Column<bool>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    Expiration = table.Column<DateTime>(nullable: false),
                    Ipv6 = table.Column<string>(nullable: true),
                    Ipv4 = table.Column<string>(nullable: true),
                    Hostname = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.CreateAt);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Authenticated = table.Column<bool>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    Expiration = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Authenticated", "CreateAt", "Email", "Expiration", "Message", "Name", "Token", "UpdateAt" },
                values: new object[] { new Guid("80d20a92-adb9-4ffb-95e3-006558bdad67"), true, new DateTime(2020, 11, 22, 10, 50, 26, 156, DateTimeKind.Local).AddTicks(5776), "administrador@sis.com.br", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Administrador", null, new DateTime(2020, 11, 22, 10, 50, 26, 158, DateTimeKind.Local).AddTicks(4226) });

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
