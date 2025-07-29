using AutoMapper;
using FKNI.Application.DTOs;
using FKNI.Application.Services.Implementations;
using FKNI.Application.Services.Interfaces;
using FKNI.Infraestructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FKNI.Web.Controllers
{
    public class ResenasController : Controller
    {
        private readonly IServiceResenas _serviceResenas;
        private readonly IServiceProductos _serviceProducto;
        private readonly IServiceUsuarios _serviceUsuario;
        private readonly IMapper _mapper;
        public ResenasController(IServiceResenas serviceResenas, IServiceProductos serviceProducto, IServiceUsuarios serviceUsuario, IMapper mapper)
        {
            _serviceResenas = serviceResenas;
            _serviceProducto = serviceProducto;
            _serviceUsuario = serviceUsuario;
            _mapper = mapper;
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

        public async Task<IActionResult> Create(int IdProducto, int IdUsuario)
        {
            ViewBag.Producto = await _serviceProducto.FindByIdAsync(IdProducto);
            ViewBag.Usuario = await _serviceUsuario.FindByIdAsync(IdUsuario);

            var modelo = new ResenasDTO
            {
                IdProducto = IdProducto,
                IdUsuario = IdUsuario,
                Fecha = DateTime.Now
            };
            return View(modelo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ResenasDTO dto)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                                   .SelectMany(x => x.Errors)
                                   .Select(x => x.ErrorMessage));

                return BadRequest(errors);
            }

            try
            {
                await _serviceResenas.AddAsync(dto);
                return RedirectToAction("Details", "Productos", new { id = dto.IdProducto });
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("duplicate") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE") == true)
                {
                    ModelState.AddModelError("", "Ya has enviado una reseña para este producto.");
                }
                else
                {
                    ModelState.AddModelError("", "Ocurrió un error al guardar la reseña. Intenta nuevamente.");
                }

                // Recargar info si la vista la necesita
                ViewBag.Usuario = await _serviceUsuario.FindByIdAsync(dto.IdUsuario);
                ViewBag.Producto = await _serviceProducto.FindByIdAsync(dto.IdProducto);

                return View(dto);
            }
        }
    }
}
