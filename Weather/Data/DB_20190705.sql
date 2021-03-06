USE [master]
GO
/****** Object:  Database [cms_VKTTV]    Script Date: 7/5/2019 5:07:40 AM ******/
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
/****** Object:  Table [dbo].[aspnet_Membership]    Script Date: 7/5/2019 5:07:41 AM ******/
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
 CONSTRAINT [PK__aspnet_M__1788CC4C70E5A222] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Rights]    Script Date: 7/5/2019 5:07:41 AM ******/
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
/****** Object:  Table [dbo].[aspnet_Roles]    Script Date: 7/5/2019 5:07:41 AM ******/
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
/****** Object:  Table [dbo].[aspnet_Roles_Rights_Relationship]    Script Date: 7/5/2019 5:07:41 AM ******/
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
/****** Object:  Table [dbo].[aspnet_Users]    Script Date: 7/5/2019 5:07:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[Username] [varchar](128) NOT NULL,
	[SimpleAuth] [uniqueidentifier] NULL,
 CONSTRAINT [PK__aspnet_U__1788CC4C0C2AB95A] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cms_News]    Script Date: 7/5/2019 5:07:41 AM ******/
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
	[Thumbnail] [image] NULL,
 CONSTRAINT [PK__cms_News__954EBDF31DD35339] PRIMARY KEY CLUSTERED 
(
	[NewsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cms_NewsCategory]    Script Date: 7/5/2019 5:07:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_NewsCategory](
	[NewsCategoryId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[NewsCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[aspnet_Membership] ([UserId], [Password], [PasswordSalt], [FullName], [ShortName], [NickName], [RoleId]) VALUES (N'eced007d-e9ef-4b19-8c83-070fe84720df', N'd052b3f47633c6746d50cbf52a3a04533ba430279a1e03a8e6bb1be1b5bb71b3', N'5ZRnzQ5r1Ys7upPrvfkLLn5C0Vfb+cTpnm4HrSdszSg=', NULL, NULL, NULL, N'cc3def5c-c6e2-47be-bf38-09c1c8f6b341')
INSERT [dbo].[aspnet_Membership] ([UserId], [Password], [PasswordSalt], [FullName], [ShortName], [NickName], [RoleId]) VALUES (N'691b8a4c-2e62-42c9-a796-6267559e53ad', N'60145b511516f951a5d7de79d410e03f6ba19992c4b51cbe17aa7082156c66e0', N'gglbiTJnhL5sp3DN6Atr7pA4zBKWFGT8wkZLKrtHPls=', N'Nguyễn Quang Huy', N'Q/Huy', NULL, N'cc3def5c-c6e2-47be-bf38-09c1c8f6b341')
INSERT [dbo].[aspnet_Membership] ([UserId], [Password], [PasswordSalt], [FullName], [ShortName], [NickName], [RoleId]) VALUES (N'9ace3dc3-8710-4028-b434-7ed0211f4dec', N'6f918310fbfe0d3aaa8a55f0381e7b9bd3b83ff4f68c53c7629dba98dc20193e', N'8yrq28347yoidfuhao78yfaoahsdigy78', N'Quản trị hệ thống', N'Admin', N'Admin', N'4819f98f-18c0-4778-959d-9dc4625664cf')
INSERT [dbo].[aspnet_Membership] ([UserId], [Password], [PasswordSalt], [FullName], [ShortName], [NickName], [RoleId]) VALUES (N'b6372d6a-a331-4c5d-bf4f-a84cf05a9c05', N'b2b8551aec77927a0f0269b63cfd780f271ae2fb221a0562588d048dbeeb3e90', N'awieoruoijkl7s6f8783sdef09', N'Dang Duc Trung', N'Trung Dang', N'TrungDD', N'cc3def5c-c6e2-47be-bf38-09c1c8f6b341')
INSERT [dbo].[aspnet_Rights] ([RightId], [Name], [Description]) VALUES (N'b9c5aea9-19eb-4861-8eeb-b08fbc42e082', N'Duyệt tin', N'Duyet tin')
INSERT [dbo].[aspnet_Rights] ([RightId], [Name], [Description]) VALUES (N'ee01b3eb-4856-4808-ad65-c0c57074e038', N'Viết tin bài', N'Viet tin')
INSERT [dbo].[aspnet_Rights] ([RightId], [Name], [Description]) VALUES (N'eba4b6cd-9cff-44b5-b066-e824c5e55207', N'Tạo tài khoản', N'Tao TK')
INSERT [dbo].[aspnet_Roles] ([RoleId], [Name], [Description]) VALUES (N'cc3def5c-c6e2-47be-bf38-09c1c8f6b341', N'Người viết tin bài', N'VietTB')
INSERT [dbo].[aspnet_Roles] ([RoleId], [Name], [Description]) VALUES (N'4819f98f-18c0-4778-959d-9dc4625664cf', N'Quản trị hệ thống', N'QTHT')
INSERT [dbo].[aspnet_Roles_Rights_Relationship] ([Id], [RoleId], [RightId]) VALUES (N'6e63201d-899a-46be-9a18-06d58c45d6de', N'4819f98f-18c0-4778-959d-9dc4625664cf', N'b9c5aea9-19eb-4861-8eeb-b08fbc42e082')
INSERT [dbo].[aspnet_Roles_Rights_Relationship] ([Id], [RoleId], [RightId]) VALUES (N'ef67f5c6-ed9c-4965-ada0-4548a8fe4948', N'4819f98f-18c0-4778-959d-9dc4625664cf', N'ee01b3eb-4856-4808-ad65-c0c57074e038')
INSERT [dbo].[aspnet_Roles_Rights_Relationship] ([Id], [RoleId], [RightId]) VALUES (N'b3625525-4689-44ed-8412-5440cc51010b', N'4819f98f-18c0-4778-959d-9dc4625664cf', N'eba4b6cd-9cff-44b5-b066-e824c5e55207')
INSERT [dbo].[aspnet_Roles_Rights_Relationship] ([Id], [RoleId], [RightId]) VALUES (N'77b98e97-61a0-4249-be60-9376d9bd3370', N'cc3def5c-c6e2-47be-bf38-09c1c8f6b341', N'ee01b3eb-4856-4808-ad65-c0c57074e038')
INSERT [dbo].[aspnet_Users] ([UserId], [Username], [SimpleAuth]) VALUES (N'eced007d-e9ef-4b19-8c83-070fe84720df', N'sonha', N'cd9a545d-9682-4ba7-849d-3ba34690191d')
INSERT [dbo].[aspnet_Users] ([UserId], [Username], [SimpleAuth]) VALUES (N'691b8a4c-2e62-42c9-a796-6267559e53ad', N'nguyenhuy', N'ca3fe180-b0da-4dae-9715-f1864989079b')
INSERT [dbo].[aspnet_Users] ([UserId], [Username], [SimpleAuth]) VALUES (N'9ace3dc3-8710-4028-b434-7ed0211f4dec', N'admin', N'4fd0b112-dae6-4cd1-b1ff-a1d6725b44f6')
INSERT [dbo].[aspnet_Users] ([UserId], [Username], [SimpleAuth]) VALUES (N'b6372d6a-a331-4c5d-bf4f-a84cf05a9c05', N'trungdd', N'a93c7cf1-f20f-4367-ae18-93e7308278d2')
INSERT [dbo].[aspnet_Users] ([UserId], [Username], [SimpleAuth]) VALUES (N'7e4cf790-08db-4e89-91de-ae106c4dd5cf', N'nguyenhuy', NULL)
INSERT [dbo].[cms_News] ([NewsId], [NewsCategory], [Name], [Location], [FinishedDate], [WriterId], [WriterName], [Introduction], [Body], [ApprovedStatus], [CreatedByUserId], [CreatedOnDate], [Thumbnail]) VALUES (N'aeb98fea-503d-4a81-a88e-84cb1771fd91', N'3af42b3e-5e0c-4f30-bdce-9b020ee4b0c3', N'1234', N'1234', NULL, NULL, N'Admin', N'1234', NULL, 0, N'9ace3dc3-8710-4028-b434-7ed0211f4dec', CAST(N'2019-07-05T01:34:22.1962850' AS DateTime2), NULL)
INSERT [dbo].[cms_News] ([NewsId], [NewsCategory], [Name], [Location], [FinishedDate], [WriterId], [WriterName], [Introduction], [Body], [ApprovedStatus], [CreatedByUserId], [CreatedOnDate], [Thumbnail]) VALUES (N'5141540f-f961-4c21-9e0d-93ba050b9555', N'3af42b3e-5e0c-4f30-bdce-9b020ee4b0c3', N'GOGOG', N'GOGOG', NULL, NULL, N'Trung Dang', N'GOGOG', NULL, 0, N'b6372d6a-a331-4c5d-bf4f-a84cf05a9c05', CAST(N'2019-07-04T19:25:07.5544250' AS DateTime2), NULL)
INSERT [dbo].[cms_News] ([NewsId], [NewsCategory], [Name], [Location], [FinishedDate], [WriterId], [WriterName], [Introduction], [Body], [ApprovedStatus], [CreatedByUserId], [CreatedOnDate], [Thumbnail]) VALUES (N'cbeb45c8-eae9-4ae7-8ddd-a929235d359c', N'dac7f4bf-b0c0-4003-bde0-d5eeea71ba03', N'123', N'Ha Noi', NULL, NULL, N'Trung Dang', N'Ha Noi mua lon da gay ra tinh trang ngap lut tren nhieu noi', N'OK', 0, N'b6372d6a-a331-4c5d-bf4f-a84cf05a9c05', CAST(N'2019-07-04T17:58:24.1734429' AS DateTime2), NULL)
INSERT [dbo].[cms_News] ([NewsId], [NewsCategory], [Name], [Location], [FinishedDate], [WriterId], [WriterName], [Introduction], [Body], [ApprovedStatus], [CreatedByUserId], [CreatedOnDate], [Thumbnail]) VALUES (N'c1997c04-6e0b-4a45-a4c7-af182c5c909d', N'3af42b3e-5e0c-4f30-bdce-9b020ee4b0c3', N'Hom nay Ha noi mua lon', N'Ha Noi', NULL, NULL, N'Dang Duc Trung', N'Ha Noi mua lon da gay ra tinh trang ngap lut tren nhieu noi. Tiep theo la dmmy text de kiem tra overflow. Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Ha Noi mua lon da gay ra tinh trang ngap lut tren nhieu noi. Tiep theo la dmmy text de kiem tra overflow. Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Ha Noi mua lon da gay ra tinh trang ngap lut tren nhieu noi. Tiep theo la dmmy text de kiem tra overflow. Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsumHa Noi mua lon da gay ra tinh trang ngap lut tren nhieu noi. Tiep theo la dmmy text de kiem tra overflow. Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum  ', N'Day la noi dung kiem thu', 0, N'b6372d6a-a331-4c5d-bf4f-a84cf05a9c05', CAST(N'2019-07-04T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[cms_News] ([NewsId], [NewsCategory], [Name], [Location], [FinishedDate], [WriterId], [WriterName], [Introduction], [Body], [ApprovedStatus], [CreatedByUserId], [CreatedOnDate], [Thumbnail]) VALUES (N'bab67874-a034-4549-a649-f8e6f580527b', N'328e5dbf-966a-4fbd-8642-e5a6f2be6033', N'Quốc hội ban hành các quyết định mới', N'Hà Nội', NULL, NULL, N'Q/Huy', N'Quốc hội ban hành các quyết định mới', NULL, 0, N'691b8a4c-2e62-42c9-a796-6267559e53ad', CAST(N'2019-07-05T03:37:17.7576207' AS DateTime2), NULL)
INSERT [dbo].[cms_NewsCategory] ([NewsCategoryId], [Name], [Description]) VALUES (N'3af42b3e-5e0c-4f30-bdce-9b020ee4b0c3', N'Tin thời tiết', NULL)
INSERT [dbo].[cms_NewsCategory] ([NewsCategoryId], [Name], [Description]) VALUES (N'dac7f4bf-b0c0-4003-bde0-d5eeea71ba03', N'Tin nội bộ', NULL)
INSERT [dbo].[cms_NewsCategory] ([NewsCategoryId], [Name], [Description]) VALUES (N'328e5dbf-966a-4fbd-8642-e5a6f2be6033', N'Tin Xã hội', NULL)
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
USE [master]
GO
ALTER DATABASE [cms_VKTTV] SET  READ_WRITE 
GO
