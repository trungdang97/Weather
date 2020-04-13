using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Data.Migrations
{
    public partial class remove_redundantRightandRightRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RightRoles");

            migrationBuilder.DropTable(
                name: "Rights");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rights",
                columns: table => new
                {
                    RightId = table.Column<Guid>(nullable: false),
                    CreatedOnDate = table.Column<DateTime>(nullable: false),
                    HasChild = table.Column<bool>(nullable: false),
                    IconClass = table.Column<string>(maxLength: 512, nullable: true),
                    ModifiedOnDate = table.Column<DateTime>(nullable: false),
                    Order = table.Column<int>(nullable: true),
                    ParentRightId = table.Column<Guid>(nullable: true),
                    RightCode = table.Column<string>(maxLength: 256, nullable: false),
                    RightName = table.Column<string>(maxLength: 256, nullable: false),
                    Status = table.Column<bool>(nullable: true),
                    UrlRewrite = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rights", x => x.RightId);
                    table.ForeignKey(
                        name: "FK_Rights_Rights_ParentRightId",
                        column: x => x.ParentRightId,
                        principalTable: "Rights",
                        principalColumn: "RightId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RightRoles",
                columns: table => new
                {
                    RightRoleId = table.Column<Guid>(nullable: false),
                    RightCode = table.Column<string>(maxLength: 256, nullable: true),
                    RightId = table.Column<Guid>(nullable: false),
                    RightName = table.Column<string>(maxLength: 256, nullable: true),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RightRoles", x => x.RightRoleId);
                    table.ForeignKey(
                        name: "FK_RightRoles_Rights_RightId",
                        column: x => x.RightId,
                        principalTable: "Rights",
                        principalColumn: "RightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RightRoles_AspnetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspnetRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RightRoles_RightId",
                table: "RightRoles",
                column: "RightId");

            migrationBuilder.CreateIndex(
                name: "IX_RightRoles_RoleId",
                table: "RightRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Rights_ParentRightId",
                table: "Rights",
                column: "ParentRightId");
        }
    }
}
