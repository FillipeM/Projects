USE [master]
GO
/****** Object:  Database [restaurante]    Script Date: 03/05/2018 20:11:37 ******/
CREATE DATABASE [restaurante]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'restaurante', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\restaurante.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'restaurante_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\restaurante_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [restaurante] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [restaurante].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [restaurante] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [restaurante] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [restaurante] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [restaurante] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [restaurante] SET ARITHABORT OFF 
GO
ALTER DATABASE [restaurante] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [restaurante] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [restaurante] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [restaurante] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [restaurante] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [restaurante] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [restaurante] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [restaurante] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [restaurante] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [restaurante] SET  DISABLE_BROKER 
GO
ALTER DATABASE [restaurante] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [restaurante] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [restaurante] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [restaurante] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [restaurante] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [restaurante] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [restaurante] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [restaurante] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [restaurante] SET  MULTI_USER 
GO
ALTER DATABASE [restaurante] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [restaurante] SET DB_CHAINING OFF 
GO
ALTER DATABASE [restaurante] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [restaurante] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [restaurante] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [restaurante] SET QUERY_STORE = OFF
GO
USE [restaurante]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
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
USE [restaurante]
GO
/****** Object:  Table [dbo].[tabPrato]    Script Date: 03/05/2018 20:11:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tabPrato](
	[codPrato] [int] IDENTITY(1,1) NOT NULL,
	[codRestaurante] [int] NOT NULL,
	[nomePrato] [varchar](255) NOT NULL,
	[valor] [decimal](18, 4) NOT NULL,
	[DELETED] [bit] NOT NULL,
 CONSTRAINT [PK_tabPrato] PRIMARY KEY CLUSTERED 
(
	[codPrato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tabRestaurante]    Script Date: 03/05/2018 20:11:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tabRestaurante](
	[codRestaurante] [int] IDENTITY(1,1) NOT NULL,
	[nomeRestaurante] [varchar](255) NOT NULL,
	[DELETED] [bit] NOT NULL,
 CONSTRAINT [PK_tabRestaurante] PRIMARY KEY CLUSTERED 
(
	[codRestaurante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tabPrato] ADD  CONSTRAINT [DF_tabPrato_DELETED]  DEFAULT ((0)) FOR [DELETED]
GO
ALTER TABLE [dbo].[tabRestaurante] ADD  CONSTRAINT [DF_tabRestaurante_DELETED]  DEFAULT ((0)) FOR [DELETED]
GO
ALTER TABLE [dbo].[tabPrato]  WITH CHECK ADD  CONSTRAINT [FK_tabPrato_tabRestaurante] FOREIGN KEY([codRestaurante])
REFERENCES [dbo].[tabRestaurante] ([codRestaurante])
GO
ALTER TABLE [dbo].[tabPrato] CHECK CONSTRAINT [FK_tabPrato_tabRestaurante]
GO
USE [master]
GO
ALTER DATABASE [restaurante] SET  READ_WRITE 
GO
