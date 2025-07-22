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
    public class RepositoryImagenes : IRepositoryImagenes
    {
        private readonly FKNIContext _context;
        //Alt+Enter
        public RepositoryImagenes(FKNIContext context)
        {
            _context = context;
        }

        public async Task<Imagenes> FindByIdAsync(int id)
        {
            var @object = await _context.Set<Imagenes>().FindAsync(id);

            return @object!;
        }

        public async Task<ICollection<Imagenes>> ListAsync()
        {
            var collection = await _context.Set<Imagenes>().AsNoTracking().ToListAsync();
            return collection;
        }

        public async Task<List<Imagenes>> ObtenerPorProductoAsync(int idProducto)
        {
            return await _context.Imagenes.Where(img => img.IdProducto == idProducto).ToListAsync();
        }

        public async Task<int> AddAsync(Imagenes entity)
        {
            await _context.Set<Imagenes>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.IdImagen;
        }

        public async Task UpdateAsync(Imagenes entity)
        {
            await _context.Set<Imagenes>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // Raw Query
            //https://www.learnentityframeworkcore.com/raw-sql/execute-sql
            int rowAffected = _context.Database.ExecuteSql($"Delete Imagenes Where id_producto = {id}");
            await Task.FromResult(1);
        }
    }
}
