--DROP DATABASE IF EXISTS Helpdesk_Kvas;
--CREATE DATABASE Helpdesk_Kvas
GO
USE Helpdesk_Kvas;
GO

--DROP TABLE IF EXISTS Empleados;
DROP TABLE IF EXISTS Empleados;
DROP TABLE IF EXISTS Fallas_x_Requerimiento;
DROP TABLE IF EXISTS Observaciones_x_Requerimiento;
DROP TABLE IF EXISTS Presupuesto_x_Requerimiento;
DROP TABLE IF EXISTS Accesorios_x_Requerimiento;
DROP TABLE IF EXISTS Mensajes_x_Requerimiento;
DROP TABLE IF EXISTS UsuariosRoles;
DROP TABLE IF EXISTS SerialesProductos;
DROP TABLE IF EXISTS ProductoServicios;
DROP TABLE IF EXISTS Requerimientos;
DROP TABLE IF EXISTS Personas;
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
	Email VARCHAR(60) NULL,
	IdPreguntaSeguridad INT NULL,
	RespuestaSeguridad VARCHAR(50) NULL,
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
DROP TABLE IF EXISTS Empleados;
CREATE TABLE Empleados(
	IdEmpleado INT NOT NULL IDENTITY(1,1),
	IdPersona INT NOT NULL,
	IdUsuario INT NOT NULL,
	IdDepartamento INT NOT NULL,
	IdCargo INT NOT NULL,
	IdSexo INT NOT NULL,
	FechaNaciomiento DATE NULL,
	FechaIngreso DATE NULL,
	FechaRetiro DATE NULL,
	Estatus INT,
	FechaRegistro DATETIME NOT NULL,
	CONSTRAINT PK_Empleados PRIMARY KEY(IdEmpleado,IdPersona),
	CONSTRAINT UQ_Empleado_IdUsuario UNIQUE(IdUsuario),
	CONSTRAINT FK_Empleados_Personas_Id FOREIGN KEY (IdPersona) REFERENCES Personas(IdPersona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Empleados_Usuarios_Id FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Empleados_GruposDetalles_IdDepartamento FOREIGN KEY (IdDepartamento) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Empleados_GruposDetalles_IdCargo FOREIGN KEY (IdCargo) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Empleados_GruposDetalles_IdSexo FOREIGN KEY (IdSexo) REFERENCES GruposDetalles(IdGrupoDetalle)
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
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Productos_Detalles_IdCondicion FOREIGN KEY (IdCondicion) REFERENCES GruposDetalles(IdGrupoDetalle)
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
--TABLAS DE REQUERIMIENTO
DROP TABLE IF EXISTS Requerimientos;
CREATE TABLE Requerimientos(
	IdRequerimiento INT IDENTITY(1,1) NOT NULL,
	IdDepartamento INT NOT NULL, --Sub Departamento que atendera el requerimiento
	Atendido BIT NOT NULL DEFAULT 0,
	IdEmpleado INT NOT NULL, -- Quien abre el requerimiento o lo aprueba
	FechaEntrada DATETIME NOT NULL,
	FechaSalida DATETIME NULL,
	IdCliente INT NOT NULL,
	IdEquipo INT NOT NULL,
	IdMarca INT NOT NULL,
	IdModelo INT NULL,
	IdPrioridad INT NOT NULL,
	Falla VARCHAR(100) NOT NULL,
	Diagnostico VARCHAR(100) NULL,
	Solucion VARCHAR(100) NULL,
	Serial VARCHAR(30) NOT NULL,
	Observaciones VARCHAR(50) NOT NULL,
	Accesorios VARCHAR(30) NULL,
	IdTecnico INT NULL,
	IdDeposito INT NOT NULL,
	IdEstatus INT NOT NULL,
	CONSTRAINT PK_Requerimientos_Id PRIMARY KEY(IdRequerimiento),
	CONSTRAINT FK_Requerimientos_GruposDetalles_IdDepartamento FOREIGN KEY(IdDepartamento) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Requerimientos_Usuarios_IdEmpleado FOREIGN KEY(IdEmpleado) REFERENCES Usuarios(IdUsuario)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Requerimientos_Personas FOREIGN KEY(IdCliente) REFERENCES Personas(IdPersona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Requerimientos_GruposDetalles_Equipo FOREIGN KEY(IdEquipo) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Requerimientos_GruposDetalles_Marca FOREIGN KEY(IdMarca) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Requerimientos_GruposDetalles_Modelo FOREIGN KEY(IdModelo) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Requerimientos_GruposDetalles_Prioridad FOREIGN KEY(IdPrioridad) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Requerimientos_Usuarios_IdUsuario FOREIGN KEY(IdTecnico) REFERENCES Usuarios(IdUsuario)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Requerimientos_GruposDetalles_Deposito FOREIGN KEY(IdDeposito) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Requerimientos_GruposDetalles_Estatus FOREIGN KEY(IdEstatus) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
);

DROP TABLE IF EXISTS Accesorios_x_Requerimiento;
CREATE TABLE Accesorios_x_Requerimiento(
	IdAccesorio INT NOT NULL,
	IdRequerimiento INT NOT NULL,
	CONSTRAINT PK_AxR_Ids PRIMARY KEY(IdAccesorio,IdRequerimiento),
	CONSTRAINT FK_AxR_ FOREIGN KEY(IdAccesorio) REFERENCES GruposDetalles(IdGrupoDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_AxR_Requerimientos_id FOREIGN KEY(IdRequerimiento) REFERENCES Requerimientos(IdRequerimiento)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
);

DROP TABLE IF EXISTS Observaciones_x_Requerimiento;
CREATE TABLE Observaciones_x_Requerimiento(
	IdOxR INT IDENTITY(1,1) NOT NULL,
	IdRequerimiento INT NOT NULL,
	IdUsuario INT NOT NULL,
	Observaciones VARCHAR(100) NOT NULL,
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

DROP TABLE IF EXISTS Presupuesto_x_Requerimiento;
CREATE TABLE Presupuesto_x_Requerimiento(
	IdPresupuesto INT IDENTITY(1,1) NOT NULL,
	IdRequerimiento INT NOT NULL,
	FechaEmision DATETIME NOT NULL,
	FechaVencimiento DATETIME NOT NULL,
	IdPoS INT NOT NULL, --Producto o Servicio
	Cant INT NOT NULL,
	Concepto VARCHAR(50) NOT NULL,
	PrecioUnit DECIMAL(8,2) NOT NULL,
	SubTotal AS (PrecioUnit*Cant),
	CONSTRAINT PK_PresupuestoPorRequerimiento_Id PRIMARY KEY(IdPresupuesto,IdRequerimiento),
	CONSTRAINT FK_PresupuestoPorRequerimiento_Requerimientos_Id FOREIGN KEY(IdRequerimiento) REFERENCES Requerimientos(IdRequerimiento)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_PresupuestoPorRequerimiento_Servicio_Id FOREIGN KEY(IdRequerimiento) REFERENCES Requerimientos(IdRequerimiento)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
);



SELECT * FROM Grupos;
SELECT * FROM GruposDetalles where IdGrupo = 4;
SELECT * FROM ProductoServicios;
SELECT * FROM Personas;
SELECT * FROM Usuarios;
SELECT * FROM UsuariosRoles;
SELECT * FROM Requerimientos;
SELECT * FROM Accesorios_x_Requerimiento;
SELECT * FROM vw_Requerimientos;
SELECT * FROM Empleados;



INSERT INTO Requerimientos(IdDepartamento,IdEmpleado,FechaEntrada,IdCliente,IdEquipo,IdMarca,IdModelo,IdPrioridad,Falla,Serial,Observaciones,Accesorios,IdDeposito,IdEstatus)VALUES
(134,4,'2018-01-03 19:45:28.087',5,106,68,122,118,'Imprime con rayas','XWWWW00001','Equipo en mal estado','Ninguno',116,61);
