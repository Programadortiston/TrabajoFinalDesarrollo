using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using Newtonsoft.Json;
using WebAppProyectoFinal.Models;
using WebAppProyectoFinal.Services;

namespace WebAppProyectoFinal.Controllers
{
    public class TemporalReservaController : Controller
    {
        private readonly ITemporalReserva _temporalReserva;
        public TemporalReservaController(ITemporalReserva temporalReserva)
        {
            _temporalReserva = temporalReserva;
        }

        public IActionResult Index(string txtid,
                                   string txttitulo,
                                   string txtgenero,
                                   string txtautor,
                                   string txtaño,
                                   string txtstock,
                                   string txtcantidad)
        {
            if(_temporalReserva.validarDatos(int.Parse(txtid)) == true)
            {
                TemporalReserva obj = new TemporalReserva();
                obj.id = int.Parse(txtid);
                obj.titulo = txttitulo;
                obj.genero = txtgenero;
                obj.autor = txtautor;
                obj.año = txtaño;
                obj.stock = int.Parse(txtstock);
                obj.cantidad = int.Parse(txtcantidad);
                _temporalReserva.add(obj);
                return RedirectToAction("LibroIndex", "Libro");
            }
            else
            {
                return RedirectToAction("Reservar", "Libro", new { codigo = int.Parse(txtid) });
            }
        }
        public IActionResult VerReservas()
        {
            var objSession = HttpContext.Session.GetString("sUsuario");
            if (objSession != null)
            {
                var obj = JsonConvert.DeserializeObject<TbLogin>(HttpContext.Session.GetString("sUsuario"));
                ViewBag.idCli = obj.getIdCliente();
                return View(_temporalReserva.GetAllTemporaryBookings());
            }
            else
            {
                return RedirectToAction("LoginIndex", "Login");
            }
        }
        public IActionResult Eliminar(int id)
        {
            _temporalReserva.eliminar(id);
            return RedirectToAction("LibroIndex", "Libro");
        }
        public IActionResult AgregarDetalle(TbReserva reserva)
        {
            _temporalReserva.agregarTemporal(reserva);
            return RedirectToAction("LibroIndex", "Libro");
        }
    }
}
