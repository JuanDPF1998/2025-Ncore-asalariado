using _2025_NetCore_Empleados.Data;
using _2025_NetCore_Empleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace _2025_NetCore_Empleados.Controllers
{
    public class empleadoController : Controller
    {
        private readonly AppDbContext _context;

        public empleadoController(AppDbContext context)
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Empleados empleados)
        {
            try
            {
                var empleado = _context.empleadosDbSet.Add(empleados);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }catch(Exception ex)
            {
                return Content($"Error al agregar un empleado {ex.Message}");
            }
        }
        public IActionResult Edit(int? id)
        {
            if( id == null)
            {
                return NotFound();
            }
            var empleado = _context.empleadosDbSet.Find(id);
            return View(empleado);
        }
        [HttpPost]
        public IActionResult Edit(int id, Empleados empleados)
        {
            if (id != empleados.idEmpleado)
            {
                return NotFound();
            }
            var empleado = _context.empleadosDbSet.Update(empleados);
            if (ModelState.IsValid)
            {
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
             var empleado =   _context.empleadosDbSet.Find(id);
                return View(empleado);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var empleado = _context.empleadosDbSet.Find(id);

                if (ModelState.IsValid)
                {
                    _context.empleadosDbSet.Remove(empleado);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(empleado);
            }
            catch (Exception ex) {
                return Content($"Se produjo una excepcion al eliminar el registro {ex.Message}");
            }
            //if (ModelState.IsValid)
            //{
            //    var empleado = _context.empleadosDbSet.Find(id);
            //      _context.empleadosDbSet.Remove(empleado);
            //    _context.SaveChanges();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View();
        }
    }
}
