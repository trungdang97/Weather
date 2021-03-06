USE [master]
GO
/****** Object:  Database [cms_VKTTV]    Script Date: 7/26/2019 1:25:12 AM ******/
CREATE DATABASE [cms_VKTTV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cms_VKTTV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\cms_VKTTV.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'cms_VKTTV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\cms_VKTTV_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [cms_VKTTV] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cms_VKTTV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cms_VKTTV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cms_VKTTV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cms_VKTTV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cms_VKTTV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cms_VKTTV] SET ARITHABORT OFF 
GO
ALTER DATABASE [cms_VKTTV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [cms_VKTTV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cms_VKTTV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cms_VKTTV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cms_VKTTV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cms_VKTTV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cms_VKTTV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cms_VKTTV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cms_VKTTV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cms_VKTTV] SET  DISABLE_BROKER 
GO
ALTER DATABASE [cms_VKTTV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cms_VKTTV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cms_VKTTV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cms_VKTTV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cms_VKTTV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cms_VKTTV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [cms_VKTTV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cms_VKTTV] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [cms_VKTTV] SET  MULTI_USER 
GO
ALTER DATABASE [cms_VKTTV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cms_VKTTV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cms_VKTTV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cms_VKTTV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [cms_VKTTV] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [cms_VKTTV] SET QUERY_STORE = OFF
GO
USE [cms_VKTTV]
GO
/****** Object:  User [IIS APPPOOL\Weather]    Script Date: 7/26/2019 1:25:13 AM ******/
CREATE USER [IIS APPPOOL\Weather] FOR LOGIN [IIS APPPOOL\Weather] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\Weather]
GO
/****** Object:  Table [dbo].[aspnet_Membership]    Script Date: 7/26/2019 1:25:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Membership](
	[UserId] [uniqueidentifier] NOT NULL,
	[Password] [varchar](128) NULL,
	[PasswordSalt] [varchar](128) NULL,
	[FullName] [nvarchar](512) NULL,
	[ShortName] [nvarchar](512) NULL,
	[NickName] [nvarchar](512) NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[Phone] [varchar](512) NOT NULL,
	[Email] [varchar](512) NULL,
 CONSTRAINT [PK__aspnet_M__1788CC4C70E5A222] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Rights]    Script Date: 7/26/2019 1:25:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Rights](
	[RightId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Description] [nvarchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RightId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Roles]    Script Date: 7/26/2019 1:25:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Roles](
	[RoleId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Description] [nvarchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Roles_Rights_Relationship]    Script Date: 7/26/2019 1:25:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Roles_Rights_Relationship](
	[Id] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[RightId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Users]    Script Date: 7/26/2019 1:25:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[Username] [varchar](128) NOT NULL,
	[SimpleAuth] [uniqueidentifier] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK__aspnet_U__1788CC4C0C2AB95A] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cms_API]    Script Date: 7/26/2019 1:25:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_API](
	[APIId] [uniqueidentifier] NOT NULL,
	[APICode] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Price] [int] NOT NULL,
	[Duration] [int] NOT NULL,
	[DurationText] [nvarchar](max) NULL,
	[APITypeId] [uniqueidentifier] NOT NULL,
	[Body] [nvarchar](max) NULL,
	[Documentation] [nvarchar](max) NULL,
	[DocumentationLink] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_cms_API] PRIMARY KEY CLUSTERED 
(
	[APIId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cms_API_Membership_Relationship]    Script Date: 7/26/2019 1:25:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_API_Membership_Relationship](
	[Id] [uniqueidentifier] NOT NULL,
	[APIId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
	[FromDate] [date] NOT NULL,
	[ToDate] [date] NOT NULL,
	[TotalPrice] [int] NULL,
	[AccessToken] [uniqueidentifier] NOT NULL,
	[AccessCode] [varchar](6) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Disabled] [bit] NOT NULL,
 CONSTRAINT [PK_cms_API_Membership_Relationship] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cms_APIType]    Script Date: 7/26/2019 1:25:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_APIType](
	[APITypeId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[TypeOrder] [int] NULL,
 CONSTRAINT [PK_cms_APIType] PRIMARY KEY CLUSTERED 
(
	[APITypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cms_News]    Script Date: 7/26/2019 1:25:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_News](
	[NewsId] [uniqueidentifier] NOT NULL,
	[NewsCategory] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[FinishedDate] [datetime2](7) NULL,
	[WriterId] [nvarchar](max) NULL,
	[WriterName] [nvarchar](max) NULL,
	[Introduction] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
	[ApprovedStatus] [bit] NULL,
	[CreatedByUserId] [uniqueidentifier] NULL,
	[CreatedOnDate] [datetime2](7) NULL,
	[Thumbnail] [varchar](max) NULL,
 CONSTRAINT [PK__cms_News__954EBDF31DD35339] PRIMARY KEY CLUSTERED 
(
	[NewsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cms_NewsCategory]    Script Date: 7/26/2019 1:25:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_NewsCategory](
	[NewsCategoryId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Type] [varchar](10) NOT NULL,
	[Order] [int] NULL,
 CONSTRAINT [PK__cms_News__9885BDE7B184E48B] PRIMARY KEY CLUSTERED 
(
	[NewsCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cms_UserTransaction]    Script Date: 7/26/2019 1:25:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_UserTransaction](
	[BillId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[TotalPrice] [int] NOT NULL,
	[CreatedOnDate] [datetime2](7) NOT NULL,
	[Paid] [bit] NOT NULL,
	[PaidOnDate] [datetime2](7) NULL,
 CONSTRAINT [PK_cms_Bill] PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cms_UserTransaction_API]    Script Date: 7/26/2019 1:25:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_UserTransaction_API](
	[Id] [uniqueidentifier] NOT NULL,
	[BillId] [uniqueidentifier] NOT NULL,
	[APIId] [uniqueidentifier] NOT NULL,
	[FromDate] [datetime2](7) NOT NULL,
	[ToDate] [datetime2](7) NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_cms_Bill_API] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[aspnet_Membership] ([UserId], [Password], [PasswordSalt], [FullName], [ShortName], [NickName], [RoleId], [Phone], [Email]) VALUES (N'691b8a4c-2e62-42c9-a796-6267559e53ad', N'60145b511516f951a5d7de79d410e03f6ba19992c4b51cbe17aa7082156c66e0', N'gglbiTJnhL5sp3DN6Atr7pA4zBKWFGT8wkZLKrtHPls=', N'Nguyễn Quang Huy', N'Q/Huy', NULL, N'cc3def5c-c6e2-47be-bf38-09c1c8f6b341', N'0000000001', NULL)
INSERT [dbo].[aspnet_Membership] ([UserId], [Password], [PasswordSalt], [FullName], [ShortName], [NickName], [RoleId], [Phone], [Email]) VALUES (N'9ace3dc3-8710-4028-b434-7ed0211f4dec', N'6f918310fbfe0d3aaa8a55f0381e7b9bd3b83ff4f68c53c7629dba98dc20193e', N'8yrq28347yoidfuhao78yfaoahsdigy78', N'Quản trị hệ thống', N'Admin', N'Admin', N'4819f98f-18c0-4778-959d-9dc4625664cf', N'0000000000', NULL)
INSERT [dbo].[aspnet_Membership] ([UserId], [Password], [PasswordSalt], [FullName], [ShortName], [NickName], [RoleId], [Phone], [Email]) VALUES (N'b6372d6a-a331-4c5d-bf4f-a84cf05a9c05', N'b2b8551aec77927a0f0269b63cfd780f271ae2fb221a0562588d048dbeeb3e90', N'awieoruoijkl7s6f8783sdef09', N'Đặng Đức Trung', N'Trung Đặng', N'TrungDD', N'cc3def5c-c6e2-47be-bf38-09c1c8f6b341', N'0830000000', N'trung******@gmail.com')
INSERT [dbo].[aspnet_Membership] ([UserId], [Password], [PasswordSalt], [FullName], [ShortName], [NickName], [RoleId], [Phone], [Email]) VALUES (N'2d1c8a15-5d02-421a-9c05-e1173b658b2f', N'6cff0d7d5addd91da934b30b421e623a17965fed33c9dd37fed644b61b69c011', N'5GKs4/5oegPiaUCju1/2h1IB7PXShQp5B11Wlv8SqP9hGVoHCedRv4AdoAU6JzzVXr9Vu0ckxJAFAauAI5TMBg==', N'Nguyễn Văn A', N'Văn A', NULL, N'1a6641c2-a8e0-4356-81c8-245253acad86', N'0831231831', NULL)
INSERT [dbo].[aspnet_Rights] ([RightId], [Name], [Description]) VALUES (N'433ccc09-89fd-4df2-9a17-5619bacbaeae', N'Sử dụng API', N'APICONSUMER')
INSERT [dbo].[aspnet_Rights] ([RightId], [Name], [Description]) VALUES (N'b9c5aea9-19eb-4861-8eeb-b08fbc42e082', N'Duyệt tin', N'DUYETTIN')
INSERT [dbo].[aspnet_Rights] ([RightId], [Name], [Description]) VALUES (N'ee01b3eb-4856-4808-ad65-c0c57074e038', N'Viết tin bài', N'VIETTIN')
INSERT [dbo].[aspnet_Rights] ([RightId], [Name], [Description]) VALUES (N'eba4b6cd-9cff-44b5-b066-e824c5e55207', N'Tạo tài khoản', N'CREATEACCOUNT')
INSERT [dbo].[aspnet_Roles] ([RoleId], [Name], [Description]) VALUES (N'cc3def5c-c6e2-47be-bf38-09c1c8f6b341', N'Người viết tin bài', N'VIETTB')
INSERT [dbo].[aspnet_Roles] ([RoleId], [Name], [Description]) VALUES (N'1a6641c2-a8e0-4356-81c8-245253acad86', N'Người dùng', N'USER')
INSERT [dbo].[aspnet_Roles] ([RoleId], [Name], [Description]) VALUES (N'4819f98f-18c0-4778-959d-9dc4625664cf', N'Quản trị hệ thống', N'QTHT')
INSERT [dbo].[aspnet_Roles_Rights_Relationship] ([Id], [RoleId], [RightId]) VALUES (N'6e63201d-899a-46be-9a18-06d58c45d6de', N'4819f98f-18c0-4778-959d-9dc4625664cf', N'b9c5aea9-19eb-4861-8eeb-b08fbc42e082')
INSERT [dbo].[aspnet_Roles_Rights_Relationship] ([Id], [RoleId], [RightId]) VALUES (N'00f0b11c-9825-4dfc-815a-1bbb75fafc70', N'cc3def5c-c6e2-47be-bf38-09c1c8f6b341', N'433ccc09-89fd-4df2-9a17-5619bacbaeae')
INSERT [dbo].[aspnet_Roles_Rights_Relationship] ([Id], [RoleId], [RightId]) VALUES (N'ef67f5c6-ed9c-4965-ada0-4548a8fe4948', N'4819f98f-18c0-4778-959d-9dc4625664cf', N'ee01b3eb-4856-4808-ad65-c0c57074e038')
INSERT [dbo].[aspnet_Roles_Rights_Relationship] ([Id], [RoleId], [RightId]) VALUES (N'b3625525-4689-44ed-8412-5440cc51010b', N'4819f98f-18c0-4778-959d-9dc4625664cf', N'eba4b6cd-9cff-44b5-b066-e824c5e55207')
INSERT [dbo].[aspnet_Roles_Rights_Relationship] ([Id], [RoleId], [RightId]) VALUES (N'007106b4-e824-4596-859e-6a80ad78c10c', N'1a6641c2-a8e0-4356-81c8-245253acad86', N'433ccc09-89fd-4df2-9a17-5619bacbaeae')
INSERT [dbo].[aspnet_Roles_Rights_Relationship] ([Id], [RoleId], [RightId]) VALUES (N'196828f6-2e98-4630-9938-8406d91c37fb', N'4819f98f-18c0-4778-959d-9dc4625664cf', N'433ccc09-89fd-4df2-9a17-5619bacbaeae')
INSERT [dbo].[aspnet_Roles_Rights_Relationship] ([Id], [RoleId], [RightId]) VALUES (N'77b98e97-61a0-4249-be60-9376d9bd3370', N'cc3def5c-c6e2-47be-bf38-09c1c8f6b341', N'ee01b3eb-4856-4808-ad65-c0c57074e038')
INSERT [dbo].[aspnet_Users] ([UserId], [Username], [SimpleAuth], [IsActive]) VALUES (N'eced007d-e9ef-4b19-8c83-070fe84720df', N'sonha', N'cd9a545d-9682-4ba7-849d-3ba34690191d', 1)
INSERT [dbo].[aspnet_Users] ([UserId], [Username], [SimpleAuth], [IsActive]) VALUES (N'691b8a4c-2e62-42c9-a796-6267559e53ad', N'nguyenhuy', N'ca3fe180-b0da-4dae-9715-f1864989079b', 1)
INSERT [dbo].[aspnet_Users] ([UserId], [Username], [SimpleAuth], [IsActive]) VALUES (N'9ace3dc3-8710-4028-b434-7ed0211f4dec', N'admin', N'f5241b84-9d7f-4c23-b9f4-cd5dfa17107e', 1)
INSERT [dbo].[aspnet_Users] ([UserId], [Username], [SimpleAuth], [IsActive]) VALUES (N'b6372d6a-a331-4c5d-bf4f-a84cf05a9c05', N'trungdd', N'11ff34d0-6152-42b8-9270-dc96f9e0d248', 1)
INSERT [dbo].[aspnet_Users] ([UserId], [Username], [SimpleAuth], [IsActive]) VALUES (N'7e4cf790-08db-4e89-91de-ae106c4dd5cf', N'nguyenhuy', NULL, 1)
INSERT [dbo].[aspnet_Users] ([UserId], [Username], [SimpleAuth], [IsActive]) VALUES (N'2d1c8a15-5d02-421a-9c05-e1173b658b2f', N'test', N'ded9f020-759a-4096-a5f9-a6be65450afa', 1)
INSERT [dbo].[cms_API] ([APIId], [APICode], [Name], [Price], [Duration], [DurationText], [APITypeId], [Body], [Documentation], [DocumentationLink], [IsActive]) VALUES (N'7d073ff9-6a2b-41c3-95c6-057d70589528', N'API_NCKH', N'Dịch vụ nghiên cứu khoa học 1', 45621, 6, N'6 tháng', N'356c8364-a4b3-4fc7-bed3-d59fd81fa780', NULL, NULL, NULL, 1)
INSERT [dbo].[cms_API] ([APIId], [APICode], [Name], [Price], [Duration], [DurationText], [APITypeId], [Body], [Documentation], [DocumentationLink], [IsActive]) VALUES (N'1156c57e-16da-4cdc-9df9-29f8b134f6ef', N'API_TV', N'Dịch vụ thủy văn 2', 20000, 9, N'9 tháng', N'645bda56-1ce5-41d5-9263-63c59fc1f78c', NULL, NULL, NULL, 1)
INSERT [dbo].[cms_API] ([APIId], [APICode], [Name], [Price], [Duration], [DurationText], [APITypeId], [Body], [Documentation], [DocumentationLink], [IsActive]) VALUES (N'31824248-7fed-40b1-9f8b-34afd1eae208', N'API_HAIVAN2', N'Dịch vụ hải văn 2', 300000, 1, N'1 tháng', N'e28eafa0-7b81-4dd3-b027-1e6bdef80b07', N'', N'', N'', 0)
INSERT [dbo].[cms_API] ([APIId], [APICode], [Name], [Price], [Duration], [DurationText], [APITypeId], [Body], [Documentation], [DocumentationLink], [IsActive]) VALUES (N'c952d40d-7379-4391-9023-6fd6b7cfb78d', N'API_HAIVAN3', N'Dịch vụ hải văn 3', 500000, 24, N'24 tháng', N'e28eafa0-7b81-4dd3-b027-1e6bdef80b07', NULL, NULL, NULL, 1)
INSERT [dbo].[cms_API] ([APIId], [APICode], [Name], [Price], [Duration], [DurationText], [APITypeId], [Body], [Documentation], [DocumentationLink], [IsActive]) VALUES (N'3de76a52-33c4-401b-bf44-7762d709bebd', N'API_TV', N'Dịch vụ thủy văn 1', 40000, 5, N'5 tháng', N'645bda56-1ce5-41d5-9263-63c59fc1f78c', NULL, NULL, NULL, 1)
INSERT [dbo].[cms_API] ([APIId], [APICode], [Name], [Price], [Duration], [DurationText], [APITypeId], [Body], [Documentation], [DocumentationLink], [IsActive]) VALUES (N'839173e4-9ea1-4b4c-bfb3-7b1ca3f6a9f5', N'API_NCKH3', N'Dịch vụ nghiên cứu khoa học 3', 5000000, 1, N'1 tháng', N'356c8364-a4b3-4fc7-bed3-d59fd81fa780', NULL, NULL, NULL, 1)
INSERT [dbo].[cms_API] ([APIId], [APICode], [Name], [Price], [Duration], [DurationText], [APITypeId], [Body], [Documentation], [DocumentationLink], [IsActive]) VALUES (N'b51cf342-4a1d-4fd9-a61f-856bf3ba4337', N'API_TVDB2', N'Dịch vụ thủy văn đặc biệt 2', 540000, 6, N'6 tháng', N'011ecdf1-d695-4e3c-a5c9-1fcb6afe70f5', N'', N'', N'', 0)
INSERT [dbo].[cms_API] ([APIId], [APICode], [Name], [Price], [Duration], [DurationText], [APITypeId], [Body], [Documentation], [DocumentationLink], [IsActive]) VALUES (N'61ee3d06-7b0f-49f4-8529-868424f8308d', N'API_TVDB3', N'Dịch vụ thủy văn đặc biệt 3', 34000, 7, N'7 tháng', N'011ecdf1-d695-4e3c-a5c9-1fcb6afe70f5', NULL, NULL, NULL, 1)
INSERT [dbo].[cms_API] ([APIId], [APICode], [Name], [Price], [Duration], [DurationText], [APITypeId], [Body], [Documentation], [DocumentationLink], [IsActive]) VALUES (N'1d8ac7aa-94de-41cb-9a95-b22cb2c6907a', N'API_PBKT1', N'Dịch vụ phổ biến kiến thức 1', 100000, 2, N'2 tháng', N'b79776dd-5480-4ed0-8268-f1e595b4a6d3', N'<p>return &quot;Hello World!&quot;;</p>
', N'<p>Kh&ocirc;ng c&oacute; HDSD</p>
', N'https://www.google.com.vn/', 1)
INSERT [dbo].[cms_API] ([APIId], [APICode], [Name], [Price], [Duration], [DurationText], [APITypeId], [Body], [Documentation], [DocumentationLink], [IsActive]) VALUES (N'73c6fead-d099-48dc-aecf-b6fadedb89b6', N'API_HAIVAN1', N'Dịch vụ hải văn 1', 20000, 8, N'8 tháng', N'e28eafa0-7b81-4dd3-b027-1e6bdef80b07', N'', N'', N'', 1)
INSERT [dbo].[cms_API] ([APIId], [APICode], [Name], [Price], [Duration], [DurationText], [APITypeId], [Body], [Documentation], [DocumentationLink], [IsActive]) VALUES (N'5b314684-0f2a-4351-986c-c749ac43163a', N'API_PBKT3', N'Dịch vụ phổ biến kiến thức 3', 300000, 5, N'5 tháng', N'b79776dd-5480-4ed0-8268-f1e595b4a6d3', NULL, NULL, NULL, 1)
INSERT [dbo].[cms_API] ([APIId], [APICode], [Name], [Price], [Duration], [DurationText], [APITypeId], [Body], [Documentation], [DocumentationLink], [IsActive]) VALUES (N'f0c67be3-31fb-4369-b8e6-d941fc08d701', N'API_TV', N'Dịch vụ thủy văn 3', 50000, 2, N'2 tháng', N'645bda56-1ce5-41d5-9263-63c59fc1f78c', NULL, NULL, NULL, 1)
INSERT [dbo].[cms_API] ([APIId], [APICode], [Name], [Price], [Duration], [DurationText], [APITypeId], [Body], [Documentation], [DocumentationLink], [IsActive]) VALUES (N'716860aa-0ff4-46c0-82f4-eb216aaf36a8', N'API_NCKH2', N'Dịch vụ nghiên cứu khoa học 2', 57851, 4, N'4 tháng', N'356c8364-a4b3-4fc7-bed3-d59fd81fa780', NULL, NULL, NULL, 1)
INSERT [dbo].[cms_API] ([APIId], [APICode], [Name], [Price], [Duration], [DurationText], [APITypeId], [Body], [Documentation], [DocumentationLink], [IsActive]) VALUES (N'35ad8cbf-955b-49e3-ae40-ed539be56771', N'API_TVDB1', N'Dịch vụ thủy văn đặc biệt 1', 111231, 12, N'12 tháng', N'011ecdf1-d695-4e3c-a5c9-1fcb6afe70f5', N'', N'', N'', 0)
INSERT [dbo].[cms_API] ([APIId], [APICode], [Name], [Price], [Duration], [DurationText], [APITypeId], [Body], [Documentation], [DocumentationLink], [IsActive]) VALUES (N'2a0706e5-580a-4051-8497-f25e8270e542', N'API_PBKT2', N'Dịch vụ phổ biến kiến thức 2', 200000, 3, N'3 tháng', N'b79776dd-5480-4ed0-8268-f1e595b4a6d3', NULL, NULL, NULL, 1)
INSERT [dbo].[cms_API_Membership_Relationship] ([Id], [APIId], [UserId], [FromDate], [ToDate], [TotalPrice], [AccessToken], [AccessCode], [IsActive], [Disabled]) VALUES (N'386f20fe-db77-4a99-9849-24c33510a701', N'73c6fead-d099-48dc-aecf-b6fadedb89b6', N'2d1c8a15-5d02-421a-9c05-e1173b658b2f', CAST(N'2019-07-14' AS Date), CAST(N'2020-03-14' AS Date), NULL, N'7dd90716-9461-4bad-ad70-bfc960d747f0', N'802763', 1, 0)
INSERT [dbo].[cms_API_Membership_Relationship] ([Id], [APIId], [UserId], [FromDate], [ToDate], [TotalPrice], [AccessToken], [AccessCode], [IsActive], [Disabled]) VALUES (N'827fdfb4-3204-406d-9bc8-2ff691db1116', N'1d8ac7aa-94de-41cb-9a95-b22cb2c6907a', N'2d1c8a15-5d02-421a-9c05-e1173b658b2f', CAST(N'2019-07-14' AS Date), CAST(N'2019-09-14' AS Date), NULL, N'481a7ad1-713f-43e4-82b7-71a78f769de7', N'576940', 1, 0)
INSERT [dbo].[cms_API_Membership_Relationship] ([Id], [APIId], [UserId], [FromDate], [ToDate], [TotalPrice], [AccessToken], [AccessCode], [IsActive], [Disabled]) VALUES (N'828d929d-424f-4dc6-bbb2-7d59dc8aae58', N'61ee3d06-7b0f-49f4-8529-868424f8308d', N'2d1c8a15-5d02-421a-9c05-e1173b658b2f', CAST(N'2019-07-14' AS Date), CAST(N'2020-02-14' AS Date), NULL, N'0a9fc9ac-2834-483b-92b6-14fe5e61d625', N'329435', 1, 0)
INSERT [dbo].[cms_API_Membership_Relationship] ([Id], [APIId], [UserId], [FromDate], [ToDate], [TotalPrice], [AccessToken], [AccessCode], [IsActive], [Disabled]) VALUES (N'd61c8e90-e77d-439b-8681-c4ff56d52f67', N'c952d40d-7379-4391-9023-6fd6b7cfb78d', N'2d1c8a15-5d02-421a-9c05-e1173b658b2f', CAST(N'2019-07-14' AS Date), CAST(N'2021-07-14' AS Date), NULL, N'7dc03b24-ff7f-4bf7-9cb0-c818facc3a9f', N'915778', 1, 0)
INSERT [dbo].[cms_APIType] ([APITypeId], [Name], [TypeOrder]) VALUES (N'e28eafa0-7b81-4dd3-b027-1e6bdef80b07', N'Hải văn', 2)
INSERT [dbo].[cms_APIType] ([APITypeId], [Name], [TypeOrder]) VALUES (N'011ecdf1-d695-4e3c-a5c9-1fcb6afe70f5', N'Thủy văn đặc biệt', 3)
INSERT [dbo].[cms_APIType] ([APITypeId], [Name], [TypeOrder]) VALUES (N'645bda56-1ce5-41d5-9263-63c59fc1f78c', N'Thủy văn', 1)
INSERT [dbo].[cms_APIType] ([APITypeId], [Name], [TypeOrder]) VALUES (N'a41a5fde-7bbb-4111-8b9a-cf661c0f5aaf', N'Hỏi đáp về KTTV', 5)
INSERT [dbo].[cms_APIType] ([APITypeId], [Name], [TypeOrder]) VALUES (N'356c8364-a4b3-4fc7-bed3-d59fd81fa780', N'Nghiên cứu KH', 6)
INSERT [dbo].[cms_APIType] ([APITypeId], [Name], [TypeOrder]) VALUES (N'b79776dd-5480-4ed0-8268-f1e595b4a6d3', N'Phổ biến kiến thức', 4)
INSERT [dbo].[cms_NewsCategory] ([NewsCategoryId], [Name], [Description], [Type], [Order]) VALUES (N'b4fcf238-211a-4164-9d69-1e26e94fe133', N'Nghiên cứu KH', N'nghien-cuu-kh', N'TT', 6)
INSERT [dbo].[cms_NewsCategory] ([NewsCategoryId], [Name], [Description], [Type], [Order]) VALUES (N'398507b5-7f43-45ff-9f6e-26ccdcbe29cf', N'Hải văn', N'hai-van', N'TT', 2)
INSERT [dbo].[cms_NewsCategory] ([NewsCategoryId], [Name], [Description], [Type], [Order]) VALUES (N'9d827d93-f23e-45b9-ab8b-67d1d5742ed8', N'Thủy văn đặc biệt', N'thuy-van-dac-biet', N'TT', 3)
INSERT [dbo].[cms_NewsCategory] ([NewsCategoryId], [Name], [Description], [Type], [Order]) VALUES (N'e8330774-2c71-470b-b080-82e2604fcba6', N'Thủy văn', N'thuy-van', N'TT', 1)
INSERT [dbo].[cms_NewsCategory] ([NewsCategoryId], [Name], [Description], [Type], [Order]) VALUES (N'c2d494c3-2086-42e5-87b3-854a5d42c129', N'Hỏi đáp về KTTV', N'hoi-dap-ve-kttv', N'TT', 5)
INSERT [dbo].[cms_NewsCategory] ([NewsCategoryId], [Name], [Description], [Type], [Order]) VALUES (N'3af42b3e-5e0c-4f30-bdce-9b020ee4b0c3', N'Tin thời tiết', N'thoi-tiet', N'CM', NULL)
INSERT [dbo].[cms_NewsCategory] ([NewsCategoryId], [Name], [Description], [Type], [Order]) VALUES (N'5e0e0a99-8757-4e2b-b3d2-aa26c7fcdcdd', N'Phổ biến kiến thức', N'pho-bien-kien-thuc', N'TT', 4)
INSERT [dbo].[cms_NewsCategory] ([NewsCategoryId], [Name], [Description], [Type], [Order]) VALUES (N'dac7f4bf-b0c0-4003-bde0-d5eeea71ba03', N'Tin nội bộ', N'noi-bo', N'CM', NULL)
INSERT [dbo].[cms_NewsCategory] ([NewsCategoryId], [Name], [Description], [Type], [Order]) VALUES (N'328e5dbf-966a-4fbd-8642-e5a6f2be6033', N'Tin Xã hội', N'xa-hoi', N'CM', NULL)
INSERT [dbo].[cms_UserTransaction] ([BillId], [UserId], [TotalPrice], [CreatedOnDate], [Paid], [PaidOnDate]) VALUES (N'6dcdcfe7-1f35-496c-91e9-1c07f1f948e6', N'2d1c8a15-5d02-421a-9c05-e1173b658b2f', 520000, CAST(N'2019-07-14T18:01:51.5735301' AS DateTime2), 1, CAST(N'2019-07-14T18:01:51.5735301' AS DateTime2))
INSERT [dbo].[cms_UserTransaction] ([BillId], [UserId], [TotalPrice], [CreatedOnDate], [Paid], [PaidOnDate]) VALUES (N'deac7f53-b29f-4769-8ca9-3472d787e68c', N'2d1c8a15-5d02-421a-9c05-e1173b658b2f', 34000, CAST(N'2019-07-14T21:16:15.7132158' AS DateTime2), 1, CAST(N'2019-07-14T21:16:15.7132158' AS DateTime2))
INSERT [dbo].[cms_UserTransaction] ([BillId], [UserId], [TotalPrice], [CreatedOnDate], [Paid], [PaidOnDate]) VALUES (N'34688bc5-02d2-4816-9110-7c988cbbd4c5', N'2d1c8a15-5d02-421a-9c05-e1173b658b2f', 100000, CAST(N'2019-07-14T21:14:59.0189091' AS DateTime2), 1, CAST(N'2019-07-14T21:14:59.0189091' AS DateTime2))
INSERT [dbo].[cms_UserTransaction_API] ([Id], [BillId], [APIId], [FromDate], [ToDate], [Price]) VALUES (N'c4bba309-ffec-4ce9-8330-30b02da171b1', N'6dcdcfe7-1f35-496c-91e9-1c07f1f948e6', N'73c6fead-d099-48dc-aecf-b6fadedb89b6', CAST(N'2019-07-14T18:01:51.5735301' AS DateTime2), CAST(N'2020-03-14T18:01:51.5735301' AS DateTime2), 0)
INSERT [dbo].[cms_UserTransaction_API] ([Id], [BillId], [APIId], [FromDate], [ToDate], [Price]) VALUES (N'c60b84c3-f6ed-4e8e-b973-48ede1af2cd9', N'deac7f53-b29f-4769-8ca9-3472d787e68c', N'61ee3d06-7b0f-49f4-8529-868424f8308d', CAST(N'2019-07-14T21:16:15.7132158' AS DateTime2), CAST(N'2020-02-14T21:16:15.7132158' AS DateTime2), 0)
INSERT [dbo].[cms_UserTransaction_API] ([Id], [BillId], [APIId], [FromDate], [ToDate], [Price]) VALUES (N'82d60989-4edc-42d0-becd-a6a72273c2c1', N'34688bc5-02d2-4816-9110-7c988cbbd4c5', N'1d8ac7aa-94de-41cb-9a95-b22cb2c6907a', CAST(N'2019-07-14T21:14:59.0189091' AS DateTime2), CAST(N'2019-09-14T21:14:59.0189091' AS DateTime2), 0)
INSERT [dbo].[cms_UserTransaction_API] ([Id], [BillId], [APIId], [FromDate], [ToDate], [Price]) VALUES (N'1c2c3ef7-78eb-4df7-b418-fdac372a3e96', N'6dcdcfe7-1f35-496c-91e9-1c07f1f948e6', N'c952d40d-7379-4391-9023-6fd6b7cfb78d', CAST(N'2019-07-14T18:01:51.5735301' AS DateTime2), CAST(N'2021-07-14T18:01:51.5735301' AS DateTime2), 0)
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_aspnet_Membership]    Script Date: 7/26/2019 1:25:14 AM ******/
ALTER TABLE [dbo].[aspnet_Membership] ADD  CONSTRAINT [IX_aspnet_Membership] UNIQUE NONCLUSTERED 
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_aspnet_Users]    Script Date: 7/26/2019 1:25:14 AM ******/
ALTER TABLE [dbo].[aspnet_Users] ADD  CONSTRAINT [IX_aspnet_Users] UNIQUE NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[aspnet_Users] ADD  CONSTRAINT [DF_aspnet_Users_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[cms_API] ADD  CONSTRAINT [DF_cms_API_APIId]  DEFAULT (newid()) FOR [APIId]
GO
ALTER TABLE [dbo].[cms_API] ADD  CONSTRAINT [DF_cms_API_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[cms_API_Membership_Relationship] ADD  CONSTRAINT [DF_cms_API_Membership_Relationship_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[cms_UserTransaction] ADD  CONSTRAINT [DF_cms_Bill_Paid]  DEFAULT ((0)) FOR [Paid]
GO
ALTER TABLE [dbo].[aspnet_Membership]  WITH CHECK ADD  CONSTRAINT [FK_aspnet_Membership_aspnet_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[aspnet_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[aspnet_Membership] CHECK CONSTRAINT [FK_aspnet_Membership_aspnet_Roles]
GO
ALTER TABLE [dbo].[aspnet_Roles_Rights_Relationship]  WITH CHECK ADD  CONSTRAINT [FK_aspnet_Roles_Rights_Relationship_aspnet_Rights] FOREIGN KEY([RightId])
REFERENCES [dbo].[aspnet_Rights] ([RightId])
GO
ALTER TABLE [dbo].[aspnet_Roles_Rights_Relationship] CHECK CONSTRAINT [FK_aspnet_Roles_Rights_Relationship_aspnet_Rights]
GO
ALTER TABLE [dbo].[aspnet_Roles_Rights_Relationship]  WITH CHECK ADD  CONSTRAINT [FK_aspnet_Roles_Rights_Relationship_aspnet_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[aspnet_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[aspnet_Roles_Rights_Relationship] CHECK CONSTRAINT [FK_aspnet_Roles_Rights_Relationship_aspnet_Roles]
GO
ALTER TABLE [dbo].[cms_API]  WITH CHECK ADD  CONSTRAINT [FK_cms_API_cms_APIType] FOREIGN KEY([APITypeId])
REFERENCES [dbo].[cms_APIType] ([APITypeId])
GO
ALTER TABLE [dbo].[cms_API] CHECK CONSTRAINT [FK_cms_API_cms_APIType]
GO
ALTER TABLE [dbo].[cms_API_Membership_Relationship]  WITH CHECK ADD  CONSTRAINT [FK_cms_API_Membership_Relationship_aspnet_Membership] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Membership] ([UserId])
GO
ALTER TABLE [dbo].[cms_API_Membership_Relationship] CHECK CONSTRAINT [FK_cms_API_Membership_Relationship_aspnet_Membership]
GO
ALTER TABLE [dbo].[cms_API_Membership_Relationship]  WITH CHECK ADD  CONSTRAINT [FK_cms_API_Membership_Relationship_cms_API] FOREIGN KEY([APIId])
REFERENCES [dbo].[cms_API] ([APIId])
GO
ALTER TABLE [dbo].[cms_API_Membership_Relationship] CHECK CONSTRAINT [FK_cms_API_Membership_Relationship_cms_API]
GO
ALTER TABLE [dbo].[cms_News]  WITH CHECK ADD  CONSTRAINT [FK_cms_News_aspnet_Membership] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[aspnet_Membership] ([UserId])
GO
ALTER TABLE [dbo].[cms_News] CHECK CONSTRAINT [FK_cms_News_aspnet_Membership]
GO
ALTER TABLE [dbo].[cms_News]  WITH CHECK ADD  CONSTRAINT [FK_cms_News_cms_NewsCategory] FOREIGN KEY([NewsCategory])
REFERENCES [dbo].[cms_NewsCategory] ([NewsCategoryId])
GO
ALTER TABLE [dbo].[cms_News] CHECK CONSTRAINT [FK_cms_News_cms_NewsCategory]
GO
ALTER TABLE [dbo].[cms_UserTransaction]  WITH CHECK ADD  CONSTRAINT [FK_cms_UserTransaction_aspnet_Membership] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Membership] ([UserId])
GO
ALTER TABLE [dbo].[cms_UserTransaction] CHECK CONSTRAINT [FK_cms_UserTransaction_aspnet_Membership]
GO
ALTER TABLE [dbo].[cms_UserTransaction_API]  WITH CHECK ADD  CONSTRAINT [FK_cms_UserTransaction_API_cms_API] FOREIGN KEY([APIId])
REFERENCES [dbo].[cms_API] ([APIId])
GO
ALTER TABLE [dbo].[cms_UserTransaction_API] CHECK CONSTRAINT [FK_cms_UserTransaction_API_cms_API]
GO
ALTER TABLE [dbo].[cms_UserTransaction_API]  WITH CHECK ADD  CONSTRAINT [FK_cms_UserTransaction_API_cms_UserTransaction] FOREIGN KEY([BillId])
REFERENCES [dbo].[cms_UserTransaction] ([BillId])
GO
ALTER TABLE [dbo].[cms_UserTransaction_API] CHECK CONSTRAINT [FK_cms_UserTransaction_API_cms_UserTransaction]
GO
USE [master]
GO
ALTER DATABASE [cms_VKTTV] SET  READ_WRITE 
GO
