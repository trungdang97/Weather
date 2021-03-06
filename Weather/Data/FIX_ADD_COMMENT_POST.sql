USE [cms_VKTTV]
GO
/****** Object:  Table [dbo].[cms_Comment]    Script Date: 8/9/2019 2:24:27 AM ******/
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
	[UserId] [uniqueidentifier] NULL,
	[IsApproved] [bit] NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Email] [varchar](max) NOT NULL,
	[CommentParentId] [uniqueidentifier] NULL,
	[Type] [varchar](max) NOT NULL,
	[ThreadId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_cms_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cms_Post]    Script Date: 8/9/2019 2:24:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_Post](
	[PostId] [uniqueidentifier] NOT NULL,
	[PostCategoryId] [uniqueidentifier] NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[CreatedOnDate] [datetime2](7) NOT NULL,
	[LastUpdatedOnDate] [datetime2](7) NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[IsApproved] [bit] NOT NULL,
 CONSTRAINT [PK_cms_Post] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cms_PostCategory]    Script Date: 8/9/2019 2:24:27 AM ******/
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
ALTER TABLE [dbo].[cms_Post] ADD  CONSTRAINT [DF_cms_Post_PostId]  DEFAULT (newid()) FOR [PostId]
GO
ALTER TABLE [dbo].[cms_Post] ADD  CONSTRAINT [DF_cms_Post_IsApproved]  DEFAULT ((1)) FOR [IsApproved]
GO
ALTER TABLE [dbo].[cms_Comment]  WITH CHECK ADD  CONSTRAINT [FK_cms_Comment_cms_Comment] FOREIGN KEY([CommentParentId])
REFERENCES [dbo].[cms_Comment] ([CommentId])
GO
ALTER TABLE [dbo].[cms_Comment] CHECK CONSTRAINT [FK_cms_Comment_cms_Comment]
GO
