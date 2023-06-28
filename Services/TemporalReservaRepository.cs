using WebAppProyectoFinal.Models;

namespace WebAppProyectoFinal.Services
{
    public class TemporalReservaRepository : ITemporalReserva
    {
        LibreriasC conexion = new LibreriasC();
        private List<TemporalReserva> _lst = new List<TemporalReserva>();

        public void add(TemporalReserva temporal)
        {
            _lst.Add(temporal);
        }

        public void agregarTemporal(TbReserva reserva)
        {
            for(int i = 0; i<_lst.Count(); i++)
            {
                int idLibro = _lst[i].id;
                int idPrestamo = reserva.IdPrestamo;
                string fecPrestamo = reserva.FecPrestamo;
                string fecDevolucion = reserva.FecDevolucion;
                int cantidad = _lst[i].cantidad;
                TbDetalleReserva obj = new TbDetalleReserva();
                obj.IdLibro = idLibro;
                obj.IdPrestamo = idPrestamo;
                obj.FecPrestamo = fecPrestamo;
                obj.FecDevolucion = fecDevolucion;
                obj.Cantidad = cantidad;
                conexion.TbDetalleReservas.Add(obj);
                conexion.SaveChanges();
            }
            _lst.Clear();
        }

        public void eliminar(int id)
        {
            var objEncontrado = (from lst in _lst
                                 where lst.id == id
                                 select lst).Single();
            _lst.Remove(objEncontrado);
        }

        public IEnumerable<TemporalReserva> GetAllTemporaryBookings()
        {
            return _lst;
        }

        public bool validarDatos(int id)
        {
            int contador = 0;
            for (int i = 0; i < _lst.Count(); i++)
            {
                if (_lst[i].id == id)
                {
                    contador++;
                }
            }
            if(contador == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
