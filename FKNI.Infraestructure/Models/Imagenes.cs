using System;
using System.Collections.Generic;

namespace FKNI.Infraestructure.Models;

public partial class Imagenes
{
    public int IdImagen { get; set; }

    public byte[]? UrlImagen { get; set; }

    public int IdProducto { get; set; }

    public virtual Productos? IdProductoNavigation { get; set; }
}
