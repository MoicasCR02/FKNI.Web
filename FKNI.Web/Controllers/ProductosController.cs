﻿using FKNI.Application.Services.Interfaces;
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
    }
}
