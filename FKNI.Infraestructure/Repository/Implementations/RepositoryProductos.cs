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
                                .Include(x => x.IdEtiqueta)
                                .Include(x => x.DetallePedidoProducto)
                                .Include(x => x.Resenas).ThenInclude(r => r.IdUsuarioNavigation)
                                .Include(x => x.IdImagen)
                                .FirstAsync();
            return @object!;
        }
        public async Task<ICollection<Productos>> ListAsync()
        {
            var collection = await _context.Set<Productos>()
                                .Include(x => x.IdCategoriaNavigation)
                                .Include(x => x.IdEtiqueta)
                                .Include(x => x.DetallePedidoProducto)
                                .Include(x => x.Resenas).ThenInclude(r => r.IdUsuarioNavigation)
                                .Include(x => x.IdImagen)
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

        public async Task<int> AddAsync(Productos entity, string[] selectedEtiquetas)
        {
            //Relación de muchos a muchos solo con llave primaria compuesta
            var etiquetas = await getEtiquetas(selectedEtiquetas);
            entity.IdEtiqueta = etiquetas;
            var imagenes = await getEtiquetas(selectedEtiquetas);
            entity.IdEtiqueta = etiquetas;
            //entity.IdImagen = imagens;
            await _context.Set<Productos>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.IdProducto;
        }

        private async Task<ICollection<Etiquetas>> getEtiquetas(string[] selectedEtiquetas)
        {
            var etiquetas = await _context.Set<Etiquetas>()
                .Where(c => selectedEtiquetas.Contains(c.IdEtiqueta.ToString()))
                .ToListAsync();
            return etiquetas;

        }
        public async Task UpdateAsync(Productos entity, string[] selectedEtiquetas)
        {
            // Asegurar que EF esté rastreando el entity
            _context.Entry(entity).State = EntityState.Modified;

            // Mantener la relación con la categoría
            var categoria = await _context.Set<Categorias>().FindAsync(entity.IdCategoria);
            entity.IdCategoriaNavigation = categoria!;

            // Obtener las nuevas etiquetas seleccionadas
            var nuevasEtiquetas = await getEtiquetas(selectedEtiquetas);

            // Cargar las etiquetas actuales si no vienen cargadas
            _context.Entry(entity).Collection(e => e.IdEtiqueta).Load();

            // Limpiar y asignar nuevas etiquetas
            entity.IdEtiqueta.Clear();
            foreach (var etiqueta in nuevasEtiquetas)
            {
                entity.IdEtiqueta.Add(etiqueta);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // Raw Query
            //https://www.learnentityframeworkcore.com/raw-sql/execute-sql
            int rowAffected = _context.Database.ExecuteSql($"Delete Productos where id_producto = {id}");
            await Task.FromResult(1);
        }
    }
}
