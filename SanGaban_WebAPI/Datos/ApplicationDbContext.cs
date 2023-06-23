using Microsoft.EntityFrameworkCore;
using SanGaban_WebAPI.Modelos;

namespace SanGaban_WebAPI.Datos
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
       
        
        } 
            
  
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


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
