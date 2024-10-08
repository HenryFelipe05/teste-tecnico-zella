USE [master]
GO
/****** Object:  Database [TodoDB]    Script Date: 24/09/2024 16:23:38 ******/
CREATE DATABASE [TodoDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TodoDB', FILENAME = N'C:\Users\inliv\TodoDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TodoDB_log', FILENAME = N'C:\Users\inliv\TodoDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TodoDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TodoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TodoDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TodoDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TodoDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TodoDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TodoDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TodoDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TodoDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TodoDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TodoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TodoDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TodoDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TodoDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TodoDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TodoDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TodoDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TodoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TodoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TodoDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TodoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TodoDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TodoDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TodoDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TodoDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TodoDB] SET  MULTI_USER 
GO
ALTER DATABASE [TodoDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TodoDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TodoDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TodoDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TodoDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TodoDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TodoDB] SET QUERY_STORE = OFF
GO
USE [TodoDB]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 24/09/2024 16:23:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genero](
	[CodigoGenero] [int] IDENTITY(1,1) NOT NULL,
	[DescricaoGenero] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoGenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusTarefa]    Script Date: 24/09/2024 16:23:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusTarefa](
	[CodigoStatusTarefa] [int] IDENTITY(1,1) NOT NULL,
	[DescricaoStatusTarefa] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoStatusTarefa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarefa]    Script Date: 24/09/2024 16:23:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarefa](
	[CodigoTarefa] [int] IDENTITY(1,1) NOT NULL,
	[CodigoUsuario] [int] NULL,
	[NomeTarefa] [nvarchar](255) NOT NULL,
	[DescricaoTarefa] [nvarchar](500) NULL,
	[CodigoStatusTarefa] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoTarefa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 24/09/2024 16:23:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[CodigoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Senha] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[CodigoGenero] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Genero] ON 

INSERT [dbo].[Genero] ([CodigoGenero], [DescricaoGenero]) VALUES (1, N'Masculino')
INSERT [dbo].[Genero] ([CodigoGenero], [DescricaoGenero]) VALUES (2, N'Feminino')
INSERT [dbo].[Genero] ([CodigoGenero], [DescricaoGenero]) VALUES (3, N'Não Informar')
SET IDENTITY_INSERT [dbo].[Genero] OFF
GO
SET IDENTITY_INSERT [dbo].[StatusTarefa] ON 

INSERT [dbo].[StatusTarefa] ([CodigoStatusTarefa], [DescricaoStatusTarefa]) VALUES (1, N'Pendente')
INSERT [dbo].[StatusTarefa] ([CodigoStatusTarefa], [DescricaoStatusTarefa]) VALUES (2, N'Concluida')
SET IDENTITY_INSERT [dbo].[StatusTarefa] OFF
GO
SET IDENTITY_INSERT [dbo].[Tarefa] ON 

INSERT [dbo].[Tarefa] ([CodigoTarefa], [CodigoUsuario], [NomeTarefa], [DescricaoTarefa], [CodigoStatusTarefa]) VALUES (5, 1, N'Criar estilo da barra de navegação', N'Adicionar um estilo para a barra de navegação adicionando icones estilizados nos botões', 2)
INSERT [dbo].[Tarefa] ([CodigoTarefa], [CodigoUsuario], [NomeTarefa], [DescricaoTarefa], [CodigoStatusTarefa]) VALUES (9, 1, N'Ajustar e organzar os estilos da página de tarefas', N'unificar blocos de codigo repetidos, ajustar identação, ajustar nomes de metodos, padronizar o código em geral - Feito', 1)
INSERT [dbo].[Tarefa] ([CodigoTarefa], [CodigoUsuario], [NomeTarefa], [DescricaoTarefa], [CodigoStatusTarefa]) VALUES (10, 2, N'Ir ao mercado', N'Comprar doce de leite, refrigerante zero, garrafa de água, 5 maçãs, 200g de morango', 1)
SET IDENTITY_INSERT [dbo].[Tarefa] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([CodigoUsuario], [Senha], [Email], [CodigoGenero]) VALUES (1, N'henry123', N'henry@email.com', 1)
INSERT [dbo].[Usuario] ([CodigoUsuario], [Senha], [Email], [CodigoGenero]) VALUES (2, N'cla123', N'clarissa@email.com', 2)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuario__A9D10534BE9615CF]    Script Date: 24/09/2024 16:23:38 ******/
ALTER TABLE [dbo].[Usuario] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tarefa]  WITH CHECK ADD FOREIGN KEY([CodigoStatusTarefa])
REFERENCES [dbo].[StatusTarefa] ([CodigoStatusTarefa])
GO
ALTER TABLE [dbo].[Tarefa]  WITH CHECK ADD FOREIGN KEY([CodigoUsuario])
REFERENCES [dbo].[Usuario] ([CodigoUsuario])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([CodigoGenero])
REFERENCES [dbo].[Genero] ([CodigoGenero])
GO
USE [master]
GO
ALTER DATABASE [TodoDB] SET  READ_WRITE 
GO
