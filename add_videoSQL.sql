USE [cms_VKTTV]
GO
/****** Object:  Table [dbo].[cms_Video]    Script Date: 9/30/2019 1:14:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_Video](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[FullPath] [nvarchar](max) NOT NULL,
	[CreatedOnDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_cms_Video] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[cms_Video] ([Id], [Name], [FullPath], [CreatedOnDate]) VALUES (N'dc272453-840a-42dd-8d30-38c6ab3630ce', N'Video động vật biển', N'avan.mp4', CAST(N'2019-09-16T18:16:29.0080000' AS DateTime2))
INSERT [dbo].[cms_Video] ([Id], [Name], [FullPath], [CreatedOnDate]) VALUES (N'329d94dd-e9f9-47ca-80a5-a6763450a7f8', N'Owl City - Fireflies', N'Owl City - Fireflies.mp4', CAST(N'2019-09-16T18:16:29.0080000' AS DateTime2))
ALTER TABLE [dbo].[cms_Video] ADD  CONSTRAINT [DF_cms_Video_Id]  DEFAULT (newid()) FOR [Id]
GO
