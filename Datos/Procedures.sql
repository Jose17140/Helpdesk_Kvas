USE Helpdesk_Kvas
GO

--PROCEDIMIENTOS ALMACENADOS DE LOS GRUPOS CRUD
--CRUDL GRUPO
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

DROP PROCEDURE IF EXISTS sp_ListarDetalles_x_Grupo;
GO   
CREATE PROCEDURE sp_ListarDetalles_x_Grupo
 (      
    @IdGrupo INT      
 )      
 AS      
 BEGIN       
    SELECT gd.IdGrupoDetalle, gd.Nombre, gd.Descripcion, gd.Orden, gd.Nombre AS Categoria, gd.Icono, gd.UrlDetalle, gd.Estatus, gd.FechaRegistro
	FROM Grupos AS g
	INNER JOIN GruposDetalles AS gd ON g.IdGrupo = gd.IdGrupo
	WHERE g.IdGrupo = @IdGrupo AND g.Estatus = 1 AND gd.Estatus = 1
	ORDER BY IdGrupoDetalle ASC     
 END
 GO


--CRUDL GRUPO DETALLE
DROP PROCEDURE IF EXISTS sp_AgregarGrupoDetalle;
GO
CREATE PROCEDURE sp_AgregarGrupoDetalle
 (      
    @Nombre VARCHAR(50),      
    @Descripcion VARCHAR(100),      
    @Orden INT,
	@IdGrupo INT,
	@IdPadre INT,
	@Icono VARCHAR(30),
	@UrlDetalle VARCHAR(50),
	@Estatus BIT,
	@FechaRegistro DATETIME     
 )      
 AS      
 BEGIN      
    INSERT INTO GruposDetalles VALUES(@Nombre,@Descripcion,@Orden,@IdGrupo,@IdPadre,@Icono,@UrlDetalle,@Estatus,@FechaRegistro)      
 END
 GO

DROP PROCEDURE IF EXISTS sp_ActualizarGrupoDetalle;
GO
CREATE PROCEDURE sp_ActualizarGrupoDetalle
 (  
	@IdGrupoDetalle INT,    
    @Titulo VARCHAR(50),      
    @Descripcion VARCHAR(100),      
    @Orden INT,
	@IdGrupo INT,
	@IdPadre INT,
	@Icono VARCHAR(30),
	@UrlDetalle VARCHAR(50),
	@Estatus BIT     
 )      
 AS      
 BEGIN      
    UPDATE GruposDetalles      
    SET Nombre=@Titulo,      
		Descripcion=@Descripcion,      
		Orden= @Orden,
		IdGrupo=@IdGrupo,
		IdPadre=@IdPadre,
		Icono=@Icono,
		UrlDetalle=@UrlDetalle,
		Estatus=@Estatus
		WHERE IdGrupoDetalle = @IdGrupoDetalle	
 END
 GO      
     
DROP PROCEDURE IF EXISTS sp_EliminarGrupoDetalle;
GO   
CREATE PROCEDURE sp_EliminarGrupoDetalle
 (      
    @IdGrupoDetalle INT      
 )      
 AS      
 BEGIN       
    DELETE FROM GruposDetalles WHERE IdGrupoDetalle=@IdGrupoDetalle      
 END
 GO

DROP PROCEDURE IF EXISTS sp_ListarGrupoDetalle;
GO
CREATE PROCEDURE sp_ListarGrupoDetalle
 AS        
 BEGIN        
    SELECT * FROM GruposDetalles      
 END
 GO

 --CRUDL PERSONAS
 DROP PROCEDURE IF EXISTS sp_AgregarPersonas;
GO
CREATE PROCEDURE sp_AgregarPersonas
 (      
    @Nombres VARCHAR(50),      
    @IdTipoPersona INT,
	@CiRif VARCHAR(11),
	@Direccion VARCHAR(100),
	@Telefonos VARCHAR(60),
	@Email VARCHAR(60),
	@FechaRegistro DATETIME     
 )      
 AS      
 BEGIN      
    INSERT INTO Personas VALUES(@Nombres,@IdTipoPersona,@CiRif,@Direccion,@Telefonos,@Email,@FechaRegistro)      
 END
 GO

DROP PROCEDURE IF EXISTS sp_ActualizarPersonas;
GO
CREATE PROCEDURE sp_ActualizarPersonas
 (  
	@IdPersona INT,
	@Nombres VARCHAR(50),      
    @IdTipoPersona INT,
	@CiRif VARCHAR(11),
	@Direccion VARCHAR(100),
	@Telefonos VARCHAR(60),
	@Email VARCHAR(60),
	@FechaRegistro DATETIME     
 )      
 AS      
 BEGIN      
    UPDATE Personas      
    SET Nombres=@Nombres,      
		IdTipoPersona=@IdTipoPersona,      
		CiRif= @CiRif,
		Direccion=@Direccion,
		Telefonos=@Telefonos,
		Email=@Email,
		FechaRegistro=@FechaRegistro
		WHERE IdPersona = @IdPersona	
 END
 GO      
     
DROP PROCEDURE IF EXISTS sp_EliminarPersonas;
GO   
CREATE PROCEDURE sp_EliminarPersonas
 (      
    @IdPersona INT      
 )      
 AS      
 BEGIN       
    DELETE FROM Personas WHERE IdPersona=@IdPersona      
 END
 GO

DROP PROCEDURE IF EXISTS sp_ListarPersonas;
GO
CREATE PROCEDURE sp_ListarPersonas
 AS        
 BEGIN        
    SELECT * FROM Personas      
 END
 GO