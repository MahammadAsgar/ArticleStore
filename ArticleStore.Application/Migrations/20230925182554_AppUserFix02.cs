using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleStore.Application.Migrations
{
    /// <inheritdoc />
    public partial class AppUserFix02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PictureSources_PictureSourceId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "PictureSourceId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PictureSources_PictureSourceId",
                table: "AspNetUsers",
                column: "PictureSourceId",
                principalTable: "PictureSources",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PictureSources_PictureSourceId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "PictureSourceId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PictureSources_PictureSourceId",
                table: "AspNetUsers",
                column: "PictureSourceId",
                principalTable: "PictureSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
