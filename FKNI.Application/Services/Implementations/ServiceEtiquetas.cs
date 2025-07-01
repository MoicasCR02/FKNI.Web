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
    public class ServiceEtiquetas : IServiceEtiquetas
    {
        private readonly IRepositoryEtiquetas _repository;
        private readonly IMapper _mapper;
        public ServiceEtiquetas(IRepositoryEtiquetas repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<EtiquetasDTO> FindByIdAsync(int id_etiqueta)
        {
            var @object = await _repository.FindByIdAsync(id_etiqueta);
            var objectMapped = _mapper.Map<EtiquetasDTO>(@object);
            return objectMapped;
        }
        public async Task<ICollection<EtiquetasDTO>> ListAsync()
        {
            //Obtener datos del repositorio
            var list = await _repository.ListAsync();

            var collection = _mapper.Map<ICollection<EtiquetasDTO>>(list);
            // Return lista
            return collection;
        }
    }
}
