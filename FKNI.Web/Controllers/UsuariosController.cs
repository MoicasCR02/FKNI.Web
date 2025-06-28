using FKNI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace FKNI.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IServiceUsuarios _serviceUsuarios;
        public UsuariosController(IServiceUsuarios serviceUsuarios)
        {
            _serviceUsuarios = serviceUsuarios;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var collection = await _serviceUsuarios.ListAsync();
            return View(collection);
        }
    }
}
