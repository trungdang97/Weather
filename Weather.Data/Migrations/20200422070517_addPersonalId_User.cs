using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Data.Migrations
{
    public partial class addPersonalId_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoweredEmail",
                table: "AspnetMemberships");

            migrationBuilder.DropColumn(
                name: "MobilePIN",
                table: "AspnetMemberships");

            migrationBuilder.AddColumn<string>(
                name: "PersonalId",
                table: "AspnetMemberships",
                maxLength: 12,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "AspnetMemberships");

            migrationBuilder.AddColumn<string>(
                name: "LoweredEmail",
                table: "AspnetMemberships",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobilePIN",
                table: "AspnetMemberships",
                maxLength: 16,
                nullable: true);
        }
    }
}
