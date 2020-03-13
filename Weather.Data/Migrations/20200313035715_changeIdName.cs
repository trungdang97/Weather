using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Data.Migrations
{
    public partial class changeIdName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CMS_Comments_CMS_News_CMS_NewsId",
                table: "CMS_Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_CMS_Comments_CMS_Posts_CMS_PostId",
                table: "CMS_Comments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CMS_Posts",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CMS_PostCategories",
                newName: "PostCategoryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CMS_NewsCategories",
                newName: "NewsCategoryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CMS_News",
                newName: "NewsId");

            migrationBuilder.RenameColumn(
                name: "CMS_PostId",
                table: "CMS_Comments",
                newName: "CMS_PostPostId");

            migrationBuilder.RenameColumn(
                name: "CMS_NewsId",
                table: "CMS_Comments",
                newName: "CMS_NewsNewsId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CMS_Comments",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_CMS_Comments_CMS_PostId",
                table: "CMS_Comments",
                newName: "IX_CMS_Comments_CMS_PostPostId");

            migrationBuilder.RenameIndex(
                name: "IX_CMS_Comments_CMS_NewsId",
                table: "CMS_Comments",
                newName: "IX_CMS_Comments_CMS_NewsNewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_Comments_CMS_News_CMS_NewsNewsId",
                table: "CMS_Comments",
                column: "CMS_NewsNewsId",
                principalTable: "CMS_News",
                principalColumn: "NewsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_Comments_CMS_Posts_CMS_PostPostId",
                table: "CMS_Comments",
                column: "CMS_PostPostId",
                principalTable: "CMS_Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CMS_Comments_CMS_News_CMS_NewsNewsId",
                table: "CMS_Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_CMS_Comments_CMS_Posts_CMS_PostPostId",
                table: "CMS_Comments");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "CMS_Posts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PostCategoryId",
                table: "CMS_PostCategories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NewsCategoryId",
                table: "CMS_NewsCategories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NewsId",
                table: "CMS_News",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CMS_PostPostId",
                table: "CMS_Comments",
                newName: "CMS_PostId");

            migrationBuilder.RenameColumn(
                name: "CMS_NewsNewsId",
                table: "CMS_Comments",
                newName: "CMS_NewsId");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "CMS_Comments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CMS_Comments_CMS_PostPostId",
                table: "CMS_Comments",
                newName: "IX_CMS_Comments_CMS_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_CMS_Comments_CMS_NewsNewsId",
                table: "CMS_Comments",
                newName: "IX_CMS_Comments_CMS_NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_Comments_CMS_News_CMS_NewsId",
                table: "CMS_Comments",
                column: "CMS_NewsId",
                principalTable: "CMS_News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_Comments_CMS_Posts_CMS_PostId",
                table: "CMS_Comments",
                column: "CMS_PostId",
                principalTable: "CMS_Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
