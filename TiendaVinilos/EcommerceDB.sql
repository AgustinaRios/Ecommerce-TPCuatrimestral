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
	
	Id int not null primary key identity (1, 1),
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
@IdCategoria int,
@Activo bit
as 
update ALBUMES  set Titulo=@Titulo,IdArtista=@IdArtista,FechaLanzamiento=@FechaLanzamiento,ImgTapa=@ImgTapa,ImgContratapa=@ImgContratapa,
Precio=@Precio,IdGenero=@IdGenero,IdCategoria=@IdCategoria,Activo=@Activo where Id=@id
go
CREATE TABLE USUARIOS (
    Id int identity(1,1) NOT NULL,
    Nombre varchar(50) NULL,
    Apellido varchar(50) NULL,
    Email varchar(50) NULL unique,
    Pass varchar(8) NULL,
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
create table PEDIDOS (
  Id int not null primary key identity (1,1),
 IdUsuario int not null references usuarios(Id),
 IdFormaEntrega int not null references Forma_Entrega(Id),
 Direccion varchar(100) not null,
 Localidad varchar(100)not null,
 Provincia Varchar (100)not null,
 IdFormaPago int not null references Forma_Pago(Id),
 Total money not null,
 IdEstadoPedido int not null references Estado_Pedido(Id),
 FechaCreacion date null
)
go
create table PRODUCTOS_POR_PEDIDO(
  Id int identity(1,1) NOT NULL,
  IdPedido int not null references Pedidos(Id),
  IdAlbum int not null references Albumes(Id),
  Cantidad int not null DEFAULT 0
)
go
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
create procedure InsertarNuevoPedido ( 
 @IdUsuario int,
 @IdFormaEntrega int,
 @Direccion varchar(100),
 @Localidad varchar (100),
 @Provincia varchar (100),
 @IdFormaPago int,
 @Total money,
 @IdEstadoPedido int

 )
As
insert into PEDIDOS (IdUsuario,IdFormaEntrega,Direccion,Localidad,Provincia,IdFormaPago,Total,IdEstadoPedido,FechaCreacion)
 output inserted.Id values (@IdUsuario, @IdFormaEntrega,@Direccion,@Localidad,@Provincia,@IdFormaPago,@Total,@IdEstadoPedido,GETDATE())
go
create procedure InsertarProductoPorPedido (
@IdPedido int,
@IdAlbum int,
@Cantidad int
)
as
Insert into PRODUCTOS_POR_PEDIDO(IdPedido,IdAlbum,Cantidad)
output inserted.Id values (@IdPedido,@IdAlbum,@Cantidad)
go
create procedure sp_modificarPedido(
@Id int,
@IdEstadoPedido int)
as
update PEDIDOS set IdEstadoPedido=@IdEstadoPedido where Id=@Id
go
create procedure sp_modificarArtista(
@Id int,
@Nombre varchar (50))
as
update ARTISTA set Nombre=@Nombre where Id=@Id
go
create procedure sp_modificarCategoria(
@Id int,
@Descripcion varchar (50))
as
update CATEGORIA set Descripcion=@Descripcion where Id=@Id
go
create procedure sp_modificarGenero(
@Id int,
@Descripcion varchar (50))
as
update GENEROS set Descripcion=@Descripcion where Id=@Id
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
 insert into CATEGORIA(Descripcion)values ('S/C'),('Los mas buscados'), ('Los mas vendidos'), ('Los mas recomendados')
go
insert into ARTISTA(Nombre)values ('QUEEN'), ('DAVID BOWIE'), ('CHARLY GARCIA'),('SODA STEREO'),
('FITO PAEZ'),('MERCEDES SOSA'),('LOS ABUELOS DE LA NADA'),('THE BEATLES'),('U2'),('NIRVANA'),('MICHAEL JACKSON'),
('PINK FLOYD'),('THE ROLLING STONES'),('ELTON JOHN'),('METALLICA'),('PRINCE'),('BOB MARLEY'),('AC DC'),('MADONNA'),
('LED ZEPPELIN'),('ASTOR PIAZZOLLA'),('GUSTAVO CERATI'),('VANGELIS')
go
INSERT INTO ALBUMES (Titulo, IdArtista, FechaLanzamiento, ImgTapa, ImgContratapa, Precio, IdGenero, IdCategoria)
VALUES 
('Libertango',21,'1968-02-03','https://i.scdn.co/image/ab67616d0000b2739df3507f06b25736592361e1','https://2.bp.blogspot.com/-8LRoUUPO3E4/U_th0hmZbCI/AAAAAAAAB9M/nFpDURFhQug/s1600/flibertangoa2e45afd2a76fd8e8e1260.jpg',35000.00,4,1),
('Bocanada',22,'1999-05-05','https://assets.dev-filo.dift.io/img/2019/06/28/ce_sq.jpg','https://i1.sndcdn.com/artworks-Pnf1jAbcgDTyTUDW-rNbtug-t500x500.jpg',28000.00,1,2),
('China',23,'1975-07-26','https://rockstorevinilos.cl/wp-content/uploads/2022/01/R-11596408-1519924909-1749.jpeg.jpg','https://m.media-amazon.com/images/I/61Rbr5R+VaL._UF1000,1000_QL80_.jpg',30000.00,3,3),
('Sound And Vision', 2, '1971-03-11', 'https://images.squarespace-cdn.com/content/v1/5a70fa14e45a7c7dd2fadad0/1519497173710-PXUY3JHRWPHINW9RTVUD/1969_manofwords.jpg?format=750w', 'https://1.bp.blogspot.com/-Lo1FX9Z0PS8/XzMDeRabQjI/AAAAAAAADz8/Uists2RHv3km2kJwLV9h4kWpLdhgdurnwCLcBGAsYHQ/s1600/low.jpg', 7500.00, 1, 3),
('Clics Modernos', 3, '1983-02-12', 'https://upload.wikimedia.org/wikipedia/commons/thumb/8/8e/Clics-modernos-charly-garcia-front.jpg/640px-Clics-modernos-charly-garcia-front.jpg', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcShlWTSI2TUDayo6QQIEV7ZS4RK5zvEmp05Gg&usqp=CAU', 5500, 1, 3),
('El Amor despues del amor (2LP)', 5, '2019-06-01', 'https://http2.mlstatic.com/D_NQ_NP_834079-MLA54966560635_042023-W.jpg', 'https://http2.mlstatic.com/D_NQ_NP_889938-MLA48948891521_012022-O.webp', 19392, 1,2),
('Soda Stereo', 4, '2015-11-01', 'https://http2.mlstatic.com/D_NQ_NP_863459-MLA48596431326_122021-O.webp', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSnwsW-LClg87hvvxrOCAetLa3nJ1jllniy9g&usqp=CAU', 14900, 1,2),
('Cantora 1 (2LP)', 6, '2017-11-01', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcmcspn-2qadfwn8s561CUEflepWiWCwNproo0tDS1OLqzqSMkrZwwMDuFgFiVIxTtZFM&usqp=CAU', 'https://http2.mlstatic.com/D_NQ_NP_898106-MLA49844455670_052022-O.webp',21800,7,3),
('Back in Black', 18, '1980-07-25', 'https://cdn1.eldia.com/072021/1627255515074.jpg','https://th.bing.com/th/id/OIP.ftiL5M_hVe2hKMwed2mMGwHaFj?pid=ImgDet&w=480&h=360&rs=1', 8500.00, 1, 2),
('Thriller', 11, '1982-11-30', 'https://i.pinimg.com/originals/a5/c8/ad/a5c8ade83a0d0aa6c50216b8bd04a10c.jpg','https://www.rockshop.ro/images/product/974-michael-jackson-thriller,-specialedition-cd-spatejpg.jpg', 9200.00, 6, 2),
('The Dark Side of the Moon', 12, '1973-03-01', 'https://i.pinimg.com/originals/bc/8f/63/bc8f63a640d62e0372e583471cf1300c.jpg','https://livedoor.blogimg.jp/johnny_the_fox/imgs/c/3/c3419013.jpg', 7800.00, 3, 2),
('Like a Virgin', 19, '1984-11-12', 'https://upload.wikimedia.org/wikipedia/en/1/17/LikeAVirgin1984.png','https://4.bp.blogspot.com/-hxI0MrVSP8o/UfTlEQE9sSI/AAAAAAAAdw8/gUYVpi3nNJM/s1600/Like+a+Virgin+-+Extended+by+Twenty5&More+b.jpg', 6900.00, 2, 2),
('Led Zeppelin IV', 20, '1971-11-08', 'https://upload.wikimedia.org/wikipedia/en/2/26/Led_Zeppelin_-_Led_Zeppelin_IV.jpg','https://th.bing.com/th/id/R.a654cdaaaa9cf451223361aa49c2c4e8?rik=b0HFjvo1XB9PRw&pid=ImgRaw&r=0', 7700.00, 1, 2),
('The Wall', 12, '1979-11-30', 'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b1/The_Wall_Cover.svg/800px-The_Wall_Cover.svg.png','https://th.bing.com/th/id/R.f76e439c1cfb58fd3eca7f2fc14eca9e?rik=T0XpT3s6tuJeng&pid=ImgRaw&r=0', 8500.00, 3, 2),
('Greatest Hits', 1, '1998-11-03', 'https://www.udiscovermusic.com/wp-content/uploads/2017/11/Queen-Greatest-Hits.jpg','https://th.bing.com/th/id/R.b6afdbfe2c0110574f907b049e10e3e4?rik=aGfKxAgm0iDEyg&pid=ImgRaw&r=0', 6800.00, 1, 3);


go
 insert into USUARIOS 
values ('adm','adm','adm@adm.com','adm','2023/06/15','Santo Tom� 4749','Monte Castro','Buenos Aires',1,1)


select * from ALBUMES
 