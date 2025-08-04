using AutoMapper;
using FKNI.Application.DTOs;
using FKNI.Application.Services.Interfaces;
using FKNI.Infraestructure.Models;
using FKNI.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Application.Services.Implementations
{
    public class ServiceImagenes : IServiceImagenes
    {
        private readonly IRepositoryImagenes _repository;
        private readonly IMapper _mapper;
        public ServiceImagenes(IRepositoryImagenes repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ImagenesDTO> FindByIdAsync(int id_imagen)
        {
            var @object = await _repository.FindByIdAsync(id_imagen);
            var objectMapped = _mapper.Map<ImagenesDTO>(@object);
            return objectMapped;
        }
        public async Task<ICollection<ImagenesDTO>> ListAsync()
        {
            //Obtener datos del repositorio
            var list = await _repository.ListAsync();
            // Map List<Usurios> a ICollection<BodegaDTO>
            var collection = _mapper.Map<ICollection<ImagenesDTO>>(list);
            // Return lista
            return collection;
        }

        public async Task<List<ImagenesDTO>> ObtenerPorProductoAsync(int idProducto)
        {
            var list = await _repository.ObtenerPorProductoAsync(idProducto);
            return _mapper.Map<List<ImagenesDTO>>(list);
        }

        public async Task<int> AddAsync(ImagenesDTO dto)
        {
            var objectMapped = _mapper.Map<Imagenes>(dto);

            // Return
            return await _repository.AddAsync(objectMapped);
        }

        public async Task UpdateAsync(ImagenesDTO dto)
        {
            //Obtenga el modelo original a actualizar
            var @object = await _repository.FindByIdAsync(dto.IdProducto);
            //       source, destination
            var entity = _mapper.Map(dto, @object!);


            await _repository.UpdateAsync(entity);
        }
        public async Task DeleteAsync(int id, int idProducto)
        {
            await _repository.DeleteAsync(id, idProducto);
        }

    }
}
