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
    public class RepositoryResenas : IRepositoryResenas
    {
        private readonly FKNIContext _context;
        //Alt+Enter
        public RepositoryResenas(FKNIContext context)
        {
            _context = context;
        }

        public async Task<Resenas> FindByIdAsync(int id_usuario, int id_producto)
        {
            //Obtener un Libro con su autor y las lista de categorías
            var @object = await _context.Set<Resenas>()
                                .Where(x => x.IdProducto == id_producto && x.IdUsuario == id_usuario)
                                .Include(x => x.IdUsuarioNavigation)
                                .Include(x => x.IdProductoNavigation)
                                .FirstAsync();
            return @object!;
        }

        public async Task<ICollection<Resenas>> ListAsync()
        {
            var collection = await _context.Set<Resenas>()
                .Include(x => x.IdUsuarioNavigation)
                .Include(x => x.IdProductoNavigation)
                .OrderByDescending(x => x.Fecha)
                .AsNoTracking().ToListAsync();
            return collection;
        }

        public async Task<int> AddAsync(Resenas entity)
        {
            await _context.Set<Resenas>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.IdProducto;
        }
    }
}
