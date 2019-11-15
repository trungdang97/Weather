using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Data.Migrations
{
    public partial class updateCMStables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdatedOnDate",
                table: "CMS_Comments");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedOnDate",
                table: "CMS_Posts",
                newName: "LastEditedOnDate");

            migrationBuilder.AddColumn<Guid>(
                name: "LastEditedByUserId",
                table: "CMS_Posts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "CMS_PostCategories",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnDate",
                table: "CMS_PostCategories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "LastEditedByUserId",
                table: "CMS_PostCategories",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditedOnDate",
                table: "CMS_PostCategories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "CMS_NewsCategories",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastEditedByUserId",
                table: "CMS_NewsCategories",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnDate",
                table: "CMS_News",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "LastEditedByUserId",
                table: "CMS_News",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditedOnDate",
                table: "CMS_News",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentCommentId",
                table: "CMS_Comments",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "LastEditedByUserId",
                table: "CMS_Comments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditedOnDate",
                table: "CMS_Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CMS_Posts_LastEditedByUserId",
                table: "CMS_Posts",
                column: "LastEditedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CMS_PostCategories_CreatedByUserId",
                table: "CMS_PostCategories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CMS_PostCategories_LastEditedByUserId",
                table: "CMS_PostCategories",
                column: "LastEditedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CMS_NewsCategories_CreatedByUserId",
                table: "CMS_NewsCategories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CMS_NewsCategories_LastEditedByUserId",
                table: "CMS_NewsCategories",
                column: "LastEditedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CMS_News_LastEditedByUserId",
                table: "CMS_News",
                column: "LastEditedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CMS_Comments_LastEditedByUserId",
                table: "CMS_Comments",
                column: "LastEditedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_Comments_AspnetMemberships_LastEditedByUserId",
                table: "CMS_Comments",
                column: "LastEditedByUserId",
                principalTable: "AspnetMemberships",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_News_AspnetMemberships_LastEditedByUserId",
                table: "CMS_News",
                column: "LastEditedByUserId",
                principalTable: "AspnetMemberships",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_NewsCategories_AspnetMemberships_CreatedByUserId",
                table: "CMS_NewsCategories",
                column: "CreatedByUserId",
                principalTable: "AspnetMemberships",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_NewsCategories_AspnetMemberships_LastEditedByUserId",
                table: "CMS_NewsCategories",
                column: "LastEditedByUserId",
                principalTable: "AspnetMemberships",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_PostCategories_AspnetMemberships_CreatedByUserId",
                table: "CMS_PostCategories",
                column: "CreatedByUserId",
                principalTable: "AspnetMemberships",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_PostCategories_AspnetMemberships_LastEditedByUserId",
                table: "CMS_PostCategories",
                column: "LastEditedByUserId",
                principalTable: "AspnetMemberships",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_Posts_AspnetMemberships_LastEditedByUserId",
                table: "CMS_Posts",
                column: "LastEditedByUserId",
                principalTable: "AspnetMemberships",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CMS_Comments_AspnetMemberships_LastEditedByUserId",
                table: "CMS_Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_CMS_News_AspnetMemberships_LastEditedByUserId",
                table: "CMS_News");

            migrationBuilder.DropForeignKey(
                name: "FK_CMS_NewsCategories_AspnetMemberships_CreatedByUserId",
                table: "CMS_NewsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_CMS_NewsCategories_AspnetMemberships_LastEditedByUserId",
                table: "CMS_NewsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_CMS_PostCategories_AspnetMemberships_CreatedByUserId",
                table: "CMS_PostCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_CMS_PostCategories_AspnetMemberships_LastEditedByUserId",
                table: "CMS_PostCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_CMS_Posts_AspnetMemberships_LastEditedByUserId",
                table: "CMS_Posts");

            migrationBuilder.DropIndex(
                name: "IX_CMS_Posts_LastEditedByUserId",
                table: "CMS_Posts");

            migrationBuilder.DropIndex(
                name: "IX_CMS_PostCategories_CreatedByUserId",
                table: "CMS_PostCategories");

            migrationBuilder.DropIndex(
                name: "IX_CMS_PostCategories_LastEditedByUserId",
                table: "CMS_PostCategories");

            migrationBuilder.DropIndex(
                name: "IX_CMS_NewsCategories_CreatedByUserId",
                table: "CMS_NewsCategories");

            migrationBuilder.DropIndex(
                name: "IX_CMS_NewsCategories_LastEditedByUserId",
                table: "CMS_NewsCategories");

            migrationBuilder.DropIndex(
                name: "IX_CMS_News_LastEditedByUserId",
                table: "CMS_News");

            migrationBuilder.DropIndex(
                name: "IX_CMS_Comments_LastEditedByUserId",
                table: "CMS_Comments");

            migrationBuilder.DropColumn(
                name: "LastEditedByUserId",
                table: "CMS_Posts");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "CMS_PostCategories");

            migrationBuilder.DropColumn(
                name: "CreatedOnDate",
                table: "CMS_PostCategories");

            migrationBuilder.DropColumn(
                name: "LastEditedByUserId",
                table: "CMS_PostCategories");

            migrationBuilder.DropColumn(
                name: "LastEditedOnDate",
                table: "CMS_PostCategories");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "CMS_NewsCategories");

            migrationBuilder.DropColumn(
                name: "LastEditedByUserId",
                table: "CMS_NewsCategories");

            migrationBuilder.DropColumn(
                name: "CreatedOnDate",
                table: "CMS_News");

            migrationBuilder.DropColumn(
                name: "LastEditedByUserId",
                table: "CMS_News");

            migrationBuilder.DropColumn(
                name: "LastEditedOnDate",
                table: "CMS_News");

            migrationBuilder.DropColumn(
                name: "LastEditedByUserId",
                table: "CMS_Comments");

            migrationBuilder.DropColumn(
                name: "LastEditedOnDate",
                table: "CMS_Comments");

            migrationBuilder.RenameColumn(
                name: "LastEditedOnDate",
                table: "CMS_Posts",
                newName: "LastUpdatedOnDate");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentCommentId",
                table: "CMS_Comments",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOnDate",
                table: "CMS_Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
