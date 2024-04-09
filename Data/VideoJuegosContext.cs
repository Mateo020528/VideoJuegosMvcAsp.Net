using Microsoft.EntityFrameworkCore;
using CrudJuegos.Models;
using System.Security.Cryptography.X509Certificates;
namespace CrudJuegos.Data{
    public class VideoJuegosContext : DbContext{
        public VideoJuegosContext(DbContextOptions<VideoJuegosContext> options) : base(options){ 

    }
            //Añadimos el apartado de modelos
            public DbSet<VideoJuego> VideoJuegos {get; set;}
        }
}



