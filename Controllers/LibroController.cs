using WebAppProyectoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using WebAppProyectoFinal.Services;
using Newtonsoft.Json;

namespace WebAppProyectoFinal.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibro _libro;
        public LibroController(ILibro libro)
        {
            _libro = libro;
        }
        public IActionResult LibroIndex()
        {
            var objSession = HttpContext.Session.GetString("sUsuario");
            if (objSession != null)
            {
                var obj = JsonConvert.DeserializeObject<TbLogin>(HttpContext.Session.GetString("sUsuario"));
                ViewBag.nombreUsuario = obj.getNomCli();
                //retornando los datos del producto a través del objeto
                return View(_libro.GetAllBooks());
            }
            else
            {
                return RedirectToAction("LoginIndex", "Login");
            }
        }
        [Route("Libro/Reservar/{codigo}")]
        public IActionResult Reservar(int codigo)
        {
            var objObtenido = _libro.GetLibro(codigo);
            return View(objObtenido);
        }
        public IActionResult AdminView()
        {
            var objSession = HttpContext.Session.GetString("sAdmin");
            if (objSession != null)
            {
                var obj = JsonConvert.DeserializeObject<TbAdmin>(HttpContext.Session.GetString("sAdmin"));
                ViewBag.nombreUsuario = obj.UserAdmin;
                //retornando los datos del producto a través del objeto
                return View(_libro.GetAllBooks());
            }
            else
            {
                return RedirectToAction("AdminIndex", "Admin");
            }
        }
        public IActionResult Nuevo()
        {
            return View();
        }
        public IActionResult Grabar(TbLibro obj)
        {
            _libro.add(obj);
            return RedirectToAction("AdminView");
        }
        [Route("Libro/Eliminar/{codigo}")]
        public IActionResult Eliminar(int codigo)
        {
            _libro.remove(codigo);
            return RedirectToAction("AdminView");
        }
        [Route("Libro/Modificar/{codigo}")]
        public IActionResult Modificar(int codigo)
        {
            return View(_libro.edit(codigo));
        }

        public IActionResult ModificarLibro(TbLibro libro)
        {
            _libro.editDetails(libro);
            return RedirectToAction("AdminView");
        }
    }
}
