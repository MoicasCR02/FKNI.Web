using FKNI.Application.DTOs;
using FKNI.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Application.Services.Interfaces
{
        public interface IServiceProductos
        {
            Task<ICollection<ProductosDTO>> ListAsync();
            Task<ProductosDTO> FindByIdAsync(int id_producto);
        }   
}
