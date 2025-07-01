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
    public class RepositoryPromociones : IRepositoryPromociones
    {
        private readonly FKNIContext _context;
        public RepositoryPromociones(FKNIContext context)
        {
            _context = context;
        }
        public async Task<Promociones> FindByIdAsync(int id_promocion)
        {
            //Obtener un Libro con su autor y las lista de categorías
            var @object = await _context.Set<Promociones>()
                                .Where(x => x.IdProducto == id_promocion)
                                .Include(x => x.IdProductoNavigation)
                                .FirstAsync();
            return @object!;
        }
        public async Task<ICollection<Promociones>> ListAsync()
        {
            //Listar los libros incluyendo su autor, ordenado de forma descendente
            var collection = await _context.Set<Promociones>()
                                .Include(x => x.IdProductoNavigation)
                                .OrderBy(x => x.IdPromocion)
                                .ToListAsync();
            return collection;
        }
    }
}
