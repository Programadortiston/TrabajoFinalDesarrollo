using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppProyectoFinal.Models;
using WebAppProyectoFinal.Services;

namespace WebAppProyectoFinal.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogin _login;
        public LoginController(ILogin login)
        {
            _login = login;
        }
        public IActionResult LoginIndex()
        {
            return View();
        } 
        public IActionResult Validar(TbLogin login1)
        {
            if (ModelState.IsValid)
            {
                if (_login.ValidateLogin(login1) == true)
                {
                    HttpContext.Session.SetString("sUsuario", JsonConvert.SerializeObject(login1));
                    return RedirectToAction("LibroIndex", "Libro");
                }
                else
                {
                    return View("LoginIndex");
                }
            }
            else
            {
                return View("LoginIndex");
            }
        }
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginIndex");
        }
    }
}
