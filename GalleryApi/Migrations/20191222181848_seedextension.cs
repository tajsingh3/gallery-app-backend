using Microsoft.EntityFrameworkCore.Migrations;

namespace GalleryApi.Migrations
{
    public partial class seedextension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8b6c6e68-f2f9-4a74-9b6f-c1baeb057ef2", "82635833-d67b-4ebf-8bfa-ec50b3872a47" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "538bdb90-df04-4120-8375-9994cc6d753d", "555e2f31-320f-4f52-80a8-59d2af605e9f" });
        }
    }
}
