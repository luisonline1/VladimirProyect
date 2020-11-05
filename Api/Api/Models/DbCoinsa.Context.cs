﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BdCoinsaContext : DbContext
    {
        public BdCoinsaContext()
            : base("name=BdCoinsaContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TblSucursales> TblSucursales { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TblPerfiles> TblPerfiles { get; set; }
        public virtual DbSet<TblUsuarios> TblUsuarios { get; set; }
    
        public virtual int SpCreaSucursal(string numSucursal, string nombreSucursal, string direccionSucursal)
        {
            var numSucursalParameter = numSucursal != null ?
                new ObjectParameter("NumSucursal", numSucursal) :
                new ObjectParameter("NumSucursal", typeof(string));
    
            var nombreSucursalParameter = nombreSucursal != null ?
                new ObjectParameter("NombreSucursal", nombreSucursal) :
                new ObjectParameter("NombreSucursal", typeof(string));
    
            var direccionSucursalParameter = direccionSucursal != null ?
                new ObjectParameter("DireccionSucursal", direccionSucursal) :
                new ObjectParameter("DireccionSucursal", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SpCreaSucursal", numSucursalParameter, nombreSucursalParameter, direccionSucursalParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int SpCreaPerfilUsuario(string perfil)
        {
            var perfilParameter = perfil != null ?
                new ObjectParameter("Perfil", perfil) :
                new ObjectParameter("Perfil", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SpCreaPerfilUsuario", perfilParameter);
        }
    
        public virtual int SpCreaUsuario(string primerNombre, string segundoNombre, string apPaterno, string apMaterno, string us, string psw, Nullable<int> perfil, string correoElectronico, Nullable<int> sucursalId)
        {
            var primerNombreParameter = primerNombre != null ?
                new ObjectParameter("PrimerNombre", primerNombre) :
                new ObjectParameter("PrimerNombre", typeof(string));
    
            var segundoNombreParameter = segundoNombre != null ?
                new ObjectParameter("SegundoNombre", segundoNombre) :
                new ObjectParameter("SegundoNombre", typeof(string));
    
            var apPaternoParameter = apPaterno != null ?
                new ObjectParameter("ApPaterno", apPaterno) :
                new ObjectParameter("ApPaterno", typeof(string));
    
            var apMaternoParameter = apMaterno != null ?
                new ObjectParameter("ApMaterno", apMaterno) :
                new ObjectParameter("ApMaterno", typeof(string));
    
            var usParameter = us != null ?
                new ObjectParameter("Us", us) :
                new ObjectParameter("Us", typeof(string));
    
            var pswParameter = psw != null ?
                new ObjectParameter("Psw", psw) :
                new ObjectParameter("Psw", typeof(string));
    
            var perfilParameter = perfil.HasValue ?
                new ObjectParameter("Perfil", perfil) :
                new ObjectParameter("Perfil", typeof(int));
    
            var correoElectronicoParameter = correoElectronico != null ?
                new ObjectParameter("CorreoElectronico", correoElectronico) :
                new ObjectParameter("CorreoElectronico", typeof(string));
    
            var sucursalIdParameter = sucursalId.HasValue ?
                new ObjectParameter("SucursalId", sucursalId) :
                new ObjectParameter("SucursalId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SpCreaUsuario", primerNombreParameter, segundoNombreParameter, apPaternoParameter, apMaternoParameter, usParameter, pswParameter, perfilParameter, correoElectronicoParameter, sucursalIdParameter);
        }
    
        public virtual ObjectResult<string> SpLogin(string usuario, string contraseña, string token)
        {
            var usuarioParameter = usuario != null ?
                new ObjectParameter("Usuario", usuario) :
                new ObjectParameter("Usuario", typeof(string));
    
            var contraseñaParameter = contraseña != null ?
                new ObjectParameter("Contraseña", contraseña) :
                new ObjectParameter("Contraseña", typeof(string));
    
            var tokenParameter = token != null ?
                new ObjectParameter("Token", token) :
                new ObjectParameter("Token", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SpLogin", usuarioParameter, contraseñaParameter, tokenParameter);
        }
    }
}
