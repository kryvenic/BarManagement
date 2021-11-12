CREATE DATABASE Infobar;

USE Infobar;

CREATE TABLE TipoUsuario(
	Id Integer PRIMARY KEY,
	Descripcion VARCHAR(10)
	)
GO

CREATE TABLE Usuario(
	Id INTEGER IDENTITY PRIMARY KEY,
	Id_Tipo INTEGER,
	Nombre VARCHAR(30),
	Clave VARCHAR(20),
	Activado int,
	FOREIGN KEY (Id_Tipo) REFERENCES TipoUsuario (Id)
	)
GO

CREATE TABLE TipoPago(
	Id_TipoPago INTEGER PRIMARY KEY,
	Descripcion VARCHAR(20)
	)
GO


CREATE TABLE TipoProducto(
	Id_TipoProd INTEGER PRIMARY KEY,
	Descripcion VARCHAR(15)
	)
GO

CREATE TABLE Producto(
	Id_Producto INTEGER PRIMARY KEY,
	Id_TipoProd INTEGER NOT NULL,
	Descripcion VARCHAR(60),
	Precio DEC(8,2),
	Imagen VARCHAR(120),
	Activado INTEGER NOT NULL,
	FOREIGN KEY (Id_TipoProd) REFERENCES TipoProducto(Id_TipoProd)
	)
GO

CREATE TABLE Pedido(
	Id_Pedido INTEGER IDENTITY PRIMARY KEY,
	Id_TipoPago INTEGER,
	Id_Usuario INTEGER,
	Mesa INTEGER,
	Fecha DATE,
	Importe_Total DEC(8,2),
	FOREIGN KEY (Id_TipoPago) REFERENCES TipoPago(Id_TipoPago),
	FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id)
	)
GO

CREATE TABLE Detalle_Pedido(
	Id_Pedido INTEGER,
	Id_Prod INTEGER,
	Cantidad INTEGER,
	Precio DEC(8,2),
	PrecioTotal DEC(8,2),
	CONSTRAINT IdDetalle PRIMARY KEY (Id_Pedido, Id_Prod),
	FOREIGN KEY (Id_Pedido) REFERENCES Pedido(Id_Pedido),
	FOREIGN KEY (Id_Prod) REFERENCES Producto(Id_Producto),
	)
GO

insert into TipoProducto values (1, 'Comidas');
insert into TipoProducto values (2, 'Bebidas');

insert into TipoUsuario values (1, 'Admin');
insert into TipoUsuario values (2, 'Gerente');
insert into TipoUsuario values (3, 'Empleado');

insert into Usuario (Id_Tipo,Nombre,Clave) values (1,'admin','admin')
insert into Usuario (Id_Tipo,Nombre,Clave) values (2,'gerente','gerente')
insert into Usuario (Id_Tipo,Nombre,Clave) values (3,'empleado','empleado')

insert into TipoPago values (1,'Efectivo')
insert into TipoPago values (2,'Debito')

insert into Producto values (100,1,'Hamburguesa Especial',300,'C:\HamburguesaEspecial.jpg',1);
insert into Producto values (101,1,'Pizza Mozzarella',400,'C:\pizzaMuzarela.jpg',1);
insert into Producto values (200,2,'Agua Mineral',400,'C:\aguamineral.jpg',1);
insert into Producto values (201,2,'Cerveza Corona 710CC',400,'C:\Cerveza_Corona_710CC.jpg',1);
insert into Producto values (202,2,'Quilmes 1LT',400,'C:\QuilmesDeLitro.jpg',1);
