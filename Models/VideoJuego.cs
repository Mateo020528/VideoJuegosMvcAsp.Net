using Microsoft.EntityFrameworkCore;
using CrudJuegos.Data;
namespace  CrudJuegos.Models{
    public class VideoJuego{
        public int Id {get; set; }
        public string Nombre {get; set; }
        public string Logo {get; set; }
        public string Descripcion {get; set; }
        public int Cantidad {get; set;}
        public string ConsolasCompatibles {get; set; }
        public string JugableOnline {get; set; }
        public DateOnly FechaDeLanzamiento {get; set;}
    }
}