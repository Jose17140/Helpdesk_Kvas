--DROP DATABASE IF EXISTS Helpdesk_Kvas;
--CREATE DATABASE Helpdesk_Kvas
GO
USE Helpdesk_Kvas;
GO

--DROP TABLE IF EXISTS Empleados;
DROP TABLE IF EXISTS UsuariosRoles;
DROP TABLE IF EXISTS Reportes;
DROP TABLE IF EXISTS PermisoDenegadoPorRol;
DROP TABLE IF EXISTS PermisosPorModulos;
DROP TABLE IF EXISTS Usuarios;
DROP TABLE IF EXISTS Personas;
DROP TABLE IF EXISTS SerialesProductos;
DROP TABLE IF EXISTS ProductoServicios;
DROP TABLE IF EXISTS GruposDetalles;
DROP TABLE IF EXISTS Grupos;


DROP TABLE IF EXISTS Grupos;
CREATE TABLE Grupos(
	IdGrupo INT IDENTITY (0,1) NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(100) NOT NULL,
	IdPadre INT NULL,
	Icono NVARCHAR(30) NULL,
	Estatus BIT NOT NULL DEFAULT 0,
	FechaRegistro DATETIME NOT NULL,
	CONSTRAINT PK_Grupos_IdGrupo PRIMARY KEY(IdGrupo),
	CONSTRAINT FK_Grupos_IdPadre FOREIGN KEY(IdPadre) REFERENCES Grupos(IdGrupo)
);
DROP TABLE IF EXISTS GruposDetalles;
CREATE TABLE GruposDetalles(
	IdGrupoDetalle INT IDENTITY(0,1) NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(50) NOT NULL,
	Orden INT NOT NULL DEFAULT 0,
	IdGrupo INT NOT NULL,
	IdPadre INT NULL,
	Imagen NVARCHAR(30) NULL,
	UrlDetalle VARCHAR(100) NULL,
	Estatus BIT NOT NULL DEFAULT 1,
	FechaRegistro DATETIME NOT NULL,
	CONSTRAINT PK_GruposDetalles_IdGrupoDetalle PRIMARY KEY(IdGrupoDetalle),
	CONSTRAINT FK_GruposDetalles_Grupos_IdGrupo FOREIGN KEY(IdGrupo) REFERENCES Grupos(IdGrupo)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_GruposDetalles_GruposDetallesPadres FOREIGN KEY(IdPadre) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
);
DROP TABLE IF EXISTS Personas;
CREATE TABLE Personas(
	IdPersona INT IDENTITY(1,1) NOT NULL,
	Nombres VARCHAR(50) NOT NULL,
	IdTipoPersona INT NOT NULL,
	CiRif VARCHAR(11) NOT NULL,
	Direccion VARCHAR(100) NOT NULL,
	Telefonos VARCHAR(60) NOT NULL,
	Email VARCHAR(60) NULL,
	FechaRegistro DATETIME NOT NULL,
	CONSTRAINT PK_Personas_IdPersona PRIMARY KEY(IdPersona),
	CONSTRAINT UQ_Personas_CiRif UNIQUE(CiRif),
	CONSTRAINT FK_Personas_GruposDetalles_IdDetalles FOREIGN KEY (IdTipoPersona) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
DROP TABLE IF EXISTS Usuarios;
CREATE TABLE Usuarios(
	IdUsuario INT IDENTITY(1,1) NOT NULL,
	NombreUsuario VARCHAR(30) NOT NULL,
	Contrasena VARCHAR(100) NOT NULL,
	Email VARCHAR(60) NOT NULL,
	IdPreguntaSeguridad INT NOT NULL,
	RespuestaSeguridad VARCHAR(50) NOT NULL,
	Avatar VARCHAR(30) NOT NULL,
	FechaLogin DATETIME NULL,
	ContadorFallido INT NOT NULL DEFAULT 0,
	Estatus BIT NOT NULL DEFAULT 0,
	FechaRegistro DATETIME NOT NULL,
	FechaModificacion DATETIME NULL,
	CONSTRAINT PK_IdUsuario PRIMARY KEY(IdUsuario),
	CONSTRAINT UQ_NombreUsuario UNIQUE (NombreUsuario),
	CONSTRAINT FK_Usuarios_GrupoDetalles_IdRespuestaSeguridad FOREIGN KEY(IdPreguntaSeguridad) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
);
DROP TABLE IF EXISTS UsuariosRoles;
CREATE TABLE UsuariosRoles(
	IdUserRoles INT IDENTITY(1,1) NOT NULL,
	IdUsuario INT NOT NULL,
	IdRoles INT NOT NULL,
	CONSTRAINT PK_Permisos PRIMARY KEY(IdUserRoles),
	CONSTRAINT FK_UsuariosRoles_Usuarios_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_UsuariosRoles_GruposDetalles_Roles FOREIGN KEY (IdRoles) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
);
--PRODUCTOS Y SERVICIOS
DROP TABLE IF EXISTS ProductoServicios;
CREATE TABLE ProductoServicios(
	IdProducto INT IDENTITY(1,1) NOT NULL,
	Sku VARCHAR(24) NOT NULL,
	IdCategoria INT NOT NULL,
	IdGrupo INT NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(100) NULL,
	IdFabricante INT NOT NULL,
	IdUnidad INT NOT NULL, -- UNIDAD DE VENTA
	Imagen VARCHAR(40) NULL,
	Stock INT NOT NULL,
	StockMin INT NULL,
	PrecioCompra DECIMAL(8,2) NULL,
	PrecioVenta DECIMAL(8,2) NOT NULL,
	Garantia INT NOT NULL DEFAULT 0,
	Estatus BIT NOT NULL DEFAULT 1,
	FechaRegistro DATETIME NOT NULL,
	CONSTRAINT PK_Productos PRIMARY KEY(IdProducto),
	CONSTRAINT UQ_ProductosServicios_Sku UNIQUE(Sku),
	CONSTRAINT FK_Productos_Detalles_IdCategoria FOREIGN KEY (IdCategoria) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT FK_Productos_Detalles_IdGrupo FOREIGN KEY (IdGrupo) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Productos_Detalles_IdFabricante FOREIGN KEY (IdFabricante) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Productos_Detalles_IdUnidad FOREIGN KEY (IdUnidad) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
);
DROP TABLE IF EXISTS SerialesProductos;
CREATE TABLE SerialesProductos(
	IdSerial INT IDENTITY(1,1) NOT NULL,
	IdProducto INT NOT NULL,
	Serial VARCHAR(40) NOT NULL,
	Estatus BIT NOT NULL DEFAULT 1,
	CONSTRAINT PK_Seriales PRIMARY KEY(IdProducto,IdSerial),
	CONSTRAINT FK_Seriales_Productos FOREIGN KEY (IdProducto) REFERENCES ProductoServicios(IdProducto)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
DROP TABLE IF EXISTS Reportes;
CREATE TABLE Reportes(
IdReporte INT IDENTITY(1,1) NOT NULL
CONSTRAINT PK_Reporte_Id PRIMARY KEY(IdReporte)
);

--DROP TABLE IF EXISTS Empleados;
--CREATE TABLE Empleados(
--IdPersona INT NOT NULL,
--IdUsuario INT NOT NULL,
--CONSTRAINT PK_Empleados PRIMARY KEY(IdPersona,IdUsuario),
--CONSTRAINT FK_Empleados_Personas_Id FOREIGN KEY (IdPersona) REFERENCES Personas(IdPersona),
--CONSTRAINT FK_Empleados_Usuarios_Id FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
--);

SELECT * FROM Grupos;
SELECT * FROM GruposDetalles where IdGrupo =2;
SELECT * FROM ProductoServicios;
SELECT * FROM Personas;
SELECT * FROM Usuarios;
SELECT * FROM UsuariosRoles;


 --PRODUCTOS
DROP VIEW IF EXISTS vw_ListarProductos;
GO
CREATE VIEW vw_ListarProductos     
 AS     
    WITH Cte_Productos(IdProducto,Sku,IdCategoria,IdGrupo,Nombre,Descripcion,IdFabricante,IdUnidad,Imagen,Stock,StockMin,PrecioCompra,PrecioVenta,Garantia,Estatus,FechaRegistro, LevelGrupo) AS (
		SELECT IdProducto,Sku,IdCategoria,IdGrupo,Nombre,Descripcion,IdFabricante,IdUnidad,Imagen,Stock,StockMin,PrecioCompra,PrecioVenta,Garantia,Estatus,FechaRegistro, 0 AS LevelGrupo
		FROM ProductoServicios AS g
		WHERE g.IdPadre is null
		UNION ALL
		SELECT gd.IdGrupoDetalle, gd.Nombre, gd.Descripcion, gd.Orden, gd.IdGrupo, gd.IdPadre, gd.Icono, gd.UrlDetalle, gd.Estatus, gd.FechaRegistro, LevelGrupo+1
		FROM ProductoServicios AS gd
		INNER JOIN Cte_Productos AS cte ON gd.IdPadre = cte.IdGrupoDetalle
	)
	SELECT ct.IdGrupoDetalle AS IdProducto, ps.Sku, ct.Nombre, ct.Descripcion, ct.Orden, ct.IdGrupo, g.Nombre AS Grupo, ct.IdPadre, c.Nombre AS Padre, ct.Icono, ct.UrlDetalle, 
			ps.IdFabricante, gd.Nombre AS Fabricante, ps.Stock, ps.Stock_Min, ps.IdUnidad, gdd.Nombre AS Unidad, ps.Garantia, ps.PrecioCompra, ps.PrecioVenta, ct.Estatus, ct.FechaRegistro
	FROM Cte_Productos AS ct
	INNER JOIN Cte_Productos AS c ON ct.IdPadre = c.IdGrupoDetalle
	INNER JOIN Grupos AS g ON ct.IdGrupo = g.IdGrupo
	LEFT JOIN PSDetalles AS ps ON ct.IdGrupoDetalle = ps.IdProducto
	LEFT JOIN GruposDetalles AS gd ON ps.IdFabricante = gd.IdGrupoDetalle
	LEFT JOIN GruposDetalles AS gdd ON ps.IdUnidad = gdd.IdGrupoDetalle
	WHERE ct.IdGrupo = 9    
 GO



 INSERT INTO ProductoServicios (Sku,IdCategoria,IdGrupo,Nombre,Descripcion,IdFabricante,IdUnidad,Imagen,Stock,StockMin,PrecioCompra,PrecioVenta,Garantia,Estatus,FechaRegistro) VALUES
('Procesador',0,0,'','',0,0,'',0,0,0,0,0,1,'2018-01-03 19:45:28.087');


SELECT * FROM Grupos
SELECT * FROM GruposDetalles


---- PRODUCTOS
--INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
--('Procesador','I7',9,'fa fa-archive',1,40,'*',GETDATE()),
--('Chip 196RG','Xp201/Xp211',9,'fa fa-archive',2,43,'*',GETDATE()),
--('Memoria Ram','DDR3',9,'fa fa-archive',3,40,'*',GETDATE()),
--('Tarjeta Red','Lan 1000',9,'fa fa-archive',4,39,'*',GETDATE()),
--('Fan Cooler','I7',9,'fa fa-archive',5,40,'*',GETDATE()),
--('Disco Duro','500Gb',9,'fa fa-archive',6,40,'*',GETDATE()),
--('Tinta 100ml','Tinta CM',9,'fa fa-archive',7,42,'*',GETDATE());