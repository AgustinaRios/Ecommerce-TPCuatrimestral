use master
go
drop database ECOMMERCE_TP_DB
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
	[Activo][bit]NOT NULL DEFAULT 1
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
CREATE TABLE [dbo].[ALBUMES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NULL,
	[IdArtista] [int] NULL,
	[FechaLanzamiento] [date] NULL,
	[ImgTapa] [varchar](250) NULL,
	[ImgContratapa] [varchar](250) NULL,
	[Precio][money]NULL,
	[IdGenero] [int] NULL,
	[IdCategoria][int]NULL,
	[Activo] [bit] default 1
 CONSTRAINT [PK_ALBUMES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE CATEGORIA(
	
	Id int not null primary key identity (0, 1),
	Descripcion varchar (50) not null ,
	[Activo] [bit] default 1)
	GO
	CREATE TABLE ARTISTA(
	
	Id int not null primary key identity (1, 1),
	Nombre varchar (50) not null unique ,
	Activo bit not null default 1)
	GO


ALTER TABLE ALBUMES 
ADD CONSTRAINT FK_Albumes_Categoria foreign key (IdCategoria) references CATEGORIA(Id)
go
ALTER TABLE ALBUMES 
ADD CONSTRAINT FK_Albumes_Genero foreign key (IdGenero) references GENEROS(Id)
ALTER TABLE ALBUMES 
ADD CONSTRAINT FK_Albumes_Artista foreign key (IdArtista) references ARTISTA(Id)
go
create procedure sp_modificarAlbum
@Id int,
@Titulo varchar(50),
@IdArtista int,
@FechaLanzamiento date,
@ImgTapa varchar(250),
@ImgContratapa varchar(250),
@Precio money,
@IdGenero int,
@IdCategoria int
as 
update ALBUMES  set Titulo=@Titulo,IdArtista=@IdArtista,FechaLanzamiento=@FechaLanzamiento,ImgTapa=@ImgTapa,ImgContratapa=@ImgContratapa,
Precio=@Precio,IdGenero=@IdGenero,IdCategoria=@IdCategoria where Id=@id
go
CREATE TABLE USUARIOS (
    Id int identity(1,1) NOT NULL,
    Nombre varchar(50) NULL,
    Apellido varchar(50) NULL,
    Email varchar(50) NULL unique,
    Pass varchar(50) NULL,
    FechaCreacion date NULL,
    Direccion varchar (100) null,
    Localidad varchar (100) null,
    Provincia varchar (100) null, 
    Administrador bit not null default 0,
    Activo bit not null default 1

CONSTRAINT [PK_USUARIOS] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)) ON [PRIMARY]
 go
 
CREATE TABLE FORMA_PAGO(
	
	Id int not null primary key identity (1, 1),
	Descripcion varchar (50)not null unique)
    go

	create table FORMA_ENTREGA (
    Id int not null primary key identity (1,1),
    Descripcion varchar (50) not null unique
    )
    go
    create table ESTADO_PEDIDO (
    Id int not null primary key identity (1,1),
    Descripcion varchar (50) not null unique
)
GO

create procedure InsertarNuevo (
 
 @Nombre varchar(50),
 @Apellido varchar(50),
 @Email varchar (50),
 @Pass varchar (50),
 @Dire varchar (100),
 @Localidad varchar (100),
 @Prov varchar (100)
 )
As
insert into USUARIOS (Nombre,Apellido,Email,Pass,FechaCreacion,Direccion,Localidad,Provincia,Administrador,Activo)
 output inserted.Id values (@Nombre,@Apellido,@Email,@Pass,GETDATE(),@Dire,@Localidad,@Prov,0,1)


go
INSERT INTO FORMA_ENTREGA values ('Delivery'),('Retiro')
go
insert into FORMA_PAGO values ('Efectivo'),('Tarjeta de Credito'),('Mercado Pago')
go
insert into ESTADO_PEDIDO values ('En preparacion'),('Listo para Entrega'),('Producto Entregado')
go
 insert into GENEROS (Descripcion)values ('Rock'), ('Pop'), ('Cl�sico'), ('Tango'), ('Funk'),('Jazz'),('Folklore'),
 ('Reggae'),('Hip Hop'),('Electr�nica'),('R&B'),('Country'),('Salsa')
 go
 insert into CATEGORIA(Descripcion)values (''),('Los mas buscados'), ('Los mas vendidos'), ('Los mas recomendados')
go
insert into ARTISTA(Nombre)values ('QUEEN'), ('DAVID BOWIE'), ('CHARLY GARCIA'),('SODA STEREO'),
('FITO PAEZ'),('MERCEDES SOSA'),('LOS ABUELOS DE LA NADA'),('THE BEATLES'),('U2'),('NIRVANA'),('MICHAEL JACKSON'),
('PINK FLOYD'),('THE ROLLING STONES'),('ELTON JOHN'),('METALLICA'),('PRINCE'),('BOB MARLEY'),('AC DC'),('MADONNA'),
('LED ZEPPELIN')
go
INSERT INTO ALBUMES (Titulo, IdArtista, FechaLanzamiento, ImgTapa, ImgContratapa, Precio, IdGenero, IdCategoria)
VALUES 
('Sound And Vision', 2, '1971-03-11', 'https://images.squarespace-cdn.com/content/v1/5a70fa14e45a7c7dd2fadad0/1519497173710-PXUY3JHRWPHINW9RTVUD/1969_manofwords.jpg?format=750w', 'https://1.bp.blogspot.com/-Lo1FX9Z0PS8/XzMDeRabQjI/AAAAAAAADz8/Uists2RHv3km2kJwLV9h4kWpLdhgdurnwCLcBGAsYHQ/s1600/low.jpg', 7500.00, 1, 3),
('Clics Modernos', 3, '1983-02-12', 'https://upload.wikimedia.org/wikipedia/commons/thumb/8/8e/Clics-modernos-charly-garcia-front.jpg/640px-Clics-modernos-charly-garcia-front.jpg', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcShlWTSI2TUDayo6QQIEV7ZS4RK5zvEmp05Gg&usqp=CAU', 5500, 1, 3),
('El Amor despues del amor (2LP)', 5, '2019-06-01', 'https://http2.mlstatic.com/D_NQ_NP_834079-MLA54966560635_042023-W.jpg', 'https://http2.mlstatic.com/D_NQ_NP_889938-MLA48948891521_012022-O.webp', 19392, 1,2),
('Soda Stereo', 4, '2015-11-01', 'https://http2.mlstatic.com/D_NQ_NP_863459-MLA48596431326_122021-O.webp', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSnwsW-LClg87hvvxrOCAetLa3nJ1jllniy9g&usqp=CAU', 14900, 1,2),
('Cantora 1 (2LP)', 6, '2017-11-01', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcmcspn-2qadfwn8s561CUEflepWiWCwNproo0tDS1OLqzqSMkrZwwMDuFgFiVIxTtZFM&usqp=CAU', 'https://http2.mlstatic.com/D_NQ_NP_898106-MLA49844455670_052022-O.webp',21800,7,3),
('Back in Black', 18, '1980-07-25', 'https://cdn1.eldia.com/072021/1627255515074.jpg', '', 8500.00, 1, 2),
('Thriller', 11, '1982-11-30', 'https://www.mmx.com.ar/media/k2/items/cache/e615c787b2f85cf06510c8d1eb939a8d_L.jpg', '', 9200.00, 6, 2),
('The Dark Side of the Moon', 12, '1973-03-01', 'https://www.elciudadanoweb.com/wp-content/uploads/2023/01/230119-pinkfloyd-darkside50-feat.jpg', '', 7800.00, 3, 2),
('Like a Virgin', 19, '1984-11-12', 'https://upload.wikimedia.org/wikipedia/en/1/17/LikeAVirgin1984.png', '', 6900.00, 2, 2),
('Led Zeppelin IV', 20, '1971-11-08', 'https://upload.wikimedia.org/wikipedia/en/2/26/Led_Zeppelin_-_Led_Zeppelin_IV.jpg', '', 7700.00, 1, 2),
('The Wall', 12, '1979-11-30', 'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b1/The_Wall_Cover.svg/800px-The_Wall_Cover.svg.png', '', 8500.00, 3, 2),
('Greatest Hits', 1, '1998-11-03', 'https://www.udiscovermusic.com/wp-content/uploads/2017/11/Queen-Greatest-Hits.jpg', '', 6800.00, 1, 3);


go
 insert into USUARIOS (Nombre,Apellido,Email,Pass,FechaCreacion,Administrador,Activo)
values ('adm','adm','adm@adm.com','adm',GETDATE(),1,1)
