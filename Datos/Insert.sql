-- INSERTANDO DATOS TABLA GRUPOS
USE Helpdesk_Kvas
GO
--GRUPO DE MENU
INSERT INTO Grupos(Nombre,Descripcion,UrlGrupo,Icono,Estatus,FechaRegistro)VALUES 
('Nulo','Agrupa las Tablas Nulas','/','fa fa-bars',1,GETDATE()),
('Menu','Agrupa el Menu slidebar de la app','/','fa fa-bars',1,GETDATE()),
('TipoPersona','Tipo de Identificacion de los Usuarios','/','fa fa-pause',1,GETDATE()),
('Sexos','Genero de las personas','/','fa fa-venus-mars',1,GETDATE()),
('Pais','Paises','/','fa fa-pause',1,GETDATE()),
('Estados','Estamos de los paises','/','fa fa-pause',1,GETDATE()),
('Categorias','Categorias de productos o servicio','/','fa fa-pause',1,GETDATE()),
('Equipos','Equipos a recibir','/','fa fa-laptop',1,GETDATE()),
('Servicios','Servicios que se realizan','/','fa fa-pause',1,GETDATE()),
('Productos','Agrupa Productos','/','fa fa-edit',1,GETDATE()),
('Tipos de Pagos','tipos de Pago','/','fa fa-cc-visa',1,GETDATE()),
('Estatus','Estatus de los requerimientos','/','fa fa-pause',1,GETDATE()),
('Fabricantes','fabricantes de los equipos','/','fa fa-shopping-cart',1,GETDATE()),
('Modelos','Modelo de los equipos','/','fa fa-pause',1,GETDATE()),
('Fallas','Agrupa Fallas de sistema','/','fa fa-wrench',1,GETDATE()),
('Accesorios','Accesorios que se entregan con el equipo','/','fa fa-pause',1,GETDATE()),
('Preguntas de Seguridad','Pregunta de seguridad al login','/','fa fa-question-circle',1,GETDATE()),
('Prioridades','Prioridad del requerimiento','/','fa fa-pause',1,GETDATE()),
('Departamentos','Departamentos de servicio','/','fa fa-pause',1,GETDATE()),
('Cargos','Cargo de los empleados','/','fa fa-pause',1,GETDATE()),
('Impuestos','Alicuota de Impuestas','/','fa fa-edit',1,GETDATE()),
('Roles','Roles de Usuario','/','fa fa-edit',1,GETDATE()),
('Permisos','Permisos por Usuarios','/','fa fa-edit',1,GETDATE()),
('Unidad','Tipos de unidades de Venta','/','fa fa-edit',1,GETDATE());
-- INSERTANDO DATOS TABLA DESCRIPCION DE GRUPOS
--MENUS '/',
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Nulos','Agrupa Detalles nulos',0,'Nulo',0,0,'/',GETDATE()),
('Registro','Registro de Clientes, Ticket y Organizaciones',1,'fa fa-plus-circle',1,0,'/',GETDATE()),
('Requerimientos','Menu',1,'fa fa-ticket',2,0,'/',GETDATE()),
('Catalogo','Menu',1,'fa  fa-tags',3,0,'/',GETDATE()),
('Clientes','Menu',1,'fa fa-users',4,0,'/',GETDATE()),
('Informes','Menu',1,'fa fa-bar-chart',5,0,'/',GETDATE()),
('Base de Conocimientos','Menu',1,'fa fa-database',6,0,'/',GETDATE()),
('Documentacion','Menu',1,'fa fa-book',7,0,'/',GETDATE()),
('Sistema','Menu',1,'fa fa-cogs',8,0,'/',GETDATE());
--SUB MENUS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Cliente','Menu',1,'fa fa-user',1,1,'/',GETDATE()),
('Ticket','Menu',1,'fa fa-sticky-note-o',2,1,'/',GETDATE()),
('Organizacion','Menu',1,'fa fa-institution',3,1,'/',GETDATE()),
('Buscar','Menu',1,'fa fa-search',4,1,'/',GETDATE());
--CATALOGO MENU
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Productos','Menu',1,'fa fa-laptop',1,3,'/',GETDATE()),
('Servicios','Menu',1,'fa fa-puzzle-piece',2,3,'/',GETDATE());
--PRODUCTOS MENU
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Productos','Menu',1,'fa  fa-tablet',1,13,'/',GETDATE()),
('Fabricantes','Menu',1,'fa fa-bank',2,13,'/',GETDATE()),
('Categorias','Menu',1,'fa fa-bookmark-o',3,13,'/',GETDATE()),
('Movimiento de Inventario','Menu',1,'fa fa-pencil-square-o',4,13,'/',GETDATE());
--SISTEMA MENU
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Configuracion','Menu',1,'fa fa-cog',1,8,'/',GETDATE()),
('Usuarios','Menu',1,'fa fa-users',2,8,'/',GETDATE()),
('Herramientas','Menu',1,'fa fa-wrench',3,8,'/',GETDATE());
--SUB MENU SISTEMA
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Tienda','Menu',1,'fa fa-home',1,19,'/',GETDATE()),
('Entidades','Menu',1,'fa fa-bars',3,19,'/Grupo/Index',GETDATE()),
('Respaldos','Menu',1,'fa fa-database',1,21,'/',GETDATE()),
('Log','Menu',1,'fa fa-circle-o',2,21,'/',GETDATE());
--USUARIOS Y ROLES MENU
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Usuarios','Menu',1,'fa fa-user',1,20,'/',GETDATE()),
('Roles','Menu',1,'fa fa-archive',3,20,'/',GETDATE());
--TIPOS DE PERSONAS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,FechaRegistro)VALUES
('V','Venezolano',2,'fa fa-flag-o',1,0, GETDATE()),
('E','Extranjero',2,'fa fa-flag-o',2,0, GETDATE()),
('J','Juridico',2,'fa fa-flag-o',3,0, GETDATE()),
('G','Gubernamental',2,'fa fa-flag-o',4,0, GETDATE());
--INSERTAR PERSONAS
INSERT personas (Nombres, IdTipoPersona, CiRif, Direccion, Telefonos,Imagen, Email, FechaRegistro) VALUES 
( N'JUAN ARCOS', 28, N'22012345', N'Caracas', N'04265556677', 'RutaImagen', N'help@help.com', GETDATE()),
( N'YADELSY REYES', 28, N'22012346', N'Caracas', N'04265556677', 'RutaImagen', N'help@help.com', GETDATE()),
( N'TERESA BRAVO', 28, N'22012347', N'Caracas', N'04265556677', 'RutaImagen', N'help@help.com', GETDATE()),
( N'ANA PRINCIPE', 28, N'22012348', N'Caracas', N'04265556677', 'RutaImagen', N'help@help.com', GETDATE()),
( N'LUIS TORRES', 28, N'22012349', N'Caracas', N'04265556677', 'RutaImagen', N'help@help.com', GETDATE()),
( N'MARIA OSPINA', 28, N'22012350', N'Caracas', N'04265556677', 'RutaImagen', N'help@help.com', GETDATE()),
( N'ANYELI MORA', 28, N'21018642', N'Caracas', N'04265556677', 'RutaImagen', N'help@help.com', GETDATE()),
( N'ROSNELLY MORA', 28, N'21018643', N'Caracas', N'04265556677', 'RutaImagen', N'help@help.com', GETDATE()),
( N'MARIA GUEVARA', 28, N'21018645', N'Caracas', N'04265556677', 'RutaImagen', N'help@help.com', GETDATE()),
( N'MARIA GUEVARA', 28, N'21018646', N'Caracas', N'04265556677', 'RutaImagen', N'help@help.com', GETDATE()),
( N'YOSNELLY PINTO', 28, N'21018660', N'Caracas', N'04265556677', 'RutaImagen', N'help@help.com', GETDATE()),
( N'JOSE RODRIGUEZ', 28, N'21018662', N'Caracas', N'04265556677', 'RutaImagen', N'help@help.com', GETDATE()),
( N'DOUGLAS GARCIA', 28, N'21018668', N'Caracas', N'04265556677', 'RutaImagen', N'help@help.com', GETDATE()),
( N'YERALDINE PAEZ', 28, N'21018669', N'Caracas', N'04265556677', 'RutaImagen', N'help@help.com', GETDATE()),
( N'ELIECER JARABA', 28, N'21018672', N'Caracas', N'04265556677', 'RutaImagen', N'help@help.com', GETDATE());