using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _1_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FederalUnit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Initials = table.Column<string>(maxLength: 2, nullable: false),
                    Name = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FederalUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "County",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    CodeIbge = table.Column<int>(nullable: false),
                    FederalUnitId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_County", x => x.Id);
                    table.ForeignKey(
                        name: "FK_County_FederalUnit_FederalUnitId",
                        column: x => x.FederalUnitId,
                        principalTable: "FederalUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZipCode",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: false),
                    PublicPlace = table.Column<string>(maxLength: 60, nullable: false),
                    Number = table.Column<string>(maxLength: 10, nullable: true),
                    CountyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZipCode_County_CountyId",
                        column: x => x.CountyId,
                        principalTable: "County",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FederalUnit",
                columns: new[] { "Id", "CreateAt", "Initials", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9192), "AC", "Acre", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9232) },
                    { new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9770), "SP", "São Paulo", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9773) },
                    { new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9761), "SE", "Sergipe", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9764) },
                    { new Guid("b81f95e0-f226-4afd-9763-290001637ed4"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9751), "SC", "Santa Catarina", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9754) },
                    { new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9741), "RS", "Rio Grande do Sul", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9744) },
                    { new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9731), "RR", "Roraima", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9734) },
                    { new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9723), "RO", "Rondônia", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9725) },
                    { new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9713), "RN", "Rio Grande do Norte", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9716) },
                    { new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9705), "RJ", "Rio de Janeiro", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9707) },
                    { new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9694), "PR", "Paraná", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9698) },
                    { new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9685), "PI", "Piauí", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9688) },
                    { new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9676), "PE", "Pernambuco", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9679) },
                    { new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9667), "PB", "Paraíba", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9669) },
                    { new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9659), "PA", "Pará", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9661) },
                    { new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9649), "MT", "Mato Grosso", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9652) },
                    { new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9638), "MS", "Mato Grosso do Sul", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9641) },
                    { new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9629), "MG", "Minas Gerais", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9631) },
                    { new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9619), "MA", "Maranhão", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9623) },
                    { new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9608), "GO", "Goiás", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9610) },
                    { new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9595), "ES", "Espírito Santo", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9597) },
                    { new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9586), "DF", "Distrito Federal", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9588) },
                    { new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9578), "CE", "Ceará", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9580) },
                    { new Guid("5abca453-d035-4766-a81b-9f73d683a54b"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9467), "BA", "Bahia", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9470) },
                    { new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9458), "AP", "Amapá", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9462) },
                    { new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9446), "AM", "Amazonas", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9449) },
                    { new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9429), "AL", "Alagoas", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9435) },
                    { new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"), new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9779), "TO", "Tocantins", new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9782) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("22bfc0cc-bb63-47ad-9675-ab9f5eeab9da"), new DateTime(2020, 12, 8, 11, 33, 44, 668, DateTimeKind.Local).AddTicks(2232), "Administrator@system.com", "Administrator", new DateTime(2020, 12, 8, 11, 33, 44, 669, DateTimeKind.Local).AddTicks(5016) });

            migrationBuilder.CreateIndex(
                name: "IX_County_CodeIbge",
                table: "County",
                column: "CodeIbge");

            migrationBuilder.CreateIndex(
                name: "IX_County_FederalUnitId",
                table: "County",
                column: "FederalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_FederalUnit_Initials",
                table: "FederalUnit",
                column: "Initials",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZipCode_CountyId",
                table: "ZipCode",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_ZipCode_ZipCode",
                table: "ZipCode",
                column: "ZipCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ZipCode");

            migrationBuilder.DropTable(
                name: "County");

            migrationBuilder.DropTable(
                name: "FederalUnit");
        }
    }
}
