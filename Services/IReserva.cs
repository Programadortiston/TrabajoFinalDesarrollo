using WebAppProyectoFinal.Models;

namespace WebAppProyectoFinal.Services
{
    public interface IReserva
    {
        void add(TbReserva obj);
        public IEnumerable<TbReserva> GetAllBookings();
        TbReserva GetReservaById(int id);

    }
}
