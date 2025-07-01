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
    public class RepositoryEtiquetas : IRepositoryEtiquetas
    {
        private readonly FKNIContext _context;
        //Alt+Enter
        public RepositoryEtiquetas(FKNIContext context)
        {
            _context = context;
        }

        public async Task<Etiquetas> FindByIdAsync(int id)
        {
            var @object = await _context.Set<Etiquetas>().FindAsync(id);

            return @object!;
        }

        public async Task<ICollection<Etiquetas>> ListAsync()
        {
            var collection = await _context.Set<Etiquetas>().AsNoTracking().ToListAsync();
            return collection;
        }
    }
}
