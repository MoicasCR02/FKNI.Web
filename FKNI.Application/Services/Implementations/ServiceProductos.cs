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
    public class ServiceProductos : IServiceProductos
    {
        private readonly IRepositoryProductos _repository;
        private readonly IMapper _mapper;
        public ServiceProductos(IRepositoryProductos repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProductosDTO> FindByIdAsync(int id_producto)
        {
            var @object = await _repository.FindByIdAsync(id_producto);
            var objectMapped = _mapper.Map<ProductosDTO>(@object);
            return objectMapped;
        }
        public async Task<ICollection<ProductosDTO>> ListAsync()
        {
            //Obtener datos del repositorio
            var list = await _repository.ListAsync();
            // Map List<Usurios> a ICollection<BodegaDTO>
            var collection = _mapper.Map<ICollection<ProductosDTO>>(list);
            // Return lista
            return collection;
        }

        public async Task<int> AddAsync(ProductosDTO dto, string[] selectedEtiquetas)
        {
            // Map LibroDTO to Libro
            var objectMapped = _mapper.Map<Productos>(dto);

            // Return
            return await _repository.AddAsync(objectMapped, selectedEtiquetas);
        }

        public async Task UpdateAsync(int id, ProductosDTO dto, string[] selectedEtiquetas)
        {
            var entity = await _repository.FindByIdAsync(id);
            // Este mapea el dto al objeto existente SIN cambiar el Id
            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(id,entity, selectedEtiquetas);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
