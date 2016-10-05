--   Definición de la base de datos 

--	ESQUEMA RELACIONAL DE LA BASE DE DATOS:
--
--	usuario(IdUser(PK), userLogin, userPwd, nombreUser, activo, esAdmon, reportes)
--	articulo(idArticulo(PK), nombreArt, localizacion, existencia, costoProm )
--	
	
--
--	DEFINICIÓN DE TABLAS

CREATE TABLE usuario
    (idUser		int  NOT NULL IDENTITY(1,1) PRIMARY KEY,
	userLogin	char(30),
	userPwd		char(50),
	nombreUser	char(50),
	activo		bit,
	esAdmon		bit,
	reportes	bit
	 );

CREATE TABLE articulo
	(idArticulo	int  NOT NULL IDENTITY(1,1) PRIMARY KEY,
	nombreArt	char(50),
	localizacion char(50),
	existencia	real,
	costoProm	real);

CREATE TABLE entrada
	(idEntrada int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	fechaRegistro date,
	fechaEntrada date,
	proveedor char(30),
	folioFactura char(50),
	fechaFactura date,
	idUser int);

CREATE TABLE salida
	(idSalida int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	fechaRegistro date,
	fechaSalida date,
	responsable char(50),
	idUser smallint);

CREATE TABLE entArticulo
	(idEntradaArticulo int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	idEntrada int,
	idArticulo int,
	cant int,
	precioCompra real);

CREATE TABLE salArticulo
	(idSalArticulo int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	idSalida int,
	idArticulo int,
	cant int);


-- Tuplas de la tabla usuario

insert into usuario values('login1','pwd1','nombre1',1,0,1);
insert into usuario values('login2','pwd2','nombre2',0,0,1);
insert into usuario values('login3','pwd3','nombre3',0,1,1);
insert into usuario values('login4','pwd4','nombre4',0,0,1);
insert into usuario values('login5','pwd5','nombre5',0,0,1);
insert into usuario values('login6','pwd6','nombre6',0,0,0);
insert into usuario values('login7','pwd7','nombre7',0,1,1);
insert into usuario values('login8','pwd8','nombre8',0,1,0);
insert into usuario values('login9','pwd9','nombre9',0,0,1);
insert into usuario values('login10','pwd10','nombre10',0,0,1);

-- Tuplas de la tabla articulo

insert into articulo values ('art1','loc1',955,552.92);
insert into articulo values ('art2','loc2',755,652.92);
insert into articulo values ('art3','loc3',655,752.92);
insert into articulo values ('art4','loc4',555,732.92);
insert into articulo values ('art5','loc5',455,532.92);
insert into articulo values ('art6','loc6',355,542.92);


-- Tuplas de la tabla entrada

insert into entrada values ('2014-08-01','2014-08-08','prov1',123,'2014-09-08',1);
insert into entrada values ('2014-08-02','2014-08-18','prov2',124,'2014-09-09',1);
insert into entrada values ('2014-08-03','2014-08-28','prov3',125,'2014-09-07',2);
insert into entrada values ('2014-08-04','2014-08-29','prov1',126,'2014-09-06',3);
insert into entrada values ('2014-08-05','2014-08-30','prov1',127,'2014-09-04',1);

-- Tuplas de la tabla salida

insert into salida values ('2014-10-21','2014-10-26','res1',1);
insert into salida values ('2014-10-23','2014-10-26','res2',2);
insert into salida values ('2014-10-24','2014-10-26','res3',3);
insert into salida values ('2014-10-25','2014-10-26','res1',4);
insert into salida values ('2014-10-26','2014-10-26','res1',1);



-- Tuplas de la tabla entArticulo

insert into entArticulo values (1,1,20,2.3);
insert into entArticulo values (2,2,22,22.3);
insert into entArticulo values (3,3,28,21.3);
insert into entArticulo values (4,4,27,23.3);
insert into entArticulo values (5,5,21,12.3);


-- Tuplas de la tabla salArticulo

insert into salArticulo values (1,1,5);
insert into salArticulo values (2,2,3);
insert into salArticulo values (3,3,4);
insert into salArticulo values (4,4,7);