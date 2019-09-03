using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Data.Migrations
{
    public partial class AddASPMembership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CMS_NewsCategory",
                table: "CMS_NewsCategory");

            migrationBuilder.RenameTable(
                name: "CMS_NewsCategory",
                newName: "CMS_NewsCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CMS_NewsCategories",
                table: "CMS_NewsCategories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspnetRoles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    RoleName = table.Column<string>(maxLength: 256, nullable: false),
                    LoweredRoleName = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    EnableDelete = table.Column<bool>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    CreatedOnDate = table.Column<DateTime>(nullable: false),
                    LastModifiedByUserId = table.Column<Guid>(nullable: false),
                    LastModifiedOnDate = table.Column<DateTime>(nullable: false),
                    RoleCode = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspnetRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "AspnetUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    LoweredUserName = table.Column<string>(maxLength: 256, nullable: false),
                    MobileAlias = table.Column<string>(maxLength: 16, nullable: true),
                    IsAnonymous = table.Column<bool>(nullable: false),
                    LastActivityDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FinanceCode = table.Column<string>(maxLength: 256, nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspnetUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CMS_Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    CreatedOnDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedOnDate = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    IsApprove = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ParentCommentId = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    ThreadId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMS_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CMS_News",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NewsCategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    FinishedDate = table.Column<DateTime>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    CreatedByUserName = table.Column<string>(nullable: true),
                    Thumbnail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMS_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CMS_News_CMS_NewsCategories_NewsCategoryId",
                        column: x => x.NewsCategoryId,
                        principalTable: "CMS_NewsCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CMS_PostCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMS_PostCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CMS_Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PostCategoryId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    CreatedOnDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedOnDate = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    IsApprove = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMS_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Idm_Rights",
                columns: table => new
                {
                    RightCode = table.Column<string>(maxLength: 256, nullable: false),
                    RightName = table.Column<string>(maxLength: 1024, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: true),
                    Order = table.Column<int>(nullable: true),
                    IsGroup = table.Column<bool>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    GroupCode = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idm_Rights", x => x.RightCode);
                    table.ForeignKey(
                        name: "FK_Idm_Rights_Idm_Rights_GroupCode",
                        column: x => x.GroupCode,
                        principalTable: "Idm_Rights",
                        principalColumn: "RightCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Navigations",
                columns: table => new
                {
                    NavigationId = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(maxLength: 256, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Status = table.Column<bool>(nullable: true),
                    Order = table.Column<int>(nullable: true),
                    HasChild = table.Column<bool>(nullable: false),
                    UrlRewrite = table.Column<string>(maxLength: 512, nullable: true),
                    IconClass = table.Column<string>(maxLength: 50, nullable: true),
                    NavigationName_En = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOnDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(nullable: true),
                    LastModifiedOnDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdPath = table.Column<string>(maxLength: 450, nullable: true),
                    Path = table.Column<string>(maxLength: 900, nullable: true),
                    Level = table.Column<int>(nullable: false),
                    SubUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navigations", x => x.NavigationId);
                    table.ForeignKey(
                        name: "FK_Navigations_Navigations_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Navigations",
                        principalColumn: "NavigationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rights",
                columns: table => new
                {
                    RightId = table.Column<Guid>(nullable: false),
                    ParentRightId = table.Column<Guid>(nullable: true),
                    RightCode = table.Column<string>(maxLength: 256, nullable: false),
                    RightName = table.Column<string>(maxLength: 256, nullable: false),
                    Status = table.Column<bool>(nullable: true),
                    Order = table.Column<int>(nullable: true),
                    HasChild = table.Column<bool>(nullable: false),
                    UrlRewrite = table.Column<string>(maxLength: 512, nullable: true),
                    IconClass = table.Column<string>(maxLength: 512, nullable: true)
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
                name: "AspnetMemberships",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Password = table.Column<string>(maxLength: 128, nullable: false),
                    PasswordFormat = table.Column<int>(nullable: false),
                    PasswordSalt = table.Column<string>(maxLength: 128, nullable: false),
                    MobilePIN = table.Column<string>(maxLength: 16, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    LoweredEmail = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordQuestion = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordAnswer = table.Column<string>(maxLength: 128, nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    IsLockedOut = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastPasswordChangedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastLockoutDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FailedPasswordAttemptCount = table.Column<int>(nullable: false),
                    FailedPasswordAttemptWindowStart = table.Column<DateTime>(type: "datetime", nullable: false),
                    FailedPasswordAnswerAttemptCount = table.Column<int>(nullable: false),
                    FailedPasswordAnswerAttemptWindowStart = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comment = table.Column<string>(type: "ntext", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    LastModifiedByUserId = table.Column<Guid>(nullable: false),
                    LastModifiedOnDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FullName = table.Column<string>(maxLength: 512, nullable: true),
                    NickName = table.Column<string>(maxLength: 512, nullable: true),
                    ShortName = table.Column<string>(maxLength: 256, nullable: true),
                    OtherEmail = table.Column<string>(maxLength: 256, nullable: true),
                    MobilePhone = table.Column<string>(maxLength: 50, nullable: true),
                    HomePhone = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspnetMemberships", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AspnetMemberships_AspnetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspnetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspnetUsersInRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspnetUsersInRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspnetUsersInRoles_AspnetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspnetRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspnetUsersInRoles_AspnetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspnetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idm_RightsInRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    RightCode = table.Column<string>(maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idm_RightsInRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idm_RightsInRoles_Idm_Rights_RightCode",
                        column: x => x.RightCode,
                        principalTable: "Idm_Rights",
                        principalColumn: "RightCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Idm_RightsInRoles_AspnetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspnetRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idm_RightsOfUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    RightCode = table.Column<string>(maxLength: 256, nullable: false),
                    InheritedFromRoles = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Inherited = table.Column<bool>(nullable: false),
                    Enable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idm_RightsOfUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idm_RightsOfUsers_Idm_Rights_RightCode",
                        column: x => x.RightCode,
                        principalTable: "Idm_Rights",
                        principalColumn: "RightCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Idm_RightsOfUsers_AspnetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspnetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NavigationRoles",
                columns: table => new
                {
                    NavigationRoleId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    NavigationId = table.Column<Guid>(nullable: false),
                    FromSubNavigation = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationRoles", x => x.NavigationRoleId);
                    table.ForeignKey(
                        name: "FK_NavigationRoles_Navigations_NavigationId",
                        column: x => x.NavigationId,
                        principalTable: "Navigations",
                        principalColumn: "NavigationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RightRoles",
                columns: table => new
                {
                    RightRoleId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    RightId = table.Column<Guid>(nullable: false),
                    RightName = table.Column<string>(maxLength: 256, nullable: true),
                    RightCode = table.Column<string>(maxLength: 256, nullable: true)
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
                name: "IX_AspnetUsersInRoles_RoleId",
                table: "AspnetUsersInRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspnetUsersInRoles_UserId",
                table: "AspnetUsersInRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CMS_News_NewsCategoryId",
                table: "CMS_News",
                column: "NewsCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Idm_Rights_GroupCode",
                table: "Idm_Rights",
                column: "GroupCode");

            migrationBuilder.CreateIndex(
                name: "IX_Idm_RightsInRoles_RightCode",
                table: "Idm_RightsInRoles",
                column: "RightCode");

            migrationBuilder.CreateIndex(
                name: "IX_Idm_RightsInRoles_RoleId",
                table: "Idm_RightsInRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Idm_RightsOfUsers_RightCode",
                table: "Idm_RightsOfUsers",
                column: "RightCode");

            migrationBuilder.CreateIndex(
                name: "IX_Idm_RightsOfUsers_UserId",
                table: "Idm_RightsOfUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationRoles_NavigationId",
                table: "NavigationRoles",
                column: "NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Navigations_ParentId",
                table: "Navigations",
                column: "ParentId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspnetMemberships");

            migrationBuilder.DropTable(
                name: "AspnetUsersInRoles");

            migrationBuilder.DropTable(
                name: "CMS_Comments");

            migrationBuilder.DropTable(
                name: "CMS_News");

            migrationBuilder.DropTable(
                name: "CMS_PostCategories");

            migrationBuilder.DropTable(
                name: "CMS_Posts");

            migrationBuilder.DropTable(
                name: "Idm_RightsInRoles");

            migrationBuilder.DropTable(
                name: "Idm_RightsOfUsers");

            migrationBuilder.DropTable(
                name: "NavigationRoles");

            migrationBuilder.DropTable(
                name: "RightRoles");

            migrationBuilder.DropTable(
                name: "Idm_Rights");

            migrationBuilder.DropTable(
                name: "AspnetUsers");

            migrationBuilder.DropTable(
                name: "Navigations");

            migrationBuilder.DropTable(
                name: "Rights");

            migrationBuilder.DropTable(
                name: "AspnetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CMS_NewsCategories",
                table: "CMS_NewsCategories");

            migrationBuilder.RenameTable(
                name: "CMS_NewsCategories",
                newName: "CMS_NewsCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CMS_NewsCategory",
                table: "CMS_NewsCategory",
                column: "Id");
        }
    }
}
