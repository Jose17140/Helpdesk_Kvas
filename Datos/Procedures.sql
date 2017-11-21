USE Helpdesk_Kvas
GO

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

--LISTAR GRUPODETALLES POR GRUPO
DROP PROCEDURE IF EXISTS sp_ListarDetalles_x_Grupo;
GO   
CREATE PROCEDURE sp_ListarDetalles_x_Grupo      
 (      
    @IdGrupo INT      
 )      
 AS      
 BEGIN       
    SELECT gd.IdGrupoDetalle, gd.Nombre, gd.Descripcion, gd.Orden, g.Nombre AS Grupo, gd.IdPadre AS Categoria, gd.Icono, gd.UrlDetalle, gd.Estatus, gd.FechaRegistro
	FROM Grupos AS g
	INNER JOIN GruposDetalles AS gd ON g.IdGrupo = gd.IdGrupo
	WHERE g.IdGrupo = 1 AND g.Estatus = 1 AND gd.Estatus = 1
	ORDER BY IdGrupoDetalle ASC     
 END
 GO