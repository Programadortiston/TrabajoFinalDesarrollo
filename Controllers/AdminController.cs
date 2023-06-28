using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppProyectoFinal.Models;
using WebAppProyectoFinal.Services;

namespace WebAppProyectoFinal.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdmin _admin;
        public AdminController(IAdmin admin)
        {
            _admin = admin;
        }
        [Route("Admin/AdminIndex")]
        public IActionResult AdminIndex()
        {
            return View();
        }
        public IActionResult Validar(TbAdmin admin)
        {
            if (ModelState.IsValid)
            {
                if (_admin.ValidateLogin(admin) == true)
                {
                    HttpContext.Session.SetString("sAdmin", JsonConvert.SerializeObject(admin));
                    return RedirectToAction("AdminView", "Libro");
                }
                else
                {
                    return View("AdminIndex");
                }
            }
            else
            {
                return View("AdminIndex");
            }
        }
    }
}
