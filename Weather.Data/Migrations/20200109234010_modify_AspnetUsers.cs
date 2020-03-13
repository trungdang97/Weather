using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Data.Migrations
{
    public partial class modify_AspnetUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastActivityDate",
                table: "AspnetUsers",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddForeignKey(
                name: "FK_AspnetMemberships_AspnetUsers_UserId",
                table: "AspnetMemberships",
                column: "UserId",
                principalTable: "AspnetUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspnetMemberships_AspnetUsers_UserId",
                table: "AspnetMemberships");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastActivityDate",
                table: "AspnetUsers",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);
        }
    }
}
