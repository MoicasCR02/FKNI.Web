using FKNI.Infraestructure.Data;
using FKNI.Infraestructure.Models;
using FKNI.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Infraestructure.Repository.Implementations
{
    public class RepositoryProductos : IRepositoryProductos
    {
        private readonly FKNIContext _context;
        public RepositoryProductos(FKNIContext context)
        {
            _context = context;
        }
        public async Task<Productos> FindByIdAsync(int id_producto)
        {
            //Obtener un Libro con su autor y las lista de categorías
            var @object = await _context.Set<Productos>()
                                .Where(x => x.IdProducto == id_producto)
                                .Include(x => x.IdCategoriaNavigation)
                                .Include(x => x.IdImagen)
                                .Include(x => x.IdEtiqueta)
                                .Include(x => x.DetallePedidoProducto)
                                .Include(x => x.Resenas).ThenInclude(r => r.IdUsuarioNavigation)
                                .FirstAsync();
            return @object!;
        }
        public async Task<ICollection<Productos>> ListAsync()
        {
            var collection = await _context.Set<Productos>()
                                .Include(x => x.IdCategoriaNavigation)
                                .Include(x => x.IdImagen)
                                .Include(x => x.IdEtiqueta)
                                .Include(x => x.DetallePedidoProducto)
                                .Include(x => x.Resenas).ThenInclude(r => r.IdUsuarioNavigation)
                                .OrderByDescending(x => x.IdCategoria)
                                .ToListAsync();
            var hoy = DateTime.Today;
            var promociones = await _context.Set<Promociones>().ToListAsync();
            var promocionesVigentes = promociones.Where(p => p.FechaInicio <= hoy && p.FechaFin >= hoy).ToList();
            foreach (var producto in collection)
            {
                var promo = promocionesVigentes.FirstOrDefault(pr => pr.IdProducto == producto.IdProducto)
                         ?? promocionesVigentes.FirstOrDefault(pr => pr.IdCategoria == producto.IdCategoria);

                producto.Descuento = promo?.Descuento ?? 0;
            }

            return collection;
        }
    }
}
