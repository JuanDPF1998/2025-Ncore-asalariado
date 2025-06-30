using _2025_NetCore_Empleados.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2025_NetCore_Empleados.Controllers
{
    public class empreadoController : Controller
    {
        private readonly AppDbContext _context;

        public empreadoController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            try
            {
                var empleado = _context.empleadosDbSet.ToList();
                return View(empleado);
            }catch(DbUpdateException ex)
            {
              return  Content($"Error de acceso a la base de datos {ex.Message}");
            }catch(Exception ex)
            {
                return Content("Se ha producido una excepcion :" + ex.Message);
            }

        }
    }
}
