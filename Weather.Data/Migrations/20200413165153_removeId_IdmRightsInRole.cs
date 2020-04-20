using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Data.Migrations
{
    public partial class removeId_IdmRightsInRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Idm_RightsInRoles",
                table: "Idm_RightsInRoles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Idm_RightsInRoles");

            migrationBuilder.AddColumn<Guid>(
                name: "TempId",
                table: "Idm_RightsInRoles",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idm_RightsInRoles",
                table: "Idm_RightsInRoles",
                column: "TempId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Idm_RightsInRoles",
                table: "Idm_RightsInRoles");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "Idm_RightsInRoles");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Idm_RightsInRoles",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idm_RightsInRoles",
                table: "Idm_RightsInRoles",
                column: "Id");
        }
    }
}
