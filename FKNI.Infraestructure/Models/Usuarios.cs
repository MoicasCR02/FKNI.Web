using System;
using System.Collections.Generic;

namespace FKNI.Infraestructure.Models;

public partial class Usuarios
{
    public int id_usuario { get; set; }

    public string nombre_usuario { get; set; } = null!;

    public string correo { get; set; } = null!;

    public string contrasena { get; set; } = null!;

    public DateTime fecha_registro { get; set; }

    public string? telefono { get; set; }

    public int? id_rol { get; set; }

    public virtual ICollection<Carrito> Carrito { get; set; } = new List<Carrito>();

    public virtual Roles? IdRolNavigation { get; set; }

    public virtual ICollection<Pedidos> Pedidos { get; set; } = new List<Pedidos>();

    public virtual ICollection<Resenas> Resenas { get; set; } = new List<Resenas>();
}
