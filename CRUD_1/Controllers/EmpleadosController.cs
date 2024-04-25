using CRUD_1.Data;
using CRUD_1.Models;
using CRUD_1.Models.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_1.Controllers
{
    public class EmpleadosController : Controller
    {
        //Crear y asignar campos de mvcDbContext
        private readonly MVCDbContext mvcDbContext;

        public EmpleadosController(MVCDbContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmpleadoViewModel nuevo)
        {
            var empleado = new Empleado()
            {
                Id = Guid.NewGuid(),
                Nombre = nuevo.Nombre,
                Email = nuevo.Email,    
                Salarry = nuevo.Salarry,
                FechaNacimiento = nuevo.FechaNacimiento,
                Departamento = nuevo.Departamento
            };
            await mvcDbContext.Empleados.AddAsync(empleado);
            await mvcDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }
    }
}
