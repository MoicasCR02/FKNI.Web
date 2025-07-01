using System;
using System.Collections.Generic;

namespace FKNI.Infraestructure.Models;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string? Telefono { get; set; }

    public int? IdRol { get; set; }

    public virtual ICollection<Carrito> Carrito { get; set; } = new List<Carrito>();

    public virtual Roles? IdRolNavigation { get; set; }

    public virtual ICollection<Pedidos> Pedidos { get; set; } = new List<Pedidos>();

    public virtual ICollection<Resenas> Resenas { get; set; } = new List<Resenas>();
}
