using FKNI.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryResenas
    {
        Task<ICollection<Resenas>> ListAsync();
        Task<Resenas> FindByIdAsync(int id_usuario, int id_producto);

        Task<int> AddAsync(Resenas entity);
    }
}


