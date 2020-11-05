select * from Usuarios.TblUsuarios
--==========================================
--LOGIN
--==========================================
--sp_helptext [Usuarios.SpLogin] 
--Usuarios.SpLogin @Usuario='joseluis.rivera', @Contraseña='lriver', @Token='cdvdfkfdkdgjfdklfdlfdkl'
if object_id('Usuarios.SpLogin') is not null
	drop proc Usuarios.SpLogin
GO
create Proc Usuarios.SpLogin
@Usuario		varchar(50)=null
,@Contraseña	varchar(20)=null
,@Token			varchar(100)
AS
	declare
		@IdUsuario		int				=0
		,@Intento		int				=4
		,@Activo		int				=0
		,@Bloqueado		int				=1
		,@Psw			varchar(20)		=null

	select
		@IdUsuario		=IdUsuario
		,@Intento		=Intento
		,@Activo		=Activo
		,@Bloqueado		=Bloqueado
		,@Psw			=convert(varchar(20),DECRYPTBYPASSPHRASE('COINSA SERV', Contraseña))
	from 
		Usuarios.TblUsuarios 
	where 
		Usuario=@Usuario or CorreoElectronico=@Usuario 
	--select * from Usuarios.TblUsuarios where idusuario=2

	if @IdUsuario=0 or @Bloqueado=1 or @Activo=0
	begin
		select 
			0					[Exito] 
			,'Datos erroneos'	[Respuesta]

		return
	end

	if @Contraseña= @Psw begin
		update Usuarios.TblUsuarios set Intento=0, Token=@Token where IdUsuario=@IdUsuario
		select 
			1		[Exito]
			,@Token [Respuesta]
	end else begin
		if @Intento+1=3 begin
			update Usuarios.TblUsuarios set FecUltimoIntento=GETDATE(), Intento=3, Bloqueado=1, Token=null where IdUsuario=@IdUsuario
			Select 
				0 [Exito] 
				,'Ha intentado ingresar 3 veces con una contraseña incorrecta, el usuario se bloqueará por su seguridad. Favor de contactar al administrador.' [Respuesta]
		end else begin
			update Usuarios.TblUsuarios set FecUltimoIntento=GETDATE(), Intento=Intento+1, Token=null where IdUsuario=@IdUsuario
			Select 
				0 [Exito] 
				,'Contraseña incorrecta.' [Respuesta]
		end
	end
