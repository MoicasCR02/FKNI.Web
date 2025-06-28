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
        Task<Productos> FindByIdAsync(int id_producto);
    }
}
