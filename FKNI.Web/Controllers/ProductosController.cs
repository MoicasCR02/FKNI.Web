using FKNI.Application.DTOs;
using FKNI.Application.Services.Implementations;
using FKNI.Application.Services.Interfaces;
using FKNI.Infraestructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;


namespace FKNI.Web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IServiceProductos _serviceProductos;
        private readonly IServiceImagenes _serviceImagenes;
        private readonly IServiceEtiquetas _serviceEtiquetas;
        private readonly IServiceCategorias _serviceCategorias;

        public ProductosController(IServiceProductos serviceProductos,IServiceEtiquetas serviceEtiquetas, IServiceCategorias serviceCategorias,IServiceImagenes serviceImagenes)
        {
            _serviceProductos = serviceProductos;
            _serviceEtiquetas = serviceEtiquetas;
            _serviceCategorias = serviceCategorias;
            _serviceImagenes = serviceImagenes;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var collection = await _serviceProductos.ListAsync();
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
                var @object = await _serviceProductos.FindByIdAsync(id.Value);
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

        // GET: LibroController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.ListCategoria = await _serviceCategorias.ListAsync();
            var etiquetas = await _serviceEtiquetas.ListAsync();
            ViewBag.ListEtiquetas = new MultiSelectList(etiquetas, "IdEtiqueta", "NombreEtiqueta");
            var imagenes = await _serviceEtiquetas.ListAsync();
            ViewBag.ListImagenes = new MultiSelectList(imagenes, "IdImagen", "UrlImagen");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductosDTO dto, List<IFormFile> ImageFiles, string[] selectedEtiquetas)
        {
            MemoryStream target = new MemoryStream();
            
            if (!ModelState.IsValid)
            {
                // Lee del ModelState todos los errores que
                // vienen para el lado del server
                string errors = string.Join("; ", ModelState.Values
                                   .SelectMany(x => x.Errors)
                                   .Select(x => x.ErrorMessage));
                // Response errores
                return BadRequest(errors);
            }

            // 3. Guardar imágenes
            if (ImageFiles != null && ImageFiles.Count > 0)
            {
                foreach (var imgs in ImageFiles)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await imgs.CopyToAsync(memoryStream);

                        await _serviceImagenes.AddAsync(new ImagenesDTO
                        {
                            //IdProducto = id,
                            UrlImagen = memoryStream.ToArray()
                        });
                    }
                }
            }

            await _serviceProductos.AddAsync(dto, selectedEtiquetas);
            return RedirectToAction("Index");

        }
    }
}
