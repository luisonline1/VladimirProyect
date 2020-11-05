use BdCoinsa
--==========================================
--SP CREA PERFIL
--==========================================
if object_id('Usuarios.SpCreaPerfilUsuario') is not null
	drop proc Usuarios.SpCreaPerfilUsuario
GO
create Proc Usuarios.SpCreaPerfilUsuario
@Perfil		varchar(30)
as
		
	if not exists(select 1 from Usuarios.TblPerfiles where Perfil=@Perfil)
		insert into Usuarios.TblPerfiles
			(Perfil)
		values
			(@Perfil)
GO

--==========================================
--SP CREA SUCURSAL
--==========================================
--select * from Catalagos.TblSucursales
if object_id('Catalagos.SpCreaSucursal') is not null
	drop proc Catalagos.SpCreaSucursal
GO
create proc Catalagos.SpCreaSucursal
@NumSucursal		varchar(10)
,@NombreSucursal	varchar(40)
,@DireccionSucursal	varchar(100)
as
insert into Catalagos.TblSucursales
(NumSucursal	,NombreSucursal		,DireccionSucursal)
values
(@NumSucursal	,@NombreSucursal	,@DireccionSucursal)
GO

--==========================================
--SP CREA USER
--==========================================
if object_id('Usuarios.SpCreaUsuario') is not null
	drop proc Usuarios.SpCreaUsuario
GO
create Proc Usuarios.SpCreaUsuario
@PrimerNombre		varchar(15)
,@SegundoNombre		varchar(15)
,@ApPaterno			varchar(15)
,@ApMaterno			varchar(15)
,@Us				varchar(50)
,@Psw				varchar(20)
,@Perfil			Int
,@CorreoElectronico	varchar(50)
,@SucursalId		int

as
	if not exists(select 1 from Usuarios.TblUsuarios where Usuario=@Us)
		insert into Usuarios.TblUsuarios
			(PriNombre,		SegNombre,		ApePaterno,		ApeMaterno,		Usuario,	Contraseña,								PerfilUsuarioId,	Bloqueado,	Activo, CorreoElectronico	,SucursalId)
		values
			(@PrimerNombre,	@Segundonombre,	@ApPaterno,		@ApMaterno,		@Us,		ENCRYPTBYPASSPHRASE('COINSA SERV', @Psw),	@Perfil,			0,			1,		@CorreoElectronico	,@SucursalId)
GO
