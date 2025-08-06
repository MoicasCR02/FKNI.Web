using AutoMapper;
using FKNI.Application.DTOs;
using FKNI.Application.Services.Interfaces;
using FKNI.Infraestructure.Models;
using FKNI.Infraestructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Application.Services.Implementations
{
    public class ServicePromociones : IServicePromociones
    {
        private readonly IRepositoryPromociones _repository;
        private readonly IMapper _mapper;
        public ServicePromociones(IRepositoryPromociones repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PromocionesDTO> FindByIdAsync(int id_promo)
        {
            var @object = await _repository.FindByIdAsync(id_promo);
            var objectMapped = _mapper.Map<PromocionesDTO>(@object);
            return objectMapped;
        }
        public async Task<ICollection<PromocionesDTO>> ListAsync()
        {
            //Obtener datos del repositorio
            var list = await _repository.ListAsync();
            // Map List<Usurios> a ICollection<BodegaDTO>
            var collection = _mapper.Map<ICollection<PromocionesDTO>>(list);
            // Return lista
            return collection;
        }

        public async Task<int> AddAsync(PromocionesDTO dto)
        {
            // Map LibroDTO to Libro
            var objectMapped = _mapper.Map<Promociones>(dto);

            // Return
            return await _repository.AddAsync(objectMapped);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
