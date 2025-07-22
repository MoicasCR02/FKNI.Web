using FKNI.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryImagenes
    {
        Task<ICollection<Imagenes>> ListAsync();
        Task<Imagenes> FindByIdAsync(int id);
        Task<int> AddAsync(Imagenes entity);
    }
}
