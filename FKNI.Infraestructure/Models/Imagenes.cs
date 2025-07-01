using System;
using System.Collections.Generic;

namespace FKNI.Infraestructure.Models;

public partial class Imagenes
{
    public int IdImagen { get; set; }

    public byte[]? UrlImagen { get; set; }

    public virtual ICollection<Productos> IdProducto { get; set; } = new List<Productos>();
}
