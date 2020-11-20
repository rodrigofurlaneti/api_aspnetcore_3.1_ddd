using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _2_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hostname",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ipv4",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ipv6",
                table: "Log",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hostname",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Ipv4",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Ipv6",
                table: "Log");
        }
    }
}
