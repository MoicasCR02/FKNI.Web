using FKNI.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Application.DTOs
{
    public record PromocionesDTO
    {
        public int IdPromocion { get; set; }

        public string? TipoPromocion { get; set; }

        public int? IdProducto { get; set; }

        public int? IdCategoria { get; set; }

        public decimal Descuento { get; set; }

        public DateOnly? FechaInicio { get; set; }

        public DateOnly? FechaFin { get; set; }

        public virtual Categorias? IdCategoriaNavigation { get; set; }

        public virtual Productos? IdProductoNavigation { get; set; }
    }
}
