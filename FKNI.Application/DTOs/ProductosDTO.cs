using FKNI.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Application.DTOs
{
    public record ProductosDTO
    {
        public int IdProducto { get; set; }

        public string NombreProducto { get; set; } = null!;

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public decimal? PromedioValoracion { get; set; }

        public int? IdCategoria { get; set; }

        public bool? Estado { get; set; }

        public virtual ICollection<DetalleCarrito> DetalleCarrito { get; set; } = new List<DetalleCarrito>();

        public virtual ICollection<DetallePedidoProducto> DetallePedidoProducto { get; set; } = new List<DetallePedidoProducto>();

        public virtual Categorias? IdCategoriaNavigation { get; set; }

        public virtual ICollection<Resenas> Resenas { get; set; } = new List<Resenas>();

        public virtual ICollection<Etiquetas> IdEtiqueta { get; set; } = new List<Etiquetas>();

        public virtual ICollection<Imagenes> IdImagen { get; set; } = new List<Imagenes>();

    }
}
