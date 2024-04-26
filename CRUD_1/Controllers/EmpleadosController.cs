using CRUD_1.Data;
using CRUD_1.Models;
using CRUD_1.Models.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

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
        public async Task<IActionResult> Index()
        {
            var lista = await mvcDbContext.Empleados.ToListAsync();
            
            return View(lista);
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

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var empleado = await mvcDbContext.Empleados.FirstOrDefaultAsync(x => x.Id == id);
            if (empleado != null)
            {
                var modelo = new UpdateEmpleadoViewModel()
                {
                    Id = empleado.Id,
                    Nombre = empleado.Nombre,
                    Email = empleado.Email,
                    Salarry = empleado.Salarry,
                    FechaNacimiento = empleado.FechaNacimiento,
                    Departamento = empleado.Departamento
                };
                //return await Task.Run(() => View("View", modelo));
                //Este error se da por la ambiguedad del nombre
                return View("View", modelo); 
                //return View(modelo);


            }
            return RedirectToAction("Index");            
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateEmpleadoViewModel modelo)
        {
            var empleado = await mvcDbContext.Empleados.FindAsync(modelo.Id);
            if(empleado != null)
            {
                //Si no es null actualizamos
                empleado.Nombre = modelo.Nombre;
                empleado.Email = modelo.Email;
                empleado.Salarry = modelo.Salarry;
                empleado.FechaNacimiento = modelo.FechaNacimiento;
                empleado.Departamento = modelo.Departamento;
                //guardamos
                await mvcDbContext.SaveChangesAsync();
                //mostramos en el index
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmpleadoViewModel modelo)
        {
            var empleado = await mvcDbContext.Empleados.FirstOrDefaultAsync(x => x.Id == modelo.Id);
            if (empleado != null)
            {
                mvcDbContext.Empleados.Remove(empleado);
                //metodo remove no posee un metodo asyncronico
                await mvcDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");            
        }

    }
}
