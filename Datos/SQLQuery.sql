DROP DATABASE IF EXISTS Helpdesk_Kvas;
CREATE DATABASE Helpdesk_Kvas
GO
USE Helpdesk_Kvas;
GO

DROP TABLE IF EXISTS PermisosPorRoles;
DROP TABLE IF EXISTS Empleados;
DROP TABLE IF EXISTS Usuarios;
DROP TABLE IF EXISTS Personas;
DROP TABLE IF EXISTS GruposDetalles;
DROP TABLE IF EXISTS Grupos;

DROP TABLE IF EXISTS Grupos;
CREATE TABLE Grupos(
	IdGrupo INT IDENTITY (0,1) NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(100) NOT NULL,
	Orden INT NOT NULL DEFAULT 0,
	Icono NVARCHAR(30) NULL,
	UrlGrupo VARCHAR(50) NOT NULL,
	Estatus BIT NOT NULL DEFAULT 1,
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
	IdPadre INT NOT NULL,
	Icono NVARCHAR(30) NULL,
	UrlDetalle VARCHAR(30) NULL,
	Estatus BIT NOT NULL DEFAULT 1,
	FechaRegistro DATETIME NOT NULL,
	CONSTRAINT PK_GruposDetalles_IdGrupoDetalle PRIMARY KEY(IdGrupoDetalle),
	CONSTRAINT FK_GruposDetalles_Grupos_IdGrupo FOREIGN KEY(IdGrupo) REFERENCES Grupos(IdGrupo),
	CONSTRAINT FK_GruposDetalles_GruposDetallesPadres FOREIGN KEY(IdPadre) REFERENCES GruposDetalles(IdGrupoDetalle)
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
	Imagen VARCHAR(60) NOT NULL,
	FechaRegistro DATETIME NOT NULL,
	CONSTRAINT PK_Personas_IdPersona PRIMARY KEY(IdPersona),
	CONSTRAINT UQ_Personas_CiRif UNIQUE(CiRif),
	CONSTRAINT FK_Personas_GruposDetalles_IdDetalles FOREIGN KEY (IdTipoPersona) REFERENCES GruposDetalles(IdGrupoDetalle)
);
--DROP TABLE IF EXISTS Usuarios;
--CREATE TABLE Usuarios(
--IdUsuario INT IDENTITY(1,1) NOT NULL,
--NombreUsuario VARCHAR(30) NOT NULL,
--Contrasena VARCHAR(100) NOT NULL,
--IdRol INT NOT NULL,
--IdPreguntaSeguridad INT NOT NULL,
--RespuestaSeguridad VARCHAR(50) NOT NULL,
--FechaLogin DATETIME NULL,
--ContadorFallido SMALLINT NOT NULL DEFAULT 0,
--Estatus BIT NOT NULL DEFAULT 0,
--FechaRegistro DATETIME NOT NULL,
--FechaModificacion DATETIME NULL,
--CONSTRAINT PK_IdUsuario PRIMARY KEY(IdUsuario),
--CONSTRAINT UQ_NombreUsuario UNIQUE (NombreUsuario),
--CONSTRAINT FK_Usuarios_GrupoDetalles_IdRespuestaSeguridad FOREIGN KEY(IdPreguntaSeguridad) REFERENCES GruposDetalles(IdGrupoDetalle),
--CONSTRAINT FK_Usuarios_GrupoDetalles_IdRol FOREIGN KEY(IdRol) REFERENCES GruposDetalles(IdGrupoDetalle)
--);
--DROP TABLE IF EXISTS Empleados;
--CREATE TABLE Empleados(
--IdPersona INT NOT NULL,
--IdUsuario INT NOT NULL,
--CONSTRAINT PK_Empleados PRIMARY KEY(IdPersona,IdUsuario),
--CONSTRAINT FK_Empleados_Personas_Id FOREIGN KEY (IdPersona) REFERENCES Personas(IdPersona),
--CONSTRAINT FK_Empleados_Usuarios_Id FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
--);


--PROCEDIMIENTOS ALMACENADOS DE LOS GRUPOS CRUD
DROP PROCEDURE IF EXISTS sp_AgregarGrupo;
GO
CREATE PROCEDURE sp_AgregarGrupo
 (      
    @Titulo VARCHAR(50),      
    @Descripcion VARCHAR(100),      
    @Orden INT,
	@Icono VARCHAR(30),
	@UrlGrupo VARCHAR(50),
	@Estatus BIT,
	@FechaRegistro DATETIME     
 )      
 AS      
 BEGIN      
    INSERT INTO Grupos VALUES(@Titulo,@Descripcion,@Orden,@Icono,@UrlGrupo,@Estatus,@FechaRegistro)      
 END
 GO

DROP PROCEDURE IF EXISTS sp_ActualizarGrupo;
GO
CREATE PROCEDURE sp_ActualizarGrupo      
 (  
	@IdGrupo INT,    
    @Titulo VARCHAR(50),      
    @Descripcion VARCHAR(100),      
    @Orden INT,
	@Icono VARCHAR(30),
	@UrlGrupo VARCHAR(50),
	@Estatus BIT     
 )      
 AS      
 BEGIN      
    UPDATE Grupos      
    SET Nombre=@Titulo,      
		Descripcion=@Descripcion,      
		Orden= @Orden,
		Icono=@Icono,
		UrlGrupo=@UrlGrupo,
		Estatus=@Estatus
		WHERE IdGrupo = @IdGrupo	
 END
 GO      
     
DROP PROCEDURE IF EXISTS sp_EliminarGrupo;
GO   
CREATE PROCEDURE sp_EliminarGrupo      
 (      
    @IdGrupo INT      
 )      
 AS      
 BEGIN       
    DELETE FROM Grupos WHERE IdGrupo=@IdGrupo      
 END
 GO

DROP PROCEDURE IF EXISTS sp_ListarGrupo;
GO
CREATE PROCEDURE sp_ListarGrupo        
 AS        
 BEGIN        
    SELECT * FROM Grupos      
 END
 GO

--PROCEDURE USUARIOS
DROP PROCEDURE IF EXISTS sp_AgregarUsuario;
GO
CREATE PROCEDURE sp_AgregarUsuario
 (      
    @NombreUsuario VARCHAR(30),      
    @Contrasena VARCHAR(100),
	@IdRole INT,
    @IdPSeguridad INT,
	@RespuestaP VARCHAR(50),
	@Estatus BIT,
	@FechaRegistro DATETIME
 )      
 AS      
 BEGIN      
    INSERT INTO Usuarios(NombreUsuario,Contrasena,IdRol,IdPreguntaSeguridad,RespuestaSeguridad,Estatus,FechaRegistro) VALUES(@NombreUsuario,@Contrasena,@IdRole,@IdPSeguridad,@RespuestaP,@Estatus,@FechaRegistro)      
 END
 GO

 EXEC sp_AgregarUsuario 'Jose', '123456', 1, 1, 'Test', 1, '2007-05-04'
 
  
 SELECT * FROM Usuarios;


UPDATE GruposDetalles SET UrlDetalle = '/Grupo/Index'
where IdGrupoDetalle = 23
SELECT * FROM GruposDetalles;

UPDATE Grupos SET Icono = 'fa fa-pause fa-4x'
where IdGrupo = 1
SELECT * FROM Grupos;


SELECT gp.IdGrupoDetalle, gp.Nombre, gp.IdGrupo, gp.Orden, gp.IdPadre, gp.Estatus 
FROM GruposDetalles AS gp 
INNER JOIN Grupos AS g ON gp.IdGrupo = g.IdGrupo 
WHERE g.Estatus =1 AND gp.Estatus =1 AND gp.IdGrupo =1 AND gp.IdPadre = 0
ORDER BY gp.Orden ASC

--SELECT GENERICOS
SELECT * FROM Grupos;
SELECT * FROM GruposDetalles;
--SELECT * FROM AspNetUsers;
SELECT * FROM Personas;
SELECT gd.IdGrupoDetalle, gd.Nombre, gd.Descripcion, gd.idGrupo, gp.Nombre, gd.idPadre
FROM GruposDetalles AS gd
INNER JOIN Grupos AS gp 
	ON gd.idGrupo = gp.idGrupo
	WHERE gd.Estatus = 1 AND gd.idGrupo = 1;

DROP VIEW IF EXISTS vw_Personas
GO
CREATE VIEW vw_Personas AS
SELECT p.IdPersona, p.Nombres, CONCAT(g.Nombre, p.CiRif) AS Cedula, p.Direccion, p.Telefonos, p.Email, p.Imagen, p.FechaRegistro
FROM Personas AS p
INNER JOIN GruposDetalles AS g ON p.IdTipoPersona = g.IdGrupoDetalle;

