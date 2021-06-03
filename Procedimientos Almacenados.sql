-- PROCEDIMIENTOS ALMACENADOS DE ARBITROS
-- Vista
use Proyecto_AdministracionTorneosFutbol
go

go
create proc getArbitros
as
    select * from ARBITRO where DPI<>0
go
--exec getArbitros
-- Creacion
create proc insertar_arbitros @DPI int, @nombre varchar(200),@apellido varchar(200),@direccion varchar(200),@telefono varchar(200),@nacionalidad varchar(200),@fechaNac date,@correo varchar(200),@rol varchar(200),@pago_alquiler decimal(8,2)
as
	insert into ARBITRO
    (
        DPI,nombre,apellidos,Direccion,telefono,
        Nacionalidad,FechaNac,Correo,Rol,pago_alquiler
    )
    values
    (
        @DPI,@nombre,@apellido,@direccion,@telefono,
        @nacionalidad,@fechaNac,@correo,@rol,@pago_alquiler
    )
go
-- Actualizacion
create proc actualizar_arbitros @DPI int, @nombre varchar(200),
    @apellido varchar(200),@direccion varchar(200),
    @telefono varchar(200),@nacionalidad varchar(200),
    @fechaNac date,@correo varchar(200),@rol varchar(200),@pago_alquiler decimal(8,2)
as
    update ARBITRO set 
        Nombre= @nombre, Apellidos= @apellido, 
        Direccion= @direccion, Telefono= @telefono, 
        Nacionalidad=@nacionalidad, FechaNac=@fechaNac,
        Correo= @correo ,Rol= @rol,pago_alquiler=@pago_alquiler  where DPI= @DPI
go

-- Eliminacion
create proc eliminar_arbitro @id int
as
    delete from arbitro where DPI=@id
go

-- PROCEDIMIENTOS ALMACENADOS DE CAMBIOS
-- Buscar partido
create proc getPartido
as
	Select * from PARTIDO
go
-- Obtener nombre de jugador 
create proc nombre_jugador @identificacion int
as
    select * from jugador where identificacion=@identificacion
go
-- Busqueda de jugador
create proc identificacionJugadores @id_juego int
as
    select j.Identificacion from jugador j
    where j.Identificacion =any
    (
        select pj.Identificacion from posicion_jugador pj
        where Id_Equipo =any
        (
            select p.Id_EquipoLocal  from partido p 
            where p.Id_Juego=@id_juego
        )
        or Id_Equipo =any 
        ( 
            select p.Id_EquipoVisita  from partido p 
            where p.Id_Juego=@id_juego
        )
    )
go
-- Vista
create proc getCambio
as
    select * from CAMBIO
go
-- Creacion
create proc insertar_cambios 
    @id_juego int,@DPIEntrada int, @DPISalida int,
    @tiempoEntrada varchar(200),@tiempoSalida varchar(200)
as
	insert into CAMBIO
    (
        Id_Juego,DPIJugadorEntra,DPIJugadorsale,
        Tiempo_entrada,Tiempo_salida
    )
    values
    (
        @id_juego,@DPIEntrada, @DPISalida,
        @tiempoEntrada,@tiempoSalida
    )
go
-- Buscar equipos
create proc nombres_equipos @id_juego int,@id_torneo int
as
    select e.Nombre,ee.Nombre from PARTIDO p
    inner join equipo e
    on p.Id_EquipoLocal=e.Id_Equipo
    inner join equipo ee 
    on p.Id_EquipoVisita=ee.Id_Equipo
    where Id_Juego=@id_juego 
    and p.Id_Torneo=@id_Torneo
go
-- Buscar los jugadores por equipo y por torneo
create proc buscar_jugadores_equipo_torneo
    @nombre varchar(100),@id_torneo int
as
    Select Distinct j.Nombres from POSICION_JUGADOR pj
    inner join JUGADOR j
    on j.Identificacion= pj.Identificacion
    inner join EQUIPO e
    on pj.Id_Equipo=e.Id_Equipo
    inner join TORNEO_EQUIPO tq
    on pj.Id_Torneo=tq.Id_Torneo
    where e.Nombre=@nombre 
    and tq.Id_Torneo=@id_torneo
go
-- Buscar identificacion por nombre
create proc buscar_identificacion_por_nombre @nombre varchar(200)
as
    Select Identificacion from jugador where Nombres=@nombre
go
-- Seleccionar cambio
create proc Seleccionar_cambio @id int
as
    select  
        c.Id_Cambio, c.Id_Juego,c.DPIJugadorEntra,
        c.DPIJugadorsale,j.Nombres,j2.Nombres,
        e.Nombre,c.Tiempo_entrada,c.Tiempo_salida 
    from cambio c,POSICION_JUGADOR pj,EQUIPO e, jugador j,jugador j2 
    where Id_Cambio=@id 
    and pj.Identificacion=c.DPIJugadorEntra 
    and c.DPIJugadorEntra=j.Identificacion 
    and c.DPIJugadorsale=j2.Identificacion 
    and e.Id_Equipo=pj.Id_Equipo
go
-- Actualizar cambios
create proc actualizar_cambios 
    @id_cambio int,@id_juego int , @dpi_entra int,@dpi_sale int,
    @tiempo_entrada varchar(200),@tiempo_salida varchar(200)
as
    update CAMBIO set 
        Id_Juego= @id_juego,DPIJugadorEntra= @dpi_entra,
        DPIJugadorsale= @dpi_sale,Tiempo_entrada=@tiempo_entrada,
        Tiempo_salida=@tiempo_salida 
    where Id_Cambio =@id_cambio
go
-- Eliminar
create proc eliminar_cambio @id_cambio int
as
    delete from CAMBIO where Id_Cambio = @id_cambio
go

-- PROCEDIMIENTOS ALMACENADOS DE CANCHAS
create proc newich
as
    select  case when count(*)> 0 
        then max(NoCancha) else 0 end as n_cancha  
    from CANCHA
go


-- PROCEDIMIENTOS ALMACENADOS DE CONTROL AMONESTACION
-- Creacion
CREATE PROCEDURE SP_INSERT_CONTROL_AMONESTACION @Id_Juego INT, @Id_Jugador INT, @Color_Tarjeta VARCHAR(200), @Tiempo VARCHAR(200)
AS BEGIN
    INSERT INTO REGISTRO_AMONESTACION
    (
        Id_Juego, Id_Jugador, Color_Tarjeta, Tiempo
    )
    VALUES
    (
        @Id_Juego, @Id_Jugador, @Color_Tarjeta, @Tiempo
    )
END
GO
-- Vista 
CREATE PROCEDURE SP_VIEW_CONTROL_AMONESTACION @Id_Juego INT
AS BEGIN
    SELECT rg.*,(
        select j.Nombres + ' ' +j.Apellidos as nombres  
        from JUGADOR j where j.Identificacion= rg.Id_Jugador
    ) FROM REGISTRO_AMONESTACION rg WHERE Id_Juego = @Id_Juego;
END
GO
-- Actualizacion 
CREATE PROCEDURE SP_UPDATE_CONTROL_AMONESTACION
	@Id_Juego INT, @Id_Jugador INT, 
    @Color_Tarjeta VARCHAR(200), @Tiempo VARCHAR(200)
AS BEGIN
	UPDATE REGISTRO_AMONESTACION SET 
		Id_Juego = @Id_Juego, 
		Id_Jugador = @Id_Jugador, 
		Color_Tarjeta = @Color_Tarjeta,
		Tiempo = @Tiempo
	WHERE Id_Juego = @Id_Juego
	AND Id_Jugador = @Id_Jugador
	AND Color_Tarjeta = @Color_Tarjeta
END
GO
-- Eliminar
CREATE PROCEDURE SP_DELETE_CONTROL_AMONESTACION
	@Id_Juego INT, @Id_Jugador INT, @Color_Tarjeta VARCHAR(200)
AS BEGIN
	DELETE FROM REGISTRO_AMONESTACION 
	WHERE Id_Juego = @Id_Juego
	AND Id_Jugador = @Id_Jugador
	AND Color_Tarjeta = @Color_Tarjeta
END
GO

-- PROCEDIMIENTOS ALMACENADO DE entrenador
-- Vista
CREATE PROCEDURE SP_VIEW_ENTRENADORES
AS BEGIN
	SELECT * FROM ENTRENADOR
END
GO 
-- Busqueda de entrenador
CREATE PROCEDURE SP_SEARCH_ENTRENADOR @opcion INT, @busqueda VARCHAR(200)
AS BEGIN
	IF @opcion = 0		
		SELECT EN.DPI, 
			EN.Id_Equipo, 
			EN.Nombre, 
			EN.Apellidos,
			EN.Telefono,
			EN.FechaNac,
			EN.Correo,
			EN.Tiempo,
			EN.Salario
		FROM ENTRENADOR EN INNER JOIN EQUIPO EQ 
		ON EN.Id_Equipo = EQ.Id_Equipo
		WHERE EQ.Nombre = @busqueda
	ELSE IF	@opcion = 1
		SELECT *
		FROM ENTRENADOR EN
		WHERE EN.Nombre = @busqueda
	ELSE IF @opcion = 2
		SELECT *
		FROM ENTRENADOR EN
		WHERE EN.Apellidos = @busqueda
	ELSE IF @opcion = 3
		SELECT *
		FROM ENTRENADOR EN
		WHERE EN.DPI = @busqueda
END
GO
-- Creacion
CREATE PROCEDURE SP_INSERT_ENTRENADOR 
	@DPI bigint,@Id_Equipo INT,@Nombre VARCHAR (200), 
	@Apellidos VARCHAR (200),@Telefono VARCHAR (200),
	@FechaNac DATETIME,@Correo VARCHAR (200),
	@Tiempo VARCHAR (200),@Salario VARCHAR (200)
AS BEGIN
	INSERT INTO ENTRENADOR 
    ( 
        DPI,Id_Equipo,Nombre,Apellidos,Telefono,
        FechaNac,Correo,Tiempo,Salario
    )
	VALUES (
		@DPI,@Id_Equipo,@Nombre,@Apellidos,@Telefono,
		@FechaNac,@Correo,@Tiempo,@Telefono
	)
END
GO
-- Actualizar
CREATE PROCEDURE SP_UPDATE_ENTRENADOR 
	@DPI bigint,@Id_Equipo INT,@Nombre VARCHAR (200),
    @Apellidos VARCHAR (200),@Telefono VARCHAR (200),
    @FechaNac DATETIME,@Correo VARCHAR (200),
	@Tiempo VARCHAR (200),@Salario VARCHAR (200)
AS BEGIN
	UPDATE ENTRENADOR SET 
	Id_Equipo = @Id_Equipo,Nombre = @Nombre,
	Apellidos = @Apellidos,Telefono = @Telefono,
	FechaNac = @FechaNac,Correo = @Correo,
	Tiempo = @Tiempo,Salario = @Salario
	WHERE DPI = @DPI
END
GO
-- Eliminar
CREATE PROCEDURE SP_DELETE_ENTRENADOR @DPI bigint
AS BEGIN
	DELETE FROM ENTRENADOR WHERE DPI = @DPI
END
GO

-- PROCEDIMIENTO ALMACENADO DE EQUIPO TORNEO
-- Creacion
CREATE PROCEDURE INSERT_TORNEO_EQUIPO 
    @Id_Torneo int, @Id_Equipo int, 
    @CostoInscripcion varchar(100)
AS BEGIN 
	INSERT INTO TORNEO_EQUIPO 
    (
        Id_Torneo,Id_Equipo,
        CostoInscripcion
    )
	VALUES 
    (
        @Id_Torneo,@Id_Equipo,
        @CostoInscripcion
    );
END 
GO 
-- Vista
CREATE PROCEDURE VIEWTORNEO_EQUIPO @Id_Torneo int
AS BEGIN 
	SELECT e.*, (
        select eq.nombre from equipo eq 
        where eq.Id_Equipo=e.Id_Equipo
    ) as Equipo FROM TORNEO_EQUIPO e 
    WHERE Id_Torneo = @Id_Torneo
END 
GO
-- Actualizacion
CREATE PROCEDURE UPDATE_TORNEO_EQUIPO 
    @Id_Torneo int, @Id_Equipo int, 
    @CostoInscripcion varchar(100)
AS BEGIN
	UPDATE TORNEO_EQUIPO SET 
        Id_Torneo = @Id_Torneo, Id_Equipo= @Id_Equipo, 
        CostoInscripcion = @CostoInscripcion 
    WHERE Id_Equipo = @Id_Equipo 
    and Id_Torneo = @Id_Torneo
END
GO
-- Eliminacion
CREATE PROCEDURE DELETE_TORNEO_EQUIPO @Id_Equipo INT, @Id_Torneo Int
AS BEGIN
	DELETE FROM TORNEO_EQUIPO 
    WHERE Id_Equipo = @Id_Equipo 
    and Id_Torneo = @Id_Torneo
END
GO

-- CREACION DE PROCEDIMIENTOS DE EQUIPO
-- Vista
CREATE PROCEDURE SP_VIEW_EQUIPOS
AS BEGIN
	SELECT * FROM EQUIPO
END
GO
-- Creacion
CREATE PROCEDURE SP_INSERT_EQUIPO 
    @Nombre VARCHAR(100), @CantidadJugadores INT, 
    @Representante VARCHAR(100)
AS BEGIN
    INSERT INTO EQUIPO 
    (
        Nombre, CantidadJugadores, Representante
    ) 
    VALUES 
    (
        @Nombre,@CantidadJugadores,@Representante
    );
END
GO
-- Actualizacion
CREATE PROCEDURE SP_UPDATE_EQUIPO 
    @Id_Equipo INT, @Nombre VARCHAR(100), 
    @CantidadJugadores INT, @Representante VARCHAR(100)
AS BEGIN
	UPDATE EQUIPO SET 
        Nombre=@Nombre, CantidadJugadores=@CantidadJugadores, 
        Representante=@Representante 
    WHERE Id_Equipo = @Id_Equipo
END
GO
-- Eliminacion
CREATE PROCEDURE SP_DELETE_EQUIPO @Id_Equipo INT
AS BEGIN
	DELETE FROM EQUIPO WHERE Id_Equipo = @Id_Equipo
END
GO

-- PROCEDIMIENTOS ALMACENADOS DE GOLES
-- Vista
create proc vergoles @id int
as 
    select 
        g.Id_Gol , g.Id_Juego , g.Identificacion ,
        j.Nombres + ' ' + j.Apellidos as Nombre , 
        g.Tipo , g.Tiempo 
    from gol  g , JUGADOR j 
    where Id_Juego=@id  
    and g.Identificacion=j.Identificacion
go
-- Buscar gol por id
create proc getgolbyid @id int 
as select * from gol where Id_Gol = @id
GO
-- Creacion
create proc goles 
    @jg int ,@dpi int ,
    @tipo varchar (200), @tiemp int
as 
    insert into Gol 
    (
        id_juego,Identificacion,Tipo,Tiempo
    ) 
    values 
    ( 
        @jg,@dpi,@tipo, @tiemp
    )
 go 
-- Actualizacion
create proc golesupd 
    @id int ,@dpi int ,@tipo varchar (200), @tiemp int
as 
    update gol set 
        Identificacion= @dpi , Tipo=@tipo , Tiempo =@tiemp 
    WHERE Id_Gol=@id
go

-- PROCEDIMIENTOS ALMACENADO DE JUGADOR
-- Vista
create proc verjugadoresporid @id int
as
    select * from JUGADOR where Identificacion=@id
go

-- Creacion
create proc insjs 
    @id int , @nb varchar(200) , @ap varchar(200),
    @fn date ,@drc varchar(250) , @nac varchar(200), 
    @cr varchar(200), @tf varchar(200),@medad bit
as 
    INSERT INTO [dbo].[JUGADOR]
    (
        [Identificacion],[Nombres],[Apellidos],[Fecha_nac]
        ,[Direccion],[Nacionalidad],[Correo],[Telefono],[Menor_edad]
    )
    VALUES 
    (
        @id  , @nb , @ap ,@fn,@drc  , @nac , @cr , @tf,@medad 
    )
go
-- Busqueda por id
create proc verjugadoresporid @id int
as
    select * from JUGADOR where Identificacion=@id
go
-- Eliminacion
create proc dtljs @id int 
as 
    delete from JUGADOR where Identificacion=@id;
go
-- Actualizacion
create proc updjs 
    @id int , @nb varchar(200) , @ap varchar(200),
    @fn date ,@drc varchar(250) , @nac varchar(200), 
    @cr varchar(200), @tf varchar(200),@medad bit
as
    update JUGADOR set 
        [Nombres]=@nb , [Apellidos]=@ap ,Fecha_nac=@fn, 
        Direccion=@drc  , Nacionalidad=@nac ,Correo= @cr ,
        Telefono= @tf,Menor_edad= @medad
    where Identificacion=@id
go
-- PROCEDIMIENTOS ALMACENADOS DE PAGO DE AMONESTACION
-- Vista
CREATE PROCEDURE SP_VIEW_PAGO_AMONESTACION
AS BEGIN
    SELECT * FROM REGISTRO_AMONESTACION
END
GO
-- Actualizacion
CREATE PROCEDURE SP_UPDATE_PAGO_AMONESTACION
	@Id_Juego INT, @Id_Jugador INT, @Color_Tarjeta VARCHAR(200), 
    @Tiempo VARCHAR(200), @Pagado BIT
AS BEGIN
	UPDATE REGISTRO_AMONESTACION SET 
		Id_Juego = @Id_Juego,Id_Jugador = @Id_Jugador, 
		Color_Tarjeta = @Color_Tarjeta,Tiempo = @Tiempo,
		Pagado = @Pagado
	WHERE Id_Juego = @Id_Juego 
	AND Id_Jugador = @Id_Jugador
	AND Color_Tarjeta = @Color_Tarjeta
	AND Tiempo = @Tiempo
END
GO

-- PROCEDIMIENTOS ALMACENADOS DE PARTIDOS
-- Obtener equipos
create proc getEquipos @id int
as
	select * from TORNEO_EQUIPO
	where Id_Torneo=@id
go
-- Creacion
create proc ingresoJornada  @idT int,@EL int,@Ev int
as 
    insert into PARTIDO
    (
        Id_Torneo,Id_EquipoLocal,Id_EquipoVisita,
        fecha, HoraInicio,HoraFinal,MarcadorLocal,
        MarcadorVisita,jugado
    ) 
    values
    (
        @idT,@EL,@Ev,GETDATE(),GETDATE(),GETDATE(),0,0,0
    )
go
-- Obtener lista de partidos
create proc getListaPartidos @id int
as 
	select  
        p.Id_Juego,p.Id_Torneo,p.Id_EquipoLocal,
        p.Id_EquipoVisita, e.Nombre , e2.Nombre ,
        p.Fecha , p.HoraInicio , p.HoraFinal ,
        p.MarcadorLocal ,p.MarcadorVisita, p.jugado
	from PARTIDO p , EQUIPO e , equipo e2
	where Id_Torneo=@id
	and p.Id_EquipoLocal = e.Id_Equipo
	and p.Id_EquipoVisita= e2.Id_Equipo
go
-- Actualizar
create proc editjornada 
    @id int , @fc datetime , @in datetime , 
    @fn datetime , @gl int , @gv int 
as 
    update PARTIDO set 
        Fecha=@fc , HoraInicio=@in , HoraFinal=@fn , 
        MarcadorLocal=@gl , MarcadorVisita=@gv , jugado=1
	where id_juego=@id;
go
-- Obtener datos
create proc getdata @id int 
as 
    select * from partido where Id_Juego=@id
go
-- Eliminar
create proc dtltarjeta @tar varchar(200)
as 
    delete AMONESTACION where ColorTarjeta=@tar;
go
-- Eliminar goles
create proc dtlgoles @id int 
as 
    delete GOL where Id_Juego=@id;

-- PROCEDIMIENTO ALMACENADO DE CONTROL CANCHA
go
-- Creacion
CREATE PROCEDURE SP_INSERT_CONTROL_CANCHA @Status_ VARCHAR(200), @NoCancha INT, @Id_Juego INT
AS BEGIN
    INSERT INTO ADMINISTRACION_CANCHA (Status_, NoCancha, Id_Juego)
    VALUES (@Status_, @NoCancha, @Id_Juego)
END
GO

-- PROCEDIMIENTOS ALMACENADOS DE POSICION JUGADOR
-- Vista
CREATE PROCEDURE SP_VIEW_POSICION_JUGADOR @Id_Torneo INT, @Id_Equipo INT
AS BEGIN
	SELECT J.* ,
    (
        select s.Nombres + ' '+ s.Apellidos as Nombres 
        from JUGADOR s where s.Identificacion =J.Identificacion
    ) FROM POSICION_JUGADOR J 
    WHERE Id_Torneo = @Id_Torneo 
    AND Id_Equipo = @Id_Equipo
END
GO
-- Creacion
CREATE PROCEDURE SP_INSERT_POSICION_JUGADOR
	@Id_Torneo INT,@Id_Equipo INT,@Identificacion INT, 
	@Posicion VARCHAR(200),@NumeroCamisola INT
AS BEGIN
	INSERT INTO POSICION_JUGADOR 
    ( 
		Id_Torneo,Id_Equipo,Identificacion, 
		Posicion,NumeroCamisola
	)
	VALUES 
    (
		@Id_Torneo,@Id_Equipo,@Identificacion, 
		@Posicion,@NumeroCamisola
	)
END
GO
-- Actualizacion
CREATE PROCEDURE SP_UPDATE_POSICION_JUGADOR
	@Id_Torneo INT,@Id_Equipo INT,@Identificacion INT, 
	@Posicion VARCHAR(200),@NumeroCamisola INT
AS BEGIN
	UPDATE POSICION_JUGADOR SET 
		Id_Torneo = @Id_Torneo,Id_Equipo= @Id_Equipo, 
		Identificacion = @Identificacion,Posicion = @Posicion,
		NumeroCamisola = @NumeroCamisola 
	WHERE Identificacion = @Identificacion 
	AND Id_Torneo = @Id_Torneo
	AND Id_Equipo= @Id_Equipo
END
GO
-- Eliminacion
CREATE PROCEDURE SP_DELETE_POSICION_JUGADOR 
	@Identificacion INT, @Id_Torneo INT,@Id_Equipo INT
AS BEGIN
	DELETE FROM POSICION_JUGADOR 
	WHERE Identificacion = @Identificacion
	AND Id_Torneo = @Id_Torneo
	AND Id_Equipo = @Id_Equipo
END
GO

-- PROCEDIMIENTOS ALMACENADOS DE PUNTEOS
-- Creacion
create proc insertpuntos 
    @id int , @el int , @ev int , @pl int , 
    @pv int  , @gl int ,@gv int
as 
    insert into PUNTEO 
    (
        [Id_Juego],[Id_EquipoLocal],[Id_EquipoVisita],
        [PunteoEquipoLocal],[PunteoEquipoVisita],
        [Golesvisita],[Goleslocal]
    ) 
    values 
    (
        @id  , @el  , @ev  , @pl  , @pv   , @gl  ,@gv
    )
go

-- PROCEDIMIENTOS ALMACENADO PARA CBX DEL REPORTE DE CANCHAS
-- Obtener cancha
create proc getCancha
as
    select * from CANCHA
go
-- Obtener torneos
create proc getToneo_reporte
as
    select * from TORNEO
go

-- PROCEDIMIENTOS ALMACENADOS DE REPORTES DE TABLA GENERAL
-- Tabla general
create proc tablageneral  @tr int
as  
    select (select e.Nombre from EQUIPO e where pr.Id_EquipoLocal=e.Id_Equipo) as Nombres   , count(p.Id_EquipoLocal)+ (
    select   count(p2.Id_EquipoVisita)   from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
    where pr2.Id_Torneo=@tr
    and pr2.Id_EquipoVisita=pr.Id_EquipoLocal
    group by  pr2.Id_EquipoVisita) as PJ, 
    case when  (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal > p2.Golesvisita  group by p2.Id_EquipoLocal) is null
    then 0   else (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal > p2.Golesvisita  group by p2.Id_EquipoLocal) end  
    +case when  (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoVisita=pr.Id_EquipoLocal and p2.Goleslocal < p2.Golesvisita  group by p2.Id_EquipoVisita) is null
    then 0   else (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoVisita=pr.Id_EquipoLocal and p2.Goleslocal < p2.Golesvisita  group by p2.Id_EquipoVisita) end as PG,
    case when  (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal < p2.Golesvisita  group by p2.Id_EquipoLocal) is null
    then 0   else (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal < p2.Golesvisita  group by p2.Id_EquipoLocal) end  
    +case when  (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoVisita=pr.Id_EquipoLocal and p2.Goleslocal > p2.Golesvisita  group by p2.Id_EquipoVisita) is null
    then 0   else (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoVisita=pr.Id_EquipoLocal and p2.Goleslocal > p2.Golesvisita  group by p2.Id_EquipoVisita) end as PP,
    case when  (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal = p2.Golesvisita  group by p2.Id_EquipoLocal) is null
    then 0   else (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal = p2.Golesvisita  group by p2.Id_EquipoLocal) end  
    +case when  (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoVisita=pr.Id_EquipoLocal and p2.Goleslocal = p2.Golesvisita  group by p2.Id_EquipoVisita) is null
    then 0   else (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoVisita=pr.Id_EquipoLocal and p2.Goleslocal = p2.Golesvisita  group by p2.Id_EquipoVisita) end as PE
    , case when sum(p.Goleslocal) is null then 0  else sum(p.Goleslocal) end + (
    select  case when  sum(p2.Golesvisita) is null then 0 else  sum(p2.Golesvisita) end  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
    where pr2.Id_Torneo=@tr and pr2.Id_EquipoVisita=pr.Id_EquipoLocal group by  pr2.Id_EquipoVisita )  as GF ,
    case when sum(p.Golesvisita) is null then 0  else sum(p.Golesvisita) end + (
    select  case when  sum(p2.Goleslocal) is null then 0 else  sum(p2.Goleslocal) end  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
    where pr2.Id_Torneo=@tr and pr2.Id_EquipoVisita=pr.Id_EquipoLocal group by  pr2.Id_EquipoVisita )  as GC,
    case when sum(p.Goleslocal) is null then 0  else sum(p.Goleslocal) end + (
    select  case when  sum(p2.Golesvisita) is null then 0 else  sum(p2.Golesvisita) end  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
    where pr2.Id_Torneo=@tr and pr2.Id_EquipoVisita=pr.Id_EquipoLocal group by  pr2.Id_EquipoVisita
    )  - ( case when sum(p.Golesvisita) is null then 0  else sum(p.Golesvisita) end + (
    select  case when  sum(p2.Goleslocal) is null then 0 else  sum(p2.Goleslocal) end  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
    where pr2.Id_Torneo=@tr and pr2.Id_EquipoVisita=pr.Id_EquipoLocal group by  pr2.Id_EquipoVisita) )as DF,
    case when sum(p.PunteoEquipoLocal) is null then 0  else sum(p.PunteoEquipoLocal) end + (
    select  case when  sum(p2.PunteoEquipoVisita) is null then 0 else  sum(p2.PunteoEquipoVisita) end  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
    where pr2.Id_Torneo=@tr and pr2.Id_EquipoVisita=pr.Id_EquipoLocal group by  pr2.Id_EquipoVisita)  as PTS
    from PUNTEO p right join PARTIDO pr on  p.Id_Juego= pr.Id_Juego where pr.Id_Torneo=@tr
    group by  pr.Id_EquipoLocal order by PTS desc
GO
-- Tabla Visita
create proc tablavisitante @id int
as
    select (select e.Nombre from EQUIPO e where pr.Id_EquipoVisita=e.Id_Equipo) as Nombres   ,  count(p.Id_EquipoVisita)  as PJ , 
    case when  (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.Goleslocal < p2.Golesvisita  group by p2.Id_EquipoVisita) is null
    then 0   else (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.Goleslocal < p2.Golesvisita  group by p2.Id_EquipoVisita) end as PG
    ,case when  (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.Goleslocal > p2.Golesvisita  group by p2.Id_EquipoVisita) is null
    then 0   else (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.Goleslocal > p2.Golesvisita  group by p2.Id_EquipoVisita) end as PP
    ,case when  (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.Goleslocal = p2.Golesvisita  group by p2.Id_EquipoVisita) is null
    then 0   else (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.Goleslocal = p2.Golesvisita  group by p2.Id_EquipoVisita) end as PE  ,
    sum(pr.MarcadorVisita) as GF  ,  sum(pr.MarcadorLocal) as GC , sum(pr.MarcadorVisita)- sum(pr.MarcadorLocal) as DG , case  when sum(p.PunteoEquipoVisita) is null then 0 else sum(p.PunteoEquipoVisita) end as PTS from PUNTEO p right join PARTIDO pr on  p.Id_Juego= pr.Id_Juego
    where pr.Id_Torneo=@id group by  pr.Id_EquipoVisita order by PTS desc
go
-- Tabla Local
create proc tablalocal @id int
as
    select (select e.Nombre from EQUIPO e where pr.Id_EquipoLocal=e.Id_Equipo) as Nombres  ,  count(p.Id_EquipoLocal)  as PJ ,
    case when  (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal > p2.Golesvisita  group by p2.Id_EquipoLocal) is null
    then 0   else (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal > p2.Golesvisita  group by p2.Id_EquipoLocal) end as PG
    ,case when  (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal < p2.Golesvisita  group by p2.Id_EquipoLocal) is null
    then 0   else (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal < p2.Golesvisita  group by p2.Id_EquipoLocal) end as PP
    ,case when  (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal = p2.Golesvisita  group by p2.Id_EquipoLocal) is null
    then 0   else (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal = p2.Golesvisita  group by p2.Id_EquipoLocal) end as PE, sum(pr.MarcadorLocal) as GF  
    ,  sum(pr.MarcadorVisita) as GC , sum(pr.MarcadorLocal)-sum(pr.MarcadorVisita) as DG , case  when sum(p.PunteoEquipoLocal) is null then 0  else sum(p.PunteoEquipoLocal) end as PTS from PUNTEO p right join PARTIDO pr on  p.Id_Juego= pr.Id_Juego
    where pr.Id_Torneo=@id group by  pr.Id_EquipoLocal order by PTS desc;
go

-- PROCEDIMIENTOS ALMACENADOS DE AMONESTACIONES
-- Creacion
create proc Tarjetas 
    @tar varchar(200), @multa varchar(200), @com varchar(200)
as 
    insert into AMONESTACION 
    (ColorTarjeta,Valor_multa,Comentario) 
    values 
    (@tar,@multa,@com)
go
-- Actualizacion
create proc editarjeta  
    @tar varchar(200), @multa varchar(200), 
    @com varchar(200)
as 
    update AMONESTACION set 
        Valor_multa=@multa , Comentario=@com 
    where ColorTarjeta=@tar
go
-- Eliminacion
create proc dtltarjeta 
    @tar varchar(200)
as 
    delete AMONESTACION where ColorTarjeta=@tar;
go
-- Ver tarjetas
create proc vertarjetas 
as 
    select * from AMONESTACION
go
-- Ver tarjeta por id
create proc vertarjeta @tar varchar(200)
 as select * from AMONESTACION where ColorTarjeta = @tar
GO

-- PROCEDIMIENTOS ALMACENADOS DE TORNEO
-- Ver torneos con id
create proc getidtorneo @id int
as 
    select * from torneo where [Id_Torneo]=@id
go
-- Ver torneos
create proc vertorneos
as
    select * from torneo
go
-- Creacion
create proc instorneo 
    @name varchar(200),@inicio date,@final date ,
    @tp varchar(200),@edmn int,@edmx int,@pga int,
    @ppe int,@pemp int,@campo int,@precio float 
as 
    INSERT INTO [TORNEO] 
    (
        [Nombre],[FechaInicio] ,[FechaFinal],[Tipo] ,
        [edadminima],[edadmaxima] ,[p_ganado],[pperdido] ,
        [pempatado],[NumeroMaximoDeJugadores],[precio_Torneo]
    )
    VALUES 
    (
        @name,@inicio,@final,@tp,@edmn,@edmx,
        @pga,@ppe,@pemp,@campo,@precio
    )
go
-- Actualizacion

create proc updtorneo 
    @id int , @name varchar(200),@inicio date,@final date ,
    @tp varchar(200),@edmn int,@edmx int,@pga int,@ppe int,
    @pemp int,@campo int
as  update  Torneo set
        [Nombre]=@name,[FechaInicio]=@inicio ,[FechaFinal]=@final,
        [Tipo]=@tp ,[edadminima]=@edmn,[edadmaxima]=@edmx ,
        [p_ganado]=@pga,[pperdido]=@ppe ,[pempatado]=@pemp,
        [NumeroMaximoDeJugadores]=@campo
    where  id_Torneo=@id

	--exec updtorneo @id,@name,@inicio,@final,@tp,@edmn,@edmx,@pga,@ppe,@pemp,@campo

	select*from TORNEO
go
-- Eliminacion
create proc dtltorneo @id int 
as 
    delete from TORNEO where Id_Torneo=@id;
go
-- 
create proc newidt
as 
    select case when count(*)> 0 then max(id_torneo) else 0 
    end as id_torneo  from torneo
go

-- REPORTE CANCHA-HORA
create proc cancha_hora @dateInicio datetime,@dateFin datetime
as
    select 
        c.Nombre as cancha,t.Nombre as Torneo, 
        sum(datediff(hh,p.HoraInicio,p.HoraFinal)) as horas 
    from ADMINISTRACION_CANCHA  aac,CANCHA c,partido p,torneo t 
    where aac.NoCancha=c.NoCancha 
    and aac.Id_Juego=p.Id_Juego 
    and p.Id_Torneo=t.Id_Torneo 
    and p.Fecha between @dateInicio and @dateFin
    group by c.Nombre, t.Nombre
go

-- REPORTE CANCHA-NOMBRE
create proc cancha_nombre 
    @nombre_cancha varchar(200), @dateInicio datetime,
    @dateFin datetime
as
    select 
        c.Nombre as cancha,t.Nombre as Torneo, 
        sum(datediff(hh,p.HoraInicio,p.HoraFinal)) as horas 
    from ADMINISTRACION_CANCHA  aac,CANCHA c,partido p,torneo t 
    where aac.NoCancha=c.NoCancha and aac.Id_Juego=p.Id_Juego 
    and p.Id_Torneo=t.Id_Torneo 
    and p.Fecha between @dateInicio and @dateFin 
    and c.Nombre=@nombre_cancha
    group by c.Nombre, t.Nombre
go

-- REPORTE CANCHA-TORNEO
create proc cancha_Torneo @nombre_torneo varchar(200)
as
    select 
        c.Nombre as cancha,t.Nombre as Torneo, 
        sum(datediff(hh,p.HoraInicio,p.HoraFinal)) as horas 
    from ADMINISTRACION_CANCHA  aac,CANCHA c,partido p,torneo t 
    where aac.NoCancha=c.NoCancha and aac.Id_Juego=p.Id_Juego 
    and p.Id_Torneo=t.Id_Torneo  and t.Nombre=@nombre_torneo
    group by c.Nombre, t.Nombre
go

-- REPORTE CANCHA-NOMBRE-FECHA
create proc cancha_nombre_fecha 
    @nombre_cancha varchar(200), @dateInicio datetime,
    @dateFin datetime
as
    select 
        c.Nombre as cancha,t.Nombre as Torneo, 
        sum(datediff(hh,p.HoraInicio,p.HoraFinal)) as horas 
    from ADMINISTRACION_CANCHA  aac,CANCHA c,partido p,torneo t 
    where aac.NoCancha=c.NoCancha and aac.Id_Juego=p.Id_Juego 
    and p.Id_Torneo=t.Id_Torneo 
    and  p.Fecha between @dateInicio and @dateFin 
    and c.Nombre=@nombre_cancha
    group by c.Nombre, t.Nombre
go

-- REPORTE cancha_Torneo_fecha
create proc cancha_Torneo_fecha 
    @nombre_torneo varchar(200), @dateInicio datetime,
    @dateFin datetime
as
    select c.Nombre as cancha,t.Nombre as Torneo, 
    sum(datediff(hh,p.HoraInicio,p.HoraFinal)) as horas 
    from ADMINISTRACION_CANCHA  aac,CANCHA c,partido p,torneo t 
    where aac.NoCancha=c.NoCancha and aac.Id_Juego=p.Id_Juego 
    and p.Id_Torneo=t.Id_Torneo 
    and  p.Fecha between @dateInicio and @dateFin 
    and t.Nombre=@nombre_torneo
    group by c.Nombre, t.Nombre
go

-- REPORTE cancha_completo
create proc cancha_completo
    @nombre_cancha varchar(200), @nombre_torneo varchar(200), 
    @dateInicio datetime,@dateFin datetime
as
    select c.Nombre as cancha,t.Nombre as Torneo,
        sum(datediff(hh,p.HoraInicio,p.HoraFinal)) as horas
    from ADMINISTRACION_CANCHA  aac,CANCHA c,partido p,torneo t 
    where aac.NoCancha=c.NoCancha and aac.Id_Juego=p.Id_Juego 
    and p.Id_Torneo=t.Id_Torneo 
    and  p.Fecha between @dateInicio and @dateFin 
    and c.Nombre=@nombre_cancha and t.Nombre=@nombre_torneo
    group by c.Nombre, t.Nombre
go

-- REPORTE estadisticasportorneoyqueipo
create proc estadisticasportorneoyqueipo @tr int , @name varchar(200)
as 
    select pr.Id_Torneo,pos.POS,
        (
            select e.Nombre 
            from EQUIPO e 
            where e.Id_Equipo=pr.Id_EquipoVisita
        ) as Nombres 
        from PUNTEO p right join PARTIDO pr 
        on p.Id_Juego= pr.Id_Juego join 
        (
            select  pr.Id_Torneo, pr.Id_EquipoLocal, ROW_NUMBER() over(PARTITION by pr.Id_Torneo order by sum(p.PunteoEquipoLocal)+valor.pts_visita desc ) as POS 
            from PUNTEO p right join PARTIDO pr on  p.Id_Juego= pr.Id_Juego join (select pr2.Id_EquipoVisita,   case when  sum(p2.PunteoEquipoVisita) is null then 0 else  sum(p2.PunteoEquipoVisita) end as pts_visita  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
            where pr2.Id_Torneo= @tr
            group by  pr2.Id_EquipoVisita
        ) as valor 
            on  valor.Id_EquipoVisita = pr.Id_EquipoLocal
            where pr.Id_Torneo=  @tr
            group by  pr.Id_EquipoLocal , pr.Id_Torneo, valor.pts_visita
        )  as pos 
        on pos.Id_EquipoLocal=pr.Id_EquipoVisita
        where pr.Id_Torneo = @tr
        and pr.Id_EquipoVisita = 
    (
        select Id_Equipo from EQUIPO where Nombre=@name)
        and pos.Id_Torneo=pr.Id_Torneo
    group by pr.Id_EquipoVisita,pr.Id_Torneo,pos.POS
go

-- REPORTE estadisticaporquipo
create proc estadisticaporquipo @name varchar(200)
as 
    select pr.Id_Torneo,pos.POS,(select e.Nombre from EQUIPO e where e.Id_Equipo=pr.Id_EquipoVisita) as Nombres   from PUNTEO p right join PARTIDO pr on  p.Id_Juego= pr.Id_Juego join 
    (
        select  pr.Id_Torneo, pr.Id_EquipoLocal, ROW_NUMBER() over(PARTITION by pr.Id_Torneo order by sum(p.PunteoEquipoLocal)+valor.pts_visita desc ) as POS  
        from PUNTEO p right join PARTIDO pr on  p.Id_Juego= pr.Id_Juego join (select pr2.Id_EquipoVisita,   case when  sum(p2.PunteoEquipoVisita) is null then 0 else  sum(p2.PunteoEquipoVisita) end as pts_visita  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
        where pr2.Id_Torneo=any(select  tq.Id_Torneo from EQUIPO e join TORNEO_EQUIPO tq on  e.Id_Equipo=tq.Id_Equipo
        where e.Nombre= @name
    )
    group by  pr2.Id_EquipoVisita
    ) as valor on  valor.Id_EquipoVisita = pr.Id_EquipoLocal
    where pr.Id_Torneo= any(
        select  tq.Id_Torneo 
        from EQUIPO e join TORNEO_EQUIPO tq 
        on  e.Id_Equipo=tq.Id_Equipo
        where e.Nombre= @name
    )
    group by  pr.Id_EquipoLocal , pr.Id_Torneo, valor.pts_visita
    )  as pos 
    on pos.Id_EquipoLocal=pr.Id_EquipoVisita
    where pr.Id_Torneo in (
        select  tq.Id_Torneo from EQUIPO e join TORNEO_EQUIPO tq on  e.Id_Equipo=tq.Id_Equipo
        where e.Nombre= @name
    )
    and pr.Id_EquipoVisita = (select Id_Equipo from EQUIPO where Nombre=@name)
    and pos.Id_Torneo=pr.Id_Torneo
    group by pr.Id_EquipoVisita,pr.Id_Torneo,pos.POS
go

-- REPORTE estadisticasportorneo
create proc estadisticasportorneo @tr int 
as 
    select ROW_NUMBER() over(
        PARTITION by pr.Id_Torneo 
        order by sum(p.PunteoEquipoLocal)+valor.pts_visita desc 
    ) as POS ,(
        select e.Nombre from EQUIPO e 
        where e.Id_Equipo=pr.Id_EquipoLocal
    ) as Nombres
    from PUNTEO p right join PARTIDO pr 
    on  p.Id_Juego= pr.Id_Juego join (
        select pr2.Id_EquipoVisita, 
        case when  sum(p2.PunteoEquipoVisita) is null 
        then 0 else  sum(p2.PunteoEquipoVisita) end as pts_visita 
        from PUNTEO p2 right join PARTIDO pr2 
        on  p2.Id_Juego= pr2.Id_Juego
    where pr2.Id_Torneo= @tr
    group by  pr2.Id_EquipoVisita
    ) as valor on  valor.Id_EquipoVisita = pr.Id_EquipoLocal
    where pr.Id_Torneo=  @tr
    group by  pr.Id_EquipoLocal ,pr.Id_Torneo, valor.pts_visita
go

-- REPORTE-PARTIDOS-AFECTADOS
create PROCEDURE SP_VIEW_REPORTE_PARTIDOS_AFECTADOS @Capacidad INT
AS BEGIN
    SELECT P.Id_Torneo,
        P.Id_Juego,  
        P.Id_EquipoLocal, 
        P.Id_EquipoVisita, 
        P.Fecha,
        p.HoraInicio,
        P.HoraFinal,
        P.jugado
    FROM TORNEO T INNER JOIN PARTIDO P 
    ON T.Id_Torneo = P.Id_Torneo
    INNER JOIN ADMINISTRACION_CANCHA AC
    ON NOT P.Id_Juego = AC.Id_Juego
    INNER JOIN CANCHA C
    ON AC.NoCancha = C.NoCancha
    WHERE T.NumeroMaximoDeJugadores = @Capacidad
	and p.jugado=0
    ORDER BY Id_Torneo;
END
GO

-- REPORTE_PLANILLA_ARBITROS
CREATE PROC SP_REPORTE_PLANILLA_ARBITROS 
    @FECHA_INICIAL DATE, @FECHA_FINAL DATE 
AS BEGIN
	SELECT T.Nombre Torneo_Nombre,
		A.Nombre Arbitro_Nombre, 
		A.Apellidos Arbitro_Apellido, 
		A.Nacionalidad Arbitro_Nacionalidad, 
		A.Telefono Arbitro_Telefono, 
		SUM(CONVERT(FLOAT,AP.Pago)) Total_Recibido
	FROM ARBITRO A, 
		ARBITRO_PARTIDO AP, 
		PARTIDO P, 
		TORNEO T 
	WHERE A.DPI = AP.DPI_ARBITRO 
	AND AP.ID_JUEGO = P.ID_JUEGO 
	AND P.ID_TORNEO = T.ID_TORNEO
	AND P.FECHA BETWEEN @FECHA_INICIAL AND @FECHA_FINAL
	GROUP BY A.NOMBRE, 
		A.APELLIDOS, 
		A.NACIONALIDAD, 
		A.TELEFONO, 
		T.NOMBRE
END
go
-- TarjetasporTorneo
create proc TarjetasporTorneo @id int 
as
    select    (select e.Nombre  from EQUIPO e where e.Id_Equipo=tr.Id_Equipo ) as Equipo , case when  ( select     count(rg.Color_Tarjeta) as Rojas   from REGISTRO_AMONESTACION rg , PARTIDO pr
    where rg.Id_Juego=pr.Id_Juego
    and pr.Id_Torneo=@id
    and rg.Color_Tarjeta='Roja'
    and pr.Id_EquipoLocal=tr.Id_Equipo
    group by pr.Id_EquipoLocal) is null  then 0   
    else 
    ( select     count(rg.Color_Tarjeta) as Rojas   from REGISTRO_AMONESTACION rg , PARTIDO pr
    where rg.Id_Juego=pr.Id_Juego
    and pr.Id_Torneo=@id
    and rg.Color_Tarjeta='Roja'
    and pr.Id_EquipoLocal=tr.Id_Equipo
    group by pr.Id_EquipoLocal) 
    end as Rojas , 
    case when  ( select     count(rg.Color_Tarjeta) as Rojas   from REGISTRO_AMONESTACION rg , PARTIDO pr
    where rg.Id_Juego=pr.Id_Juego
    and pr.Id_Torneo=@id
    and rg.Color_Tarjeta='Amarilla'
    and pr.Id_EquipoLocal=tr.Id_Equipo
    group by pr.Id_EquipoLocal) is null  then 0   
    else 
    ( select     count(rg.Color_Tarjeta) as Rojas   from REGISTRO_AMONESTACION rg , PARTIDO pr
    where rg.Id_Juego=pr.Id_Juego
    and pr.Id_Torneo=@id
    and rg.Color_Tarjeta='Amarilla'
    and pr.Id_EquipoLocal=tr.Id_Equipo
    group by pr.Id_EquipoLocal) 
    end as Amarillas

    from TORNEO_EQUIPO tr 
    where tr.Id_Torneo = @id
go

/** Object:  StoredProcedure [dbo].[TarjetasporTorneo]    Script Date: 4/05/2021 11:23:47 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER proc [dbo].[TarjetasporTorneo] @id int , @color varchar(200) 
as
    select  (select e.Nombre  from EQUIPO e where e.Id_Equipo=tr.Id_Equipo ) as Equipo  , case when sum(rd.x) is null then 0 else sum(rd.x) end  as Roja 
    
    from TORNEO_EQUIPO tr  left join (select  count(rg.Color_Tarjeta)as x ,  trr.Id_Equipo from REGISTRO_AMONESTACION rg , PARTIDO pr, TORNEO_EQUIPO trr
    where rg.Id_Juego=pr.Id_Juego
    and pr.Id_Torneo=@id
    and trr.Id_Torneo = @id
    and rg.Color_Tarjeta=@color
    and rg.Id_Jugador in ( 
        select j.Identificacion from POSICION_JUGADOR j 
        where trr.Id_Equipo=j.Id_Equipo  and  j.Id_Torneo=@id 
    ) 
    group by rg.Id_Juego,rg.Id_Jugador,rg.Color_Tarjeta , trr.Id_Equipo ) as rd  
    on tr.Id_Equipo = rd.Id_Equipo
    where tr.Id_Torneo = @id
    group by tr.Id_Equipo
go

