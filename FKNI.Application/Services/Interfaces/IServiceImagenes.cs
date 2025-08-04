using FKNI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Application.Services.Interfaces
{
    public interface IServiceImagenes
    {
        Task<ICollection<ImagenesDTO>> ListAsync();
        Task<ImagenesDTO> FindByIdAsync(int id_imagen);

        Task<List<ImagenesDTO>> ObtenerPorProductoAsync(int idProducto);
        Task<int> AddAsync(ImagenesDTO dto);
        Task UpdateAsync(ImagenesDTO dto);
        Task DeleteAsync(int id, int idProducto);


    }
}
