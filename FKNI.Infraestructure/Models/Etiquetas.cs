using System;
using System.Collections.Generic;

namespace FKNI.Infraestructure.Models;

public partial class Etiquetas
{
    public int IdEtiqueta { get; set; }

    public string NombreEtiqueta { get; set; } = null!;

    public virtual ICollection<Productos> IdProducto { get; set; } = new List<Productos>();
}
