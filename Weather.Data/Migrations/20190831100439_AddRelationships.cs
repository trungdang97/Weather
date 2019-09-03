using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Data.Migrations
{
    public partial class AddRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedByUserId",
                table: "CMS_News",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CMS_NewsId",
                table: "CMS_Comments",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CMS_PostId",
                table: "CMS_Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CMS_Posts_CreatedByUserId",
                table: "CMS_Posts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CMS_Posts_PostCategoryId",
                table: "CMS_Posts",
                column: "PostCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CMS_News_CreatedByUserId",
                table: "CMS_News",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CMS_Comments_CMS_NewsId",
                table: "CMS_Comments",
                column: "CMS_NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_CMS_Comments_CMS_PostId",
                table: "CMS_Comments",
                column: "CMS_PostId");

            migrationBuilder.CreateIndex(
                name: "IX_CMS_Comments_CreatedByUserId",
                table: "CMS_Comments",
                column: "CreatedByUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_Comments_AspnetMemberships_CreatedByUserId",
                table: "CMS_Comments",
                column: "CreatedByUserId",
                principalTable: "AspnetMemberships",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_News_AspnetMemberships_CreatedByUserId",
                table: "CMS_News",
                column: "CreatedByUserId",
                principalTable: "AspnetMemberships",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_Posts_AspnetMemberships_CreatedByUserId",
                table: "CMS_Posts",
                column: "CreatedByUserId",
                principalTable: "AspnetMemberships",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_Posts_CMS_PostCategories_PostCategoryId",
                table: "CMS_Posts",
                column: "PostCategoryId",
                principalTable: "CMS_PostCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CMS_Comments_CMS_News_CMS_NewsId",
                table: "CMS_Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_CMS_Comments_CMS_Posts_CMS_PostId",
                table: "CMS_Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_CMS_Comments_AspnetMemberships_CreatedByUserId",
                table: "CMS_Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_CMS_News_AspnetMemberships_CreatedByUserId",
                table: "CMS_News");

            migrationBuilder.DropForeignKey(
                name: "FK_CMS_Posts_AspnetMemberships_CreatedByUserId",
                table: "CMS_Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_CMS_Posts_CMS_PostCategories_PostCategoryId",
                table: "CMS_Posts");

            migrationBuilder.DropIndex(
                name: "IX_CMS_Posts_CreatedByUserId",
                table: "CMS_Posts");

            migrationBuilder.DropIndex(
                name: "IX_CMS_Posts_PostCategoryId",
                table: "CMS_Posts");

            migrationBuilder.DropIndex(
                name: "IX_CMS_News_CreatedByUserId",
                table: "CMS_News");

            migrationBuilder.DropIndex(
                name: "IX_CMS_Comments_CMS_NewsId",
                table: "CMS_Comments");

            migrationBuilder.DropIndex(
                name: "IX_CMS_Comments_CMS_PostId",
                table: "CMS_Comments");

            migrationBuilder.DropIndex(
                name: "IX_CMS_Comments_CreatedByUserId",
                table: "CMS_Comments");

            migrationBuilder.DropColumn(
                name: "CMS_NewsId",
                table: "CMS_Comments");

            migrationBuilder.DropColumn(
                name: "CMS_PostId",
                table: "CMS_Comments");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "CMS_News",
                nullable: true,
                oldClrType: typeof(Guid));
        }
    }
}
