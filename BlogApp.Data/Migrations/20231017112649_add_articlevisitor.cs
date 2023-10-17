using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_articlevisitor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitors",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVisitors", x => new { x.ArticleId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("415eb209-e5de-4cf7-b420-f4096488e006"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 14, 26, 49, 366, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("55c9f789-10cf-48c1-a121-a5f7a55352b9"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 26, 49, 366, DateTimeKind.Local).AddTicks(2189));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c950313-876b-4f94-8b8b-d5d6705087ba"),
                column: "ConcurrencyStamp",
                value: "56b87cd8-7e20-4763-9538-4c998910cad3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("89039672-13c6-4dcd-91c7-d274445b7957"),
                column: "ConcurrencyStamp",
                value: "2eac4219-d05b-4a9a-9328-75a76caaf4ff");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e91ab1a9-ed39-4b3d-8941-5a104e625b69"),
                column: "ConcurrencyStamp",
                value: "ce076296-6d2f-454f-b05a-e324aad6a0ab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44f8e767-19e2-4a7e-a60a-b32d583bdd9f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1383dab6-67b5-4dd3-9dcc-8a57552c0460", "AQAAAAEAACcQAAAAEGvAhqrCqzCbzhrrbPNIb3hDtFWPrd+yn3uO3p9SyJt/b5bmBXARO3Qb/THEFqaokg==", "bf5e2034-4d04-4aac-b791-ecb59d684a61" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df7ecd49-19a0-4e79-bb3a-edb17d382675"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "140001b4-058d-4f62-882b-447ee15ac8c1", "AQAAAAEAACcQAAAAENjkMlw0zOtoC7V/AYNCneAsXgqcnoByFpLs3ubssVM4DhamJTklvoUPfAQl8UXKHg==", "fabf8bce-3274-46ff-89e5-01e356549068" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e3e8c34a-3536-4f48-8e48-e14b33acacfe"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 26, 49, 366, DateTimeKind.Local).AddTicks(3620));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e85fe282-3469-4922-857f-6cea0d8bce78"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 14, 26, 49, 366, DateTimeKind.Local).AddTicks(3622));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a1fdf4c4-5681-44f5-8d06-982f3708bacf"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 26, 49, 366, DateTimeKind.Local).AddTicks(3723));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("fccb9c4f-e389-4adc-8d22-d7ac483020c4"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 14, 26, 49, 366, DateTimeKind.Local).AddTicks(3721));

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_VisitorId",
                table: "ArticleVisitors",
                column: "VisitorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitors");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("415eb209-e5de-4cf7-b420-f4096488e006"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 14, 12, 5, 202, DateTimeKind.Local).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("55c9f789-10cf-48c1-a121-a5f7a55352b9"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 11, 14, 12, 5, 202, DateTimeKind.Local).AddTicks(4578));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c950313-876b-4f94-8b8b-d5d6705087ba"),
                column: "ConcurrencyStamp",
                value: "a622bfe1-fca0-4f6a-b2b1-dc4be9fe81b8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("89039672-13c6-4dcd-91c7-d274445b7957"),
                column: "ConcurrencyStamp",
                value: "f631cc40-45c8-43a9-8300-f2573eae93d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e91ab1a9-ed39-4b3d-8941-5a104e625b69"),
                column: "ConcurrencyStamp",
                value: "2aa28dfa-d835-4fc9-a581-d9a8956d7376");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44f8e767-19e2-4a7e-a60a-b32d583bdd9f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c48b3f94-c2ff-4444-a6e2-f4051298ab6a", "AQAAAAEAACcQAAAAEEVY7SBh/NMdAaQ1A3Tg6IfEoWJmtCmA05OpEvnQqkjh7U6n89de4Vf9is81llqTAw==", "20574fcb-9f77-4649-9c22-4e61d069e127" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df7ecd49-19a0-4e79-bb3a-edb17d382675"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82ad071e-7295-478a-94e8-a08e2a55c9c2", "AQAAAAEAACcQAAAAEOvupYkQmIyAIwOIB+AM4DYVIOhvuwde0j9DwpG+/TwfPkrYFYFSFi0sKaJ/V7w7jg==", "1fc2dfed-9788-4205-bbc1-d81c8dd648a7" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e3e8c34a-3536-4f48-8e48-e14b33acacfe"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 11, 14, 12, 5, 202, DateTimeKind.Local).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e85fe282-3469-4922-857f-6cea0d8bce78"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 14, 12, 5, 202, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a1fdf4c4-5681-44f5-8d06-982f3708bacf"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 11, 14, 12, 5, 202, DateTimeKind.Local).AddTicks(4854));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("fccb9c4f-e389-4adc-8d22-d7ac483020c4"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 14, 12, 5, 202, DateTimeKind.Local).AddTicks(4851));
        }
    }
}
