using WebAppProyectoFinal.Models;

namespace WebAppProyectoFinal.Services
{
    public class ReservaRepository : IReserva
    {
        LibreriasC conexion = new LibreriasC();
        public void add(TbReserva obj)
        {
            conexion.TbReservas.Add(obj);
            conexion.SaveChanges();
        }

        public IEnumerable<TbReserva> GetAllBookings()
        {
            return conexion.TbReservas;
        }

        public TbReserva GetReservaById(int id)
        {
            var objEncontrado = (from tReserva in conexion.TbReservas
                                 where tReserva.IdPrestamo == id
                                 select tReserva).Single();
            return objEncontrado;
        }
    }
}
