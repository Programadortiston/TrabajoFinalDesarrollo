using WebAppProyectoFinal.Models;
namespace WebAppProyectoFinal.Services
{
    public interface ITemporalReserva
    {
        void add(TemporalReserva temporal);
        void eliminar(int id);
        IEnumerable<TemporalReserva> GetAllTemporaryBookings();
        void agregarTemporal(TbReserva reserva);
        bool validarDatos(int id);
    }
}
