using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet]
        public ActionResult<List<Producto>> GetProductos()
        {
            var productos = _productoRepository.GetProductosAsync();
            return Ok(productos);
        }

        [HttpPost]
        public ActionResult<Producto> GuadarProducto(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Producto = _productoRepository.GuardarProducto(producto);

            return Ok(Producto);
        }

        [HttpPut]
        public ActionResult<Producto> EditarProducto(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Producto = _productoRepository.EditarProducto(producto);

            return Ok(Producto);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Boolean> EliminarProducto(int id)
        {
            var eliminado = _productoRepository.EliminarProducto(id);

            return Ok(eliminado);
        }
    }
}
