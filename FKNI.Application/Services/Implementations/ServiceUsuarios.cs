using AutoMapper;
using FKNI.Application.DTOs;
using FKNI.Application.Services.Interfaces;
using FKNI.Infraestructure.Models;
using FKNI.Infraestructure.Repository.Implementations;
using FKNI.Infraestructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Application.Services.Implementations
{
    public class ServiceUsuarios : IServiceUsuarios
    {
        private readonly IRepositoryUsuarios _repository;
        private readonly IMapper _mapper;
        public ServiceUsuarios(IRepositoryUsuarios repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UsuariosDTO> FindByIdAsync(int id_usuario)
        {
            var @object = await _repository.FindByIdAsync(id_usuario);
            var objectMapped = _mapper.Map<UsuariosDTO>(@object);
            return objectMapped;
        }
        public async Task<ICollection<UsuariosDTO>> ListAsync()
        {
            //Obtener datos del repositorio
            var list = await _repository.ListAsync();
            // Map List<Usurios> a ICollection<BodegaDTO>
            var collection = _mapper.Map<ICollection<UsuariosDTO>>(list);
            // Return lista
            return collection;
        }
    }
}
