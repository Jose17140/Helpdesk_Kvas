-- INSERTANDO DATOS TABLA GRUPOS
USE Helpdesk_Kvas
GO
--GRUPO DE MENU
INSERT INTO Grupos(Nombre,Descripcion,UrlGrupo,Icono, FechaRegistro)VALUES 
('Nulo','Agrupa las Tablas Nulas','/','fa fa-bars',GETDATE()),
('Menu','Agrupa el Menu slidebar de la app','/','fa fa-bars',GETDATE()),
('TipoPersona','Tipo de Identificacion de los Usuarios','/','fa fa-pause',GETDATE()),
('Sexos','Genero de las personas','/','fa fa-venus-mars',GETDATE()),
('Pais','Paises','/','fa fa-pause',GETDATE()),
('Estados','Estamos de los paises','/','fa fa-pause',GETDATE()),
('Categorias','Categorias de productos o servicio','/','fa fa-pause',GETDATE()),
('Equipos','Equipos a recibir','/','fa fa-laptop',GETDATE()),
('Servicios','Servicios que se realizan','/','fa fa-pause',GETDATE()),
('Tipos de Pagos','tipos de Pago','/','fa fa-cc-visa',GETDATE()),
('Estatus','Estatus de los requerimientos','/','fa fa-pause',GETDATE()),
('Fabricantes','fabricantes de los equipos','/','fa fa-shopping-cart',GETDATE()),
('Modelos','Modelo de los equipos','/','fa fa-pause',GETDATE()),
('Fallas','Agrupa Fallas de sistema','/','fa fa-wrench',GETDATE()),
('Accesorios','Accesorios que se entregan con el equipo','/','fa fa-pause',GETDATE()),
('Preguntas de Seguridad','Pregunta de seguridad al login','/','fa fa-question-circle',GETDATE()),
('Prioridades','Prioridad del requerimiento','/','fa fa-pause',GETDATE()),
('Departamentos','Departamentos de servicio','/','fa fa-pause',GETDATE()),
('Cargos','Cargo de los empleados','/','fa fa-pause',GETDATE()),
('Usuarios','Carga Usuarios del Sistema','/','fa fa-user',GETDATE()),
('Impuestos','Alicuota de Impuestas','/','fa fa-edit',GETDATE());
-- INSERTANDO DATOS TABLA DESCRIPCION DE GRUPOS
--MENUS '/',
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Nulos','Agrupa Detalles nulos',0,'Nulo',0,0,'/',GETDATE()),
('Registro','Registro de Clientes, Ticket y Organizaciones',1,'fa fa-plus-circle',1,0,'/',GETDATE()),
('Requerimientos','',1,'fa fa-ticket',2,0,'/',GETDATE()),
('Catalogo','',1,'fa  fa-tags',3,0,'/',GETDATE()),
('Clientes','',1,'fa fa-users',4,0,'/',GETDATE()),
('Informes','',1,'fa fa-bar-chart',5,0,'/',GETDATE()),
('Base de Conocimientos','',1,'fa fa-database',6,0,'/',GETDATE()),
('Documentacion','',1,'fa fa-book',7,0,'/',GETDATE()),
('Sistema','',1,'fa fa-cogs',8,0,'/',GETDATE());
--SUBMENUS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Cliente','',1,'fa fa-user',1,1,'/',GETDATE()),
('Ticket','',1,'fa fa-sticky-note-o',2,1,'/',GETDATE()),
('Organizacion','',1,'fa fa-institution',3,1,'/',GETDATE()),
('Buscar','',1,'fa fa-search',4,1,'/',GETDATE());
--CATALOGO
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Productos','',1,'fa fa-laptop',1,3,'/',GETDATE()),
('Servicios','',1,'fa fa-puzzle-piece',2,3,'/',GETDATE());
--PRODUCTOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Productos','',1,'fa  fa-tablet',1,13,'/',GETDATE()),
('Fabricantes','',1,'fa fa-bank',2,13,'/',GETDATE()),
('Categorias','',1,'fa fa-bookmark-o',3,13,'/',GETDATE()),
('Movimiento de Inventario','',1,'fa fa-pencil-square-o',4,13,'/',GETDATE());
--SISTEMA SUBMENU
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Configuracion','',1,'fa fa-cog',1,8,'/',GETDATE()),
('Usuarios','',1,'fa fa-users',2,8,'/',GETDATE()),
('Herramientas','',1,'fa fa-wrench',3,8,'/',GETDATE());
--SUBMENU SISTEMA
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Tienda','',1,'fa fa-home',1,19,'/',GETDATE()),
('Entidades','',1,'fa fa-bars',3,19,'/Grupo/Index',GETDATE()),
('Respaldos','',1,'fa fa-database',1,21,'/',GETDATE()),
('Log','',1,'fa fa-circle-o',2,21,'/',GETDATE());
--USUARIOS Y ROLES
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Usuarios','',1,'fa fa-user',1,20,'/',GETDATE()),
('Roles','',1,'fa fa-archive',3,20,'/Grupo/Index',GETDATE());
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