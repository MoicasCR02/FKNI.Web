﻿using FKNI.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryEtiquetas
    {
        Task<ICollection<Etiquetas>> ListAsync();
        Task<Etiquetas> FindByIdAsync(int id);
    }
}
