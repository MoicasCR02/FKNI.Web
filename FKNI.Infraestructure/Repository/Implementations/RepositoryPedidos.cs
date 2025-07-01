﻿using FKNI.Infraestructure.Data;
using FKNI.Infraestructure.Models;
using FKNI.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNI.Infraestructure.Repository.Implementations
{
    public class RepositoryPedidos : IRepositoryPedidos
    {
        private readonly FKNIContext _context;
        public RepositoryPedidos(FKNIContext context)
        {
            _context = context;
        }
        public async Task<Pedidos> FindByIdAsync(int id_pedido)
        {
            //Obtener un Libro con su autor y las lista de categorías
            var @object = await _context.Set<Pedidos>()
                                .Where(x => x.IdPedido == id_pedido)
                                .Include(x => x.IdClienteNavigation)
                                .Include(x => x.IdEstadoNavigation)
                                .Include(x => x.IdPagoNavigation)
                                .Include(x => x.DetallePedidoProducto).ThenInclude(dp => dp.IdProductoNavigation) // Incluye la navegación al producto
                                .Include(x => x.DetallePedido)
                                .FirstAsync();
            return @object!;
        }
        public async Task<ICollection<Pedidos>> ListAsync()
        {
            //Listar los libros incluyendo su autor, ordenado de forma descendente
            var collection = await _context.Set<Pedidos>()
                                .Include(x => x.IdClienteNavigation)
                                .Include(x => x.IdEstadoNavigation)
                                .Include(x => x.IdPagoNavigation)
                                .Include(x => x.DetallePedidoProducto).ThenInclude(dp => dp.IdProductoNavigation) // Incluye la navegación al producto
                                .OrderByDescending(x => x.IdPedido)
                                .Include(x => x.DetallePedido)
                                .ToListAsync();
            return collection;
        }
    }
}
