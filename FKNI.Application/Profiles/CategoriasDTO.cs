using AutoMapper;
using FKNI.Application.DTOs;
using FKNI.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Application.Profiles
{
    public class CategoriasProfile : Profile
    {
        public CategoriasProfile()
        {
            CreateMap<CategoriasDTO, Categorias>().ReverseMap();
        }
    }
}
