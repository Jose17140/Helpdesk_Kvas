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
('Departamentos','Departamentos de servicio',0,'glyphicon glyphicon-th-large',1,GETDATE()),
('Pais','Paises',0,'fa fa-globe',1,GETDATE()),
('Estados','Estados de los paises',7,'fa fa-globe',1,GETDATE()),
('Ciudades','Agrupa Ciudades',8,'fa fa-globe',1,GETDATE()),
('Marcas','fabricantes de los equipos',0,'fa fa-shopping-cart',1,GETDATE()),
('Accesorios','Accesorios que se entregan con el equipo',0,'fa fa-pause',1,GETDATE()),
('Preguntas de Seguridad','Pregunta de seguridad al login',0,'fa fa-question-circle',1,GETDATE()),
('Fallas','Agrupa Fallas de sistema',0,'fa fa-wrench',1,GETDATE()),
('Equipos','Equipos de Servicio',0,'fa fa-laptop',1,GETDATE()),
('Tipos de Pagos','tipos de Pago',0,'fa fa-cc-visa',1,GETDATE()),
('Productos','Productos que se venden',0,'fa fa-pause',1,GETDATE()),
('Servicios','Servicio que se prestan',0,'fa fa-pause',1,GETDATE()),
('Tipos de Estatus','Estatus',0,'glyphicon glyphicon-ok',1,GETDATE()),
('Prioridades','Prioridad del requerimiento',0,'glyphicon glyphicon-time',1,GETDATE()),
('Cargos','Cargo de los empleados',0,'glyphicon glyphicon-briefcase',1,GETDATE()),
('Impuestos','Alicuota de Impuestas',0,'fa fa-edit',1,GETDATE()),
('Unidades','Tipos de unidades de Venta',0,'fa fa-edit',1,GETDATE()),
('Cat. Productos','Categorias de los Productos',0,'fa fa-edit',1,GETDATE()),
('Cat. Servicio','Categoria de los Servicios',0,'fa fa-edit',1,GETDATE()),
('Estado del Producto','Condicion del producto, (Nuevo o Usado)',0,'glyphicon glyphicon-erase',1,GETDATE()),
('Depositos','Ubicacion de equipo',0,'glyphicon glyphicon-th-list',1,GETDATE()),
('Modelo','Modelo del equipo',14,'glyphicon glyphicon-hdd',1,GETDATE()),
('Sub Departamento','Descripcion de los departamentos',6,'glyphicon glyphicon-lock',1,GETDATE()),
('Estatus de Requerimiento','Descripcion de los estatus de un requerimiento',18,'glyphicon glyphicon-lock',1,GETDATE()),
('Estatus de Aprobacion','Descripcion aprobado o rechazado',18,'glyphicon glyphicon-lock',1,GETDATE()),
('Estatus de Estado','Activo o inactivo',18,'glyphicon glyphicon-lock',1,GETDATE());
UPDATE Grupos SET IdPadre = 28 WHERE IdGrupo = 20;
UPDATE Grupos SET IdPadre = 28 WHERE IdGrupo = 14;
--NULOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('---','Agrupa los elementos padre GrupoDetalles',0,'Nulo',0,null,'*',GETDATE());
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
('Usuarios','Menu',2,'fa fa-user',1,18,'/Account/Index',GETDATE()),
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
( N'JUAN ARCOS', 27, N'22012345', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'YADELSY REYES', 27, N'22012346', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'TERESA BRAVO', 27, N'22012347', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'ANA PRINCIPE', 27, N'22012348', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'LUIS TORRES', 27, N'22012349', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'MARIA OSPINA', 27, N'22012350', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'ANYELI MORA', 27, N'21018642', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'ROSNELLY MORA', 27, N'21018643', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'MARIA GUEVARA', 27, N'21018645', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'MARIA GUEVARA', 27, N'21018646', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'YOSNELLY PINTO', 27, N'21018660', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'JOSE RODRIGUEZ', 27, N'21018662', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'DOUGLAS GARCIA', 27, N'21018668', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'YERALDINE PAEZ', 27, N'21018669', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'ELIECER JARABA', 27, N'21018672', N'Caracas', N'04265556677', N'help@help.com', GETDATE()),
( N'JOSE BOLIVAR', 27, N'17243451', N'Catia', N'04265556677', N'help@help.com', GETDATE());
--DEPARTAMENTOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Soporte','Departamento de Soporte',6,'fa fa-archive',1,0,'*',GETDATE()),
('Atencion al Cliente','Departamento Atencion al cliente',6,'glyphicon glyphicon-paperclip',4,0,'*',GETDATE());
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
('Estatus de Requerimiento','Requerimiento Recibido y en espera',18,'fa fa-hourglass-o',1,0,'*',GETDATE()),
('Estatus de Aprobacion','Requerimiento asignado a un tecnico',18,'fa fa-hourglass-o',2,0,'*',GETDATE()),
('Estatus de Estado','Requerimiento atendido y revisado',18,'fa fa-hourglass-o',3,0,'*',GETDATE()),
('Llenado','Requerimiento Recibido y en espera',29,'fa fa-hourglass-o',1,58,'*',GETDATE()),
('Recibido','Requerimiento asignado a un tecnico',29,'fa fa-hourglass-o',2,58,'*',GETDATE()),
('Asignado','Requerimiento atendido y revisado',29,'fa fa-hourglass-o',3,58,'*',GETDATE());
--FABRICANTES
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Intel', 'Intel', 10, 'glyphicon glyphicon-cog', 1, 0, '*', GETDATE()),
('MKI', 'MKI', 10, 'glyphicon glyphicon-cog', 2, 0, '*', GETDATE()),
('Genius', 'Genius', 10, 'glyphicon glyphicon-cog', 3, 0, '*', GETDATE()),
('Entercop', 'Entercop', 10, 'glyphicon glyphicon-cog', 4, 0, '*', GETDATE()),
('Epson', 'Epson', 10, 'glyphicon glyphicon-cog', 5, 0, '*', GETDATE()),
('Hp', 'Hp', 10, 'glyphicon glyphicon-cog', 6, 0, '*', GETDATE()),
('TpLink', 'TpLink', 10, 'glyphicon glyphicon-cog', 7, 0, '*', GETDATE()),
('Color Make', 'Color Make', 10, 'glyphicon glyphicon-cog', 8, 0, '*', GETDATE()),
('Printon', 'Printon', 10, 'glyphicon glyphicon-cog', 9, 0, '*', GETDATE()),
('Inverprint', 'Inverprint', 10, 'glyphicon glyphicon-cog', 10, 0, '*', GETDATE()),
('Generico', 'Generico', 10, 'glyphicon glyphicon-cog', 11, 0, '*', GETDATE()),
('Microsoft', 'Microsoft', 10, 'glyphicon glyphicon-cog', 12, 0, '*', GETDATE()),
('AMD', 'AMD', 10, 'glyphicon glyphicon-cog', 13, 0, '*', GETDATE()),
('Samsung', 'Samsung', 10, 'glyphicon glyphicon-cog', 14, 0, '*', GETDATE()),
('Vit', 'Vit', 10, 'glyphicon glyphicon-cog', 15, 0, '*', GETDATE());
--PAISES Y ESTADOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Venezuela','Venezuela',7,'fa fa-globe',1,0,'*',GETDATE()),
('DC','Disctrito Capital',8,'fa fa-globe',2,79,'*',GETDATE()),
('Miranda','Miranda',8,'fa fa-globe',3,79,'*',GETDATE()),
('Aragua','Aragua',8,'fa fa-globe',4,79,'*',GETDATE()),
('Caracas','Ciudad de Caracas',9,'fa fa-globe',5,80,'*',GETDATE());
--CARGOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Atencion al Cliente','Atencion al Publico',20,'fa fa-users',1,0,'*',GETDATE()),
('Tecnico Impresoras','Tecnico',20,'fa fa-users',2,0,'*',GETDATE()),
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
--USUARIOS
EXEC sp_AgregarUsuario 'Jose','l8lOvl12ejU7d/PAzi1Cl0Hy6MmUc8PBUOL6o9FMnaY=',40,'edmundo romero','user1-128x128.jpg',1,'2018-01-03 19:45:28.087',46
EXEC sp_AgregarUsuario 'Jonas','l8lOvl12ejU7d/PAzi1Cl0Hy6MmUc8PBUOL6o9FMnaY=',40,'edmundo romero','user2-160x160.jpg',1,'2018-01-03 19:45:28.087',47
EXEC sp_AgregarUsuario 'Iveet','l8lOvl12ejU7d/PAzi1Cl0Hy6MmUc8PBUOL6o9FMnaY=',40,'edmundo romero','user3-128x128.jpg',1,'2018-01-03 19:45:28.087',48
EXEC sp_AgregarUsuario 'David','l8lOvl12ejU7d/PAzi1Cl0Hy6MmUc8PBUOL6o9FMnaY=',40,'edmundo romero','user4-128x128.jpg',1,'2018-01-03 19:45:28.087',49
EXEC sp_AgregarUsuario 'Jesus','l8lOvl12ejU7d/PAzi1Cl0Hy6MmUc8PBUOL6o9FMnaY=',40,'edmundo romero','user5-128x128.jpg',1,'2018-01-03 19:45:28.087',50
UPDATE Usuarios SET IdPersona = 16 WHERE IdUsuario = 1
--CAT PRODUCTOS Y SERVICIOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
--CAT PRODUCTOS
('Almacenamiento','Dispositivos de almacenamiento',23,'glyphicon glyphicon-tags',1,0,'*',GETDATE()),
('Redes','Equipos de red y comunicaciones',23,'glyphicon glyphicon-tags',2,0,'*',GETDATE()),
('Partes y Piezas','Piezas de pc, impresoras, otros',23,'glyphicon glyphicon-tags',3,0,'*',GETDATE()),
('Accesorios','Accesorios de mano',23,'glyphicon glyphicon-tags',4,0,'*',GETDATE()),
('Consumibles','Tintas, cartuchos',23,'glyphicon glyphicon-tags',5,0,'*',GETDATE()),
--CAT SERVICIOS
('Redes','Equipos de red y comunicaciones',24,'glyphicon glyphicon-tags',1,0,'*',GETDATE()),
('Computadoras','Computadoras y laptop',24,'glyphicon glyphicon-tags',2,0,'*',GETDATE()),
('Impresoras','Equipos de impresion',24,'glyphicon glyphicon-tags',3,0,'*',GETDATE());
--PRODUCTOS
INSERT INTO ProductoServicios (Sku,IdCategoria,IdGrupo,Nombre,Descripcion,IdFabricante,IdUnidad,Imagen,Stock,StockMin,PrecioCompra,PrecioVenta,Garantia,Estatus,FechaRegistro) VALUES
('123456789',97,16,'Procesador I7','Procesador I7 XXXX LGA123',64,31,'IMAGEN',10,1,200000,500000,10,1,'2018-01-03 19:45:28.087');
--SERVICIO
INSERT INTO ProductoServicios (Sku,IdCategoria,IdGrupo,Nombre,Descripcion,IdFabricante,IdUnidad,Imagen,Stock,StockMin,PrecioCompra,PrecioVenta,Garantia,Estatus,FechaRegistro) VALUES
('976543217',135,17,'Limpieza de Cabezal','Solvente y ultrasonido',67,31,'glyphicon glyphicon-wrench',0,0,200000,500000,15,1,'2018-01-03 19:45:28.087');
--CONDICIONES
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Nuevo','Producto Nuevo',25,'glyphicon glyphicon-tags',1,0,'*',GETDATE()),
('Usado','Producto Usado',25,'glyphicon glyphicon-tags',2,0,'*',GETDATE()),
('Consignacion','Consignado para su ventas',25,'glyphicon glyphicon-tags',3,0,'*',GETDATE());
--EQUIPOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Impresora','Impresoras',14,'glyphicon glyphicon-print',1,0,'*',GETDATE()),
('Computadora','Pc',14,'fa fa-laptop',2,0,'*',GETDATE()),
('Laptop','Laptop',14,'fa fa-laptop',3,0,'*',GETDATE()),
('Router','Router, Wifi',14,'glyphicon glyphicon-signal',4,0,'*',GETDATE()),
('Servidor','Servidor',14,'glyphicon glyphicon-hdd',5,0,'*',GETDATE()),
('Telefono','Smartphone',14,'glyphicon glyphicon-earphone',6,0,'*',GETDATE());
--DEPOSITOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Estante Vitrina','Vitrina de equipos recibidos',26,'glyphicon glyphicon-th-list',1,0,'*',GETDATE()),
('Estante Taller','Estante de equipos area de soporte',26,'glyphicon glyphicon-th-list',2,0,'*',GETDATE()),
('Deposito','Deposito final, equipos no retirados',26,'glyphicon glyphicon-th-list',3,0,'*',GETDATE());
--EQUIPOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Multifuncional','Impresora multifuncional',14,'glyphicon glyphicon-th-list',1,0,'*',GETDATE()),
('Laser','Impresora Laser',14,'glyphicon glyphicon-th-list',2,0,'*',GETDATE()),
('Tablet','Tableta',14,'glyphicon glyphicon-th-list',3,0,'*',GETDATE()),
('Switches','Conmutadores de red',14,'glyphicon glyphicon-th-list',3,0,'*',GETDATE());
--PRIORIDADES
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Normal','Requerimientos en cola',19,'lyphicon glyphicon-flash',1,0,'*',GETDATE()),
('Urgente','Requerimientos con prioridad rapida',19,'lyphicon glyphicon-flash',2,0,'*',GETDATE()),
('Critica','Requerimiento critico y prioritario',19,'lyphicon glyphicon-flash',3,0,'*',GETDATE());
--FABRICANTES 2
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Alcatel', 'Intel', 10, 'glyphicon glyphicon-cog', 16, 0, '*', GETDATE());
--MODELO DE EQUIPOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('L120','Impresora Multifuncional',27,'lyphicon glyphicon-flash',0,106,'*',GETDATE()),
('Tx130','Impresora Multifuncional',27,'lyphicon glyphicon-flash',0,115,'*',GETDATE()),
('T22','Impresora simple',27,'lyphicon glyphicon-flash',0,106,'*',GETDATE()),
('V2400','Laptop',27,'lyphicon glyphicon-flash',0,108,'*',GETDATE()),
('Pavillion 6801us','Laptop',27,'lyphicon glyphicon-flash',0,108,'*',GETDATE()),
('Tl-720w','Router',27,'lyphicon glyphicon-flash',0,109,'*',GETDATE()),
('Cx5600','Impresora Multifuncional',27,'lyphicon glyphicon-flash',0,115,'*',GETDATE()),
('Fierce 2','Telefono Inteligente',27,'lyphicon glyphicon-flash',0,111,'*',GETDATE()),
('Generico','Equipo generico',27,'lyphicon glyphicon-flash',0,107,'*',GETDATE());
--SUB MENU REQUERIMIENTO
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Nuevo Ticket','Sub Menu',2,'glyphicon glyphicon-qrcode',1,2,'/Requerimiento/Create',GETDATE()),
('Consultar','Sub Menu',2,'glyphicon glyphicon-search',2,2,'/Requerimiento/Index',GETDATE());
--SUB DEPARTAMENTOS
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
--DEPARTAMENTOS
('Administracion','Departamento Administrativo',6,'glyphicon glyphicon-paperclip',3,0,'*',GETDATE()),
--SUBDEPARTAMENTOS
('Soporte de Impresoras','SubDepartamento Impresoras',28,'glyphicon glyphicon-print',1,36,'*',GETDATE()),
('Soporte de Informatica','SubDepartamento Informatica',28,'fa fa-laptop',2,36,'*',GETDATE()),
('Soporte de Moviles','SubDepartamento Smartphone y Tablet',28,'glyphicon glyphicon-phone',2,36,'*',GETDATE()),
('Soporte de Redes','SubDepartamento Redes',28,'glyphicon glyphicon-signal',3,36,'*',GETDATE()),
('Atencion al Cliente','SubDepartamento Atencion al Cliente',28,'glyphicon glyphicon-user',3,37,'*',GETDATE()),
('Administrativo','SubDepartamento Administracion',28,'glyphicon glyphicon-briefcase',3,134,'*',GETDATE()),
--CARGOS PENDIENTES
('Tecnico Celulares','Tecnico',20,'fa fa-users',2,136,'*',GETDATE()),
('Tecnico PC','Tecnico',20,'fa fa-users',2,135,'*',GETDATE());
UPDATE GruposDetalles SET IdPadre = 138 WHERE IdGrupoDetalle = 84;
UPDATE GruposDetalles SET IdPadre = 134 WHERE IdGrupoDetalle = 85;
UPDATE GruposDetalles SET IdPadre = 139 WHERE IdGrupoDetalle = 86;
UPDATE ProductoServicios SET IdCondicion = 103;
UPDATE ProductoServicios SET IdCategoria = 134 WHERE IdProducto = 2;
UPDATE GruposDetalles SET IdPadre = 135 WHERE IdGrupoDetalle = 106;
UPDATE GruposDetalles SET IdPadre = 136 WHERE IdGrupoDetalle = 107;
UPDATE GruposDetalles SET IdPadre = 136 WHERE IdGrupoDetalle = 108;
UPDATE GruposDetalles SET IdPadre = 138 WHERE IdGrupoDetalle = 109;
UPDATE GruposDetalles SET IdPadre = 136 WHERE IdGrupoDetalle = 110;
UPDATE GruposDetalles SET IdPadre = 137 WHERE IdGrupoDetalle = 111;
UPDATE GruposDetalles SET IdPadre = 135 WHERE IdGrupoDetalle = 115;
UPDATE GruposDetalles SET IdPadre = 135 WHERE IdGrupoDetalle = 116;
UPDATE GruposDetalles SET IdPadre = 137 WHERE IdGrupoDetalle = 117;
UPDATE GruposDetalles SET IdPadre = 138 WHERE IdGrupoDetalle = 118;
SELECT * FROM GruposDetalles where IdGrupo = 27
--ESTATUS 2.0
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Comprobacion','Requerimiento Resuelto',29,'fa fa-hourglass-o',4,58,'*',GETDATE()),
('Reparado','Requerimiento Devuelto sin solucion',29,'fa fa-hourglass-o',5,58,'*',GETDATE()),
('Devuelto','Requerimiento Cerrado',29,'fa fa-hourglass-o',6,58,'*',GETDATE()),
('Entregado','Requerimiento Recibido y en espera',29,'fa fa-hourglass-o',7,58,'*',GETDATE()),
('Garantia','Requerimiento asignado a un tecnico',29,'fa fa-hourglass-o',8,58,'*',GETDATE()),
--Aprobacion
('Aprobado','Estatus Aprobado',30,'fa fa-hourglass-o',1,59,'*',GETDATE()),
('Rechazado','Estatus Rechazado',30,'fa fa-hourglass-o',2,59,'*',GETDATE()),
--estado
('Activo','activa elementos',31,'fa fa-hourglass-o',1,60,'*',GETDATE()),
('Inactivo','inactiva elementos',31,'fa fa-hourglass-o',2,60,'*',GETDATE());
--REQUERIMIENTO
--SUB MENU REQUERIMIENTO 2
INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Imagen,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
('Presupuesto','Sub Menu',2,'fa-file',3,2,'/Presupuesto/Create',GETDATE());
--REQUERIMIENTO
INSERT INTO Requerimientos(IdDepartamento,IdEmpleado,FechaEntrada,IdCliente,IdEquipo,IdMarca,IdModelo,IdPrioridad,Falla,Serial,Observaciones,Accesorios,IdDeposito,IdEstatus)VALUES
(135,4,'2018-01-03 19:45:28.087',5,106,68,129,118,'Imprime con rayas','XWWWW00001','Equipo en mal estado','Ninguno',116,61);

---- PRODUCTOS
--INSERT INTO GruposDetalles(Nombre,Descripcion,IdGrupo,Icono,Orden,IdPadre,UrlDetalle,FechaRegistro)VALUES
--('Procesador','I7',9,'fa fa-archive',1,40,'*',GETDATE()),
--('Chip 196RG','Xp201/Xp211',9,'fa fa-archive',2,43,'*',GETDATE()),
--('Memoria Ram','DDR3',9,'fa fa-archive',3,40,'*',GETDATE()),
--('Tarjeta Red','Lan 1000',9,'fa fa-archive',4,39,'*',GETDATE()),
--('Fan Cooler','I7',9,'fa fa-archive',5,40,'*',GETDATE()),
--('Disco Duro','500Gb',9,'fa fa-archive',6,40,'*',GETDATE()),
--('Tinta 100ml','Tinta CM',9,'fa fa-archive',7,42,'*',GETDATE());