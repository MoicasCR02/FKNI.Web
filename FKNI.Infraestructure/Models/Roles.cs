﻿using System;
using System.Collections.Generic;

namespace FKNI.Infraestructure.Models;

public partial class Roles
{
    public int IdRol { get; set; }

    public string NombreRol { get; set; } = null!;

    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
