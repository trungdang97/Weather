using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Data.Migrations
{
    public partial class fixRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspnetMemberships_AspnetUsers_UserId",
                table: "AspnetMemberships");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOnDate",
                table: "CMS_Comments");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Idm_RightsOfUsers",
                newName: "ModifiedOnDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Idm_RightsOfUsers",
                newName: "CreatedOnDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Idm_RightsInRoles",
                newName: "ModifiedOnDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Idm_RightsInRoles",
                newName: "CreatedOnDate");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedOnDate",
                table: "CMS_Posts",
                newName: "LastEditedOnDate");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "AspnetUsersInRoles",
                newName: "DeleteOnDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "AspnetUsersInRoles",
                newName: "CreateOnDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "AspnetMemberships",
                newName: "CreatedOnDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnDate",
                table: "Rights",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnDate",
                table: "Rights",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnDate",
                table: "Idm_Rights",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnDate",
                table: "Idm_Rights",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnDate",
                table: "CMS_NewsCategories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "LastEditedByUserId",
                table: "CMS_NewsCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditedOnDate",
                table: "CMS_NewsCategories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnDate",
                table: "CMS_News",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "LastEditedByUserId",
                table: "CMS_News",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_NewsCategories_AspnetMemberships_CreatedByUserId",
                table: "CMS_NewsCategories",
                column: "CreatedByUserId",
                principalTable: "AspnetMemberships",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_NewsCategories_AspnetMemberships_LastEditedByUserId",
                table: "CMS_NewsCategories",
                column: "LastEditedByUserId",
                principalTable: "AspnetMemberships",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_PostCategories_AspnetMemberships_CreatedByUserId",
                table: "CMS_PostCategories",
                column: "CreatedByUserId",
                principalTable: "AspnetMemberships",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_PostCategories_AspnetMemberships_LastEditedByUserId",
                table: "CMS_PostCategories",
                column: "LastEditedByUserId",
                principalTable: "AspnetMemberships",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CMS_Posts_AspnetMemberships_LastEditedByUserId",
                table: "CMS_Posts",
                column: "LastEditedByUserId",
                principalTable: "AspnetMemberships",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
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
                name: "CreatedOnDate",
                table: "Rights");

            migrationBuilder.DropColumn(
                name: "ModifiedOnDate",
                table: "Rights");

            migrationBuilder.DropColumn(
                name: "CreatedOnDate",
                table: "Idm_Rights");

            migrationBuilder.DropColumn(
                name: "ModifiedOnDate",
                table: "Idm_Rights");

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
                name: "CreatedOnDate",
                table: "CMS_NewsCategories");

            migrationBuilder.DropColumn(
                name: "LastEditedByUserId",
                table: "CMS_NewsCategories");

            migrationBuilder.DropColumn(
                name: "LastEditedOnDate",
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
                name: "ModifiedOnDate",
                table: "Idm_RightsOfUsers",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOnDate",
                table: "Idm_RightsOfUsers",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedOnDate",
                table: "Idm_RightsInRoles",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOnDate",
                table: "Idm_RightsInRoles",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "LastEditedOnDate",
                table: "CMS_Posts",
                newName: "LastUpdatedOnDate");

            migrationBuilder.RenameColumn(
                name: "DeleteOnDate",
                table: "AspnetUsersInRoles",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "CreateOnDate",
                table: "AspnetUsersInRoles",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOnDate",
                table: "AspnetMemberships",
                newName: "CreateDate");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspnetMemberships_AspnetUsers_UserId",
                table: "AspnetMemberships",
                column: "UserId",
                principalTable: "AspnetUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
