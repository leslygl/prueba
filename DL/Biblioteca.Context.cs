//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BibliotecaEntities : DbContext
    {
        public BibliotecaEntities()
            : base("name=BibliotecaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Coordenada> Coordenadas { get; set; }
        public virtual DbSet<Voluman> Volumen { get; set; }
    
        public virtual int CoordenadasAdd(string estante, string sala, string librero, Nullable<int> posicion)
        {
            var estanteParameter = estante != null ?
                new ObjectParameter("Estante", estante) :
                new ObjectParameter("Estante", typeof(string));
    
            var salaParameter = sala != null ?
                new ObjectParameter("Sala", sala) :
                new ObjectParameter("Sala", typeof(string));
    
            var libreroParameter = librero != null ?
                new ObjectParameter("Librero", librero) :
                new ObjectParameter("Librero", typeof(string));
    
            var posicionParameter = posicion.HasValue ?
                new ObjectParameter("Posicion", posicion) :
                new ObjectParameter("Posicion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CoordenadasAdd", estanteParameter, salaParameter, libreroParameter, posicionParameter);
        }
    
        public virtual ObjectResult<CoordenadasGetAll_Result> CoordenadasGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CoordenadasGetAll_Result>("CoordenadasGetAll");
        }
    
        public virtual int CoordenadasUpdate(Nullable<int> idCoordenadas, string estante, string sala, string librero, Nullable<int> posicion)
        {
            var idCoordenadasParameter = idCoordenadas.HasValue ?
                new ObjectParameter("IdCoordenadas", idCoordenadas) :
                new ObjectParameter("IdCoordenadas", typeof(int));
    
            var estanteParameter = estante != null ?
                new ObjectParameter("Estante", estante) :
                new ObjectParameter("Estante", typeof(string));
    
            var salaParameter = sala != null ?
                new ObjectParameter("Sala", sala) :
                new ObjectParameter("Sala", typeof(string));
    
            var libreroParameter = librero != null ?
                new ObjectParameter("Librero", librero) :
                new ObjectParameter("Librero", typeof(string));
    
            var posicionParameter = posicion.HasValue ?
                new ObjectParameter("Posicion", posicion) :
                new ObjectParameter("Posicion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CoordenadasUpdate", idCoordenadasParameter, estanteParameter, salaParameter, libreroParameter, posicionParameter);
        }
    
        public virtual int VolumenAdd(Nullable<int> numeroVolumen, string titulo)
        {
            var numeroVolumenParameter = numeroVolumen.HasValue ?
                new ObjectParameter("NumeroVolumen", numeroVolumen) :
                new ObjectParameter("NumeroVolumen", typeof(int));
    
            var tituloParameter = titulo != null ?
                new ObjectParameter("Titulo", titulo) :
                new ObjectParameter("Titulo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("VolumenAdd", numeroVolumenParameter, tituloParameter);
        }
    
        public virtual int VolumenDelete(Nullable<int> numeroVolumen)
        {
            var numeroVolumenParameter = numeroVolumen.HasValue ?
                new ObjectParameter("NumeroVolumen", numeroVolumen) :
                new ObjectParameter("NumeroVolumen", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("VolumenDelete", numeroVolumenParameter);
        }
    
        public virtual ObjectResult<VolumenGetAll_Result> VolumenGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VolumenGetAll_Result>("VolumenGetAll");
        }
    
        public virtual int VolumenUpdate(Nullable<int> numeroVolumen, string titulo)
        {
            var numeroVolumenParameter = numeroVolumen.HasValue ?
                new ObjectParameter("NumeroVolumen", numeroVolumen) :
                new ObjectParameter("NumeroVolumen", typeof(int));
    
            var tituloParameter = titulo != null ?
                new ObjectParameter("Titulo", titulo) :
                new ObjectParameter("Titulo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("VolumenUpdate", numeroVolumenParameter, tituloParameter);
        }
    
        public virtual ObjectResult<CoordenadasGetById_Result> CoordenadasGetById(Nullable<int> idCoordenada)
        {
            var idCoordenadaParameter = idCoordenada.HasValue ?
                new ObjectParameter("IdCoordenada", idCoordenada) :
                new ObjectParameter("IdCoordenada", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CoordenadasGetById_Result>("CoordenadasGetById", idCoordenadaParameter);
        }
    
        public virtual ObjectResult<VolumenGetById_Result> VolumenGetById(Nullable<int> numeroVolumen)
        {
            var numeroVolumenParameter = numeroVolumen.HasValue ?
                new ObjectParameter("NumeroVolumen", numeroVolumen) :
                new ObjectParameter("NumeroVolumen", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VolumenGetById_Result>("VolumenGetById", numeroVolumenParameter);
        }
    
        public virtual int CoordenadasDelete(Nullable<int> idCoordenadas)
        {
            var idCoordenadasParameter = idCoordenadas.HasValue ?
                new ObjectParameter("IdCoordenadas", idCoordenadas) :
                new ObjectParameter("IdCoordenadas", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CoordenadasDelete", idCoordenadasParameter);
        }
    }
}
