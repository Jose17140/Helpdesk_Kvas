--DROP DATABASE IF EXISTS Helpdesk_Kvas;
--CREATE DATABASE Helpdesk_Kvas
GO
USE Helpdesk_Kvas;
GO

DROP TABLE IF EXISTS PermisoDenegadoPorRol;
DROP TABLE IF EXISTS PermisosPorModulos;
DROP TABLE IF EXISTS Usuarios;
DROP TABLE IF EXISTS Personas;
DROP TABLE IF EXISTS SerialesProductos;
DROP TABLE IF EXISTS PSDetalles;
DROP TABLE IF EXISTS GruposDetalles;
DROP TABLE IF EXISTS Grupos;

--DROP TABLE IF EXISTS Empleados;
--CREATE TABLE Empleados(
--IdPersona INT NOT NULL,
--IdUsuario INT NOT NULL,
--CONSTRAINT PK_Empleados PRIMARY KEY(IdPersona,IdUsuario),
--CONSTRAINT FK_Empleados_Personas_Id FOREIGN KEY (IdPersona) REFERENCES Personas(IdPersona),
--CONSTRAINT FK_Empleados_Usuarios_Id FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
--);

DROP TABLE IF EXISTS Grupos;
CREATE TABLE Grupos(
	IdGrupo INT IDENTITY (0,1) NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(100) NOT NULL,
	Orden INT NOT NULL DEFAULT 0,
	Icono NVARCHAR(30) NULL,
	UrlGrupo VARCHAR(50) NOT NULL,
	Estatus BIT NOT NULL DEFAULT 0,
	FechaRegistro DATETIME NOT NULL,
	CONSTRAINT PK_Grupos_IdGrupo PRIMARY KEY(IdGrupo)
);
DROP TABLE IF EXISTS GruposDetalles;
CREATE TABLE GruposDetalles(
	IdGrupoDetalle INT IDENTITY(0,1) NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(50) NOT NULL,
	Orden INT NOT NULL DEFAULT 0,
	IdGrupo INT NOT NULL,
	IdPadre INT NULL,
	Icono NVARCHAR(30) NULL,
	UrlDetalle VARCHAR(100) NULL,
	Estatus BIT NOT NULL DEFAULT 1,
	FechaRegistro DATETIME NOT NULL,
	CONSTRAINT PK_GruposDetalles_IdGrupoDetalle PRIMARY KEY(IdGrupoDetalle),
	CONSTRAINT FK_GruposDetalles_Grupos_IdGrupo FOREIGN KEY(IdGrupo) REFERENCES Grupos(IdGrupo)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
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
	IdRol INT NOT NULL,
	IdPreguntaSeguridad INT NOT NULL,
	RespuestaSeguridad VARCHAR(50) NOT NULL,
	FechaLogin DATETIME NULL,
	ContadorFallido INT NOT NULL DEFAULT 0,
	Estatus BIT NOT NULL DEFAULT 0,
	FechaRegistro DATETIME NOT NULL,
	FechaModificacion DATETIME NULL,
	CONSTRAINT PK_IdUsuario PRIMARY KEY(IdUsuario),
	CONSTRAINT UQ_NombreUsuario UNIQUE (NombreUsuario),
	CONSTRAINT FK_Usuarios_GrupoDetalles_IdRespuestaSeguridad FOREIGN KEY(IdPreguntaSeguridad) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Usuarios_GrupoDetalles_IdRol FOREIGN KEY(IdRol) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
);
--DROP TABLE IF EXISTS PermisosPorModulos;
--CREATE TABLE PermisosPorModulos(
--	IdPermiso INT IDENTITY(1,1) NOT NULL,
--	IdModulo INT NOT NULL,
--	Descripcion VARCHAR(80) NOT NULL,
--	CONSTRAINT PK_Permisos PRIMARY KEY(IdPermiso),
--	CONSTRAINT FK_Permisos_IdModulo FOREIGN KEY (IdModulo) REFERENCES GruposDetalles(IdGrupoDetalle)
--		ON DELETE NO ACTION
--		ON UPDATE NO ACTION
--);
--DROP TABLE IF EXISTS PermisoDenegadoPorRol;
--CREATE TABLE PermisoDenegadoPorRol(
--	IdRol INT NOT NULL,
--	IdPermiso INT NOT NULL,
--	CONSTRAINT PK_PermisoDenegadoPorRol PRIMARY KEY(IdRol,IdPermiso),
--	CONSTRAINT FK_PermisoDenegadoPorRol_GrupoDetalles_IdRol FOREIGN KEY (IdRol) REFERENCES GruposDetalles(IdGrupoDetalle)
--		ON DELETE NO ACTION
--		ON UPDATE NO ACTION,
--	CONSTRAINT FK_PermisoDenegadoPorRol_PermisosPorModulos_IdPermiso FOREIGN KEY (IdPermiso) REFERENCES PermisosPorModulos(IdPermiso)
--		ON DELETE NO ACTION
--		ON UPDATE NO ACTION
--);
--PRODUCTOS Y SERVICIOS
DROP TABLE IF EXISTS PSDetalles;
CREATE TABLE PSDetalles(
	IdProducto INT NOT NULL,
	Sku VARCHAR(24) NOT NULL,
	IdFabricante INT NOT NULL,
	Stock INT NULL,
	IdUnidad INT NOT NULL, -- UNIDAD DE VENTA
	Stock_Min INT NULL,
	PrecioCompra DECIMAL(8,2) NULL,
	PrecioVenta DECIMAL(8,2) NOT NULL,
	Garantia INT NOT NULL DEFAULT 0
	CONSTRAINT PK_Productos PRIMARY KEY(IdProducto),
	CONSTRAINT FK_Productos_Detalles_IdProducto FOREIGN KEY (IdProducto) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
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
	CONSTRAINT FK_Seriales_Productos FOREIGN KEY (IdProducto) REFERENCES PSDetalles(IdProducto)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

--SELECT GENERICOS
SELECT * FROM Grupos;
SELECT * FROM GruposDetalles;
SELECT * FROM Personas;
SELECT * FROM Usuarios;
SELECT * FROM PSDetalles;
SELECT * FROM SerialesProductos;
SELECT * FROM vw_Personas;




WITH Cte_Productos(IdGrupoDetalle,Nombre,Descripcion,Orden,IdGrupo,IdPadre,Icono,Estatus,FechaRegistro, LevelGrupo) AS (
	SELECT g.IdGrupoDetalle, g.Nombre, g.Descripcion, g.Orden, g.IdGrupo, g.IdPadre, g.Icono, g.Estatus, g.FechaRegistro, 0 AS LevelGrupo
	FROM GruposDetalles AS g
	WHERE g.IdPadre = 0
	UNION ALL
	SELECT gd.IdGrupoDetalle, gd.Nombre, gd.Descripcion, gd.Orden, gd.IdGrupo, gd.IdPadre, gd.Icono, gd.Estatus, gd.FechaRegistro, LevelGrupo+1
	FROM GruposDetalles AS gd
	INNER JOIN Cte_Productos AS cte ON gd.IdPadre = cte.IdGrupoDetalle
)
SELECT c.IdGrupoDetalle AS IdDepartamento, c.Nombre AS Departamento, ct.IdGrupoDetalle, ct.Nombre AS Producto, ct.Descripcion, ct.Orden, ct.LevelGrupo, g.Nombre
FROM Cte_Productos AS ct
INNER JOIN Cte_Productos AS c ON ct.IdPadre = c.IdGrupoDetalle
INNER JOIN Grupos AS g ON ct.IdGrupo = g.IdGrupo
ORDER BY ct.LevelGrupo ASC



--SELECT *
--FROM GruposDetalles AS p
--LEFT JOIN PSDetalles AS ps ON p.IdGrupoDetalle = ps.IdProducto
--WHERE p.IdPadre = 33 AND p.IdGrupoDetalle > 0

--EXEC sp_AgregarProducto 'Chip Reset','Impresora Tx120',2,9,33,'fa fa-laptop','*',1,'30-11-2017','BAR123',33,64,100,96,0,50000,110000,10
--EXEC sp_AgregarProducto 'Sistema de Tinta','Impresora Tx120',2,9,33,'fa fa-laptop','*',1,'30-11-2017','BAR123',33,64,100,96,0,50000,110000,10
--EXEC sp_AgregarProducto 'Procesador','Pc',2,9,33,'fa fa-laptop','*',1,'30-11-2017','BAR123',33,64,100,96,0,50000,110000,10