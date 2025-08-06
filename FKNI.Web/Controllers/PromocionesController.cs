using FKNI.Application.Services.Implementations;
using FKNI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FKNI.Web.Controllers
{
    public class PromocionesController : Controller
    {
        private readonly IServicePromociones _servicePromociones;
        private readonly IServiceProductos _serviceProductos;
        public PromocionesController(IServicePromociones servicePromociones, IServiceProductos serviceProductos)
        {
            _servicePromociones = servicePromociones;
            _serviceProductos = serviceProductos;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var collection = await _servicePromociones.ListAsync();
            return View(collection);
        }
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }
                var @object = await _servicePromociones.FindByIdAsync(id.Value);
                if (@object == null)
                {
                    throw new Exception("Producto no existente");

                }

                return View(@object);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.ListProductos = await _serviceProductos.ListAsync();
            return View();
        }





        // GET: LibroController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var @object = await _servicePromociones.FindByIdAsync(id);
            return View(@object);
        }

        // POST: LibroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            await _servicePromociones.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
