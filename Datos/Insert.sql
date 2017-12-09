-- INSERTANDO DATOS TABLA GRUPOS
USE Helpdesk_Kvas
GO
--GRUPO DE MENU
INSERT INTO Grupos(Nombre,Descripcion,UrlGrupo,Icono,Estatus,FechaRegistro)VALUES 
('Cat. Superior','Agrupa las Tablas Nulas','/','fa fa-bars',1,GETDATE()),
('Menu','Agrupa el Menu slidebar de la app','/','fa fa-bars',1,GETDATE()),
('TipoPersona','Tipo de Identificacion de los Usuarios','/','fa fa-pause',1,GETDATE()),
('Sexos','Genero de las personas','/','fa fa-venus-mars',1,GETDATE()),
('Pais','Paises','/','fa fa-globe',1,GETDATE()),
('Estados','Estamos de los paises','/','fa fa-globe',1,GETDATE()),
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
('Unidades','Tipos de unidades de Venta','/','fa fa-edit',1,GETDATE()),
('Municipios','Agrupa Municipios','/','fa fa-globe',1,GETDATE()),
('Ciudades','Agrupa Ciudades','/','fa fa-globe',1,GETDATE());
--MENUS
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
('Servicios','Menu',1,'fa fa-puzzle-piece',2,3,'/Servicio',GETDATE());
--PRODUCTOS MENU
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Productos','Menu',1,'fa  fa-tablet',1,13,'/Producto/Index',GETDATE()),
('Fabricantes','Menu',0,'fa fa-bank',2,0,'/',GETDATE()),
('Departamentos','Menu',0,'fa fa-bookmark-o',3,0,'/',GETDATE()),
('Movimiento de Inventario','Menu',1,'fa fa-pencil-square-o',4,13,'/Producto/movimientoinventario',GETDATE());
--SISTEMA MENU
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Configuracion','Menu',1,'fa fa-cog',1,8,'/',GETDATE()),
('Usuarios','Menu',1,'fa fa-users',2,8,'/Usuario/Index',GETDATE()),
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
--SEXOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Femenino','Mujeres',3,'fa fa-venus',1,0,'*',GETDATE()),
('Masculino','Hombres',3,'fa fa-mars-stroke',2,0,'*',GETDATE());
--PREGUNTAS DE SEGURIDAD
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('¿Cómo se llama tu escuela primaria?','Pregunta de Seguridad',16,'fa fa-question',1,0,'*',GETDATE()),
('¿Ano de Nacimiento de mi madre?','Pregunta de Seguridad',16,'fa fa-question',2,0,'*',GETDATE()),
('¿Nombre de mi padre?','Pregunta de Seguridad',16,'fa fa-question',3,0,'*',GETDATE()),
('¿Cuál es la profesión de mi abuelo?','Pregunta de Seguridad',16,'fa fa-question',4,0,'*',GETDATE()),
('¿Cuál es el nombre de mi mascota?','Pregunta de Seguridad',16,'fa fa-question',5,0,'*',GETDATE()),
('¿Cuál mi película favorita?','Pregunta de Seguridad',16,'fa fa-question',6,0,'*',GETDATE());
--Roles DE SEGURIDAD
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Master','Control Total',21,'fa fa-user',1,0,'*',GETDATE()),
('Supervisor','No Puede modificar grupos',21,'fa fa-user',2,0,'*',GETDATE()),
('Analista','Recepcion de Equipos',21,'fa fa-user',3,0,'*',GETDATE()),
('Tecnico','Atencion de Requerimiento y Recepcion',21,'fa fa-user',4,0,'*',GETDATE()),
('Cliente','Estatus de Servicio',21,'fa fa-user',5,0,'*',GETDATE());
--IMPUESTOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('12%','Iva 12% Pagos Efectivo',20,'fa fa-money',1,0,'*',GETDATE()),
('9%','Iva 9% Pagos electronicos menores a 2M',20,'fa fa-money',2,0,'*',GETDATE()),
('7%','Iva 7% Pagos electronicos mayores a 2M',20,'fa fa-money',3,0,'*',GETDATE());
--TIPOS DE PAGO
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Efectivo','Pagos en efectivo',10,'fa fa-money',1,0,'*',GETDATE()),
('Debito','Tarjeta de debito',10,'fa fa-credit-card',2,0,'*',GETDATE()),
('Transferencia','Transferencia bancaria',10,'fa fa-bank',3,0,'*',GETDATE()),
('Credito','Tarejta de Credito',10,'fa fa-cc-visa',4,0,'*',GETDATE());
--TIPOS DE ESTATUS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Recibido','Requerimiento Recibido y en espera',11,'fa fa-hourglass-o',1,0,'*',GETDATE()),
('Asignado','Requerimiento asignado a un tecnico',11,'fa fa-hourglass-o',2,0,'*',GETDATE()),
('Revisado','Requerimiento atendido y revisado',11,'fa fa-hourglass-o',3,0,'*',GETDATE()),
('Reparado','Requerimiento Resuelto',11,'fa fa-hourglass-o',4,0,'*',GETDATE()),
('Devuelto','Requerimiento Devuelto sin solucion',11,'fa fa-hourglass-o',5,0,'*',GETDATE()),
('Entregado','Requerimiento Cerrado',11,'fa fa-hourglass-o',6,0,'*',GETDATE());
--PAISES Y ESTADOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Venezuela','Venezuela',4,'fa fa-globe',1,0,'*',GETDATE()),
('DC','Disctrito Capital',5,'fa fa-globe',2,77,'*',GETDATE()),
('Miranda','Miranda',5,'fa fa-globe',3,77,'*',GETDATE()),
('Aragua','Aragua',5,'fa fa-globe',4,77,'*',GETDATE()),
('Caracas','Ciudad de Caracas',25,'fa fa-globe',5,78,'*',GETDATE()),
('Libertador','Municipio',24,'fa fa-globe',5,81,'*',GETDATE());
--CARGOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Atencion al Publico','Venezuela',19,'fa fa-users',1,0,'*',GETDATE()),
('Tecnico','Disctrito Capital',19,'fa fa-users',2,0,'*',GETDATE()),
('Administrativo','Miranda',19,'fa fa-users',3,0,'*',GETDATE());
--ACCESORIOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Raton','Raton',15,'fa fa-users',1,0,'*',GETDATE()),
('Teclado','Teclado',15,'fa fa-users',2,0,'*',GETDATE()),
('Sistema de Tinta','Sistema de Tinta',19,'fa fa-users',3,0,'*',GETDATE()),
('Cargador','Cargador',15,'fa fa-users',4,0,'*',GETDATE()),
('Cargador y Cable','Cargador mas Cable de poder',15,'fa fa-users',5,0,'*',GETDATE()),
('Tinta','Envase de tinta',15,'fa fa-users',6,0,'*',GETDATE()),
('CD/DVD','Driver y documentacion',15,'fa fa-users',7,0,'*',GETDATE()),
('Cartuchos','Cartuchos de tinta',15,'fa fa-users',8,0,'*',GETDATE());












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
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Intel', '', 12, 'fa fa-laptop', 41, 0, 'intel', GETDATE()),
('MKI', ' ', 12, 'fa fa-laptop', 1, 0, 'MKI', GETDATE()),
('Genius', '', 12, 'fa fa-laptop', 2, 0, 'Genius', GETDATE());