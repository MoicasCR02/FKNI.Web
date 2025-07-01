using FKNI.Application.Services.Implementations;
using FKNI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FKNI.Web.Controllers
{
    public class ResenasController : Controller
    {
        private readonly IServiceResenas _serviceResenas;
        public ResenasController(IServiceResenas serviceResenas)
        {
            _serviceResenas = serviceResenas;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var collection = await _serviceResenas.ListAsync();
            return View(collection);
        }

        public async Task<ActionResult> Details(int? id_usuario, int? id_producto)
        {
            try
            {
                if (id_usuario == null && id_producto == null)
                {
                    return RedirectToAction("IndexAdmin");
                }
                var @object = await _serviceResenas.FindByIdAsync(id_usuario.Value,id_producto.Value);
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
