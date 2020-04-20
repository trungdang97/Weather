﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Weather.Data.V1;

namespace Weather.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200413165153_removeId_IdmRightsInRole")]
    partial class removeId_IdmRightsInRole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Weather.Data.V1.AspnetMembership", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("Comment")
                        .HasColumnType("ntext");

                    b.Property<Guid>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOnDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<int>("FailedPasswordAnswerAttemptCount");

                    b.Property<DateTime>("FailedPasswordAnswerAttemptWindowStart")
                        .HasColumnType("datetime");

                    b.Property<int>("FailedPasswordAttemptCount");

                    b.Property<DateTime>("FailedPasswordAttemptWindowStart")
                        .HasColumnType("datetime");

                    b.Property<string>("FullName")
                        .HasMaxLength(512);

                    b.Property<string>("HomePhone")
                        .HasMaxLength(50);

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsLockedOut");

                    b.Property<DateTime>("LastLockoutDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("LastModifiedByUserId");

                    b.Property<DateTime>("LastModifiedOnDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("LastPasswordChangedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LoweredEmail")
                        .HasMaxLength(256);

                    b.Property<string>("MobilePhone")
                        .HasMaxLength(50);

                    b.Property<string>("MobilePin")
                        .HasColumnName("MobilePIN")
                        .HasMaxLength(16);

                    b.Property<string>("NickName")
                        .HasMaxLength(512);

                    b.Property<string>("OtherEmail")
                        .HasMaxLength(256);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("PasswordAnswer")
                        .HasMaxLength(128);

                    b.Property<int>("PasswordFormat");

                    b.Property<string>("PasswordQuestion")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("ShortName")
                        .HasMaxLength(256);

                    b.HasKey("UserId");

                    b.ToTable("AspnetMemberships");
                });

            modelBuilder.Entity("Weather.Data.V1.AspnetRoles", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOnDate");

                    b.Property<string>("Description")
                        .HasMaxLength(256);

                    b.Property<bool>("EnableDelete");

                    b.Property<Guid>("LastModifiedByUserId");

                    b.Property<DateTime>("LastModifiedOnDate");

                    b.Property<string>("LoweredRoleName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("RoleId");

                    b.ToTable("AspnetRoles");
                });

            modelBuilder.Entity("Weather.Data.V1.AspnetUsers", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FinanceCode")
                        .HasMaxLength(256);

                    b.Property<bool>("IsAnonymous");

                    b.Property<DateTime?>("LastActivityDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LoweredUserName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("MobileAlias")
                        .HasMaxLength(16);

                    b.Property<int>("Type");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("UserId");

                    b.ToTable("AspnetUsers");
                });

            modelBuilder.Entity("Weather.Data.V1.AspnetUsersInRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateOnDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DeleteOnDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("RoleId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspnetUsersInRoles");
                });

            modelBuilder.Entity("Weather.Data.V1.CMS_Comment", b =>
                {
                    b.Property<Guid>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<Guid?>("CMS_NewsNewsId");

                    b.Property<Guid?>("CMS_PostPostId");

                    b.Property<Guid>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOnDate");

                    b.Property<string>("Email");

                    b.Property<bool>("IsApprove");

                    b.Property<Guid?>("LastEditedByUserId");

                    b.Property<DateTime?>("LastEditedOnDate");

                    b.Property<Guid?>("ParentCommentId");

                    b.Property<Guid>("ThreadId");

                    b.Property<string>("Title");

                    b.Property<string>("Type");

                    b.HasKey("CommentId");

                    b.HasIndex("CMS_NewsNewsId");

                    b.HasIndex("CMS_PostPostId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("LastEditedByUserId");

                    b.ToTable("CMS_Comments");
                });

            modelBuilder.Entity("Weather.Data.V1.CMS_News", b =>
                {
                    b.Property<Guid>("NewsId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<Guid>("CreatedByUserId");

                    b.Property<string>("CreatedByUserName");

                    b.Property<DateTime>("CreatedOnDate");

                    b.Property<DateTime>("FinishedDate");

                    b.Property<bool>("IsHidden");

                    b.Property<Guid?>("LastEditedByUserId");

                    b.Property<DateTime>("LastEditedOnDate");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<Guid>("NewsCategoryId");

                    b.Property<string>("Thumbnail");

                    b.HasKey("NewsId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("LastEditedByUserId");

                    b.HasIndex("NewsCategoryId");

                    b.ToTable("CMS_News");
                });

            modelBuilder.Entity("Weather.Data.V1.CMS_NewsCategory", b =>
                {
                    b.Property<Guid>("NewsCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOnDate");

                    b.Property<string>("Description");

                    b.Property<Guid?>("LastEditedByUserId");

                    b.Property<DateTime>("LastEditedOnDate");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("Type");

                    b.HasKey("NewsCategoryId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("LastEditedByUserId");

                    b.ToTable("CMS_NewsCategories");
                });

            modelBuilder.Entity("Weather.Data.V1.CMS_Post", b =>
                {
                    b.Property<Guid>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<Guid>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOnDate");

                    b.Property<bool>("IsApprove");

                    b.Property<Guid>("LastEditedByUserId");

                    b.Property<DateTime>("LastEditedOnDate");

                    b.Property<Guid>("PostCategoryId");

                    b.Property<string>("Title");

                    b.HasKey("PostId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("LastEditedByUserId");

                    b.HasIndex("PostCategoryId");

                    b.ToTable("CMS_Posts");
                });

            modelBuilder.Entity("Weather.Data.V1.CMS_PostCategory", b =>
                {
                    b.Property<Guid>("PostCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOnDate");

                    b.Property<string>("Description");

                    b.Property<Guid>("LastEditedByUserId");

                    b.Property<DateTime>("LastEditedOnDate");

                    b.Property<string>("Name");

                    b.HasKey("PostCategoryId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("LastEditedByUserId");

                    b.ToTable("CMS_PostCategories");
                });

            modelBuilder.Entity("Weather.Data.V1.Idm_Right", b =>
                {
                    b.Property<Guid>("RightId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOnDate");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<Guid?>("GroupId");

                    b.Property<bool>("IsGroup");

                    b.Property<Guid>("LastModifiedByUserId");

                    b.Property<int>("Level");

                    b.Property<DateTime>("ModifiedOnDate");

                    b.Property<int?>("Order");

                    b.Property<string>("RightName")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<bool?>("Status");

                    b.HasKey("RightId");

                    b.HasIndex("GroupId");

                    b.ToTable("Idm_Rights");
                });

            modelBuilder.Entity("Weather.Data.V1.Idm_RightsInRole", b =>
                {
                    b.Property<Guid>("TempId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOnDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ModifiedOnDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("RightId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("TempId");

                    b.HasIndex("RightId");

                    b.HasIndex("RoleId");

                    b.ToTable("Idm_RightsInRoles");
                });

            modelBuilder.Entity("Weather.Data.V1.Idm_RightsOfUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOnDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("Enable");

                    b.Property<bool>("Inherited");

                    b.Property<string>("InheritedFromRoles");

                    b.Property<DateTime>("ModifiedOnDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("RightId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RightId");

                    b.HasIndex("UserId");

                    b.ToTable("Idm_RightsOfUsers");
                });

            modelBuilder.Entity("Weather.Data.V1.Navigation", b =>
                {
                    b.Property<Guid>("NavigationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .HasMaxLength(256);

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime?>("CreatedOnDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("HasChild");

                    b.Property<string>("IconClass")
                        .HasMaxLength(50);

                    b.Property<string>("IdPath")
                        .HasMaxLength(450);

                    b.Property<Guid?>("LastModifiedByUserId");

                    b.Property<DateTime?>("LastModifiedOnDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Level");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("NavigationNameEn")
                        .HasColumnName("NavigationName_En")
                        .HasMaxLength(256);

                    b.Property<int?>("Order");

                    b.Property<Guid?>("ParentId");

                    b.Property<string>("Path")
                        .HasMaxLength(900);

                    b.Property<bool?>("Status");

                    b.Property<string>("SubUrl");

                    b.Property<string>("UrlRewrite")
                        .HasMaxLength(512);

                    b.HasKey("NavigationId");

                    b.HasIndex("ParentId");

                    b.ToTable("Navigations");
                });

            modelBuilder.Entity("Weather.Data.V1.NavigationRole", b =>
                {
                    b.Property<Guid>("NavigationRoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("FromSubNavigation");

                    b.Property<Guid>("NavigationId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("NavigationRoleId");

                    b.HasIndex("NavigationId");

                    b.ToTable("NavigationRoles");
                });

            modelBuilder.Entity("Weather.Data.V1.AspnetMembership", b =>
                {
                    b.HasOne("Weather.Data.V1.AspnetUsers", "User")
                        .WithOne("AspnetMembership")
                        .HasForeignKey("Weather.Data.V1.AspnetMembership", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Weather.Data.V1.AspnetUsersInRoles", b =>
                {
                    b.HasOne("Weather.Data.V1.AspnetRoles", "Role")
                        .WithMany("AspnetUsersInRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Weather.Data.V1.AspnetUsers", "User")
                        .WithMany("AspnetUsersInRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Weather.Data.V1.CMS_Comment", b =>
                {
                    b.HasOne("Weather.Data.V1.CMS_News")
                        .WithMany("Comments")
                        .HasForeignKey("CMS_NewsNewsId");

                    b.HasOne("Weather.Data.V1.CMS_Post")
                        .WithMany("Comments")
                        .HasForeignKey("CMS_PostPostId");

                    b.HasOne("Weather.Data.V1.AspnetMembership", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Weather.Data.V1.AspnetMembership", "LastEditedByUser")
                        .WithMany()
                        .HasForeignKey("LastEditedByUserId");
                });

            modelBuilder.Entity("Weather.Data.V1.CMS_News", b =>
                {
                    b.HasOne("Weather.Data.V1.AspnetMembership", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Weather.Data.V1.AspnetMembership", "LastEditedByUser")
                        .WithMany()
                        .HasForeignKey("LastEditedByUserId");

                    b.HasOne("Weather.Data.V1.CMS_NewsCategory", "NewsCategory")
                        .WithMany()
                        .HasForeignKey("NewsCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Weather.Data.V1.CMS_NewsCategory", b =>
                {
                    b.HasOne("Weather.Data.V1.AspnetMembership", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Weather.Data.V1.AspnetMembership", "LastEditedByUser")
                        .WithMany()
                        .HasForeignKey("LastEditedByUserId");
                });

            modelBuilder.Entity("Weather.Data.V1.CMS_Post", b =>
                {
                    b.HasOne("Weather.Data.V1.AspnetMembership", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Weather.Data.V1.AspnetMembership", "LastEditedByUser")
                        .WithMany()
                        .HasForeignKey("LastEditedByUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Weather.Data.V1.CMS_PostCategory", "PostCategory")
                        .WithMany()
                        .HasForeignKey("PostCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Weather.Data.V1.CMS_PostCategory", b =>
                {
                    b.HasOne("Weather.Data.V1.AspnetMembership", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Weather.Data.V1.AspnetMembership", "LastEditedByUser")
                        .WithMany()
                        .HasForeignKey("LastEditedByUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Weather.Data.V1.Idm_Right", b =>
                {
                    b.HasOne("Weather.Data.V1.Idm_Right", "GroupIdNavigation")
                        .WithMany("InverseGroupIdNavigation")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Weather.Data.V1.Idm_RightsInRole", b =>
                {
                    b.HasOne("Weather.Data.V1.Idm_Right", "RightIdNavigation")
                        .WithMany("IdmRightsInRole")
                        .HasForeignKey("RightId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Weather.Data.V1.AspnetRoles", "Role")
                        .WithMany("IdmRightsInRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Weather.Data.V1.Idm_RightsOfUser", b =>
                {
                    b.HasOne("Weather.Data.V1.Idm_Right", "RightIdNavigation")
                        .WithMany("IdmRightsOfUser")
                        .HasForeignKey("RightId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Weather.Data.V1.AspnetUsers", "User")
                        .WithMany("IdmRightsOfUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Weather.Data.V1.Navigation", b =>
                {
                    b.HasOne("Weather.Data.V1.Navigation", "Parent")
                        .WithMany("InverseParent")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Weather.Data.V1.NavigationRole", b =>
                {
                    b.HasOne("Weather.Data.V1.Navigation", "Navigation")
                        .WithMany("NavigationRole")
                        .HasForeignKey("NavigationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
