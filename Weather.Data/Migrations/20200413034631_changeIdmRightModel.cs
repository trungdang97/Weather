using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Data.Migrations
{
    public partial class changeIdmRightModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Idm_Rights_Idm_Rights_GroupCode",
                table: "Idm_Rights");

            migrationBuilder.DropForeignKey(
                name: "FK_Idm_RightsInRoles_Idm_Rights_RightCode",
                table: "Idm_RightsInRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Idm_RightsOfUsers_Idm_Rights_RightCode",
                table: "Idm_RightsOfUsers");

            migrationBuilder.DropIndex(
                name: "IX_Idm_RightsOfUsers_RightCode",
                table: "Idm_RightsOfUsers");

            migrationBuilder.DropIndex(
                name: "IX_Idm_RightsInRoles_RightCode",
                table: "Idm_RightsInRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idm_Rights",
                table: "Idm_Rights");

            migrationBuilder.DropIndex(
                name: "IX_Idm_Rights_GroupCode",
                table: "Idm_Rights");

            migrationBuilder.DropColumn(
                name: "RightCode",
                table: "Idm_RightsOfUsers");

            migrationBuilder.DropColumn(
                name: "RightCode",
                table: "Idm_RightsInRoles");

            migrationBuilder.DropColumn(
                name: "RightCode",
                table: "Idm_Rights");

            migrationBuilder.DropColumn(
                name: "GroupCode",
                table: "Idm_Rights");

            migrationBuilder.AddColumn<Guid>(
                name: "RightId",
                table: "Idm_RightsOfUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RightId",
                table: "Idm_RightsInRoles",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RightId",
                table: "Idm_Rights",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Idm_Rights",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idm_Rights",
                table: "Idm_Rights",
                column: "RightId");

            migrationBuilder.CreateIndex(
                name: "IX_Idm_RightsOfUsers_RightId",
                table: "Idm_RightsOfUsers",
                column: "RightId");

            migrationBuilder.CreateIndex(
                name: "IX_Idm_RightsInRoles_RightId",
                table: "Idm_RightsInRoles",
                column: "RightId");

            migrationBuilder.CreateIndex(
                name: "IX_Idm_Rights_GroupId",
                table: "Idm_Rights",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Idm_Rights_Idm_Rights_GroupId",
                table: "Idm_Rights",
                column: "GroupId",
                principalTable: "Idm_Rights",
                principalColumn: "RightId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Idm_RightsInRoles_Idm_Rights_RightId",
                table: "Idm_RightsInRoles",
                column: "RightId",
                principalTable: "Idm_Rights",
                principalColumn: "RightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Idm_RightsOfUsers_Idm_Rights_RightId",
                table: "Idm_RightsOfUsers",
                column: "RightId",
                principalTable: "Idm_Rights",
                principalColumn: "RightId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Idm_Rights_Idm_Rights_GroupId",
                table: "Idm_Rights");

            migrationBuilder.DropForeignKey(
                name: "FK_Idm_RightsInRoles_Idm_Rights_RightId",
                table: "Idm_RightsInRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Idm_RightsOfUsers_Idm_Rights_RightId",
                table: "Idm_RightsOfUsers");

            migrationBuilder.DropIndex(
                name: "IX_Idm_RightsOfUsers_RightId",
                table: "Idm_RightsOfUsers");

            migrationBuilder.DropIndex(
                name: "IX_Idm_RightsInRoles_RightId",
                table: "Idm_RightsInRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idm_Rights",
                table: "Idm_Rights");

            migrationBuilder.DropIndex(
                name: "IX_Idm_Rights_GroupId",
                table: "Idm_Rights");

            migrationBuilder.DropColumn(
                name: "RightId",
                table: "Idm_RightsOfUsers");

            migrationBuilder.DropColumn(
                name: "RightId",
                table: "Idm_RightsInRoles");

            migrationBuilder.DropColumn(
                name: "RightId",
                table: "Idm_Rights");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Idm_Rights");

            migrationBuilder.AddColumn<string>(
                name: "RightCode",
                table: "Idm_RightsOfUsers",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RightCode",
                table: "Idm_RightsInRoles",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RightCode",
                table: "Idm_Rights",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GroupCode",
                table: "Idm_Rights",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idm_Rights",
                table: "Idm_Rights",
                column: "RightCode");

            migrationBuilder.CreateIndex(
                name: "IX_Idm_RightsOfUsers_RightCode",
                table: "Idm_RightsOfUsers",
                column: "RightCode");

            migrationBuilder.CreateIndex(
                name: "IX_Idm_RightsInRoles_RightCode",
                table: "Idm_RightsInRoles",
                column: "RightCode");

            migrationBuilder.CreateIndex(
                name: "IX_Idm_Rights_GroupCode",
                table: "Idm_Rights",
                column: "GroupCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Idm_Rights_Idm_Rights_GroupCode",
                table: "Idm_Rights",
                column: "GroupCode",
                principalTable: "Idm_Rights",
                principalColumn: "RightCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Idm_RightsInRoles_Idm_Rights_RightCode",
                table: "Idm_RightsInRoles",
                column: "RightCode",
                principalTable: "Idm_Rights",
                principalColumn: "RightCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Idm_RightsOfUsers_Idm_Rights_RightCode",
                table: "Idm_RightsOfUsers",
                column: "RightCode",
                principalTable: "Idm_Rights",
                principalColumn: "RightCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
