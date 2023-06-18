use master
go
create database ECOMMERCE_TP_DB
go
use ECOMMERCE_TP_DB
go

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
insert into GENEROS values ('Rock'), ('Pop'), ('Cl�sico'), ('Tango'), ('Funk'),('Jazz')
GO
CREATE TABLE [dbo].[ALBUMES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NULL,
	[IdArtista] [int] NULL,
	[FechaLanzamiento] [date] NULL,
	[ImgTapa] [varchar](250) NULL,
	[ImgContratapa] [varchar](250) NULL,
	[Precio][money]NULL,
	[IdGenero] [int] NULL,
	[IdCategoria][int]NULL
 CONSTRAINT [PK_ALBUMES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO ALBUMES values ('Sound And Vision',2,'11-03-1971','https://images.squarespace-cdn.com/content/v1/5a70fa14e45a7c7dd2fadad0/1519497173710-PXUY3JHRWPHINW9RTVUD/1969_manofwords.jpg?format=750w','https://1.bp.blogspot.com/-Lo1FX9Z0PS8/XzMDeRabQjI/AAAAAAAADz8/Uists2RHv3km2kJwLV9h4kWpLdhgdurnwCLcBGAsYHQ/s1600/low.jpg',7500.00,1,3)
INSERT INTO ALBUMES values ('Clics Modernos',3,'12-02-1983','https://upload.wikimedia.org/wikipedia/commons/thumb/8/8e/Clics-modernos-charly-garcia-front.jpg/640px-Clics-modernos-charly-garcia-front.jpg','https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcShlWTSI2TUDayo6QQIEV7ZS4RK5zvEmp05Gg&usqp=CAU',5500,1,3)
go

CREATE TABLE CATEGORIA(
	
	Id int not null primary key identity (1, 1),
	Descripcion varchar (50) not null )
	GO
	CREATE TABLE ARTISTA(
	
	Id int not null primary key identity (1, 1),
	Nombre varchar (50) not null unique )
	GO
insert into CATEGORIA(Descripcion)values ('Lo mas buscados'), ('Lo mas vendidos'), ('Lo mas recomendados')
go
insert into ARTISTA(Nombre)values ('QUEEN'), ('DAVID BOWIE'), ('CHARLY GARCIA'),('SODA STEREO')
GO

ALTER TABLE ALBUMES 
ADD CONSTRAINT FK_Albumes_Categoria foreign key (IdCategoria) references CATEGORIA(Id)
go
ALTER TABLE ALBUMES 
ADD CONSTRAINT FK_Albumes_Genero foreign key (IdGenero) references GENEROS(Id)
ALTER TABLE ALBUMES 
ADD CONSTRAINT FK_Albumes_Artista foreign key (IdArtista) references ARTISTA(Id)

insert into GENEROS (Descripcion) values ('Folklore')


insert into ARTISTA (Nombre)
VALUES ('FITO PAEZ'),('MERCEDES SOSA'),('LOS ABUELOS DE LA NADA'),('THE BEATLES'),('U2'),('HARRY STYLES'),('MICHAEL JACKSON')

insert into ALBUMES (Titulo,IdArtista,FechaLanzamiento,ImgTapa,ImgContratapa,Precio,IdGenero)
VALUES ('EL AMOR DESPUES DEL AMOR (2LP)',5,'2019/06/01','https://http2.mlstatic.com/D_NQ_NP_834079-MLA54966560635_042023-W.jpg','https://http2.mlstatic.com/D_NQ_NP_889938-MLA48948891521_012022-O.webp',19392,1),
('SODA STEREO',4,'01/11/2015','https://http2.mlstatic.com/D_NQ_NP_863459-MLA48596431326_122021-O.webp','https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSnwsW-LClg87hvvxrOCAetLa3nJ1jllniy9g&usqp=CAU',14900,1),
('CANTORA 1 (2LP)',6,'01/11/2017','https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcmcspn-2qadfwn8s561CUEflepWiWCwNproo0tDS1OLqzqSMkrZwwMDuFgFiVIxTtZFM&usqp=CAU','https://http2.mlstatic.com/D_NQ_NP_898106-MLA49844455670_052022-O.webp',21880,7),
('BOHEMIAN RHAPSODY',1,NULL,'https://contentv2.tap-commerce.com/cover/large/50087408435_1.jpg?id_com=1156','https://tiendateatral.com/6549-large_default/cd-bohemian-rhapsody-original-soundtrack.jpg',1810,1),
('FINE LINE',10,'2019','https://http2.mlstatic.com/D_NQ_NP_832207-MLA40089208872_122019-O.jpg',NULL,43200,2)