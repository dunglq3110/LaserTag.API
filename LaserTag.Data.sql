USE [laser_tag]
GO
/****** Object:  Table [dbo].[attribute]    Script Date: 9/23/2024 12:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attribute](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[description] [nvarchar](max) NULL,
	[code_name] [nvarchar](255) NOT NULL,
	[is_gun] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[config]    Script Date: 9/23/2024 12:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[config](
	[config_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[code_name] [nvarchar](255) NOT NULL,
	[config_type_id] [nvarchar](50) NOT NULL,
	[value1] [nvarchar](255) NULL,
	[value2] [nvarchar](255) NULL,
	[value3] [nvarchar](255) NULL,
	[value4] [nvarchar](255) NULL,
	[value5] [nvarchar](255) NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK__config__4AD1BFF19E8A3A61] PRIMARY KEY CLUSTERED 
(
	[config_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hit_log]    Script Date: 9/23/2024 12:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hit_log](
	[hit_log_id] [int] IDENTITY(1,1) NOT NULL,
	[source_player_id] [int] NOT NULL,
	[target_player_id] [int] NOT NULL,
	[round_id] [int] NOT NULL,
	[hit_type_id] [nvarchar](50) NOT NULL,
	[value] [int] NOT NULL,
 CONSTRAINT [PK__hit_log__DFA4E8DB8859B714] PRIMARY KEY CLUSTERED 
(
	[hit_log_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[match]    Script Date: 9/23/2024 12:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[match](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NOT NULL,
	[stage_id] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__match__3213E83FFF0EDC76] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[player]    Script Date: 9/23/2024 12:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[player](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[mac_gun] [nvarchar](255) NOT NULL,
	[mac_vest] [nvarchar](255) NOT NULL,
	[current_health] [int] NOT NULL,
	[current_bullet] [int] NOT NULL,
	[balance] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[player_attribute]    Script Date: 9/23/2024 12:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[player_attribute](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[player_id] [int] NOT NULL,
	[attribute_id] [int] NOT NULL,
	[value] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[player_match]    Script Date: 9/23/2024 12:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[player_match](
	[player_match_id] [int] IDENTITY(1,1) NOT NULL,
	[player_id] [int] NOT NULL,
	[match_id] [int] NOT NULL,
	[team_id] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__player_m__DA50FA83C03ABE10] PRIMARY KEY CLUSTERED 
(
	[player_match_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[player_upgrade]    Script Date: 9/23/2024 12:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[player_upgrade](
	[player_upgrade_id] [int] IDENTITY(1,1) NOT NULL,
	[player_match_id] [int] NOT NULL,
	[upgrade_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[player_upgrade_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[round]    Script Date: 9/23/2024 12:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[round](
	[round_id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NOT NULL,
	[round_stage_id] [nvarchar](50) NOT NULL,
	[match_id] [int] NOT NULL,
 CONSTRAINT [PK__round__295E52E37140C06E] PRIMARY KEY CLUSTERED 
(
	[round_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shared_base]    Script Date: 9/23/2024 12:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shared_base](
	[base_id] [nvarchar](50) NOT NULL,
	[group_id] [nvarchar](50) NOT NULL,
	[base_name1] [nvarchar](255) NOT NULL,
	[base_name2] [nvarchar](255) NULL,
	[base_name3] [nvarchar](255) NULL,
	[base_name4] [nvarchar](255) NULL,
	[base_name5] [nvarchar](255) NULL,
	[sort] [int] NOT NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK__shared_b__BA7F1F40CC9CB798] PRIMARY KEY CLUSTERED 
(
	[base_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shared_group]    Script Date: 9/23/2024 12:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shared_group](
	[group_id] [nvarchar](50) NOT NULL,
	[group_name1] [nvarchar](255) NOT NULL,
	[group_name2] [nvarchar](255) NULL,
	[group_name3] [nvarchar](255) NULL,
	[group_name4] [nvarchar](255) NULL,
	[group_name5] [nvarchar](255) NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK__shared_g__D57795A01B922B64] PRIMARY KEY CLUSTERED 
(
	[group_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shoot_log]    Script Date: 9/23/2024 12:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shoot_log](
	[shoot_log_id] [int] IDENTITY(1,1) NOT NULL,
	[player_id] [int] NOT NULL,
	[round_id] [int] NOT NULL,
	[date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[shoot_log_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[upgrade]    Script Date: 9/23/2024 12:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[upgrade](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[description] [nvarchar](max) NULL,
	[price] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[upgrade_attribute]    Script Date: 9/23/2024 12:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[upgrade_attribute](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[upgrade_id] [int] NOT NULL,
	[attribute_id] [int] NOT NULL,
	[value] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[attribute] ON 

INSERT [dbo].[attribute] ([id], [name], [description], [code_name], [is_gun]) VALUES (1, N'Damage Value', NULL, N'damage_value', 1)
INSERT [dbo].[attribute] ([id], [name], [description], [code_name], [is_gun]) VALUES (2, N'Max Bullet', NULL, N'bullet_max', 1)
INSERT [dbo].[attribute] ([id], [name], [description], [code_name], [is_gun]) VALUES (3, N'Fire level', NULL, N'fire_level', 1)
INSERT [dbo].[attribute] ([id], [name], [description], [code_name], [is_gun]) VALUES (4, N'Max Health', NULL, N'health_max', 0)
INSERT [dbo].[attribute] ([id], [name], [description], [code_name], [is_gun]) VALUES (5, N'Armor', NULL, N'armor_value', 0)
SET IDENTITY_INSERT [dbo].[attribute] OFF
GO
SET IDENTITY_INSERT [dbo].[config] ON 

INSERT [dbo].[config] ([config_id], [name], [code_name], [config_type_id], [value1], [value2], [value3], [value4], [value5], [description]) VALUES (1, N'Default Player Damage', N'damage_value', N'CONF01', N'10', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[config] ([config_id], [name], [code_name], [config_type_id], [value1], [value2], [value3], [value4], [value5], [description]) VALUES (2, N'Default Player Max Bullet', N'bullet_max', N'CONF01', N'10', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[config] ([config_id], [name], [code_name], [config_type_id], [value1], [value2], [value3], [value4], [value5], [description]) VALUES (3, N'Player Fire Level', N'fire_level', N'CONF01', N'0', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[config] ([config_id], [name], [code_name], [config_type_id], [value1], [value2], [value3], [value4], [value5], [description]) VALUES (4, N'Max Health', N'health_max', N'CONF01', N'100', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[config] ([config_id], [name], [code_name], [config_type_id], [value1], [value2], [value3], [value4], [value5], [description]) VALUES (5, N'Armor', N'armor_value', N'CONF01', N'50', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[config] ([config_id], [name], [code_name], [config_type_id], [value1], [value2], [value3], [value4], [value5], [description]) VALUES (6, N'Initial money', N'money_init', N'CONF01', N'1000', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[config] OFF
GO
SET IDENTITY_INSERT [dbo].[match] ON 

INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (1, CAST(N'2024-08-07T21:20:57.207' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (2, CAST(N'2024-08-09T15:07:46.730' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (3, CAST(N'2024-08-09T21:55:28.490' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (4, CAST(N'2024-08-10T12:36:27.567' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (5, CAST(N'2024-08-10T13:12:38.183' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (6, CAST(N'2024-08-10T14:18:26.123' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (7, CAST(N'2024-08-10T16:03:23.850' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (8, CAST(N'2024-08-10T17:23:37.407' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (9, CAST(N'2024-08-17T12:03:24.170' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (10, CAST(N'2024-08-17T17:41:46.663' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (11, CAST(N'2024-08-17T17:45:39.773' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (12, CAST(N'2024-08-17T19:57:42.563' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (13, CAST(N'2024-08-18T11:04:33.143' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (14, CAST(N'2024-08-18T12:41:55.943' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (15, CAST(N'2024-08-18T12:44:04.610' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (16, CAST(N'2024-08-18T14:05:06.027' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (17, CAST(N'2024-08-18T14:05:06.370' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (18, CAST(N'2024-08-18T14:05:29.603' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (19, CAST(N'2024-08-18T14:05:29.630' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (20, CAST(N'2024-08-18T14:30:32.343' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (21, CAST(N'2024-08-18T14:30:36.727' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (22, CAST(N'2024-08-18T14:30:37.110' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (23, CAST(N'2024-08-18T14:30:37.247' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (24, CAST(N'2024-08-18T14:30:37.383' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (25, CAST(N'2024-08-18T14:30:37.520' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (26, CAST(N'2024-08-18T14:31:36.803' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (27, CAST(N'2024-08-18T14:34:19.060' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (28, CAST(N'2024-08-18T14:34:32.907' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (29, CAST(N'2024-08-18T14:34:34.327' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (30, CAST(N'2024-08-18T14:34:34.453' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (31, CAST(N'2024-08-18T14:34:34.590' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (32, CAST(N'2024-08-18T14:40:29.210' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (33, CAST(N'2024-08-18T15:06:51.203' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (34, CAST(N'2024-08-18T15:10:39.673' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (35, CAST(N'2024-08-18T15:14:37.027' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (36, CAST(N'2024-08-18T15:20:43.487' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (37, CAST(N'2024-08-18T16:03:23.580' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (38, CAST(N'2024-08-18T16:49:56.643' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (39, CAST(N'2024-08-18T17:07:54.147' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (40, CAST(N'2024-08-18T17:15:14.347' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (41, CAST(N'2024-08-18T17:17:35.883' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (42, CAST(N'2024-08-25T17:57:40.147' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (43, CAST(N'2024-08-25T18:28:34.357' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (44, CAST(N'2024-08-25T18:56:26.177' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (45, CAST(N'2024-08-25T19:24:39.170' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (46, CAST(N'2024-08-25T19:28:22.370' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (47, CAST(N'2024-08-25T19:30:51.640' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (48, CAST(N'2024-08-25T19:34:56.393' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (49, CAST(N'2024-08-25T19:35:48.647' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (50, CAST(N'2024-08-25T19:38:21.787' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (51, CAST(N'2024-08-25T20:57:59.487' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (52, CAST(N'2024-08-25T21:01:45.433' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (53, CAST(N'2024-08-25T21:11:13.657' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (54, CAST(N'2024-08-25T21:12:24.903' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (55, CAST(N'2024-08-25T21:13:06.243' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (56, CAST(N'2024-08-25T21:14:03.410' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (57, CAST(N'2024-08-25T21:17:53.667' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (58, CAST(N'2024-08-25T21:25:53.723' AS DateTime), N'MTST01')
INSERT [dbo].[match] ([id], [date], [stage_id]) VALUES (59, CAST(N'2024-08-25T21:27:03.003' AS DateTime), N'MTST01')
SET IDENTITY_INSERT [dbo].[match] OFF
GO
INSERT [dbo].[shared_base] ([base_id], [group_id], [base_name1], [base_name2], [base_name3], [base_name4], [base_name5], [sort], [description]) VALUES (N'CONF01', N'CONF00', N'Default player attribute value', NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[shared_base] ([base_id], [group_id], [base_name1], [base_name2], [base_name3], [base_name4], [base_name5], [sort], [description]) VALUES (N'CONF02', N'CONF00', N'default system value', NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[shared_base] ([base_id], [group_id], [base_name1], [base_name2], [base_name3], [base_name4], [base_name5], [sort], [description]) VALUES (N'MTST01', N'MTST00', N'Matching', NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[shared_base] ([base_id], [group_id], [base_name1], [base_name2], [base_name3], [base_name4], [base_name5], [sort], [description]) VALUES (N'MTST02', N'MTST00', N'Started', NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[shared_base] ([base_id], [group_id], [base_name1], [base_name2], [base_name3], [base_name4], [base_name5], [sort], [description]) VALUES (N'MTST03', N'MTST00', N'Finished', NULL, NULL, NULL, NULL, 2, NULL)
INSERT [dbo].[shared_base] ([base_id], [group_id], [base_name1], [base_name2], [base_name3], [base_name4], [base_name5], [sort], [description]) VALUES (N'RDST01', N'RDST00', N'Buy phase', NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[shared_base] ([base_id], [group_id], [base_name1], [base_name2], [base_name3], [base_name4], [base_name5], [sort], [description]) VALUES (N'RDST02', N'RDST00', N'Battle phase', NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[shared_base] ([base_id], [group_id], [base_name1], [base_name2], [base_name3], [base_name4], [base_name5], [sort], [description]) VALUES (N'RDST03', N'RDST00', N'Review', NULL, NULL, NULL, NULL, 2, NULL)
INSERT [dbo].[shared_base] ([base_id], [group_id], [base_name1], [base_name2], [base_name3], [base_name4], [base_name5], [sort], [description]) VALUES (N'RDST04', N'RDST00', N'Finished', NULL, NULL, NULL, NULL, 3, NULL)
INSERT [dbo].[shared_base] ([base_id], [group_id], [base_name1], [base_name2], [base_name3], [base_name4], [base_name5], [sort], [description]) VALUES (N'TEAM01', N'TEAM00', N'Team 1', N'Team red', NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[shared_base] ([base_id], [group_id], [base_name1], [base_name2], [base_name3], [base_name4], [base_name5], [sort], [description]) VALUES (N'TEAM02', N'TEAM00', N'Team 2', N'Team blue', NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[shared_base] ([base_id], [group_id], [base_name1], [base_name2], [base_name3], [base_name4], [base_name5], [sort], [description]) VALUES (N'TEAM03', N'TEAM00', N'Team 3', N'Team yellow', NULL, NULL, NULL, 3, NULL)
INSERT [dbo].[shared_base] ([base_id], [group_id], [base_name1], [base_name2], [base_name3], [base_name4], [base_name5], [sort], [description]) VALUES (N'TEAM04', N'TEAM00', N'Team 4', N'Team green', NULL, NULL, NULL, 4, NULL)
GO
INSERT [dbo].[shared_group] ([group_id], [group_name1], [group_name2], [group_name3], [group_name4], [group_name5], [description]) VALUES (N'CONF00', N'Config type', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[shared_group] ([group_id], [group_name1], [group_name2], [group_name3], [group_name4], [group_name5], [description]) VALUES (N'MTST00', N'Match stage', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[shared_group] ([group_id], [group_name1], [group_name2], [group_name3], [group_name4], [group_name5], [description]) VALUES (N'RDST00', N'Round stage', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[shared_group] ([group_id], [group_name1], [group_name2], [group_name3], [group_name4], [group_name5], [description]) VALUES (N'TEAM00', N'Team name', NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[upgrade] ON 

INSERT [dbo].[upgrade] ([id], [name], [description], [price]) VALUES (1, N'Attack plus', NULL, CAST(500.00 AS Decimal(10, 2)))
INSERT [dbo].[upgrade] ([id], [name], [description], [price]) VALUES (3, N'Defense plus', NULL, CAST(400.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[upgrade] OFF
GO
SET IDENTITY_INSERT [dbo].[upgrade_attribute] ON 

INSERT [dbo].[upgrade_attribute] ([id], [upgrade_id], [attribute_id], [value]) VALUES (1, 1, 1, 10)
INSERT [dbo].[upgrade_attribute] ([id], [upgrade_id], [attribute_id], [value]) VALUES (2, 1, 2, 5)
INSERT [dbo].[upgrade_attribute] ([id], [upgrade_id], [attribute_id], [value]) VALUES (6, 3, 4, 50)
INSERT [dbo].[upgrade_attribute] ([id], [upgrade_id], [attribute_id], [value]) VALUES (7, 3, 4, 50)
SET IDENTITY_INSERT [dbo].[upgrade_attribute] OFF
GO
ALTER TABLE [dbo].[config]  WITH CHECK ADD  CONSTRAINT [FK__config__config_t__07C12930] FOREIGN KEY([config_type_id])
REFERENCES [dbo].[shared_base] ([base_id])
GO
ALTER TABLE [dbo].[config] CHECK CONSTRAINT [FK__config__config_t__07C12930]
GO
ALTER TABLE [dbo].[hit_log]  WITH CHECK ADD  CONSTRAINT [FK__hit_log__hit_typ__04E4BC85] FOREIGN KEY([hit_type_id])
REFERENCES [dbo].[shared_base] ([base_id])
GO
ALTER TABLE [dbo].[hit_log] CHECK CONSTRAINT [FK__hit_log__hit_typ__04E4BC85]
GO
ALTER TABLE [dbo].[hit_log]  WITH CHECK ADD  CONSTRAINT [FK__hit_log__round_i__03F0984C] FOREIGN KEY([round_id])
REFERENCES [dbo].[round] ([round_id])
GO
ALTER TABLE [dbo].[hit_log] CHECK CONSTRAINT [FK__hit_log__round_i__03F0984C]
GO
ALTER TABLE [dbo].[hit_log]  WITH CHECK ADD  CONSTRAINT [FK__hit_log__source___02084FDA] FOREIGN KEY([source_player_id])
REFERENCES [dbo].[player] ([id])
GO
ALTER TABLE [dbo].[hit_log] CHECK CONSTRAINT [FK__hit_log__source___02084FDA]
GO
ALTER TABLE [dbo].[hit_log]  WITH CHECK ADD  CONSTRAINT [FK__hit_log__target___02FC7413] FOREIGN KEY([target_player_id])
REFERENCES [dbo].[player] ([id])
GO
ALTER TABLE [dbo].[hit_log] CHECK CONSTRAINT [FK__hit_log__target___02FC7413]
GO
ALTER TABLE [dbo].[match]  WITH CHECK ADD  CONSTRAINT [FK__match__stage_id__6EF57B66] FOREIGN KEY([stage_id])
REFERENCES [dbo].[shared_base] ([base_id])
GO
ALTER TABLE [dbo].[match] CHECK CONSTRAINT [FK__match__stage_id__6EF57B66]
GO
ALTER TABLE [dbo].[player_attribute]  WITH CHECK ADD FOREIGN KEY([attribute_id])
REFERENCES [dbo].[attribute] ([id])
GO
ALTER TABLE [dbo].[player_attribute]  WITH CHECK ADD FOREIGN KEY([attribute_id])
REFERENCES [dbo].[attribute] ([id])
GO
ALTER TABLE [dbo].[player_attribute]  WITH CHECK ADD FOREIGN KEY([player_id])
REFERENCES [dbo].[player] ([id])
GO
ALTER TABLE [dbo].[player_attribute]  WITH CHECK ADD FOREIGN KEY([player_id])
REFERENCES [dbo].[player] ([id])
GO
ALTER TABLE [dbo].[player_match]  WITH CHECK ADD  CONSTRAINT [FK__player_ma__match__76969D2E] FOREIGN KEY([match_id])
REFERENCES [dbo].[match] ([id])
GO
ALTER TABLE [dbo].[player_match] CHECK CONSTRAINT [FK__player_ma__match__76969D2E]
GO
ALTER TABLE [dbo].[player_match]  WITH CHECK ADD  CONSTRAINT [FK__player_ma__playe__75A278F5] FOREIGN KEY([player_id])
REFERENCES [dbo].[player] ([id])
GO
ALTER TABLE [dbo].[player_match] CHECK CONSTRAINT [FK__player_ma__playe__75A278F5]
GO
ALTER TABLE [dbo].[player_match]  WITH CHECK ADD  CONSTRAINT [FK__player_ma__team___778AC167] FOREIGN KEY([team_id])
REFERENCES [dbo].[shared_base] ([base_id])
GO
ALTER TABLE [dbo].[player_match] CHECK CONSTRAINT [FK__player_ma__team___778AC167]
GO
ALTER TABLE [dbo].[player_upgrade]  WITH CHECK ADD  CONSTRAINT [FK__player_up__playe__7A672E12] FOREIGN KEY([player_match_id])
REFERENCES [dbo].[player_match] ([player_match_id])
GO
ALTER TABLE [dbo].[player_upgrade] CHECK CONSTRAINT [FK__player_up__playe__7A672E12]
GO
ALTER TABLE [dbo].[player_upgrade]  WITH CHECK ADD FOREIGN KEY([upgrade_id])
REFERENCES [dbo].[upgrade] ([id])
GO
ALTER TABLE [dbo].[player_upgrade]  WITH CHECK ADD FOREIGN KEY([upgrade_id])
REFERENCES [dbo].[upgrade] ([id])
GO
ALTER TABLE [dbo].[round]  WITH CHECK ADD  CONSTRAINT [FK__round__match_id__72C60C4A] FOREIGN KEY([match_id])
REFERENCES [dbo].[match] ([id])
GO
ALTER TABLE [dbo].[round] CHECK CONSTRAINT [FK__round__match_id__72C60C4A]
GO
ALTER TABLE [dbo].[round]  WITH CHECK ADD  CONSTRAINT [FK__round__round_sta__71D1E811] FOREIGN KEY([round_stage_id])
REFERENCES [dbo].[shared_base] ([base_id])
GO
ALTER TABLE [dbo].[round] CHECK CONSTRAINT [FK__round__round_sta__71D1E811]
GO
ALTER TABLE [dbo].[shared_base]  WITH CHECK ADD  CONSTRAINT [FK__shared_ba__group__6C190EBB] FOREIGN KEY([group_id])
REFERENCES [dbo].[shared_group] ([group_id])
GO
ALTER TABLE [dbo].[shared_base] CHECK CONSTRAINT [FK__shared_ba__group__6C190EBB]
GO
ALTER TABLE [dbo].[shoot_log]  WITH CHECK ADD FOREIGN KEY([player_id])
REFERENCES [dbo].[player] ([id])
GO
ALTER TABLE [dbo].[shoot_log]  WITH CHECK ADD FOREIGN KEY([player_id])
REFERENCES [dbo].[player] ([id])
GO
ALTER TABLE [dbo].[shoot_log]  WITH CHECK ADD  CONSTRAINT [FK__shoot_log__round__7F2BE32F] FOREIGN KEY([round_id])
REFERENCES [dbo].[round] ([round_id])
GO
ALTER TABLE [dbo].[shoot_log] CHECK CONSTRAINT [FK__shoot_log__round__7F2BE32F]
GO
ALTER TABLE [dbo].[upgrade_attribute]  WITH CHECK ADD FOREIGN KEY([attribute_id])
REFERENCES [dbo].[attribute] ([id])
GO
ALTER TABLE [dbo].[upgrade_attribute]  WITH CHECK ADD FOREIGN KEY([attribute_id])
REFERENCES [dbo].[attribute] ([id])
GO
ALTER TABLE [dbo].[upgrade_attribute]  WITH CHECK ADD FOREIGN KEY([upgrade_id])
REFERENCES [dbo].[upgrade] ([id])
GO
ALTER TABLE [dbo].[upgrade_attribute]  WITH CHECK ADD FOREIGN KEY([upgrade_id])
REFERENCES [dbo].[upgrade] ([id])
GO
