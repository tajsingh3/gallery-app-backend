using Microsoft.EntityFrameworkCore.Migrations;

namespace GalleryApi.Migrations
{
    public partial class addforeignkeyreqs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Votes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Artworks",
                nullable: false,
                defaultValue: "");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_AspNetUsers_ApplicationUserId",
                table: "Votes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Artworks_ArtworkId",
                table: "Votes",
                column: "ArtworkId",
                principalTable: "Artworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Artworks");

            migrationBuilder.AlterColumn<int>(
                name: "ArtworkId",
                table: "Votes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Votes",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Artworks",
                type: "varchar(255) CHARACTER SET utf8mb4",
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
    }
}
