using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductoRepository
    {
        Task<Producto> GetProductoByIdAsync(int Id);
        IReadOnlyList<Producto> GetProductosAsync();
        Task<Producto> GuardarProducto(Producto producto);
        Task<Producto> EditarProducto(Producto producto);
        Boolean EliminarProducto(int id);
    }
}
