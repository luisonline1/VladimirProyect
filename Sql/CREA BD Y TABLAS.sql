/*
--===========================================
--CREA BASE DE DATOS
--===========================================
CREATE DATABASE BdCoinsa
go
USE BdCoinsa

--===========================================
--CREA ESQUEMAS
--===========================================
--USUARIOS
if object_id('Usuarios') is not null
	drop schema Usuarios
go
create schema Usuarios
go

--CATALAGOS
if object_id('Catalagos') is not null
	drop schema Catalagos
go
create schema Catalagos
go

*/
--===========================================
--CREA TABLAS
--===========================================
--USUARIOS
if object_id('Usuarios.TblUsuarios') is not null
	drop table Usuarios.TblUsuarios
go
CREATE TABLE Usuarios.TblUsuarios
(
	IdUsuario			int identity(1,1)
	,PriNombre			varchar(15)
	,SegNombre			varchar(15)
	,ApePaterno			varchar(15)
	,ApeMaterno			varchar(15)
	,Usuario			varchar(20) unique
	,Contraseña			varbinary(8000) 
	,SucursalId			int
	,CorreoElectronico	varchar(50)
	,Token				varchar(100)
	,FecAlta			datetime default getdate()
	,PerfilUsuarioId	Int
	,Intento			int default 0
	,FecUltimoIntento	datetime
	,Bloqueado			bit
	,Activo				bit
	Primary key			(IdUsuario)
)
Go

--USUARIOS2 ESTA TABLA NO TIENE EL PSSW ENCRITPADO
if object_id('Usuarios.TblUsuarios2') is not null
	drop table Usuarios.TblUsuarios2
go
CREATE TABLE Usuarios.TblUsuarios2
(
	IdUsuario			int identity(1,1)
	,PriNombre			varchar(15)
	,SegNombre			varchar(15)
	,ApePaterno			varchar(15)
	,ApeMaterno			varchar(15)
	,Usuario			varchar(20) unique
	,Contraseña			varchar(20) 
	,SucursalId			int
	,CorreoElectronico	varchar(50)
	,Token				varchar(100)
	,FecAlta			datetime default getdate()
	,PerfilUsuarioId	Int
	,Intento			int default 0
	,FecUltimoIntento	datetime
	,Bloqueado			bit
	,Activo				bit
	Primary key			(IdUsuario)
)
Go

--PERFILES DE USUARIOS
if object_id('Usuarios.TblPerfiles') is not null
	drop table Usuarios.TblPerfiles
go
CREATE TABLE Usuarios.TblPerfiles
(
	IdPerfil		int identity(1,1)
	,Perfil			varchar(30)
	,FecAlta		datetime default getdate()
	Primary key		(IdPerfil)
)
Go

--SUCURSALES
if object_id('Catalagos.TblSucursales') is not null
	drop table Catalagos.TblSucursales
go
CREATE TABLE Catalagos.TblSucursales
(
	IdSucursal			int identity(1,1),
	NumSucursal			varchar(10) NULL,
	NombreSucursal		varchar(40) NULL,
	DireccionSucursal	varchar(100) NULL,
	Primary key			(IdSucursal)
)
GO

ALTER TABLE [Usuarios].[TblUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_TblUsuarios_TblPerfiles] FOREIGN KEY([PerfilUsuarioId])
REFERENCES [Usuarios].[TblPerfiles] ([IdPerfil])
GO
ALTER TABLE [Usuarios].[TblUsuarios] CHECK CONSTRAINT [FK_TblUsuarios_TblPerfiles]
GO

ALTER TABLE [Usuarios].[TblUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_TblUsuarios_TblSucursales] FOREIGN KEY([SucursalId])
REFERENCES [Catalagos].[TblSucursales] ([IdSucursal])
GO
ALTER TABLE [Usuarios].[TblUsuarios] CHECK CONSTRAINT [FK_TblUsuarios_TblSucursales]
GO