USE [master]
GO
/****** Object:  Database [SHS]    Script Date: 06/03/2018 17:06:56 ******/
CREATE DATABASE [SHS] ON  PRIMARY 
( NAME = N'SHS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\SHS.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SHS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\SHS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SHS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SHS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SHS] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [SHS] SET ANSI_NULLS OFF
GO
ALTER DATABASE [SHS] SET ANSI_PADDING OFF
GO
ALTER DATABASE [SHS] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [SHS] SET ARITHABORT OFF
GO
ALTER DATABASE [SHS] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [SHS] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [SHS] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [SHS] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [SHS] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [SHS] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [SHS] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [SHS] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [SHS] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [SHS] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [SHS] SET  DISABLE_BROKER
GO
ALTER DATABASE [SHS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [SHS] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [SHS] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [SHS] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [SHS] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [SHS] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [SHS] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [SHS] SET  READ_WRITE
GO
ALTER DATABASE [SHS] SET RECOVERY SIMPLE
GO
ALTER DATABASE [SHS] SET  MULTI_USER
GO
ALTER DATABASE [SHS] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [SHS] SET DB_CHAINING OFF
GO
USE [SHS]
GO
/****** Object:  Table [dbo].[Technician]    Script Date: 06/03/2018 17:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Technician](
	[ID] [char](13) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[ContactNo] [char](10) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Commission] [money] NOT NULL,
	[DateEmployed] [date] NOT NULL,
 CONSTRAINT [PK_Technician] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Technician] ([ID], [Name], [Surname], [ContactNo], [Email], [Commission], [DateEmployed]) VALUES (N'7412120352615', N'Anila', N'Brecher', N'0735462716', N'brechera@gmail.com', 120.0000, CAST(0xB63D0B00 AS Date))
INSERT [dbo].[Technician] ([ID], [Name], [Surname], [ContactNo], [Email], [Commission], [DateEmployed]) VALUES (N'8216256573816', N'Marc', N'Fourie', N'0372836472', N'fouriem@gmail.com', 100.0000, CAST(0x223C0B00 AS Date))
INSERT [dbo].[Technician] ([ID], [Name], [Surname], [ContactNo], [Email], [Commission], [DateEmployed]) VALUES (N'8601017562837', N'Peter', N'Gomez', N'0836257463', N'gomesp@gmail.com', 100.0000, CAST(0x4C3D0B00 AS Date))
INSERT [dbo].[Technician] ([ID], [Name], [Surname], [ContactNo], [Email], [Commission], [DateEmployed]) VALUES (N'9001020253416', N'Melissa', N'Pienaar', N'0965252378', N'pienaarm@gmail.com', 120.0000, CAST(0x403A0B00 AS Date))
INSERT [dbo].[Technician] ([ID], [Name], [Surname], [ContactNo], [Email], [Commission], [DateEmployed]) VALUES (N'9374625142637', N'Manang', N'Mabaso', N'0836452638', N'mabasom@gmail.com', 100.0000, CAST(0x2E330B00 AS Date))
/****** Object:  Table [dbo].[Package]    Script Date: 06/03/2018 17:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Package](
	[PackageCode] [char](3) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Package] PRIMARY KEY CLUSTERED 
(
	[PackageCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Package] ([PackageCode], [Name]) VALUES (N'HCM', N'Home Convenience Management')
INSERT [dbo].[Package] ([PackageCode], [Name]) VALUES (N'HEM', N'Home Energy Management')
INSERT [dbo].[Package] ([PackageCode], [Name]) VALUES (N'HSM', N'Home Safety Management')
/****** Object:  Table [dbo].[Administrator]    Script Date: 06/03/2018 17:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Administrator](
	[ID] [char](13) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[ContactNo] [char](10) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Salary] [money] NOT NULL,
	[DateEmployed] [date] NOT NULL,
 CONSTRAINT [PK_Administrator] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Administrator] ([ID], [Name], [Surname], [ContactNo], [Email], [Salary], [DateEmployed]) VALUES (N'7518090132647', N'Jessica', N'Grater', N'0825362715', N'graterj@gmail.com', 10000.0000, CAST(0x2B310B00 AS Date))
INSERT [dbo].[Administrator] ([ID], [Name], [Surname], [ContactNo], [Email], [Salary], [DateEmployed]) VALUES (N'8316246452718', N'John', N'Maree', N'0283726152', N'mareej@gmail.com', 10000.0000, CAST(0x6E390B00 AS Date))
/****** Object:  Table [dbo].[Address]    Script Date: 06/03/2018 17:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Address](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Suburb] [varchar](50) NOT NULL,
	[Street] [varchar](50) NOT NULL,
	[Port] [varchar](10) NOT NULL,
 CONSTRAINT [PK_BillingAddress] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Address] ON
INSERT [dbo].[Address] ([AddressID], [City], [Suburb], [Street], [Port]) VALUES (1, N'Pretoria', N'Montana', N'Haveman', N'0182')
INSERT [dbo].[Address] ([AddressID], [City], [Suburb], [Street], [Port]) VALUES (2, N'Sandton', N'Benmore Gardens', N'Rose', N'0352')
INSERT [dbo].[Address] ([AddressID], [City], [Suburb], [Street], [Port]) VALUES (3, N'Cape Town', N'Salt River', N'Amaryllis', N'7925')
INSERT [dbo].[Address] ([AddressID], [City], [Suburb], [Street], [Port]) VALUES (5, N'Pretoria', N'Montana', N'Riviera', N'0182')
INSERT [dbo].[Address] ([AddressID], [City], [Suburb], [Street], [Port]) VALUES (9, N'Pretoria', N'Montana', N'Riviera', N'0182')
INSERT [dbo].[Address] ([AddressID], [City], [Suburb], [Street], [Port]) VALUES (10, N'Pretoria', N'Montana', N'Riviera', N'0182')
INSERT [dbo].[Address] ([AddressID], [City], [Suburb], [Street], [Port]) VALUES (11, N'Pretoria', N'Montana', N'Riviera', N'0182')
SET IDENTITY_INSERT [dbo].[Address] OFF
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 06/03/2018 17:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[ManufacturerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[ContactNo] [char](10) NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[ManufacturerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_ManufacturerName] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Manufacturer] ON
INSERT [dbo].[Manufacturer] ([ManufacturerID], [Name], [ContactNo]) VALUES (1, N'Fontana', N'0127564736')
INSERT [dbo].[Manufacturer] ([ManufacturerID], [Name], [ContactNo]) VALUES (2, N'Truvello Manufacturers', N'0127583728')
INSERT [dbo].[Manufacturer] ([ManufacturerID], [Name], [ContactNo]) VALUES (3, N'Milga Manufacturing', N'0113546281')
SET IDENTITY_INSERT [dbo].[Manufacturer] OFF
/****** Object:  Table [dbo].[InstalledProduct]    Script Date: 06/03/2018 17:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InstalledProduct](
	[OrderID] [int] NOT NULL,
	[ProductCode] [char](5) NOT NULL,
	[LastMaintenance] [date] NULL,
	[StillInstalled] [bit] NULL,
 CONSTRAINT [PK_InstalledProduct] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1001, N'ACDS3', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1002, N'ALS71', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1005, N'SAA45', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1006, N'SWANS', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1011, N'HMM45', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1013, N'CHTM3', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1013, N'HEP23', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1014, N'GTM56', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1016, N'ALS71', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1017, N'HMM12', CAST(0xAA3D0B00 AS Date), 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1017, N'SMS98', CAST(0xAA3D0B00 AS Date), 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1018, N'SWANS', CAST(0x6F3C0B00 AS Date), 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1019, N'SRPS5', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1021, N'SAA45', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1021, N'SMS98', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1021, N'SRPS5', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1021, N'SWANS', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1026, N'ACDS3', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1026, N'AHCM1', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1026, N'ALS71', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1026, N'HMM12', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1026, N'HMM45', NULL, 1)
INSERT [dbo].[InstalledProduct] ([OrderID], [ProductCode], [LastMaintenance], [StillInstalled]) VALUES (1026, N'SRPS5', NULL, 1)
/****** Object:  Table [dbo].[Component]    Script Date: 06/03/2018 17:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Component](
	[ComponentCode] [char](5) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Component] PRIMARY KEY CLUSTERED 
(
	[ComponentCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'AS820', N'Air Separator', 50.0000)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'BVWFM', N'Balancing Valve With Flow Meter', 235.0000)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'CMD45', N'Carbon Monoxide Detector', 75.0000)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'DAWS8', N'Door And Window Sensor', 45.0000)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'EDL98', N'Electric Door Lock', 225.0000)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'FDACS', N'Fire Detection And Control System', 55.0000)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'HS531', N'Heat Sensor', 75.0000)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'LB153', N'Light Bulbs', 100.8800)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'LB435', N'Light Bulb', 84.9500)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'MHS31', N'Multifunction Hydraulic Separator', 150.0000)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'MS638', N'Motion Sensor', 59.9500)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'PCV52', N'Pressure Control Valve', 99.9500)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'PGADP', N'Pickling Gel And Deoxidising Powder', 35.0000)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'RWTCS', N'Radio Wave Temperature Control System', 99.9500)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'SC735', N'Security Camera', 135.0000)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'SCAH7', N'Strainer Cartridges And Housing', 45.0000)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'STCK5', N'Solar Thermostatic Connection Kit', 149.9500)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'T6352', N'Thermostat', 34.9500)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'TAPRV', N'Temperature And Pressure Relief Valve', 80.0000)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'TG438', N'Temperature Gauge', 45.0000)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'TMV58', N'Temperature Manager Valve', 50.0000)
INSERT [dbo].[Component] ([ComponentCode], [Description], [Price]) VALUES (N'TRV82', N'Thermostatic Radiator Valve', 115.0000)
/****** Object:  Table [dbo].[Client]    Script Date: 06/03/2018 17:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Client](
	[ClientID] [char](9) NOT NULL,
	[IDNumber] [char](13) NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[ContactNo] [char](10) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[AddressID] [int] NOT NULL,
	[Contract] [char](12) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_IDNumber] ON [dbo].[Client] 
(
	[IDNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[Client] ([ClientID], [IDNumber], [Name], [Surname], [ContactNo], [Email], [AddressID], [Contract]) VALUES (N'B39146609', N'6503200263078', N'Leah', N'Webb', N'0825364827', N'webbl@gmail.com', 5, N'2018BA000001')
INSERT [dbo].[Client] ([ClientID], [IDNumber], [Name], [Surname], [ContactNo], [Email], [AddressID], [Contract]) VALUES (N'B54657467', N'7603206374625', N'Hendriko', N'du Toit', N'0635472837', N'dutoith@gmail.com', 2, NULL)
INSERT [dbo].[Client] ([ClientID], [IDNumber], [Name], [Surname], [ContactNo], [Email], [AddressID], [Contract]) VALUES (N'C72456462', N'8602078374516', N'Jozehan', N'Grobbies', N'0756372635', N'grobbiesj@gmail.com', 3, N'2017BB000001')
INSERT [dbo].[Client] ([ClientID], [IDNumber], [Name], [Surname], [ContactNo], [Email], [AddressID], [Contract]) VALUES (N'E83720953', N'9702050121088', N'Nicky', N'Muller', N'0822239591', N'mullern@gmail.com', 1, N'2016AA000001')
/****** Object:  Table [dbo].[CallLog]    Script Date: 06/03/2018 17:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CallLog](
	[CallLogID] [int] IDENTITY(1,1) NOT NULL,
	[StartDateTime] [datetime2](7) NULL,
	[EndDateTime] [datetime] NULL,
	[AdministratorID] [char](13) NULL,
 CONSTRAINT [PK_CallLogs] PRIMARY KEY CLUSTERED 
(
	[CallLogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CallLog] ON
INSERT [dbo].[CallLog] ([CallLogID], [StartDateTime], [EndDateTime], [AdministratorID]) VALUES (1, CAST(0x0700396C66672E3E0B AS DateTime2), CAST(0x0000A8D300CC5178 AS DateTime), N'7518090132647')
INSERT [dbo].[CallLog] ([CallLogID], [StartDateTime], [EndDateTime], [AdministratorID]) VALUES (2, CAST(0x078052DBC27FC13D0B AS DateTime2), CAST(0x0000A86600FC9F18 AS DateTime), N'8316246452718')
INSERT [dbo].[CallLog] ([CallLogID], [StartDateTime], [EndDateTime], [AdministratorID]) VALUES (3, CAST(0x0700DE3B51582A3E0B AS DateTime2), CAST(0x0000A8CF00B01FE4 AS DateTime), N'8316246452718')
INSERT [dbo].[CallLog] ([CallLogID], [StartDateTime], [EndDateTime], [AdministratorID]) VALUES (4, CAST(0x0700DAD05C43703D0B AS DateTime2), CAST(0x0000A81500852E88 AS DateTime), N'7518090132647')
INSERT [dbo].[CallLog] ([CallLogID], [StartDateTime], [EndDateTime], [AdministratorID]) VALUES (5, CAST(0x078047272870373E0B AS DateTime2), CAST(0x0000A8DC00DEFA08 AS DateTime), N'8316246452718')
INSERT [dbo].[CallLog] ([CallLogID], [StartDateTime], [EndDateTime], [AdministratorID]) VALUES (7, CAST(0x0700F01310914A3E0B AS DateTime2), CAST(0x0000A8EF011D3A5C AS DateTime), N'7518090132647')
INSERT [dbo].[CallLog] ([CallLogID], [StartDateTime], [EndDateTime], [AdministratorID]) VALUES (9, CAST(0x0700EE09E9914A3E0B AS DateTime2), CAST(0x0000A8EF011EF2FC AS DateTime), N'7518090132647')
INSERT [dbo].[CallLog] ([CallLogID], [StartDateTime], [EndDateTime], [AdministratorID]) VALUES (11, CAST(0x07808554AE924A3E0B AS DateTime2), CAST(0x0000A8EF01206B28 AS DateTime), N'7518090132647')
INSERT [dbo].[CallLog] ([CallLogID], [StartDateTime], [EndDateTime], [AdministratorID]) VALUES (13, CAST(0x0700A3BB0A9B4D3E0B AS DateTime2), CAST(0x0000A8F20130F1A0 AS DateTime), N'8316246452718')
INSERT [dbo].[CallLog] ([CallLogID], [StartDateTime], [EndDateTime], [AdministratorID]) VALUES (14, CAST(0x07802174AD9B4D3E0B AS DateTime2), CAST(0x0000A8F201323894 AS DateTime), N'7518090132647')
INSERT [dbo].[CallLog] ([CallLogID], [StartDateTime], [EndDateTime], [AdministratorID]) VALUES (15, CAST(0x0700192E07A74D3E0B AS DateTime2), CAST(0x0000A8F2014885F4 AS DateTime), N'7518090132647')
INSERT [dbo].[CallLog] ([CallLogID], [StartDateTime], [EndDateTime], [AdministratorID]) VALUES (16, CAST(0x0780620679A74D3E0B AS DateTime2), CAST(0x0000A8F201494C00 AS DateTime), N'7518090132647')
INSERT [dbo].[CallLog] ([CallLogID], [StartDateTime], [EndDateTime], [AdministratorID]) VALUES (17, CAST(0x0700EAF2DEA74D3E0B AS DateTime2), CAST(0x0000A8F2014A1B6C AS DateTime), N'7518090132647')
SET IDENTITY_INSERT [dbo].[CallLog] OFF
/****** Object:  Table [dbo].[Installation]    Script Date: 06/03/2018 17:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Installation](
	[InstallationID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[ProductCode] [char](5) NULL,
	[TechnicianID] [char](13) NULL,
	[DateOfInstallation] [date] NULL,
	[Duration] [int] NULL,
	[Cost] [money] NULL,
 CONSTRAINT [PK_Installation] PRIMARY KEY CLUSTERED 
(
	[InstallationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Installation] ON
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (1, 1001, N'ACDS3', N'7412120352615', CAST(0x013E0B00 AS Date), 53, 100.0000)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (2, 1002, N'ALS71', N'8216256573816', CAST(0xC73D0B00 AS Date), 67, 120.0000)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (3, 1013, N'CHTM3', N'8601017562837', CAST(0xA93D0B00 AS Date), 42, 100.0000)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (4, 1013, N'HEP23', N'9001020253416', CAST(0xA93D0B00 AS Date), 47, 100.0000)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (5, 1005, N'SAA45', NULL, CAST(0x3E3E0B00 AS Date), NULL, NULL)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (6, 1006, N'SWANS', N'7412120352615', CAST(0x9A3D0B00 AS Date), 101, 120.0000)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (7, 1014, N'GTM56', N'8216256573816', CAST(0xCF3D0B00 AS Date), 43, 100.0000)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (8, 1016, N'ALS71', N'8601017562837', CAST(0xD63C0B00 AS Date), 83, 120.0000)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (9, 1017, N'HMM12', N'9001020253416', CAST(0x443C0B00 AS Date), 94, 120.0000)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (10, 1017, N'SMS98', N'9374625142637', CAST(0x443C0B00 AS Date), 53, 100.0000)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (11, 1018, N'SWANS', N'7412120352615', CAST(0x2B3D0B00 AS Date), 136, 140.0000)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (12, 1011, N'HMM45', N'8216256573816', CAST(0x593D0B00 AS Date), 63, 120.0000)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (13, 1019, N'SRPS5', N'8601017562837', CAST(0xA33C0B00 AS Date), 112, 120.0000)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (68, 1021, N'SAA45', NULL, CAST(0x483E0B00 AS Date), NULL, NULL)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (69, 1021, N'SMS98', NULL, CAST(0x483E0B00 AS Date), NULL, NULL)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (70, 1021, N'SRPS5', NULL, CAST(0x483E0B00 AS Date), NULL, NULL)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (71, 1021, N'SWANS', NULL, CAST(0x483E0B00 AS Date), NULL, NULL)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (80, 1026, N'ACDS3', NULL, CAST(0x493E0B00 AS Date), NULL, NULL)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (81, 1026, N'AHCM1', NULL, CAST(0x493E0B00 AS Date), NULL, NULL)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (82, 1026, N'HMM12', NULL, CAST(0x493E0B00 AS Date), NULL, NULL)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (83, 1026, N'HMM45', NULL, CAST(0x493E0B00 AS Date), NULL, NULL)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (84, 1026, N'ALS71', NULL, CAST(0x493E0B00 AS Date), NULL, NULL)
INSERT [dbo].[Installation] ([InstallationID], [OrderID], [ProductCode], [TechnicianID], [DateOfInstallation], [Duration], [Cost]) VALUES (85, 1026, N'SRPS5', NULL, CAST(0x493E0B00 AS Date), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Installation] OFF
/****** Object:  Table [dbo].[Maintenance]    Script Date: 06/03/2018 17:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Maintenance](
	[MaintenanceID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[ProductCode] [char](5) NULL,
	[TechnicianID] [char](13) NULL,
	[DateOfMaintenance] [date] NULL,
	[Duration] [int] NULL,
 CONSTRAINT [PK_Maintenance] PRIMARY KEY CLUSTERED 
(
	[MaintenanceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Maintenance] ON
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (1, 1001, N'ACDS3', NULL, CAST(0x6E3F0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (2, 1005, N'SAA45', NULL, CAST(0xAB3F0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (3, 1006, N'SWANS', NULL, CAST(0x073F0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (4, 1013, N'CHTM3', NULL, CAST(0x5F3E0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (5, 1013, N'HEP23', NULL, CAST(0x5F3E0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (6, 1014, N'GTM56', NULL, CAST(0x843E0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (7, 1016, N'ALS71', N'7412120352615', CAST(0x8E3D0B00 AS Date), 57)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (8, 1016, N'ALS71', NULL, CAST(0x433E0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (9, 1017, N'HMM12', N'8601017562837', CAST(0xFA3C0B00 AS Date), 111)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (10, 1017, N'SMS98', N'9001020253416', CAST(0xFA3C0B00 AS Date), 102)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (11, 1017, N'HMM12', N'9374625142637', CAST(0xB13D0B00 AS Date), 83)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (12, 1017, N'SMS98', N'7412120352615', CAST(0xB13D0B00 AS Date), 14)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (13, 1017, N'HMM12', NULL, CAST(0x673E0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (14, 1017, N'SMS98', NULL, CAST(0x673E0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (15, 1018, N'SWANS', N'9001020253416', CAST(0xE33D0B00 AS Date), 41)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (16, 1018, N'SWANS', NULL, CAST(0x983E0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (17, 1019, N'SRPS5', N'8216256573816', CAST(0x5A3D0B00 AS Date), 71)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (18, 1019, N'SRPS5', NULL, CAST(0x103E0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (19, 1019, N'SRPS5', NULL, CAST(0xC73E0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (46, 1021, N'SAA45', NULL, CAST(0xAE3F0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (47, 1021, N'SMS98', NULL, CAST(0xAE3F0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (48, 1021, N'SRPS5', NULL, CAST(0xAE3F0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (49, 1021, N'SWANS', NULL, CAST(0xAE3F0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (58, 1026, N'ACDS3', NULL, CAST(0xAF3F0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (59, 1026, N'AHCM1', NULL, CAST(0xAF3F0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (60, 1026, N'HMM12', NULL, CAST(0xAF3F0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (61, 1026, N'HMM45', NULL, CAST(0xAF3F0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (62, 1026, N'ALS71', NULL, CAST(0xAF3F0B00 AS Date), NULL)
INSERT [dbo].[Maintenance] ([MaintenanceID], [OrderID], [ProductCode], [TechnicianID], [DateOfMaintenance], [Duration]) VALUES (63, 1026, N'SRPS5', NULL, CAST(0xAF3F0B00 AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Maintenance] OFF
/****** Object:  Table [dbo].[Login]    Script Date: 06/03/2018 17:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[AdministratorID] [char](13) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Username] ASC,
	[Password] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Login] ([Username], [Password], [AdministratorID]) VALUES (N'admin1', N'1234', N'7518090132647')
INSERT [dbo].[Login] ([Username], [Password], [AdministratorID]) VALUES (N'admin2', N'4321', N'8316246452718')
/****** Object:  Table [dbo].[Product]    Script Date: 06/03/2018 17:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ProductCode] [char](5) NOT NULL,
	[PackageCode] [char](3) NULL,
	[Description] [varchar](50) NULL,
	[ManufacturerID] [int] NULL,
	[Sellable] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Product] ([ProductCode], [PackageCode], [Description], [ManufacturerID], [Sellable]) VALUES (N'ACDS3', N'HCM', N'Automatic Curtain Drawing System', 3, 1)
INSERT [dbo].[Product] ([ProductCode], [PackageCode], [Description], [ManufacturerID], [Sellable]) VALUES (N'AGMS1', N'HCM', N'Automatic Garder Master Sprinkler', 1, 0)
INSERT [dbo].[Product] ([ProductCode], [PackageCode], [Description], [ManufacturerID], [Sellable]) VALUES (N'AHCM1', N'HCM', N'Automatic Home Chef System', 3, 1)
INSERT [dbo].[Product] ([ProductCode], [PackageCode], [Description], [ManufacturerID], [Sellable]) VALUES (N'ALS71', N'HEM', N'Automatic Light Switch', 2, 1)
INSERT [dbo].[Product] ([ProductCode], [PackageCode], [Description], [ManufacturerID], [Sellable]) VALUES (N'CHTM3', N'HEM', N'Central Heating Temperature Manager', 1, 1)
INSERT [dbo].[Product] ([ProductCode], [PackageCode], [Description], [ManufacturerID], [Sellable]) VALUES (N'GTM56', N'HEM', N'Geyser Temperature Manager', 1, 1)
INSERT [dbo].[Product] ([ProductCode], [PackageCode], [Description], [ManufacturerID], [Sellable]) VALUES (N'HEP23', N'HEM', N'Home Energy Producer', 3, 1)
INSERT [dbo].[Product] ([ProductCode], [PackageCode], [Description], [ManufacturerID], [Sellable]) VALUES (N'HMM12', N'HCM', N'Home Mood Manager', 2, 1)
INSERT [dbo].[Product] ([ProductCode], [PackageCode], [Description], [ManufacturerID], [Sellable]) VALUES (N'HMM45', N'HCM', N'Home Music Manager', 3, 1)
INSERT [dbo].[Product] ([ProductCode], [PackageCode], [Description], [ManufacturerID], [Sellable]) VALUES (N'SAA45', N'HSM', N'Security Alarm Activator', 1, 1)
INSERT [dbo].[Product] ([ProductCode], [PackageCode], [Description], [ManufacturerID], [Sellable]) VALUES (N'SMS98', N'HSM', N'Security Mode Scheduler', 3, 1)
INSERT [dbo].[Product] ([ProductCode], [PackageCode], [Description], [ManufacturerID], [Sellable]) VALUES (N'SRPS5', N'HSM', N'Security Response Plan System', 1, 1)
INSERT [dbo].[Product] ([ProductCode], [PackageCode], [Description], [ManufacturerID], [Sellable]) VALUES (N'SWANS', N'HSM', N'Security Warning And Notification System', 1, 1)
/****** Object:  StoredProcedure [dbo].[spEndCall]    Script Date: 06/03/2018 17:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spEndCall]
	@EndDateTime DateTime,
	@CallLogID int
AS
BEGIN
	UPDATE CallLog
	SET EndDateTime = @EndDateTime
	WHERE CallLogID = @CallLogID
END
GO
/****** Object:  Table [dbo].[ServiceTicket]    Script Date: 06/03/2018 17:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiceTicket](
	[ServiceTicketID] [int] IDENTITY(1,1) NOT NULL,
	[CallLogID] [int] NULL,
	[ProblemDescription] [varchar](100) NULL,
 CONSTRAINT [PK_ServiceTicket] PRIMARY KEY CLUSTERED 
(
	[ServiceTicketID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ServiceTicket] ON
INSERT [dbo].[ServiceTicket] ([ServiceTicketID], [CallLogID], [ProblemDescription]) VALUES (1, 1, N'Faulty')
INSERT [dbo].[ServiceTicket] ([ServiceTicketID], [CallLogID], [ProblemDescription]) VALUES (2, 3, N'Broken')
INSERT [dbo].[ServiceTicket] ([ServiceTicketID], [CallLogID], [ProblemDescription]) VALUES (3, 4, N'Faulty')
INSERT [dbo].[ServiceTicket] ([ServiceTicketID], [CallLogID], [ProblemDescription]) VALUES (4, 5, N'Unresponsive')
INSERT [dbo].[ServiceTicket] ([ServiceTicketID], [CallLogID], [ProblemDescription]) VALUES (6, 13, N'Heat element not heating up')
INSERT [dbo].[ServiceTicket] ([ServiceTicketID], [CallLogID], [ProblemDescription]) VALUES (7, 14, N'Unclear')
SET IDENTITY_INSERT [dbo].[ServiceTicket] OFF
/****** Object:  Table [dbo].[ProductComponent]    Script Date: 06/03/2018 17:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductComponent](
	[ProductCode] [char](5) NOT NULL,
	[ComponentCode] [char](5) NOT NULL,
	[DefaultQuantity] [int] NOT NULL,
 CONSTRAINT [PK_ProductComponent] PRIMARY KEY CLUSTERED 
(
	[ProductCode] ASC,
	[ComponentCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'ACDS3', N'BVWFM', 2)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'ACDS3', N'CMD45', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'AGMS1', N'DAWS8', 7)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'AGMS1', N'EDL98', 6)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'AGMS1', N'LB153', 3)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'AHCM1', N'FDACS', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'AHCM1', N'T6352', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'AHCM1', N'TRV82', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'ALS71', N'HS531', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'ALS71', N'MS638', 2)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'CHTM3', N'PGADP', 3)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'CHTM3', N'STCK5', 2)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'CHTM3', N'TG438', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'CHTM3', N'TRV82', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'GTM56', N'HS531', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'GTM56', N'PCV52', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'GTM56', N'TAPRV', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'HEP23', N'AS820', 2)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'HEP23', N'TAPRV', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'HMM12', N'MHS31', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'HMM12', N'TRV82', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'HMM45', N'MHS31', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'HMM45', N'SCAH7', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'HMM45', N'TMV58', 2)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'SAA45', N'EDL98', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'SAA45', N'SC735', 2)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'SMS98', N'DAWS8', 2)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'SMS98', N'MS638', 2)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'SMS98', N'SC735', 5)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'SRPS5', N'MS638', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'SRPS5', N'SC735', 1)
INSERT [dbo].[ProductComponent] ([ProductCode], [ComponentCode], [DefaultQuantity]) VALUES (N'SWANS', N'MS638', 2)
/****** Object:  StoredProcedure [dbo].[spGetAddress]    Script Date: 06/03/2018 17:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetAddress]
	@ClientID char(9)
AS
BEGIN
	SELECT Address.*
	FROM Address
		INNER JOIN Client
			ON Address.AddressID = Client.AddressID
	WHERE ClientID = @ClientID
END
GO
/****** Object:  StoredProcedure [dbo].[spFinaliseMaintenance]    Script Date: 06/03/2018 17:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spFinaliseMaintenance]
	@OperationID int, 
	@TechnicianID char(13),
	@Duration int
AS
BEGIN
	UPDATE Maintenance
	SET TechnicianID = @TechnicianID, Duration = @Duration
	WHERE MaintenanceID = @OperationID
END
GO
/****** Object:  StoredProcedure [dbo].[spFinaliseInstallation]    Script Date: 06/03/2018 17:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spFinaliseInstallation]
	@OperationID int, 
	@TechnicianID char(13),
	@Duration int,
	@Cost money
AS
BEGIN
	UPDATE Installation
	SET TechnicianID = @TechnicianID, Duration = @Duration, Cost = @Cost
	WHERE InstallationID = @OperationID
END
GO
/****** Object:  Table [dbo].[tblOrder]    Script Date: 06/03/2018 17:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblOrder](
	[OrderID] [int] IDENTITY(1000,1) NOT NULL,
	[ClientID] [char](9) NOT NULL,
	[DateOrdered] [date] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblOrder] ON
INSERT [dbo].[tblOrder] ([OrderID], [ClientID], [DateOrdered]) VALUES (1001, N'C72456462', CAST(0xFA3D0B00 AS Date))
INSERT [dbo].[tblOrder] ([OrderID], [ClientID], [DateOrdered]) VALUES (1002, N'B54657467', CAST(0xC03D0B00 AS Date))
INSERT [dbo].[tblOrder] ([OrderID], [ClientID], [DateOrdered]) VALUES (1005, N'C72456462', CAST(0x373E0B00 AS Date))
INSERT [dbo].[tblOrder] ([OrderID], [ClientID], [DateOrdered]) VALUES (1006, N'C72456462', CAST(0x933D0B00 AS Date))
INSERT [dbo].[tblOrder] ([OrderID], [ClientID], [DateOrdered]) VALUES (1011, N'B54657467', CAST(0x523D0B00 AS Date))
INSERT [dbo].[tblOrder] ([OrderID], [ClientID], [DateOrdered]) VALUES (1013, N'E83720953', CAST(0xA23D0B00 AS Date))
INSERT [dbo].[tblOrder] ([OrderID], [ClientID], [DateOrdered]) VALUES (1014, N'E83720953', CAST(0xC83D0B00 AS Date))
INSERT [dbo].[tblOrder] ([OrderID], [ClientID], [DateOrdered]) VALUES (1016, N'E83720953', CAST(0xCF3C0B00 AS Date))
INSERT [dbo].[tblOrder] ([OrderID], [ClientID], [DateOrdered]) VALUES (1017, N'E83720953', CAST(0x3D3C0B00 AS Date))
INSERT [dbo].[tblOrder] ([OrderID], [ClientID], [DateOrdered]) VALUES (1018, N'E83720953', CAST(0x243D0B00 AS Date))
INSERT [dbo].[tblOrder] ([OrderID], [ClientID], [DateOrdered]) VALUES (1019, N'E83720953', CAST(0x9C3C0B00 AS Date))
INSERT [dbo].[tblOrder] ([OrderID], [ClientID], [DateOrdered]) VALUES (1021, N'B39146609', CAST(0x413E0B00 AS Date))
INSERT [dbo].[tblOrder] ([OrderID], [ClientID], [DateOrdered]) VALUES (1026, N'B39146609', CAST(0x423E0B00 AS Date))
SET IDENTITY_INSERT [dbo].[tblOrder] OFF
/****** Object:  StoredProcedure [dbo].[spRemoveProduct]    Script Date: 06/03/2018 17:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spRemoveProduct]
	@ProductCode char(5)
AS
BEGIN
	UPDATE Product
	SET Sellable = 0
	WHERE ProductCode = @ProductCode	
END
GO
/****** Object:  StoredProcedure [dbo].[spGetSellableProductsInPackage]    Script Date: 06/03/2018 17:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetSellableProductsInPackage]
	@Sellable bit,
	@PackageCode char(3)
AS
BEGIN
	SELECT *
	FROM Product
		INNER JOIN Package
			ON Product.PackageCode = Package.PackageCode
	WHERE Sellable = @Sellable AND Package.PackageCode = @PackageCode
END
GO
/****** Object:  StoredProcedure [dbo].[spGetSellableProducts]    Script Date: 06/03/2018 17:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetSellableProducts]
	@Sellable bit
AS
BEGIN
	SELECT *
	FROM Product
	WHERE Sellable = @Sellable
END
GO
/****** Object:  StoredProcedure [dbo].[spGetManufacturer]    Script Date: 06/03/2018 17:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetManufacturer]
	@ProductCode char(9)
AS
BEGIN
	SELECT Manufacturer.*
	FROM Manufacturer
		INNER JOIN Product
			ON Manufacturer.ManufacturerID = Product.ManufacturerID
	WHERE Product.ProductCode = @ProductCode
END
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 06/03/2018 17:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderID] [int] NOT NULL,
	[ProductCode] [char](5) NOT NULL,
	[ComponentCode] [char](5) NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_OrderDetail_1] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductCode] ASC,
	[ComponentCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1001, N'ACDS3', N'BVWFM', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1001, N'ACDS3', N'CMD45', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1002, N'ALS71', N'HS531', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1002, N'ALS71', N'MS638', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1005, N'SAA45', N'EDL98', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1005, N'SAA45', N'SC735', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1006, N'SWANS', N'MS638', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1011, N'HMM45', N'MHS31', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1011, N'HMM45', N'SCAH7', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1011, N'HMM45', N'TMV58', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1013, N'CHTM3', N'PGADP', 3)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1013, N'CHTM3', N'STCK5', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1013, N'CHTM3', N'TG438', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1013, N'CHTM3', N'TRV82', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1013, N'HEP23', N'AS820', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1013, N'HEP23', N'TAPRV', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1014, N'GTM56', N'HS531', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1014, N'GTM56', N'PCV52', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1014, N'GTM56', N'TAPRV', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1016, N'ALS71', N'HS531', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1016, N'ALS71', N'MS638', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1017, N'HMM12', N'MHS31', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1017, N'HMM12', N'TRV82', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1017, N'SMS98', N'DAWS8', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1017, N'SMS98', N'MS638', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1017, N'SMS98', N'SC735', 5)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1018, N'SWANS', N'MS638', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1019, N'SRPS5', N'MS638', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1019, N'SRPS5', N'SC735', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1021, N'SAA45', N'EDL98', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1021, N'SAA45', N'SC735', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1021, N'SMS98', N'DAWS8', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1021, N'SMS98', N'MS638', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1021, N'SMS98', N'SC735', 5)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1021, N'SRPS5', N'MS638', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1021, N'SRPS5', N'SC735', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1021, N'SWANS', N'MS638', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1026, N'ACDS3', N'BVWFM', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1026, N'ACDS3', N'CMD45', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1026, N'AHCM1', N'FDACS', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1026, N'AHCM1', N'T6352', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1026, N'AHCM1', N'TRV82', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1026, N'ALS71', N'HS531', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1026, N'ALS71', N'MS638', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1026, N'HMM12', N'MHS31', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1026, N'HMM12', N'TRV82', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1026, N'HMM45', N'MHS31', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1026, N'HMM45', N'SCAH7', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1026, N'HMM45', N'TMV58', 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1026, N'SRPS5', N'MS638', 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductCode], [ComponentCode], [Quantity]) VALUES (1026, N'SRPS5', N'SC735', 1)
/****** Object:  Table [dbo].[Correction]    Script Date: 06/03/2018 17:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Correction](
	[CorrectionID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceTicketID] [int] NULL,
	[OrderID] [int] NULL,
	[ProductCode] [char](5) NULL,
	[TechnicianID] [char](13) NULL,
	[DateOfCorrection] [date] NULL,
	[Duration] [int] NULL,
	[Cost] [money] NULL,
 CONSTRAINT [PK_Correction] PRIMARY KEY CLUSTERED 
(
	[CorrectionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Correction] ON
INSERT [dbo].[Correction] ([CorrectionID], [ServiceTicketID], [OrderID], [ProductCode], [TechnicianID], [DateOfCorrection], [Duration], [Cost]) VALUES (1, 1, 1013, N'CHTM3', N'7412120352615', CAST(0x353E0B00 AS Date), 243, 160.0000)
INSERT [dbo].[Correction] ([CorrectionID], [ServiceTicketID], [OrderID], [ProductCode], [TechnicianID], [DateOfCorrection], [Duration], [Cost]) VALUES (2, 2, 1006, N'SWANS', N'9001020253416', CAST(0x313E0B00 AS Date), 132, 140.0000)
INSERT [dbo].[Correction] ([CorrectionID], [ServiceTicketID], [OrderID], [ProductCode], [TechnicianID], [DateOfCorrection], [Duration], [Cost]) VALUES (3, 3, 1017, N'SMS98', N'7412120352615', CAST(0x773D0B00 AS Date), 23, 100.0000)
INSERT [dbo].[Correction] ([CorrectionID], [ServiceTicketID], [OrderID], [ProductCode], [TechnicianID], [DateOfCorrection], [Duration], [Cost]) VALUES (4, 4, 1014, N'GTM56', NULL, CAST(0x3E3E0B00 AS Date), NULL, NULL)
INSERT [dbo].[Correction] ([CorrectionID], [ServiceTicketID], [OrderID], [ProductCode], [TechnicianID], [DateOfCorrection], [Duration], [Cost]) VALUES (5, 6, 1013, N'HEP23', NULL, CAST(0x543E0B00 AS Date), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Correction] OFF
/****** Object:  StoredProcedure [dbo].[spGetCompletedOrders]    Script Date: 06/03/2018 17:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetCompletedOrders]
AS
BEGIN
	SELECT *
	FROM tblOrder 
	WHERE OrderID IN 
		(SELECT InstalledProduct.OrderID 
		 FROM InstalledProduct 
			INNER JOIN Installation 
				ON InstalledProduct.OrderID = Installation.OrderID 
		 WHERE Duration IS NOT NULL)
END
GO
/****** Object:  StoredProcedure [dbo].[spGetProductComponents]    Script Date: 06/03/2018 17:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetProductComponents]
	@ProductCode char(9)
AS
BEGIN
	SELECT Component.*, ProductComponent.DefaultQuantity AS 'Quantity', ProductComponent.ProductCode
	FROM Component 
		INNER JOIN ProductComponent 
			ON Component.ComponentCode = ProductComponent.ComponentCode 
		INNER JOIN Product 
			ON Product.ProductCode = ProductComponent.ProductCode 
	WHERE Product.ProductCode = @ProductCode
END
GO
/****** Object:  StoredProcedure [dbo].[spGetPendingOrders]    Script Date: 06/03/2018 17:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetPendingOrders]
AS
BEGIN
	SELECT *
	FROM tblOrder 
	WHERE OrderID IN 
		(SELECT InstalledProduct.OrderID 
		 FROM InstalledProduct 
			INNER JOIN Installation 
				ON InstalledProduct.OrderID = Installation.OrderID 
		 WHERE Duration IS NULL)
END
GO
/****** Object:  StoredProcedure [dbo].[spGetOrderDetails]    Script Date: 06/03/2018 17:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetOrderDetails]
	@OrderID int
AS
BEGIN
	SELECT * 
	FROM OrderDetail 
	WHERE OrderID = @OrderID
END
GO
/****** Object:  StoredProcedure [dbo].[spFinaliseCorrection]    Script Date: 06/03/2018 17:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spFinaliseCorrection]
	@OperationID int, 
	@TechnicianID char(13),
	@Duration int,
	@Cost money
AS
BEGIN
	UPDATE Correction
	SET TechnicianID = @TechnicianID, Duration = @Duration, Cost = @Cost
	WHERE CorrectionID = @OperationID
END
GO
/****** Object:  Default [DF_InstalledProduct_LastMaintenance]    Script Date: 06/03/2018 17:06:57 ******/
ALTER TABLE [dbo].[InstalledProduct] ADD  CONSTRAINT [DF_InstalledProduct_LastMaintenance]  DEFAULT (NULL) FOR [LastMaintenance]
GO
/****** Object:  ForeignKey [FK_Client_Address]    Script Date: 06/03/2018 17:06:57 ******/
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Address] FOREIGN KEY([AddressID])
REFERENCES [dbo].[Address] ([AddressID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Address]
GO
/****** Object:  ForeignKey [FK_CallLog_Administrator]    Script Date: 06/03/2018 17:06:57 ******/
ALTER TABLE [dbo].[CallLog]  WITH CHECK ADD  CONSTRAINT [FK_CallLog_Administrator] FOREIGN KEY([AdministratorID])
REFERENCES [dbo].[Administrator] ([ID])
GO
ALTER TABLE [dbo].[CallLog] CHECK CONSTRAINT [FK_CallLog_Administrator]
GO
/****** Object:  ForeignKey [FK_Installation_InstalledProduct]    Script Date: 06/03/2018 17:06:57 ******/
ALTER TABLE [dbo].[Installation]  WITH CHECK ADD  CONSTRAINT [FK_Installation_InstalledProduct] FOREIGN KEY([OrderID], [ProductCode])
REFERENCES [dbo].[InstalledProduct] ([OrderID], [ProductCode])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Installation] CHECK CONSTRAINT [FK_Installation_InstalledProduct]
GO
/****** Object:  ForeignKey [FK_Installation_Technician]    Script Date: 06/03/2018 17:06:57 ******/
ALTER TABLE [dbo].[Installation]  WITH CHECK ADD  CONSTRAINT [FK_Installation_Technician] FOREIGN KEY([TechnicianID])
REFERENCES [dbo].[Technician] ([ID])
GO
ALTER TABLE [dbo].[Installation] CHECK CONSTRAINT [FK_Installation_Technician]
GO
/****** Object:  ForeignKey [FK_Maintenance_InstalledProduct]    Script Date: 06/03/2018 17:06:57 ******/
ALTER TABLE [dbo].[Maintenance]  WITH CHECK ADD  CONSTRAINT [FK_Maintenance_InstalledProduct] FOREIGN KEY([OrderID], [ProductCode])
REFERENCES [dbo].[InstalledProduct] ([OrderID], [ProductCode])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Maintenance] CHECK CONSTRAINT [FK_Maintenance_InstalledProduct]
GO
/****** Object:  ForeignKey [FK_Maintenance_Technician]    Script Date: 06/03/2018 17:06:57 ******/
ALTER TABLE [dbo].[Maintenance]  WITH CHECK ADD  CONSTRAINT [FK_Maintenance_Technician] FOREIGN KEY([TechnicianID])
REFERENCES [dbo].[Technician] ([ID])
GO
ALTER TABLE [dbo].[Maintenance] CHECK CONSTRAINT [FK_Maintenance_Technician]
GO
/****** Object:  ForeignKey [FK_Login_Administrator]    Script Date: 06/03/2018 17:06:57 ******/
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_Administrator] FOREIGN KEY([AdministratorID])
REFERENCES [dbo].[Administrator] ([ID])
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FK_Login_Administrator]
GO
/****** Object:  ForeignKey [FK_Product_Package]    Script Date: 06/03/2018 17:06:57 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Package] FOREIGN KEY([PackageCode])
REFERENCES [dbo].[Package] ([PackageCode])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Package]
GO
/****** Object:  ForeignKey [FK_Product_Product]    Script Date: 06/03/2018 17:06:57 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Product] FOREIGN KEY([ManufacturerID])
REFERENCES [dbo].[Manufacturer] ([ManufacturerID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Product]
GO
/****** Object:  ForeignKey [FK_ServiceTicket_CallLog]    Script Date: 06/03/2018 17:06:57 ******/
ALTER TABLE [dbo].[ServiceTicket]  WITH CHECK ADD  CONSTRAINT [FK_ServiceTicket_CallLog] FOREIGN KEY([CallLogID])
REFERENCES [dbo].[CallLog] ([CallLogID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ServiceTicket] CHECK CONSTRAINT [FK_ServiceTicket_CallLog]
GO
/****** Object:  ForeignKey [FK_ProductComponent_Component]    Script Date: 06/03/2018 17:06:57 ******/
ALTER TABLE [dbo].[ProductComponent]  WITH CHECK ADD  CONSTRAINT [FK_ProductComponent_Component] FOREIGN KEY([ComponentCode])
REFERENCES [dbo].[Component] ([ComponentCode])
GO
ALTER TABLE [dbo].[ProductComponent] CHECK CONSTRAINT [FK_ProductComponent_Component]
GO
/****** Object:  ForeignKey [FK_ProductComponent_Product]    Script Date: 06/03/2018 17:06:57 ******/
ALTER TABLE [dbo].[ProductComponent]  WITH CHECK ADD  CONSTRAINT [FK_ProductComponent_Product] FOREIGN KEY([ProductCode])
REFERENCES [dbo].[Product] ([ProductCode])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductComponent] CHECK CONSTRAINT [FK_ProductComponent_Product]
GO
/****** Object:  ForeignKey [FK_Order_Client]    Script Date: 06/03/2018 17:06:58 ******/
ALTER TABLE [dbo].[tblOrder]  WITH CHECK ADD  CONSTRAINT [FK_Order_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblOrder] CHECK CONSTRAINT [FK_Order_Client]
GO
/****** Object:  ForeignKey [FK_OrderDetail_Order]    Script Date: 06/03/2018 17:06:58 ******/
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[tblOrder] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
/****** Object:  ForeignKey [FK_OrderDetail_ProductComponent]    Script Date: 06/03/2018 17:06:58 ******/
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_ProductComponent] FOREIGN KEY([ProductCode], [ComponentCode])
REFERENCES [dbo].[ProductComponent] ([ProductCode], [ComponentCode])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_ProductComponent]
GO
/****** Object:  ForeignKey [FK_Correction_InstalledProduct]    Script Date: 06/03/2018 17:06:58 ******/
ALTER TABLE [dbo].[Correction]  WITH CHECK ADD  CONSTRAINT [FK_Correction_InstalledProduct] FOREIGN KEY([OrderID], [ProductCode])
REFERENCES [dbo].[InstalledProduct] ([OrderID], [ProductCode])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Correction] CHECK CONSTRAINT [FK_Correction_InstalledProduct]
GO
/****** Object:  ForeignKey [FK_Correction_ServiceTicket]    Script Date: 06/03/2018 17:06:58 ******/
ALTER TABLE [dbo].[Correction]  WITH CHECK ADD  CONSTRAINT [FK_Correction_ServiceTicket] FOREIGN KEY([ServiceTicketID])
REFERENCES [dbo].[ServiceTicket] ([ServiceTicketID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Correction] CHECK CONSTRAINT [FK_Correction_ServiceTicket]
GO
/****** Object:  ForeignKey [FK_Correction_Technician]    Script Date: 06/03/2018 17:06:58 ******/
ALTER TABLE [dbo].[Correction]  WITH CHECK ADD  CONSTRAINT [FK_Correction_Technician] FOREIGN KEY([TechnicianID])
REFERENCES [dbo].[Technician] ([ID])
GO
ALTER TABLE [dbo].[Correction] CHECK CONSTRAINT [FK_Correction_Technician]
GO
