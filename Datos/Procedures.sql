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
	WHERE g.IdGrupo = 1 AND g.Estatus = 1 AND gd.Estatus = 1
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
	@UrlDetalle VARCHAR(100),
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
	@UrlDetalle VARCHAR(100),
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
	@Email VARCHAR(60)   
 )      
 AS      
 BEGIN      
    UPDATE Personas      
    SET Nombres=@Nombres,      
		IdTipoPersona=@IdTipoPersona,      
		CiRif=@CiRif,
		Direccion=@Direccion,
		Telefonos=@Telefonos,
		Email=@Email
		WHERE IdPersona = @IdPersona	
 END
 GO

DROP PROCEDURE IF EXISTS sp_ActualizarPersonasSimple;
GO
CREATE PROCEDURE sp_ActualizarPersonasSimple
 (  
	@IdPersona INT,
	@Nombres VARCHAR(50),
	@Direccion VARCHAR(100),
	@Telefonos VARCHAR(60),
	@Email VARCHAR(60)   
 )      
 AS      
 BEGIN      
    UPDATE Personas      
    SET Nombres=@Nombres,
		Direccion=@Direccion,
		Telefonos=@Telefonos,
		Email=@Email
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
--VISTA PERSONAS
DROP VIEW IF EXISTS vw_Personas;
GO
CREATE VIEW vw_Personas
AS
	SELECT p.IdPersona, p.Nombres, CONCAT(gd.Nombre,p.CiRif) AS Cedula, p.Direccion, p.Telefonos, p.Email, p.FechaRegistro
	FROM Personas AS p
	INNER JOIN GruposDetalles AS gd ON P.IdTipoPersona = gd.IdGrupoDetalle
GO

SELECT * FROM GruposDetalles;
SELECT * FROM PSDetalles;

 --CRUDL PRODUCTOS
IF OBJECT_ID('sp_AgregarProducto') IS NOT NULL
BEGIN 
	DROP PROC sp_AgregarProducto 
END
GO
CREATE PROCEDURE sp_AgregarProducto (
	@Nombre VARCHAR(50),      
    @Descripcion VARCHAR(50),      
    @Orden INT,
	@IdGrupo INT,
	@IdPadre INT,
	@Icono VARCHAR(30), -- DIRECTORIO DONDE ESTA LA IMAGEN
	@UrlDetalle VARCHAR(100),
	@Estatus BIT,
	@FechaRegistro DATETIME,
	@Sku VARCHAR(24),
	@IdDepartamento INT,
	@IdFabricante INT,
	@Stock INT,
	@IdUnidad INT,
	@StockMin INT,
	@PrecioCompra DECIMAL(8,2),
	@PrecioVenta DECIMAL(8,2),
	@Garantia INT
)	
	AS
	BEGIN TRY
		BEGIN TRAN Products
			DECLARE @Id INT
			INSERT INTO GruposDetalles VALUES(@Nombre,@Descripcion,@Orden,@IdGrupo,@IdPadre,@Icono,@UrlDetalle,@Estatus,@FechaRegistro)
			SELECT @Id = SCOPE_IDENTITY();
			INSERT INTO PSDetalles VALUES (@Id,@Sku,@IdDepartamento,@IdFabricante,@Stock,@IdUnidad,@StockMin,@PrecioCompra,@PrecioVenta,@Garantia)
		COMMIT TRANSACTION Products
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS errNumber,
			   ERROR_SEVERITY() AS errSeverity,
			   ERROR_STATE() AS errState,
			   ERROR_PROCEDURE() AS errProcedure,
			   ERROR_LINE() AS errLine,
			   ERROR_MESSAGE() AS errMessage
		ROLLBACK TRAN Products
	END CATCH
GO

IF OBJECT_ID('sp_ActualizarProducto') IS NOT NULL
BEGIN 
	DROP PROC sp_ActualizarProducto 
END
GO
CREATE PROCEDURE sp_ActualizarProducto (
	@Id INT,
	@Nombre VARCHAR(50),      
    @Descripcion VARCHAR(50),      
    @Orden INT,
	@IdGrupo INT,
	@IdPadre INT,
	@Icono VARCHAR(30), -- DIRECTORIO DONDE ESTA LA IMAGEN
	@UrlDetalle VARCHAR(100),
	@Estatus BIT,
	@Sku VARCHAR(24),
	@IdDepartamento INT,
	@IdFabricante INT,
	@Stock INT,
	@IdUnidad INT,
	@StockMin INT,
	@PrecioCompra DECIMAL(8,2),
	@PrecioVenta DECIMAL(8,2),
	@Garantia INT
)	
	AS
	BEGIN TRY
		BEGIN TRAN Products
			UPDATE GruposDetalles SET
				Nombre= @Nombre,      
				Descripcion= @Descripcion,      
				Orden= @Orden,
				IdGrupo= @IdGrupo,
				IdPadre= @IdPadre,
				Icono= @Icono, -- DIRECTORIO DONDE ESTA LA IMAGEN
				UrlDetalle= @UrlDetalle,
				Estatus= @Estatus
				WHERE IdGrupoDetalle = @Id;
			UPDATE PSDetalles SET
				Sku= @Sku,
				IdDepartamento= @IdDepartamento,
				IdFabricante= @IdFabricante,
				Stock= @Stock,
				IdUnidad= @IdUnidad,
				Stock_Min= @StockMin,
				PrecioCompra= @PrecioCompra,
				PrecioVenta= @PrecioVenta,
				Garantia= @Garantia
				WHERE IdProducto = @Id;
		COMMIT TRANSACTION Products
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS errNumber,
			   ERROR_SEVERITY() AS errSeverity,
			   ERROR_STATE() AS errState,
			   ERROR_PROCEDURE() AS errProcedure,
			   ERROR_LINE() AS errLine,
			   ERROR_MESSAGE() AS errMessage
			   ROLLBACK TRAN Products
	END CATCH
GO

IF OBJECT_ID('sp_OperacionesInventarioProducto') IS NOT NULL
BEGIN 
	DROP PROC sp_OperacionesInventarioProducto 
END
GO
CREATE PROCEDURE sp_OperacionesInventarioProducto (
	@Id INT,
	@Operador INT,
	@Stock INT,
	@PrecioCompra DECIMAL(8,2),
	@PrecioVenta DECIMAL(8,2)
)	
	AS
	BEGIN TRY
		BEGIN TRAN Products
			IF @Operador = 1
			UPDATE PSDetalles SET
				Stock= Stock+@Stock,
				PrecioCompra= @PrecioCompra,
				PrecioVenta= @PrecioVenta
				WHERE IdProducto = @Id;
			IF @Operador = 2
			UPDATE PSDetalles SET
				Stock= Stock-@Stock,
				PrecioCompra= @PrecioCompra,
				PrecioVenta= @PrecioVenta
				WHERE IdProducto = @Id;
		COMMIT TRANSACTION Products
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS errNumber,
			   ERROR_SEVERITY() AS errSeverity,
			   ERROR_STATE() AS errState,
			   ERROR_PROCEDURE() AS errProcedure,
			   ERROR_LINE() AS errLine,
			   ERROR_MESSAGE() AS errMessage
			   ROLLBACK TRAN Products
	END CATCH
GO

DROP PROCEDURE IF EXISTS sp_EliminarProducto;
GO   
CREATE PROCEDURE sp_EliminarProducto
 (      
    @IdProducto INT      
 )      
 AS      
 BEGIN       
    DELETE FROM GruposDetalles WHERE IdGrupoDetalle=@IdProducto      
 END
 GO

DROP PROCEDURE IF EXISTS sp_BuscarProducto;
GO   
CREATE PROCEDURE sp_BuscarProducto
 (      
    @IdProducto INT      
 )      
 AS      
 BEGIN       
    SELECT gd.IdGrupoDetalle, gd.Nombre, gd.Descripcion, gd.Orden, gd.Nombre AS Categoria, gd.Icono, gd.UrlDetalle, gd.Estatus, gd.FechaRegistro
	FROM Grupos AS g
	INNER JOIN GruposDetalles AS gd ON g.IdGrupo = gd.IdGrupo
	WHERE g.IdGrupo = @IdProducto AND g.Estatus = 1 AND gd.Estatus = 1
	ORDER BY IdGrupoDetalle ASC     
 END
 GO

 GO
 CREATE VIEW vw_ProductoSimple AS
	SELECT gd.IdGrupoDetalle AS IdProducto, gd.Nombre, gd.Descripcion, gd.Orden, gd.IdGrupo, gd.IdPadre, gd.Icono, ps.Sku, ps.IdDepartamento, ps.IdFabricante, ps.Stock, ps.Stock_Min, ps.PrecioCompra, ps.PrecioVenta, ps.Garantia, gd.Estatus, gd.FechaRegistro
	FROM GruposDetalles AS gd
	INNER JOIN PSDetalles AS ps ON gd.IdGrupoDetalle = ps.IdProducto

