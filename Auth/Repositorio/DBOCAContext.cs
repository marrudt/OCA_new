using Auth.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Auth.Repositorio
{
    public partial class DBOCAContext : DbContext
    {
        public DBOCAContext()
           : base("name=DBOCAContext")
        {
        }
        public DbSet<ControlMatriculas> ControlMatriculas { get; set; }
        public DbSet<LineaVh> LineaVh { get; set; }
        public DbSet<OrdenCompra> OrdenCompra { get; set; }
        public DbSet<GestionOC> GestionOC { get; set; }
        public DbSet<CarteraOC> CarteraOC { get; set; }
        public DbSet<GestionCartera> GestionCartera { get; set; }
        public DbSet<EjecucionOC> EjecucionOC { get; set; }
        public DbSet<ArchivoOC> ArchivoOCs { get; set; }
        public DbSet<TercerosOCA> TercerosOCAs { get; set; }
        public DbSet<ArchivoCarteraOC> ArchivoCarteraOCs { get; set; }
        public DbSet<ArchivoEjecucionOC> ArchivoEjecucionOCs { get; set; }
        public DbSet<Proveedor> Proveedors { get; set; }
        public DbSet<ReferenciasOC> ReferenciasOC { get; set; }
        public DbSet<EntidadMatricula> EntidadMatriculas { get; set; }
        public DbSet<ProveedorOC> ProveedorOCs { get; set; }
        public DbSet<ArchivoProveedorOC> ArchivoProveedorOCs { get; set; }
        public DbSet<Evento> Eventoes { get; set; }        
        public DbSet<IntervaloPrecio> IntervaloPrecios { get; set; }
        public DbSet<Transmision> Transmisiones { get; set; }
        public DbSet<MttoPreventivo> MttoPreventivos { get; set; }
        public DbSet<VigenciaSoat> VigenciaSoats { get; set; }
        public DbSet<CiudadOCA> CiudadOCA { get; set; }
        public DbSet<Segmento> Segmentoes { get; set; }
        public DbSet<Detalle> Detalles { get; set; }
        public DbSet<Adecuacion> Adecuacions { get; set; }
        public DbSet<RegisterViewModel> Registro { get; set; }
    }
}