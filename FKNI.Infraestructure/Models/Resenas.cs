using System;
using System.Collections.Generic;

namespace FKNI.Infraestructure.Models;

public partial class Resenas
{
    public int IdUsuario { get; set; }

    public int IdProducto { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Comentario { get; set; }

    public int? Valoracion { get; set; }

    public bool? Estado { get; set; }

    public virtual Productos IdProductoNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
