using Microsoft.AspNetCore.Mvc;
using WebAppProyectoFinal.Services;

namespace WebAppProyectoFinal.Controllers
{
    public class DetalleController : Controller
    {
        private readonly IDetalle _detalle;
        public DetalleController(IDetalle detalle)
        {
            _detalle = detalle;
        }
        public IActionResult VerDetalles()
        {
            return View(_detalle.GetAllDetails());
        }
        [Route("Detalle/VerDetalle/{codigo}")]
        public IActionResult VerDetalle(int codigo)
        {
            return View(_detalle.GetDetalleById(codigo));
        }
    }
}
