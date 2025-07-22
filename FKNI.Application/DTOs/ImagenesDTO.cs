using FKNI.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Application.DTOs
{
    public record ImagenesDTO
    {
        public int IdImagen { get; set; }

        public byte[]? UrlImagen { get; set; }

        public int IdProducto { get; set; }

        public virtual Productos? IdProductoNavigation { get; set; }
    }
}
    