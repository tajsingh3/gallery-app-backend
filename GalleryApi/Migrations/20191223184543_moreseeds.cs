using Microsoft.EntityFrameworkCore.Migrations;

namespace GalleryApi.Migrations
{
    public partial class moreseeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a94505dc-0421-4756-9f86-3350faf0d7e1", "d4a4c945-6e9b-4cd6-96ca-9c3713ac4d0b" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "f22046a2-eb4d-4063-80ab-6fc4c17a0fc4", null, false, false, null, null, null, null, null, false, "1ffe017f-4b35-464f-92e3-8eee69387c3b", false, "Rani" });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "Id", "ApplicationUserId", "Description", "ImageUrl", "Name" },
                values: new object[] { 2, "2", "My monkey portrait", null, "monkey" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8b6c6e68-f2f9-4a74-9b6f-c1baeb057ef2", "82635833-d67b-4ebf-8bfa-ec50b3872a47" });
        }
    }
}
