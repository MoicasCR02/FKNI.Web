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

        public virtual ICollection<Productos> IdProducto { get; set; } = new List<Productos>();
    }
}
