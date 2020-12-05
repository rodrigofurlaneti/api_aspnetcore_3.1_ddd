using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _1Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
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
                    table.PrimaryKey("PK_Logs", x => x.CreateAt);
                });

            migrationBuilder.CreateTable(
                name: "user",
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
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "Authenticated", "CreateAt", "Email", "Expiration", "Message", "Name", "Token", "UpdateAt" },
                values: new object[] { new Guid("75aae6ff-fa34-4d55-af67-7c4abdd0e65f"), true, new DateTime(2020, 12, 5, 11, 3, 8, 700, DateTimeKind.Local).AddTicks(9464), "Administrator@system.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Administrator", null, new DateTime(2020, 12, 5, 11, 3, 8, 702, DateTimeKind.Local).AddTicks(2990) });

            migrationBuilder.CreateIndex(
                name: "IX_user_Email",
                table: "user",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
