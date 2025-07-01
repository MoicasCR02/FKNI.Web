using FKNI.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Application.DTOs
{
    public record EtiquetasDTO
    {
        public int IdEtiqueta { get; set; }

        public string NombreEtiqueta { get; set; } = null!;

        public virtual ICollection<Productos> IdProducto { get; set; } = new List<Productos>();
    }
}
