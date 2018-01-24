--DROP DATABASE IF EXISTS Helpdesk_Kvas;
--CREATE DATABASE Helpdesk_Kvas
GO
USE Helpdesk_Kvas;
GO

--DROP TABLE IF EXISTS Empleados;

DROP TABLE IF EXISTS Empleados;
DROP TABLE IF EXISTS Personas;
DROP TABLE IF EXISTS Observaciones;
DROP TABLE IF EXISTS Presupuestos;
DROP TABLE IF EXISTS ProductoServicios;
DROP TABLE IF EXISTS Requerimientos;
DROP TABLE IF EXISTS Usuarios;
DROP TABLE IF EXISTS GruposDetalles;
DROP TABLE IF EXISTS Grupos;

--TABLAS DEL SISTEMA
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
		ON UPDATE NO ACTION
);
DROP TABLE IF EXISTS Usuarios;
CREATE TABLE Usuarios(
	IdUsuario INT IDENTITY(1,1) NOT NULL,
	NombreUsuario VARCHAR(30) NOT NULL,
	Contrasena VARCHAR(100) NOT NULL,
	IdPreguntaSeguridad INT NULL,
	RespuestaSeguridad VARCHAR(50) NULL,
	Avatar VARCHAR(30) NOT NULL,
	IdRoles INT NOT NULL,
	FechaLogin DATETIME NULL,
	ContadorFallido INT NOT NULL DEFAULT 0,
	Estatus BIT NOT NULL DEFAULT 0,
	FormColor VARCHAR(20) NULL,
	FechaRegistro DATETIME NOT NULL,
	FechaModificacion DATETIME NULL,
	CONSTRAINT PK_IdUsuario PRIMARY KEY(IdUsuario),
	CONSTRAINT UQ_NombreUsuario UNIQUE (NombreUsuario),
	CONSTRAINT FK_Usuarios_GrupoDetalles_IdRespuestaSeguridad FOREIGN KEY(IdPreguntaSeguridad) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Usuarios_GruposDetalles_IdRoles FOREIGN KEY (IdRoles) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
);
DROP TABLE IF EXISTS Personas;
CREATE TABLE Personas(
	IdPersona INT IDENTITY(1,1) NOT NULL,
	IdUsuario INT NOT NULL,
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
		ON UPDATE CASCADE,
	CONSTRAINT FK_Personas_Usuarios_IdUsuario FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
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
	IdCondicion INT NULL,
	Stock INT NOT NULL,
	StockMin INT NULL,
	PrecioCompra DECIMAL(15,2) NULL,
	PrecioVenta DECIMAL(15,2) NOT NULL,
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
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Productos_Detalles_IdCondicion FOREIGN KEY (IdCondicion) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
);
--TABLAS DE REQUERIMIENTO
DROP TABLE IF EXISTS Requerimientos;
CREATE TABLE Requerimientos(
	IdRequerimiento INT IDENTITY(1,1) NOT NULL,
	IdDepartamento INT NOT NULL, -- SUB DEPARTAMENTO ENCARGADO DE ATENDER EL REQUERIMIENTO
	Presupuestado BIT NOT NULL DEFAULT 0, --FUE PRESUPUESTADO
	Asignado BIT NOT NULL DEFAULT 0,-- SI YA FUE ASIGNADO
	IdEmpleado INT NULL, -- USUARIO QUE GENERA EL REQUERIMIENTO O LO APRUEBA
	IdTecnico INT NULL, -- USUARIO TECNICO ENCARGADO DE ATENDER EL REQUERIMIENTO
	IdCliente INT NOT NULL, -- PERSONA QUE SOLICITA EL REQUERIMIENTO
	FechaEntrada DATETIME NOT NULL,
	FechaSalida DATETIME NULL,
	IdEquipo INT NOT NULL,
	IdMarca INT NULL,
	IdModelo INT NULL,
	IdPrioridad INT NOT NULL,
	Falla VARCHAR(250) NOT NULL,
	Diagnostico VARCHAR(250) NULL,
	Solucion VARCHAR(250) NULL,
	Serial VARCHAR(30) NOT NULL,
	Observaciones VARCHAR(250) NULL,
	Accesorios VARCHAR(30) NULL,
	IdEstatus INT NOT NULL,
	CONSTRAINT PK_Requerimientos_Id PRIMARY KEY(IdRequerimiento),
	CONSTRAINT FK_Requerimientos_GruposDetalles_IdDepartamento FOREIGN KEY(IdDepartamento) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Requerimientos_Usuarios_IdEmpleado FOREIGN KEY(IdEmpleado) REFERENCES Usuarios(IdUsuario)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Requerimientos_Usuarios_IdTecnico FOREIGN KEY(IdTecnico) REFERENCES Usuarios(IdUsuario)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Requerimientos_Usuarios_IdCliente FOREIGN KEY(IdCliente) REFERENCES Usuarios(IdUsuario)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Requerimientos_GruposDetalles_IdEquipo FOREIGN KEY(IdEquipo) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Requerimientos_GruposDetalles_IdMarca FOREIGN KEY(IdMarca) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Requerimientos_GruposDetalles_IdModelo FOREIGN KEY(IdModelo) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Requerimientos_GruposDetalles_IdPrioridad FOREIGN KEY(IdPrioridad) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Requerimientos_GruposDetalles_Estatus FOREIGN KEY(IdEstatus) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
);
--OBSERVACIONES POR REQUERIMIENTO
DROP TABLE IF EXISTS Observaciones;
CREATE TABLE Observaciones(
	IdOxR INT IDENTITY(1,1) NOT NULL,
	IdRequerimiento INT NOT NULL,
	IdUsuario INT NOT NULL, --USUARIO QUE REALIZO EL MENSAJE
	Observacion VARCHAR(100) NOT NULL,
	Leido BIT NOT NULL DEFAULT 0, -- SIN LEER 0, LEIDO 1
	FechaRegistro DATETIME NOT NULL,
	CONSTRAINT PK_OxR_Id PRIMARY KEY(IdOxR,IdRequerimiento),
	CONSTRAINT FK_OxR_Requerimientos_id FOREIGN KEY(IdRequerimiento) REFERENCES Requerimientos(IdRequerimiento)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_OxR_Usuarios_IdUsuario FOREIGN KEY(IdUsuario) REFERENCES Usuarios(IdUsuario)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
);
DROP TABLE IF EXISTS Presupuestos;
CREATE TABLE Presupuestos(
	IdPresupuesto INT IDENTITY(1,1) NOT NULL,
	IdRequerimiento INT NOT NULL,
	IdUsuario INT NOT NULL,
	FechaEmision DATETIME NOT NULL,
	FechaVencimiento DATETIME NULL,
	IdPoS INT NOT NULL, --Producto o Servicio
	Cant INT NOT NULL,
	PrecioUnit DECIMAL(15,2) NOT NULL,
	SubTotal AS (PrecioUnit*Cant),
	Iva AS (PrecioUnit*Cant)*0.12,
	IdEstatus INT NOT NULL,
	CONSTRAINT PK_PresupuestoPorRequerimiento_Id PRIMARY KEY(IdPresupuesto,IdRequerimiento),
	CONSTRAINT FK_PresupuestoPorRequerimiento_Requerimientos_Id FOREIGN KEY(IdRequerimiento) REFERENCES Requerimientos(IdRequerimiento)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_PresupuestoPorRequerimiento_PoS_IdProducto FOREIGN KEY(IdPoS) REFERENCES ProductoServicios(IdProducto)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_PxR_Usuarios_IdUsuario FOREIGN KEY(IdUsuario) REFERENCES Usuarios(IdUsuario)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Presupuesto_GruposDetalles_Estatus FOREIGN KEY(IdEstatus) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
);



SELECT * FROM Grupos;
SELECT * FROM GruposDetalles where IdPadre = 135 AND IdGrupo = 14;
SELECT * FROM GruposDetalles where IdGrupo = 4 AND IdPadre = 129;
SELECT * FROM GruposDetalles WHERE IdGrupoDetalle = 135
SELECT * FROM ProductoServicios;
SELECT * FROM Personas;
SELECT * FROM Usuarios;
SELECT * FROM Requerimientos;
SELECT * FROM vw_Requerimientos;
SELECT * FROM Observaciones;
SELECT * FROM vw_ListarProductos
SELECT * FROM Presupuestos;
SELECT * FROM vw_ListarUsuarios where IdRoles = 47
SELECT * FROM vw_Personas;
SELECT * FROM vw_Bitacora;
SELECT * FROM vw_Usuarios_Personas;



SELECT pt.IdPresupuesto, pt.IdRequerimiento, pt.IdPoS, ps.Nombre, ps.Descripcion, pt.Cant, pt.PrecioUnit, pt.SubTotal, pt.IdEstatus
FROM Presupuestos AS pt
INNER JOIN ProductoServicios AS ps ON pt.IdPoS = ps.IdProducto



INSERT INTO Observaciones(IdRequerimiento,IdUsuario,Observacion,FechaRegistro)VALUES
(1,1,'Por favor atender',GETDATE());

INSERT INTO Presupuestos(IdRequerimiento,IdUsuario,FechaEmision,IdPoS,Cant,PrecioUnit)VALUES
(1,4,GETDATE(),1,2,550000)





EXEC sp_AgregarUsuarioA 'Jose1710', 'l8lOvl12ejU7d/PAzi1Cl0Hy6MmUc8PBUOL6o9FMnaY=',40,'Trinidad Figueira','user.png',47,1,'ROJO','2018-01-03 19:45:28.087',
	'jose121',27,'121211212','Catia','1212121212','josej@gg.com'
--CRUDL PRODUCTOS

