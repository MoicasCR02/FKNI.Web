using System;
using System.Collections.Generic;

namespace FKNI.Infraestructure.Models;

public partial class DetallePedido
{
    public int IdDetalle { get; set; }

    public int? IdPedido { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Impuesto { get; set; }

    public decimal? TotalConImpuesto { get; set; }

    public virtual Pedidos? IdPedidoNavigation { get; set; }
}
