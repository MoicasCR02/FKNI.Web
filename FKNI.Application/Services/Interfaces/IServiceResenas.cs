using FKNI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Application.Services.Interfaces
{
    public interface IServiceResenas
    {
        Task<ICollection<ResenasDTO>> ListAsync();
        Task<ResenasDTO> FindByIdAsync(int id_usuario, int id_producto);
    }
}
