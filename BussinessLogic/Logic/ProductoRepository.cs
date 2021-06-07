using BussinessLogic.Data;
using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BussinessLogic.Logic
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly JugueteriaDbContext _context;
        public ProductoRepository(JugueteriaDbContext context)
        {
            _context = context;
        }
        public async Task<Producto> GetProductoByIdAsync(int Id)
        {
            return await _context.Producto.FindAsync(Id);
        }

        public IReadOnlyList<Producto> GetProductosAsync()
        {
            return _context.Producto.Select(p => p).ToList();
        }

        public async Task<Producto> GuardarProducto(Producto producto)
        {
            _context.Producto.Add(producto);

            await _context.SaveChangesAsync();

            return producto;
        }

        public async Task<Producto> EditarProducto(Producto producto)
        {
            try
            {
                _context.Producto.Update(producto);

                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            } 
            

            return producto;
        }

        public Boolean EliminarProducto(int id)
        {
            try
            {
                var producto = _context.Producto.Find(id);

                _context.Producto.Remove(producto);

                _context.SaveChanges();

                return true;
            } catch (Exception ex)
            {
                return false;
            }
            
        }
            
    }
}
