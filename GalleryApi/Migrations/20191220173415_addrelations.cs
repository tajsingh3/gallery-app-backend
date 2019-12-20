using Microsoft.EntityFrameworkCore.Migrations;

namespace GalleryApi.Migrations
{
    public partial class addrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_AspNetUsers_ApplicationUserId",
                table: "Artworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_AspNetUsers_ApplicationUserId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Artworks_ArtworkId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_ApplicationUserId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Artworks_ApplicationUserId",
                table: "Artworks");

            migrationBuilder.DeleteData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Artworks");

            migrationBuilder.AlterColumn<int>(
                name: "ArtworkId",
                table: "Votes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Votes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Artworks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserId",
                table: "Votes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_UserId",
                table: "Artworks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_AspNetUsers_UserId",
                table: "Artworks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Artworks_ArtworkId",
                table: "Votes",
                column: "ArtworkId",
                principalTable: "Artworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_AspNetUsers_UserId",
                table: "Votes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_AspNetUsers_UserId",
                table: "Artworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Artworks_ArtworkId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_AspNetUsers_UserId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_UserId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Artworks_UserId",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Artworks");

            migrationBuilder.AlterColumn<int>(
                name: "ArtworkId",
                table: "Votes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Votes",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Artworks",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "4814c0ee-00e9-442a-be72-276ccc9f0e89", null, false, false, null, null, null, null, null, false, "373f074e-f7d1-43e8-a274-68108104cc7c", false, "Taj" });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "Id", "ApplicationUserId", "Description", "ImageUrl", "Name" },
                values: new object[] { 1, "1", "dick", null, "dick" });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ApplicationUserId",
                table: "Votes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_ApplicationUserId",
                table: "Artworks",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_AspNetUsers_ApplicationUserId",
                table: "Artworks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_AspNetUsers_ApplicationUserId",
                table: "Votes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Artworks_ArtworkId",
                table: "Votes",
                column: "ArtworkId",
                principalTable: "Artworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
