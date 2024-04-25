using Microsoft.AspNetCore.Mvc;

namespace CRUD_1.Controllers
{
    public class EmpleadosController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
