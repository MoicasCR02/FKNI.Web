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

        public async Task<int> AddAsync(Imagenes entity)
        {
            //Relación de muchos a muchos solo con llave primaria compuesta
            await _context.Set<Imagenes>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.IdImagen;
        }
    }
}
