using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebAppProyectoFinal.Models;
using WebAppProyectoFinal.Services;

namespace WebAppProyectoFinal.Controllers
{
    public class ReservaController : Controller
    {
        private readonly IReserva _reserva;
        public ReservaController(IReserva reserva)
        {
            _reserva = reserva;
        }
        public IActionResult VerBoleta(string txtfechaA,
                                       string txtfechaD,
                                       string txtidCli,
                                       string txtestado)
        {
            TbReserva obj = new TbReserva();
            obj.FecPrestamo = txtfechaA;
            obj.FecDevolucion = txtfechaD;
            obj.IdCli = int.Parse(txtidCli);
            obj.Estado = txtestado;
            _reserva.add(obj);
            return View(obj);
        }
        public IActionResult ViewBookings()
        {
            return View(_reserva.GetAllBookings());
        }
    }
}
