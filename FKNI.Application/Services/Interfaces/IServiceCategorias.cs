using FKNI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Application.Services.Interfaces
{
    public interface IServiceCategorias
    {
        Task<ICollection<CategoriasDTO>> ListAsync();
        Task<CategoriasDTO> FindByIdAsync(int id_categoria);

        Task<ICollection<CategoriasDTO>> SinPromo();
    }
}
