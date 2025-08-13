using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FKNI.Infraestructure.Models;

public partial class Imagenes
{
    public int IdImagen { get; set; }

    public byte[]? UrlImagen { get; set; }

    public int IdProducto { get; set; }

    public virtual Productos? IdProductoNavigation { get; set; }

    [NotMapped]
    public List<string> ImagenesBase64 { get; set; } = new List<string>();
}
