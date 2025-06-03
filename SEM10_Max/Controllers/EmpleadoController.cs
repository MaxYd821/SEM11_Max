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
    }
}
