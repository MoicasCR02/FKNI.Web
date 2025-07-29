using FKNI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FKNI.Web.Controllers
{
    public class PromocionesController : Controller
    {
        private readonly IServicePromociones _servicePromociones;
        public PromocionesController(IServicePromociones servicePromociones)
        {
            _servicePromociones = servicePromociones;
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
    }
}
