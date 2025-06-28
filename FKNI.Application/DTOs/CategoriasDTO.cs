using FKNI.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Application.DTOs
{
    public record CategoriasDTO
    {
        public int IdCategoria { get; set; }

        public string NombreCategoria { get; set; } = null!;

        public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();


    }
}
