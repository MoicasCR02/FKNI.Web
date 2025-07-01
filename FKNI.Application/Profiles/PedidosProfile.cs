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
    public class PedidosProfile : Profile
    {
        public PedidosProfile()
        {
            CreateMap<PedidosDTO,  Pedidos>().ReverseMap();
        }
    }
}
