using FKNI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Application.Services.Interfaces
{
    public interface IServiceEtiquetas
    {
        Task<ICollection<EtiquetasDTO>> ListAsync();
        Task<EtiquetasDTO> FindByIdAsync(int id_etiqueta);
    }
}
