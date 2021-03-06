USE [cms_VKTTV]
GO
/****** Object:  Table [dbo].[cms_Comment]    Script Date: 8/6/2019 11:02:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_Comment](
	[CommentId] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[CreatedOnDate] [datetime2](7) NOT NULL,
	[LastUpdatedOnDate] [datetime2](7) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[IsApproved] [bit] NOT NULL,
 CONSTRAINT [PK_cms_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cms_Comment_Relationships]    Script Date: 8/6/2019 11:02:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_Comment_Relationships](
	[Id] [uniqueidentifier] NOT NULL,
	[CommentId] [uniqueidentifier] NOT NULL,
	[ObjectId] [uniqueidentifier] NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_cms_Comment_Relationships] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cms_Post]    Script Date: 8/6/2019 11:02:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_Post](
	[PostId] [uniqueidentifier] NOT NULL,
	[PostCategoryId] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[CreatedOnDate] [datetime2](7) NOT NULL,
	[LastUpdatedOnDate] [datetime2](7) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[IsApproved] [bit] NOT NULL,
 CONSTRAINT [PK_cms_Post] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cms_PostCategory]    Script Date: 8/6/2019 11:02:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_PostCategory](
	[PostCategoryId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_cms_PostCategory] PRIMARY KEY CLUSTERED 
(
	[PostCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[cms_Comment] ADD  CONSTRAINT [DF_cms_Comment_CommentId]  DEFAULT (newid()) FOR [CommentId]
GO
ALTER TABLE [dbo].[cms_Comment] ADD  CONSTRAINT [DF_cms_Comment_IsApproved]  DEFAULT ((1)) FOR [IsApproved]
GO
ALTER TABLE [dbo].[cms_Comment_Relationships] ADD  CONSTRAINT [DF_cms_Comment_Relationships_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[cms_Post] ADD  CONSTRAINT [DF_cms_Post_PostId]  DEFAULT (newid()) FOR [PostId]
GO
ALTER TABLE [dbo].[cms_Post] ADD  CONSTRAINT [DF_cms_Post_IsApproved]  DEFAULT ((1)) FOR [IsApproved]
GO
ALTER TABLE [dbo].[cms_Comment_Relationships]  WITH CHECK ADD  CONSTRAINT [FK_cms_Comment_Relationships_cms_Comment] FOREIGN KEY([CommentId])
REFERENCES [dbo].[cms_Comment] ([CommentId])
GO
ALTER TABLE [dbo].[cms_Comment_Relationships] CHECK CONSTRAINT [FK_cms_Comment_Relationships_cms_Comment]
GO
ALTER TABLE [dbo].[cms_Comment_Relationships]  WITH CHECK ADD  CONSTRAINT [FK_cms_Comment_Relationships_cms_News] FOREIGN KEY([ObjectId])
REFERENCES [dbo].[cms_News] ([NewsId])
GO
ALTER TABLE [dbo].[cms_Comment_Relationships] CHECK CONSTRAINT [FK_cms_Comment_Relationships_cms_News]
GO
ALTER TABLE [dbo].[cms_Comment_Relationships]  WITH CHECK ADD  CONSTRAINT [FK_cms_Comment_Relationships_cms_Post] FOREIGN KEY([ObjectId])
REFERENCES [dbo].[cms_Post] ([PostId])
GO
ALTER TABLE [dbo].[cms_Comment_Relationships] CHECK CONSTRAINT [FK_cms_Comment_Relationships_cms_Post]
GO
ALTER TABLE [dbo].[cms_Post]  WITH CHECK ADD  CONSTRAINT [FK_cms_Post_cms_PostCategory] FOREIGN KEY([PostCategoryId])
REFERENCES [dbo].[cms_PostCategory] ([PostCategoryId])
GO
ALTER TABLE [dbo].[cms_Post] CHECK CONSTRAINT [FK_cms_Post_cms_PostCategory]
GO
