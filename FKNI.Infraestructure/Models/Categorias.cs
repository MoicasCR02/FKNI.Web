using System;
using System.Collections.Generic;

namespace FKNI.Infraestructure.Models;

public partial class Categorias
{
    public int IdCategoria { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
