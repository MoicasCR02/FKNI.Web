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
        public Task<Categorias> FindByIdAsync(int id_categoria)
        {
            throw new NotImplementedException();
        }
        public async Task<ICollection<Categorias>> ListAsync()
        {
            //Select * from Categorias
            var collection = await _context.Set<Categorias>().ToListAsync();
            return collection;
        }
    }
}
