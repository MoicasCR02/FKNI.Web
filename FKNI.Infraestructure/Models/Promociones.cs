using System;
using System.Collections.Generic;

namespace FKNI.Infraestructure.Models;

public partial class Promociones
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
