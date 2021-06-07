using BussinessLogic.Data;
using BussinessLogic.Logic;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApi.Controllers;
using Xunit;

namespace UnitTesting
{
    public class ProductApiValidator
    {
        public ProductApiValidator()
        {
            var options = new DbContextOptionsBuilder<JugueteriaDbContext>()
            .UseInMemoryDatabase(databaseName: "Producto")
            .Options;

            using (var context = new JugueteriaDbContext(options))
            {
                var repository = new ProductoRepository(context);


                context.Producto.Add(new Producto
                {
                    Nombre = "Producto Prueba",
                    Descripcion = "Prueba de producto precargado",
                    RestriccionEdad = 18,
                    Compania = "N/A",
                    Precio = 999
                });

                context.SaveChanges();

            }
        }


        [Fact]
        public void ValidateGetProducts_ShouldNotNull()
        {
            //Arrange

            List<Producto> productos = new List<Producto>();
            var options = new DbContextOptionsBuilder<JugueteriaDbContext>()
            .UseInMemoryDatabase(databaseName: "Producto")
            .Options;


            using (var context = new JugueteriaDbContext(options))
            {
                //Act
                var repository = new ProductoRepository(context);

                var controller = new ProductoController(repository);

                var result = controller.GetProductos();
                //Assert
                Assert.NotNull(result.Result);
            }

        }

        [Fact]
        public void ValidateGetProducts_Notfound()
        {
            //Arrange

            List<Producto> productos = new List<Producto>();
            var repositoryMock = new Mock<IProductoRepository>();


            //Act
            repositoryMock.Setup(r => r.GetProductosAsync()).Returns(productos);

            var controller = new ProductoController(repositoryMock.Object);

            var result = (NotFoundResult)controller.GetProductos().Result;
            //Assert
            Assert.Equal(result.StatusCode.ToString(), ((int)HttpStatusCode.NotFound).ToString());


        }

        [Fact]
        public void ValidateGetProductById_ShouldHaveValue()
        {
            //Arrange

            Producto producto = new Producto
            {
                Id = 1,
                Nombre = "Producto Prueba",
                Descripcion = "Prueba de producto precargado",
                RestriccionEdad = 18,
                Compania = "N/A",
                Precio = 999
            };
            var options = new DbContextOptionsBuilder<JugueteriaDbContext>()
            .UseInMemoryDatabase(databaseName: "Producto")
            .Options;


            using (var context = new JugueteriaDbContext(options))
            {
                var repositoryMock = new Mock<IProductoRepository>();


                //Act
                repositoryMock.Setup(r => r.GetProductoByIdAsync(1)).Returns(Task.FromResult<Producto>(producto));

                var controller = new ProductoController(repositoryMock.Object);

                var result = (OkObjectResult)controller.GetProductoByIdAsync(1).Result;
                //Assert
                Assert.Equal(result.Value, producto);
            }
        }
    }
}
