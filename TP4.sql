USE [master]
GO
/****** Object:  Database [AgenciaTP4]    Script Date: 27/06/2021 17:02:05 ******/
CREATE DATABASE [AgenciaTP4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AgenciaTP4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AgenciaTP4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AgenciaTP4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AgenciaTP4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AgenciaTP4] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AgenciaTP4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AgenciaTP4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AgenciaTP4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AgenciaTP4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AgenciaTP4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AgenciaTP4] SET ARITHABORT OFF 
GO
ALTER DATABASE [AgenciaTP4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AgenciaTP4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AgenciaTP4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AgenciaTP4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AgenciaTP4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AgenciaTP4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AgenciaTP4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AgenciaTP4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AgenciaTP4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AgenciaTP4] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AgenciaTP4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AgenciaTP4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AgenciaTP4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AgenciaTP4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AgenciaTP4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AgenciaTP4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AgenciaTP4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AgenciaTP4] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AgenciaTP4] SET  MULTI_USER 
GO
ALTER DATABASE [AgenciaTP4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AgenciaTP4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AgenciaTP4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AgenciaTP4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AgenciaTP4] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AgenciaTP4] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AgenciaTP4] SET QUERY_STORE = OFF
GO
USE [AgenciaTP4]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 27/06/2021 17:02:05 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alojamientos]    Script Date: 27/06/2021 17:02:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alojamientos](
	[pk] [int] IDENTITY(1,1) NOT NULL,
	[barrio] [varchar](50) NULL,
	[baños] [int] NOT NULL,
	[cantPersonas] [int] NOT NULL,
	[ciudad] [varchar](50) NULL,
	[codigo] [int] NOT NULL,
	[estrellas] [int] NOT NULL,
	[habitaciones] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[precioDia] [int] NOT NULL,
	[precioPorPersona] [int] NOT NULL,
	[tipo] [varchar](50) NULL,
	[tv] [bit] NOT NULL,
 CONSTRAINT [PK_Alojamientos] PRIMARY KEY CLUSTERED 
(
	[pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 27/06/2021 17:02:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[pk] [int] IDENTITY(1,1) NOT NULL,
	[fdesde] [datetime] NOT NULL,
	[fhasta] [datetime] NOT NULL,
	[id] [int] NOT NULL,
	[personaint] [int] NOT NULL,
	[precio] [int] NOT NULL,
	[propiedadint] [int] NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 27/06/2021 17:02:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[num_usr] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [int] NOT NULL,
	[Mail] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[bloqueado] [bit] NOT NULL,
	[esAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[num_usr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210619220013_Usuario', N'5.0.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210619220245_Alojamiento', N'5.0.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210619220337_Reserva', N'5.0.7')
GO
SET IDENTITY_INSERT [dbo].[Alojamientos] ON 
GO
INSERT [dbo].[Alojamientos] ([pk], [barrio], [baños], [cantPersonas], [ciudad], [codigo], [estrellas], [habitaciones], [nombre], [precioDia], [precioPorPersona], [tipo], [tv]) VALUES (1, N'General San Martin', 1, 5, N'Villa Lynch', 1, 3, 2, N'El Manquito', 1526, 0, N'Cabaña', 1)
GO
INSERT [dbo].[Alojamientos] ([pk], [barrio], [baños], [cantPersonas], [ciudad], [codigo], [estrellas], [habitaciones], [nombre], [precioDia], [precioPorPersona], [tipo], [tv]) VALUES (2, N'Billinghurst', 1, 6, N'General San Martin', 2, 4, 3, N'Zurdito', 0, 1424, N'Hotel', 1)
GO
INSERT [dbo].[Alojamientos] ([pk], [barrio], [baños], [cantPersonas], [ciudad], [codigo], [estrellas], [habitaciones], [nombre], [precioDia], [precioPorPersona], [tipo], [tv]) VALUES (3, N'Capital Federal', 2, 5, N'Nuñez', 3, 5, 2, N'Viper', 0, 2000, N'Hotel', 1)
GO
INSERT [dbo].[Alojamientos] ([pk], [barrio], [baños], [cantPersonas], [ciudad], [codigo], [estrellas], [habitaciones], [nombre], [precioDia], [precioPorPersona], [tipo], [tv]) VALUES (4, N'Capital Federal', 1, 3, N'Flores', 4, 3, 1, N'La Nueva Rusia', 1200, 0, N'Cabaña', 1)
GO
SET IDENTITY_INSERT [dbo].[Alojamientos] OFF
GO
SET IDENTITY_INSERT [dbo].[Reserva] ON 
GO
INSERT [dbo].[Reserva] ([pk], [fdesde], [fhasta], [id], [personaint], [precio], [propiedadint]) VALUES (1011, CAST(N'2021-06-27T00:00:00.000' AS DateTime), CAST(N'2021-06-30T00:00:00.000' AS DateTime), 0, 123456, 3052, 1)
GO
INSERT [dbo].[Reserva] ([pk], [fdesde], [fhasta], [id], [personaint], [precio], [propiedadint]) VALUES (1012, CAST(N'2021-06-27T00:00:00.000' AS DateTime), CAST(N'2021-06-30T00:00:00.000' AS DateTime), 2, 123456, 3052, 1)
GO
SET IDENTITY_INSERT [dbo].[Reserva] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 
GO
INSERT [dbo].[Usuarios] ([num_usr], [DNI], [Mail], [Nombre], [Password], [bloqueado], [esAdmin]) VALUES (1, 39104528, N'basualdo1995@gmail.com', N'Lucas', N'123456', 0, 1)
GO
INSERT [dbo].[Usuarios] ([num_usr], [DNI], [Mail], [Nombre], [Password], [bloqueado], [esAdmin]) VALUES (2, 39449216, N'@prueba', N'Alejo', N'123456', 0, 0)
GO
INSERT [dbo].[Usuarios] ([num_usr], [DNI], [Mail], [Nombre], [Password], [bloqueado], [esAdmin]) VALUES (3, 123456, N'@prueba', N'prueba', N'123456', 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
USE [master]
GO
ALTER DATABASE [AgenciaTP4] SET  READ_WRITE 
GO
