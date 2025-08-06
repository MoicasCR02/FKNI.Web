using FKNI.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryProductos
    {
        Task<ICollection<Productos>> ListAsync();
        Task<ICollection<Productos>> FindByNameAsync(string nombre);
        Task<Productos> FindByIdAsync(int id_producto);
        Task<int> AddAsync(Productos entity, string[] selectedEtiquetas);
        Task UpdateAsync(int id, Productos entity, string[] selectedEtiquetas);
        Task DeleteAsync(int id);

    }
}
