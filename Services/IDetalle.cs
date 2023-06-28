using WebAppProyectoFinal.Models;

namespace WebAppProyectoFinal.Services
{
    public interface IDetalle
    {
        public IEnumerable<TbDetalleReserva> GetAllDetails();
        public IEnumerable<TbDetalleReserva> GetDetalleById(int id);
    }
}
