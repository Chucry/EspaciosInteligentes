----CREATE DATABASE EspaciosInteligentes
----GO

----USE EspaciosInteligentes
----GO

CREATE TABLE Sucursal (
	id int PRIMARY KEY IDENTITY,
	nombre varchar(80) not null,
	telefono varchar(10) not null,
	direccion varchar(100) not null,
	colonia varchar(100) not null
)

CREATE TABLE Locker (
	id int PRIMARY KEY IDENTITY,
	nombre varchar(80) not null,
	alto decimal(5) not null,
	largo decimal(5) not null,
	ancho decimal(5) not null,
	idSucursal int FOREIGN KEY REFERENCES Sucursal (id) not null,
	precioUnitario decimal(7,2) not null
)

CREATE TABLE Departamento (
	id int PRIMARY KEY IDENTITY,
	nombre varchar(80) not null
)

CREATE TABLE Empleado (
	id int PRIMARY KEY IDENTITY,
	nombre varchar(80) not null,
	apellido varchar(80) not null,
	fechaNacimiento DATE not null,
	email varchar(80) not null,
	telefono varchar(10) not null,
	celular varchar(10),
	idDepartamento int FOREIGN KEY REFERENCES Departamento (id),
	puesto varchar(50),
	fechaContratacion DATE not null,
	fechaTerminacion DATE,
	sueldoBase decimal(8,2) not null,
	direccion varchar(100) not null,
	colonia varchar(100) not null,
	numeroSeguroSocial varchar(9) not null,
	curp varchar(18) not null,
	clabe varchar(18) not null
)

CREATE TABLE Venta (
	id int PRIMARY KEY IDENTITY,
	idLocker int FOREIGN KEY REFERENCES Locker (id),
	precioLocker decimal(7,2) not null,
	fechaInicio DATE not null,
	fechaFinal DATE,
	tipo varchar(25) not null
)

CREATE TABLE Municipio (
	id int PRIMARY KEY IDENTITY,
	nombre varchar(80) not null
)

CREATE TABLE Cliente (
	id int PRIMARY KEY IDENTITY,
	nombre varchar(80) not null,
	apellido varchar(80) not null,
	fechaNacimiento DATE not null,
	email varchar(80) not null,
	password varchar(40) not null,
	numeroContacto varchar(10) not null,
	idMunicipio int FOREIGN KEY REFERENCES Municipio (id)
)

CREATE TABLE PromoCode (
	id int PRIMARY KEY IDENTITY,
	codigo varchar(20) not null,
	descripcion varchar(200) not null,
	tipo int not null,
	cantidad int not null,
	fechaAlta DATE not null,
	expiracion DATE,
	usuarioCreador int FOREIGN KEY REFERENCES Empleado (id)
)

CREATE TABLE Ticket (
	id int PRIMARY KEY IDENTITY,
	clienteId int FOREIGN KEY REFERENCES Cliente (id),
	subtotal decimal(7,2) not null,
	iva decimal(7,2) not null,
	descuento decimal(7,2),
	idPromocode int FOREIGN KEY REFERENCES PromoCode (id)
)

CREATE TABLE TicketVenta (
	idTicket int FOREIGN KEY REFERENCES Ticket (id),
	idVenta int FOREIGN KEY REFERENCES Venta (id)
)