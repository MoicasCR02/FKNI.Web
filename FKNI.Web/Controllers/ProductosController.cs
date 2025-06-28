using FKNI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FKNI.Web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IServiceProductos _serviceProductos;
        public ProductosController(IServiceProductos serviceProductos)
        {
            _serviceProductos = serviceProductos;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var collection = await _serviceProductos.ListAsync();
            return View(collection);
        }
    }
}
