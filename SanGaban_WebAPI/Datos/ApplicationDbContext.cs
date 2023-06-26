using Microsoft.EntityFrameworkCore;
using SanGaban_WebAPI.Modelos;
using SanGaban_WebAPI.Modelos.Dto;

namespace SanGaban_WebAPI.Datos
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }


        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Ubicacion> Ubicacion { get; set; }
        public DbSet<TipoRegistro> TipoRegistro { get; set; }
        public DbSet<Equipos> Equipos { get; set; }

        public DbSet<Login> Login { get; set; }
        public DbSet<LoginResultadoDto> LoginResultadoDto { get; set; }
        public DbSet<ListarUbicacionResultadoDto> ListarUbicacionResultadoDto { get; set; }
        
        public DbSet<Ubicacion_x_EquipoDto> Ubicacion_x_EquipoDto { get; set; }

        public DbSet<ListarUbicacion_x_TipoRegistroResultadoDto> ListarUbicacion_x_TipoRegistroResultadoDto { get; set; }

        public DbSet<ExportarBitacoraDto> ExportarBitacoraDto { get; set; }


        public DbSet<AuditoriaDto> AuditoriaDto { get; set; }
        public DbSet<BitacoraDto> BitacoraDto { get; set; }

        //CREA REGISTROS EN LA TABLA
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Rol>().HasData(
        //        new Rol()
        //        {
        //            Id_Rol = 80,
        //            Nombre = "Programador",
        //            Fecha_Registro = DateTime.Now
        //        }
        //        );
        //}




    }
}
