using FKNI.Application.DTOs;
using FKNI.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Application.Services.Interfaces
{
    public interface IServicePromociones
    {
        Task<ICollection<PromocionesDTO>> ListAsync();
        Task<PromocionesDTO > FindByIdAsync(int id_promocion);

        

    }
}
