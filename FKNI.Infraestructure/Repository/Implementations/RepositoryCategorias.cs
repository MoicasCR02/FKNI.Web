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
    public class RepositoryCategorias : IRepositoryCategorias
    {
        private readonly FKNIContext _context;
        public RepositoryCategorias(FKNIContext context)
        {
            _context = context;
        }
        public async Task<Categorias> FindByIdAsync(int id_categoria)
        {
            var @object = await _context.Set<Categorias>().FindAsync(id_categoria);

            return @object!;
        }
        public async Task<ICollection<Categorias>> ListAsync()
        {
            //Select * from Categorias
            var collection = await _context.Set<Categorias>().ToListAsync();
            return collection;
        }

        public async Task<ICollection<Categorias>> SinPromo()
        {
            var collection = await _context.Categorias
                .Where(c => !c.Promociones.Any()) // No tiene promociones
                .ToListAsync();

            return collection;
        }
    }
}
