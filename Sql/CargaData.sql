use BdCoinsa
--==========================================
--CARGA PERFILES USUARIO
--==========================================
--select * from Usuarios.TblPerfiles
exec Usuarios.SpCreaPerfilUsuario @Perfil='Sistemas'
exec Usuarios.SpCreaPerfilUsuario @Perfil='Administrador'
exec Usuarios.SpCreaPerfilUsuario @Perfil='Gerencia'
exec Usuarios.SpCreaPerfilUsuario @Perfil='Analista'
exec Usuarios.SpCreaPerfilUsuario @Perfil='Mesa de Ayuda'
exec Usuarios.SpCreaPerfilUsuario @Perfil='Auxiliar Administrativo'
exec Usuarios.SpCreaPerfilUsuario @Perfil='Promotor'

--==========================================
--CARGA SUCURSAL PRUEBA
--==========================================
--select * from Catalagos.TblSucursales
exec Catalagos.SpCreaSucursal
@NumSucursal		='001'
,@NombreSucursal	='Matríz'
,@DireccionSucursal	='Cumbres, Monterrey N.L.'

--==========================================
--CARGA USUARIOS 
--==========================================
--select * from Usuarios.TblUsuarios
exec Usuarios.SpCreaUsuario
@PrimerNombre	='José'
,@SegundoNombre	='Luis'
,@ApPaterno		='Rivera'
,@ApMaterno		='Cerezo'
,@Us			='joseluis.rivera'
,@Psw			='lriver'
,@Perfil		=1
,@CorreoElectronico='joseluis.rivera@fcoinsa.com.mx'	
,@SucursalId=1
