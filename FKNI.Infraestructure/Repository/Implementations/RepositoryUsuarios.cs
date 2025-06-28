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
    public class RepositoryUsuarios : IRepositoryUsuarios
    {
        private readonly FKNIContext _context;
        public RepositoryUsuarios(FKNIContext context)
        {
            _context = context;
        }
        public Task<Usuarios> FindByIdAsync(int IdUsuario)
        {
            throw new NotImplementedException();
        }
        public async Task<ICollection<Usuarios>> ListAsync()
        {
            //Select * from Autor
            var collection = await _context.Set<Usuarios>().ToListAsync();
            return collection;
        }
    }
}
