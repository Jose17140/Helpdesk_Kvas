USE Helpdesk_Kvas
GO

--NIVEL DE RECURSIVIDAD EN EL GRUPO
DROP PROCEDURE IF EXISTS sp_ListarNivel;
GO
CREATE PROCEDURE sp_ListarNivelGrupo(
	@IdGrupo INT )
	AS
		BEGIN
			WITH Cte_Grupos(IdGrupo,Nombre,Descripcion,IdPadre,Icono,Estatus,FechaRegistro, LevelGrupo) AS (
				SELECT g.IdGrupo, g.Nombre, g.Descripcion, g.IdPadre, g.Icono, g.Estatus, g.FechaRegistro, 0 AS LevelGrupo
				FROM Grupos AS g
				WHERE g.IdPadre is null
				UNION ALL
				SELECT gd.IdGrupo, gd.Nombre, gd.Descripcion, gd.IdPadre, gd.Icono, gd.Estatus, gd.FechaRegistro, LevelGrupo+1
				FROM Grupos AS gd
				INNER JOIN Cte_Grupos AS cte ON gd.IdPadre = cte.IdGrupo
			)
			SELECT ct.IdGrupo, ct.Nombre, ct.Descripcion, ct.IdPadre, c.IdGrupo AS IdGrupoPadre, c.Nombre AS Categoria, ct.Icono, ct.Estatus, ct.FechaRegistro, ct.LevelGrupo
			FROM Cte_Grupos AS ct
			INNER JOIN Cte_Grupos AS c ON ct.IdPadre = c.IdGrupo
			WHERE ct.IdGrupo = @IdGrupo
			ORDER BY ct.LevelGrupo ASC
		END
GO

--PERSONAS
DROP VIEW IF EXISTS vw_Personas;
GO
CREATE VIEW vw_Personas
AS
	SELECT p.IdPersona, p.Nombres, CONCAT(gd.Nombre,p.CiRif) AS Cedula, p.Direccion, p.Telefonos, p.Email, p.FechaRegistro
	FROM Personas AS p
	INNER JOIN GruposDetalles AS gd ON P.IdTipoPersona = gd.IdGrupoDetalle
GO

--GRUPOSDETALLES
DROP VIEW IF EXISTS vw_GruposDetalles;
GO
CREATE VIEW vw_GruposDetalles AS
	WITH Cte_GruposDetalles(IdGrupoDetalle,Nombre,Descripcion,Orden,IdGrupo,IdPadre,Imagen,UrlDetalle,Estatus,FechaRegistro, LevelGrupo) AS (
		SELECT g.IdGrupoDetalle, g.Nombre, g.Descripcion, g.Orden, g.IdGrupo, g.IdPadre, g.Imagen, g.UrlDetalle, g.Estatus, g.FechaRegistro, 0 AS LevelGrupo
		FROM GruposDetalles AS g
		WHERE g.IdPadre is null
		UNION ALL
		SELECT gd.IdGrupoDetalle, gd.Nombre, gd.Descripcion, gd.Orden, gd.IdGrupo, gd.IdPadre, gd.Imagen, gd.UrlDetalle, gd.Estatus, gd.FechaRegistro, LevelGrupo+1
		FROM GruposDetalles AS gd
		INNER JOIN Cte_GruposDetalles AS cte ON gd.IdPadre = cte.IdGrupoDetalle
	)
	SELECT ct.IdGrupoDetalle, ct.Nombre, ct.Descripcion, ct.Orden, ct.IdGrupo, g.Nombre AS NombreGrupo, ct.IdPadre, c.IdGrupo AS IdGrupoPadre, c.Nombre AS Categoria, ct.Imagen, ct.UrlDetalle, ct.Estatus, ct.FechaRegistro, ct.LevelGrupo
	FROM Cte_GruposDetalles AS ct
	INNER JOIN Cte_GruposDetalles AS c ON ct.IdPadre = c.IdGrupoDetalle
	INNER JOIN Grupos AS g ON ct.IdGrupo = g.IdGrupo
GO
--MENU
DROP VIEW IF EXISTS vw_Menu;
GO
CREATE VIEW vw_Menu AS
WITH Cte_GruposDetalles(IdGrupoDetalle,Nombre,Descripcion,Orden,IdGrupo,IdPadre,Imagen,UrlDetalle,Estatus,FechaRegistro, LevelGrupo) AS (
		SELECT g.IdGrupoDetalle, g.Nombre, g.Descripcion, g.Orden, g.IdGrupo, g.IdPadre, g.Imagen, g.UrlDetalle, g.Estatus, g.FechaRegistro, 0 AS LevelGrupo
		FROM GruposDetalles AS g
		WHERE g.IdPadre is null
		UNION ALL
		SELECT gd.IdGrupoDetalle, gd.Nombre, gd.Descripcion, gd.Orden, gd.IdGrupo, gd.IdPadre, gd.Imagen, gd.UrlDetalle, gd.Estatus, gd.FechaRegistro, LevelGrupo+1
		FROM GruposDetalles AS gd
		INNER JOIN Cte_GruposDetalles AS cte ON gd.IdPadre = cte.IdGrupoDetalle
	)
	SELECT ct.IdGrupoDetalle, ct.Nombre, ct.Descripcion, ct.Orden, ct.IdGrupo, g.Nombre AS NombreGrupo, c.IdGrupo AS IdGrupoPadre, ct.IdPadre, c.Nombre AS Categoria, ct.Imagen, ct.UrlDetalle, ct.Estatus, ct.FechaRegistro, ct.LevelGrupo
	FROM Cte_GruposDetalles AS ct
	INNER JOIN Cte_GruposDetalles AS c ON ct.IdPadre = c.IdGrupoDetalle
	INNER JOIN Grupos AS g ON ct.IdGrupo = g.IdGrupo
	WHERE ct.IdGrupo IN(1,2)
GO
-- USUARIO
DROP PROCEDURE IF EXISTS sp_AgregarUsuario;
GO
CREATE PROCEDURE sp_AgregarUsuario
 (      
    @NombreUsuario VARCHAR(30),      
    @Contrasena VARCHAR(100),
	@Email VARCHAR(60),
	@IdPregunta INT,
	@Respuesta VARCHAR(50),
	@Avatar VARCHAR(30),
	@Estatus BIT,
	@FechaRegistro DATETIME,
	@IdRole INT
 )      
 AS      
 BEGIN
	DECLARE @Id INT 
    INSERT INTO Usuarios(NombreUsuario,Contrasena,Email,IdPreguntaSeguridad,RespuestaSeguridad,Avatar,Estatus,FechaRegistro) VALUES
	(@NombreUsuario,@Contrasena,@Email,@IdPregunta,@Respuesta,@Avatar,@Estatus,@FechaRegistro)
	SELECT @Id = SCOPE_IDENTITY();
	INSERT INTO UsuariosRoles(IdUsuario,IdRoles)VALUES(@Id,@IdRole)
 END
 GO

DROP PROCEDURE IF EXISTS sp_ActualizarUsuario;
GO
CREATE PROCEDURE sp_ActualizarUsuario
 (  
	@IdUsuario INT,
    @Contrasena VARCHAR(100),
	@Email VARCHAR(60),
	@IdPregunta INT,
	@Respuesta VARCHAR(50),
	@Estatus BIT,
	@FechaModificacion DATETIME,
	@IdRole INT
 )      
 AS      
 BEGIN      
    UPDATE Usuarios      
    SET Contrasena=@Contrasena,      
		Email=@Email,      
		IdPreguntaSeguridad=@IdPregunta,
		RespuestaSeguridad=@Respuesta,
		Estatus=@Estatus,
		FechaModificacion = @FechaModificacion
		WHERE IdUsuario = @IdUsuario;
	UPDATE UsuariosRoles
	SET IdRoles = @IdRole
	WHERE IdUsuario = @IdUsuario
 END
 GO

DROP PROCEDURE IF EXISTS sp_BuscarUsuarios;
GO
CREATE PROCEDURE sp_BuscarUsuarios
( 
	@id INT
)
 AS        
 BEGIN        
    SELECT u.IdUsuario, u.NombreUsuario, u.Contrasena, u.Email AS Correo, ur.IdRoles,gd.Nombre AS NombreRol, u.IdPreguntaSeguridad AS IdPregunta, gdd.Nombre AS Pregunta, u.RespuestaSeguridad,
		u.Avatar, u.FechaLogin, u.ContadorFallido, u.Estatus, u.FechaRegistro, u.FechaModificacion
	FROM Usuarios AS u
	INNER JOIN UsuariosRoles AS ur ON u.IdUsuario = ur.IdUsuario
	INNER JOIN GruposDetalles AS gd ON ur.IdRoles = gd.IdGrupoDetalle
	INNER JOIN GruposDetalles AS gdd ON u.IdPreguntaSeguridad = gdd.IdGrupoDetalle
	WHERE u.IdUsuario = @id      
 END
 GO

DROP VIEW IF EXISTS vw_ListarUsuarios;
GO
CREATE VIEW vw_ListarUsuarios
 AS
	SELECT u.IdUsuario, u.NombreUsuario, u.Contrasena, u.Email AS Correo, ur.IdRoles,gd.Nombre AS NombreRol, u.IdPreguntaSeguridad AS IdPregunta, gdd.Nombre AS Pregunta, u.RespuestaSeguridad,
		u.Avatar, u.FechaLogin, u.ContadorFallido, u.Estatus, u.FechaRegistro, u.FechaModificacion
	FROM Usuarios AS u
	INNER JOIN UsuariosRoles AS ur ON u.IdUsuario = ur.IdUsuario
	INNER JOIN GruposDetalles AS gd ON ur.IdRoles = gd.IdGrupoDetalle
	INNER JOIN GruposDetalles AS gdd ON u.IdPreguntaSeguridad = gdd.IdGrupoDetalle         
 GO

-- --PRODUCTOS
--DROP VIEW IF EXISTS vw_ListarProductos;
--GO
--CREATE VIEW vw_ListarProductos     
-- AS     
--    WITH Cte_Productos(IdGrupoDetalle,Nombre,Descripcion,Orden,IdGrupo,IdPadre,Icono,UrlDetalle,Estatus,FechaRegistro, LevelGrupo) AS (
--		SELECT g.IdGrupoDetalle, g.Nombre, g.Descripcion, g.Orden, g.IdGrupo, g.IdPadre, g.Icono, g.UrlDetalle, g.Estatus, g.FechaRegistro, 0 AS LevelGrupo
--		FROM GruposDetalles AS g
--		WHERE g.IdPadre is null
--		UNION ALL
--		SELECT gd.IdGrupoDetalle, gd.Nombre, gd.Descripcion, gd.Orden, gd.IdGrupo, gd.IdPadre, gd.Icono, gd.UrlDetalle, gd.Estatus, gd.FechaRegistro, LevelGrupo+1
--		FROM GruposDetalles AS gd
--		INNER JOIN Cte_Productos AS cte ON gd.IdPadre = cte.IdGrupoDetalle
--	)
--	SELECT ct.IdGrupoDetalle AS IdProducto, ps.Sku, ct.Nombre, ct.Descripcion, ct.Orden, ct.IdGrupo, g.Nombre AS Grupo, ct.IdPadre, c.Nombre AS Padre, ct.Icono, ct.UrlDetalle, 
--			ps.IdFabricante, gd.Nombre AS Fabricante, ps.Stock, ps.Stock_Min, ps.IdUnidad, gdd.Nombre AS Unidad, ps.Garantia, ps.PrecioCompra, ps.PrecioVenta, ct.Estatus, ct.FechaRegistro
--	FROM Cte_Productos AS ct
--	INNER JOIN Cte_Productos AS c ON ct.IdPadre = c.IdGrupoDetalle
--	INNER JOIN Grupos AS g ON ct.IdGrupo = g.IdGrupo
--	LEFT JOIN PSDetalles AS ps ON ct.IdGrupoDetalle = ps.IdProducto
--	LEFT JOIN GruposDetalles AS gd ON ps.IdFabricante = gd.IdGrupoDetalle
--	LEFT JOIN GruposDetalles AS gdd ON ps.IdUnidad = gdd.IdGrupoDetalle
--	WHERE ct.IdGrupo = 9    
-- GO

--DROP PROCEDURE IF EXISTS sp_BuscarProducto;
--GO   
--CREATE PROCEDURE sp_BuscarProducto
-- (      
--    @IdProducto INT      
-- )      
-- AS      
-- BEGIN       
--    WITH Cte_Productos(IdGrupoDetalle,Nombre,Descripcion,Orden,IdGrupo,IdPadre,Icono,UrlDetalle,Estatus,FechaRegistro, LevelGrupo) AS (
--		SELECT g.IdGrupoDetalle, g.Nombre, g.Descripcion, g.Orden, g.IdGrupo, g.IdPadre, g.Icono, g.UrlDetalle, g.Estatus, g.FechaRegistro, 0 AS LevelGrupo
--		FROM GruposDetalles AS g
--		WHERE g.IdPadre is null
--		UNION ALL
--		SELECT gd.IdGrupoDetalle, gd.Nombre, gd.Descripcion, gd.Orden, gd.IdGrupo, gd.IdPadre, gd.Icono, gd.UrlDetalle, gd.Estatus, gd.FechaRegistro, LevelGrupo+1
--		FROM GruposDetalles AS gd
--		INNER JOIN Cte_Productos AS cte ON gd.IdPadre = cte.IdGrupoDetalle
--	)
--	SELECT ct.IdGrupoDetalle AS IdProducto, ps.Sku, ct.Nombre AS Titulo, ct.Descripcion, ct.Orden, ct.IdGrupo, g.Nombre AS Grupo, ct.IdPadre, c.Nombre AS Padre, ct.Icono, ct.UrlDetalle, ct.Estatus, 
--			ps.IdFabricante, gd.Nombre AS Fabricante, ps.Stock, ps.Stock_Min, ps.IdUnidad, ps.Garantia, ps.PrecioCompra, ps.PrecioVenta, ct.FechaRegistro
--	FROM Cte_Productos AS ct
--	INNER JOIN Cte_Productos AS c ON ct.IdPadre = c.IdGrupoDetalle
--	INNER JOIN Grupos AS g ON ct.IdGrupo = g.IdGrupo
--	LEFT JOIN PSDetalles AS ps ON ct.IdGrupoDetalle = ps.IdProducto
--	LEFT JOIN GruposDetalles AS gd ON ps.IdFabricante = gd.IdGrupoDetalle
--	WHERE ct.IdGrupoDetalle = @IdProducto
--	ORDER BY ct.LevelGrupo ASC    
-- END
-- GO

----CRUDL PRODUCTOS
--IF OBJECT_ID('sp_AgregarProducto') IS NOT NULL
--BEGIN 
--	DROP PROC sp_AgregarProducto 
--END
--GO
--CREATE PROCEDURE sp_AgregarProducto (
--	@Nombre VARCHAR(50),      
--    @Descripcion VARCHAR(50),      
--    @Orden INT,
--	@IdGrupo INT,
--	@IdPadre INT,
--	@Icono VARCHAR(30), -- DIRECTORIO DONDE ESTA LA IMAGEN
--	@UrlDetalle VARCHAR(100),
--	@Estatus BIT,
--	@FechaRegistro DATETIME,
--	@Sku VARCHAR(24),
--	@IdFabricante INT,
--	@IdEquipo INT,
--	@Stock INT,
--	@IdUnidad INT,
--	@StockMin INT,
--	@PrecioCompra DECIMAL(8,2),
--	@PrecioVenta DECIMAL(8,2),
--	@Garantia INT
--)
--	AS
--	BEGIN TRY
--		BEGIN TRAN Products
--			DECLARE @Id INT
--			INSERT INTO GruposDetalles VALUES(@Nombre,@Descripcion,@Orden,@IdGrupo,@IdPadre,@Icono,@UrlDetalle,@Estatus,@FechaRegistro)
--			SELECT @Id = SCOPE_IDENTITY();
--			INSERT INTO PSDetalles VALUES (@Id,@Sku,@IdFabricante,@Stock,@IdUnidad,@IdEquipo,@StockMin,@PrecioCompra,@PrecioVenta,@Garantia)
--		COMMIT TRANSACTION Products
--	END TRY
--	BEGIN CATCH
--		SELECT ERROR_NUMBER() AS errNumber,
--			   ERROR_SEVERITY() AS errSeverity,
--			   ERROR_STATE() AS errState,
--			   ERROR_PROCEDURE() AS errProcedure,
--			   ERROR_LINE() AS errLine,
--			   ERROR_MESSAGE() AS errMessage
--		ROLLBACK TRAN Products
--	END CATCH
--GO

--IF OBJECT_ID('sp_ActualizarProducto') IS NOT NULL
--BEGIN 
--	DROP PROC sp_ActualizarProducto 
--END
--GO
--CREATE PROCEDURE sp_ActualizarProducto (
--	@Id INT,
--	@Nombre VARCHAR(50),      
--    @Descripcion VARCHAR(50),      
--    @Orden INT,
--	@IdGrupo INT,
--	@IdPadre INT,
--	@Icono VARCHAR(30), -- DIRECTORIO DONDE ESTA LA IMAGEN
--	@UrlDetalle VARCHAR(100),
--	@Estatus BIT,
--	@Sku VARCHAR(24),
--	@IdFabricante INT,
--	@IdEquipo INT,
--	@Stock INT,
--	@IdUnidad INT,
--	@StockMin INT,
--	@PrecioCompra DECIMAL(8,2),
--	@PrecioVenta DECIMAL(8,2),
--	@Garantia INT
--)	
--	AS
--	BEGIN TRY
--		BEGIN TRAN Products
--			UPDATE GruposDetalles SET
--				Nombre= @Nombre,      
--				Descripcion= @Descripcion,      
--				Orden= @Orden,
--				IdGrupo= @IdGrupo,
--				IdPadre= @IdPadre,
--				Icono= @Icono, -- DIRECTORIO DONDE ESTA LA IMAGEN
--				UrlDetalle= @UrlDetalle,
--				Estatus= @Estatus
--				WHERE IdGrupoDetalle = @Id;
--			UPDATE PSDetalles SET
--				Sku= @Sku,
--				IdFabricante= @IdFabricante,
--				Stock= @Stock,
--				IdUnidad= @IdUnidad,
--				Stock_Min= @StockMin,
--				PrecioCompra= @PrecioCompra,
--				PrecioVenta= @PrecioVenta,
--				Garantia= @Garantia
--				WHERE IdProducto = @Id;
--		COMMIT TRANSACTION Products
--	END TRY
--	BEGIN CATCH
--		SELECT ERROR_NUMBER() AS errNumber,
--			   ERROR_SEVERITY() AS errSeverity,
--			   ERROR_STATE() AS errState,
--			   ERROR_PROCEDURE() AS errProcedure,
--			   ERROR_LINE() AS errLine,
--			   ERROR_MESSAGE() AS errMessage
--			   ROLLBACK TRAN Products
--	END CATCH
--GO

--IF OBJECT_ID('sp_OperacionesInventarioProducto') IS NOT NULL
--BEGIN 
--	DROP PROC sp_OperacionesInventarioProducto 
--END
--GO
--CREATE PROCEDURE sp_OperacionesInventarioProducto (
--	@Id INT,
--	@Operador INT,
--	@Stock INT,
--	@PrecioCompra DECIMAL(8,2),
--	@PrecioVenta DECIMAL(8,2)
--)	
--	AS
--	BEGIN TRY
--		BEGIN TRAN Products
--			IF @Operador = 1
--			UPDATE PSDetalles SET
--				Stock= Stock+@Stock,
--				PrecioCompra= @PrecioCompra,
--				PrecioVenta= @PrecioVenta
--				WHERE IdProducto = @Id;
--			IF @Operador = 2
--			UPDATE PSDetalles SET
--				Stock= Stock-@Stock,
--				PrecioCompra= @PrecioCompra,
--				PrecioVenta= @PrecioVenta
--				WHERE IdProducto = @Id;
--		COMMIT TRANSACTION Products
--	END TRY
--	BEGIN CATCH
--		SELECT ERROR_NUMBER() AS errNumber,
--			   ERROR_SEVERITY() AS errSeverity,
--			   ERROR_STATE() AS errState,
--			   ERROR_PROCEDURE() AS errProcedure,
--			   ERROR_LINE() AS errLine,
--			   ERROR_MESSAGE() AS errMessage
--			   ROLLBACK TRAN Products
--	END CATCH
--GO