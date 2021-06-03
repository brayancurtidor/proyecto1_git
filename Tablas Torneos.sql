--use EEEG
--drop database  Proyecto_AdministracionTorneosFutbol 
Create database Proyecto_AdministracionTorneosFutbol
go
USE Proyecto_AdministracionTorneosFutbol
go

--TABLA AMONESTACION
CREATE TABLE AMONESTACION
(
	ColorTarjeta varchar(200) NOT NULL, 
	Valor_multa varchar(200) NOT NULL,
	Comentario varchar(200) NOT NULL
	PRIMARY KEY(ColorTarjeta)
);
go
--TABLA ARBITRO
CREATE TABLE ARBITRO
(
	DPI int NOT NULL  ,
	Nombre varchar(200) NOT NULL,
	Apellidos varchar(200) NOT NULL,
	Direccion varchar(200) NOT NULL,
	Telefono varchar(200) NOT NULL,
	Nacionalidad varchar(200) NOT NULL,
	FechaNac date NOT NULL,
	Correo varchar(200) NOT NULL,
	Rol	varchar(200) NOT NULL,
	pago_alquiler decimal(8,2),
	PRIMARY KEY(DPI)
);
go
insert into ARBITRO(DPI,Nombre,Apellidos,Direccion,Telefono,Nacionalidad,FechaNac,Correo,Rol,pago_alquiler)values(0,'no','no','0','0','0','2000/01/01','0','0',0);

go

--TABLA JUGADOR

CREATE TABLE JUGADOR
(

	Identificacion	int NOT NULL  default 0,
	Nombres	varchar(200) NOT NULL,
	Apellidos varchar(200) NOT NULL,
	Fecha_nac date NOT NULL,
	Direccion varchar(250) NOT NULL,
	Nacionalidad varchar(200) NOT NULL,
	Correo varchar(200) NOT NULL,
	Telefono varchar(200) NOT NULL,
	Menor_edad bit default 0,
	PRIMARY KEY(Identificacion)
);

go
--TABLA EQUIPO
CREATE TABLE EQUIPO
(
	Id_Equipo int NOT NULL IDENTITY(1,1),
	Nombre varchar(100) NOT NULL,
	CantidadJugadores int NOT NULL,
	Representante varchar(100) NOT NULL,
	PRIMARY KEY(Id_Equipo)
);
go
-- TABLA entrenador
CREATE TABLE ENTRENADOR
(
	DPI bigint NOT NULL,
	Id_Equipo int NOT NULL,
	Nombre varchar(200) NOT NULL,
	Apellidos varchar(200) NOT NULL,
	Telefono varchar(200) NOT NULL,
	FechaNac date NOT NULL,
	Correo varchar(200) NOT NULL,
	Tiempo varchar(200) NOT NULL,
	Salario VARCHAR(200) NOT NULL,
	PRIMARY KEY(DPI)
);
go
ALTER TABLE ENTRENADOR
	ADD CONSTRAINT fk_entrenador_equipo FOREIGN KEY (Id_Equipo)
	REFERENCES EQUIPO (Id_Equipo);

	go
	-- TABLA torneo
CREATE TABLE TORNEO
(
	Id_Torneo int NOT NULL IDENTITY(1,1),
	Nombre	varchar(200) NOT NULL,
	FechaInicio date NOT NULL,
	FechaFinal	date NOT NULL,
	Tipo varchar(200) NOT NULL,
	edadminima int NOT NULL,
	edadmaxima int NOT NULL,
	p_ganado int NOT NULL,
	pperdido int NOT NULL,
	pempatado int NOT NULL,
	precio_Torneo Float not null,
	 
	NumeroMaximoDeJugadores int NOT NULL,
	PRIMARY KEY(Id_Torneo)
);

go
--TABLA CANCHA
CREATE TABLE CANCHA
(

	NoCancha int NOT NULL IDENTITY(1,1),
	Nombre varchar(200) NOT NULL,
	Capacidad varchar(20) NOT NULL,
	estatus varchar(20) not null,
	precio_alquiler decimal(8,2)
	PRIMARY KEY(NoCancha)

);

go
--TABLA TORNEO_EQUIPO 
CREATE TABLE TORNEO_EQUIPO
(
	Id_Torneo int NOT NULL ,
	Id_Equipo int NOT NULL,
	CostoInscripcion VARCHAR(200) NOT NULL,
	PRIMARY KEY(Id_Torneo,Id_Equipo)
);
go
ALTER TABLE TORNEO_EQUIPO
	ADD CONSTRAINT fk_torneoEquipo_TORNEO FOREIGN KEY (Id_Torneo)
	REFERENCES TORNEO (Id_Torneo)  ;
	go
ALTER TABLE TORNEO_EQUIPO
	ADD CONSTRAINT fk_torneoEquipo_equipo FOREIGN KEY (Id_Equipo)
	REFERENCES EQUIPO (Id_Equipo)  ;
	go
--TABLA POSICION_JUGADOR
 
CREATE TABLE POSICION_JUGADOR
(
	Id_Torneo int NOT NULL, 
	Id_Equipo int NOT NULL,
	Identificacion int NOT NULL,
	Posicion varchar(200),
	NumeroCamisola int NOT NULL,
	PRIMARY KEY(Id_Torneo,Id_Equipo,Identificacion)
);
go
ALTER TABLE POSICION_JUGADOR
	ADD CONSTRAINT fk_posicion_jugador_torneo FOREIGN KEY (Id_Torneo)
	REFERENCES TORNEO (Id_Torneo)  ;
	go
ALTER TABLE POSICION_JUGADOR
	ADD CONSTRAINT fk_posicion_jugador_equipo FOREIGN KEY (Id_Equipo)
	REFERENCES EQUIPO (Id_Equipo)  ;
	go
ALTER TABLE POSICION_JUGADOR
	ADD CONSTRAINT fk_posicion_jugador_jugador FOREIGN KEY (Identificacion)
	REFERENCES JUGADOR (Identificacion)  ;
	go


--TABLA partido

CREATE TABLE PARTIDO
(
	Id_Juego int NOT NULL IDENTITY(1,1),
	Id_Torneo int NOT NULL,
	Id_EquipoLocal int NOT NULL,
	Id_EquipoVisita int NOT NULL,
	Fecha datetime NOT NULL,			
	HoraInicio datetime NOT NULL,     		
	HoraFinal datetime NOT NUll,		
	MarcadorLocal  int NOT NUll,
	MarcadorVisita int NOT NUll,
	jugado BIT NOT NUll,
	PRIMARY KEY(Id_Juego)
);
go
ALTER TABLE PARTIDO
	ADD CONSTRAINT fk_partido_torneo FOREIGN KEY (Id_Torneo)
	REFERENCES TORNEO (Id_Torneo)  ;
	go
ALTER TABLE PARTIDO
	ADD CONSTRAINT fk_partido_equipoLocal FOREIGN KEY (Id_EquipoLocal)
	REFERENCES EQUIPO (Id_Equipo)  ;
	go
ALTER TABLE PARTIDO
	ADD CONSTRAINT fk_partido_equipoVisita FOREIGN KEY (Id_EquipoVisita)
	REFERENCES EQUIPO (Id_Equipo);
	go

--TABLA punteo
CREATE TABLE PUNTEO
(
	Id_Punteo int NOT NULL IDENTITY(1,1),
	Id_Juego int NOT NULL,
	Id_EquipoLocal int NOT NULL,
	Id_EquipoVisita	int NOT NULL,
	PunteoEquipoLocal int NOT NULL,
	PunteoEquipoVisita int NOT NULL,
	Golesvisita int NOT NULL,
	Goleslocal int NOT NULL,
	
	PRIMARY KEY(Id_Punteo)
);
go
ALTER TABLE PUNTEO
	ADD CONSTRAINT fk_PUNTEO_PARTIDO FOREIGN KEY (Id_Juego)
	REFERENCES PARTIDO (Id_Juego)  ;
	go
ALTER TABLE PUNTEO
	ADD CONSTRAINT fk_PUNTEO_equipoLocal FOREIGN KEY (Id_EquipoLocal)
	REFERENCES EQUIPO (Id_Equipo);
	go
ALTER TABLE PUNTEO
	ADD CONSTRAINT fk_PUNTEO_equipoVisita FOREIGN KEY (Id_EquipoVisita)
	REFERENCES EQUIPO (Id_Equipo);
	go


-- TABLA CAMBIO
CREATE TABLE CAMBIO
(
	Id_Cambio int NOT NULL IDENTITY(1,1),
	Id_Juego int NOT NULL,
	DPIJugadorEntra int NOT NULL,
	DPIJugadorsale	int NOT NULL,
	Tiempo_entrada varchar(200),
	Tiempo_salida varchar(200),
	PRIMARY KEY(Id_Cambio)
);
go
ALTER TABLE CAMBIO
	ADD CONSTRAINT fk_CAMBIO_PARTIDO FOREIGN KEY (Id_Juego)
	REFERENCES PARTIDO (Id_Juego)  ;
	go
ALTER TABLE CAMBIO
	ADD CONSTRAINT fk_CAMBIO_jugadorEntra FOREIGN KEY (DPIJugadorEntra)
	REFERENCES JUGADOR (Identificacion)  ;
	go
ALTER TABLE CAMBIO
	ADD CONSTRAINT fk_cambio_jugadorSale FOREIGN KEY (DPIJugadorSALE)
	REFERENCES JUGADOR (Identificacion)  ;
	go

--TABLA GOL
CREATE TABLE GOL
(
	Id_Gol int NOT NULL IDENTITY(1,1),
	Id_Juego int NOT NULL,
	Identificacion int NOT NULL,
	Tipo varchar(200),
	Tiempo varchar(200),
	PRIMARY KEY(Id_Gol)
);
go
ALTER TABLE GOL
	ADD CONSTRAINT fk_GOL_JUGADOR FOREIGN KEY (Id_Juego)
	REFERENCES PARTIDO (Id_Juego)  ;
go
ALTER TABLE GOL
	ADD CONSTRAINT fk_GOL_JUGADOR2 FOREIGN KEY (Identificacion)
	REFERENCES JUGADOR (Identificacion)  ;
	go

--TABLA ARBITRO_PARTIDO 
CREATE TABLE ARBITRO_PARTIDO
(
	DPI_Arbitro int NOT NULL,
	Id_Juego int NOT NULL,
	Pago varchar(100) NOT NULL,
	PRIMARY KEY(DPI_Arbitro, Id_Juego)
);
go

go
ALTER TABLE ARBITRO_PARTIDO
	ADD CONSTRAINT fk_ARBITRO_PARTIDO_ARBITRO FOREIGN KEY (DPI_Arbitro)
	REFERENCES ARBITRO (DPI)  ;
	go
ALTER TABLE ARBITRO_PARTIDO
	ADD CONSTRAINT fk_ARBITRO_PARTIDO_PARTIDO FOREIGN KEY (Id_Juego)
	REFERENCES PARTIDO (Id_Juego)  ;
	go

--TABLA ADMINISTRACION_CANCHA
CREATE TABLE ADMINISTRACION_CANCHA
(
	Id_Status int NOT NULL IDENTITY(1,1),
	Status_ varchar(200) NOT NULL,
	NoCancha int NOT NULL,
	Id_Juego int NOT NULL,
	PRIMARY KEY(Id_Status)
);
go
ALTER TABLE ADMINISTRACION_CANCHA
	ADD CONSTRAINT fk_ADMINISTRACION_CANCHA_CANCHA FOREIGN KEY (NoCancha)
	REFERENCES CANCHA (NoCancha)  ;
	go
ALTER TABLE ADMINISTRACION_CANCHA
	ADD CONSTRAINT fk_ADMINISTRACION_CANCHA_PARTIDO FOREIGN KEY (Id_Juego)
	REFERENCES PARTIDO (Id_Juego)  ;
	go

--TABLA registro_amonestacion
CREATE TABLE REGISTRO_AMONESTACION
(
	Id_Juego int NOT NULL,
	Id_Jugador int NOT NULL,
	Color_Tarjeta varchar(200) NOT NULL,
	Tiempo varchar(200) NOT NULL,
	Pagado BIT DEFAULT 0,
	PRIMARY KEY(Id_Juego,Id_Jugador, Color_Tarjeta)
);
go
ALTER TABLE REGISTRO_AMONESTACION
	ADD CONSTRAINT fk_REGISTRO_AMONESTACION_PARTIDO FOREIGN KEY (Id_Juego)
	REFERENCES partido (Id_Juego)  ;
	go
ALTER TABLE REGISTRO_AMONESTACION
	ADD CONSTRAINT fk_REGISTRO_AMONESTACION_JUGADOR FOREIGN KEY (Id_Jugador)
	REFERENCES   JUGADOR (Identificacion) ;
	go
ALTER TABLE REGISTRO_AMONESTACION
	ADD CONSTRAINT fk_REGISTRO_AMONESTACION_Color_Tarjeta FOREIGN KEY (Color_Tarjeta)
	REFERENCES AMONESTACION (ColorTarjeta)  ;
	

	go

create proc verjugadores
as
select * from JUGADOR
go
	--nuevas tablas*****************************************************************************************************07/05/2021
	
	create table parametros_empresa
	(
	id_empresa int not null identity(1,1),
	nombre_empresa varchar(100)default 'sin asiganr', 
	inicio_jornada_lunes_vienres time default '00:00:00',
	fin_jornada_lunes_viernes time default '00:00:00',
	inicio_jornada_sabados time default'00:00:00',
	fin_jornadas_sabados time default '00:00:00',
	inicio_jornadas_domingo time default'00:00:00',
	fin_jornada_domingo time default'00:00:00',
	PRIMARY KEY(id_empresa)
	)
	
	go
	create table alquiler (
	id_alquiler int not null identity(1,1),
	DPI  bigint not null,
	nombres varchar(100) default'ingresar nombre',
	apellidos varchar(100) default'inngresar apellidos',
	telefono varchar(100) default'0',
	correo  varchar(100) default 'ingresa corrreo',
	id_cancha int not null,
	id_arbitro int not null,
	fecha_reservacion date not null,
	hora_inicio_reservacion time default '00:00:00',
	hora_fin_reservacion time default '00:00:00',
	pago_cancha decimal (8,2),
	pago_arbitro decimal(8,2)
		PRIMARY KEY(id_alquiler)
	)
	go
	ALTER TABLE alquiler
	ADD CONSTRAINT fk_alquileres_canchas FOREIGN KEY (id_cancha)
	REFERENCES CANCHA(NoCancha)  ;
	go
		ALTER TABLE alquiler
	ADD CONSTRAINT fk_alquileres_arbitro FOREIGN KEY (id_arbitro)
	REFERENCES ARBITRO(DPI);
	go
	--creando nuevas tablas para los usuarios 12/05/2021
	
	create table usuarios(
	dpi_usuario bigint not null,
	nombre_usuario varchar(100) default 'sin asignar',
	apellidos varchar(100) default'sin agregar',
	telefono varchar(100) default'sin asignar',
	direccion varchar(100) default 'sin asignar',
	correo varchar(100) default 'sin asignar',
	puesto_usuario varchar(50),
	rol_usuario varchar(100) default 'sin asignar',
	contraeña varchar(100) not null,
	activo varchar(1) default 'S',
	PRIMARY KEY(dpi_usuario)
	)
	go

	insert into usuarios(dpi_usuario,nombre_usuario,apellidos,puesto_usuario,contraeña,activo)values(0,'admin 1','admin 1','Administrador','111','S');
	go
	--bitacoras tablas

	create  table bitacoras(
	id_bitacora int identity(1,1) not null,
	nombre_usuario varchar(100)default'sin asignar' ,
	apellido_usuaio varchar(100) default'sin asignar',
	puesto_trabajo varchar(100) default'sin asignar',
	acciones_sistema varchar(100) default'sin asignar',
	fecha_hora datetime default getdate()
	)

	



	go




	--*************************************************NUEVOS PROCEDIMIENTOS-------------------07/05/2020
	--use EEEG
	--drop database Proyecto_AdministracionTorneosFutbol
	
	
	--igresando valores en parametros empresa
	go

	insert into parametros_empresa(nombre_empresa,inicio_jornada_lunes_vienres,fin_jornada_lunes_viernes,inicio_jornada_sabados,fin_jornadas_sabados,inicio_jornadas_domingo,fin_jornada_domingo)values('sin asignar nombre','0:00','0:00','00:00','0:00','0:00','0:00');
	go




	--nuevos procedimientos  11/05/2021  PARAMERTRO EDITABLE 11/05/2021
	go
	create proc insertar_alquileres @DPI bigint,@nombres varchar(100),@apellidos varchar(100),@telefono varchar(100),@correo varchar(100),@id_cancha int,@id_arbitro int, @fecha_reservacion datetime, @horainicio time, @horasalida time,@pago_cancha decimal(8,2),@pago_arbitro decimal(8,2)
	as
	insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)
	values(@DPI,@nombres,@apellidos,@telefono,@correo,@id_cancha,@id_arbitro,@fecha_reservacion,@horainicio,@horasalida,@pago_cancha,@pago_arbitro)
	--exec insertar_alquileres  @DPI=123456,@nombres='nenene',@apellidos='feo',@telefono='123456',@correo='correo',@id_cancha=1,@id_arbitro=0,@fecha_reservacion='2021/01/01',@horainicio='10:00',@horasalida='11:00',@pago_cancha='350',@pago_arbitro=0.0
	--exec insertar_alquileres @DPI,@nombres,@apellidos,@telefono,@correo,@id_cancha,@id_arbitro,@fecha_reservacion,@horainicio,@horasalida,@pago_cancha,@pago_arbitro


--nuevo procedimiento tabla usuarios
go

--creando procedimiento para la vista de alquileres

create proc mostrar_alquileres
as
select id_alquiler,DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro,SUM(pago_arbitro+pago_cancha)PAGO_TOTAL from alquiler
group by id_alquiler,DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro

--exec mostrar_alquileres
go
create proc ver_usuarios
as
select*from usuarios

--exec ver_usuarios
go
--procedimiento para agregar nuevos usuarios 1205/2021
create proc insertar_usuarios  @dpi bigint,@nombres varchar(100),@apellidos varchar(100),@telefonos varchar(100),@direccion varchar(100),@correo varchar(100),@puesto_usuario varchar(50),@rol varchar(100),@contraeña varchar(100),@activo varchar(1) 
as
insert into usuarios(dpi_usuario,nombre_usuario,apellidos,telefono,direccion,correo,puesto_usuario,rol_usuario,contraeña,activo)values(@dpi,@nombres,@apellidos,@telefonos,@direccion,@correo,@puesto_usuario,@rol,@contraeña,@activo)
--exec insertar_usuarios @dpi,@nombres,@apellidos,@telefonos,@direccion,@correo,@puesto_usuario,@rol,@contraeña,@activo
go

--procedimneitnos para busvcar a jugadores por dpi 12/05/2021
create proc buscar_usuarios_dpi @dpi bigint
as
select*from usuarios where dpi_usuario=@dpi
--exec buscar_usuarios_dpi @dpi=123
go 
-- procedimientos para actualizar los usuarios 12/05/2021

create proc actualizar_datos_usuarios @dpi_usuario bigint,@nombre_usuario varchar(100),@apellidos varchar(100),@telefono varchar(100),@direccion varchar(100),@correo varchar(100),@puesto_usuario varchar(100),@rol_usuario varchar(100),@contraeña varchar(100),@activo varchar(1)
as
update usuarios set nombre_usuario=@nombre_usuario,apellidos=@apellidos,telefono=@telefono,direccion=@direccion,correo=@correo,puesto_usuario=@puesto_usuario,rol_usuario=@rol_usuario,contraeña=@contraeña,activo=@activo  where dpi_usuario=@dpi_usuario
	
--exec actualizar_datos_usuarios @dpi_usuario,@nombre_usuario,@apellidos,@telefono,@direccion,@correo,@puesto_usuario,@rol_usuario,@contraeña,@activo
go

--procedimientos para desactivar usuario
create proc desactivar_usuarios_por_dpi @dpi_usuario bigint
as
update usuarios set activo='N' where dpi_usuario=@dpi_usuario
--exec desactivar_usuarios_por_dpi @dpi_usuario=12
	go

	--creacion de procedimientos para el login 13/05/2021 
	go

create proc validar_ingreso_usuarios @nombre_usuario varchar(100),@apellido_usuario varchar(100),@contraseña varchar(100)
as
select  dpi_usuario,nombre_usuario,apellidos,contraeña,puesto_usuario,activo from usuarios where nombre_usuario=@nombre_usuario and apellidos=@apellido_usuario and contraeña=@contraseña 
--exec validar_ingreso_usuarios @nombre_usuario, @apellido_usuario, @contraseña
go
--creando procedimiento para mostrar los apellidos de usuarios con un nombre igual.
create proc apellidos_nombres_iguales @nombres varchar(100)
as
select apellidos from usuarios where nombre_usuario=@nombres
--exec apellidos_nombres_iguales @nombres= rgi

go
--creando procedimeintos para la mostrar los parametros de la empresa
create proc parametros
as
select*from parametros_empresa
--exec parametros
go
-- creando procedimeinto para selecionar un solo registro pen la tabla parametros
create proc seleccionar_un_registro @id_empresa int
as
select*from parametros_empresa  where id_empresa=@id_empresa;
--exec seleccionar_un_registro @id_empresa=2
go
--procedimiento para actualizar los campso de la tabala parametros 14/05/2021

create proc actualizar_parametros_empresa @id_empresa int, @nombre_empresa varchar(100),@inicio_jornada_lunes_vienres time,@fin_jornada_lunes_viernes time,@inicio_jornada_sabados time,@fin_jornadas_sabados time,@inicio_jornadas_domingo time,@fin_jornada_domingo time
as
update parametros_empresa set nombre_empresa=@nombre_empresa,inicio_jornada_lunes_vienres=@inicio_jornada_lunes_vienres,fin_jornada_lunes_viernes=@fin_jornada_lunes_viernes,inicio_jornada_sabados=@inicio_jornada_sabados,fin_jornadas_sabados=@fin_jornadas_sabados,inicio_jornadas_domingo=@inicio_jornadas_domingo,fin_jornada_domingo=@fin_jornada_domingo where id_empresa=@id_empresa
--exec actualizar_parametros_empresa @id_empresa,@nombre_empresa,@inicio_jornada_lunes_vienres,@fin_jornada_lunes_viernes,@inicio_jornada_sabados,@fin_jornadas_sabados,@inicio_jornadas_domingo,@fin_jornada_domingo


go

--nuevos procedimeintos para la trabla de alquileres 18:15 17/05/2021 en donde se mostrara solo las canchas disponibles disponibles



--select*from  ARBITRO
--where NoCancha  not in(
--select adc.NoCancha from PARTIDO p
--inner join ADMINISTRACION_CANCHA adc
--on p.Id_Juego=adc.Id_Juego
--where CONVERT(date,p.Fecha)='2021/01/01' and CONVERT(time,HoraInicio)>='13:00' and CONVERT(time,HoraInicio)<='14:00'
--)
--and NoCancha not in
--(select id_cancha from alquiler
--where fecha_reservacion='2021/01/01' and hora_inicio_reservacion>='13:00' and hora_fin_reservacion<='14:00'
--) 
go

	--insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)values(12,'b','c','111','@torneo',1,0,'2021/01/17','12:00','13:00',50,0.0)
	--insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)values(123,'b','c','111','@torneo',1,0,'2021/01/18','13:00','14:00',50,0.0)
	--insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)values(1234,'b','c','111','@torneo',2,1,'2021/02/18','14:00','15:00',50,300)
	--insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)values(12345,'b','c','111','@torneo',3,2,'2021/02/18','15:00','16:00',50,300)
	--insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)values(1231,'b','c','111','@torneo',4,2,'2021/03/19','16:00','17:00',50,200)
	--insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)values(1222,'b','c','111','@torneo',7,12,'2021/03/20','17:00','18:00',50,100)
	--insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)values(1223,'b','c','111','@torneo',7,12,'2021/03/20','18:00','19:00',50,100)
	--insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)values(1233,'b','c','111','@torneo',7,12,'2021/08/21','19:00','20:00',50,100)
	--insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)values(12248,'b','c','111','@torneo',3,0,'2021/08/21','12:00','13:00',50,0.0)
	--insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)values(12888,'b','c','111','@torneo',3,0,'2021/08/21','11:00','12:00',50,0.0)
	--insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)values(1299,'b','c','111','@torneo',3,0,'2021/12/08','12:00','13:00',50,0.0)
	--insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)values(99,'b','c','111','@torneo',2,1,'2021/12/01','11:00','13:00',50,300)
	--insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)values(100,'b','c','111','@torneo',2,1,'2021/02/01','11:00','13:00',50,300)
	--insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)values(106,'b','c','111','@torneo',2,2,'2021/07/01','10:00','11:00',50,100)
	--insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)values(123456,'b','c','111','@torneo',1,2,'2021/07/10','10:00','11:00',50,100)
	--insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)values(1089,'b','c','111','@torneo',1,12,'2021/09/11','09:00','10:00',50,100)
	--insert into alquiler(DPI,nombres,apellidos,telefono,correo,id_cancha,id_arbitro,fecha_reservacion,hora_inicio_reservacion,hora_fin_reservacion,pago_cancha,pago_arbitro)values(1078,'b','c','111','@torneo',7,12,'2021/09/12','10:00','11:00',50,100)
	
	--creando reporte de cancha
	

	create proc  reporte_canchas_alquileres @fecha_inico date,@fecha_final date
	as
	select alquiler.id_cancha,CANCHA.Nombre nombre_cancha,year(fecha_reservacion)año ,MONTH(fecha_reservacion)mes,DAY(fecha_reservacion)dia,sum(pago_cancha)monto_por_dia_cancahas
	from alquiler
	inner join CANCHA
	on alquiler.id_cancha=CANCHA.NoCancha
	where fecha_reservacion between @fecha_inico and @fecha_final
	group by alquiler.id_cancha,CANCHA.Nombre,year(fecha_reservacion),MONTH(fecha_reservacion),DAY(fecha_reservacion)
	order by MONTH(fecha_reservacion)asc
--EXEC reporte_canchas_alquileres @fecha_inico='2021/05/18',@fecha_final='2021/07/30'
go
select*from alquiler
--creaNDO REPRTE PARA ARBITROS
go

create proc  reporte_arbitro_alquileres @fecha_inico date,@fecha_final date
	as
	select alquiler.id_arbitro,arbitro.Nombre nombre_arbitro,arbitro.Apellidos apellido_arbitro,year(fecha_reservacion)año ,MONTH(fecha_reservacion)mes,DAY(fecha_reservacion)dia,sum(pago_arbitro)monto_por_dia_arbitro
	from alquiler
	inner join arbitro
	on alquiler.id_arbitro=arbitro.DPI
	where fecha_reservacion between @fecha_inico  and @fecha_final and arbitro.DPI<>0
	group by alquiler.id_arbitro,arbitro.Nombre,arbitro.Apellidos,year(fecha_reservacion),MONTH(fecha_reservacion),DAY(fecha_reservacion)
	order by MONTH(fecha_reservacion)asc
--EXEC reporte_arbitro_alquileres @fecha_inico='2021/01/01',@fecha_final='2021/07/30'


go
--insertando bitacoras procedimiento almacenado
create proc insertando_bitacoras @nombre_usuario varchar(100),@apellido_usuaio varchar(100),@puesto_trabajo varchar(100),@acciones_sistema varchar(100)
as
insert into bitacoras(nombre_usuario,apellido_usuaio,puesto_trabajo,acciones_sistema) values(@nombre_usuario,@apellido_usuaio,@puesto_trabajo,@acciones_sistema)
--exec insertando_bitacoras @nombre_usuario,@apellido_usuaio,@puesto_trabajo,@acciones_sistema
go
--haciednop reportes de bitacoras por rango de fechas

create proc reporte_por_fechas_bitacora @fecha_inico datetime,@fecha_fin datetime
as 
select*from bitacoras 
where CONVERT(date,fecha_hora)>= @fecha_inico and CONVERT(date,fecha_hora)<=@fecha_fin
order by fecha_hora asc
--exec reporte_por_fechas_bitacora @fecha_inico='2021/05/18',@fecha_fin='2021/05/18'
go
--haciednop reportes de bitacoras por usuario

create proc reporte_por_usuario_bitacora @nombre_usuario varchar(100), @apellido_usuario varchar(100)
as 
select*from bitacoras 
where nombre_usuario=@nombre_usuario and apellido_usuaio=@apellido_usuario
order by fecha_hora asc
--exec reporte_por_usuario_bitacora @nombre_usuario=ana,@apellido_usuario=garcia
go

--procedimientos para las validaciones de la tabla alquileres
create proc canchas_disponibles @fecha_reservaciones datetime, @hora_inicio_reservacion time, @hora_fin_reservacion time
as
select*from  CANCHA
where NoCancha  not in(
select adc.NoCancha from PARTIDO p
inner join ADMINISTRACION_CANCHA adc
on p.Id_Juego=adc.Id_Juego
where CONVERT(date,p.Fecha)=@fecha_reservaciones and (CONVERT(time,HoraInicio)>=@hora_inicio_reservacion and   CONVERT(time,HoraFinal)<=@hora_fin_reservacion)
)
and NoCancha not in
(select id_cancha from alquiler
where fecha_reservacion=@fecha_reservaciones and hora_inicio_reservacion>=@hora_inicio_reservacion and hora_fin_reservacion<=@hora_fin_reservacion
)and NoCancha  not in(
select adc.NoCancha from PARTIDO p
inner join ADMINISTRACION_CANCHA adc
on p.Id_Juego=adc.Id_Juego
where CONVERT(date,p.Fecha)=@fecha_reservaciones and (CONVERT(time,HoraInicio)<=@hora_inicio_reservacion and   CONVERT(time,HoraFinal)>=@hora_fin_reservacion)
)and NoCancha not in
(select id_cancha from alquiler
where fecha_reservacion=@fecha_reservaciones and hora_inicio_reservacion<=@hora_inicio_reservacion and hora_fin_reservacion>=@hora_fin_reservacion
)
and NoCancha not in
(select id_cancha from alquiler
where fecha_reservacion=@fecha_reservaciones and hora_inicio_reservacion<=@hora_inicio_reservacion and hora_fin_reservacion>@hora_inicio_reservacion
)
and NoCancha not in
(select id_cancha from alquiler
where fecha_reservacion=@fecha_reservaciones and hora_inicio_reservacion<@hora_fin_reservacion and hora_fin_reservacion>=@hora_fin_reservacion
)

and estatus='Habilitada'

																									
																								
--exec canchas_disponibles @fecha_reservaciones='2021/06/03',@hora_inicio_reservacion='20:00',@hora_fin_reservacion='21:00'



select*from PARTIDO
select*from ADMINISTRACION_CANCHA
select*from CANCHA
select*from alquiler
select*from PARTIDO



















go
	--creando procedimeintos para ver la disponiblidad de arbitros en l atabla de partidos y aalquileres (revisar)
create proc vista_arbitros_disponibles @fecha_reservacion datetime,@hora_inicio_reservacion time,@hora_fin_reservacion time
	as 
select*from  ARBITRO
where DPI  not in(
select ap.DPI_Arbitro from PARTIDO p
inner join ARBITRO_PARTIDO ap
on p.Id_Juego=ap.Id_Juego
where CONVERT(date,p.Fecha)=@fecha_reservacion and CONVERT(time,HoraInicio)>=@hora_inicio_reservacion and CONVERT(time,HoraFinal)<=@hora_fin_reservacion
)
and DPI  not in
(select id_arbitro from alquiler
where fecha_reservacion=@fecha_reservacion and hora_inicio_reservacion>=@hora_inicio_reservacion and hora_fin_reservacion<=@hora_fin_reservacion
)
and DPI<>0
--exec vista_arbitros_disponibles @fecha_reservacion='2021/02/18',@hora_inicio_reservacion='14:00',@hora_fin_reservacion='15:00'





go
--creando procedimientospara la disponibilidad de canchas en reportes NOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO

CREATE PROC DISPONIBILIDAD_CANCHA @Fecha DATETIME,@Hora_Inicio time, @Hora_Fin time, @NoCancha INT
	AS
	SELECT * FROM alquiler AC WHERE AC.id_cancha = @NoCancha AND AC.fecha_reservacion = @Fecha AND AC.hora_inicio_reservacion <= @Hora_Inicio AND AC.hora_fin_reservacion >= @Hora_Fin
	
	--exec PROC DISPONIBILIDAD_CANCHA ,@NoCancha,@Fecha,@Hora_Inicio,@Hora_Fin

	go
	
	create proc update_alquileres @id_alquiler int ,@DPI bigint,@nombres varchar(100),@apellidos varchar(100),@telefono varchar(50),@correo varchar(100),@id_cancha int,@id_arbitro int,@fecha_reservacion date,@hora_inicio_reservacion time,@hora_fin_reservacion time ,@pago_cancha decimal(8,2),@pago_arbitro decimal(8,2)
	as
	update alquiler set DPI=@DPI,nombres=@nombres,apellidos=@apellidos,telefono=@telefono,correo=@correo,id_cancha=@id_cancha,id_arbitro=@id_arbitro,fecha_reservacion=@fecha_reservacion,hora_inicio_reservacion=@hora_inicio_reservacion,hora_fin_reservacion=@hora_fin_reservacion,pago_cancha=@pago_cancha,pago_arbitro=@pago_arbitro where id_alquiler=@id_alquiler
	--exec update_alquileres @id_alquiler  ,@DPI ,@nombres ,@apellidos ,@telefono ,@correo ,@id_cancha,@id_arbitro ,@fecha_reservacion,@hora_inicio_reservacion,@hora_fin_reservacion ,@pago_cancha,@pago_arbitro
	go
	
	--creando procedimientos para ver la canchas utilizadas en alquileres
	create proc procedimiento_cacnhas_utilizadas_alquiler @fecha_incio date,@fecha_fin date,@nombre_canchas varchar(100)
	as
	select c.NoCancha,c.Nombre,a.fecha_reservacion,a.hora_inicio_reservacion,a.hora_fin_reservacion from CANCHA c
	left join alquiler a
	on c.NoCancha=a.id_cancha
	group by c.NoCancha,c.Nombre, a.fecha_reservacion,a.hora_inicio_reservacion,a.hora_fin_reservacion
	having  a.fecha_reservacion between @fecha_incio and @fecha_fin and c.Nombre=@nombre_canchas

	--exec procedimiento_cacnhas_utilizadas_alquiler @fecha_incio='2021/01/01',@fecha_fin='2021/07/01',@nombre_canchas='cancha1'
	go
	create proc editar_un_aluiler @id_cancha int
	as
	select*from alquiler where id_alquiler=@id_cancha
	--editar_un_aluiler @id_cancha=1
	go
	create proc disponibilidad_de_cacnchas_alquileres2 @fecha_i date, @fecha_f date, @nombre_c varchar(100)
	as
	select c.NoCancha,c.Nombre,convert(date, p.Fecha)fecha_torneo,CONVERT(time, p.HoraInicio)hora_inicio_tonrneo,CONVERT(time, p.HoraFinal)hora_fin_torneo from PARTIDO p
	inner join ADMINISTRACION_CANCHA ac
	on p.Id_Juego=ac.Id_Juego
	inner join CANCHA c
	on c.NoCancha=ac.NoCancha
	group by  c.NoCancha,c.Nombre, convert(date, p.Fecha),CONVERT(time, p.HoraInicio),CONVERT(time, p.HoraFinal)
	having c.Nombre=@nombre_c and (convert(date, p.Fecha) between @fecha_i and @fecha_f)

	--exec disponibilidad_de_cacnchas_alquileres2 @fecha_i='2021/01/01',@fecha_f='2021/10/01',@nombre_c='cancha1'
	select*from alquiler
	select*from cancha
	go


	
	





select*from CANCHA
select*from alquiler
go


