using FKNI.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryPromociones
    {
        Task<ICollection<Promociones>> ListAsync();
        Task<Promociones> FindByIdAsync(int id_promocion);
        Task<int> AddAsync(Promociones entity);

        Task UpdateAsync(Promociones entity);
        Task DeleteAsync(int id);
    }
}
