

use master
go
create database ECOMMERCE_TP_DB
go
USE ECOMMERCE_TP_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[GENEROS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_GENEROS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
insert into GENEROS values ('Rock'), ('Pop'), ('Clásico'), ('Tango'), ('Funk'),('Jazz')
GO
CREATE TABLE [dbo].[ALBUMES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NULL,
	[Artista] [varchar](50) NULL,
	[FechaLanzamiento] [date] NULL,
	[ImgTapa] [varchar](250) NULL,
	[ImgContratapa] [varchar](250) NULL,
	[IdGenero] [int] NULL,
	[IdCategoria][int]NULL
 CONSTRAINT [PK_ALBUMES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO ALBUMES values ('Sound And Vision','David Bowie','11-03-1971','https://images.squarespace-cdn.com/content/v1/5a70fa14e45a7c7dd2fadad0/1519497173710-PXUY3JHRWPHINW9RTVUD/1969_manofwords.jpg?format=750w','https://1.bp.blogspot.com/-Lo1FX9Z0PS8/XzMDeRabQjI/AAAAAAAADz8/Uists2RHv3km2kJwLV9h4kWpLdhgdurnwCLcBGAsYHQ/s1600/low.jpg',1,3)
INSERT INTO ALBUMES values ('Clics Modernos','Charly Garcia','12-02-1983','https://upload.wikimedia.org/wikipedia/commons/thumb/8/8e/Clics-modernos-charly-garcia-front.jpg/640px-Clics-modernos-charly-garcia-front.jpg','https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcShlWTSI2TUDayo6QQIEV7ZS4RK5zvEmp05Gg&usqp=CAU',1,3)