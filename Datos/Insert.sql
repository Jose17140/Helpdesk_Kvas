-- INSERTANDO DATOS TABLA GRUPOS
USE Helpdesk_Kvas
GO
--GRUPO DE MENU
INSERT INTO Grupos(Nombre,Descripcion,UrlGrupo,Icono,Estatus,FechaRegistro)VALUES 
('Cat. Superior','Agrupa las Tablas Nulas','/','fa fa-bars',1,GETDATE()),
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
('Unidades','Tipos de unidades de Venta','/','fa fa-edit',1,GETDATE());
--('Hardware','Piezas Fisicas','/','fa fa-edit',1,GETDATE()),
--('Software','Sistemas','/','fa fa-edit',1,GETDATE());
-- INSERTANDO DATOS TABLA DESCRIPCION DE GRUPOS
--MENUS '/',
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Cat. Superior','Agrupa los elementos padre GrupoDetalles',0,'Nulo',0,null,'/',GETDATE()),
('Registro','Registro de Clientes, Ticket y Organizaciones',1,'fa fa-plus-circle',1,0,'/',GETDATE()),
('Requerimientos','Menu',1,'fa fa-ticket',2,0,'/',GETDATE()),
('Catalogo','Menu',1,'fa  fa-tags',3,0,'/',GETDATE()),
('Clientes','Menu',1,'fa fa-users',4,0,'/Persona',GETDATE()),
('Informes','Menu',1,'fa fa-bar-chart',5,0,'/',GETDATE()),
('Base de Conocimientos','Menu',1,'fa fa-database',6,0,'/',GETDATE()),
('Documentacion','Menu',1,'fa fa-book',7,0,'/',GETDATE()),
('Sistema','Menu',1,'fa fa-cogs',8,0,'/',GETDATE());
--SUB MENUS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Cliente','Menu',1,'fa fa-user',1,1,'/Persona',GETDATE()),
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
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('V','Venezolano',2,'fa fa-flag-o',1,0,'*',GETDATE()),
('E','Extranjero',2,'fa fa-flag-o',2,0,'*',GETDATE()),
('J','Juridico',2,'fa fa-flag-o',3,0,'*',GETDATE()),
('G','Gubernamental',2,'fa fa-flag-o',4,0,'*',GETDATE());
--UNIDADES DE MEDIDA
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Unidad','Una Pieza',23,'fa fa-user',1,0,'*',GETDATE()),
('Metro','Un metro',23,'fa fa-archive',2,0,'*',GETDATE()),
('Hora','Hora de Servicio',23,'fa fa-archive',3,0,'*',GETDATE()),
('Litro','Litro de Tinta',23,'fa fa-archive',4,0,'*',GETDATE()),
('Mililitro','Tinta por mililitro',23,'fa fa-archive',5,0,'*',GETDATE());
--INSERTAR PERSONAS
INSERT personas (Nombres, IdTipoPersona, CiRif, Direccion, Telefonos, Email, FechaRegistro) VALUES 
( N'JUAN ARCOS', 28, N'22012345', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'YADELSY REYES', 28, N'22012346', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'TERESA BRAVO', 28, N'22012347', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'ANA PRINCIPE', 28, N'22012348', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'LUIS TORRES', 28, N'22012349', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'MARIA OSPINA', 28, N'22012350', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'ANYELI MORA', 28, N'21018642', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'ROSNELLY MORA', 28, N'21018643', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'MARIA GUEVARA', 28, N'21018645', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'MARIA GUEVARA', 28, N'21018646', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'YOSNELLY PINTO', 28, N'21018660', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'JOSE RODRIGUEZ', 28, N'21018662', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'DOUGLAS GARCIA', 28, N'21018668', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'YERALDINE PAEZ', 28, N'21018669', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'ELIECER JARABA', 28, N'21018672', N'Caracas', N'04265556677', N'help@help.com', GETDATE());

SELECT * FROM Grupos WHERE  IdGrupo = 18; --DEPARTAMENTO 1 NIVEL 
SELECT * FROM Grupos WHERE  IdGrupo = 24; --HARDWARE O SOFTWARE 2 NIVEL
SELECT * FROM Grupos WHERE  IdGrupo = 12; --FABRICANTE 3 NIVEL
SELECT * FROM Grupos WHERE  IdGrupo =  9; --PRODUCTO 4 NIVEL
SELECT * FROM GruposDetalles WHERE IdGrupo = 18
--37 Soporte 38 Inventario
--DEPARTAMENTOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Soporte','Departamento de Soporte Tecnico',18,'fa fa-archive',1,0,'/',GETDATE()),
('Inventario','Departamento Inventario',18,'fa fa-archive',2,0,'/',GETDATE());
--SUB DEPARTAMENTOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Redes','Departamentos',18,'fa fa-archive',1,38,'/',GETDATE()),
('Partes y Piezas','Departamentos',18,'fa fa-archive',2,38,'/',GETDATE()),
('Accesorios','Departamentos',18,'fa fa-archive',4,38,'/',GETDATE()),
('Consumibles','Departamentos',18,'fa fa-archive',5,38,'/',GETDATE()),
('Impresoras','Departamentos',18,'fa fa-archive',6,38,'/',GETDATE());
-- PRODUCTOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Procesador','I7',9,'fa fa-user',1,40,'*',GETDATE()),
('Reset Impresoras','Xp201',9,'fa fa-archive',2,43,'*',GETDATE()),
('Memoria Ram','DDR3',9,'fa fa-archive',3,40,'*',GETDATE()),
('Tarjeta Red','Lan 1000',9,'fa fa-archive',4,39,'*',GETDATE()),
('Fan Cooler','I7',9,'fa fa-archive',5,40,'*',GETDATE()),
('Disco Duro','500Gb',9,'fa fa-archive',6,40,'*',GETDATE()),
('Tinta 100ml','Tinta CM',9,'fa fa-archive',7,42,'*',GETDATE());



--SERVICIOS
--INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
--('Instalacion','Instalacion de Sistema',8,'fa fa-user',1,32,'*',GETDATE()),
--('Respaldo','Respaldo de Datos',8,'fa fa-archive',2,32,'*',GETDATE()),
--('Recuperacion','Recuperacion de informacion',8,'fa fa-archive',3,32,'*',GETDATE()),
--('Limpieza','Limpieza de Inyectores',8,'fa fa-archive',4,32,'*',GETDATE()),
--('Mantenimiento','Preventivo',8,'fa fa-archive',5,32,'*',GETDATE());

--PRODUCTOS
--INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
--('Memoria','Repuestos de Computadoras',9,'fa fa-user',1,0,'/',GETDATE()),
--('Procesador','Menu',1,'fa fa-archive',3,13,'/',GETDATE());

--GRUPOS
-- 8 SERVICIO
-- 9 PRODUCTO
-- 18 DEPARTAMENTO

--GRUPOSDETALLES
-- 32 SERVICIOS
-- 33 VENTAS

--EQUIPOS

--FABRICANTES
--INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
--('MKI', ' ', 12, 'fa fa-laptop', 1, 0, 'MKI', GETDATE()),
--('Genius', '', 12, 'fa fa-laptop', 2, 0, 'Genius', GETDATE()),
--('Samsung', '', 12, 'fa fa-laptop', 3, 0, 'Samsung', GETDATE()),
--('AMD', '', 12, 'fa fa-laptop', 4, 0, 'http://www.amd.com/es-xl', GETDATE()),
--('AOC', '', 12, 'fa fa-laptop', 5, 0, 'latin.aoc.com/', GETDATE()),
--('Asrock', '', 12, 'fa fa-laptop', 6, 0, 'www.asrock.com/index.es.asp', GETDATE()),
--('Ati Radeon', '', 12, 'fa fa-laptop', 7, 0, 'http://support.amd.com/en-us/download', GETDATE()),
--('Benq', '', 12, 'fa fa-laptop', 8, 0, 'latam.benq.com/', GETDATE()),
--('Corsair', '', 12, 'fa fa-laptop', 9, 0, 'corsair', GETDATE()),
--('Dell', '', 12, 'fa fa-laptop', 10, 0, 'dell', GETDATE()),
--('Epson', '', 12, 'fa fa-laptop', 11, 0, 'epson', GETDATE()),
--('Fujifilm', '', 12, 'fa fa-laptop', 12, 0, 'fujifilm', GETDATE()),
--('Hp', '', 12, 'fa fa-laptop', 13, 0, 'hp', GETDATE()),
--('Microsoft', '', 12, 'fa fa-laptop', 14, 0, 'microsoft', GETDATE()),
--('MSI', '', 12, 'fa fa-laptop', 15, 0, 'msi', GETDATE()),
--('Nvidia', '', 12, 'fa fa-laptop', 16, 0, 'nvidia', GETDATE()),
--('PNY', '', 12, 'fa fa-laptop', 17, 0, 'pny', GETDATE()),
--('TpLink', '', 12, 'fa fa-laptop', 18, 0, 'tplink', GETDATE()),
--('Entercop', '', 12, 'fa fa-laptop', 19, 0, 'entercop', GETDATE()),
--('Lenovo', '', 12, 'fa fa-laptop', 20, 0, 'lenovo', GETDATE()),
--('D-Link', '', 12, 'fa fa-laptop', 21, 0, 'd-link', GETDATE()),
--('SanDisk', '', 12, 'fa fa-laptop', 22, 0, 'sandisk', GETDATE()),
--('Sapphire', '', 12, 'fa fa-laptop', 23, 0, 'sapphire', GETDATE()),
--('LG', '', 12, 'fa fa-laptop', 24, 0, 'lg', GETDATE()),
--('Lanpro', '', 12, 'fa fa-laptop', 25, 0, 'lanpro', GETDATE()),
--('Advantek', '', 12, 'fa fa-laptop', 26, 0, 'http://ww38.advanteknetworks.com/', GETDATE()),
--('Ecs', '', 12, 'fa fa-laptop', 27, 0, 'ecs', GETDATE()),
--('Biostar', '', 12, 'fa fa-laptop', 28, 0, 'www.biostar.com.tw/', GETDATE()),
--('Apex', '', 12, 'fa fa-laptop', 29, 0, 'http://www.apextechusa.com/', GETDATE()),
--('MYO', '', 12, 'fa fa-laptop', 30, 0, 'myo', GETDATE()),
--('Generico', '', 12, 'fa fa-laptop', 31, 0, 'generico', GETDATE()),
--('Argon', '', 12, 'fa fa-laptop', 32, 0, 'https://www.argomtech.com/', GETDATE()),
--('COBY', '', 12, 'fa fa-laptop', 33, 0, 'coby', GETDATE()),
--('Hitachi', '', 12, 'fa fa-laptop', 34, 0, 'hitachi', GETDATE()),
--('Seagate', '', 12, 'fa fa-laptop', 35, 0, 'seagate', GETDATE()),
--('Kingston', '', 12, 'fa fa-laptop', 36, 0, 'kingston', GETDATE()),
--('Ativen', '', 12, 'fa fa-laptop', 37, 0, 'www.ativen.com/', GETDATE()),
--('Printon', '', 12, 'fa fa-laptop', 38, 0, 'printon', GETDATE()),
--('Markvision', '', 12, 'fa fa-laptop', 39, 0, 'markvision', GETDATE()),
--('Toshiba', '', 12, 'fa fa-laptop', 40, 0, 'toshiba', GETDATE()),
--('Intel', '', 12, 'fa fa-laptop', 41, 0, 'intel', GETDATE()),
--('QuickHeal', '', 12, 'fa fa-laptop', 42, 0, 'quickheal', GETDATE()),
--('ColorMarke', '', 12, 'fa fa-laptop', 43, 0, 'colormarke', GETDATE()),
--('Wash', '', 12, 'fa fa-laptop', 44, 0, 'wash', GETDATE()),
--('Havit', '', 12, 'fa fa-laptop', 45, 0, 'havit', GETDATE()),
--('Interprint', '', 12, 'fa fa-laptop', 46, 0, 'interprint', GETDATE()),
--('Alcatel', '', 12, 'fa fa-laptop', 47, 0, 'http://www.alcatel-mobile.com/global-en/', GETDATE()),
--('KODE', '', 12, 'fa fa-laptop', 48, 0, 'kode', GETDATE()),
--('AVANT', '', 12, 'fa fa-laptop', 49, 0, 'www.avanttechnology.com/', GETDATE()),
--('DOIT', '', 12, 'fa fa-laptop', 50, 0, 'doit', GETDATE()),
--('Yoobao', '', 12, 'fa fa-laptop', 51, 0, 'yoobao', GETDATE());

