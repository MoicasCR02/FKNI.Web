using AutoMapper;
using FKNI.Application.DTOs;
using FKNI.Application.Services.Interfaces;
using FKNI.Infraestructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Application.Services.Implementations
{
    public class ServiceResenas : IServiceResenas
    {
        private readonly IRepositoryResenas _repository;
        private readonly IMapper _mapper;
        public ServiceResenas(IRepositoryResenas repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResenasDTO> FindByIdAsync(int id_usuario, int id_producto)
        {
            var @object = await _repository.FindByIdAsync(id_usuario,id_producto);
            var objectMapped = _mapper.Map<ResenasDTO>(@object);
            return objectMapped;
        }
        public async Task<ICollection<ResenasDTO>> ListAsync()
        {
            //Obtener datos del repositorio
            var list = await _repository.ListAsync();
            // Map List<Usurios> a ICollection<BodegaDTO>
            var collection = _mapper.Map<ICollection<ResenasDTO>>(list);
            // Return lista
            return collection;
        }
    }
}
