using System;
using System.Collections.Generic;

namespace FKNI.Infraestructure.Models;

public partial class Estados
{
    public int IdEstado { get; set; }

    public string NombreEstado { get; set; } = null!;

    public virtual ICollection<Pedidos> Pedidos { get; set; } = new List<Pedidos>();
}
