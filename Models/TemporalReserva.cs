using System.ComponentModel.DataAnnotations;

namespace WebAppProyectoFinal.Models
{
    public class TemporalReserva
    {
        public int id { set; get; }
        public string titulo { set; get; }
        public string genero { set; get; }
        public string autor { set; get; }
        public string año { set; get; }
        public int stock { set; get; }
        public int cantidad { set; get; }


    }
}
