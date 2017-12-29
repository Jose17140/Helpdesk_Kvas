-- INSERTANDO DATOS TABLA GRUPOS
USE Helpdesk_Kvas
GO
--GRUPO DE MENU
INSERT INTO Grupos(Nombre,Descripcion,IdPadre,Icono,Estatus,FechaRegistro)VALUES
('Cat. Superior','Agrupa las Tablas Nulas',NULL,'fa fa-bars',1,GETDATE()),
('Menu','Agrupa el Menu slidebar de la app',0,'fa fa-bars',1,GETDATE()),
('SubMenu','Agrupa los Sub Menus de primer nivel',1,'fa fa-bars',1,GETDATE()),
('TipoPersona','Tipo de Identificacion de los Usuarios',0,'fa fa-pause',1,GETDATE()),
('Roles','Roles de Usuario',0,'fa fa-edit',1,GETDATE()),
('Sexos','Genero de las personas',0,'fa fa-venus-mars',1,GETDATE()),
('Departamentos','Departamentos de servicio',0,'fa fa-pause',1,GETDATE()),
('Pais','Paises',0,'fa fa-globe',1,GETDATE()),
('Estados','Estados de los paises',7,'fa fa-globe',1,GETDATE()),
('Ciudades','Agrupa Ciudades',8,'fa fa-globe',1,GETDATE()),
('Marcas','fabricantes de los equipos',0,'fa fa-shopping-cart',1,GETDATE()),
('Accesorios','Accesorios que se entregan con el equipo',0,'fa fa-pause',1,GETDATE()),
('Preguntas de Seguridad','Pregunta de seguridad al login',0,'fa fa-question-circle',1,GETDATE()),
('Fallas','Agrupa Fallas de sistema',0,'fa fa-wrench',1,GETDATE()),
('Equipos','Equipos de Servicio',0,'fa fa-edit',1,GETDATE()),
('Tipos de Pagos','tipos de Pago',0,'fa fa-cc-visa',1,GETDATE()),
('Productos','Productos que se venden',0,'fa fa-pause',1,GETDATE()),
('Servicios','Servicio que se prestan',0,'fa fa-pause',1,GETDATE()),
('Estatus','Estatus de los requerimientos',0,'fa fa-pause',1,GETDATE()),
('Prioridades','Prioridad del requerimiento',0,'fa fa-pause',1,GETDATE()),
('Cargos','Cargo de los empleados',0,'fa fa-pause',1,GETDATE()),
('Impuestos','Alicuota de Impuestas',0,'fa fa-edit',1,GETDATE()),
('Unidades','Tipos de unidades de Venta',0,'fa fa-edit',1,GETDATE());
--NULOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Cat. Superior','Agrupa los elementos padre GrupoDetalles',0,'Nulo',0,null,'*',GETDATE());
--MENUS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Registro','Registro de Clientes, Ticket y Organizaciones',1,'fa fa-plus-circle',1,0,'/',GETDATE()),
('Requerimientos','Menu',1,'fa fa-ticket',2,0,'/',GETDATE()),
('Catalogo','Menu',1,'fa  fa-tags',3,0,'/',GETDATE()),
('Clientes','Menu',1,'fa fa-users',4,0,'/Persona',GETDATE()),
('Informes','Menu',1,'fa fa-bar-chart',5,0,'/',GETDATE()),
('Base de Conocimientos','Menu',1,'fa fa-database',6,0,'/',GETDATE()),
('Documentacion','Menu',1,'fa fa-book',7,0,'/',GETDATE()),
('Sistema','Menu',1,'fa fa-cogs',8,0,'/',GETDATE());
--SUB MENUS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Cliente','Menu',2,'fa fa-user',1,1,'/Persona',GETDATE()),
('Ticket','Menu',2,'fa fa-sticky-note-o',2,1,'/',GETDATE()),
('Organizacion','Menu',2,'fa fa-institution',3,1,'/',GETDATE()),
('Buscar','Menu',2,'fa fa-search',4,1,'/',GETDATE());
--CATALOGO MENU
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Productos','Menu',2,'fa fa-laptop',1,3,'/',GETDATE()),
('Servicios','Menu',2,'fa fa-puzzle-piece',2,3,'/Servicio',GETDATE());
--PRODUCTOS MENU
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Productos','Menu',2,'fa  fa-tablet',1,13,'/Producto/Index',GETDATE()),
('Movimiento de Inventario','Menu',2,'fa fa-pencil-square-o',4,13,'/Producto/movimientoinventario',GETDATE());
--SISTEMA MENU
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Configuracion','Menu',2,'fa fa-cog',1,8,'/',GETDATE()),
('Usuarios','Menu',2,'fa fa-users',2,8,'/',GETDATE()),
('Herramientas','Menu',2,'fa fa-wrench',3,8,'/',GETDATE());
--SUB MENU SISTEMA
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Tienda','Menu',2,'fa fa-home',1,17,'/',GETDATE()),
('Entidades','Menu',2,'fa fa-bars',3,17,'/Grupo/Index',GETDATE()),
('Menu','Menu',2,'fa fa-bars',3,17,'/Menu/Index',GETDATE()),
('Respaldos','Menu',2,'fa fa-database',1,19,'/',GETDATE()),
('Log','Menu',2,'fa fa-circle-o',2,19,'/',GETDATE());
--USUARIOS Y ROLES MENU
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Usuarios','Menu',2,'fa fa-user',1,18,'/Usuario/Index',GETDATE()),
('Roles','Menu',2,'fa fa-archive',3,18,'/Roles/Index',GETDATE());
--TIPOS DE PERSONAS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('V','Venezolano',3,'fa fa-flag-o',1,0,'*',GETDATE()),
('E','Extranjero',3,'fa fa-flag-o',2,0,'*',GETDATE()),
('J','Juridico',3,'fa fa-flag-o',3,0,'*',GETDATE()),
('G','Gubernamental',3,'fa fa-flag-o',4,0,'*',GETDATE());
--UNIDADES DE MEDIDA
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Unidad','Una Pieza',22,'fa fa-archive',1,0,'*',GETDATE()),
('Metro','Un metro',22,'fa fa-archive',2,0,'*',GETDATE()),
('Hora','Hora de Servicio',22,'fa fa-archive',3,0,'*',GETDATE()),
('Litro','Litro de Tinta',22,'fa fa-archive',4,0,'*',GETDATE()),
('Mililitro','Tinta por mililitro',22,'fa fa-archive',5,0,'*',GETDATE());
--INSERTAR PERSONAS
INSERT Personas (Nombres, IdTipoPersona, CiRif, Direccion, Telefonos, Email, FechaRegistro) VALUES 
( N'JUAN ARCOS', 26, N'22012345', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'YADELSY REYES', 26, N'22012346', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'TERESA BRAVO', 26, N'22012347', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'ANA PRINCIPE', 26, N'22012348', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'LUIS TORRES', 26, N'22012349', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'MARIA OSPINA', 26, N'22012350', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'ANYELI MORA', 26, N'21018642', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'ROSNELLY MORA', 26, N'21018643', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'MARIA GUEVARA', 26, N'21018645', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'MARIA GUEVARA', 26, N'21018646', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'YOSNELLY PINTO', 26, N'21018660', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'JOSE RODRIGUEZ', 26, N'21018662', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'DOUGLAS GARCIA', 26, N'21018668', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'YERALDINE PAEZ', 26, N'21018669', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'ELIECER JARABA', 26, N'21018672', N'Caracas', N'04265556677', N'help@help.com', GETDATE());
--DEPARTAMENTOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Soporte','Departamento',6,'fa fa-archive',1,0,'*',GETDATE()),
('Ventas','Departamento',6,'fa fa-archive',2,0,'*',GETDATE());
--SEXOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Femenino','Mujeres',5,'fa fa-venus',1,0,'*',GETDATE()),
('Masculino','Hombres',5,'fa fa-mars-stroke',2,0,'*',GETDATE());
--PREGUNTAS DE SEGURIDAD
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('¿Cómo se llama tu escuela primaria?','Pregunta de Seguridad',12,'fa fa-question',1,0,'*',GETDATE()),
('¿Ano de Nacimiento de mi madre?','Pregunta de Seguridad',12,'fa fa-question',2,0,'*',GETDATE()),
('¿Nombre de mi padre?','Pregunta de Seguridad',12,'fa fa-question',3,0,'*',GETDATE()),
('¿Cuál es la profesión de mi abuelo?','Pregunta de Seguridad',12,'fa fa-question',4,0,'*',GETDATE()),
('¿Cuál es el nombre de mi mascota?','Pregunta de Seguridad',12,'fa fa-question',5,0,'*',GETDATE()),
('¿Cuál mi película favorita?','Pregunta de Seguridad',12,'fa fa-question',6,0,'*',GETDATE());
--Roles DE SEGURIDAD
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Master','Control Total',4,'fa fa-user',1,0,'*',GETDATE()),
('Supervisor','No Puede modificar grupos',4,'fa fa-user',2,0,'*',GETDATE()),
('Analista','Recepcion de Equipos',4,'fa fa-user',3,0,'*',GETDATE()),
('Tecnico','Atencion de Requerimiento y Recepcion',4,'fa fa-user',4,0,'*',GETDATE()),
('Cliente','Estatus de Servicio',4,'fa fa-user',5,0,'*',GETDATE());
--IMPUESTOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('12%','Iva 12% Pagos Efectivo',21,'fa fa-money',1,0,'*',GETDATE()),
('9%','Iva 9% Pagos electronicos menores a 2M',21,'fa fa-money',2,0,'*',GETDATE()),
('7%','Iva 7% Pagos electronicos mayores a 2M',21,'fa fa-money',3,0,'*',GETDATE());
--TIPOS DE PAGO
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Efectivo','Pagos en efectivo',15,'fa fa-money',1,0,'*',GETDATE()),
('Debito','Tarjeta de debito',15,'fa fa-credit-card',2,0,'*',GETDATE()),
('Transferencia','Transferencia bancaria',15,'fa fa-bank',3,0,'*',GETDATE()),
('Credito','Tarjeta de Credito',15,'fa fa-cc-visa',4,0,'*',GETDATE());
--TIPOS DE ESTATUS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Recibido','Requerimiento Recibido y en espera',18,'fa fa-hourglass-o',1,0,'*',GETDATE()),
('Asignado','Requerimiento asignado a un tecnico',18,'fa fa-hourglass-o',2,0,'*',GETDATE()),
('Revisado','Requerimiento atendido y revisado',18,'fa fa-hourglass-o',3,0,'*',GETDATE()),
('Reparado','Requerimiento Resuelto',18,'fa fa-hourglass-o',4,0,'*',GETDATE()),
('Devuelto','Requerimiento Devuelto sin solucion',18,'fa fa-hourglass-o',5,0,'*',GETDATE()),
('Entregado','Requerimiento Cerrado',18,'fa fa-hourglass-o',6,0,'*',GETDATE());
--FABRICANTES
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Intel', 'Intel', 10, 'fa fa-laptop', 1, 0, '*', GETDATE()),
('MKI', 'MKI', 10, 'fa fa-laptop', 2, 0, '*', GETDATE()),
('Genius', 'Genius', 10, 'fa fa-laptop', 3, 0, '*', GETDATE()),
('Entercop', 'Entercop', 10, 'fa fa-laptop', 4, 0, '*', GETDATE());
--PAISES Y ESTADOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Venezuela','Venezuela',7,'fa fa-globe',1,0,'*',GETDATE()),
('DC','Disctrito Capital',8,'fa fa-globe',2,68,'*',GETDATE()),
('Miranda','Miranda',8,'fa fa-globe',3,68,'*',GETDATE()),
('Aragua','Aragua',8,'fa fa-globe',4,68,'*',GETDATE()),
('Caracas','Ciudad de Caracas',9,'fa fa-globe',5,69,'*',GETDATE());
--CARGOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Atencion al Publico','Atencion al Publico',20,'fa fa-users',1,0,'*',GETDATE()),
('Tecnico','Tecnico',20,'fa fa-users',2,0,'*',GETDATE()),
('Administrativo','Administrativo',20,'fa fa-users',3,0,'*',GETDATE());
--ACCESORIOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Raton','Raton',11,'fa fa-users',1,0,'*',GETDATE()),
('Teclado','Teclado',11,'fa fa-users',2,0,'*',GETDATE()),
('Sistema de Tinta','Sistema de Tinta',11,'fa fa-users',3,0,'*',GETDATE()),
('Cargador','Cargador',11,'fa fa-users',4,0,'*',GETDATE()),
('Cargador y Cable','Cargador mas Cable de poder',11,'fa fa-users',5,0,'*',GETDATE()),
('Tinta','Envase de tinta',11,'fa fa-users',6,0,'*',GETDATE()),
('CD/DVD','Driver y documentacion',11,'fa fa-users',7,0,'*',GETDATE()),
('Cartuchos','Cartuchos de tinta',11,'fa fa-users',8,0,'*',GETDATE());



select * from gruposdetalles;





---- PRODUCTOS
--INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
--('Procesador','I7',9,'fa fa-archive',1,40,'*',GETDATE()),
--('Chip 196RG','Xp201/Xp211',9,'fa fa-archive',2,43,'*',GETDATE()),
--('Memoria Ram','DDR3',9,'fa fa-archive',3,40,'*',GETDATE()),
--('Tarjeta Red','Lan 1000',9,'fa fa-archive',4,39,'*',GETDATE()),
--('Fan Cooler','I7',9,'fa fa-archive',5,40,'*',GETDATE()),
--('Disco Duro','500Gb',9,'fa fa-archive',6,40,'*',GETDATE()),
--('Tinta 100ml','Tinta CM',9,'fa fa-archive',7,42,'*',GETDATE());
