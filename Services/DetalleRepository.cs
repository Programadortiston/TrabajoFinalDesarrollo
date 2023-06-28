using WebAppProyectoFinal.Models;

namespace WebAppProyectoFinal.Services
{
    public class DetalleRepository : IDetalle
    {
        LibreriasC conexion = new LibreriasC();
        public IEnumerable<TbDetalleReserva> GetAllDetails()
        {
            return conexion.TbDetalleReservas;
        }

        public IEnumerable<TbDetalleReserva> GetDetalleById(int id)
        {
            var lst = (from tDetalle in conexion.TbDetalleReservas
                                 where tDetalle.IdPrestamo == id
                                 select tDetalle).ToList();
            return lst;
        }
    }
}
