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
    }
}
