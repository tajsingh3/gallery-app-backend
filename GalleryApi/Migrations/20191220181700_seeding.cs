using Microsoft.EntityFrameworkCore.Migrations;

namespace GalleryApi.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "9ca4711a-e35e-4f07-b8bd-331952dde47e", null, false, false, null, null, null, null, null, false, "a5decdc8-335d-4b79-b03e-2dd764190a63", false, "Taj" });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "Id", "ApplicationUserId", "Description", "ImageUrl", "Name" },
                values: new object[] { 1, "1", "My superman portrait", null, "Superman" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
