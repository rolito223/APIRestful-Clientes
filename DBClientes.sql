USE [master]
GO

/****** Object:  Database [DBClientes]    Script Date: 15/11/2023 18:24:42 ******/
CREATE DATABASE [DBClientes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBClientes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBClientes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBClientes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBClientes.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBClientes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [DBClientes] SET ANSI_NULL_DEFAULT ON 
GO

ALTER DATABASE [DBClientes] SET ANSI_NULLS ON 
GO

ALTER DATABASE [DBClientes] SET ANSI_PADDING ON 
GO

ALTER DATABASE [DBClientes] SET ANSI_WARNINGS ON 
GO

ALTER DATABASE [DBClientes] SET ARITHABORT ON 
GO

ALTER DATABASE [DBClientes] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [DBClientes] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [DBClientes] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [DBClientes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [DBClientes] SET CURSOR_DEFAULT  LOCAL 
GO

ALTER DATABASE [DBClientes] SET CONCAT_NULL_YIELDS_NULL ON 
GO

ALTER DATABASE [DBClientes] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [DBClientes] SET QUOTED_IDENTIFIER ON 
GO

ALTER DATABASE [DBClientes] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [DBClientes] SET  DISABLE_BROKER 
GO

ALTER DATABASE [DBClientes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [DBClientes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [DBClientes] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [DBClientes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [DBClientes] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [DBClientes] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [DBClientes] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [DBClientes] SET RECOVERY FULL 
GO

ALTER DATABASE [DBClientes] SET  MULTI_USER 
GO

ALTER DATABASE [DBClientes] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [DBClientes] SET DB_CHAINING OFF 
GO

ALTER DATABASE [DBClientes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [DBClientes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [DBClientes] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [DBClientes] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [DBClientes] SET QUERY_STORE = OFF
GO

ALTER DATABASE [DBClientes] SET  READ_WRITE 
GO

