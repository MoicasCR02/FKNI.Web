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
        public Task<Productos> FindByIdAsync(int id_producto)
        {
            throw new NotImplementedException();
        }
        public async Task<ICollection<Productos>> ListAsync()
        {
            //Listar los libros incluyendo su autor, ordenado de forma descendente
            var collection = await _context.Set<Productos>()
                                .Include(x => x.IdCategoriaNavigation)
                                .OrderByDescending(x => x.IdCategoria)
                                .ToListAsync();
            return collection;
        }
    }
}
