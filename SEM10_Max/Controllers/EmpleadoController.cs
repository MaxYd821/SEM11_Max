using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEM10_Max.Data;
using SEM10_Max.Models;

namespace SEM10_Max.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly AppDBContext _appDBContext;
        public EmpleadoController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Empleado> lista = await _appDBContext.Empleados.ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public async Task<IActionResult> Nuevo()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Nuevo(Empleado empleado)
        {
            await _appDBContext.Empleados.AddAsync(empleado);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id) { 
            Empleado empleado = await _appDBContext.Empleados.FirstAsync(e =>e.Id == id);
            return View(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Empleado empleado) { 
            _appDBContext.Empleados.Update(empleado);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Empleado empleado = await _appDBContext.Empleados.FirstAsync(e => e.Id == id);
            _appDBContext.Empleados.Remove(empleado);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
