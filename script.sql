USE [master]
GO
/****** Object:  Database [customersdb]    Script Date: 8/27/2019 5:01:46 PM ******/
CREATE DATABASE [customersdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'customersdb', FILENAME = N'C:\Users\vlady\customersdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'customersdb_log', FILENAME = N'C:\Users\vlady\customersdb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [customersdb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [customersdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [customersdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [customersdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [customersdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [customersdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [customersdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [customersdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [customersdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [customersdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [customersdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [customersdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [customersdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [customersdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [customersdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [customersdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [customersdb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [customersdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [customersdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [customersdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [customersdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [customersdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [customersdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [customersdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [customersdb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [customersdb] SET  MULTI_USER 
GO
ALTER DATABASE [customersdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [customersdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [customersdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [customersdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [customersdb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [customersdb] SET QUERY_STORE = OFF
GO
USE [customersdb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [customersdb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/27/2019 5:01:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 8/27/2019 5:01:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[PhoneNo] [int] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 8/27/2019 5:01:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[CurrencyCode] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[CustomerId] [int] NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190827151209_InitialMigration', N'2.2.6-servicing-10079')
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [Name], [Email], [PhoneNo]) VALUES (1, N'Julie', N'jhandrahan0@paypal.com', 1)
INSERT [dbo].[Customers] ([Id], [Name], [Email], [PhoneNo]) VALUES (2, N'Boyd', N'bsessions1@biblegateway.com', 2)
INSERT [dbo].[Customers] ([Id], [Name], [Email], [PhoneNo]) VALUES (3, N'Steven', N'sgarfath2@indiegogo.com', 3)
INSERT [dbo].[Customers] ([Id], [Name], [Email], [PhoneNo]) VALUES (4, N'Delmer', N'dadger3@altervista.org', 4)
INSERT [dbo].[Customers] ([Id], [Name], [Email], [PhoneNo]) VALUES (5, N'Ursala', N'ukloss4@example.com', 5)
INSERT [dbo].[Customers] ([Id], [Name], [Email], [PhoneNo]) VALUES (6, N'Firstname LastName', N'user @domain.com', 5)
SET IDENTITY_INSERT [dbo].[Customers] OFF
SET IDENTITY_INSERT [dbo].[Transaction] ON 

INSERT [dbo].[Transaction] ([Id], [Date], [Amount], [CurrencyCode], [Status], [CustomerId]) VALUES (2, CAST(N'2008-11-11T00:00:00.0000000' AS DateTime2), CAST(1.20 AS Decimal(18, 2)), N'USD', 1, 6)
SET IDENTITY_INSERT [dbo].[Transaction] OFF
/****** Object:  Index [IX_Transaction_CustomerId]    Script Date: 8/27/2019 5:01:46 PM ******/
CREATE NONCLUSTERED INDEX [IX_Transaction_CustomerId] ON [dbo].[Transaction]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Customers_CustomerId]
GO
USE [master]
GO
ALTER DATABASE [customersdb] SET  READ_WRITE 
GO
